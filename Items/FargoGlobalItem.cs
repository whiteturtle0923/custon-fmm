using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
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

            if (item.type == ItemID.CrystalBall)
            {
                TooltipLine line = new TooltipLine(mod, "Altar", "Functions as a Demon altar as well");
                tooltips.Add(line);
            }
        }

        public override bool PreDrawTooltipLine(Item item, DrawableTooltipLine line, ref int yOffset)
        {
            if (line.Name == "OneDrop")
            {
                float num28 = 1f;
                int num29 = (int)((float)Main.mouseTextColor * num28);
                Color black = Color.Black;
                for (int l = 0; l < 5; l++)
                {
                    int num30 = 0;
                    int num31 = yOffset;
                    if (l == 4)
                    {
                        black = new Color(num29, num29, num29, num29);
                    }
                    if (l == 0)
                    {
                        num30--;
                    }
                    else if (l == 1)
                    {
                        num30++;
                    }
                    else if (l == 2)
                    {
                        num31--;
                    }
                    else if (l == 3)
                    {
                        num31++;
                    }
                    Main.spriteBatch.Draw(Main.oneDropLogo, new Vector2((float)(num30 + line.X), (float)(num31 + line.Y)), null, black, 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
                }
            }

            return true;
        }

        public override void SetDefaults(Item item)
        {
            if (item.maxStack > 10 && item.maxStack != 100 && item.type != ItemID.CopperCoin && item.type != ItemID.SilverCoin && item.type != ItemID.GoldCoin && item.type != ItemID.PlatinumCoin)
            {
                item.maxStack = 9999;
            }
        }

        public override void OpenVanillaBag(string context, Player player, int arg)
        {
            if (arg == ItemID.KingSlimeBossBag)
            {
                if (Main.rand.Next(50) == 0)
                {
                    player.QuickSpawnItem(ItemID.SlimeStaff);
                }
            }

            if (arg == ItemID.WoodenCrate)
            {
                if (Main.rand.Next(45) == 0)
                {
                    int[] drops = { ItemID.Spear, ItemID.Blowpipe, ItemID.WandofSparking, ItemID.WoodenBoomerang };
                    player.QuickSpawnItem(drops[Main.rand.Next(drops.Length)]);
                }
            }

            if (arg == ItemID.GoldenCrate)
            {
                if (Main.rand.Next(25) == 0)
                {
                    int[] drops = { ItemID.BandofRegeneration, ItemID.MagicMirror, ItemID.CloudinaBottle, ItemID.EnchantedBoomerang, ItemID.ShoeSpikes, ItemID.FlareGun, ItemID.HermesBoots, ItemID.LavaCharm, ItemID.SandstorminaBottle, ItemID.FlyingCarpet };
                    player.QuickSpawnItem(drops[Main.rand.Next(drops.Length)]);
                }
            }

            if (context == "lockBox")
            {
                if (Main.rand.Next(7) == 0)
                {
                    player.QuickSpawnItem(ItemID.Valor);
                }
            }
        }

        public override bool CanRightClick(Item item)
        {
            if (Array.IndexOf(thrown, item.type) > -1)
            {
                return true;
            }

            return false;
        }

        public override void RightClick(Item item, Player player)
        {
            if (Array.IndexOf(thrown, item.type) > -1)
            {
                Main.NewText(item.Name, 175, 75, 255);
                NewThrown(item, player, item.Name.Replace(" ", "").Replace("'", "").Replace("-", "").Replace(":", ""));
            }
        }

        private void NewThrown(Item item, Player player, string thrown)
        {
            Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, mod.ItemType(thrown + "Thrown"), 1, false, (int)item.prefix);
        }
    }
}