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

        public override bool GetDefaultVisibility(PlayerDrawSet drawInfo)
        {
            return ModContent.GetInstance<FargoConfig>().DebuffDisplay && !Main.hideUI
                && drawInfo.drawPlayer.whoAmI == Main.myPlayer && drawInfo.drawPlayer.active && !drawInfo.drawPlayer.dead && !drawInfo.drawPlayer.ghost
                && drawInfo.drawPlayer.buffType.Count(d => Main.debuff[d] && !debuffsToIgnore.Contains(d)) > 0;
        }

        public override Position GetDefaultPosition() => new Between();

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
                    Texture2D buffIcon = Terraria.GameContent.TextureAssets.Buff[debuffs[j + i]].Value;
                    Color buffColor = Color.White * ModContent.GetInstance<FargoConfig>().DebuffOpacity;
                    Vector2 drawPos = (player.gravDir > 0 ? player.Top : player.Bottom);
                    drawPos.Y -= (32f + yOffset) * player.gravDir;
                    drawPos.X += 32f * (i - midpoint);

                    drawPos -= player.MountedCenter; //turn it into just the offset from player center
                    drawPos = drawPos.RotatedBy(-player.fullRotation); //correct for player rotation????
                    drawPos += player.MountedCenter;
                    drawPos -= Main.screenPosition;

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
