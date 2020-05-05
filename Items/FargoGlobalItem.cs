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

            if (GetInstance<FargoConfig>().WeaponConversions)
            {
                if (Array.IndexOf(Thrown, item.type) > -1 || Array.IndexOf(Summon, item.type) > -1)
                {
                    TooltipLine line = new TooltipLine(mod, "help", "Right click to convert");
                    tooltips.Add(line);
                }
            }

            if (Array.IndexOf(yoyos, item.type) > -1)
            {
                TooltipLine line = new TooltipLine(mod, "OneDrop", string.Empty);
                tooltips.Add(line);
            }

            //switch soon tm

            if (item.type == ItemID.CrystalBall)
            {
                TooltipLine line = new TooltipLine(mod, "Altar", "Functions as a Demon altar as well");
                tooltips.Add(line);
            }

            if (item.type == ItemID.GoodieBag)
            {
                TooltipLine line = new TooltipLine(mod, "Tooltip1", "Also use this to toggle the Halloween season");
                tooltips.Add(line);
            }

            if (item.type == ItemID.Present)
            {
                TooltipLine line = new TooltipLine(mod, "Tooltip1", "Also use this to toggle the Christmas season");
                tooltips.Add(line);
            }

            if (item.type == ItemID.PureWaterFountain)
            {
                TooltipLine line = new TooltipLine(mod, "Tooltip0", "Forces surrounding biome state to Ocean upon activation");
                tooltips.Add(line);
            }

            if (item.type == ItemID.DesertWaterFountain)
            {
                TooltipLine line = new TooltipLine(mod, "Tooltip0", "Forces surrounding biome state to Desert upon activation");
                tooltips.Add(line);
            }

            if (item.type == ItemID.JungleWaterFountain)
            {
                TooltipLine line = new TooltipLine(mod, "Tooltip0", "Forces surrounding biome state to Jungle upon activation");
                tooltips.Add(line);
            }

            if (item.type == ItemID.IcyWaterFountain)
            {
                TooltipLine line = new TooltipLine(mod, "Tooltip0", "Forces surrounding biome state to Snow upon activation");
                tooltips.Add(line);
            }

            if (item.type == ItemID.CorruptWaterFountain)
            {
                TooltipLine line = new TooltipLine(mod, "Tooltip0", "Forces surrounding biome state to Corruption upon activation");
                tooltips.Add(line);
            }

            if (item.type == ItemID.CrimsonWaterFountain)
            {
                TooltipLine line = new TooltipLine(mod, "Tooltip1", "Forces surrounding biome state to Crimson upon activation");
                tooltips.Add(line);
            }

            if (item.type == ItemID.HallowedWaterFountain)
            {
                TooltipLine line = new TooltipLine(mod, "Tooltip1", "In hardmode, forces surrounding biome state to Hallow upon activation");
                tooltips.Add(line);
            }

            if (GetInstance<FargoConfig>().ExtraLures)
            {
                if (item.type == ItemID.FishingPotion)
                {
                    TooltipLine line = new TooltipLine(mod, "Tooltip1", "Also grants one extra lure");
                    tooltips.Insert(3, line);
                }

                if (item.type == ItemID.FiberglassFishingPole || item.type == ItemID.FisherofSouls || item.type == ItemID.Fleshcatcher)
                {
                    TooltipLine line = new TooltipLine(mod, "Tooltip1", "This rod fires 2 lures");
                    tooltips.Insert(3, line);
                }

                if (item.type == ItemID.MechanicsRod || item.type == ItemID.SittingDucksFishingRod)
                {
                    TooltipLine line = new TooltipLine(mod, "Tooltip1", "This rod fires 3 lures");
                    tooltips.Insert(3, line);
                }

                if (item.type == ItemID.GoldenFishingRod || item.type == ItemID.HotlineFishingHook)
                {
                    TooltipLine line = new TooltipLine(mod, "Tooltip1", "This rod fires 5 lures");
                    tooltips.Insert(3, line);
                }
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
            if (GetInstance<FargoConfig>().IncreaseMaxStack)
            {
                if (item.maxStack > 10 && (item.maxStack != 100 || ModLoader.GetMod("TerrariaOverhaul") != null) && !(item.type >= ItemID.CopperCoin && item.type <= ItemID.PlatinumCoin))
                {
                    item.maxStack = 9999;
                }

                if (item.type == ItemID.PirateMap || item.type == ItemID.SnowGlobe)
                {
                    item.maxStack = 9999;
                }
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
                    if (Main.rand.NextBool(10))
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
            if (GetInstance<FargoConfig>().WeaponConversions)
            {
                return Array.IndexOf(Thrown, item.type) > -1 || Array.IndexOf(Summon, item.type) > -1;
            }

            return base.CanRightClick(item);
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
            if (GetInstance<FargoConfig>().ExtractSpeed && (item.type == ItemID.SiltBlock || item.type == ItemID.SlushBlock || item.type == ItemID.DesertFossil))
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

        public override void UpdateAccessory(Item item, Player player, bool hideVisual)
        {
            if (item.type == ItemID.MusicBox && Main.curMusic > 0 && Main.curMusic <= 41)
            {
                int itemId = 0;

                //still better than vanilla (fear)
                switch (Main.curMusic)
                {
                    case 1:
                        itemId = 0 + 562;
                        break;
                    case 2:
                        itemId = 1 + 562;
                        break;
                    case 3:
                        itemId = 2 + 562;
                        break;
                    case 4:
                        itemId = 4 + 562;
                        break;
                    case 5:
                        itemId = 5 + 562;
                        break;
                    case 6:
                        itemId = 3 + 562;
                        break;
                    case 7:
                        itemId = 6 + 562;
                        break;
                    case 8:
                        itemId = 7 + 562;
                        break;
                    case 9:
                        itemId = 9 + 562;
                        break;
                    case 10:
                        itemId = 8 + 562;
                        break;
                    case 11:
                        itemId = 11 + 562;
                        break;
                    case 12:
                        itemId = 10 + 562;
                        break;
                    case 13:
                        itemId = 12 + 562;
                        break;
                    case 28:
                        itemId = 1963;
                        break;
                    case 29:
                        itemId = 1610;
                        break;
                    case 30:
                        itemId = 1963;
                        break;
                    case 31:
                        itemId = 1964;
                        break;
                    case 32:
                        itemId = 1965;
                        break;
                    case 33:
                        itemId = 2742;
                        break;
                    case 34:
                        itemId = 3370;
                        break;
                    case 35:
                        itemId = 3236;
                        break;
                    case 36:
                        itemId = 3237;
                        break;
                    case 37:
                        itemId = 3235;
                        break;
                    case 38:
                        itemId = 3044;
                        break;
                    case 39:
                        itemId = 3371;
                        break;
                    case 40:
                        itemId = 3796;
                        break;
                    case 41:
                        itemId = 3869;
                        break;
                    default:
                        itemId = 1596 + Main.curMusic - 14;
                        break;
                }

                for (int i = 0; i < player.armor.Length; i++)
                {
                    Item accessory = player.armor[i];

                    if (accessory.accessory && accessory.type == item.type)
                    {
                        player.armor[i].SetDefaults(itemId, false);
                        break;
                    }
                }
            }
        }

        public override bool ConsumeAmmo(Item item, Player player)
        {
            if (GetInstance<FargoConfig>().UnlimitedAmmo && Main.hardMode && item.ammo != 0 && item.stack >= 3996)
                return false;
            return true;
        }

        public override bool ConsumeItem(Item item, Player player)
        {
            if (GetInstance<FargoConfig>().UnlimitedConsumableWeapons && Main.hardMode && item.damage > 0 && item.ammo == 0 && item.stack >= 3996)
                return false;
            return true;
        }

        public override bool OnPickup(Item item, Player player)
        {
            String dye = "";

            switch (item.type)
            {
                case ItemID.RedHusk:
                    dye = "RedHusk";
                    break;
                case ItemID.OrangeBloodroot:
                    dye = "OrangeBloodroot";
                    break;
                case ItemID.YellowMarigold:
                    dye = "YellowMarigold";
                    break;
                case ItemID.LimeKelp:
                    dye = "LimeKelp";
                    break;
                case ItemID.GreenMushroom:
                    dye = "GreenMushroom";
                    break;
                case ItemID.TealMushroom:
                    dye = "TealMushroom";
                    break;
                case ItemID.CyanHusk:
                    dye = "CyanHusk";
                    break;
                case ItemID.SkyBlueFlower:
                    dye = "SkyBlueFlower";
                    break;
                case ItemID.BlueBerries:
                    dye = "BlueBerries";
                    break;
                case ItemID.PurpleMucos:
                    dye = "PurpleMucos";
                    break;
                case ItemID.VioletHusk:
                    dye = "VioletHusk";
                    break;
                case ItemID.PinkPricklyPear:
                    dye = "PinkPricklyPear";
                    break;
                case ItemID.BlackInk:
                    dye = "BlackInk";
                    break;
            }

            if (dye != "")
            {
                player.GetModPlayer<FargoPlayer>().FirstDyeIngredients[dye] = true;
            }

            return base.OnPickup(item, player);
        }
    }
}
