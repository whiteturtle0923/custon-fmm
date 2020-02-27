using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Fargowiltas.Items
{
    public class FargoGlobalItem : GlobalItem
    {
        private static readonly int[] Thrown = { ItemID.Bananarang, ItemID.BloodyMachete, ItemID.DayBreak, ItemID.EnchantedBoomerang, ItemID.Flamarang, ItemID.FruitcakeChakram, ItemID.IceBoomerang, ItemID.LightDisc, ItemID.MagicDagger, ItemID.PaladinsHammer, ItemID.PossessedHatchet, ItemID.ShadowFlameKnife, ItemID.ThornChakram, ItemID.ToxicFlask, ItemID.VampireKnives, ItemID.WoodenBoomerang, ItemID.WoodYoyo, ItemID.Rally, ItemID.CorruptYoyo, ItemID.CrimsonYoyo, ItemID.JungleYoyo, ItemID.Code1, ItemID.Valor, ItemID.Cascade, ItemID.FormatC, ItemID.Gradient, ItemID.Chik, ItemID.HelFire, ItemID.Amarok, ItemID.Code2, ItemID.Yelets, ItemID.RedsYoyo, ItemID.ValkyrieYoyo, ItemID.Kraken, ItemID.TheEyeOfCthulhu, ItemID.Terrarian, ItemID.FlyingKnife, ItemID.BallOHurt, ItemID.TheMeatball, ItemID.BlueMoon, ItemID.Sunfury, ItemID.DaoofPow, ItemID.FlowerPow, ItemID.ScourgeoftheCorruptor, ItemID.NorthPole };
        private static readonly int[] Summon = { ItemID.NimbusRod, ItemID.CrimsonRod, ItemID.BeeGun, ItemID.WaspGun, ItemID.PiranhaGun, ItemID.BatScepter };

        private static readonly int[] Hearts = new int[] { ItemID.Heart, ItemID.CandyApple, ItemID.CandyCane };
        private static readonly int[] Stars = new int[] { ItemID.Star, ItemID.SoulCake, ItemID.SugarPlum };

        private bool firstTick = true;

        public override bool InstancePerEntity => true;

        public override bool CloneNewInstances => true;

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            int[] yoyos = { mod.ItemType("CascadeThrown"), mod.ItemType("ChikThrown"), mod.ItemType("Code1Thrown"), mod.ItemType("Code2Thrown"), mod.ItemType("FormatCThrown"), mod.ItemType("GradientThrown"), mod.ItemType("KrakenThrown"), mod.ItemType("RallyThrown"), mod.ItemType("TerrarianThrown"), mod.ItemType("ValorThrown"), mod.ItemType("YeletsThrown") };

            if (Array.IndexOf(Thrown, item.type) > -1 || Array.IndexOf(Summon, item.type) > -1)
            {
                TooltipLine line = new TooltipLine(mod, "help", "Right click to convert");
                tooltips.Add(line);
            }

            if (Array.IndexOf(yoyos, item.type) > -1)
            {
                TooltipLine line = new TooltipLine(mod, "OneDrop", string.Empty);
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
            if (line.Name != "OneDrop")
            {
                return true;
            }

            int colorValue = (int)(Main.mouseTextColor * 1f);
            Color color = Color.Black;
            for (int l = 0; l < 5; l++)
            {
                int vecX = 0;
                int vecY = yOffset;

                switch (l)
                {
                    case 0:
                        vecX--;
                        break;

                    case 1:
                        vecX++;
                        break;

                    case 2:
                        vecY--;
                        break;

                    case 3:
                        vecY++;
                        break;

                    case 4:
                        color = new Color(colorValue, colorValue, colorValue, colorValue);
                        break;
                }

                Main.spriteBatch.Draw(Main.oneDropLogo, new Vector2(vecX + line.X, vecY + line.Y), color);
            }

            return true;
        }

        public override void SetDefaults(Item item)
        {
            if (item.maxStack > 10 && (item.maxStack != 100 || ModLoader.GetMod("TerrariaOverhaul") != null) && !(item.type >= ItemID.CopperCoin && item.type <= ItemID.PlatinumCoin))
            {
                item.maxStack = 9999;
            }

            if (item.type == ItemID.PirateMap)
            {
                item.maxStack = 9999;
            }

            if (item.type == ItemID.GoodieBag || item.type == ItemID.Present)
            {
                item.useAnimation = 30;
                item.useTime = 30;
                item.useStyle = ItemUseStyleID.HoldingUp;
                item.UseSound = SoundID.Item44;
            }
        }

        public override bool UseItem(Item item, Player player)
        {
            switch (item.type)
            {
                case ItemID.GoodieBag:
                    FargoWorld.DownedBools["halloween"] = !FargoWorld.DownedBools["halloween"];
                    Main.NewText(FargoWorld.DownedBools["halloween"] ? "Halloween has begun!" : "Halloween has ended!", 175, 75);
                    return true;

                case ItemID.Present:
                    FargoWorld.DownedBools["xmas"] = !FargoWorld.DownedBools["xmas"];
                    Main.NewText(FargoWorld.DownedBools["xmas"] ? "Christmas has begun!" : "Christmas has ended!", 175, 75);
                    return true;
            }

            return false;
        }

        public override void OpenVanillaBag(string context, Player player, int arg)
        {
            switch (arg)
            {
                case ItemID.KingSlimeBossBag:
                    if (Main.rand.NextBool(25))
                    {
                        player.QuickSpawnItem(ItemID.SlimeStaff);
                    }

                    break;

                case ItemID.WoodenCrate:
                    if (Main.rand.NextBool(45))
                    {
                        int[] drops = { ItemID.Spear, ItemID.Blowpipe, ItemID.WandofSparking, ItemID.WoodenBoomerang };
                        player.QuickSpawnItem(Main.rand.Next(drops));
                    }

                    break;

                case ItemID.GoldenCrate:
                    if (Main.rand.NextBool(5))
                    {
                        int[] drops = { ItemID.BandofRegeneration, ItemID.MagicMirror, ItemID.CloudinaBottle, ItemID.EnchantedBoomerang, ItemID.ShoeSpikes, ItemID.FlareGun, ItemID.HermesBoots, ItemID.LavaCharm, ItemID.SandstorminaBottle, ItemID.FlyingCarpet };
                        player.QuickSpawnItem(Main.rand.Next(drops));
                    }

                    break;
            }

            if (context == "lockBox")
            {
                if (Main.rand.NextBool(7))
                {
                    player.QuickSpawnItem(ItemID.Valor);
                }
            }
        }

        public override bool CanRightClick(Item item)
        {
            return Array.IndexOf(Thrown, item.type) > -1 || Array.IndexOf(Summon, item.type) > -1;
        }

        public override void RightClick(Item item, Player player)
        {
            int newType = -1;

            if (Array.IndexOf(Summon, item.type) > -1)
            {
                newType = mod.ItemType(ItemID.GetUniqueKey(item.type).Replace("Terraria ", string.Empty) + "Summon");
            }
            else if (Array.IndexOf(Thrown, item.type) > -1)
            {
                newType = mod.ItemType(ItemID.GetUniqueKey(item.type).Replace("Terraria ", string.Empty) + "Thrown");
            }

            if (newType != -1)
            {
                int num = Item.NewItem(player.getRect(), newType, prefixGiven: item.prefix);

                if (Main.netMode == NetmodeID.MultiplayerClient)
                {
                    NetMessage.SendData(MessageID.SyncItem, number: num, number2: 1f);
                }
            }
        }

        public override void PostUpdate(Item item)
        {
            if (FargoWorld.DownedBools["halloween"] && FargoWorld.DownedBools["xmas"] && firstTick)
            {
                if (Array.IndexOf(Hearts, item.type) >= 0)
                {
                    item.type = Hearts[Main.rand.Next(Hearts.Length)];
                }

                if (Array.IndexOf(Stars, item.type) >= 0)
                {
                    item.type = Stars[Main.rand.Next(Stars.Length)];
                }

                firstTick = false;
            }
        }

        public override bool CanUseItem(Item item, Player player)
        {
            if (item.type == ItemID.SiltBlock || item.type == ItemID.SlushBlock || item.type == ItemID.DesertFossil)
            {
                item.useTime = 2;
                item.useAnimation = 3;
            }

            return base.CanUseItem(item, player);
        }

        public override void UpdateInventory(Item item, Player player)
        {
            if (item.buffType != 0 && item.stack >= 60 && GetInstance<FargoConfig>().UnlimitedPotionBuffsOn120)
            {
                player.AddBuff(item.buffType, 2);
            }
        }
    }
}
