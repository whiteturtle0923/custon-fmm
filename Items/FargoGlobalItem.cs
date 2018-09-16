using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items
{
    public class FargoGlobalItem : GlobalItem
    {
        private static int[] thrown = { ItemID.Bananarang, ItemID.BloodyMachete, ItemID.DayBreak, ItemID.EnchantedBoomerang, ItemID.Flamarang, ItemID.FruitcakeChakram, ItemID.IceBoomerang, ItemID.LightDisc, ItemID.MagicDagger, ItemID.PaladinsHammer, ItemID.PossessedHatchet, ItemID.ShadowFlameKnife, ItemID.ThornChakram, ItemID.ToxicFlask, ItemID.VampireKnives, ItemID.WoodenBoomerang, ItemID.WoodYoyo, ItemID.Rally, ItemID.CorruptYoyo, ItemID.CrimsonYoyo, ItemID.JungleYoyo, ItemID.Code1, ItemID.Valor, ItemID.Cascade, ItemID.FormatC, ItemID.Gradient, ItemID.Chik, ItemID.HelFire, ItemID.Amarok, ItemID.Code2, ItemID.Yelets, ItemID.RedsYoyo, ItemID.ValkyrieYoyo, ItemID.Kraken, ItemID.TheEyeOfCthulhu, ItemID.Terrarian, ItemID.FlyingKnife, ItemID.BallOHurt, ItemID.TheMeatball, ItemID.BlueMoon, ItemID.Sunfury, ItemID.DaoofPow, ItemID.FlowerPow, ItemID.ScourgeoftheCorruptor };

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            int[] yoyos = { mod.ItemType("CascadeThrown"), mod.ItemType("ChikThrown"), mod.ItemType("Code1Thrown"), mod.ItemType("Code2Thrown"), mod.ItemType("FormatCThrown"), mod.ItemType("GradientThrown"), mod.ItemType("KrakenThrown"), mod.ItemType("RallyThrown"), mod.ItemType("TerrarianThrown"), mod.ItemType("ValorThrown"), mod.ItemType("YeletsThrown") };

            if (Array.IndexOf(yoyos, item.type) > -1)
            {
                TooltipLine line = new TooltipLine(mod, "OneDrop", "");
                tooltips.Add(line);
            }

            // ReSharper disable once InvertIf
            if (item.type == ItemID.CrystalBall)
            {
                TooltipLine line = new TooltipLine(mod, "Altar", "Functions as a Demon altar as well");
                tooltips.Add(line);
            }
        }

        public override bool PreDrawTooltipLine(Item item, DrawableTooltipLine line, ref int yOffset)
        {
            if (line.Name != "OneDrop") return true;
            float num28 = 1f;
            int num29 = (int)(Main.mouseTextColor * num28);
            Color black = Color.Black;
            for (int l = 0; l < 5; l++)
            {
                int num30 = 0;
                int num31 = yOffset;
                // ReSharper disable once SwitchStatementMissingSomeCases
                switch (l)
                {
                    case 4:
                        black = new Color(num29, num29, num29, num29);
                        break;
                    case 0:
                        num30--;
                        break;
                    case 1:
                        num30++;
                        break;
                    case 2:
                        num31--;
                        break;
                    case 3:
                        num31++;
                        break;
                }

                Main.spriteBatch.Draw(Main.oneDropLogo, new Vector2((float)(num30 + line.X), (float)(num31 + line.Y)), null, black, 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
            }

            return true;
        }

        public override void SetDefaults(Item item)
        {
            if (item.maxStack > 10 && item.maxStack != 100 && item.type != ItemID.CopperCoin && item.type != ItemID.SilverCoin && item.type != ItemID.GoldCoin && item.type != ItemID.PlatinumCoin)
            {
                item.maxStack = 9999;
            }

            if (item.type == ItemID.GoodieBag || item.type == ItemID.Present)
            {
                item.consumable = false;
                item.useAnimation = 30;
                item.useTime = 30;
                item.useStyle = 4;
                item.UseSound = SoundID.Item44;
            }
        }

        public override bool UseItem(Item item, Player player)
        {
            // ReSharper disable once SwitchStatementMissingSomeCases
            switch (item.type)
            {
                case ItemID.GoodieBag:
                    FargoWorld.halloween = !FargoWorld.halloween;

                    Main.NewText(FargoWorld.halloween ? "Halloween has begun!" : "Halloween has ended!", 175, 75);

                    return true;
                case ItemID.Present:
                    FargoWorld.xmas = !FargoWorld.xmas;

                    Main.NewText(FargoWorld.xmas ? "Christmas has begun!" : "Christmas has ended!", 175, 75);

                    return true;
            }

            return false;
        }

        public override void UpdateInventory(Item item, Player player)
        {
            if(item.type == ItemID.RodofDiscord)
            {
                FargoPlayer p = player.GetModPlayer<FargoPlayer>(mod);
                //.5 second cd
                if (player.controlHook && p.rodCD == 0 && Main.myPlayer == player.whoAmI)
                {
                    Vector2 vector32;
                    vector32.X = (float)Main.mouseX + Main.screenPosition.X;
                    if (player.gravDir == 1f)
                    {
                        vector32.Y = (float)Main.mouseY + Main.screenPosition.Y - (float)player.height;
                    }
                    else
                    {
                        vector32.Y = Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY;
                    }
                    vector32.X -= (float)(player.width / 2);
                    if (vector32.X > 50f && vector32.X < (float)(Main.maxTilesX * 16 - 50) && vector32.Y > 50f && vector32.Y < (float)(Main.maxTilesY * 16 - 50))
                    {
                        int num246 = (int)(vector32.X / 16f);
                        int num247 = (int)(vector32.Y / 16f);
                        if ((Main.tile[num246, num247].wall != 87 || (double)num247 <= Main.worldSurface || NPC.downedPlantBoss) && !Collision.SolidCollision(vector32, player.width, player.height))
                        {
                            player.Teleport(vector32, 1, 0);
                            NetMessage.SendData(65, -1, -1, null, 0, (float)player.whoAmI, vector32.X, vector32.Y, 1, 0, 0);

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
                            p.rodCD = 30;
                        }
                    }
                }
                
                if(p.rodCD != 0)
                {
                    p.rodCD--;
                }
                
            }
        }

        public override void OpenVanillaBag(string context, Player player, int arg)
        {
            switch (arg)
            {
                case ItemID.KingSlimeBossBag:
                    if (Main.rand.Next(50) == 0)
                    {
                        player.QuickSpawnItem(ItemID.SlimeStaff);
                    }

                    break;
                case ItemID.WoodenCrate:
                    if (Main.rand.Next(45) == 0)
                    {
                        int[] drops = { ItemID.Spear, ItemID.Blowpipe, ItemID.WandofSparking, ItemID.WoodenBoomerang };
                        player.QuickSpawnItem(drops[Main.rand.Next(drops.Length)]);
                    }

                    break;
                case ItemID.GoldenCrate:
                    if (Main.rand.Next(25) == 0)
                    {
                        int[] drops = { ItemID.BandofRegeneration, ItemID.MagicMirror, ItemID.CloudinaBottle, ItemID.EnchantedBoomerang, ItemID.ShoeSpikes, ItemID.FlareGun, ItemID.HermesBoots, ItemID.LavaCharm, ItemID.SandstorminaBottle, ItemID.FlyingCarpet };
                        player.QuickSpawnItem(drops[Main.rand.Next(drops.Length)]);
                    }

                    break;
            }

            if (context != "lockBox") return;
            if (Main.rand.Next(7) == 0)
            {
                player.QuickSpawnItem(ItemID.Valor);
            }
        }

        public override bool CanRightClick(Item item) => Array.IndexOf(thrown, item.type) > -1;

        public override void RightClick(Item item, Player player)
        {      
            if (Array.IndexOf(thrown, item.type) <= -1) return;
            Main.NewText(item.Name, 175, 75);
            NewThrown(item, player, item.Name.Replace(" ", "").Replace("'", "").Replace("-", "").Replace(":", ""));
        }

        private void NewThrown(Item item, Player player, string thrown)
        {
            Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, mod.ItemType(thrown + "Thrown"), 1, false, item.prefix);
        }
    }
}