using Fargowiltas.NPCs;
using Microsoft.Xna.Framework;
using System;
using System.IO;
using Terraria;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Fargowiltas
{
    class Fargowiltas : Mod
    {
        //hotkeys
        internal static ModHotKey CustomKey;
        internal static ModHotKey HomeKey;
        internal static ModHotKey RodKey;

        #region mod loaded bools
        internal bool fargoLoaded;

        internal bool blueMagicLoaded;
        internal bool calamityLoaded;
        internal bool cookieLoaded;
        internal bool crystiliumLoaded;
        internal bool grealmLoaded;
        internal bool joostLoaded;
        internal bool nightmaresLoaded;
        internal bool pumpkingLoaded;
        internal bool sacredToolsLoaded;
        internal bool spiritLoaded;
        internal bool terraCompLoaded;
        internal bool thoriumLoaded;
        internal bool tremorLoaded;
        internal bool w1kLoaded;
        internal bool ancientsLoaded;
        internal bool btfaLoaded;
        internal bool disarrayLoaded;
        internal bool elementsLoaded;
        internal bool enigmaLoaded;
        internal bool splitLoaded;
        internal bool JSLoaded;
        //internal bool ferniumLoaded;
        internal bool antiarisLoaded;
        internal bool aaLoaded;
        internal bool trelamiumLoaded;
        internal bool pinkyLoaded;
        internal bool redemptionLoaded;
        internal bool ocramLoaded;
        internal bool CSkiesLoaded;
        #endregion

        //swarms
        internal static bool swarmActive;
        internal static int swarmKills;
        internal static int swarmTotal;
        internal static int swarmSpawned;

        internal static Fargowiltas instance;

        public Fargowiltas()
        {
            Properties = new ModProperties()
            {
                Autoload = true,
                AutoloadGores = true,
                AutoloadSounds = true
            };
        }

        public override void Load()
        {
            instance = this;
            HomeKey = RegisterHotKey("Teleport Home", "P");
            RodKey = RegisterHotKey("Rod of Discord", "E");
            CustomKey = RegisterHotKey("Custom Hotkey (Bottom Left Inventory Slot)", "K");
        }

        #region mod loaded bools + census
        //bool sheet
        public override void PostSetupContent()
        {
            try
            {
                fargoLoaded = ModLoader.GetMod("FargowiltasSouls") != null;

                blueMagicLoaded = ModLoader.GetMod("Bluemagic") != null;
                calamityLoaded = ModLoader.GetMod("CalamityMod") != null;
                cookieLoaded = ModLoader.GetMod("CookieMod") != null;
                crystiliumLoaded = ModLoader.GetMod("CrystiliumMod") != null;
                grealmLoaded = ModLoader.GetMod("GRealm") != null;
                joostLoaded = ModLoader.GetMod("JoostMod") != null;
                nightmaresLoaded = ModLoader.GetMod("TrueEater") != null;
                pumpkingLoaded = ModLoader.GetMod("Pumpking") != null;
                sacredToolsLoaded = ModLoader.GetMod("SacredTools") != null;
                spiritLoaded = ModLoader.GetMod("SpiritMod") != null;
                terraCompLoaded = ModLoader.GetMod("TerraCompilation") != null;
                thoriumLoaded = ModLoader.GetMod("ThoriumMod") != null;
                tremorLoaded = ModLoader.GetMod("Tremor") != null;
                w1kLoaded = ModLoader.GetMod("W1KModRedux") != null;
                ancientsLoaded = ModLoader.GetMod("EchoesoftheAncients") != null;
                btfaLoaded = ModLoader.GetMod("ForgottenMemories") != null;
                disarrayLoaded = ModLoader.GetMod("Disarray") != null;
                elementsLoaded = ModLoader.GetMod("ElementsAwoken") != null;
                enigmaLoaded = ModLoader.GetMod("Laugicality") != null; //why
                splitLoaded = ModLoader.GetMod("Split") != null;
                antiarisLoaded = ModLoader.GetMod("Antiaris") != null;
                aaLoaded = ModLoader.GetMod("AAMod") != null;
                trelamiumLoaded = ModLoader.GetMod("TrelamiumMod") != null;
                pinkyLoaded = ModLoader.GetMod("pinkymod") != null;
                redemptionLoaded = ModLoader.GetMod("Redemption") != null;
                JSLoaded = ModLoader.GetMod("Jetshift") != null;
                ocramLoaded = ModLoader.GetMod("Ocram") != null;
                CSkiesLoaded = ModLoader.GetMod("CSkies") != null;
            }
            catch (Exception e)
            {
                ErrorLogger.Log("Fargowiltas PostSetupContent Error: " + e.StackTrace + e.Message);
            }
            Mod censusMod = ModLoader.GetMod("Census");
            if (censusMod != null)
            {
				censusMod.Call("TownNPCCondition", NPCType("Deviantt"), "Use the Mutant's Gift");
				censusMod.Call("TownNPCCondition", NPCType("Mutant"), "Defeat any Boss or Miniboss");
				censusMod.Call("TownNPCCondition", NPCType("LumberJack"), "Hold a Wooden Token in your Inventory");
				censusMod.Call("TownNPCCondition", NPCType("Abominationn"), "Defeat any Event");

			}

        }
        #endregion

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(this);

            #region summon conversions
            recipe = new ModRecipe(this);
            recipe.AddIngredient(null, "FleshyDoll");
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.GuideVoodooDoll);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(null, "LihzahrdPowerCell2");
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.LihzahrdPowerCell);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(null, "TruffleWorm2");
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.TruffleWorm);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(null, "CelestialSigil2");
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.CelestialSigil);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(null, "MechEye");
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.MechanicalEye);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(null, "MechWorm");
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.MechanicalWorm);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(null, "MechSkull");
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.MechanicalSkull);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(null, "GoreySpine");
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.BloodySpine);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(null, "SlimyCrown");
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.SlimeCrown);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(null, "Abeemination2");
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.Abeemination);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(null, "WormyFood");
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.WormFood);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(null, "SuspiciousEye");
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.SuspiciousLookingEye);
            recipe.AddRecipe();

            #endregion

            #region crimson/corruption conversions

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.PurpleSolution);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(ItemID.RedSolution);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.RedSolution);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(ItemID.PurpleSolution);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.Ichor);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(ItemID.CursedFlame);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.CursedFlame);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(ItemID.Ichor);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.FleshKnuckles);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(ItemID.PutridScent);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.PutridScent);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(ItemID.FleshKnuckles);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.DartPistol);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(ItemID.DartRifle);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.DartRifle);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(ItemID.DartPistol);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.WormHook);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(ItemID.TendonHook);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.TendonHook);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(ItemID.WormHook);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.ChainGuillotines);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(ItemID.FetidBaghnakhs);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.FetidBaghnakhs);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(ItemID.ChainGuillotines);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.ClingerStaff);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(ItemID.SoulDrain);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.SoulDrain);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(ItemID.ClingerStaff);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.ShadowOrb);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(ItemID.CrimsonHeart);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.CrimsonHeart);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(ItemID.ShadowOrb);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.Musket);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(ItemID.TheUndertaker);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.TheUndertaker);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(ItemID.Musket);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.PanicNecklace);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(ItemID.BandofStarpower);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.BandofStarpower);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(ItemID.PanicNecklace);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.BallOHurt);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(ItemID.TheRottedFork);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.TheRottedFork);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(ItemID.BallOHurt);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.CrimsonRod);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(ItemID.Vilethorn);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.Vilethorn);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(ItemID.CrimsonRod);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.CrimstoneBlock);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(ItemID.EbonstoneBlock);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.EbonstoneBlock);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(ItemID.CrimstoneBlock);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.Shadewood);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(ItemID.Ebonwood);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.Ebonwood);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(ItemID.Shadewood);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.VileMushroom);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(ItemID.ViciousMushroom);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.ViciousMushroom);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(ItemID.VileMushroom);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.Ebonkoi);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(ItemID.CrimsonTigerfish);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.Ebonkoi);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(ItemID.Hemopiranha);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.CrimsonTigerfish);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(ItemID.Ebonkoi);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.Hemopiranha);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(ItemID.Ebonkoi);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.Bladetongue);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(ItemID.Toxikarp);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.Toxikarp);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(ItemID.Bladetongue);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.VampireKnives);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(ItemID.ScourgeoftheCorruptor);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.ScourgeoftheCorruptor);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(ItemID.VampireKnives);
            recipe.AddRecipe();

            #endregion

            #region banner recipes
            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.AngryBonesBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.TallyCounter);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.WalkingAntlionBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.AntlionClaw);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.SlimeBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.Gel, 200);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.PinkyBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.PinkGel, 999);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.UmbrellaSlimeBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.UmbrellaHat);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.LavaSlimeBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.Cascade);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.ToxicSludgeBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.Bezoar);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.CorruptSlimeBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.Blindfold);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.PinkJellyfishBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.JellyfishNecklace);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.PixieBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.Megaphone);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.BatBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.ChainKnife);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.JungleBatBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.DepthMeter);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.CursedSkullBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.Nazar);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.DemonBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.DemonScythe);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.ZombieBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.ZombieArm);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.ZombieBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.Shackle);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.RaincoatZombieBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.RainHat);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.ZombieEskimoBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.EskimoHood);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.ZombieEskimoBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.EskimoCoat);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.ZombieEskimoBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.EskimoPants);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.BloodZombieBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.SharkToothNecklace);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.FireImpBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.ObsidianRose);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.GiantShellyBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.Rally);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.CrawdadBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.Rally);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.SalamanderBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.Rally);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.WormBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.WhoopieCushion);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.GraniteFlyerBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.NightVisionHelmet);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.HarpyBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.GiantHarpyFeather);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.HellbatBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.MagmaStone);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.DemonEyeBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.BlackLens);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.HornetBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.TatteredBeeWing);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.IceBatBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.DepthMeter);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.PiranhaBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.RobotHat);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.SharkBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.DivingHelmet);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.SkeletonBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.BoneSword);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.SnowFlinxBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.SnowballLauncher);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.UndeadMinerBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.BonePickaxe);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.UndeadVikingBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.VikingHelmet);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.AnglerFishBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.AdhesiveBandage);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.AngryTrapperBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.Uzi);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.ArmoredSkeletonBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.ArmorPolish);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.ArmoredSkeletonBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.BeamSword);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.ArmoredVikingBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.IceSickle);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.DesertBasiliskBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.AncientHorn);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.BlackRecluseBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.PoisonStaff);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.CorruptorBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.Vitamins);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.FloatyGrossBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.Vitamins);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.DesertDjinnBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.DjinnLamp);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.DesertDjinnBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.DjinnsCurse);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.GiantBatBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.TrifoldMap);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.MummyBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.MummyMask);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.MummyBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.MummyShirt);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.MummyBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.MummyPants);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.WerewolfBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.MoonCharm);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.VampireBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.BrokenBatWing);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.EyezorBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.EyeSpring);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.DiablolistBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.InfernoFork);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.NecromancerBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.ShadowbeamStaff);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.RaggedCasterBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.SpectreStaff);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.PaladinBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.PaladinsHammer);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.PaladinBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.PaladinsShield);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.WraithBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.FastClock);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.DarkMummyBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.Blindfold);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.IcyMermanBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.FrostStaff);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.IceTortoiseBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.FrozenTurtleShell);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.LihzahrdBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.LizardEgg);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.MedusaBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.MedusaHead);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.MedusaBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.PocketMirror);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.SkeletonArcherBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.MagicQuiver);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.SkeletonArcherBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.Marrow);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.UnicornBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.UnicornonaStick);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.GastropodBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.BlessedApple);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.AngryNimbusBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.NimbusRod);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.DripplerBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.MoneyTrough);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.GoblinArcherBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.Harpoon);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.ButcherBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.ButchersChainsaw);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.CreatureFromTheDeepBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.NeptunesShell);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.DeadlySphereBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.DeadlySphereStaff);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.DrManFlyBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.ToxicFlask);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.MothronBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.MothronWings);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.PsychoBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.PsychoKnife);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.ReaperBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.DeathSickle);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.MartianScutlixGunnerBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.BrainScrambler);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.RedDevilBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.UnholyTrident);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.RedDevilBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.FireFeather);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.LavaBatBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.HelFire);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.WolfBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.Amarok);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.JungleCreeperBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.Yelets);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.ZombieElfBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.ElfHat);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.ZombieElfBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.ElfShirt);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.ZombieElfBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.ElfPants);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.PirateBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.SailorHat);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.PirateBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.SailorShirt);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.PirateBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.SailorPants);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.BunnyBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.BunnyHood);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.PenguinBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.PedguinHat);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.PenguinBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.PedguinShirt);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.PenguinBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.PedguinPants);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddRecipeGroup("Fargowiltas:AnyArmoredBones");
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.Keybrand);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddRecipeGroup("Fargowiltas:AnyArmoredBones");
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.Kraken);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddRecipeGroup("Fargowiltas:AnyArmoredBones");
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.MagnetSphere);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddRecipeGroup("Fargowiltas:AnyArmoredBones");
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.WispinaBottle);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddRecipeGroup("Fargowiltas:AnyArmoredBones");
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.BoneFeather);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.DesertLamiaBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.LamiaHat);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.DesertLamiaBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.LamiaShirt);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.DesertLamiaBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.LamiaPants);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.DesertLamiaBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.MoonMask);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.DesertLamiaBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.SunMask);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.FloatyGrossBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.MeatGrinder);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.SkeletonMageBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.BoneWand);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.VampireBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.MoonStone);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.PirateCaptainBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.Cutlass);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.PirateCaptainBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.GoldRing);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.PirateCaptainBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.PirateStaff);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.PirateCaptainBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.DiscountCard);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.PirateCaptainBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.LuckyCoin);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.PirateCaptainBanner, 5);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.CoinGun);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.ChaosElementalBanner, 5);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.RodofDiscord);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.SkeletonCommandoBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.RocketLauncher);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.SkeletonSniperBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.RifleScope);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.SkeletonSniperBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.SniperRifle);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.TacticalSkeletonBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.TacticalShotgun);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.TacticalSkeletonBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.SWATHelmet);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.BoneLeeBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.BlackBelt);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.BoneLeeBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.Tabi);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.PresentMimicBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.ToySled);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.NailheadBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.NailGun);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.ButcherBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.ButchersChainsaw);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.DeadlySphereBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.DeadlySphereStaff);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.DrManFlyBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.ToxicFlask);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.PsychoBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.PsychoKnife);
            recipe.AddRecipe();

            #endregion

            #region statue recipes
            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.BatBanner);
            recipe.AddIngredient(ItemID.StoneBlock, 50);
            recipe.AddTile(TileID.HeavyWorkBench);
            recipe.SetResult(ItemID.BatStatue);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.MimicBanner);
            recipe.AddIngredient(ItemID.StoneBlock, 50);
            recipe.AddTile(TileID.HeavyWorkBench);
            recipe.SetResult(ItemID.ChestStatue);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.CrabBanner);
            recipe.AddIngredient(ItemID.StoneBlock, 50);
            recipe.AddTile(TileID.HeavyWorkBench);
            recipe.SetResult(ItemID.CrabStatue);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.JellyfishBanner);
            recipe.AddIngredient(ItemID.StoneBlock, 50);
            recipe.AddTile(TileID.HeavyWorkBench);
            recipe.SetResult(ItemID.JellyfishStatue);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.PiranhaBanner);
            recipe.AddIngredient(ItemID.StoneBlock, 50);
            recipe.AddTile(TileID.HeavyWorkBench);
            recipe.SetResult(ItemID.PiranhaStatue);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.SharkBanner);
            recipe.AddIngredient(ItemID.StoneBlock, 50);
            recipe.AddTile(TileID.HeavyWorkBench);
            recipe.SetResult(ItemID.SharkStatue);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.SkeletonBanner);
            recipe.AddIngredient(ItemID.StoneBlock, 50);
            recipe.AddTile(TileID.HeavyWorkBench);
            recipe.SetResult(ItemID.SkeletonStatue);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.SlimeBanner);
            recipe.AddIngredient(ItemID.StoneBlock, 50);
            recipe.AddTile(TileID.HeavyWorkBench);
            recipe.SetResult(ItemID.SlimeStatue);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.SpiderBanner);
            recipe.AddIngredient(ItemID.StoneBlock, 50);
            recipe.AddTile(TileID.HeavyWorkBench);
            recipe.SetResult(ItemID.WallCreeperStatue);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.UnicornBanner);
            recipe.AddIngredient(ItemID.StoneBlock, 50);
            recipe.AddTile(TileID.HeavyWorkBench);
            recipe.SetResult(ItemID.UnicornStatue);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.DripplerBanner);
            recipe.AddIngredient(ItemID.StoneBlock, 50);
            recipe.AddTile(TileID.HeavyWorkBench);
            recipe.SetResult(ItemID.DripplerStatue);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.WraithBanner);
            recipe.AddIngredient(ItemID.StoneBlock, 50);
            recipe.AddTile(TileID.HeavyWorkBench);
            recipe.SetResult(ItemID.WraithStatue);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.UndeadVikingBanner);
            recipe.AddIngredient(ItemID.StoneBlock, 50);
            recipe.AddTile(TileID.HeavyWorkBench);
            recipe.SetResult(ItemID.UndeadVikingStatue);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.MedusaBanner);
            recipe.AddIngredient(ItemID.StoneBlock, 50);
            recipe.AddTile(TileID.HeavyWorkBench);
            recipe.SetResult(ItemID.MedusaStatue);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.HarpyBanner);
            recipe.AddIngredient(ItemID.StoneBlock, 50);
            recipe.AddTile(TileID.HeavyWorkBench);
            recipe.SetResult(ItemID.HarpyStatue);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.PigronBanner);
            recipe.AddIngredient(ItemID.StoneBlock, 50);
            recipe.AddTile(TileID.HeavyWorkBench);
            recipe.SetResult(ItemID.PigronStatue);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.GreekSkeletonBanner);
            recipe.AddIngredient(ItemID.StoneBlock, 50);
            recipe.AddTile(TileID.HeavyWorkBench);
            recipe.SetResult(ItemID.HopliteStatue);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.GraniteGolemBanner);
            recipe.AddIngredient(ItemID.StoneBlock, 50);
            recipe.AddTile(TileID.HeavyWorkBench);
            recipe.SetResult(ItemID.GraniteGolemStatue);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.BloodZombieBanner);
            recipe.AddIngredient(ItemID.StoneBlock, 50);
            recipe.AddTile(TileID.HeavyWorkBench);
            recipe.SetResult(ItemID.BloodZombieStatue);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.Bomb, 99);
            recipe.AddIngredient(ItemID.StoneBlock, 50);
            recipe.AddTile(TileID.HeavyWorkBench);
            recipe.SetResult(ItemID.BombStatue);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.LifeCrystal, 6);
            recipe.AddIngredient(ItemID.StoneBlock, 50);
            recipe.AddTile(TileID.HeavyWorkBench);
            recipe.SetResult(ItemID.HeartStatue);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.ManaCrystal, 6);
            recipe.AddIngredient(ItemID.StoneBlock, 50);
            recipe.AddTile(TileID.HeavyWorkBench);
            recipe.SetResult(ItemID.StarStatue);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.Throne);
            recipe.AddIngredient(ItemID.TeleportationPotion);
            recipe.AddIngredient(ItemID.StoneBlock, 50);
            recipe.AddTile(TileID.HeavyWorkBench);
            recipe.SetResult(ItemID.KingStatue);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.Throne);
            recipe.AddIngredient(ItemID.TeleportationPotion);
            recipe.AddIngredient(ItemID.StoneBlock, 50);
            recipe.AddTile(TileID.HeavyWorkBench);
            recipe.SetResult(ItemID.QueenStatue);
            recipe.AddRecipe();

            #endregion

            #region ore conversions
            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.CopperBar);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(ItemID.TinBar);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.TinBar);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(ItemID.CopperBar);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.IronBar);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(ItemID.LeadBar);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.LeadBar);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(ItemID.IronBar);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.SilverBar);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(ItemID.TungstenBar);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.TungstenBar);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(ItemID.SilverBar);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.GoldBar);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(ItemID.PlatinumBar);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.PlatinumBar);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(ItemID.GoldBar);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.CobaltBar);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(ItemID.PalladiumBar);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.PalladiumBar);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(ItemID.CobaltBar);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.MythrilBar);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(ItemID.OrichalcumBar);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.OrichalcumBar);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(ItemID.MythrilBar);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.AdamantiteBar);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(ItemID.TitaniumBar);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.TitaniumBar);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(ItemID.AdamantiteBar);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.DemoniteBar);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(ItemID.CrimtaneBar);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.CrimtaneBar);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(ItemID.DemoniteBar);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.ShadowScale);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(ItemID.TissueSample);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.TissueSample);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(ItemID.ShadowScale);
            recipe.AddRecipe();

            #endregion

            #region water chest loot

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.Spear);
            recipe.AddIngredient(ItemID.Coral, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ItemID.Trident);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.PalmWood, 20);
            recipe.AddTile(TileID.Sawmill);
            recipe.SetResult(ItemID.BreathingReed);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.Silk, 20);
            recipe.AddIngredient(ItemID.Seashell, 5);
            recipe.AddTile(TileID.Loom);
            recipe.SetResult(ItemID.Flipper);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.HermesBoots);
            recipe.AddIngredient(ItemID.Starfish, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ItemID.WaterWalkingBoots);
            recipe.AddRecipe();

            #endregion

            #region biome chest loot

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.CrimsonKey);
            recipe.AddIngredient(ItemID.Ectoplasm, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ItemID.VampireKnives);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.CorruptionKey);
            recipe.AddIngredient(ItemID.Ectoplasm, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ItemID.ScourgeoftheCorruptor);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.JungleKey);
            recipe.AddIngredient(ItemID.Ectoplasm, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ItemID.PiranhaGun);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.FrozenKey);
            recipe.AddIngredient(ItemID.Ectoplasm, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ItemID.StaffoftheFrostHydra);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.HallowedKey);
            recipe.AddIngredient(ItemID.Ectoplasm, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ItemID.RainbowGun);
            recipe.AddRecipe();

            if (thoriumLoaded)
            {
                Mod thorium = ModLoader.GetMod("ThoriumMod");

                recipe = new ModRecipe(this);
                recipe.AddIngredient(thorium.ItemType("DesertBiomeKey"));
                recipe.AddIngredient(ItemID.Ectoplasm, 10);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.SetResult(thorium.ItemType("PharaohsSlab"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(thorium.ItemType("UnderworldBiomeKey"));
                recipe.AddIngredient(ItemID.Ectoplasm, 10);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.SetResult(thorium.ItemType("PheonixStaff"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(thorium.ItemType("AquaticDepthsBiomeKey"));
                recipe.AddIngredient(ItemID.Ectoplasm, 10);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.SetResult(thorium.ItemType("Fishbone"));
                recipe.AddRecipe();
            }

            #endregion

            #region npc recipes

            recipe = new ModRecipe(this);
            recipe.AddRecipeGroup("Fargowiltas:AnyCaughtNPC");
            recipe.AddTile(TileID.MeatGrinder);
            recipe.SetResult(ItemID.FleshBlock, 15);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddRecipeGroup("Fargowiltas:AnyCaughtNPC");
            recipe.AddTile(TileID.DyeVat);
            recipe.SetResult(ItemID.DeepRedPaint, 100);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddRecipeGroup("Fargowiltas:AnyCaughtNPC");
            recipe.AddTile(TileID.DyeVat);
            recipe.SetResult(ItemID.GrimDye, 3);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddRecipeGroup("Fargowiltas:AnyCaughtNPC");
            recipe.AddTile(TileID.BoneWelder);
            recipe.SetResult(ItemID.Bone, 25);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(null, "Dryad");
            recipe.AddTile(TileID.LivingLoom);
            recipe.SetResult(ItemID.LeafWand);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(null, "Dryad");
            recipe.AddTile(TileID.LivingLoom);
            recipe.SetResult(ItemID.LivingWoodWand);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(null, "Truffle");
            recipe.AddIngredient(ItemID.EnchantedNightcrawler);
            recipe.AddTile(TileID.Autohammer);
            recipe.SetResult(ItemID.TruffleWorm);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(null, "DyeTrader");
            recipe.AddIngredient(ItemID.WoodenSword);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(ItemID.DyeTradersScimitar);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(null, "Tavernkeep");
            recipe.AddIngredient(ItemID.Ale, 5);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(ItemID.AleThrowingGlove);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(null, "Stylist");
            recipe.AddIngredient(ItemID.WoodenSword);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(ItemID.StylistKilLaKillScissorsIWish);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(null, "Painter");
            recipe.AddIngredient(ItemID.WoodenBow);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(ItemID.PainterPaintballGun);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(null, "TaxCollector");
            recipe.AddIngredient(ItemID.WoodenSword);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(ItemID.TaxCollectorsStickOfDoom);
            recipe.AddRecipe();

            #endregion

            #region emblems 
            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.RangerEmblem);
            recipe.AddIngredient(ItemID.SoulofLight);
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(ItemID.SorcererEmblem);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.WarriorEmblem);
            recipe.AddIngredient(ItemID.SoulofLight);
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(ItemID.SorcererEmblem);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.SummonerEmblem);
            recipe.AddIngredient(ItemID.SoulofLight);
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(ItemID.SorcererEmblem);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.WarriorEmblem);
            recipe.AddIngredient(ItemID.SoulofLight);
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(ItemID.RangerEmblem);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.SorcererEmblem);
            recipe.AddIngredient(ItemID.SoulofLight);
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(ItemID.RangerEmblem);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.SummonerEmblem);
            recipe.AddIngredient(ItemID.SoulofLight);
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(ItemID.RangerEmblem);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.RangerEmblem);
            recipe.AddIngredient(ItemID.SoulofLight);
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(ItemID.WarriorEmblem);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.SorcererEmblem);
            recipe.AddIngredient(ItemID.SoulofLight);
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(ItemID.WarriorEmblem);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.SummonerEmblem);
            recipe.AddIngredient(ItemID.SoulofLight);
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(ItemID.WarriorEmblem);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.RangerEmblem);
            recipe.AddIngredient(ItemID.SoulofLight);
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(ItemID.SummonerEmblem);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.SorcererEmblem);
            recipe.AddIngredient(ItemID.SoulofLight);
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(ItemID.SummonerEmblem);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.WarriorEmblem);
            recipe.AddIngredient(ItemID.SoulofLight);
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(ItemID.SummonerEmblem);
            recipe.AddRecipe();
            #endregion

            #region goodiebag/present recipes

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.GoodieBag, 50);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.UnluckyYarn);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.GoodieBag, 100);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.BatHook);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.Present, 50);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.DogWhistle);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.Present, 50);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.Toolbox);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.Present, 50);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.HandWarmer);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.Present, 50);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.RedRyder);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.Present, 50);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.CandyCaneSword);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.Present, 50);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.CandyCaneHook);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.Present, 50);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.FruitcakeChakram);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.Present, 50);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.CnadyCanePickaxe);
            recipe.AddRecipe();

            #endregion

            #region misc recipes

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.SillyBalloonPink);
            recipe.AddIngredient(ItemID.WhiteString);
            recipe.AddTile(TileID.SkyMill);
            recipe.SetResult(ItemID.ShinyRedBalloon);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.GoldBar, 10);
            recipe.AddIngredient(ItemID.Feather, 5);
            recipe.AddTile(TileID.SkyMill);
            recipe.SetResult(ItemID.LuckyHorseshoe);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.IceBlade);
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(ItemID.EnchantedSword);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.EnchantedSword, 2);
            recipe.AddIngredient(ItemID.SoulofLight, 5);
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(ItemID.Arkhalis);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.Pumpkin, 500);
            recipe.AddTile(TileID.LivingLoom);
            recipe.SetResult(ItemID.MagicalPumpkinSeed);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.FishingSeaweed, 10);
            recipe.AddTile(TileID.LivingLoom);
            recipe.SetResult(ItemID.Seaweed);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
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

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.Loom);
            recipe.AddIngredient(ItemID.Vine, 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.LivingLoom);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.NaturesGift);
            recipe.AddIngredient(ItemID.RedHusk);
            recipe.AddTile(TileID.LivingLoom);
            recipe.SetResult(ItemID.JungleRose);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.Amber, 15);
            recipe.AddIngredient(ItemID.Firefly);
            recipe.AddTile(TileID.CookingPots);
            recipe.SetResult(ItemID.AmberMosquito);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.Moonglow, 15);
            recipe.AddIngredient(ItemID.ManaCrystal);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(ItemID.NaturesGift);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.SandBlock, 50);
            recipe.AddIngredient(ItemID.Bottle);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(ItemID.SandstorminaBottle);
            recipe.AddRecipe();


            #endregion

            #region thorium banner recipes

            if (thoriumLoaded)
            {
                Mod thorium = ModLoader.GetMod("ThoriumMod");

                recipe = new ModRecipe(this);
                recipe.AddIngredient(thorium.ItemType("AncientChargerBanner"));
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(thorium.ItemType("OlympicTorch"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(thorium.ItemType("AncientPhalanxBanner"));
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(thorium.ItemType("AncientAegis"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(thorium.ItemType("ArmyAntBanner"));
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(thorium.ItemType("HiveMind"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(thorium.ItemType("CoinBagBanner"));
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(thorium.ItemType("AncientDrachma"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(thorium.ItemType("CoolmeraBanner"));
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(thorium.ItemType("MeatBallStaff"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(thorium.ItemType("DarksteelKnightBanner"));
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(thorium.ItemType("BrokenDarksteelHelmet"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(thorium.ItemType("DarksteelKnightBanner"));
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(thorium.ItemType("GrayDPaintingItem"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(thorium.ItemType("FlamekinCasterBanner"));
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(thorium.ItemType("MoltenScale"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(thorium.ItemType("GigaClamBanner"));
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(thorium.ItemType("NanoClamCane"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(thorium.ItemType("HammerHeadBanner"));
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(thorium.ItemType("CartlidgedCatcher"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(thorium.ItemType("ShamblerBanner"));
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(thorium.ItemType("BallnChain"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(thorium.ItemType("UFOBanner"));
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(thorium.ItemType("DetachedUFOBlaster"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(thorium.ItemType("WindElementalBanner"));
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(thorium.ItemType("Zapper"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(thorium.ItemType("AstroBeetleBanner"));
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(thorium.ItemType("AstroBeetleHusk"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(thorium.ItemType("BlisterPodBanner"));
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(thorium.ItemType("BlisterSack"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(thorium.ItemType("BoneFlayerBanner"));
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(thorium.ItemType("BoneFlayerTail"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(thorium.ItemType("ChilledSpitterBanner"));
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(thorium.ItemType("FrostPlagueStaff"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(thorium.ItemType("ColdlingBanner"));
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(thorium.ItemType("SpineBuster"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(thorium.ItemType("CrownBanner"));
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(thorium.ItemType("SpinyShell"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(thorium.ItemType("GnomesBanner"));
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(thorium.ItemType("GnomePick"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(thorium.ItemType("InvaderBanner"));
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(thorium.ItemType("VegaPhaser"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(thorium.ItemType("InvaderBanner"));
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(thorium.ItemType("BioPod"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(thorium.ItemType("InfernalHoundBanner"));
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(thorium.ItemType("MoltenCollar"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(thorium.ItemType("KrakenBanner"));
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(thorium.ItemType("Leviathan"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(thorium.ItemType("UnderworldPotBanner"));
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(thorium.ItemType("HotPot"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(thorium.ItemType("NecroPotBanner"));
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(thorium.ItemType("GhostlyGrapple"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(thorium.ItemType("LycanBanner"));
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(thorium.ItemType("MoonlightStaff"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(thorium.ItemType("MoltenMortarBanner"));
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(thorium.ItemType("MortarStaff"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(thorium.ItemType("SpectrumiteBanner"));
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(thorium.ItemType("PrismiteStaff"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(thorium.ItemType("TarantulaBanner"));
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(thorium.ItemType("Arthropod"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(thorium.ItemType("VampireSquidBanner"));
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(thorium.ItemType("VampireGland"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(thorium.ItemType("StarvedBanner"));
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(thorium.ItemType("DesecratedHeart"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(thorium.ItemType("VileSpitterBanner"));
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(thorium.ItemType("VileSpitter"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(thorium.ItemType("VoltBanner"));
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(thorium.ItemType("VoltHatchet"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(thorium.ItemType("WargBanner"));
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(thorium.ItemType("BattleHorn"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(thorium.ItemType("WargBanner"));
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(thorium.ItemType("BlackCatEars"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(thorium.ItemType("NecroticImbuerBanner"));
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(thorium.ItemType("TechniqueBloodLotus"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(thorium.ItemType("NecroticImbuerBanner"));
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(thorium.ItemType("NecroticStaff"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(thorium.ItemType("BlizzardBatBanner"));
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(thorium.ItemType("IceFairyStaff"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(thorium.ItemType("FrostBurntBanner"));
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(thorium.ItemType("BlizzardsEdge"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(thorium.ItemType("SnowyOwlBanner"));
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(thorium.ItemType("LostMail"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(thorium.ItemType("SnowSingaBanner"));
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(thorium.ItemType("EskimoBanjo"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(thorium.ItemType("ScissorStalkerBanner"));
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(thorium.ItemType("StalkersSnippers"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(thorium.ItemType("SharptoothBanner"), 4);
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(thorium.ItemType("GoldenScale"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.SquirrelGold, 10);
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(thorium.ItemType("SinisterAcorn"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.MimicBanner);
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(thorium.ItemType("ProofAvarice"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.MimicBanner);
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(thorium.ItemType("LargeCoin"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.SnowBallaBanner);
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(thorium.ItemType("HailBomber"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.RaggedCasterBanner);
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(thorium.ItemType("GatewayGlass"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.FrankensteinBanner);
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(thorium.ItemType("TeslaDefibrillator"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.PirateDeadeyeBanner);
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(thorium.ItemType("DeadEyePatch"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.SkeletonCommandoBanner);
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(thorium.ItemType("LaunchJumper"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.MartianOfficerBanner);
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(thorium.ItemType("ShieldDroneBeacon"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.SwampThingBanner);
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(thorium.ItemType("SwampSpike"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.MisterStabbyBanner);
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(thorium.ItemType("BackStabber"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.BloodZombieBanner);
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(thorium.ItemType("BloodCellStaff"));
                recipe.AddRecipe();

               /* recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.BloodZombieBanner);
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(thorium.ItemType("BloodDrinker"));
                recipe.AddRecipe();*/

                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.DripplerBanner);
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(thorium.ItemType("Bagpipe"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.WyvernBanner);
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(thorium.ItemType("CloudyChewToy"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.RedDevilBanner);
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(thorium.ItemType("DemonTongue"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.AngryBonesBanner);
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(thorium.ItemType("GraveGoods"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.FlyingSnakeBanner);
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(thorium.ItemType("Spearmint"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.BoneLeeBanner);
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(thorium.ItemType("TechniqueShadowClone"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.SnowmanGangstaBanner);
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(thorium.ItemType("TommyGun"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.RavagerScorpionBanner);
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(thorium.ItemType("EbonyTail"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.BoneSerpentBanner);
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(thorium.ItemType("SpineBreaker"));
                recipe.AddRecipe();
            }

            #endregion

            #region calamity banner recipes

            if (calamityLoaded)
            {
                Mod calamity = ModLoader.GetMod("CalamityMod");

                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.PirateCrossbowerBanner, 4);
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(calamity.ItemType("Arbalest"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.PirateCrossbowerBanner);
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(calamity.ItemType("RaidersGlory"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.TacticalSkeletonBanner, 4);
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(calamity.ItemType("TrueConferenceCall"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.DesertBasiliskBanner, 4);
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(calamity.ItemType("EvilSmasher"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.TortoiseBanner, 4);
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(calamity.ItemType("FabledTortoiseShell"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.DungeonSpiritBanner, 4);
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(calamity.ItemType("PearlGod"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.PossessedArmorBanner, 4);
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(calamity.ItemType("PsychoticAmulet"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.IchorStickerBanner, 4);
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(calamity.ItemType("SpearofDestiny"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.IchorStickerBanner);
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(calamity.ItemType("IchorSpear"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.MimicBanner, 2);
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(calamity.ItemType("TheBee"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.HarpyBanner, 2);
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(calamity.ItemType("SkyGlaze"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.DemonBanner);
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(calamity.ItemType("BladecrestOathsword"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.SkeletonMageBanner);
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(calamity.ItemType("AncientShiv"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.ClingerBanner);
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(calamity.ItemType("CursedDagger"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.GoblinSorcererBanner);
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(calamity.ItemType("PlasmaRod"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.PirateDeadeyeBanner);
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(calamity.ItemType("ProporsePistol"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.GoblinWarriorBanner);
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(calamity.ItemType("Warblade"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.NecromancerBanner);
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(calamity.ItemType("WrathoftheAncients"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.FlyingAntlionBanner);
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(calamity.ItemType("MandibleBow"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.WalkingAntlionBanner);
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(calamity.ItemType("MandibleClaws"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.SkeletonBanner);
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(calamity.ItemType("Waraxe"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.TombCrawlerBanner);
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(calamity.ItemType("BurntSienna"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.SharkBanner);
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(calamity.ItemType("DepthBlade"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.BoneSerpentBanner);
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(calamity.ItemType("OldLordOathsword"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.RuneWizardBanner);
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(calamity.ItemType("EyeofMagnus"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(calamity.ItemType("ArmoredDiggerBanner"));
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(calamity.ItemType("LeadWizard"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(calamity.ItemType("IceClasperBanner"));
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(calamity.ItemType("FrostBarrier"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(calamity.ItemType("ImpiousImmolatorBanner"));
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(calamity.ItemType("EnergyStaff"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(calamity.ItemType("EidolonWyrmJuvenileBanner"), 200);
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(calamity.ItemType("HalibutCannon"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(calamity.ItemType("CuttlefishBanner"));
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(calamity.ItemType("InkBomb"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(calamity.ItemType("CnidrionBanner"), 2);
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(calamity.ItemType("TheTransformer"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(calamity.ItemType("CrystalCrawlerBanner"));
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(calamity.ItemType("CrystalBlade"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(calamity.ItemType("IrradiatedSlimeBanner"));
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(calamity.ItemType("LeadCore"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(calamity.ItemType("TrasherBanner"));
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(calamity.ItemType("TrashmanTrashcan"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(calamity.ItemType("AngryDogBanner"), 2);
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(calamity.ItemType("Cryophobia"));
                recipe.AddRecipe();

                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.SandElementalBanner);
                recipe.AddTile(TileID.Solidifier);
                recipe.SetResult(calamity.ItemType("WifeinaBottlewithBoobs"));
                recipe.AddRecipe();
            }

            #endregion
        }

        public override void AddRecipeGroups()
        {
            //evil wood
            RecipeGroup group = new RecipeGroup(() => Lang.misc[37] + " Evil Wood", new int[]
            {
                ItemID.Ebonwood,
                ItemID.Shadewood,
            });
            RecipeGroup.RegisterGroup("Fargowiltas:AnyEvilWood", group);

            //bone banner
            group = new RecipeGroup(() => Lang.misc[37] + " Armored Bones Banner", new int[]
            {
                ItemID.BlueArmoredBonesBanner,
                ItemID.HellArmoredBonesBanner,
                ItemID.RustyArmoredBonesBanner,
            });
            RecipeGroup.RegisterGroup("Fargowiltas:AnyArmoredBones", group);

            //npcs
            group = new RecipeGroup(() => Lang.misc[37] + " Caught Town NPC", new int[]
            {
                ItemType("Guide"),
                ItemType("Abominationn"),
                ItemType("Angler"),
                ItemType("ArmsDealer"),
                ItemType("Clothier"),
                ItemType("Cyborg"),
                ItemType("Demolitionist"),
                ItemType("Deviantt"),
                ItemType("Dryad"),
                ItemType("DyeTrader"),
                ItemType("GoblinTinkerer"),
                ItemType("LumberJack"),
                ItemType("Mechanic"),
                ItemType("Merchant"),
                ItemType("Mutant"),
                ItemType("Nurse"),
                ItemType("Painter"),
                ItemType("PartyGirl"),
                ItemType("Pirate"),
                ItemType("SantaClaus"),
                ItemType("SkeletonMerchant"),
                ItemType("Steampunker"),
                ItemType("Stylist"),
                ItemType("Tavernkeep"),
                ItemType("TaxCollector"),
                ItemType("TravellingMerchant"),
                ItemType("Truffle"),
                ItemType("WitchDoctor"),
                ItemType("Wizard"),
            });
            RecipeGroup.RegisterGroup("Fargowiltas:AnyCaughtNPC", group);
        }

        public override void HandlePacket(BinaryReader reader, int whoAmI)
        {
            byte boi = reader.ReadByte();

            switch (boi)
            {
                case 1: //regal statue
                    FargoWorld.ReceiveCurrentSpawnRateTile(reader, whoAmI);
                    break;

                case 2: //abom clear events
                    if (Main.netMode == 2)
                    {
                        bool eventOccurring = false;
                        if (ClearEvents(ref eventOccurring))
                        {
                            NetMessage.SendData(7);
                            NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("The event has been cancelled!"), new Color(175, 75, 255));
                        }
                    }
                    break;

                case 3: //angler reset
                    if (Main.netMode == 2)
                        Main.AnglerQuestSwap();
                    break;

                case 4: //spawn deviantt items
                    if (Main.netMode == 2)
                    {
                        Player p = Main.player[reader.ReadByte()];
                        Item.NewItem(p.Center, ItemID.SilverPickaxe);
                        Item.NewItem(p.Center, ItemID.SilverAxe);
                        Item.NewItem(p.Center, ItemID.HermesBoots);
                        Item.NewItem(p.Center, ItemID.LifeCrystal, 4);
                    }
                    break;

                default:
                    break;
            }

        }

        public static bool ClearEvents(ref bool eventOccurring)
        {
            bool canClearEvent = FargoWorld.AbomClearCD <= 0;
            if (Main.invasionType != 0)
            {
                eventOccurring = true;
                if (canClearEvent)
                    Main.invasionType = 0;
            }
            if (Main.pumpkinMoon)
            {
                eventOccurring = true;
                if (canClearEvent)
                    Main.pumpkinMoon = false;
            }
            if (Main.snowMoon)
            {
                eventOccurring = true;
                if (canClearEvent)
                    Main.snowMoon = false;
            }
            if (Main.eclipse)
            {
                eventOccurring = true;
                if (canClearEvent)
                    Main.eclipse = false;
            }
            if (Main.bloodMoon)
            {
                eventOccurring = true;
                if (canClearEvent)
                    Main.bloodMoon = false;
            }
            if (Main.raining)
            {
                eventOccurring = true;
                if (canClearEvent)
                    Main.raining = false;
            }
            if (Main.slimeRain)
            {
                eventOccurring = true;
                if (canClearEvent)
                {
                    Main.StopSlimeRain();
                    Main.slimeWarningDelay = 1;
                    Main.slimeWarningTime = 1;
                }
            }
            if (BirthdayParty.PartyIsUp)
            {
                eventOccurring = true;
                if (canClearEvent)
                    BirthdayParty.WorldClear();
            }
            if (DD2Event.Ongoing)
            {
                eventOccurring = true;
                if (canClearEvent)
                    DD2Event.StopInvasion();
            }
            if (Sandstorm.Happening)
            {
                eventOccurring = true;
                if (canClearEvent)
                {
                    Sandstorm.Happening = false;
                    Sandstorm.TimeLeft = 0;
                }
            }
            if (NPC.LunarApocalypseIsUp)
            {
                eventOccurring = true;
                if (canClearEvent)
                {
                    NPC.LunarApocalypseIsUp = false;
                    NPC.ShieldStrengthTowerNebula = 0;
                    NPC.ShieldStrengthTowerSolar = 0;
                    NPC.ShieldStrengthTowerStardust = 0;
                    NPC.ShieldStrengthTowerVortex = 0;
                    for (int i = 0; i < Main.maxNPCs; i++) //purge all towers
                        if (Main.npc[i].active
                            && (Main.npc[i].type == NPCID.LunarTowerNebula || Main.npc[i].type == NPCID.LunarTowerSolar
                            || Main.npc[i].type == NPCID.LunarTowerStardust || Main.npc[i].type == NPCID.LunarTowerVortex))
                        {
                            Main.npc[i].dontTakeDamage = false;
                            Main.npc[i].GetGlobalNPC<FargoGlobalNPC>().noLoot = true;
                            Main.npc[i].StrikeNPCNoInteraction(int.MaxValue, 0f, 0);
                        }
                }
            }
            if (eventOccurring && canClearEvent)
                FargoWorld.AbomClearCD = 7200;
            return eventOccurring && canClearEvent;
        }

        #region Boss Summon Method (Thanks Grox)
        public static void SpawnBoss(Player player, string type, bool spawnMessage = true, int overrideDirection = 0, int overrideDirectionY = 0, string overrideDisplayName = "", bool namePlural = false)
        {
            Mod mod = Fargowiltas.instance;
            SpawnBoss(player, mod.NPCType(type), spawnMessage, overrideDirection, overrideDirectionY, overrideDisplayName, namePlural);
        }

        // SpawnBoss(player, mod.NPCType("MyBoss"), true, 0, 0, "DerpyBoi 2", false);
        public static void SpawnBoss(Player player, int bossType, bool spawnMessage = true, int overrideDirection = 0, int overrideDirectionY = 0, string overrideDisplayName = "", bool namePlural = false)
        {
            if (overrideDirection == 0)
                overrideDirection = (Main.rand.Next(2) == 0 ? -1 : 1);
            if (overrideDirectionY == 0)
                overrideDirectionY = -1;
            Vector2 npcCenter = player.Center + new Vector2(MathHelper.Lerp(500f, 800f, (float)Main.rand.NextDouble()) * overrideDirection, 800f * overrideDirectionY);
            SpawnBoss(player, bossType, spawnMessage, npcCenter, overrideDisplayName, namePlural);
        }

        // SpawnBoss(player, "MyBoss", true, player.Center + new Vector2(0, -800f), "DerpFromAbove", false);
        public static void SpawnBoss(Player player, string type, bool spawnMessage = true, Vector2 npcCenter = default(Vector2), string overrideDisplayName = "", bool namePlural = false)
        {
            Mod mod = Fargowiltas.instance;
            SpawnBoss(player, mod.NPCType(type), spawnMessage, npcCenter, overrideDisplayName, namePlural);
        }

        // SpawnBoss(player, mod.NPCType("MyBoss"), true, player.Center + new Vector2(0, 800f), "DerpFromBelow", false);
        public static int SpawnBoss(Player player, int bossType, bool spawnMessage = true, Vector2 npcCenter = default(Vector2), string overrideDisplayName = "", bool namePlural = false)
        {
            if (npcCenter == default(Vector2))
                npcCenter = player.Center;
            if (Main.netMode != 1)
            {
                int npcID = NPC.NewNPC((int)npcCenter.X, (int)npcCenter.Y, bossType, 0);
                Main.npc[npcID].Center = npcCenter;
                Main.npc[npcID].netUpdate2 = true;
                if (spawnMessage)
                {
                    string npcName = (!String.IsNullOrEmpty(Main.npc[npcID].GivenName) ? Main.npc[npcID].GivenName : overrideDisplayName);
                    if ((npcName == null || npcName.Equals("")) && Main.npc[npcID].modNPC != null)
                        npcName = Main.npc[npcID].modNPC.DisplayName.GetDefault();
                    if (namePlural)
                    {
                        if (Main.netMode == 0) { Main.NewText(npcName + " have awoken!", 175, 75, 255, false); }
                        else
                        if (Main.netMode == 2)
                        {
                            NetMessage.BroadcastChatMessage(NetworkText.FromLiteral(npcName + " have awoken!"), new Color(175, 75, 255), -1);
                        }
                    }
                    else
                    {
                        if (Main.netMode == 0) { Main.NewText(Language.GetTextValue("Announcement.HasAwoken", npcName), 175, 75, 255, false); }
                        else
                        if (Main.netMode == 2)
                        {
                            NetMessage.BroadcastChatMessage(NetworkText.FromKey("Announcement.HasAwoken", new object[]
                            {
                            NetworkText.FromLiteral(npcName)
                            }), new Color(175, 75, 255), -1);
                        }
                    }
                }
            }
            else
            {
                //I have no idea how to convert this to the standard system so im gonna post this method too lol
                FargoNet.SendNetMessage(FargoNet.SummonNPCFromClient, (byte)player.whoAmI, (short)bossType, spawnMessage, npcCenter.X, npcCenter.Y, overrideDisplayName, namePlural);
            }
            return 200;
        }
        #endregion
    }

    /*public static class FargoExtentions
    {
        public const byte SummonNPCFromClient = 0;
        public static bool ReadBool(this BinaryReader w) { return w.ReadBoolean(); }
        public static int ReadInt(this BinaryReader w) { return w.ReadInt32(); }
        public static short ReadShort(this BinaryReader w) { return w.ReadInt16(); }
        public static float ReadFloat(this BinaryReader w) { return w.ReadSingle(); }
    }*/

    public class FargoNet
    {
        public static bool DEBUG = true;

        public static void SendData(int dataType, int dataA, int dataB, string text, int playerID, float dataC, float dataD, float dataE, int clientType)
        {
            NetMessage.SendData(dataType, dataA, dataB, NetworkText.FromLiteral(text), playerID, dataC, dataD, dataE, clientType);
        }

        public static ModPacket WriteToPacket(ModPacket packet, byte msg, params object[] param)
        {
            packet.Write((byte)msg);
            for (int m = 0; m < param.Length; m++)
            {
                object obj = param[m];

                if (obj is byte[])
                {
                    byte[] array = (byte[])obj;
                    foreach (byte b in array) packet.Write((byte)b);
                }
                else
                if (obj is bool) packet.Write((bool)obj);
                else
                if (obj is byte) packet.Write((byte)obj);
                else
                if (obj is short) packet.Write((short)obj);
                else
                if (obj is int) packet.Write((int)obj);
                else
                if (obj is float) packet.Write((float)obj);
            }
            return packet;
        }

        public static void SyncAI(Entity codable, float[] ai, int aitype)
        {
            int entType = (codable is NPC ? 0 : codable is Projectile ? 1 : -1);
            if (entType == -1) { return; }
            int id = (codable is NPC ? ((NPC)codable).whoAmI : ((Projectile)codable).identity);
            SyncAI(entType, id, ai, aitype);
        }

        /*
         * Used to sync custom ai float arrays. (the npc or projectile requires a method called 'public void SetAI(float[] ai, int type)' that sets the ai for this to work)
         */
        public static void SyncAI(int entType, int id, float[] ai, int aitype)
        {
            object[] ai2 = new object[ai.Length + 4];
            ai2[0] = (byte)entType;
            ai2[1] = (short)id;
            ai2[2] = (byte)aitype;
            ai2[3] = (byte)ai.Length;
            for (int m = 4; m < ai2.Length; m++) { ai2[m] = ai[m - 4]; }
            SendFargoNetMessage(1, ai2);
        }

        /*
         * Writes a vector2 array to an obj[] array that can be sent via netmessaging.
         */
        public static object[] WriteVector2Array(Vector2[] array)
        {
            System.Collections.Generic.List<object> list = new System.Collections.Generic.List<object>();
            list.Add(array.Length);
            foreach (Vector2 vec in array)
            {
                list.Add(vec.X); list.Add(vec.Y);
            }
            return list.ToArray();
        }

        /*
         * Writes a vector2 array to a binary writer.
         */
        public static void WriteVector2Array(Vector2[] array, BinaryWriter writer)
        {
            writer.Write(array.Length);
            foreach (Vector2 vec in array)
            {
                writer.Write(vec.X); writer.Write(vec.Y);
            }
        }

        /*
         * Reads a vector2 array from a binary reader.
         */
        public static Vector2[] ReadVector2Array(BinaryReader reader)
        {
            int arrayLength = reader.ReadInt32();
            Vector2[] array = new Vector2[arrayLength];
            for (int m = 0; m < arrayLength; m++)
            {
                array[m] = new Vector2(reader.ReadSingle(), reader.ReadSingle());
            }
            return array;
        }

        public static void SendFargoNetMessage(int msg, params object[] param)
        {
            if (Main.netMode == 0) { return; } //nothing to sync in SP
            WriteToPacket(Fargowiltas.instance.GetPacket(), (byte)msg, param).Send();
        }

        public const byte SummonNPCFromClient = 0;

        public static void HandlePacket(BinaryReader bb, int whoAmI)
        {
            byte msg = bb.ReadByte();
            if (DEBUG) ErrorLogger.Log((Main.netMode == 2 ? "--SERVER-- " : "--CLIENT-- ") + "HANDING MESSAGE: " + msg);
            try
            {
                if (msg == SummonNPCFromClient)
                {
                    if (Main.netMode == 2)
                    {
                        int playerID = (int)bb.ReadByte();
                        int bossType = bb.ReadInt16();
                        bool spawnMessage = bb.ReadBoolean();
                        int npcCenterX = bb.ReadInt32();
                        int npcCenterY = bb.ReadInt32();
                        string overrideDisplayName = bb.ReadString();
                        bool namePlural = bb.ReadBoolean();

                        Fargowiltas.SpawnBoss(Main.player[playerID], bossType, spawnMessage, new Vector2(npcCenterX, npcCenterY), overrideDisplayName, namePlural);
                    }
                }
            }
            catch (Exception e) { ErrorLogger.Log((Main.netMode == 2 ? "--SERVER-- " : "--CLIENT-- ") + "ERROR HANDLING MSG: " + msg.ToString() + ": " + e.Message); ErrorLogger.Log(e.StackTrace); ErrorLogger.Log("-------"); }
        }

        public static void SyncPlayer(int toWho, int fromWho, bool newPlayer)
        {
            if (DEBUG) ErrorLogger.Log((Main.netMode == 2 ? "--SERVER-- " : "--CLIENT-- ") + "SYNC PLAYER CALLED! NEWPLAYER: " + newPlayer + ". TOWHO: " + toWho + ". FROMWHO:" + fromWho);
            if (Main.netMode == 2 && (toWho > -1 || fromWho > -1))
            {
                PlayerConnected(toWho == -1 ? fromWho : toWho);
            }
        }

        public static void PlayerConnected(int playerID)
        {
            if (DEBUG) ErrorLogger.Log("--SERVER-- PLAYER JOINED!");
        }

        public static void SendNetMessage(int msg, params object[] param)
        {
            SendNetMessageClient(msg, -1, param);
        }

        public static void SendNetMessageClient(int msg, int client, params object[] param)
        {
            try
            {
                if (Main.netMode == 0) { return; }

                WriteToPacket(Fargowiltas.instance.GetPacket(), (byte)msg, param).Send(client);
            }
            catch (Exception e)
            {
                ErrorLogger.Log((Main.netMode == 2 ? "--SERVER-- " : "--CLIENT-- ") + "ERROR SENDING MSG: " + msg.ToString() + ": " + e.Message); ErrorLogger.Log(e.StackTrace); ErrorLogger.Log("-------");
                string param2 = "";
                for (int m = 0; m < param.Length; m++)
                {
                    param2 += param[m];
                }
                ErrorLogger.Log("PARAMS: " + param2);
                ErrorLogger.Log("-------");
            }
        }
    }
}
