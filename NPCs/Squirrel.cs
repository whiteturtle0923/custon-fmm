using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Fargowiltas.Items.Summons;
using Fargowiltas.Items.Summons.Abom;
using Fargowiltas.Items.Summons.Mutant;

namespace Fargowiltas.NPCs
{
	[AutoloadHead]
	public class Squirrel : ModNPC
	{
		public override bool Autoload(ref string name)
		{
			name = "Squirrel";
			return ModLoader.GetMod("FargowiltasSouls") != null;
		}

		private readonly Mod fargosouls = ModLoader.GetMod("FargowiltasSouls");

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Squirrel");
			Main.npcFrameCount[npc.type] = 6;
			NPCID.Sets.ExtraFramesCount[npc.type] = 9;
			NPCID.Sets.AttackFrameCount[npc.type] = 4;
			NPCID.Sets.DangerDetectRange[npc.type] = 700;
			NPCID.Sets.AttackType[npc.type] = 0;
			NPCID.Sets.AttackTime[npc.type] = 90;
			NPCID.Sets.AttackAverageChance[npc.type] = 30;
			NPCID.Sets.HatOffsetY[npc.type] = 4;
		}
		public override void SetDefaults()
		{
			npc.townNPC = true;
			npc.friendly = true;
			npc.width = 50;
			npc.height = 32;
			npc.damage = 0;
			npc.defense = 0;
			npc.lifeMax = 100;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.knockBackResist = .25f;

			animationType = NPCID.Squirrel;
			npc.aiStyle = 7;

            if (GetInstance<FargoConfig>().CatchNPCs)
            {
                Main.npcCatchable[npc.type] = true;
                npc.catchItem = (short)mod.ItemType("Squirrel");
            }
        }

        public override void AI()
        {
            npc.dontTakeDamage = Main.bloodMoon;
        }

        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
		{
            if (FargoWorld.DownedBools["squirrel"])
            {
                return true;
            }

			for (int k = 0; k < 255; k++)
			{
				Player player = Main.player[k];
				if (!player.active)
				{
					continue;
				}

				foreach (Item item in player.inventory)
				{
					if (item.type == fargosouls.ItemType("TopHatSquirrelCaught"))
					{
						return true;
					}
				}
			}
			return false;
		}

        public override bool CanGoToStatue(bool toKingStatue) => toKingStatue;

        public override string TownNPCName()
		{
			switch (WorldGen.genRand.Next(7))
			{
				case 0:
					return "Rick";
				case 1:
					return "Acorn";
                case 2:
                    return "Puff";
                case 3:
                    return "Coco";
                case 4:
                    return "Truffle";
                case 5:
                    return "Furgo";
                default:
					return "Squeaks";
			}
		}

