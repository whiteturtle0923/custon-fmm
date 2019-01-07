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

            if (Array.IndexOf(thrown, item.type) > -1)
            {
                /*foreach(TooltipLine line in tooltips)
                {
                    if (line.Name == "")
                    {

                    }
                }*/

                TooltipLine line = new TooltipLine(mod, "help", "Right click to convert");
                tooltips.Add(line);
            }

            if (item.type == ItemID.CrystalBall)
            {
                TooltipLine line = new TooltipLine(mod, "Altar", "Functions as a Demon altar as well");
                tooltips.Add(line);
            }

            if (item.type == ItemID.GoodieBag)
            {
                TooltipLine line = new TooltipLine(mod, "help", "Also use this to toggle the Halloween season");
                tooltips.Add(line);
            }

            if (item.type == ItemID.Present)
            {
                TooltipLine line = new TooltipLine(mod, "help", "Also use this to toggle the Christmas season");
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

            NewThrown(item, player, item.Name.Replace(" ", "").Replace("'", "").Replace("-", "").Replace(":", ""));
        }

        private void NewThrown(Item item, Player player, string thrown)
        {
            int num = Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, mod.ItemType(thrown + "Thrown"), 1, false, item.prefix);

            if (Main.netMode == 1)
            {
                NetMessage.SendData(21, -1, -1, null, num, 1f, 0f, 0f, 0, 0, 0);
            }
        }
    }
}
