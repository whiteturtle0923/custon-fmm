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
        private static int[] thrown = { ItemID.Bananarang, ItemID.BloodyMachete, ItemID.DayBreak, ItemID.EnchantedBoomerang, ItemID.Flamarang, ItemID.FruitcakeChakram, ItemID.IceBoomerang, ItemID.LightDisc, ItemID.MagicDagger, ItemID.PaladinsHammer, ItemID.PossessedHatchet, ItemID.ShadowFlameKnife, ItemID.ThornChakram, ItemID.ToxicFlask, ItemID.VampireKnives, ItemID.WoodenBoomerang, ItemID.WoodYoyo, ItemID.Rally, ItemID.CorruptYoyo, ItemID.CrimsonYoyo, ItemID.JungleYoyo, ItemID.Code1, ItemID.Valor, ItemID.Cascade, ItemID.FormatC, ItemID.Gradient, ItemID.Chik, ItemID.HelFire, ItemID.Amarok, ItemID.Code2, ItemID.Yelets, ItemID.RedsYoyo, ItemID.ValkyrieYoyo, ItemID.Kraken, ItemID.TheEyeOfCthulhu, ItemID.Terrarian, ItemID.FlyingKnife, ItemID.BallOHurt, ItemID.TheMeatball, ItemID.BlueMoon, ItemID.Sunfury, ItemID.DaoofPow, ItemID.FlowerPow, ItemID.ScourgeoftheCorruptor, ItemID.NorthPole };

        private static int[] summon = { ItemID.NimbusRod, ItemID.CrimsonRod, ItemID.BeeGun, ItemID.WaspGun, ItemID.PiranhaGun, ItemID.BatScepter };

        public override bool InstancePerEntity => true;

        public override bool CloneNewInstances => true;

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            int[] yoyos = { mod.ItemType("CascadeThrown"), mod.ItemType("ChikThrown"), mod.ItemType("Code1Thrown"), mod.ItemType("Code2Thrown"), mod.ItemType("FormatCThrown"), mod.ItemType("GradientThrown"), mod.ItemType("KrakenThrown"), mod.ItemType("RallyThrown"), mod.ItemType("TerrarianThrown"), mod.ItemType("ValorThrown"), mod.ItemType("YeletsThrown") };

            if (Array.IndexOf(yoyos, item.type) > -1)
            {
                TooltipLine line = new TooltipLine(mod, "OneDrop", "");
                tooltips.Add(line);
            }

            if (Array.IndexOf(thrown, item.type) > -1 || Array.IndexOf(summon, item.type) > -1)
            {
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
            if (item.maxStack > 10 && (item.maxStack != 100 || ModLoader.GetMod("TerrariaOverhaul") != null) && item.type != ItemID.CopperCoin && item.type != ItemID.SilverCoin && item.type != ItemID.GoldCoin && item.type != ItemID.PlatinumCoin)
            {
                item.maxStack = 9999;
            }

            if (item.type == ItemID.PirateMap)
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

        public override bool CanRightClick(Item item) => (Array.IndexOf(thrown, item.type) > -1 || Array.IndexOf(summon, item.type) > -1);

        public override void RightClick(Item item, Player player)
        {
            int newType = -1;

            switch (item.type)
            {
                case ItemID.Bananarang:
                    newType = mod.ItemType("BananarangThrown");
                    break;
                case ItemID.BloodyMachete:
                    newType = mod.ItemType("BloodyMacheteThrown");
                    break;
                case ItemID.DayBreak:
                    newType = mod.ItemType("DaybreakThrown");
                    break;
                case ItemID.EnchantedBoomerang:
                    newType = mod.ItemType("EnchantedBoomerangThrown");
                    break;
                case ItemID.Flamarang:
                    newType = mod.ItemType("FlamarangThrown");
                    break;
                case ItemID.FruitcakeChakram:
                    newType = mod.ItemType("FruitcakeChakramThrown");
                    break;
                case ItemID.IceBoomerang:
                    newType = mod.ItemType("IceBoomerangThrown");
                    break;
                case ItemID.LightDisc:
                    newType = mod.ItemType("LightDiscThrown");
                    break;
                case ItemID.MagicDagger:
                    newType = mod.ItemType("MagicDaggerThrown");
                    break;
                case ItemID.PaladinsHammer:
                    newType = mod.ItemType("PaladinsHammerThrown");
                    break;
                case ItemID.PossessedHatchet:
                    newType = mod.ItemType("PossessedHatchetThrown");
                    break;
                case ItemID.ShadowFlameKnife:
                    newType = mod.ItemType("ShadowflameKnifeThrown");
                    break;
                case ItemID.ThornChakram:
                    newType = mod.ItemType("ThornChakramThrown");
                    break;
                case ItemID.ToxicFlask:
                    newType = mod.ItemType("ToxicFlaskThrown");
                    break;
                case ItemID.VampireKnives:
                    newType = mod.ItemType("VampireKnivesThrown");
                    break;
                case ItemID.WoodenBoomerang:
                    newType = mod.ItemType("WoodenBoomerangThrown");
                    break;
                case ItemID.WoodYoyo:
                    newType = mod.ItemType("WoodenYoyoThrown");
                    break;
                case ItemID.Rally:
                    newType = mod.ItemType("RallyThrown");
                    break;
                case ItemID.CorruptYoyo:
                    newType = mod.ItemType("MalaiseThrown");
                    break;
                case ItemID.CrimsonYoyo:
                    newType = mod.ItemType("ArteryThrown");
                    break;
                case ItemID.JungleYoyo:
                    newType = mod.ItemType("AmazonThrown");
                    break;
                case ItemID.Code1:
                    newType = mod.ItemType("Code1Thrown");
                    break;
                case ItemID.Valor:
                    newType = mod.ItemType("ValorThrown");
                    break;
                case ItemID.Cascade:
                    newType = mod.ItemType("CascadeThrown");
                    break;
                case ItemID.FormatC:
                    newType = mod.ItemType("FormatCThrown");
                    break;
                case ItemID.Gradient:
                    newType = mod.ItemType("GradientThrown");
                    break;
                case ItemID.Chik:
                    newType = mod.ItemType("ChikThrown");
                    break;
                case ItemID.HelFire:
                    newType = mod.ItemType("HelFireThrown");
                    break;
                case ItemID.Amarok:
                    newType = mod.ItemType("AmarokThrown");
                    break;
                case ItemID.Code2:
                    newType = mod.ItemType("Code2Thrown");
                    break;
                case ItemID.Yelets:
                    newType = mod.ItemType("YeletsThrown");
                    break;
                case ItemID.RedsYoyo:
                    newType = mod.ItemType("RedsThrowThrown");
                    break;
                case ItemID.ValkyrieYoyo:
                    newType = mod.ItemType("ValkyrieYoyoThrown");
                    break;
                case ItemID.Kraken:
                    newType = mod.ItemType("KrakenThrown");
                    break;
                case ItemID.TheEyeOfCthulhu:
                    newType = mod.ItemType("TheEyeofCthulhuThrown");
                    break;
                case ItemID.Terrarian:
                    newType = mod.ItemType("TerrarianThrown");
                    break;
                case ItemID.FlyingKnife:
                    newType = mod.ItemType("FlyingKnifeThrown");
                    break;
                case ItemID.BallOHurt:
                    newType = mod.ItemType("BallOHurtThrown");
                    break;
                case ItemID.TheMeatball:
                    newType = mod.ItemType("TheMeatballThrown");
                    break;
                case ItemID.BlueMoon:
                    newType = mod.ItemType("BlueMoonThrown");
                    break;
                case ItemID.Sunfury:
                    newType = mod.ItemType("SunfuryThrown");
                    break;
                case ItemID.DaoofPow:
                    newType = mod.ItemType("DaoofPowThrown");
                    break;
                case ItemID.FlowerPow:
                    newType = mod.ItemType("FlowerPowThrown");
                    break;
                case ItemID.ScourgeoftheCorruptor:
                    newType = mod.ItemType("ScourgeoftheCorruptorThrown");
                    break;
                case ItemID.NorthPole:
                    newType = mod.ItemType("NorthPoleThrown");
                    break;
                case ItemID.NimbusRod:
                    newType = mod.ItemType("NimbusRodSummon");
                    break;
                case ItemID.CrimsonRod:
                    newType = mod.ItemType("CrimsonRodSummon");
                    break;
                case ItemID.BatScepter:
                    newType = mod.ItemType("BatScepterSummon");
                    break;
                case ItemID.BeeGun:
                    newType = mod.ItemType("BeeGunSummon");
                    break;
                case ItemID.WaspGun:
                    newType = mod.ItemType("WaspGunSummon");
                    break;
                case ItemID.PiranhaGun:
                    newType = mod.ItemType("PiranhaGunSummon");
                    break;
            }

            if (newType != -1)
            {
                int num = Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, newType, 1, false, item.prefix);

                if (Main.netMode == 1)
                {
                    NetMessage.SendData(21, -1, -1, null, num, 1f, 0f, 0f, 0, 0, 0);
                }
            }
        }

        static int[] hearts = new int[] { ItemID.Heart, ItemID.CandyApple, ItemID.CandyCane };
        static int[] stars = new int[] { ItemID.Star, ItemID.SoulCake, ItemID.SugarPlum };

        bool firstTick = true;

        public override void PostUpdate(Item item)
        {
            if (FargoWorld.halloween && FargoWorld.xmas && firstTick)
            {
                if (Array.IndexOf(hearts, item.type) >= 0)
                {
                    item.type = hearts[Main.rand.Next(hearts.Length)];
                }

                if (Array.IndexOf(stars, item.type) >= 0)
                {
                    item.type = stars[Main.rand.Next(stars.Length)];
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
            if (item.buffType != 0 && item.stack >= 120 && FargoConfig.Instance.UnlimitedPotionBuffsOn120 && player.buffType[21] == 0) //dont try to buff if slots full
                player.AddBuff(item.buffType, 2);
        }
    }
}
