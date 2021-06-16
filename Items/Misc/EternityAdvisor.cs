using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Fargowiltas.Items.Summons;
using Fargowiltas.Items.Summons.Abom;
using Fargowiltas.Items.Summons.Mutant;
using Fargowiltas.Items.Tiles;

namespace Fargowiltas.Items.Misc
{
    public class EternityAdvisor : ModItem
    {
        public override string Texture => "Fargowiltas/Items/Placeholder";

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("FargowiltasSouls") != null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Eternity Advisor");
            Tooltip.SetDefault("Suggests loadouts for Eternity Mode based on progression");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.rare = ItemRarityID.Blue;
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.UseSound = SoundID.Item1;
        }

        public override bool CanUseItem(Player player)
        {
            return (bool)ModLoader.GetMod("FargowiltasSouls").Call("Masomode");
        }

        private string GetBuildText(params int[] args)
        {
            string text = "";
            foreach (int itemType in args)
                text += $"[i:{itemType}]";
            return text;
        }

        private string GetBuildTextRandom(params int[] args) //takes number of accs to use as first param and list of accs as the rest
        {
            List<int> choices = new List<int>();
            int maxSize = args.Length - 1;
            for (int i = 0; i < args[0]; i++)
            {
                int attempt = Main.rand.Next(maxSize) + 1; //skip the first number
                if (choices.Contains(args[attempt])) //if already chose this acc, try to choose the next in line
                {
                    for (int j = 0; j < maxSize; j++)
                    {
                        if (++attempt >= maxSize) //wrap around at end of array
                            attempt = 1;
                        if (!choices.Contains(args[attempt]))
                            break;
                    }
                }
                choices.Add(args[attempt]);
            }
            return GetBuildText(choices.ToArray());
        }

