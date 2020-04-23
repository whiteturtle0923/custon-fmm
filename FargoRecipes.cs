using Fargowiltas.Items.CaughtNPCs;
using Fargowiltas.Items.Summons;
using Fargowiltas.Items.Summons.Deviantt;
using Fargowiltas.Items.Summons.Abom;
using Fargowiltas.Items.Summons.SwarmSummons;
using Fargowiltas.Items.Summons.Mutant;
using Fargowiltas.Items.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas
{
    internal class FargoRecipes
    {
        public static void AddRecipeGroups()
        {
            // Evil Wood
            RecipeGroup group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Evil Wood", new int[] { ItemID.Ebonwood, ItemID.Shadewood });
            RecipeGroup.RegisterGroup("Fargowiltas:AnyEvilWood", group);

            //iron anvil
            group = new RecipeGroup(() => "Any Iron Anvil", new int[] { ItemID.IronAnvil, ItemID.LeadAnvil});
            RecipeGroup.RegisterGroup("Fargowiltas:AnyAnvil", group);

            //anvil HM
            group = new RecipeGroup(() => "Any Mythril Anvil", ItemID.MythrilAnvil, ItemID.OrichalcumAnvil);
            RecipeGroup.RegisterGroup("Fargowiltas:AnyHMAnvil", group);

            //forge HM
            group = new RecipeGroup(() => "Any Adamantite Forge", ItemID.AdamantiteForge, ItemID.TitaniumForge);
            RecipeGroup.RegisterGroup("Fargowiltas:AnyForge", group);

            //book cases
            group = new RecipeGroup(() => "Any Bookcase", new int[]
            {
                ItemID.Bookcase,
                ItemID.BlueDungeonBookcase,
                ItemID.BoneBookcase,
                ItemID.BorealWoodBookcase,
                ItemID.CactusBookcase,
                ItemID.CrystalBookCase,
                ItemID.DynastyBookcase,
                ItemID.EbonwoodBookcase,
                ItemID.FleshBookcase,
                ItemID.FrozenBookcase,
                ItemID.GlassBookcase,
                ItemID.GoldenBookcase,
                ItemID.GothicBookcase,
                ItemID.GraniteBookcase,
                ItemID.GreenDungeonBookcase,
                ItemID.HoneyBookcase,
                ItemID.LivingWoodBookcase,
                ItemID.MarbleBookcase,
                ItemID.MeteoriteBookcase,
                ItemID.MushroomBookcase,
                ItemID.ObsidianBookcase,
                ItemID.PalmWoodBookcase,
                ItemID.PearlwoodBookcase,
                ItemID.PinkDungeonBookcase,
                ItemID.PumpkinBookcase,
                ItemID.RichMahoganyBookcase,
                ItemID.ShadewoodBookcase,
                ItemID.SkywareBookcase,
                ItemID.SlimeBookcase,
                ItemID.SpookyBookcase,
                ItemID.SteampunkBookcase
            });
            RecipeGroup.RegisterGroup("Fargowiltas:AnyBookcase", group);


            // Bone Banners
            int[] boneBanners = { ItemID.BlueArmoredBonesBanner, ItemID.HellArmoredBonesBanner, ItemID.RustyArmoredBonesBanner };
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Armored Bones Banner", boneBanners);
            RecipeGroup.RegisterGroup("Fargowiltas:AnyArmoredBones", group);

            // Slimes (excluding ones that don't drop gel)
            int[] slimeBanners = {
                ItemID.SlimeBanner,
                ItemID.GreenSlimeBanner,
                ItemID.RedSlimeBanner,
                ItemID.PurpleSlimeBanner,
                ItemID.YellowSlimeBanner,
                ItemID.BlackSlimeBanner,
                ItemID.IceSlimeBanner,
                ItemID.SandSlimeBanner,
                ItemID.JungleSlimeBanner,
                ItemID.SpikedIceSlimeBanner,
                ItemID.SpikedJungleSlimeBanner,
                ItemID.MotherSlimeBanner,
                ItemID.UmbrellaSlimeBanner,
                ItemID.ToxicSludgeBanner,
                ItemID.CorruptSlimeBanner,
                ItemID.SlimerBanner,
                ItemID.CrimslimeBanner,
                ItemID.GastropodBanner,
                ItemID.IlluminantSlimeBanner,
                ItemID.RainbowSlimeBanner
            };
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Slime Banner", slimeBanners);
            RecipeGroup.RegisterGroup("Fargowiltas:AnySlimes", group);

            // Any Hallow enemy
            int[] hallowBanners = {
                ItemID.PixieBanner,
                ItemID.UnicornBanner,
                ItemID.RainbowSlimeBanner,
                ItemID.GastropodBanner,
                ItemID.LightMummyBanner,
                ItemID.IlluminantBatBanner,
                ItemID.IlluminantSlimeBanner,
                ItemID.ChaosElementalBanner,
                ItemID.EnchantedSwordBanner,
            };
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Hallow Banner", hallowBanners);
            RecipeGroup.RegisterGroup("Fargowiltas:AnyHallows", group);

            // Any Corruption enemy
            int[] corruptionBanners = {
                ItemID.EaterofSoulsBanner,
                ItemID.CorruptorBanner,
                ItemID.CorruptSlimeBanner,
                ItemID.SlimerBanner,
                ItemID.DevourerBanner,
                ItemID.WorldFeederBanner,
                ItemID.DarkMummyBanner,
                ItemID.CursedHammerBanner,
                ItemID.ClingerBanner,
            };
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Corruption Banner", corruptionBanners);
            RecipeGroup.RegisterGroup("Fargowiltas:AnyCorrupts", group);

            // Any Crimson enemy
            int[] crimsonBanners = {
                ItemID.BloodCrawlerBanner,
                ItemID.FaceMonsterBanner,
                ItemID.CrimeraBanner,
                ItemID.HerplingBanner,
                ItemID.CrimslimeBanner,
                ItemID.BloodJellyBanner,
                ItemID.BloodFeederBanner,
                ItemID.DarkMummyBanner,
                ItemID.CrimsonAxeBanner,
                ItemID.IchorStickerBanner,
                ItemID.FloatyGrossBanner,
            };
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Crimson Banner", crimsonBanners);
            RecipeGroup.RegisterGroup("Fargowiltas:AnyCrimsons", group);

            // Any Jungle enemy
            int[] jungleBanners = {
                ItemID.PiranhaBanner,
                ItemID.SnatcherBanner,
                ItemID.JungleBatBanner,
                ItemID.JungleSlimeBanner,
                ItemID.DoctorBonesBanner,
                ItemID.AnglerFishBanner,
                ItemID.ArapaimaBanner,
                ItemID.TortoiseBanner,
                ItemID.AngryTrapperBanner,
                ItemID.DerplingBanner,
                ItemID.GiantFlyingFoxBanner,
                ItemID.HornetBanner,
                ItemID.SpikedJungleSlimeBanner,
                ItemID.JungleCreeperBanner,
                ItemID.MothBanner,
            };
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Jungle Banner", jungleBanners);
            RecipeGroup.RegisterGroup("Fargowiltas:AnyJungles", group);

            // Any Snow enemy
            int[] snowBanners = {
                ItemID.IceSlimeBanner,
                ItemID.ZombieEskimoBanner,
                ItemID.IceElementalBanner,
                ItemID.WolfBanner,
                ItemID.IceGolemBanner,
                ItemID.IceBatBanner,
                ItemID.SnowFlinxBanner,
                ItemID.SpikedIceSlimeBanner,
                ItemID.UndeadVikingBanner,
                ItemID.ArmoredVikingBanner,
                ItemID.IceTortoiseBanner,
                ItemID.IcyMermanBanner,
                ItemID.PigronBanner,
            };
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Snow Banner", snowBanners);
            RecipeGroup.RegisterGroup("Fargowiltas:AnySnows", group);

            // Caught NPCs
            int[] caughtNPCs = new int[]
            {
                ModContent.ItemType<Guide>(),
                ModContent.ItemType<Angler>(),
                ModContent.ItemType<ArmsDealer>(),
                ModContent.ItemType<Clothier>(),
                ModContent.ItemType<Cyborg>(),
                ModContent.ItemType<Demolitionist>(),
                ModContent.ItemType<Dryad>(),
                ModContent.ItemType<DyeTrader>(),
                ModContent.ItemType<GoblinTinkerer>(),
                ModContent.ItemType<LumberJack>(),
                ModContent.ItemType<Mechanic>(),
                ModContent.ItemType<Merchant>(),
                ModContent.ItemType<Nurse>(),
                ModContent.ItemType<Painter>(),
                ModContent.ItemType<PartyGirl>(),
                ModContent.ItemType<Pirate>(),
                ModContent.ItemType<SantaClaus>(),
                ModContent.ItemType<SkeletonMerchant>(),
                ModContent.ItemType<Steampunker>(),
                ModContent.ItemType<Stylist>(),
                ModContent.ItemType<Tavernkeep>(),
                ModContent.ItemType<TaxCollector>(),
                ModContent.ItemType<TravellingMerchant>(),
                ModContent.ItemType<WitchDoctor>(),
                ModContent.ItemType<Wizard>(),
            };
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Caught Town NPC", caughtNPCs);
            RecipeGroup.RegisterGroup("Fargowiltas:AnyCaughtNPC", group);

            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Omnistation", ModContent.ItemType<Omnistation>(), ModContent.ItemType<Omnistation2>());
            RecipeGroup.RegisterGroup("Fargowiltas:AnyOmnistation", group);
        }

        public static void AddRecipes()
        {
            AddSummonConversions();
            AddEvilConversions();
            AddMetalConversions();

            if (ModContent.GetInstance<FargoConfig>().BannerRecipes)
            {
                AddBannerToItemRecipes();
            }

            AddStatueRecipes();
            AddContainerLootRecipes();
            AddNPCRecipes();
            AddEmblemRecipes();
            AddMiscRecipes();
        }

        private static void AddSummonConversions()
        {
            ModRecipe recipe;
            void AddSummonConversion(int ingredient, int result)
            {
                recipe = GetNewRecipe();
                recipe.AddIngredient(ingredient);
                recipe.AddTile(TileID.WorkBenches);
                recipe.SetResult(result);
                recipe.AddRecipe();
            }

            AddSummonConversion(ModContent.ItemType<FleshyDoll>(), ItemID.GuideVoodooDoll);
            AddSummonConversion(ModContent.ItemType<LihzahrdPowerCell2>(), ItemID.LihzahrdPowerCell);
            AddSummonConversion(ModContent.ItemType<TruffleWorm2>(), ItemID.TruffleWorm);
            AddSummonConversion(ModContent.ItemType<CelestialSigil2>(), ItemID.CelestialSigil);
            AddSummonConversion(ModContent.ItemType<MechEye>(), ItemID.MechanicalEye);
            AddSummonConversion(ModContent.ItemType<MechWorm>(), ItemID.MechanicalWorm);
            AddSummonConversion(ModContent.ItemType<MechSkull>(), ItemID.MechanicalSkull);
            AddSummonConversion(ModContent.ItemType<GoreySpine>(), ItemID.BloodySpine);
            AddSummonConversion(ModContent.ItemType<SlimyCrown>(), ItemID.SlimeCrown);
            AddSummonConversion(ModContent.ItemType<Abeemination2>(), ItemID.Abeemination);
            AddSummonConversion(ModContent.ItemType<WormyFood>(), ItemID.WormFood);
            AddSummonConversion(ModContent.ItemType<SuspiciousEye>(), ItemID.SuspiciousLookingEye);
        }

        private static void AddEvilConversions()
        {
            AddConvertRecipe(ItemID.ShadowScale, ItemID.TissueSample);
            AddConvertRecipe(ItemID.PurpleSolution, ItemID.RedSolution);
            AddConvertRecipe(ItemID.Ichor, ItemID.CursedFlame);
            AddConvertRecipe(ItemID.FleshKnuckles, ItemID.PutridScent);
            AddConvertRecipe(ItemID.DartPistol, ItemID.DartRifle);
            AddConvertRecipe(ItemID.WormHook, ItemID.TendonHook);
            AddConvertRecipe(ItemID.ChainGuillotines, ItemID.FetidBaghnakhs);
            AddConvertRecipe(ItemID.ClingerStaff, ItemID.SoulDrain);
            AddConvertRecipe(ItemID.ShadowOrb, ItemID.CrimsonHeart);
            AddConvertRecipe(ItemID.Musket, ItemID.TheUndertaker);
            AddConvertRecipe(ItemID.PanicNecklace, ItemID.BandofStarpower);
            AddConvertRecipe(ItemID.BallOHurt, ItemID.TheRottedFork);
            AddConvertRecipe(ItemID.CrimsonRod, ItemID.Vilethorn);
            AddConvertRecipe(ItemID.CrimstoneBlock, ItemID.EbonstoneBlock);
            AddConvertRecipe(ItemID.Shadewood, ItemID.Ebonwood);
            AddConvertRecipe(ItemID.VileMushroom, ItemID.ViciousMushroom);
            AddConvertRecipe(ItemID.Bladetongue, ItemID.Toxikarp);
            AddConvertRecipe(ItemID.VampireKnives, ItemID.ScourgeoftheCorruptor);
            AddConvertRecipe(ItemID.Ebonkoi, ItemID.CrimsonTigerfish);
            AddConvertRecipe(ItemID.Hemopiranha, ItemID.Ebonkoi);
            AddConvertRecipe(ItemID.BoneRattle, ItemID.EatersBone);
        }

        private static void AddMetalConversions()
        {
            AddConvertRecipe(ItemID.CopperOre, ItemID.TinOre);
            AddConvertRecipe(ItemID.CopperBar, ItemID.TinBar);
            AddConvertRecipe(ItemID.IronOre, ItemID.LeadOre);
            AddConvertRecipe(ItemID.IronBar, ItemID.LeadBar);
            AddConvertRecipe(ItemID.SilverOre, ItemID.TungstenOre);
            AddConvertRecipe(ItemID.SilverBar, ItemID.TungstenBar);
            AddConvertRecipe(ItemID.GoldOre, ItemID.PlatinumOre);
            AddConvertRecipe(ItemID.GoldBar, ItemID.PlatinumBar);
            AddConvertRecipe(ItemID.CobaltOre, ItemID.PalladiumOre);
            AddConvertRecipe(ItemID.CobaltBar, ItemID.PalladiumBar);
            AddConvertRecipe(ItemID.MythrilOre, ItemID.OrichalcumOre);
            AddConvertRecipe(ItemID.MythrilBar, ItemID.OrichalcumBar);
            AddConvertRecipe(ItemID.AdamantiteOre, ItemID.TitaniumOre);
            AddConvertRecipe(ItemID.AdamantiteBar, ItemID.TitaniumBar);
            AddConvertRecipe(ItemID.DemoniteOre, ItemID.CrimtaneOre);
            AddConvertRecipe(ItemID.DemoniteBar, ItemID.CrimtaneBar);
        }

        private static void AddBannerToItemRecipes()
        {
            ModRecipe recipe;
            void AddBannerToItemRecipe(int banner, int result, int bannerAmount = 1, int resultAmount = 1)
            {
                recipe = GetNewRecipe();
                recipe.AddIngredient(banner, bannerAmount);
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(result, resultAmount);
                recipe.AddRecipe();
            }

            void AddBannerToItemsRecipe(int banner, int[] results, int bannerAmount = 1)
            {
                foreach (int result in results)
                {
                    recipe = GetNewRecipe();
                    recipe.AddIngredient(banner, bannerAmount);
                    recipe.AddTile(TileID.Solidifier);
                    recipe.SetResult(result);
                    recipe.AddRecipe();
                }
            }

            void AddGroupToItemRecipe(string group, int result, int station = TileID.Solidifier, int resultAmount = 1, int groupAmount = 1)
            {
                recipe = GetNewRecipe();
                recipe.AddRecipeGroup(group, groupAmount);
                recipe.AddTile(station);
                recipe.SetResult(result, resultAmount);
                recipe.AddRecipe();
            }

            AddBannerToItemRecipe(ItemID.AnglerFishBanner, ItemID.AdhesiveBandage);
            AddBannerToItemRecipe(ItemID.WerewolfBanner, ItemID.AdhesiveBandage);
            AddBannerToItemRecipe(ItemID.AngryBonesBanner, ItemID.TallyCounter);
            AddBannerToItemRecipe(ItemID.AngryNimbusBanner, ItemID.NimbusRod);
            AddBannerToItemRecipe(ItemID.AngryTrapperBanner, ItemID.Uzi);
            AddBannerToItemRecipe(ItemID.ArmoredVikingBanner, ItemID.IceSickle);
            AddBannerToItemRecipe(ItemID.BatBanner, ItemID.ChainKnife);
            AddBannerToItemRecipe(ItemID.BlackRecluseBanner, ItemID.PoisonStaff);
            AddBannerToItemRecipe(ItemID.BloodZombieBanner, ItemID.SharkToothNecklace);
            AddBannerToItemRecipe(ItemID.BunnyBanner, ItemID.BunnyHood);
            AddBannerToItemRecipe(ItemID.ButcherBanner, ItemID.ButchersChainsaw);
            AddBannerToItemRecipe(ItemID.CorruptorBanner, ItemID.Vitamins);
            AddBannerToItemRecipe(ItemID.CorruptSlimeBanner, ItemID.Blindfold);
            AddBannerToItemRecipe(ItemID.CrawdadBanner, ItemID.Rally);
            AddBannerToItemRecipe(ItemID.CreatureFromTheDeepBanner, ItemID.NeptunesShell);
            AddBannerToItemRecipe(ItemID.CursedSkullBanner, ItemID.Nazar);
            AddBannerToItemRecipe(ItemID.DarkMummyBanner, ItemID.Blindfold);
            AddBannerToItemRecipe(ItemID.DeadlySphereBanner, ItemID.DeadlySphereStaff);
            AddBannerToItemRecipe(ItemID.DemonBanner, ItemID.DemonScythe);
            AddBannerToItemRecipe(ItemID.DemonEyeBanner, ItemID.BlackLens);
            AddBannerToItemRecipe(ItemID.DesertBasiliskBanner, ItemID.AncientHorn);
            AddBannerToItemRecipe(ItemID.DiablolistBanner, ItemID.InfernoFork);
            AddBannerToItemRecipe(ItemID.DripplerBanner, ItemID.MoneyTrough);
            AddBannerToItemRecipe(ItemID.DrManFlyBanner, ItemID.ToxicFlask);
            AddBannerToItemRecipe(ItemID.EyezorBanner, ItemID.EyeSpring);
            AddBannerToItemRecipe(ItemID.FireImpBanner, ItemID.ObsidianRose);
            AddBannerToItemRecipe(ItemID.GastropodBanner, ItemID.BlessedApple);
            AddBannerToItemRecipe(ItemID.GiantBatBanner, ItemID.TrifoldMap);
            AddBannerToItemRecipe(ItemID.GiantShellyBanner, ItemID.Rally);
            AddBannerToItemRecipe(ItemID.GoblinArcherBanner, ItemID.Harpoon);
            AddBannerToItemRecipe(ItemID.GraniteFlyerBanner, ItemID.NightVisionHelmet);
            AddBannerToItemRecipe(ItemID.HarpyBanner, ItemID.GiantHarpyFeather);
            AddBannerToItemRecipe(ItemID.HellbatBanner, ItemID.MagmaStone);
            AddBannerToItemRecipe(ItemID.HornetBanner, ItemID.TatteredBeeWing);
            AddBannerToItemRecipe(ItemID.IceBatBanner, ItemID.DepthMeter);
            AddBannerToItemRecipe(ItemID.IceTortoiseBanner, ItemID.FrozenTurtleShell);
            AddBannerToItemRecipe(ItemID.IcyMermanBanner, ItemID.FrostStaff);
            AddBannerToItemRecipe(ItemID.JungleBatBanner, ItemID.DepthMeter);
            AddBannerToItemRecipe(ItemID.JungleCreeperBanner, ItemID.Yelets);
            AddBannerToItemRecipe(ItemID.LavaBatBanner, ItemID.HelFire);
            AddBannerToItemRecipe(ItemID.LavaSlimeBanner, ItemID.Cascade);
            AddBannerToItemRecipe(ItemID.LihzahrdBanner, ItemID.LizardEgg);
            AddBannerToItemRecipe(ItemID.MartianScutlixGunnerBanner, ItemID.BrainScrambler);
            AddBannerToItemRecipe(ItemID.MothronBanner, ItemID.MothronWings);
            AddBannerToItemRecipe(ItemID.NailheadBanner, ItemID.NailGun);
            AddBannerToItemRecipe(ItemID.NecromancerBanner, ItemID.ShadowbeamStaff);
            AddBannerToItemRecipe(ItemID.PinkJellyfishBanner, ItemID.JellyfishNecklace);
            AddBannerToItemRecipe(ItemID.PiranhaBanner, ItemID.RobotHat);
            AddBannerToItemRecipe(ItemID.PixieBanner, ItemID.Megaphone);
            AddBannerToItemRecipe(ItemID.PresentMimicBanner, ItemID.ToySled);
            AddBannerToItemRecipe(ItemID.PsychoBanner, ItemID.PsychoKnife);
            AddBannerToItemRecipe(ItemID.RaggedCasterBanner, ItemID.SpectreStaff);
            AddBannerToItemRecipe(ItemID.RaincoatZombieBanner, ItemID.RainHat);
            AddBannerToItemRecipe(ItemID.RaincoatZombieBanner, ItemID.RainCoat);
            AddBannerToItemRecipe(ItemID.ReaperBanner, ItemID.DeathSickle);
            AddBannerToItemRecipe(ItemID.SalamanderBanner, ItemID.Rally);
            AddBannerToItemRecipe(ItemID.SharkBanner, ItemID.DivingHelmet);
            AddBannerToItemRecipe(ItemID.SkeletonBanner, ItemID.BoneSword);
            AddBannerToItemRecipe(ItemID.SkeletonCommandoBanner, ItemID.RocketLauncher);
            AddBannerToItemRecipe(ItemID.SkeletonMageBanner, ItemID.BoneWand);
            AddBannerToItemRecipe(ItemID.SnowFlinxBanner, ItemID.SnowballLauncher);
            AddBannerToItemRecipe(ItemID.TortoiseBanner, ItemID.TurtleShell);
            AddBannerToItemRecipe(ItemID.ToxicSludgeBanner, ItemID.Bezoar);
            AddBannerToItemRecipe(ItemID.UmbrellaSlimeBanner, ItemID.UmbrellaHat);
            AddBannerToItemRecipe(ItemID.UndeadMinerBanner, ItemID.BonePickaxe);
            AddBannerToItemRecipe(ItemID.UndeadVikingBanner, ItemID.VikingHelmet);
            AddBannerToItemRecipe(ItemID.UnicornBanner, ItemID.UnicornonaStick);
            AddBannerToItemRecipe(ItemID.WalkingAntlionBanner, ItemID.AntlionClaw);
            AddBannerToItemRecipe(ItemID.WerewolfBanner, ItemID.MoonCharm);
            AddBannerToItemRecipe(ItemID.WolfBanner, ItemID.Amarok);
            AddBannerToItemRecipe(ItemID.WormBanner, ItemID.WhoopieCushion);
            AddBannerToItemRecipe(ItemID.WraithBanner, ItemID.FastClock);
            AddBannerToItemRecipe(ItemID.PirateCaptainBanner, ItemID.CoinGun, 5);
            AddBannerToItemRecipe(ItemID.ChaosElementalBanner, ItemID.RodofDiscord, 5);
            AddBannerToItemRecipe(ItemID.SalamanderBanner, ItemID.Compass);
            AddBannerToItemRecipe(ItemID.CrawdadBanner, ItemID.Compass);
            AddBannerToItemRecipe(ItemID.GiantShellyBanner, ItemID.Compass);

            AddBannerToItemsRecipe(ItemID.ArmoredSkeletonBanner, new int[] { ItemID.ArmorPolish, ItemID.BeamSword });
            AddBannerToItemsRecipe(ItemID.BoneLeeBanner, new int[] { ItemID.BlackBelt, ItemID.Tabi });
            AddBannerToItemsRecipe(ItemID.DesertDjinnBanner, new int[] { ItemID.DjinnLamp, ItemID.DjinnsCurse });
            AddBannerToItemsRecipe(ItemID.DesertLamiaBanner, new int[] { ItemID.LamiaHat, ItemID.LamiaShirt, ItemID.LamiaPants, ItemID.MoonMask, ItemID.SunMask });
            AddBannerToItemsRecipe(ItemID.FloatyGrossBanner, new int[] { ItemID.Vitamins, ItemID.MeatGrinder });
            AddBannerToItemsRecipe(ItemID.MedusaBanner, new int[] { ItemID.MedusaHead, ItemID.PocketMirror });
            AddBannerToItemsRecipe(ItemID.MummyBanner, new int[] { ItemID.MummyMask, ItemID.MummyShirt, ItemID.MummyPants });
            AddBannerToItemsRecipe(ItemID.PaladinBanner, new int[] { ItemID.PaladinsHammer, ItemID.PaladinsShield });
            AddBannerToItemsRecipe(ItemID.PenguinBanner, new int[] { ItemID.PedguinHat, ItemID.PedguinShirt, ItemID.PedguinPants });
            AddBannerToItemsRecipe(ItemID.PirateBanner, new int[] { ItemID.SailorHat, ItemID.SailorShirt, ItemID.SailorPants });
            AddBannerToItemsRecipe(ItemID.PirateCaptainBanner, new int[] { ItemID.Cutlass, ItemID.GoldRing, ItemID.PirateStaff, ItemID.DiscountCard, ItemID.LuckyCoin });
            AddBannerToItemsRecipe(ItemID.RedDevilBanner, new int[] { ItemID.UnholyTrident, ItemID.FireFeather });
			AddBannerToItemsRecipe(ItemID.SkeletonArcherBanner, new int[] { ItemID.MagicQuiver, ItemID.Marrow});
            AddBannerToItemsRecipe(ItemID.SkeletonSniperBanner, new int[] { ItemID.RifleScope, ItemID.SniperRifle });
            AddBannerToItemsRecipe(ItemID.TacticalSkeletonBanner, new int[] { ItemID.TacticalShotgun, ItemID.SWATHelmet });
            AddBannerToItemsRecipe(ItemID.VampireBanner, new int[] { ItemID.BrokenBatWing, ItemID.MoonStone });
            AddBannerToItemsRecipe(ItemID.ZombieBanner, new int[] { ItemID.ZombieArm, ItemID.Shackle });
            AddBannerToItemsRecipe(ItemID.ZombieElfBanner, new int[] { ItemID.ElfHat, ItemID.ElfShirt, ItemID.ElfPants });
            AddBannerToItemsRecipe(ItemID.ZombieEskimoBanner, new int[] { ItemID.EskimoHood, ItemID.EskimoCoat, ItemID.EskimoPants });
            //ancient armors
            AddBannerToItemsRecipe(ItemID.EaterofSoulsBanner, new int[] { ItemID.AncientShadowHelmet, ItemID.AncientShadowScalemail, ItemID.AncientShadowGreaves }, 2);
            AddBannerToItemsRecipe(ItemID.HornetBanner, new int[] { ItemID.AncientCobaltHelmet, ItemID.AncientCobaltBreastplate, ItemID.AncientCobaltLeggings }, 2);
            AddBannerToItemsRecipe(ItemID.SkeletonBanner, new int[] { ItemID.AncientIronHelmet, ItemID.AncientGoldHelmet }, 2);
            AddBannerToItemRecipe(ItemID.AngryBonesBanner, ItemID.AncientNecroHelmet, 2);
            //gladiator
            AddBannerToItemsRecipe(ItemID.GreekSkeletonBanner, new int[] { ItemID.GladiatorHelmet, ItemID.GladiatorBreastplate, ItemID.GladiatorLeggings });
            



            //boss trophy recipes
            AddBannerToItemRecipe(ItemID.KingSlimeTrophy, ItemID.SlimeStaff);
            AddBannerToItemRecipe(ItemID.EyeofCthulhuTrophy, ItemID.Binoculars);
            AddBannerToItemRecipe(ItemID.EaterofWorldsTrophy, ItemID.EatersBone);
            AddBannerToItemRecipe(ItemID.BrainofCthulhuTrophy, ItemID.BoneRattle);
            AddBannerToItemRecipe(ItemID.QueenBeeTrophy, ItemID.HoneyedGoggles);
            AddBannerToItemRecipe(ItemID.SkeletronTrophy, ItemID.BookofSkulls);
            AddBannerToItemRecipe(ItemID.PlanteraTrophy, ItemID.TheAxe);


            AddGroupToItemRecipe("Fargowiltas:AnyArmoredBones", ItemID.Keybrand);
            AddGroupToItemRecipe("Fargowiltas:AnyArmoredBones", ItemID.Kraken);
            AddGroupToItemRecipe("Fargowiltas:AnyArmoredBones", ItemID.MagnetSphere);
            AddGroupToItemRecipe("Fargowiltas:AnyArmoredBones", ItemID.WispinaBottle);
            AddGroupToItemRecipe("Fargowiltas:AnyArmoredBones", ItemID.BoneFeather);

            AddGroupToItemRecipe("Fargowiltas:AnySlimes", ItemID.Gel, resultAmount: 200);

            AddGroupToItemRecipe("Fargowiltas:AnyHallows", ItemID.HallowedKey, TileID.MythrilAnvil, 1, 10);
            AddGroupToItemRecipe("Fargowiltas:AnyCorrupts", ItemID.CorruptionKey, TileID.MythrilAnvil, 1, 10);
            AddGroupToItemRecipe("Fargowiltas:AnyCrimsons", ItemID.CrimsonKey, TileID.MythrilAnvil, 1, 10);
            AddGroupToItemRecipe("Fargowiltas:AnyJungles", ItemID.JungleKey, TileID.MythrilAnvil, 1, 10);
            AddGroupToItemRecipe("Fargowiltas:AnySnows", ItemID.FrozenKey, TileID.MythrilAnvil, 1, 10);

            // Thorium
            if (Fargowiltas.ModLoaded["ThoriumMod"])
            {
                Mod thorium = ModLoader.GetMod("ThoriumMod");

                AddBannerToItemRecipe(thorium.ItemType("AncientChargerBanner"), thorium.ItemType("OlympicTorch"));
                AddBannerToItemRecipe(thorium.ItemType("AncientPhalanxBanner"), thorium.ItemType("AncientAegis"));
                AddBannerToItemRecipe(thorium.ItemType("ArmyAntBanner"), thorium.ItemType("HiveMind"));
                AddBannerToItemRecipe(thorium.ItemType("AstroBeetleBanner"), thorium.ItemType("AstroBeetleHusk"));
                AddBannerToItemRecipe(thorium.ItemType("BlisterPodBanner"), thorium.ItemType("BlisterSack"));
                AddBannerToItemRecipe(thorium.ItemType("BlizzardBatBanner"), thorium.ItemType("IceFairyStaff"));
                AddBannerToItemRecipe(thorium.ItemType("BoneFlayerBanner"), thorium.ItemType("BoneFlayerTail"));
                AddBannerToItemRecipe(thorium.ItemType("ChilledSpitterBanner"), thorium.ItemType("FrostPlagueStaff"));
                AddBannerToItemRecipe(thorium.ItemType("CoinBagBanner"), thorium.ItemType("AncientDrachma"));
                AddBannerToItemRecipe(thorium.ItemType("ColdlingBanner"), thorium.ItemType("SpineBuster"));
                AddBannerToItemRecipe(thorium.ItemType("CoolmeraBanner"), thorium.ItemType("MeatBallStaff"));
                AddBannerToItemRecipe(thorium.ItemType("CrownBanner"), thorium.ItemType("SpinyShell"));
                AddBannerToItemRecipe(thorium.ItemType("FlamekinCasterBanner"), thorium.ItemType("MoltenScale"));
                AddBannerToItemRecipe(thorium.ItemType("FrostBurntBanner"), thorium.ItemType("BlizzardsEdge"));
                AddBannerToItemRecipe(thorium.ItemType("GigaClamBanner"), thorium.ItemType("NanoClamCane"));
                AddBannerToItemRecipe(thorium.ItemType("GnomesBanner"), thorium.ItemType("GnomePick"));
                AddBannerToItemRecipe(thorium.ItemType("HammerHeadBanner"), thorium.ItemType("CartlidgedCatcher"));
                AddBannerToItemRecipe(thorium.ItemType("InfernalHoundBanner"), thorium.ItemType("MoltenCollar"));
                AddBannerToItemRecipe(thorium.ItemType("KrakenBanner"), thorium.ItemType("Leviathan"));
                AddBannerToItemRecipe(thorium.ItemType("LycanBanner"), thorium.ItemType("MoonlightStaff"));
                AddBannerToItemRecipe(thorium.ItemType("MoltenMortarBanner"), thorium.ItemType("MortarStaff"));
                AddBannerToItemRecipe(thorium.ItemType("NecroPotBanner"), thorium.ItemType("GhostlyGrapple"));
                AddBannerToItemRecipe(thorium.ItemType("ScissorStalkerBanner"), thorium.ItemType("StalkersSnippers"));
                AddBannerToItemRecipe(thorium.ItemType("ShamblerBanner"), thorium.ItemType("BallnChain"));
                AddBannerToItemRecipe(thorium.ItemType("SharptoothBanner"), thorium.ItemType("GoldenScale"), 4);
                AddBannerToItemRecipe(thorium.ItemType("SnowSingaBanner"), thorium.ItemType("EskimoBanjo"));
                AddBannerToItemRecipe(thorium.ItemType("SnowyOwlBanner"), thorium.ItemType("LostMail"));
                AddBannerToItemRecipe(thorium.ItemType("SpectrumiteBanner"), thorium.ItemType("PrismiteStaff"));
                AddBannerToItemRecipe(thorium.ItemType("StarvedBanner"), thorium.ItemType("DesecratedHeart"));
                AddBannerToItemRecipe(thorium.ItemType("TarantulaBanner"), thorium.ItemType("Arthropod"));
                AddBannerToItemRecipe(thorium.ItemType("UFOBanner"), thorium.ItemType("DetachedUFOBlaster"));
                AddBannerToItemRecipe(thorium.ItemType("UnderworldPotBanner"), thorium.ItemType("HotPot"));
                AddBannerToItemRecipe(thorium.ItemType("VampireSquidBanner"), thorium.ItemType("VampireGland"));
                AddBannerToItemRecipe(thorium.ItemType("VileSpitterBanner"), thorium.ItemType("VileSpitter"));
                AddBannerToItemRecipe(thorium.ItemType("VoltBanner"), thorium.ItemType("VoltHatchet"));
                AddBannerToItemRecipe(thorium.ItemType("WindElementalBanner"), thorium.ItemType("Zapper"));

                AddBannerToItemRecipe(ItemID.AngryBonesBanner, thorium.ItemType("GraveGoods"));
                AddBannerToItemRecipe(ItemID.BoneLeeBanner, thorium.ItemType("TechniqueShadowClone"));
                AddBannerToItemRecipe(ItemID.BoneSerpentBanner, thorium.ItemType("SpineBreaker"));
                AddBannerToItemRecipe(ItemID.FlyingSnakeBanner, thorium.ItemType("Spearmint"));
                AddBannerToItemRecipe(ItemID.FrankensteinBanner, thorium.ItemType("TeslaDefibrillator"));
                AddBannerToItemRecipe(ItemID.MartianOfficerBanner, thorium.ItemType("ShieldDroneBeacon"));
                AddBannerToItemRecipe(ItemID.MisterStabbyBanner, thorium.ItemType("BackStabber"));
                AddBannerToItemRecipe(ItemID.PirateDeadeyeBanner, thorium.ItemType("DeadEyePatch"));
                AddBannerToItemRecipe(ItemID.RaggedCasterBanner, thorium.ItemType("GatewayGlass"));
                AddBannerToItemRecipe(ItemID.RavagerScorpionBanner, thorium.ItemType("EbonyTail"));
                AddBannerToItemRecipe(ItemID.RedDevilBanner, thorium.ItemType("DemonTongue"));
                AddBannerToItemRecipe(ItemID.SkeletonCommandoBanner, thorium.ItemType("LaunchJumper"));
                AddBannerToItemRecipe(ItemID.SnowBallaBanner, thorium.ItemType("HailBomber"));
                AddBannerToItemRecipe(ItemID.SnowmanGangstaBanner, thorium.ItemType("TommyGun"));
                AddBannerToItemRecipe(ItemID.SquirrelGold, thorium.ItemType("SinisterAcorn"), 10);
                AddBannerToItemRecipe(ItemID.SwampThingBanner, thorium.ItemType("SwampSpike"));
                AddBannerToItemRecipe(ItemID.WyvernBanner, thorium.ItemType("CloudyChewToy"));

                AddBannerToItemsRecipe(thorium.ItemType("DarksteelKnightBanner"), new int[] { thorium.ItemType("BrokenDarksteelHelmet"), thorium.ItemType("GrayDPaintingItem") });
                AddBannerToItemsRecipe(thorium.ItemType("InvaderBanner"), new int[] { thorium.ItemType("VegaPhaser"), thorium.ItemType("BioPod") });
                AddBannerToItemsRecipe(thorium.ItemType("NecroticImbuerBanner"), new int[] { thorium.ItemType("NecroticStaff"), thorium.ItemType("TechniqueBloodLotus") });
                AddBannerToItemsRecipe(thorium.ItemType("WargBanner"), new int[] { thorium.ItemType("BattleHorn"), thorium.ItemType("BlackCatEars"), thorium.ItemType("Bagpipe"), thorium.ItemType("BloodCellStaff") });
                AddBannerToItemsRecipe(ItemID.MimicBanner, new int[] { thorium.ItemType("LargeCoin"), thorium.ItemType("ProofAvarice") });
            }

            // Calamity
            if (Fargowiltas.ModLoaded["CalamityMod"])
            {
                Mod calamity = ModLoader.GetMod("CalamityMod");

                AddBannerToItemRecipe(calamity.ItemType("AngryDogBanner"), calamity.ItemType("Cryophobia"), 2);
                AddBannerToItemRecipe(calamity.ItemType("ArmoredDiggerBanner"), calamity.ItemType("LeadWizard"));
                AddBannerToItemRecipe(calamity.ItemType("CnidrionBanner"), calamity.ItemType("TheTransformer"), 2);
                AddBannerToItemRecipe(calamity.ItemType("CrystalCrawlerBanner"), calamity.ItemType("CrystalBlade"));
                AddBannerToItemRecipe(calamity.ItemType("CuttlefishBanner"), calamity.ItemType("InkBomb"));
                AddBannerToItemRecipe(calamity.ItemType("EidolonWyrmJuvenileBanner"), calamity.ItemType("HalibutCannon"), 200);
                AddBannerToItemRecipe(calamity.ItemType("IceClasperBanner"), calamity.ItemType("FrostBarrier"));
                AddBannerToItemRecipe(calamity.ItemType("ImpiousImmolatorBanner"), calamity.ItemType("EnergyStaff"));
                AddBannerToItemRecipe(calamity.ItemType("IrradiatedSlimeBanner"), calamity.ItemType("LeadCore"));
                AddBannerToItemRecipe(calamity.ItemType("TrasherBanner"), calamity.ItemType("TrashmanTrashcan"));

                AddBannerToItemRecipe(ItemID.BoneSerpentBanner, calamity.ItemType("OldLordOathsword"));
                AddBannerToItemRecipe(ItemID.ClingerBanner, calamity.ItemType("CursedDagger"));
                AddBannerToItemRecipe(ItemID.DemonBanner, calamity.ItemType("BladecrestOathsword"));
                AddBannerToItemRecipe(ItemID.DesertBasiliskBanner, calamity.ItemType("EvilSmasher"), 4);
                AddBannerToItemRecipe(ItemID.DungeonSpiritBanner, calamity.ItemType("PearlGod"), 4);
                AddBannerToItemRecipe(ItemID.FlyingAntlionBanner, calamity.ItemType("MandibleBow"));
                AddBannerToItemRecipe(ItemID.GoblinSorcererBanner, calamity.ItemType("PlasmaRod"));
                AddBannerToItemRecipe(ItemID.GoblinWarriorBanner, calamity.ItemType("Warblade"));
                AddBannerToItemRecipe(ItemID.HarpyBanner, calamity.ItemType("SkyGlaze"), 2);
                AddBannerToItemRecipe(ItemID.IchorStickerBanner, calamity.ItemType("IchorSpear"));
                AddBannerToItemRecipe(ItemID.IchorStickerBanner, calamity.ItemType("SpearofDestiny"), 4);
                AddBannerToItemRecipe(ItemID.MimicBanner, calamity.ItemType("TheBee"), 2);
                AddBannerToItemRecipe(ItemID.NecromancerBanner, calamity.ItemType("WrathoftheAncients"));
                AddBannerToItemRecipe(ItemID.PirateCrossbowerBanner, calamity.ItemType("Arbalest"), 4);
                AddBannerToItemRecipe(ItemID.PirateCrossbowerBanner, calamity.ItemType("RaidersGlory"));
                AddBannerToItemRecipe(ItemID.PirateDeadeyeBanner, calamity.ItemType("ProporsePistol"));
                AddBannerToItemRecipe(ItemID.PossessedArmorBanner, calamity.ItemType("PsychoticAmulet"), 4);
                AddBannerToItemRecipe(ItemID.RuneWizardBanner, calamity.ItemType("EyeofMagnus"));
                AddBannerToItemRecipe(ItemID.SandElementalBanner, calamity.ItemType("WifeinaBottlewithBoobs"));
                AddBannerToItemRecipe(ItemID.SharkBanner, calamity.ItemType("DepthBlade"));
                AddBannerToItemRecipe(ItemID.SkeletonBanner, calamity.ItemType("Waraxe"));
                AddBannerToItemRecipe(ItemID.SkeletonMageBanner, calamity.ItemType("AncientShiv"));
                AddBannerToItemRecipe(ItemID.TacticalSkeletonBanner, calamity.ItemType("TrueConferenceCall"), 4);
                AddBannerToItemRecipe(ItemID.TombCrawlerBanner, calamity.ItemType("BurntSienna"));
                AddBannerToItemRecipe(ItemID.TortoiseBanner, calamity.ItemType("FabledTortoiseShell"), 4);
                AddBannerToItemRecipe(ItemID.WalkingAntlionBanner, calamity.ItemType("MandibleClaws"));
            }
        }

        private static void AddStatueRecipes()
        {
            ModRecipe recipe;
            void AddStatueRecipe(int statue, int ingredient, int ingredientAmount = 1)
            {
                recipe = GetNewRecipe();
                recipe.AddIngredient(ingredient, ingredientAmount);
                recipe.AddIngredient(ItemID.StoneBlock, 50);
                recipe.AddTile(TileID.HeavyWorkBench);
                recipe.SetResult(statue);
                recipe.AddRecipe();
            }

            AddStatueRecipe(ItemID.BatStatue, ItemID.BatBanner);
            AddStatueRecipe(ItemID.ChestStatue, ItemID.MimicBanner);
            AddStatueRecipe(ItemID.CrabStatue, ItemID.CrabBanner);
            AddStatueRecipe(ItemID.JellyfishStatue, ItemID.JellyfishBanner);
            AddStatueRecipe(ItemID.PiranhaStatue, ItemID.PiranhaBanner);
            AddStatueRecipe(ItemID.SharkStatue, ItemID.SharkBanner);
            AddStatueRecipe(ItemID.SkeletonStatue, ItemID.SkeletonBanner);
            AddStatueRecipe(ItemID.SlimeStatue, ItemID.SlimeBanner);
            AddStatueRecipe(ItemID.WallCreeperStatue, ItemID.SpiderBanner);
            AddStatueRecipe(ItemID.UnicornStatue, ItemID.UnicornBanner);
            AddStatueRecipe(ItemID.DripplerStatue, ItemID.DripplerBanner);
            AddStatueRecipe(ItemID.WraithStatue, ItemID.WraithBanner);
            AddStatueRecipe(ItemID.UndeadVikingStatue, ItemID.UndeadVikingBanner);
            AddStatueRecipe(ItemID.MedusaStatue, ItemID.MedusaBanner);
            AddStatueRecipe(ItemID.HarpyStatue, ItemID.HarpyBanner);
            AddStatueRecipe(ItemID.PigronStatue, ItemID.PigronBanner);
            AddStatueRecipe(ItemID.HopliteStatue, ItemID.GreekSkeletonBanner);
            AddStatueRecipe(ItemID.GraniteGolemStatue, ItemID.GraniteGolemBanner);
            AddStatueRecipe(ItemID.BloodZombieStatue, ItemID.BloodZombieBanner);
            AddStatueRecipe(ItemID.BombStatue, ItemID.Bomb, 99);
            AddStatueRecipe(ItemID.HeartStatue, ItemID.LifeCrystal, 6);
            AddStatueRecipe(ItemID.StarStatue, ItemID.ManaCrystal, 6);

            recipe = GetNewRecipe();
            recipe.AddIngredient(ItemID.Throne);
            recipe.AddIngredient(ItemID.TeleportationPotion);
            recipe.AddIngredient(ItemID.StoneBlock, 50);
            recipe.AddTile(TileID.HeavyWorkBench);
            recipe.SetResult(ItemID.KingStatue);
            recipe.AddRecipe();

            recipe = GetNewRecipe();
            recipe.AddIngredient(ItemID.Throne);
            recipe.AddIngredient(ItemID.TeleportationPotion);
            recipe.AddIngredient(ItemID.StoneBlock, 50);
            recipe.AddTile(TileID.HeavyWorkBench);
            recipe.SetResult(ItemID.QueenStatue);
            recipe.AddRecipe();
        }

        private static void AddContainerLootRecipes()
        {
            ModRecipe recipe;
            void KeyToItemRecipe(int key, int result)
            {
                recipe = GetNewRecipe();
                recipe.AddIngredient(key);
                recipe.AddIngredient(ItemID.Ectoplasm, 10);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.SetResult(result);
                recipe.AddRecipe();
            }

            KeyToItemRecipe(ItemID.CrimsonKey, ItemID.VampireKnives);
            KeyToItemRecipe(ItemID.CorruptionKey, ItemID.ScourgeoftheCorruptor);
            KeyToItemRecipe(ItemID.JungleKey, ItemID.PiranhaGun);
            KeyToItemRecipe(ItemID.FrozenKey, ItemID.StaffoftheFrostHydra);
            KeyToItemRecipe(ItemID.HallowedKey, ItemID.RainbowGun);

            if (Fargowiltas.ModLoaded["ThoriumMod"])
            {
                Mod thorium = ModLoader.GetMod("ThoriumMod");

                KeyToItemRecipe(thorium.ItemType("DesertBiomeKey"), thorium.ItemType("PharaohsSlab"));
                KeyToItemRecipe(thorium.ItemType("UnderworldBiomeKey"), thorium.ItemType("PheonixStaff"));
                KeyToItemRecipe(thorium.ItemType("AquaticDepthsBiomeKey"), thorium.ItemType("Fishbone"));
            }

            // Goodie Bag / Present recipes
            void AddGrabBagItemRecipe(int result, int grabBag = ItemID.Present, int grabBagAmount = 50)
            {
                recipe = GetNewRecipe();
                recipe.AddIngredient(grabBag, grabBagAmount);
                recipe.AddTile(TileID.WorkBenches);
                recipe.SetResult(result);
                recipe.AddRecipe();
            }

            AddGrabBagItemRecipe(ItemID.DogWhistle);
            AddGrabBagItemRecipe(ItemID.Toolbox);
            AddGrabBagItemRecipe(ItemID.HandWarmer);
            AddGrabBagItemRecipe(ItemID.RedRyder);
            AddGrabBagItemRecipe(ItemID.CandyCaneSword);
            AddGrabBagItemRecipe(ItemID.CandyCaneHook);
            AddGrabBagItemRecipe(ItemID.FruitcakeChakram);
            AddGrabBagItemRecipe(ItemID.CnadyCanePickaxe);
            AddGrabBagItemRecipe(ItemID.UnluckyYarn, ItemID.GoodieBag);
            AddGrabBagItemRecipe(ItemID.BatHook, ItemID.GoodieBag, 100);
            //wooden
            AddGrabBagItemRecipe(ItemID.SailfishBoots, ItemID.WoodenCrate, 5);
            AddGrabBagItemRecipe(ItemID.TsunamiInABottle, ItemID.WoodenCrate, 5);
            AddGrabBagItemRecipe(ItemID.Extractinator, ItemID.WoodenCrate, 5);
            AddGrabBagItemRecipe(ItemID.Aglet, ItemID.WoodenCrate, 5);
            AddGrabBagItemRecipe(ItemID.CordageGuide, ItemID.WoodenCrate, 5);
            AddGrabBagItemRecipe(ItemID.Umbrella, ItemID.WoodenCrate, 5);
            AddGrabBagItemRecipe(ItemID.ClimbingClaws, ItemID.WoodenCrate, 5);
            AddGrabBagItemRecipe(ItemID.Radar, ItemID.WoodenCrate, 5);
            AddGrabBagItemRecipe(ItemID.WoodenBoomerang, ItemID.WoodenCrate, 5);
            AddGrabBagItemRecipe(ItemID.WandofSparking, ItemID.WoodenCrate, 5);
            AddGrabBagItemRecipe(ItemID.Spear, ItemID.WoodenCrate, 5);
            AddGrabBagItemRecipe(ItemID.Blowpipe, ItemID.WoodenCrate, 5);
            //iron
            AddGrabBagItemRecipe(ItemID.FalconBlade, ItemID.IronCrate, 5);
            AddGrabBagItemRecipe(ItemID.TartarSauce, ItemID.IronCrate, 5);
            //gold
            AddGrabBagItemRecipe(ItemID.HardySaddle, ItemID.GoldenCrate, 5);
            AddGrabBagItemRecipe(ItemID.BandofRegeneration, ItemID.GoldenCrate, 5);
            AddGrabBagItemRecipe(ItemID.MagicMirror, ItemID.GoldenCrate, 5);
            AddGrabBagItemRecipe(ItemID.LavaCharm, ItemID.GoldenCrate, 5);
            AddGrabBagItemRecipe(ItemID.EnchantedBoomerang, ItemID.GoldenCrate, 5);
            AddGrabBagItemRecipe(ItemID.FlareGun, ItemID.GoldenCrate, 5);
            AddGrabBagItemRecipe(ItemID.HermesBoots, ItemID.GoldenCrate, 5);
            AddGrabBagItemRecipe(ItemID.ShoeSpikes, ItemID.GoldenCrate, 5);
            AddGrabBagItemRecipe(ItemID.CloudinaBottle, ItemID.GoldenCrate, 5);
            AddGrabBagItemRecipe(ItemID.FlyingCarpet, ItemID.GoldenCrate, 5);
            AddGrabBagItemRecipe(ItemID.SandstorminaBottle, ItemID.GoldenCrate, 5);
            AddGrabBagItemRecipe(ItemID.Sundial, ItemID.GoldenCrate, 10);
            //jungle
            AddGrabBagItemRecipe(ItemID.AnkletoftheWind, ItemID.JungleFishingCrate, 5);
            AddGrabBagItemRecipe(ItemID.StaffofRegrowth, ItemID.JungleFishingCrate, 5);
            AddGrabBagItemRecipe(ItemID.Boomstick, ItemID.JungleFishingCrate, 5);
            AddGrabBagItemRecipe(ItemID.FeralClaws, ItemID.JungleFishingCrate, 5);
            AddGrabBagItemRecipe(ItemID.FiberglassFishingPole, ItemID.JungleFishingCrate, 5);
            //sky
            AddGrabBagItemRecipe(ItemID.ShinyRedBalloon, ItemID.FloatingIslandFishingCrate, 5);
            AddGrabBagItemRecipe(ItemID.Starfury, ItemID.FloatingIslandFishingCrate, 5);
            AddGrabBagItemRecipe(ItemID.LuckyHorseshoe, ItemID.FloatingIslandFishingCrate, 5);
            //corrupt
            AddGrabBagItemRecipe(ItemID.BallOHurt, ItemID.CorruptFishingCrate, 5);
            AddGrabBagItemRecipe(ItemID.BandofStarpower, ItemID.CorruptFishingCrate, 5);
            AddGrabBagItemRecipe(ItemID.ShadowOrb, ItemID.CorruptFishingCrate, 5);
            AddGrabBagItemRecipe(ItemID.Musket, ItemID.CorruptFishingCrate, 5);
            AddGrabBagItemRecipe(ItemID.Vilethorn, ItemID.CorruptFishingCrate, 5);
            //crimson
            AddGrabBagItemRecipe(ItemID.TheUndertaker, ItemID.CrimsonFishingCrate, 5);
            AddGrabBagItemRecipe(ItemID.TheRottedFork, ItemID.CrimsonFishingCrate, 5);
            AddGrabBagItemRecipe(ItemID.CrimsonRod, ItemID.CrimsonFishingCrate, 5);
            AddGrabBagItemRecipe(ItemID.PanicNecklace, ItemID.CrimsonFishingCrate, 5);
            AddGrabBagItemRecipe(ItemID.CrimsonHeart, ItemID.CrimsonFishingCrate, 5);
            //dungeon
            AddGrabBagItemRecipe(ItemID.Muramasa, ItemID.DungeonFishingCrate, 5);
            AddGrabBagItemRecipe(ItemID.CobaltShield, ItemID.DungeonFishingCrate, 5);
            AddGrabBagItemRecipe(ItemID.MagicMissile, ItemID.DungeonFishingCrate, 5);
            AddGrabBagItemRecipe(ItemID.AquaScepter, ItemID.DungeonFishingCrate, 5);
            AddGrabBagItemRecipe(ItemID.Valor, ItemID.DungeonFishingCrate, 5);
            AddGrabBagItemRecipe(ItemID.Handgun, ItemID.DungeonFishingCrate, 5);
            AddGrabBagItemRecipe(ItemID.ShadowKey, ItemID.DungeonFishingCrate, 5);
            //ice
            AddGrabBagItemRecipe(ItemID.SnowballCannon, ModContent.ItemType<IceCrate>(), 5);
            AddGrabBagItemRecipe(ItemID.BlizzardinaBottle, ModContent.ItemType<IceCrate>(), 5);
            AddGrabBagItemRecipe(ItemID.IceBlade, ModContent.ItemType<IceCrate>(), 5);
            AddGrabBagItemRecipe(ItemID.IceSkates, ModContent.ItemType<IceCrate>(), 5);
            AddGrabBagItemRecipe(ItemID.FlurryBoots, ModContent.ItemType<IceCrate>(), 5);
            AddGrabBagItemRecipe(ItemID.IceBoomerang, ModContent.ItemType<IceCrate>(), 5);
            AddGrabBagItemRecipe(ItemID.Fish, ModContent.ItemType<IceCrate>(), 10);
            //shadow
            AddGrabBagItemRecipe(ItemID.DarkLance, ModContent.ItemType<ShadowCrate>(), 5);
            AddGrabBagItemRecipe(ItemID.HellwingBow, ModContent.ItemType<ShadowCrate>(), 5);
            AddGrabBagItemRecipe(ItemID.Flamelash, ModContent.ItemType<ShadowCrate>(), 5);
            AddGrabBagItemRecipe(ItemID.FlowerofFire, ModContent.ItemType<ShadowCrate>(), 5);
            AddGrabBagItemRecipe(ItemID.Sunfury, ModContent.ItemType<ShadowCrate>(), 5);

            // Water chests
            recipe = GetNewRecipe();
            recipe.AddIngredient(ItemID.Spear);
            recipe.AddIngredient(ItemID.Coral, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ItemID.Trident);
            recipe.AddRecipe();

            recipe = GetNewRecipe();
            recipe.AddIngredient(ItemID.PalmWood, 20);
            recipe.AddTile(TileID.Sawmill);
            recipe.SetResult(ItemID.BreathingReed);
            recipe.AddRecipe();

            recipe = GetNewRecipe();
            recipe.AddIngredient(ItemID.Silk, 20);
            recipe.AddIngredient(ItemID.Seashell, 5);
            recipe.AddTile(TileID.Loom);
            recipe.SetResult(ItemID.Flipper);
            recipe.AddRecipe();

            recipe = GetNewRecipe();
            recipe.AddIngredient(ItemID.HermesBoots);
            recipe.AddIngredient(ItemID.Starfish, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ItemID.WaterWalkingBoots);
            recipe.AddRecipe();
        }

        private static void AddNPCRecipes()
        {
            ModRecipe recipe = GetNewRecipe();
            recipe.AddRecipeGroup("Fargowiltas:AnyCaughtNPC");
            recipe.AddTile(TileID.MeatGrinder);
            recipe.SetResult(ItemID.FleshBlock, 25);
            recipe.AddRecipe();

            recipe = GetNewRecipe();
            recipe.AddRecipeGroup("Fargowiltas:AnyCaughtNPC");
            recipe.AddTile(TileID.DyeVat);
            recipe.SetResult(ItemID.DeepRedPaint, 20);
            recipe.AddRecipe();

            recipe = GetNewRecipe();
            recipe.AddIngredient(ModContent.ItemType<Truffle>());
            recipe.AddTile(TileID.DyeVat);
            recipe.SetResult(ItemID.BluePaint, 20);
            recipe.AddRecipe();

            recipe = GetNewRecipe();
            recipe.AddRecipeGroup("Fargowiltas:AnyCaughtNPC");
            recipe.AddTile(TileID.DyeVat);
            recipe.SetResult(ItemID.GrimDye, 2);
            recipe.AddRecipe();

            recipe = GetNewRecipe();
            recipe.AddRecipeGroup("Fargowiltas:AnyCaughtNPC");
            recipe.AddTile(TileID.BoneWelder);
            recipe.SetResult(ItemID.Bone, 25);
            recipe.AddRecipe();

            recipe = GetNewRecipe();
            recipe.AddIngredient(null, "Dryad");
            recipe.AddTile(TileID.LivingLoom);
            recipe.SetResult(ItemID.LeafWand);
            recipe.AddRecipe();

            recipe = GetNewRecipe();
            recipe.AddIngredient(null, "Dryad");
            recipe.AddTile(TileID.LivingLoom);
            recipe.SetResult(ItemID.LivingWoodWand);
            recipe.AddRecipe();

            recipe = GetNewRecipe();
            recipe.AddIngredient(null, "Truffle");
            recipe.AddIngredient(ItemID.EnchantedNightcrawler);
            recipe.AddTile(TileID.Autohammer);
            recipe.SetResult(ItemID.TruffleWorm);
            recipe.AddRecipe();

            recipe = GetNewRecipe();
            recipe.AddIngredient(null, "DyeTrader");
            recipe.AddIngredient(ItemID.WoodenSword);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(ItemID.DyeTradersScimitar);
            recipe.AddRecipe();

            recipe = GetNewRecipe();
            recipe.AddIngredient(null, "Tavernkeep");
            recipe.AddIngredient(ItemID.Ale, 5);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(ItemID.AleThrowingGlove);
            recipe.AddRecipe();

            recipe = GetNewRecipe();
            recipe.AddIngredient(null, "Stylist");
            recipe.AddIngredient(ItemID.WoodenSword);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(ItemID.StylistKilLaKillScissorsIWish);
            recipe.AddRecipe();

            recipe = GetNewRecipe();
            recipe.AddIngredient(null, "Painter");
            recipe.AddIngredient(ItemID.WoodenBow);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(ItemID.PainterPaintballGun);
            recipe.AddRecipe();

            recipe = GetNewRecipe();
            recipe.AddIngredient(null, "TaxCollector");
            recipe.AddIngredient(ItemID.WoodenSword);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(ItemID.TaxCollectorsStickOfDoom);
            recipe.AddRecipe();
        }

        private static void AddEmblemRecipes()
        {
            ModRecipe recipe;
            int[] emblems = { ItemID.SorcererEmblem, ItemID.WarriorEmblem, ItemID.RangerEmblem, ItemID.SummonerEmblem };
            for (int i = 0; i < emblems.Length; i++)
            {
                for (int j = 0; j < emblems.Length; j++)
                {
                    if (i != j)
                    {
                        recipe = GetNewRecipe();
                        recipe.AddIngredient(emblems[j]);
                        recipe.AddIngredient(ItemID.SoulofLight);
                        recipe.AddTile(TileID.CrystalBall);
                        recipe.SetResult(emblems[i]);
                        recipe.AddRecipe();
                    }
                }
            }
        }

        private static void AddMiscRecipes()
        {
            ModRecipe recipe = GetNewRecipe();

            recipe = GetNewRecipe();
            recipe.AddIngredient(ItemID.IceBlade);
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(ItemID.EnchantedSword);
            recipe.AddRecipe();

            recipe = GetNewRecipe();
            recipe.AddIngredient(ItemID.EnchantedSword, 2);
            recipe.AddIngredient(ItemID.SoulofLight, 5);
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(ItemID.Arkhalis);
            recipe.AddRecipe();

            recipe = GetNewRecipe();
            recipe.AddIngredient(ItemID.Pumpkin, 500);
            recipe.AddTile(TileID.LivingLoom);
            recipe.SetResult(ItemID.MagicalPumpkinSeed);
            recipe.AddRecipe();

            recipe = GetNewRecipe();
            recipe.AddIngredient(ItemID.FishingSeaweed, 10);
            recipe.AddTile(TileID.LivingLoom);
            recipe.SetResult(ItemID.Seaweed);
            recipe.AddRecipe();

            recipe = GetNewRecipe();
            recipe.AddIngredient(ItemID.HermesBoots);
            recipe.AddIngredient(ItemID.Daybloom);
            recipe.AddIngredient(ItemID.Blinkroot);
            recipe.AddIngredient(ItemID.Shiverthorn);
            recipe.AddIngredient(ItemID.Moonglow);
            recipe.AddIngredient(ItemID.Waterleaf);
            recipe.AddIngredient(ItemID.Deathweed);
            recipe.AddIngredient(ItemID.Fireblossom);
            recipe.AddTile(TileID.LivingLoom);
            recipe.SetResult(ItemID.FlowerBoots);
            recipe.AddRecipe();

            recipe = GetNewRecipe();
            recipe.AddIngredient(ItemID.Loom);
            recipe.AddIngredient(ItemID.Vine, 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.LivingLoom);
            recipe.AddRecipe();

            recipe = GetNewRecipe();
            recipe.AddIngredient(ItemID.NaturesGift);
            recipe.AddIngredient(ItemID.RedHusk);
            recipe.AddTile(TileID.LivingLoom);
            recipe.SetResult(ItemID.JungleRose);
            recipe.AddRecipe();

            recipe = GetNewRecipe();
            recipe.AddIngredient(ItemID.Amber, 15);
            recipe.AddIngredient(ItemID.Firefly);
            recipe.AddTile(TileID.CookingPots);
            recipe.SetResult(ItemID.AmberMosquito);
            recipe.AddRecipe();

            recipe = GetNewRecipe();
            recipe.AddIngredient(ItemID.Moonglow, 15);
            recipe.AddIngredient(ItemID.ManaCrystal);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(ItemID.NaturesGift);
            recipe.AddRecipe();

            recipe = GetNewRecipe();
            recipe.AddIngredient(ItemID.SandBlock, 50);
            recipe.AddIngredient(ItemID.Bottle);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(ItemID.SandstorminaBottle);
            recipe.AddRecipe();

            recipe = GetNewRecipe();
            recipe.AddIngredient(ItemID.ChlorophyteBar);
            recipe.AddIngredient(ItemID.DarkBlueSolution);
            recipe.AddTile(TileID.Autohammer);
            recipe.SetResult(ItemID.ShroomiteBar);
            recipe.AddRecipe();

            recipe = GetNewRecipe();
            recipe.AddIngredient(ItemID.GrapplingHook);
            recipe.AddIngredient(ItemID.WebRopeCoil, 8);
            recipe.AddTile(TileID.CookingPots);
            recipe.SetResult(ItemID.WebSlinger);
            recipe.AddRecipe();

            //Dungeon furniture pain
            recipe = GetNewRecipe();
            recipe.AddIngredient(ItemID.BlueBrick);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.BlueBrickPlatform, 2);
            recipe.AddRecipe();

            recipe = GetNewRecipe();
            recipe.AddIngredient(ItemID.BlueBrick, 14);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.BlueDungeonBathtub);
            recipe.AddRecipe();

            recipe = GetNewRecipe();
            recipe.AddIngredient(ItemID.BlueBrick, 15);
            recipe.AddIngredient(ItemID.Silk, 5);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.BlueDungeonBed);
            recipe.AddRecipe();

            recipe = GetNewRecipe();
            recipe.AddIngredient(ItemID.BlueBrick, 20);
            recipe.AddIngredient(ItemID.Book, 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.BlueDungeonBookcase);
            recipe.AddRecipe();

            recipe = GetNewRecipe();
            recipe.AddIngredient(ItemID.BlueBrick, 5);
            recipe.AddIngredient(ItemID.Torch, 3);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.BlueDungeonCandelabra);
            recipe.AddRecipe();

            recipe = GetNewRecipe();
            recipe.AddIngredient(ItemID.BlueBrick, 4);
            recipe.AddIngredient(ItemID.Torch);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.BlueDungeonCandle);
            recipe.AddRecipe();

            recipe = GetNewRecipe();
            recipe.AddIngredient(ItemID.BlueBrick, 4);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.BlueDungeonChair);
            recipe.AddRecipe();

            recipe = GetNewRecipe();
            recipe.AddIngredient(ItemID.BlueBrick, 4);
            recipe.AddIngredient(ItemID.Torch, 4);
            recipe.AddIngredient(ItemID.Chain, 4);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.BlueDungeonChandelier);
            recipe.AddRecipe();

            recipe = GetNewRecipe();
            recipe.AddRecipeGroup("IronBar");
            recipe.AddIngredient(ItemID.Glass, 6);
            recipe.AddIngredient(ItemID.BlueBrick, 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.DungeonClockBlue);
            recipe.AddRecipe();

            recipe = GetNewRecipe();
            recipe.AddIngredient(ItemID.BlueBrick, 6);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.BlueDungeonDoor);
            recipe.AddRecipe();

            recipe = GetNewRecipe();
            recipe.AddIngredient(ItemID.BlueBrick, 16);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.BlueDungeonDresser);
            recipe.AddRecipe();

            recipe = GetNewRecipe();
            recipe.AddIngredient(ItemID.Torch);
            recipe.AddIngredient(ItemID.BlueBrick, 3);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.BlueDungeonLamp);
            recipe.AddRecipe();

            recipe = GetNewRecipe();
            recipe.AddIngredient(ItemID.Bone, 4);
            recipe.AddIngredient(ItemID.BlueBrick, 15);
            recipe.AddIngredient(ItemID.Book);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.BlueDungeonPiano);
            recipe.AddRecipe();

            recipe = GetNewRecipe();
            recipe.AddIngredient(ItemID.BlueBrick, 5);
            recipe.AddIngredient(ItemID.Silk, 2);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.BlueDungeonSofa);
            recipe.AddRecipe();

            recipe = GetNewRecipe();
            recipe.AddIngredient(ItemID.BlueBrick, 8);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.BlueDungeonTable);
            recipe.AddRecipe();

            recipe = GetNewRecipe();
            recipe.AddIngredient(ItemID.BlueBrick, 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.BlueDungeonVase);
            recipe.AddRecipe();

            recipe = GetNewRecipe();
            recipe.AddIngredient(ItemID.BlueBrick, 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.BlueDungeonWorkBench);
            recipe.AddRecipe();

            //green
            recipe = GetNewRecipe();
            recipe.AddIngredient(ItemID.GreenBrick);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.GreenBrickPlatform, 2);
            recipe.AddRecipe();

            recipe = GetNewRecipe();
            recipe.AddIngredient(ItemID.GreenBrick, 14);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.GreenDungeonBathtub);
            recipe.AddRecipe();

            recipe = GetNewRecipe();
            recipe.AddIngredient(ItemID.GreenBrick, 15);
            recipe.AddIngredient(ItemID.Silk, 5);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.GreenDungeonBed);
            recipe.AddRecipe();

            recipe = GetNewRecipe();
            recipe.AddIngredient(ItemID.GreenBrick, 20);
            recipe.AddIngredient(ItemID.Book, 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.GreenDungeonBookcase);
            recipe.AddRecipe();

            recipe = GetNewRecipe();
            recipe.AddIngredient(ItemID.GreenBrick, 5);
            recipe.AddIngredient(ItemID.Torch, 3);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.GreenDungeonCandelabra);
            recipe.AddRecipe();

            recipe = GetNewRecipe();
            recipe.AddIngredient(ItemID.GreenBrick, 4);
            recipe.AddIngredient(ItemID.Torch);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.GreenDungeonCandle);
            recipe.AddRecipe();

            recipe = GetNewRecipe();
            recipe.AddIngredient(ItemID.GreenBrick, 4);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.GreenDungeonChair);
            recipe.AddRecipe();

            recipe = GetNewRecipe();
            recipe.AddIngredient(ItemID.GreenBrick, 4);
            recipe.AddIngredient(ItemID.Torch, 4);
            recipe.AddIngredient(ItemID.Chain, 4);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.GreenDungeonChandelier);
            recipe.AddRecipe();

            recipe = GetNewRecipe();
            recipe.AddRecipeGroup("IronBar");
            recipe.AddIngredient(ItemID.Glass, 6);
            recipe.AddIngredient(ItemID.GreenBrick, 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.DungeonClockGreen);
            recipe.AddRecipe();

            recipe = GetNewRecipe();
            recipe.AddIngredient(ItemID.GreenBrick, 6);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.GreenDungeonDoor);
            recipe.AddRecipe();

            recipe = GetNewRecipe();
            recipe.AddIngredient(ItemID.GreenBrick, 16);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.GreenDungeonDresser);
            recipe.AddRecipe();

            recipe = GetNewRecipe();
            recipe.AddIngredient(ItemID.Torch);
            recipe.AddIngredient(ItemID.GreenBrick, 3);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.GreenDungeonLamp);
            recipe.AddRecipe();

            recipe = GetNewRecipe();
            recipe.AddIngredient(ItemID.Bone, 4);
            recipe.AddIngredient(ItemID.GreenBrick, 15);
            recipe.AddIngredient(ItemID.Book);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.GreenDungeonPiano);
            recipe.AddRecipe();

            recipe = GetNewRecipe();
            recipe.AddIngredient(ItemID.GreenBrick, 5);
            recipe.AddIngredient(ItemID.Silk, 2);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.GreenDungeonSofa);
            recipe.AddRecipe();

            recipe = GetNewRecipe();
            recipe.AddIngredient(ItemID.GreenBrick, 8);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.GreenDungeonTable);
            recipe.AddRecipe();

            recipe = GetNewRecipe();
            recipe.AddIngredient(ItemID.GreenBrick, 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.GreenDungeonVase);
            recipe.AddRecipe();

            recipe = GetNewRecipe();
            recipe.AddIngredient(ItemID.GreenBrick, 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.GreenDungeonWorkBench);
            recipe.AddRecipe();

            //pink
            recipe = GetNewRecipe();
            recipe.AddIngredient(ItemID.PinkBrick);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.PinkBrickPlatform, 2);
            recipe.AddRecipe();

            recipe = GetNewRecipe();
            recipe.AddIngredient(ItemID.PinkBrick, 14);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.PinkDungeonBathtub);
            recipe.AddRecipe();

            recipe = GetNewRecipe();
            recipe.AddIngredient(ItemID.PinkBrick, 15);
            recipe.AddIngredient(ItemID.Silk, 5);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.PinkDungeonBed);
            recipe.AddRecipe();

            recipe = GetNewRecipe();
            recipe.AddIngredient(ItemID.PinkBrick, 20);
            recipe.AddIngredient(ItemID.Book, 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.PinkDungeonBookcase);
            recipe.AddRecipe();

            recipe = GetNewRecipe();
            recipe.AddIngredient(ItemID.PinkBrick, 5);
            recipe.AddIngredient(ItemID.Torch, 3);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.PinkDungeonCandelabra);
            recipe.AddRecipe();

            recipe = GetNewRecipe();
            recipe.AddIngredient(ItemID.PinkBrick, 4);
            recipe.AddIngredient(ItemID.Torch);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.PinkDungeonCandle);
            recipe.AddRecipe();

            recipe = GetNewRecipe();
            recipe.AddIngredient(ItemID.PinkBrick, 4);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.PinkDungeonChair);
            recipe.AddRecipe();

            recipe = GetNewRecipe();
            recipe.AddIngredient(ItemID.PinkBrick, 4);
            recipe.AddIngredient(ItemID.Torch, 4);
            recipe.AddIngredient(ItemID.Chain, 4);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.PinkDungeonChandelier);
            recipe.AddRecipe();

            recipe = GetNewRecipe();
            recipe.AddRecipeGroup("IronBar");
            recipe.AddIngredient(ItemID.Glass, 6);
            recipe.AddIngredient(ItemID.PinkBrick, 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.DungeonClockPink);
            recipe.AddRecipe();

            recipe = GetNewRecipe();
            recipe.AddIngredient(ItemID.PinkBrick, 6);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.PinkDungeonDoor);
            recipe.AddRecipe();

            recipe = GetNewRecipe();
            recipe.AddIngredient(ItemID.PinkBrick, 16);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.PinkDungeonDresser);
            recipe.AddRecipe();

            recipe = GetNewRecipe();
            recipe.AddIngredient(ItemID.Torch);
            recipe.AddIngredient(ItemID.PinkBrick, 3);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.PinkDungeonLamp);
            recipe.AddRecipe();

            recipe = GetNewRecipe();
            recipe.AddIngredient(ItemID.Bone, 4);
            recipe.AddIngredient(ItemID.PinkBrick, 15);
            recipe.AddIngredient(ItemID.Book);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.PinkDungeonPiano);
            recipe.AddRecipe();

            recipe = GetNewRecipe();
            recipe.AddIngredient(ItemID.PinkBrick, 5);
            recipe.AddIngredient(ItemID.Silk, 2);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.PinkDungeonSofa);
            recipe.AddRecipe();

            recipe = GetNewRecipe();
            recipe.AddIngredient(ItemID.PinkBrick, 8);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.PinkDungeonTable);
            recipe.AddRecipe();

            recipe = GetNewRecipe();
            recipe.AddIngredient(ItemID.PinkBrick, 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.PinkDungeonVase);
            recipe.AddRecipe();

            recipe = GetNewRecipe();
            recipe.AddIngredient(ItemID.PinkBrick, 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.PinkDungeonWorkBench);
            recipe.AddRecipe();

        }

        private static void AddDungeonFurnitureRecipes()
        {

        }

        private static void AddConvertRecipe(int item, int item2)
        {
            ModRecipe recipe = GetNewRecipe();
            recipe.AddIngredient(item);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(item2);
            recipe.AddRecipe();

            recipe = GetNewRecipe();
            recipe.AddIngredient(item2);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(item);
            recipe.AddRecipe();

            recipe = GetNewRecipe();
            recipe.AddIngredient(item);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(item2);
            recipe.AddRecipe();

            recipe = GetNewRecipe();
            recipe.AddIngredient(item2);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(item);
            recipe.AddRecipe();
        }

        private static ModRecipe GetNewRecipe()
        {
            return new ModRecipe(ModContent.GetInstance<Fargowiltas>());
        }
    }
}
