using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.UI;
using Terraria.ModLoader;
using Fargowiltas.Items;
using Fargowiltas.NPCs;
using Fargowiltas.Projectiles;
using System.Linq;
using System.Collections.Generic;

namespace Fargowiltas
{
	class Fargowiltas : Mod
	{
		internal static ModHotKey CheckListKey;
		internal soulcheck soulcheck;
		internal soulcheck SoulCheck;
		public UserInterface customResources;
		public UserInterface customRessources;
		//loaded
    	internal bool blueMagicLoaded;
		internal bool calamityLoaded;
		internal bool cookieLoaded;
		internal bool crystiliumLoaded;
		internal bool ersionLoaded;
		internal bool gabeLoaded;
		internal bool grealmLoaded;
		internal bool joostLoaded;
		internal bool nightmaresLoaded;
		internal bool pumpkingLoaded;
		internal bool sacredToolsLoaded;
		internal bool shroomsLoaded;
		internal bool spiritLoaded;
		internal bool terraCompLoaded;
		internal bool thoriumLoaded;
		internal bool tremorLoaded;
		internal bool xervosLoaded;
		internal bool w1kLoaded;
		internal bool waterBiomeLoaded;
		internal bool ancientsLoaded;
		internal bool btfaLoaded;
		//multi summon
		internal bool multiSlime;
		internal static int slime100;
		internal bool multiEye;
		internal static int eye100;
		internal bool multiWorm;
		internal static int worm100;
		internal bool multiBrain;
		internal static int brain100;
		internal bool multiSkele;
		internal static int skele100;
		internal bool multiBee;
		internal static int bee100;
		
		internal bool multiTwins;
		internal static int twins100;
		internal bool multiPrime;
		internal static int prime100;
		internal bool multiDestroy;
		internal static int destroy100;
		
		internal bool multiFish;
		internal static int fish100;
		

		
	
		static internal Fargowiltas instance; 

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
			CheckListKey = RegisterHotKey("Soul Toggles", "L");
			