        private int GetBossHelp(ref string build, Player player)
        {
            Mod fargoSouls = ModLoader.GetMod("FargowiltasSouls");
            int summonType = -1;

            if (!NPC.downedSlimeKing)
            {
                summonType = ItemID.SlimeCrown;
                build = GetBuildText(
                    fargoSouls.ItemType("EurusSock"),
                    fargoSouls.ItemType("PuffInABottle")
                ) + GetBuildTextRandom(
                    3,
                    ItemID.ShinyRedBalloon,
                    ItemID.BandofRegeneration,
                    ItemID.SharkToothNecklace,
                    fargoSouls.ItemType("IronEnchant"),
                    fargoSouls.ItemType("EbonwoodEnchant"),
                    fargoSouls.ItemType("CactusEnchant"),
                    fargoSouls.ItemType("PalmWoodEnchant")
                );
            }
            else if (!NPC.downedBoss1)
            {
                summonType = ItemID.SuspiciousLookingEye;
                build = GetBuildText(
                    Main.rand.Next(new int[] { ItemID.HermesBoots, ItemID.SailfishBoots, ItemID.FlurryBoots }),
                    Main.rand.Next(new int[] { ItemID.CloudinaBottle, ItemID.TsunamiInABottle, ItemID.SandstorminaBottle, ItemID.BlizzardinaBottle })
                ) + GetBuildTextRandom(
                    3,
                    ItemID.CharmofMyths,
                    ItemID.CrossNecklace,
                    ItemID.SharkToothNecklace,
                    fargoSouls.ItemType("SlimyShield"),
                    fargoSouls.ItemType("BorealWoodEnchant"),
                    fargoSouls.ItemType("IronEnchant"),
                    fargoSouls.ItemType("PalmWoodEnchant"),
                    fargoSouls.ItemType("CactusEnchant")
                );
            }
            else if (!NPC.downedBoss2)
            {
                summonType = WorldGen.crimson ? ItemID.BloodySpine : ItemID.WormFood;
                build = GetBuildText(
                    ItemID.EoCShield,
                    ItemID.SpectreBoots,
                    Main.rand.Next(new int[] { ItemID.BalloonHorseshoeFart, ItemID.BalloonHorseshoeSharkron, ItemID.WhiteHorseshoeBalloon })
                ) + GetBuildTextRandom(
                    2,
                    ItemID.CharmofMyths,
                    ItemID.CrossNecklace,
                    fargoSouls.ItemType("AgitatingLens"),
                    fargoSouls.ItemType("LeadEnchant"),
                    fargoSouls.ItemType("JungleEnchant"),
                    fargoSouls.ItemType("ShadewoodEnchant"),
                    fargoSouls.ItemType("EbonwoodEnchant")
                );
            }
            else if (!NPC.downedQueenBee)
            {
                summonType = ItemID.Abeemination;
                build = GetBuildText(
                    ItemID.EoCShield,
                    ItemID.SpectreBoots,
                    ItemID.Bezoar,
                    Main.rand.Next(new int[] { ItemID.BalloonHorseshoeFart, ItemID.BalloonHorseshoeSharkron, ItemID.WhiteHorseshoeBalloon }),
                    Main.rand.Next(new int[] {
                        ItemID.CharmofMyths,
                        ItemID.WormScarf,
                        Main.rand.NextBool() ? fargoSouls.ItemType("GuttedHeart") : fargoSouls.ItemType("CorruptHeart"),
                        fargoSouls.ItemType("NymphsPerfume"),
                        fargoSouls.ItemType("ShadowEnchant")})
                );
            }
            else if (!NPC.downedBoss3)
            {
                summonType = ItemType<SuspiciousSkull>();
                build = GetBuildText(
                    ItemID.EoCShield,
                    ItemID.LightningBoots,
                    ItemID.BalloonHorseshoeFart
                ) + GetBuildTextRandom(
                    2,
                    ItemID.CharmofMyths,
                    Main.rand.NextBool() ? fargoSouls.ItemType("GuttedHeart") : fargoSouls.ItemType("CorruptHeart"),
                    fargoSouls.ItemType("QueenStinger"),
                    fargoSouls.ItemType("ShadowEnchant"),
                    fargoSouls.ItemType("IronEnchant")
                );
            }
            else if (!(bool)fargoSouls.Call("DownedDeviantt"))
            {
                summonType = fargoSouls.ItemType("DevisCurse");
                build = GetBuildText(
                    ItemID.EoCShield,
                    ItemID.FrostsparkBoots,
                    ItemID.BalloonHorseshoeFart,
                    fargoSouls.ItemType("NymphsPerfume")
                ) + GetBuildTextRandom(
                    1,
                    ItemID.CharmofMyths,
                    fargoSouls.ItemType("GuttedHeart"),
                    fargoSouls.ItemType("QueenStinger"),
                    fargoSouls.ItemType("NecromanticBrew"),
                    fargoSouls.ItemType("IronEnchant")
                );
            }
            else if (!Main.hardMode)
            {
                summonType = ItemType<FleshyDoll>();
                build = GetBuildText(
                    ItemID.EoCShield,
                    fargoSouls.ItemType("AeolusBoots"),
                    fargoSouls.ItemType("SupremeDeathbringerFairy")
                ) + GetBuildTextRandom(
                    2,
                    ItemID.CharmofMyths,
                    ItemID.CrossNecklace,
                    fargoSouls.ItemType("SparklingAdoration"),
                    fargoSouls.ItemType("GuttedHeart"),
                    fargoSouls.ItemType("ObsidianEnchant"),
                    fargoSouls.ItemType("ShadowEnchant"),
                    fargoSouls.ItemType("IronEnchant")
                );
            }
            else if (!NPC.downedMechBoss1)
            {
                summonType = ItemID.MechanicalWorm;
                build = GetBuildText(
                    ItemID.EoCShield,
                    fargoSouls.ItemType("AeolusBoots"),
                    Main.rand.NextBool() ? ItemID.LeafWings : ItemID.FrozenWings
                ) + GetBuildTextRandom(
                    3,
                    ItemID.CharmofMyths,
                    ItemID.CrossNecklace,
                    ItemID.AnkhShield,
                    fargoSouls.ItemType("SparklingAdoration"),
                    fargoSouls.ItemType("SupremeDeathbringerFairy"),
                    fargoSouls.ItemType("PalladiumEnchant"),
                    fargoSouls.ItemType("MythrilEnchant"),
                    fargoSouls.ItemType("TitaniumEnchant"),
                    Main.rand.Next(new int[] { ItemID.WarriorEmblem, ItemID.RangerEmblem, ItemID.SorcererEmblem, ItemID.SummonerEmblem })
                );
            }
            else if (!NPC.downedMechBoss2)
            {
                summonType = ItemID.MechanicalEye;
                build = GetBuildText(
                    ItemID.EoCShield,
                    fargoSouls.ItemType("AeolusBoots"),
                    Main.rand.NextBool() ? ItemID.LeafWings : ItemID.FrozenWings
                ) + GetBuildTextRandom(
                    3,
                    ItemID.CharmofMyths,
                    ItemID.CrossNecklace,
                    ItemID.FrogLeg,
                    fargoSouls.ItemType("SparklingAdoration"),
                    fargoSouls.ItemType("SupremeDeathbringerFairy"),
                    fargoSouls.ItemType("PalladiumEnchant"),
                    fargoSouls.ItemType("MythrilEnchant"),
                    fargoSouls.ItemType("TitaniumEnchant"),
                    Main.rand.Next(new int[] { ItemID.WarriorEmblem, ItemID.RangerEmblem, ItemID.SorcererEmblem, ItemID.SummonerEmblem })
                );
            }
            else if (!NPC.downedMechBoss3)
            {
                summonType = ItemID.MechanicalSkull;
                build = GetBuildText(
                    ItemID.EoCShield,
                    fargoSouls.ItemType("AeolusBoots"),
                    Main.rand.NextBool() ? ItemID.LeafWings : ItemID.FrozenWings
                ) + GetBuildTextRandom(
                    3,
                    ItemID.CharmofMyths,
                    ItemID.CrossNecklace,
                    fargoSouls.ItemType("SparklingAdoration"),
                    fargoSouls.ItemType("SupremeDeathbringerFairy"),
                    fargoSouls.ItemType("PalladiumEnchant"),
                    fargoSouls.ItemType("MythrilEnchant"),
                    fargoSouls.ItemType("TitaniumEnchant"),
                    Main.rand.Next(new int[] { ItemID.WarriorEmblem, ItemID.RangerEmblem, ItemID.SorcererEmblem, ItemID.SummonerEmblem })
                );
            }
            else if (!NPC.downedPlantBoss)
            {
                summonType = ItemType<PlanterasFruit>();
                build = GetBuildText(
                    Main.rand.NextBool() ? ItemID.EoCShield : fargoSouls.ItemType("MonkEnchant"),
                    fargoSouls.ItemType("AeolusBoots"),
                    Main.rand.Next(new int[] { ItemID.LeafWings, ItemID.FrozenWings, ItemID.FlameWings }),
                    Main.rand.Next(new int[] { ItemID.AnkhShield, fargoSouls.ItemType("SupremeDeathbringerFairy"), fargoSouls.ItemType("DubiousCircuitry") })
                ) + GetBuildTextRandom(
                    2,
                    ItemID.CharmofMyths,
                    ItemID.CrossNecklace,
                    fargoSouls.ItemType("SparklingAdoration"),
                    fargoSouls.ItemType("PureHeart"),
                    fargoSouls.ItemType("PalladiumEnchant"),
                    fargoSouls.ItemType("MythrilEnchant"),
                    fargoSouls.ItemType("HallowEnchant"),
                    ItemID.AvengerEmblem
                );
            }
            else if (!NPC.downedGolemBoss)
            {
                summonType = ItemID.LihzahrdPowerCell;
                build = GetBuildText(
                    Main.rand.NextBool() ? ItemID.Tabi : fargoSouls.ItemType("MonkEnchant"),
                    fargoSouls.ItemType("AeolusBoots"),
                    fargoSouls.ItemType("DubiousCircuitry"),
                    Main.rand.Next(new int[] { ItemID.SpookyWings, ItemID.TatteredFairyWings, ItemID.Hoverboard })
                ) + GetBuildTextRandom(
                    2,
                    ItemID.AnkhShield,
                    ItemID.CharmofMyths,
                    ItemID.CrossNecklace,
                    ItemID.AvengerEmblem,
                    fargoSouls.ItemType("PureHeart"),
                    fargoSouls.ItemType("PalladiumEnchant"),
                    fargoSouls.ItemType("HallowEnchant"),
                    fargoSouls.ItemType("MagicalBulb"),
                    fargoSouls.ItemType("LumpOfFlesh")
                );
            }
            else if (!FargoWorld.DownedBools["betsy"])
            {
                summonType = ItemType<BetsyEgg>();
                build = GetBuildText(
                    Main.rand.NextBool() ? ItemID.Tabi : fargoSouls.ItemType("ShinobiEnchant"),
                    fargoSouls.ItemType("AeolusBoots"),
                    fargoSouls.ItemType("LihzahrdTreasureBox"),
                    ItemID.SteampunkWings
                ) + GetBuildTextRandom(
                    2,
                    fargoSouls.ItemType("PureHeart"),
                    fargoSouls.ItemType("DubiousCircuitry"),
                    fargoSouls.ItemType("BeetleEnchant"),
                    fargoSouls.ItemType("SpectreEnchant"),
                    fargoSouls.ItemType("SaucerControlConsole"),
                    fargoSouls.ItemType("LumpOfFlesh")
                );
            }
            else if (!NPC.downedFishron)
            {
                summonType = ItemType<TruffleWorm2>();
                build = GetBuildText(
                    Main.rand.NextBool() ? ItemID.Tabi : fargoSouls.ItemType("ShinobiEnchant"),
                    fargoSouls.ItemType("AeolusBoots"),
                    fargoSouls.ItemType("DubiousCircuitry"),
                    Main.rand.Next(new int[] { ItemID.SteampunkWings, ItemID.BetsyWings, ItemID.Hoverboard })
                ) + GetBuildTextRandom(
                    2,
                    ItemID.CharmofMyths,
                    ItemID.FrogLeg,
                    ItemID.AnkhShield,
                    ItemID.DestroyerEmblem,
                    fargoSouls.ItemType("PureHeart"),
                    fargoSouls.ItemType("BeetleEnchant"),
                    fargoSouls.ItemType("AdamantiteEnchant"),
                    fargoSouls.ItemType("LumpOfFlesh"),
                    fargoSouls.ItemType("LihzahrdTreasureBox"),
                    fargoSouls.ItemType("IronEnchant"),
                    fargoSouls.ItemType("BetsysHeart")
                );
            }
            else if (!NPC.downedAncientCultist)
            {
                summonType = ItemType<CultistSummon>();
                build = GetBuildText(
                    Main.rand.NextBool() ? ItemID.Tabi : fargoSouls.ItemType("ShinobiEnchant"),
                    fargoSouls.ItemType("AeolusBoots"),
                    Main.rand.NextBool() ? ItemID.BetsyWings : ItemID.FishronWings
                ) + GetBuildTextRandom(
                    3,
                    ItemID.CharmofMyths,
                    ItemID.DestroyerEmblem,
                    fargoSouls.ItemType("PureHeart"),
                    fargoSouls.ItemType("DubiousCircuitry"),
                    fargoSouls.ItemType("BeetleEnchant"),
                    fargoSouls.ItemType("MythrilEnchant"),
                    fargoSouls.ItemType("PalladiumEnchant"),
                    fargoSouls.ItemType("SpectreEnchant"),
                    fargoSouls.ItemType("HallowEnchant"),
                    fargoSouls.ItemType("MutantAntibodies"),
                    fargoSouls.ItemType("LihzahrdTreasureBox"),
                    fargoSouls.ItemType("BetsysHeart")
                );
            }
            else if (!NPC.downedMoonlord)
            {
                summonType = ItemType<CelestialSigil2>();
                build = GetBuildText(
                    fargoSouls.ItemType("GaiaHelmet"),
                    fargoSouls.ItemType("GaiaPlate"),
                    fargoSouls.ItemType("GaiaGreaves")
                ) + " " + GetBuildText(
                    Main.rand.NextBool() ? ItemID.Tabi : fargoSouls.ItemType("ShinobiEnchant"),
                    fargoSouls.ItemType("AeolusBoots"),
                    Main.rand.NextBool() ? ItemID.BetsyWings : ItemID.FishronWings
                ) + GetBuildTextRandom(
                    3,
                    ItemID.CharmofMyths,
                    ItemID.DestroyerEmblem,
                    fargoSouls.ItemType("DubiousCircuitry"),
                    fargoSouls.ItemType("BeetleEnchant"),
                    fargoSouls.ItemType("MutantAntibodies"),
                    fargoSouls.ItemType("BetsysHeart"),
                    fargoSouls.ItemType("SparklingAdoration"),
                    fargoSouls.ItemType("CelestialRune")
                );
            }
            else if (!(bool)fargoSouls.Call("DownedEridanus"))
            {
                summonType = fargoSouls.ItemType("SigilOfChampions");
                build = GetBuildText(
                    fargoSouls.ItemType("GaiaHelmet"),
                    fargoSouls.ItemType("GaiaPlate"),
                    fargoSouls.ItemType("GaiaGreaves")
                ) + " " + GetBuildText(
                    Main.rand.NextBool() ? fargoSouls.ItemType("SolarEnchant") : fargoSouls.ItemType("SupersonicSoul"),
                    fargoSouls.ItemType("FlightMasterySoul"),
                    fargoSouls.ItemType("ColossusSoul"),
                    Main.rand.Next(new int[] { fargoSouls.ItemType("GladiatorsSoul"), fargoSouls.ItemType("SnipersSoul"), fargoSouls.ItemType("ArchWizardsSoul"), fargoSouls.ItemType("ConjuristsSoul") })
                ) + GetBuildTextRandom(
                    3,
                    fargoSouls.ItemType("NebulaEnchant"),
                    fargoSouls.ItemType("PureHeart"),
                    fargoSouls.ItemType("HeartoftheMasochist"),
                    fargoSouls.ItemType("MutantAntibodies"),
                    fargoSouls.ItemType("SparklingAdoration"),
                    fargoSouls.ItemType("TerraForce"),
                    fargoSouls.ItemType("LifeForce"),
                    fargoSouls.ItemType("SpiritForce"),
                    fargoSouls.ItemType("EarthForce")
                );
            }
            else if (!(bool)fargoSouls.Call("DownedAbominationn"))
            {
                summonType = fargoSouls.ItemType("AbomsCurse");
                build = GetBuildText(
                    fargoSouls.ItemType("CosmoForce"),
                    fargoSouls.ItemType("FlightMasterySoul"),
                    fargoSouls.ItemType("ColossusSoul"),
                    fargoSouls.ItemType("TerraForce"),
                    fargoSouls.ItemType("HeartoftheMasochist"),
                    Main.rand.Next(new int[] { fargoSouls.ItemType("GladiatorsSoul"), fargoSouls.ItemType("SnipersSoul"), fargoSouls.ItemType("ArchWizardsSoul"), fargoSouls.ItemType("ConjuristsSoul") })
                ) + GetBuildTextRandom(
                    1,
                    fargoSouls.ItemType("SparklingAdoration"),
                    fargoSouls.ItemType("LifeForce"),
                    fargoSouls.ItemType("EarthForce"),
                    fargoSouls.ItemType("NatureForce")
                );
            }
            else if (!(bool)fargoSouls.Call("DownedMutant"))
            {
                summonType = fargoSouls.ItemType("AbominationnVoodooDoll");
                build = GetBuildText(
                    fargoSouls.ItemType("TerrariaSoul"),
                    fargoSouls.ItemType("MasochistSoul"),
                    fargoSouls.ItemType("UniverseSoul"),
                    fargoSouls.ItemType("DimensionSoul"),
                    Main.rand.Next(new int[] { fargoSouls.ItemType("GladiatorsSoul"), fargoSouls.ItemType("SnipersSoul"), fargoSouls.ItemType("ArchWizardsSoul"), fargoSouls.ItemType("ConjuristsSoul") }),
                    fargoSouls.ItemType("SparklingAdoration"),
                    fargoSouls.ItemType("CyclonicFin")
                );
            }
            else
            {
                summonType = fargoSouls.ItemType("MutantsCurse");
                build = GetBuildText(
                    fargoSouls.ItemType("MutantMask"),
                    fargoSouls.ItemType("MutantBody"),
                    fargoSouls.ItemType("MutantPants")
                ) + " " + GetBuildText(
                    fargoSouls.ItemType("EternitySoul"),
                    fargoSouls.ItemType("MasochistSoul"),
                    fargoSouls.ItemType("UniverseSoul"),
                    Main.rand.Next(new int[] { fargoSouls.ItemType("GladiatorsSoul"), fargoSouls.ItemType("SnipersSoul"), fargoSouls.ItemType("ArchWizardsSoul"), fargoSouls.ItemType("ConjuristsSoul") }),
                    fargoSouls.ItemType("SparklingAdoration"),
                    fargoSouls.ItemType("CyclonicFin"),
                    fargoSouls.ItemType("MutantEye")
                );
            }

            if (Main.hardMode)
            {
                bool playerHasOmnistation = false;
                if (player.HasBuff(BuffType<Buffs.Omnistation>()) || player.HasBuff(BuffType<Buffs.OmnistationPlus>()))
                    playerHasOmnistation = true;
                foreach (Item item in player.inventory)
                {
                    if (item.type == ItemType<Omnistation>() || item.type == ItemType<Omnistation2>() || item.type == ItemType <OmnistationPlus>())
                    {
                        playerHasOmnistation = true;
                        break;
                    }
                }
                if (!playerHasOmnistation)
                {
                    build += Main.rand.NextBool()
                        ? $" [i:{ItemType<Omnistation>()}]"
                        : $" [i:{ItemType<Omnistation2>()}]";
                }
            }

            build += $" [i:{summonType}]";

            return summonType;
        }

        public override bool UseItem(Player player)
        {
            string dialogue = "";
            GetBossHelp(ref dialogue, player);
            Main.NewText(dialogue);

            Main.PlaySound(SoundID.Meowmere, player.Center, 5 + Main.rand.Next(5)); //meow
            return true;
        }
    }
}