using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Fargowiltas.NPCs;

namespace Fargowiltas
{
    public class FargoPlayer : ModPlayer
    {
        internal bool BattleCry;

        private int oldSelected;
        private bool isReuse = false;

        private int mirrorCD;
        private int rodCD;
        private bool hasMirror;
        private bool hasRod;

        public override void SetupStartInventory(IList<Item> items, bool mediumCoreDeath)
        {
            Item item = new Item();
            item.SetDefaults(ItemType<Items.Misc.Stats>());
            items.Add(item);
        }

        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            // Saves what the item selected was then switches to the hotkey item and uses it
            if (Fargowiltas.CustomKey.JustPressed)
            {
                oldSelected = player.selectedItem;
                player.selectedItem = 40;
                player.controlUseItem = true;
                isReuse = player.HeldItem.autoReuse;
                player.HeldItem.autoReuse = true;
                player.releaseUseItem = true;
            }

            // Switches back to the old item (has some big ol jank)
            if (Fargowiltas.CustomKey.JustReleased)
            {
                player.controlUseItem = false;
                player.releaseUseItem = false;
                player.HeldItem.autoReuse = isReuse;
                player.selectedItem = oldSelected;
            }

            if (Fargowiltas.RodKey.JustPressed && hasRod)
            {
                // .5 second cd
                if (rodCD == 0 && Main.myPlayer == player.whoAmI)
                {
                    Vector2 targetPos;
                    targetPos.X = Main.MouseWorld.X;
                    targetPos.Y = (player.gravDir == -1f) ? Main.MouseWorld.Y : Main.MouseWorld.Y - player.height;

                    targetPos.X -= player.width / 2;

                    if (targetPos.X > 50f && targetPos.X < (Main.maxTilesX * 16 - 50) && targetPos.Y > 50f && targetPos.Y < (Main.maxTilesY * 16 - 50))
                    {
                        int tileX = (int)(targetPos.X / 16f);
                        int tileY = (int)(targetPos.Y / 16f);
                        if ((Main.tile[tileX, tileY].wall != WallID.LihzahrdBrickUnsafe || tileY <= Main.worldSurface || NPC.downedPlantBoss) && !Collision.SolidCollision(targetPos, player.width, player.height))
                        {
                            player.Teleport(targetPos, 1);
                            NetMessage.SendData(MessageID.Teleport, -1, -1, null, 0, player.whoAmI, targetPos.X, targetPos.Y, 1);

                            if (player.chaosState)
                            {
                                player.statLife -= player.statLifeMax2 / 7;

                                PlayerDeathReason damageSource = PlayerDeathReason.ByOther(13);
                                if (Main.rand.NextBool(2))
                                {
                                    damageSource = PlayerDeathReason.ByOther(player.Male ? 14 : 15);
                                }

                                if (player.statLife <= 0)
                                {
                                    player.KillMe(damageSource, 1d, 0);
                                }

                                player.lifeRegenCount = 0;
                                player.lifeRegenTime = 0;
                            }

                            player.AddBuff(BuffID.ChaosState, 360);

                            if (Fargowiltas.ModLoaded["FargowiltasSouls"])
                            {
                                Fargos();
                            }

                            rodCD = 30;
                        }
                    }
                }
            }

            if (Fargowiltas.HomeKey.JustPressed && hasMirror && mirrorCD == 0)
            {
                if (Main.rand.NextBool(2))
                {
                    Dust.NewDust(player.position, player.width, player.height, 15, 0f, 0f, 150, Color.White, 1.1f);
                }

                for (int i = 0; i < 70; ++i)
                {
                    Dust.NewDust(player.position, player.width, player.height, 15, (float)(player.velocity.X * 0.5), (float)(player.velocity.Y * 0.5), 150, Color.White, 1.5f);
                }

                player.grappling[0] = -1;
                player.grapCount = 0;

                for (int i = 0; i < Main.maxProjectiles; ++i)
                {
                    if (Main.projectile[i].active && Main.projectile[i].owner == player.whoAmI && Main.projectile[i].aiStyle == 7)
                    {
                        Main.projectile[i].Kill();
                    }
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

        private void Fargos()
        {
            if (player.GetModPlayer<FargowiltasSouls.FargoPlayer>().NinjaEnchant)
            {
                player.AddBuff(ModLoader.GetMod("FargowiltasSouls").BuffType("FirstStrike"), 60);
            }
        }

        public override void ResetEffects()
        {
            hasMirror = false;
            hasRod = false;
        }

        public override void PostUpdateEquips()
        {
            Mod soulsMod = ModLoader.GetMod("FargowiltasSouls");

            if (!hasMirror)
            {
                hasMirror = player.HasAnyItem(ItemID.IceMirror, ItemID.MagicMirror, ItemID.CellPhone);

                if (Fargowiltas.ModLoaded["FargowiltasSouls"])
                {
                    hasMirror = player.HasAnyItem(ItemID.IceMirror, ItemID.MagicMirror, ItemID.CellPhone, soulsMod.ItemType("WorldShaperSoul"), soulsMod.ItemType("DimensionSoul"), soulsMod.ItemType("EternitySoul"));
                }
            }

            if (!hasRod)
            {
                hasRod = player.HasItem(ItemID.RodofDiscord);
            }

            if (mirrorCD != 0)
            {
                mirrorCD--;
            }

            if (rodCD != 0)
            {
                rodCD--;
            }

            if (FargoGlobalNPC.BossIsAlive(ref FargoGlobalNPC.eaterBoss, NPCID.EaterofWorldsHead))
            {
                player.ZoneCorrupt = true;
            }

            if (FargoGlobalNPC.BossIsAlive(ref FargoGlobalNPC.brainBoss, NPCID.BrainofCthulhu))
            {
                player.ZoneCrimson = true;
            }

            if (FargoGlobalNPC.BossIsAlive(ref FargoGlobalNPC.plantBoss, NPCID.Plantera))
            {
                player.ZoneJungle = true;
            }
        }

        public override void CatchFish(Item fishingRod, Item bait, int power, int liquidType, int poolSize, int worldLayer, int questFish, ref int caughtType, ref bool junk)
        {
            // Crate chance
            if (Main.rand.Next(100) < (5 + (player.cratePotion ? 10 : 0)))
            {
                if (liquidType == 0 && player.ZoneSnow)
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