			if (!Main.dedServ)
            {
			
			customRessources = new UserInterface();
            SoulCheck = new soulcheck();
            soulcheck.visible = false;
            customRessources.SetState(SoulCheck);
			}
        }
		public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
			int MouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
				layers.Insert(MouseTextIndex, new LegacyGameInterfaceLayer(
				"CustomBars: Custom Resource Bar",
				delegate
				{
					if (soulcheck.visible)
					{
						//Update CustomBars
						customRessources.Update(Main._drawInterfaceGameTime);
						SoulCheck.Draw(Main.spriteBatch);
					}
					return true;
				},
				InterfaceScaleType.UI)
				);
        }
		
		//bool sheet
		public override void PostSetupContent()
        {
            try
            {
                blueMagicLoaded = ModLoader.GetMod("Bluemagic") != null;
				calamityLoaded = ModLoader.GetMod("CalamityMod") != null;
				cookieLoaded = ModLoader.GetMod("CookieMod") != null;
				crystiliumLoaded = ModLoader.GetMod("CrystiliumMod") != null;
				ersionLoaded = ModLoader.GetMod("Ersion") != null;
				gabeLoaded = ModLoader.GetMod("GabeHasWonsMod") != null;
				grealmLoaded = ModLoader.GetMod("GRealm") != null;
				joostLoaded = ModLoader.GetMod("JoostMod") != null;
				nightmaresLoaded = ModLoader.GetMod("TrueEater") != null;
				pumpkingLoaded = ModLoader.GetMod("Pumpking") != null;
				sacredToolsLoaded = ModLoader.GetMod("SacredTools") != null;
				shroomsLoaded = ModLoader.GetMod("Shrooms") != null;
				spiritLoaded = ModLoader.GetMod("SpiritMod") != null;
				terraCompLoaded = ModLoader.GetMod("TerraCompilation") != null;
				thoriumLoaded = ModLoader.GetMod("ThoriumMod") != null;
				tremorLoaded = ModLoader.GetMod("Tremor") != null;
				xervosLoaded = ModLoader.GetMod("XervosMod") != null;
				w1kLoaded = ModLoader.GetMod("W1KModRedux") != null;
				waterBiomeLoaded = ModLoader.GetMod("WaterBiomeMod") != null;
				ancientsLoaded = ModLoader.GetMod("EchoesoftheAncients") != null;
				btfaLoaded = ModLoader.GetMod("ForgottenMemories") != null;
				
				//multi summons
				multiSlime = false;
				slime100 = 0;
				multiEye = false;
				eye100 = 0;
				multiWorm = false;
				worm100 = 0;
				multiBrain = false;
				brain100 = 0;
				multiSkele = false;
				skele100 = 0;
				multiBee = false;
				bee100 = 0;
				
				multiTwins = false;
				twins100 = 0;
				multiPrime = false;
				prime100 = 0;
				multiDestroy = false;
				destroy100 = 0;
				
				multiFish = false;
				fish100 = 0;
				
				
				
            }
            catch (Exception e)
            {
                ErrorLogger.Log("Fargowiltas PostSetupContent Error: " + e.StackTrace + e.Message);
            }
			
        }
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(this);
			recipe.AddIngredient(null, "BananarangThrown");
	        recipe.SetResult(ItemID.Bananarang);
	        recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(null, "BloodyMacheteThrown");
	        recipe.SetResult(ItemID.BloodyMachete);
	        recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(null, "DaybreakThrown");
	        recipe.SetResult(ItemID.DayBreak);
	        recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(null, "EnchantedBoomerangThrown");
	        recipe.SetResult(ItemID.EnchantedBoomerang);
	        recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(null, "FlamarangThrown");
	        recipe.SetResult(ItemID.Flamarang);
	        recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(null, "FruitcakeChakramThrown");
	        recipe.SetResult(ItemID.FruitcakeChakram);
	        recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(null, "IceBoomerangThrown");
	        recipe.SetResult(ItemID.IceBoomerang);
	        recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(null, "LightDiscThrown");
	        recipe.SetResult(ItemID.LightDisc);
	        recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(null, "MagicDaggerThrown");
	        recipe.SetResult(ItemID.MagicDagger);
	        recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(null, "PaladinsHammerThrown");
	        recipe.SetResult(ItemID.PaladinsHammer);
	        recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(null, "PossessedHatchetThrown");
	        recipe.SetResult(ItemID.PossessedHatchet);
	        recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(null, "ShadowflameKnifeThrown");
	        recipe.SetResult(ItemID.ShadowFlameKnife);
	        recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(null, "ThornChakramThrown");
	        recipe.SetResult(ItemID.ThornChakram);
	        recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(null, "VampireKnivesThrown");
	        recipe.SetResult(ItemID.VampireKnives);
	        recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(null, "WoodenBoomerangThrown");
	        recipe.SetResult(ItemID.WoodenBoomerang);
	        recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(null, "ToxicFlaskThrown");
	        recipe.SetResult(ItemID.ToxicFlask);
	        recipe.AddRecipe();
	
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
			recipe.AddIngredient(ItemID.CopperPickaxe);
			recipe.AddIngredient(ItemID.WoodenHammer);
			recipe.AddIngredient(ItemID.Wrench);
			recipe.AddIngredient(ItemID.WireCutter);
			recipe.AddIngredient(ItemID.EmptyBucket);
			recipe.AddTile(TileID.Anvils);
	        recipe.SetResult(ItemID.Toolbox);
	        recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.Pumpkin, 500);
			recipe.AddTile(TileID.LivingLoom);
	        recipe.SetResult(ItemID.MagicalPumpkinSeed);
	        recipe.AddRecipe();
			
			
			
		}
		
		public override void AddRecipeGroups()
        {
			//drax
			RecipeGroup group = new RecipeGroup(() => Lang.misc[37] + " Drax" , new int[]
            {
                ItemID.Drax, 
                ItemID.PickaxeAxe, 
            });
            RecipeGroup.RegisterGroup("Fargowiltas:AnyDrax", group);
			
			if(Fargowiltas.instance.terraCompLoaded)
			{
				//cobalt
				group = new RecipeGroup(() => Lang.misc[37] + " Cobalt Repeater" , new int[]
				{
                ItemID.CobaltRepeater,
                ItemID.PalladiumRepeater,
				ModLoader.GetMod("TerraCompilation").ItemType("CobaltComp"),	
				ModLoader.GetMod("TerraCompilation").ItemType("PaladiumComp"),	
				
				});
				RecipeGroup.RegisterGroup("Fargowiltas:AnyCobaltRepeater", group);
			
				//mythril
				group = new RecipeGroup(() => Lang.misc[37] + " Mythril Repeater" , new int[]
				{
                ItemID.MythrilRepeater,
                ItemID.OrichalcumRepeater,
				ModLoader.GetMod("TerraCompilation").ItemType("MythrilComp"),	
				ModLoader.GetMod("TerraCompilation").ItemType("OrichalcumComp"),	
				});
				RecipeGroup.RegisterGroup("Fargowiltas:AnyMythrilRepeater", group);
			
				//adamantite
				group = new RecipeGroup(() => Lang.misc[37] + " Adamantite Repeater" , new int[]
				{
                ItemID.AdamantiteRepeater,
                ItemID.TitaniumRepeater,
				ModLoader.GetMod("TerraCompilation").ItemType("AdamantiteComp"),	
				ModLoader.GetMod("TerraCompilation").ItemType("TitaniumComp"),	
				
				});
				RecipeGroup.RegisterGroup("Fargowiltas:AnyAdamantiteRepeater", group);
			}
			
		else
		{
		
			//cobalt
			group = new RecipeGroup(() => Lang.misc[37] + " Cobalt Repeater" , new int[]
            {
                ItemID.CobaltRepeater,
                ItemID.PalladiumRepeater,
            });
            RecipeGroup.RegisterGroup("Fargowiltas:AnyCobaltRepeater", group);
			
			//mythril
			group = new RecipeGroup(() => Lang.misc[37] + " Mythril Repeater" , new int[]
            {
                ItemID.MythrilRepeater,
                ItemID.OrichalcumRepeater,				
           });
            RecipeGroup.RegisterGroup("Fargowiltas:AnyMythrilRepeater", group);
			
			//adamantite
			group = new RecipeGroup(() => Lang.misc[37] + " Adamantite Repeater" , new int[]
            {
                ItemID.AdamantiteRepeater,
                ItemID.TitaniumRepeater,				
            });
            RecipeGroup.RegisterGroup("Fargowiltas:AnyAdamantiteRepeater", group);
		}
			
			//evil chest
			group = new RecipeGroup(() => Lang.misc[37] + " Evil Chest" , new int[]
            {
                ItemID.VampireKnives,
				ItemType("VampireKnivesThrown"),
                ItemID.ScourgeoftheCorruptor,
            });
            RecipeGroup.RegisterGroup("Fargowiltas:AnyEvilChest", group);
			
			//evil wood
			group = new RecipeGroup(() => Lang.misc[37] + " Evil Wood" , new int[]
            {
                ItemID.Ebonwood, 
                ItemID.Shadewood, 
            });
            RecipeGroup.RegisterGroup("Fargowiltas:AnyEvilWood", group);
			
			//evilfishing
			group = new RecipeGroup(() => Lang.misc[37] + " Evil Fished Weapon" , new int[]
            {
                ItemID.Toxikarp, 
                ItemID.Bladetongue, 
            });
            RecipeGroup.RegisterGroup("Fargowiltas:AnyEvilFished", group);
			
			//evilbow
			group = new RecipeGroup(() => Lang.misc[37] + " Evil Bow" , new int[]
            {
                ItemID.DemonBow, 
                ItemID.TendonBow, 
            });
            RecipeGroup.RegisterGroup("Fargowiltas:AnyEvilBow", group);
			
			//evilgun
			group = new RecipeGroup(() => Lang.misc[37] + " Evil Gun" , new int[]
            {
                ItemID.Musket, 
                ItemID.TheUndertaker, 
            });
            RecipeGroup.RegisterGroup("Fargowiltas:AnyEvilGun", group);
			
			//silverstaff
			group = new RecipeGroup(() => Lang.misc[37] + " Silver Staff" , new int[]
            {
                ItemID.SapphireStaff, 
                ItemID.EmeraldStaff, 
            });
            RecipeGroup.RegisterGroup("Fargowiltas:AnySilverStaff", group);
			
			//goldstaff
			group = new RecipeGroup(() => Lang.misc[37] + " Gold Staff" , new int[]
            {
                ItemID.RubyStaff, 
                ItemID.DiamondStaff, 
            });
            RecipeGroup.RegisterGroup("Fargowiltas:AnyGoldStaff", group);
			
			//evilmagic
			group = new RecipeGroup(() => Lang.misc[37] + " Evil Magic Weapon" , new int[]
            {
                ItemID.Vilethorn, 
                ItemID.CrimsonRod, 
            });
            RecipeGroup.RegisterGroup("Fargowiltas:AnyEvilMagic", group);
			
			//expertevil
			group = new RecipeGroup(() => Lang.misc[37] + " Evil Expert Drop" , new int[]
            {
                ItemID.WormScarf, 
                ItemID.BrainOfConfusion, 
            });
            RecipeGroup.RegisterGroup("Fargowiltas:AnyEvilExpert", group);
			
			//evilmimic acc
			group = new RecipeGroup(() => Lang.misc[37] + " Evil Mimic Accessory" , new int[]
            {
                ItemID.FleshKnuckles, 
                ItemID.PutridScent, 
            });
            RecipeGroup.RegisterGroup("Fargowiltas:AnyEvilMimic", group);
			
			//tier 1 sentry
			group = new RecipeGroup(() => Lang.misc[37] + " Tier 1 Sentry" , new int[]
            {
				ItemID.DD2LightningAuraT1Popper,
				ItemID.DD2FlameburstTowerT1Popper,
				ItemID.DD2ExplosiveTrapT1Popper,
				ItemID.DD2BallistraTowerT1Popper,
            });
            RecipeGroup.RegisterGroup("Fargowiltas:AnySentry1", group);
			
			//tier 3 sentry
			group = new RecipeGroup(() => Lang.misc[37] + " Tier 3 Sentry" , new int[]
            {
				ItemID.DD2LightningAuraT3Popper,
				ItemID.DD2FlameburstTowerT3Popper,
				ItemID.DD2ExplosiveTrapT3Popper,
				ItemID.DD2BallistraTowerT3Popper,
            });
            RecipeGroup.RegisterGroup("Fargowiltas:AnySentry", group);
			
			//anvil HM
			group = new RecipeGroup(() => Lang.misc[37] + " Mythril Anvil" , new int[]
            {
				ItemID.MythrilAnvil,
				ItemID.OrichalcumAnvil,
            });
            RecipeGroup.RegisterGroup("Fargowiltas:AnyAnvil", group);
			
			//forge HM
			group = new RecipeGroup(() => Lang.misc[37] + " Adamantite Forge" , new int[]
            {
				ItemID.AdamantiteForge,
				ItemID.TitaniumForge,
            });
            RecipeGroup.RegisterGroup("Fargowiltas:AnyForge", group);
			
			//any adamantite
			group = new RecipeGroup(() => Lang.misc[37] + " Adamantite Bar" , new int[]
            {
				ItemID.AdamantiteBar,
				ItemID.TitaniumBar,
            });
            RecipeGroup.RegisterGroup("Fargowiltas:AnyAdamantite", group);
			
			//shroomite head
			group = new RecipeGroup(() => Lang.misc[37] + " Shroomite Head Piece" , new int[]
            {
				ItemID.ShroomiteHeadgear,
				ItemID.ShroomiteMask,
				ItemID.ShroomiteHelmet,
            });
            RecipeGroup.RegisterGroup("Fargowiltas:AnyShroomHead", group);
			
			//orichalcum head
			group = new RecipeGroup(() => Lang.misc[37] + " Orichalcum Head Piece" , new int[]
            {
				ItemID.OrichalcumHeadgear,
				ItemID.OrichalcumMask,
				ItemID.OrichalcumHelmet,
            });
            RecipeGroup.RegisterGroup("Fargowiltas:AnyOriHead", group);
			
			//palladium head
			group = new RecipeGroup(() => Lang.misc[37] + " Palladium Head Piece" , new int[]
            {
				ItemID.PalladiumHeadgear,
				ItemID.PalladiumMask,
				ItemID.PalladiumHelmet,
            });
            RecipeGroup.RegisterGroup("Fargowiltas:AnyPallaHead", group);
			
			//cobalt head
			group = new RecipeGroup(() => Lang.misc[37] + " Cobalt Head Piece" , new int[]
            {
				ItemID.CobaltHelmet,
				ItemID.CobaltHat,
				ItemID.CobaltMask,
            });
            RecipeGroup.RegisterGroup("Fargowiltas:AnyCobaltHead", group);
			
			//mythril head
			group = new RecipeGroup(() => Lang.misc[37] + " Mythril Head Piece" , new int[]
            {
				ItemID.MythrilHat,
				ItemID.MythrilHelmet,
				ItemID.MythrilHood,
            });
            RecipeGroup.RegisterGroup("Fargowiltas:AnyMythrilHead", group);
			
			//titanium head
			group = new RecipeGroup(() => Lang.misc[37] + " Titanium Head Piece" , new int[]
            {
				ItemID.TitaniumHeadgear,
				ItemID.TitaniumMask,
				ItemID.TitaniumHelmet,
            });
            RecipeGroup.RegisterGroup("Fargowiltas:AnyTitaHead", group);
			
			//hallowed head
			group = new RecipeGroup(() => Lang.misc[37] + " Hallowed Head Piece" , new int[]
            {
				ItemID.HallowedMask,
				ItemID.HallowedHeadgear,
				ItemID.HallowedHelmet,
            });
            RecipeGroup.RegisterGroup("Fargowiltas:AnyHallowHead", group);
			
			//adamantite head
			group = new RecipeGroup(() => Lang.misc[37] + " Adamantite Head Piece" , new int[]
            {
				ItemID.AdamantiteHelmet,
				ItemID.AdamantiteMask,
				ItemID.AdamantiteHeadgear,
				
            });
            RecipeGroup.RegisterGroup("Fargowiltas:AnyAdamHead", group);
			
			//chloro head
			group = new RecipeGroup(() => Lang.misc[37] + " Chlorophyte Head Piece" , new int[]
            {
				ItemID.ChlorophyteMask,
				ItemID.ChlorophyteHelmet,
				ItemID.ChlorophyteHeadgear,
				
            });
            RecipeGroup.RegisterGroup("Fargowiltas:AnyChloroHead", group);
			
			//spectre head
			group = new RecipeGroup(() => Lang.misc[37] + " Spectre Head Piece" , new int[]
            {
				ItemID.SpectreHood,
				ItemID.SpectreMask,
				
            });
            RecipeGroup.RegisterGroup("Fargowiltas:AnySpectreHead", group);
			
			//book cases
			group = new RecipeGroup(() => Lang.misc[37] + " Wooden Bookcase" , new int[]
            {
				ItemID.Bookcase,
				ItemID.EbonwoodBookcase,
				ItemID.RichMahoganyBookcase,
				ItemID.LivingWoodBookcase,
				ItemID.ShadewoodBookcase,
				ItemID.PalmWoodBookcase,
				ItemID.BorealWoodBookcase,
            });
            RecipeGroup.RegisterGroup("Fargowiltas:AnyBookcase", group);
			
			//beetle body
			group = new RecipeGroup(() => Lang.misc[37] + " Beetle Body" , new int[]
            {
				ItemID.BeetleShell,
				ItemID.BeetleScaleMail,
				
            });
            RecipeGroup.RegisterGroup("Fargowiltas:AnyBeetle", group);
			
			//phasesabers
			group = new RecipeGroup(() => Lang.misc[37] + " Phasesaber" , new int[]
            {
				ItemID.RedPhasesaber,
				ItemID.BluePhasesaber,
				ItemID.GreenPhasesaber,
				ItemID.PurplePhasesaber,
				ItemID.WhitePhasesaber,
				ItemID.YellowPhasesaber,
				
            });
            RecipeGroup.RegisterGroup("Fargowiltas:AnyPhasesaber", group);
			
        }
		
		public static bool NoInvasion(NPCSpawnInfo spawnInfo)
		{
			return !spawnInfo.invasion && ((!Main.pumpkinMoon && !Main.snowMoon) || spawnInfo.spawnTileY > Main.worldSurface || Main.dayTime) && (!Main.eclipse || spawnInfo.spawnTileY > Main.worldSurface || !Main.dayTime);
		}

		public static bool NormalSpawn(NPCSpawnInfo spawnInfo)
		{
			return !spawnInfo.playerInTown && NoInvasion(spawnInfo);
		}
		
		public static bool NoBiome(NPCSpawnInfo spawnInfo)
		{
			Player player = spawnInfo.player;
			return !player.ZoneJungle && !player.ZoneDungeon && !player.ZoneCorrupt && !player.ZoneCrimson && !player.ZoneHoly && !player.ZoneSnow && !player.ZoneUndergroundDesert;
		}
		
	}
}
