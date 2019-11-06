using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas
{
    public class FargoPlayer : ModPlayer
    {
        public int oldSelected;
        bool IsReuse = false;
        public bool battleCry;
        private bool hasMirror;
        private int mirrorCD;
        private bool hasRod;
        internal int rodCD;

        public override void SetupStartInventory(IList<Item> items)
        {
            Item item = new Item();
            item.SetDefaults(mod.ItemType("Stats"));
            items.Add(item);
        }

        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            //saves what the item selected was then switches to the hotkey item and uses it 
            if (Fargowiltas.CustomKey.JustPressed)
            {
                oldSelected = player.selectedItem;
                player.selectedItem = 40;
                player.controlUseItem = true;
                IsReuse = player.HeldItem.autoReuse;
                player.HeldItem.autoReuse = true;
                player.releaseUseItem = true;
            }
            //switches back to the old item (has some big ol jank)
            if(Fargowiltas.CustomKey.JustReleased)
            {
                player.controlUseItem = false;
                player.releaseUseItem = false;
                player.HeldItem.autoReuse = IsReuse;
                player.selectedItem = oldSelected;
            }
            if (Fargowiltas.RodKey.JustPressed && hasRod)
            {
                //.5 second cd
                if (rodCD == 0 && Main.myPlayer == player.whoAmI)
                {
                    Vector2 vector32;
                    vector32.X = Main.mouseX + Main.screenPosition.X;
                    if (player.gravDir == 1f)
                    {
                        vector32.Y = Main.mouseY + Main.screenPosition.Y - player.height;
                    }
                    else
                    {
                        vector32.Y = Main.screenPosition.Y + Main.screenHeight - Main.mouseY;
                    }

                    vector32.X -= (player.width / 2);

                    if (vector32.X > 50f && vector32.X < (Main.maxTilesX * 16 - 50) && vector32.Y > 50f && vector32.Y < (Main.maxTilesY * 16 - 50))
                    {
                        int num246 = (int)(vector32.X / 16f);
                        int num247 = (int)(vector32.Y / 16f);
                        if ((Main.tile[num246, num247].wall != 87 || num247 <= Main.worldSurface || NPC.downedPlantBoss) && !Collision.SolidCollision(vector32, player.width, player.height))
                        {
                            player.Teleport(vector32, 1, 0);
                            NetMessage.SendData(65, -1, -1, null, 0, player.whoAmI, vector32.X, vector32.Y, 1, 0, 0);

                            if (player.chaosState)
                            {
                                player.statLife -= player.statLifeMax2 / 7;

                                PlayerDeathReason damageSource = PlayerDeathReason.ByOther(13);
                                if (Main.rand.Next(2) == 0)
                                {
                                    damageSource = PlayerDeathReason.ByOther(player.Male ? 14 : 15);
                                }
                                if (player.statLife <= 0)
                                {
                                    player.KillMe(damageSource, 1.0, 0, false);
                                }

                                player.lifeRegenCount = 0;
                                player.lifeRegenTime = 0;
                            }
                            player.AddBuff(88, 360, true);

                            if (Fargowiltas.instance.fargoLoaded)
                            {
                                player.AddBuff(ModLoader.GetMod("FargowiltasSouls").BuffType("FirstStrike"), 60);
                            }

                            rodCD = 30;
                        }
                    }
                }
            }

            if(Fargowiltas.HomeKey.JustPressed && hasMirror && mirrorCD == 0)
            {
                if (Main.rand.Next(2) == 0)
                {
                    Dust.NewDust(player.position, player.width, player.height, 15, 0.0f, 0.0f, 150, Color.White, 1.1f);
                }

                for (int i = 0; i < 70; ++i)
                {
                    Dust.NewDust(player.position, player.width, player.height, 15, (float)(player.velocity.X * 0.5), (float)(player.velocity.Y * 0.5), 150, Color.White, 1.5f);
                }

                player.grappling[0] = -1;
                player.grapCount = 0;

                for (int i = 0; i < 1000; ++i)
                {
                    if (Main.projectile[i].active && Main.projectile[i].owner == player.whoAmI && Main.projectile[i].aiStyle == 7)
                        Main.projectile[i].Kill();
                }

                Main.PlaySound(SoundID.Item6, player.Center);

                player.Spawn();

                for (int i = 0; i < 70; ++i)
                {
                    Dust.NewDust(player.position, player.width, player.height, 15, 0.0f, 0.0f, 150, Color.White, 1.5f);
                }

                mirrorCD = 120;
            }
        }

        public override void ResetEffects()
        {
            hasMirror = false;
            hasRod = false;
        }

        public override void PostUpdateEquips()
        {
            for (int j = 0; j < player.inventory.Length; j++)
            {
                if (hasMirror && hasRod)
                {
                    break;
                }

                Item item = player.inventory[j];

                if (item.type == ItemID.IceMirror || item.type == ItemID.MagicMirror || item.type == ItemID.CellPhone)
                {
                    hasMirror = true;
                }

                if (Fargowiltas.instance.fargoLoaded && (item.type == ModLoader.GetMod("FargowiltasSouls").ItemType("WorldShaperSoul") || item.type == ModLoader.GetMod("FargowiltasSouls").ItemType("DimensionSoul") || item.type == ModLoader.GetMod("FargowiltasSouls").ItemType("EternitySoul")))
                {
                    hasMirror = true;
                }

                if (item.type == ItemID.RodofDiscord)
                {
                    hasRod = true;
                }
            }

            if(mirrorCD != 0)
            {
                mirrorCD--;
            }

            if (rodCD != 0)
            {
                rodCD--;
            }

            if (NPC.AnyNPCs(NPCID.BrainofCthulhu))
            {
                player.ZoneCrimson = true;
            }
            if (NPC.AnyNPCs(NPCID.EaterofWorldsHead))
            {
                player.ZoneCorrupt = true;
            }
        }

        public override void CatchFish(Item fishingRod, Item bait, int power, int liquidType, int poolSize, int worldLayer, int questFish, ref int caughtType, ref bool junk)
        {
            //crate chance
            if (Main.rand.Next(100) < (5 + (player.cratePotion ? 10 : 0)))
            {
                if(liquidType == 0 && player.ZoneSnow)
                {
                    caughtType = mod.ItemType("IceCrate");
                }
                else if (liquidType == 1 && ItemID.Sets.CanFishInLava[fishingRod.type] && player.ZoneUnderworldHeight)
                {
                    caughtType = mod.ItemType("ShadowCrate");
                }
            }
        }
    }
}