		public override string GetChat()
		{
            if (Main.bloodMoon)
                return $"[c/ff0000:You will suffer.]";

            switch (Main.rand.Next(3))
			{
				case 0:
					return "*squeak*";
				case 1:
					return "*chitter*";
				default:
					return "*crunch crunch*";
			}
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

        private int GetBossHelp(ref string build)
        {
            Mod fargoSouls = ModLoader.GetMod("FargowiltasSouls");
            int summonType = -1;

            if (!NPC.downedSlimeKing)
            {
                summonType = ItemID.SlimeCrown;
                build = GetBuildText(
                    fargosouls.ItemType("EurusSock"),
                    fargosouls.ItemType("PuffInABottle")
                ) + GetBuildTextRandom(
                    3,
                    ItemID.ShinyRedBalloon,
                    ItemID.BandofRegeneration,
                    ItemID.SharkToothNecklace,
                    fargosouls.ItemType("IronEnchant"),
                    fargosouls.ItemType("EbonwoodEnchant"),
                    fargosouls.ItemType("CactusEnchant"),
                    fargosouls.ItemType("PalmWoodEnchant")
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
                    fargosouls.ItemType("SlimyShield"),
                    fargosouls.ItemType("BorealWoodEnchant"),
                    fargosouls.ItemType("IronEnchant"),
                    fargosouls.ItemType("PalmWoodEnchant"),
                    fargosouls.ItemType("CactusEnchant")
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
                    fargosouls.ItemType("AgitatingLens"),
                    fargosouls.ItemType("LeadEnchant"),
                    fargosouls.ItemType("JungleEnchant"),
                    fargosouls.ItemType("ShadewoodEnchant"),
                    fargosouls.ItemType("EbonwoodEnchant")
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
                        Main.rand.NextBool() ? fargosouls.ItemType("GuttedHeart") : fargosouls.ItemType("CorruptHeart"),
                        fargosouls.ItemType("NymphsPerfume"),
                        fargosouls.ItemType("ShadowEnchant")})
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
                    Main.rand.NextBool() ? fargosouls.ItemType("GuttedHeart") : fargosouls.ItemType("CorruptHeart"),
                    fargosouls.ItemType("QueenStinger"),
                    fargosouls.ItemType("ShadowEnchant"),
                    fargosouls.ItemType("IronEnchant")
                );
            }
            else if (!(bool)fargoSouls.Call("DownedDeviantt"))
            {
                summonType = fargoSouls.ItemType("DevisCurse");
                build = GetBuildText(
                    ItemID.EoCShield,
                    ItemID.FrostsparkBoots,
                    ItemID.BalloonHorseshoeFart,
                    fargosouls.ItemType("NymphsPerfume")
                ) + GetBuildTextRandom(
                    1,
                    ItemID.CharmofMyths,
                    fargosouls.ItemType("GuttedHeart"),
                    fargosouls.ItemType("QueenStinger"),
                    fargosouls.ItemType("NecromanticBrew"),
                    fargosouls.ItemType("IronEnchant")
                );
            }
            else if (!Main.hardMode)
            {
                summonType = ItemType<FleshyDoll>();
                build = GetBuildText(
                    ItemID.EoCShield,
                    fargosouls.ItemType("AeolusBoots"),
                    fargosouls.ItemType("SupremeDeathbringerFairy")
                ) + GetBuildTextRandom(
                    2,
                    ItemID.CharmofMyths,
                    ItemID.CrossNecklace,
                    fargosouls.ItemType("SparklingAdoration"),
                    fargosouls.ItemType("GuttedHeart"),
                    fargosouls.ItemType("ObsidianEnchant"),
                    fargosouls.ItemType("ShadowEnchant"),
                    fargosouls.ItemType("IronEnchant")
                );
            }
            else if (!NPC.downedMechBoss1)
            {
                summonType = ItemID.MechanicalWorm;
                build = GetBuildText(
                    ItemID.EoCShield,
                    fargosouls.ItemType("AeolusBoots"),
                    Main.rand.NextBool() ? ItemID.LeafWings : ItemID.FrozenWings
                ) + GetBuildTextRandom(
                    3,
                    ItemID.CharmofMyths,
                    ItemID.CrossNecklace,
                    ItemID.AnkhShield,
                    fargosouls.ItemType("SparklingAdoration"),
                    fargosouls.ItemType("SupremeDeathbringerFairy"),
                    fargosouls.ItemType("PalladiumEnchant"),
                    fargosouls.ItemType("MythrilEnchant"),
                    fargosouls.ItemType("TitaniumEnchant"),
                    Main.rand.Next(new int[] { ItemID.WarriorEmblem, ItemID.RangerEmblem, ItemID.SorcererEmblem, ItemID.SummonerEmblem })
                );
            }
            else if (!NPC.downedMechBoss2)
            {
                summonType = ItemID.MechanicalEye;
                build = GetBuildText(
                    ItemID.EoCShield,
                    fargosouls.ItemType("AeolusBoots"),
                    Main.rand.NextBool() ? ItemID.LeafWings : ItemID.FrozenWings
                ) + GetBuildTextRandom(
                    3,
                    ItemID.CharmofMyths,
                    ItemID.CrossNecklace,
                    ItemID.FrogLeg,
                    fargosouls.ItemType("SparklingAdoration"),
                    fargosouls.ItemType("SupremeDeathbringerFairy"),
                    fargosouls.ItemType("PalladiumEnchant"),
                    fargosouls.ItemType("MythrilEnchant"),
                    fargosouls.ItemType("TitaniumEnchant"),
                    Main.rand.Next(new int[] { ItemID.WarriorEmblem, ItemID.RangerEmblem, ItemID.SorcererEmblem, ItemID.SummonerEmblem })
                );
            }
            else if (!NPC.downedMechBoss3)
            {
                summonType = ItemID.MechanicalSkull;
                build = GetBuildText(
                    ItemID.EoCShield,
                    fargosouls.ItemType("AeolusBoots"),
                    Main.rand.NextBool() ? ItemID.LeafWings : ItemID.FrozenWings
                ) + GetBuildTextRandom(
                    3,
                    ItemID.CharmofMyths,
                    ItemID.CrossNecklace,
                    fargosouls.ItemType("SparklingAdoration"),
                    fargosouls.ItemType("SupremeDeathbringerFairy"),
                    fargosouls.ItemType("PalladiumEnchant"),
                    fargosouls.ItemType("MythrilEnchant"),
                    fargosouls.ItemType("TitaniumEnchant"),
                    Main.rand.Next(new int[] { ItemID.WarriorEmblem, ItemID.RangerEmblem, ItemID.SorcererEmblem, ItemID.SummonerEmblem })
                );
            }
            else if (!NPC.downedPlantBoss)
            {
                summonType = ItemType<PlanterasFruit>();
                build = GetBuildText(
                    Main.rand.NextBool() ? ItemID.EoCShield : fargosouls.ItemType("MonkEnchant"),
                    fargosouls.ItemType("AeolusBoots"),
                    Main.rand.Next(new int[] { ItemID.LeafWings, ItemID.FrozenWings, ItemID.FlameWings }),
                    Main.rand.Next(new int[] { ItemID.AnkhShield, fargosouls.ItemType("SupremeDeathbringerFairy"), fargosouls.ItemType("DubiousCircuitry") })
                ) + GetBuildTextRandom(
                    2,
                    ItemID.CharmofMyths,
                    ItemID.CrossNecklace,
                    fargosouls.ItemType("SparklingAdoration"),
                    fargosouls.ItemType("PureHeart"),
                    fargosouls.ItemType("PalladiumEnchant"),
                    fargosouls.ItemType("MythrilEnchant"),
                    fargosouls.ItemType("HallowEnchant"),
                    ItemID.AvengerEmblem
                );
            }
            else if (!NPC.downedGolemBoss)
            {
                summonType = ItemID.LihzahrdPowerCell;
                build = GetBuildText(
                    Main.rand.NextBool() ? ItemID.Tabi : fargosouls.ItemType("MonkEnchant"),
                    fargosouls.ItemType("AeolusBoots"),
                    fargosouls.ItemType("DubiousCircuitry"),
                    Main.rand.Next(new int[] { ItemID.SpookyWings, ItemID.TatteredFairyWings, ItemID.Hoverboard})
                ) + GetBuildTextRandom(
                    2,
                    ItemID.AnkhShield,
                    ItemID.CharmofMyths,
                    ItemID.CrossNecklace,
                    ItemID.AvengerEmblem,
                    fargosouls.ItemType("PureHeart"),
                    fargosouls.ItemType("PalladiumEnchant"),
                    fargosouls.ItemType("HallowEnchant"),
                    fargosouls.ItemType("MagicalBulb"),
                    fargosouls.ItemType("LumpOfFlesh")
                );
            }
            else if (!FargoWorld.DownedBools["betsy"])
            {
                summonType = ItemType<BetsyEgg>();
                build = GetBuildText(
                    Main.rand.NextBool() ? ItemID.Tabi : fargosouls.ItemType("ShinobiEnchant"),
                    fargosouls.ItemType("AeolusBoots"),
                    fargosouls.ItemType("LihzahrdTreasureBox"),
                    ItemID.SteampunkWings
                ) + GetBuildTextRandom(
                    2,
                    fargosouls.ItemType("PureHeart"),
                    fargosouls.ItemType("DubiousCircuitry"),
                    fargosouls.ItemType("BeetleEnchant"),
                    fargosouls.ItemType("SpectreEnchant"),
                    fargosouls.ItemType("SaucerControlConsole"),
                    fargosouls.ItemType("LumpOfFlesh")
                );
            }
            else if (!NPC.downedFishron)
            {
                summonType = ItemType<TruffleWorm2>();
                build = GetBuildText(
                    Main.rand.NextBool() ? ItemID.Tabi : fargosouls.ItemType("ShinobiEnchant"),
                    fargosouls.ItemType("AeolusBoots"),
                    fargosouls.ItemType("DubiousCircuitry"),
                    Main.rand.Next(new int[] { ItemID.SteampunkWings, ItemID.BetsyWings, ItemID.Hoverboard })
                ) + GetBuildTextRandom(
                    2,
                    ItemID.CharmofMyths,
                    ItemID.FrogLeg,
                    ItemID.AnkhShield,
                    ItemID.DestroyerEmblem,
                    fargosouls.ItemType("PureHeart"),
                    fargosouls.ItemType("BeetleEnchant"),
                    fargosouls.ItemType("AdamantiteEnchant"),
                    fargosouls.ItemType("LumpOfFlesh"),
                    fargosouls.ItemType("LihzahrdTreasureBox"),
                    fargosouls.ItemType("IronEnchant"),
                    fargosouls.ItemType("BetsysHeart")
                );
            }
            else if (!NPC.downedAncientCultist)
            {
                summonType = ItemType<CultistSummon>();
                build = GetBuildText(
                    Main.rand.NextBool() ? ItemID.Tabi : fargosouls.ItemType("ShinobiEnchant"),
                    fargosouls.ItemType("AeolusBoots"),
                    Main.rand.NextBool() ? ItemID.BetsyWings : ItemID.FishronWings
                ) + GetBuildTextRandom(
                    3,
                    ItemID.CharmofMyths,
                    ItemID.DestroyerEmblem,
                    fargosouls.ItemType("PureHeart"),
                    fargosouls.ItemType("DubiousCircuitry"),
                    fargosouls.ItemType("BeetleEnchant"),
                    fargosouls.ItemType("MythrilEnchant"),
                    fargosouls.ItemType("PalladiumEnchant"),
                    fargosouls.ItemType("SpectreEnchant"),
                    fargosouls.ItemType("HallowEnchant"),
                    fargosouls.ItemType("MutantAntibodies"),
                    fargosouls.ItemType("LihzahrdTreasureBox"),
                    fargosouls.ItemType("BetsysHeart")
                );
            }
            else if (!NPC.downedMoonlord)
            {
                summonType = ItemType<CelestialSigil2>();
                build = GetBuildText(
                    fargosouls.ItemType("GaiaHelmet"),
                    fargosouls.ItemType("GaiaPlate"),
                    fargosouls.ItemType("GaiaGreaves")
                ) + " " + GetBuildText(
                    Main.rand.NextBool() ? ItemID.Tabi : fargosouls.ItemType("ShinobiEnchant"),
                    fargosouls.ItemType("AeolusBoots"),
                    Main.rand.NextBool() ? ItemID.BetsyWings : ItemID.FishronWings
                ) + GetBuildTextRandom(
                    3,
                    ItemID.CharmofMyths,
                    ItemID.DestroyerEmblem,
                    fargosouls.ItemType("DubiousCircuitry"),
                    fargosouls.ItemType("BeetleEnchant"),
                    fargosouls.ItemType("MutantAntibodies"),
                    fargosouls.ItemType("BetsysHeart"),
                    fargosouls.ItemType("SparklingAdoration"),
                    fargosouls.ItemType("CelestialRune")
                );
            }
            else if (!(bool)fargoSouls.Call("DownedEridanus"))
            {
                summonType = fargoSouls.ItemType("SigilOfChampions");
                build = GetBuildText(
                    fargosouls.ItemType("GaiaHelmet"),
                    fargosouls.ItemType("GaiaPlate"),
                    fargosouls.ItemType("GaiaGreaves")
                ) + " " + GetBuildText(
                    Main.rand.NextBool() ? fargosouls.ItemType("SolarEnchant") : fargosouls.ItemType("SupersonicSoul"),
                    fargosouls.ItemType("FlightMasterySoul"),
                    fargosouls.ItemType("ColossusSoul"),
                    Main.rand.Next(new int[] { fargosouls.ItemType("GladiatorsSoul"), fargosouls.ItemType("SnipersSoul"), fargosouls.ItemType("ArchWizardsSoul"), fargosouls.ItemType("ConjuristsSoul") })
                ) + GetBuildTextRandom(
                    3,
                    fargosouls.ItemType("NebulaEnchant"),
                    fargosouls.ItemType("PureHeart"),
                    fargosouls.ItemType("HeartoftheMasochist"),
                    fargosouls.ItemType("MutantAntibodies"),
                    fargosouls.ItemType("SparklingAdoration"),
                    fargosouls.ItemType("TerraForce"),
                    fargosouls.ItemType("LifeForce"),
                    fargosouls.ItemType("SpiritForce"),
                    fargosouls.ItemType("EarthForce")
                );
            }
            else if (!(bool)fargoSouls.Call("DownedAbominationn"))
            {
                summonType = fargoSouls.ItemType("AbomsCurse");
                build = GetBuildText(
                    fargosouls.ItemType("CosmoForce"),
                    fargosouls.ItemType("FlightMasterySoul"),
                    fargosouls.ItemType("ColossusSoul"),
                    fargosouls.ItemType("TerraForce"),
                    fargosouls.ItemType("HeartoftheMasochist"),
                    Main.rand.Next(new int[] { fargosouls.ItemType("GladiatorsSoul"), fargosouls.ItemType("SnipersSoul"), fargosouls.ItemType("ArchWizardsSoul"), fargosouls.ItemType("ConjuristsSoul") })
                ) + GetBuildTextRandom(
                    1,
                    fargosouls.ItemType("SparklingAdoration"),
                    fargosouls.ItemType("LifeForce"),
                    fargosouls.ItemType("EarthForce"),
                    fargosouls.ItemType("NatureForce")
                );
            }
            else if (!(bool)fargoSouls.Call("DownedMutant"))
            {
                summonType = fargoSouls.ItemType("AbominationnVoodooDoll");
                build = GetBuildText(
                    fargosouls.ItemType("TerrariaSoul"),
                    fargosouls.ItemType("MasochistSoul"),
                    fargosouls.ItemType("UniverseSoul"),
                    fargosouls.ItemType("DimensionSoul"),
                    Main.rand.Next(new int[] { fargosouls.ItemType("GladiatorsSoul"), fargosouls.ItemType("SnipersSoul"), fargosouls.ItemType("ArchWizardsSoul"), fargosouls.ItemType("ConjuristsSoul") }),
                    fargosouls.ItemType("SparklingAdoration"),
                    fargosouls.ItemType("CyclonicFin")
                );
            }
            else
            {
                summonType = fargoSouls.ItemType("MutantsCurse");
                build = GetBuildText(
                    fargosouls.ItemType("MutantMask"),
                    fargosouls.ItemType("MutantBody"),
                    fargosouls.ItemType("MutantPants")
                ) + " " + GetBuildText(
                    fargosouls.ItemType("EternitySoul"),
                    fargosouls.ItemType("MasochistSoul"),
                    fargosouls.ItemType("UniverseSoul"),
                    Main.rand.Next(new int[] { fargosouls.ItemType("GladiatorsSoul"), fargosouls.ItemType("SnipersSoul"), fargosouls.ItemType("ArchWizardsSoul"), fargosouls.ItemType("ConjuristsSoul") }),
                    fargosouls.ItemType("SparklingAdoration"),
                    fargosouls.ItemType("CyclonicFin"),
                    fargosouls.ItemType("MutantEye")
                );
            }

