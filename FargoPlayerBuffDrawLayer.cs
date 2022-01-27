using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas
{
    public class FargoPlayerBuffDrawLayer : PlayerDrawLayer
    {
        public override bool IsHeadLayer => false;

        private readonly int[] debuffsToIgnore = {
            BuffID.Campfire,
            BuffID.HeartLamp,
            BuffID.Sunflower,
            BuffID.PeaceCandle,
            BuffID.StarInBottle,
            BuffID.Tipsy,
            BuffID.MonsterBanner,
            BuffID.Werewolf,
            BuffID.Merfolk,
            BuffID.CatBast,
            BuffID.BrainOfConfusionBuff,
            BuffID.NeutralHunger
        };

        private float globalTimeTracker;

        public override bool GetDefaultVisibility(PlayerDrawSet drawInfo)
        {
            //stop it from drawing multiple times per frame, e.g. with armor/dash afterimages that ruin opacity
            if (globalTimeTracker == Main.GlobalTimeWrappedHourly)
                return false;
            globalTimeTracker = Main.GlobalTimeWrappedHourly;

            return ModContent.GetInstance<FargoConfig>().DebuffOpacity > 0 && !Main.hideUI
                && drawInfo.drawPlayer.whoAmI == Main.myPlayer && drawInfo.drawPlayer.active && !drawInfo.drawPlayer.dead && !drawInfo.drawPlayer.ghost
                && drawInfo.drawPlayer.buffType.Count(d => Main.debuff[d] && !debuffsToIgnore.Contains(d)) > 0;
        }

        public override Position GetDefaultPosition() => new Between();

        //key is buff id
        //value is <old duration, max duration>
        //purpose of knowing old duration: get debuffed for 15sec, it decrease to 4sec, debuffed again for 10sec, recalculate ratio to match
        private Dictionary<int, Tuple<int, int>> memorizedDebuffDurations = new Dictionary<int, Tuple<int, int>>();

        protected override void Draw(ref PlayerDrawSet drawInfo)
        {
            Player player = drawInfo.drawPlayer;
            List<int> debuffs = player.buffType.Where(d => Main.debuff[d] && !debuffsToIgnore.Contains(d)).ToList();
            const int maxPerLine = 10;
            int yOffset = 0;
            for (int j = 0; j < debuffs.Count; j += maxPerLine)
            {
                int maxForThisLine = Math.Min(maxPerLine, debuffs.Count - j);
                float midpoint = maxForThisLine / 2f - 0.5f;
                for (int i = 0; i < maxForThisLine; i++)
                {
                    int debuffID = debuffs[j + i];

                    Vector2 drawPos = (player.gravDir > 0 ? player.Top : player.Bottom);
                    drawPos.Y -= (32f + yOffset) * player.gravDir;
                    drawPos.X += 32f * (i - midpoint);

                    drawPos -= player.MountedCenter; //turn it into just the offset from player center
                    drawPos = drawPos.RotatedBy(-player.fullRotation); //correct for player rotation????
                    drawPos += player.MountedCenter;
                    drawPos -= Main.screenPosition;

                    Texture2D buffIcon = Terraria.GameContent.TextureAssets.Buff[debuffID].Value;
                    Color buffColor = Color.White * ModContent.GetInstance<FargoConfig>().DebuffOpacity;

                    float faderRatio = ModContent.GetInstance<FargoConfig>().DebuffFaderRatio;
                    if (faderRatio > 0)
                    {
                        int index = Array.FindIndex(player.buffType, id => id == debuffID);
                        int currentDuration = player.buffTime[index];
                        if (currentDuration <= 1) //probably either a persistent debuff or one that will clear soon
                        {
                            if (memorizedDebuffDurations.TryGetValue(debuffID, out Tuple<int, int> knownDurations))
                            {
                                memorizedDebuffDurations.Remove(debuffID); //remove it
                                buffColor *= 1f - faderRatio; //like drawing 0% ratio so it doesnt jumpscare full opacity for 1 tick
                            }
                        }
                        else //is longer
                        {
                            //draw part of the rectangle to represent time remaining
                            if (memorizedDebuffDurations.TryGetValue(debuffID, out Tuple<int, int> knownDurations)
                                && knownDurations.Item1 >= currentDuration && knownDurations.Item2 > currentDuration)
                            {
                                int maxDuration = knownDurations.Item2;
                                float ratio = (float)currentDuration / maxDuration;
                                
                                int x = 0;
                                int y = (int)(buffIcon.Bounds.Height * (1f - ratio));
                                int width = buffIcon.Bounds.Width;
                                int height = (int)(buffIcon.Bounds.Height * ratio);
                                if (y + height > buffIcon.Bounds.Height) //just in case
                                    y = buffIcon.Bounds.Height - height;

                                Rectangle buffIconPortion = new Rectangle(x, y, width, height);
                                Vector2 drawPortion = drawPos + Vector2.UnitY * y * player.gravDir;
                                Color portionColor = buffColor * faderRatio;

                                drawInfo.DrawDataCache.Add(new DrawData(
                                    buffIcon, drawPortion, buffIconPortion, buffColor,
                                    (player.gravDir > 0 ? 0 : MathHelper.Pi) - player.fullRotation, buffIcon.Bounds.Size() / 2,
                                    1f, player.gravDir > 0 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0));

                                buffColor *= 1f - faderRatio;

                                //update known duration
                                memorizedDebuffDurations[debuffID] = new Tuple<int, int>(currentDuration, maxDuration);
                            }
                            else //if just got this debuff for the first time or it reapplied for longer, update max duration and draw at 100% opacity ratio
                            {
                                memorizedDebuffDurations[debuffID] = new Tuple<int, int>(currentDuration, currentDuration);
                            }
                        }
                    }

                    drawInfo.DrawDataCache.Add(new DrawData(
                        buffIcon, drawPos, buffIcon.Bounds, buffColor,
                        (player.gravDir > 0 ? 0 : MathHelper.Pi) - player.fullRotation, buffIcon.Bounds.Size() / 2,
                        1f, player.gravDir > 0 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0));
                }
                yOffset += (int)(32 * player.gravDir);
            }
        }
    }
}