            build += $" [i:{summonType}]";

            return summonType;
        }

		public override void SetChatButtons(ref string button, ref string button2)
		{
			button = Language.GetTextValue("LegacyInterface.28");

            if ((bool)ModLoader.GetMod("FargowiltasSouls").Call("Masomode"))
            {
                button2 = "Advice";
                /*string dummy = "";
                int summonType = GetBossHelp(ref dummy);
                button2 = $"Advice [i:{summonType}]";*/
            }
        }

		public override void OnChatButtonClicked(bool firstButton, ref bool shop)
		{
			if (firstButton)
			{
				shop = true;
			}
            else
            {
                /*if (Main.hardMode) //ask player why they don't have biocluster
                {
                    bool playerHasBiocluster = false;
                    int type = ModLoader.GetMod("FargowiltasSouls").ItemType("BionomicCluster");
                    foreach (Item item in Main.LocalPlayer.inventory)
                    {
                        if (item.type == type)
                        {
                            playerHasBiocluster = true;
                            break;
                        }
                    }
                    foreach (Item item in Main.LocalPlayer.armor)
                    {
                        if (item.type == type)
                        {
                            playerHasBiocluster = true;
                            break;
                        }
                    }
                    if (!playerHasBiocluster)
                    {
                        CombatText.NewText(npc.Hitbox, Color.White, $"[i:{type}]?", true);
                    }
                }*/

                string dialogue = "";
                GetBossHelp(ref dialogue);
                Main.npcChatText = dialogue + "\n";
            }
		}

        private void TryAddItem(Item item, Chest shop, ref int nextSlot)
        {
            const int maxShop = 40;

            bool duplicateItem = false;

            if (item.type == ItemID.CellPhone || item.type == ItemID.AnkhShield)
            {
                foreach (Item item2 in shop.item)
                {
                    if (item2.type == item.type)
                    {
                        duplicateItem = true;
                        break;
                    }
                }
                if (duplicateItem == false && nextSlot < maxShop)
                {
                    shop.item[nextSlot].SetDefaults(item.type);
                    nextSlot++;
                }
            }

            if (item.type == ItemID.RodofDiscord)
            {
                foreach (Item item2 in shop.item)
                {
                    if (item2.type == item.type)
                    {
                        duplicateItem = true;
                        break;
                    }
                }
                if (duplicateItem == false && nextSlot < maxShop)
                {
                    shop.item[nextSlot].SetDefaults(item.type);
                    shop.item[nextSlot].shopCustomPrice = 200;
                    shop.item[nextSlot].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
                    nextSlot++;
                }
            }

            if (item.modItem == null || (!item.modItem.mod.Name.Equals("FargowiltasSouls") && !item.modItem.mod.Name.Equals("FargowiltasSoulsDLC")) || nextSlot >= maxShop)
                return;

            if (item.Name.EndsWith("Enchantment"))
            {
                foreach (Item item2 in shop.item)
                {
                    if (item2.type == item.type)
                    {
                        duplicateItem = true;
                        break;
                    }
                }
                if (duplicateItem == false && nextSlot < maxShop)
                {
                    shop.item[nextSlot].SetDefaults(item.type);
                    nextSlot++;
                }
            }
            else if (item.Name.Contains("Force"))
            {
                RecipeFinder finder = new RecipeFinder();
                finder.SetResult(item.type);
                Recipe exactRecipe = finder.SearchRecipes()[0];
                foreach (Item item2 in exactRecipe.requiredItem)
                {
                    foreach (Item item3 in shop.item)
                    {
                        if (item3.type == item2.type)
                        {
                            duplicateItem = true;
                            break;
                        }
                    }
                    if (duplicateItem == false && nextSlot < maxShop)
                    {
                        if (item2.Name.Contains("Enchantment"))
                        {
                            shop.item[nextSlot].SetDefaults(item2.type);
                            nextSlot++;
                        }
                    }
                    duplicateItem = false;
                }
            }
            else if (item.Name.StartsWith("Soul"))
            {
                RecipeFinder finder = new RecipeFinder();
                finder.SetResult(item.type);
                Recipe exactRecipe = finder.SearchRecipes()[0];
                foreach (Item item2 in exactRecipe.requiredItem)
                {
                    foreach (Item item3 in shop.item)
                    {
                        if (item3.type == item2.type)
                        {
                            duplicateItem = true;
                            break;
                        }
                    }
                    if (duplicateItem == false && nextSlot < maxShop)
                    {
                        if (item2.Name.Contains("Force") || item2.Name.Contains("Soul"))
                        {
                            shop.item[nextSlot].SetDefaults(item2.type);
                            nextSlot++;
                        }
                        else if (item.type == ModLoader.GetMod("FargowiltasSouls").ItemType("MasochistSoul"))
                        {
                            RecipeFinder ingredientFinder = new RecipeFinder();
                            finder.SetResult(item2.type);
                            if (finder.SearchRecipes().Count > 0) //only put in materials that have recipes themselves
                            {
                                shop.item[nextSlot].SetDefaults(item2.type);
                                nextSlot++;
                            }
                        }
                    }
                    duplicateItem = false;
                }
            }
            else if (item.Name.EndsWith("Essence"))
            {
                foreach (Item item2 in shop.item)
                {
                    if (item2.type == item.type)
                    {
                        duplicateItem = true;
                        break;
                    }
                }
                if (duplicateItem == false && nextSlot < maxShop)
                {
                    shop.item[nextSlot].SetDefaults(item.type);
                    nextSlot++;
                }
            }
            else if (item.Name.EndsWith("Soul"))
            {
                RecipeFinder finder = new RecipeFinder();
                finder.SetResult(item.type);
                Recipe exactRecipe = finder.SearchRecipes()[0];
                foreach (Item item2 in exactRecipe.requiredItem)
                {
                    foreach (Item item3 in shop.item)
                    {
                        if (item3.type == item2.type)
                        {
                            duplicateItem = true;
                            break;
                        }
                    }
                    if (duplicateItem == false && nextSlot < maxShop)
                    {
                        if (item2.Name.EndsWith("Essence"))
                        {
                            shop.item[nextSlot].SetDefaults(item2.type);
                            nextSlot++;
                        }
                    }
                    duplicateItem = false;
                }
                foreach (Item item4 in shop.item)
                {
                    if (item4.type == item.type)
                    {
                        duplicateItem = true;
                        break;
                    }
                }
                if (duplicateItem == false && nextSlot < maxShop)
                {
                    shop.item[nextSlot].SetDefaults(item.type);
                    nextSlot++;
                }
            }
            else if (item.type == ModLoader.GetMod("FargowiltasSouls").ItemType("AeolusBoots"))
            {
                foreach (Item item2 in shop.item)
                {
                    if (item2.type == ItemID.FrostsparkBoots || item2.type == ItemID.BalloonHorseshoeFart)
                    {
                        duplicateItem = true;
                        break;
                    }
                }
                if (duplicateItem == false && nextSlot < maxShop)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.FrostsparkBoots);
                    nextSlot++;
                }
                if (duplicateItem == false && nextSlot < maxShop)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.BalloonHorseshoeFart);
                    nextSlot++;
                }
            }
            else if (item.type == ModLoader.GetMod("FargowiltasSouls").ItemType("BionomicCluster")
                || item.type == ModLoader.GetMod("FargowiltasSouls").ItemType("HeartoftheMasochist"))
            {
                foreach (Item item2 in shop.item)
                {
                    if (item2.type == item.type)
                    {
                        duplicateItem = true;
                        break;
                    }
                }
                if (duplicateItem == false && nextSlot < maxShop)
                {
                    shop.item[nextSlot].SetDefaults(item.type);
                    nextSlot++;
                }
            }
        }

		public override void SetupShop(Chest shop, ref int nextSlot)
		{
            if (Fargowiltas.ModLoaded["FargowiltasSouls"])
            {
                shop.item[nextSlot].SetDefaults(ModLoader.GetMod("FargowiltasSouls").ItemType("TopHatSquirrelCaught"));
                shop.item[nextSlot].shopCustomPrice = 100000;
                nextSlot++;
            }

			for (int k = 0; k < 255; k++)
			{
				Player player = Main.player[k];
				if (!player.active)
				{
					continue;
				}

				foreach (Item item in player.inventory)
				{
                    TryAddItem(item, shop, ref nextSlot);
				}

				foreach (Item item in player.armor)
				{
                    TryAddItem(item, shop, ref nextSlot);
                }
			}
		}

        public override void NPCLoot()
        {
            FargoWorld.DownedBools["squirrel"] = true;
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D texture2D13 = Main.npcTexture[npc.type];
            //int num156 = Main.npcTexture[npc.type].Height / Main.npcFrameCount[npc.type]; //ypos of lower right corner of sprite to draw
            //int y3 = num156 * npc.frame.Y; //ypos of upper left corner of sprite to draw
            Rectangle rectangle = npc.frame;//new Rectangle(0, y3, texture2D13.Width, num156);
            Vector2 origin2 = rectangle.Size() / 2f;

            Color color26 = lightColor;
            color26 = npc.GetAlpha(color26);

            SpriteEffects effects = npc.spriteDirection < 0 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;

            if (Main.bloodMoon)
            {
                Texture2D texture2D14 = mod.GetTexture("NPCs/Squirrel_Glow");
                float scale = (Main.mouseTextColor / 200f - 0.35f) * 0.3f + 0.9f;
                Main.spriteBatch.Draw(texture2D14, npc.Center - Main.screenPosition + new Vector2(0f, npc.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(rectangle), Color.White * npc.Opacity, npc.rotation, origin2, scale, effects, 0f);
            }

            Main.spriteBatch.Draw(texture2D13, npc.Center - Main.screenPosition + new Vector2(0f, npc.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(rectangle), npc.GetAlpha(lightColor), npc.rotation, origin2, npc.scale, effects, 0f);

            if (Main.bloodMoon)
            {
                Texture2D texture2D14 = mod.GetTexture("NPCs/Squirrel_Eyes");
                Main.spriteBatch.Draw(texture2D14, npc.Center - Main.screenPosition + new Vector2(0f, npc.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(rectangle), Color.White * npc.Opacity, npc.rotation, origin2, npc.scale, effects, 0f);
            }
            return false;
        }
    }
}