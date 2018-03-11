<<<<<<< HEAD
using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Events;
using System.Linq;
using Fargowiltas.NPCs;
using Fargowiltas;

namespace Fargowiltas.NPCs
{
	[AutoloadHead]
	public class Mutant : ModNPC
	{
		public override string Texture
		{
			get
			{
				return "Fargowiltas/NPCs/Mutant";
			}
		}	
		public static bool shop1 = false;
		public static bool shop2 = false;
		public static bool shop3 = false;
		
		public static int shopnum = 1;
	
		public override bool Autoload(ref string name)
		{
			name = "Mutant";
			return mod.Properties.Autoload;
		}
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mutant");
			Main.npcFrameCount[npc.type] = 25;
			NPCID.Sets.ExtraFramesCount[npc.type] = 9;
			NPCID.Sets.AttackFrameCount[npc.type] = 4;
			NPCID.Sets.DangerDetectRange[npc.type] = 700;
			NPCID.Sets.AttackType[npc.type] = 0;
			NPCID.Sets.AttackTime[npc.type] = 90;
			NPCID.Sets.AttackAverageChance[npc.type] = 30;
		}
		public override void SetDefaults()
		{
			npc.townNPC = true;
			npc.friendly = true;
			npc.width = 18;
			npc.height = 40;
			npc.aiStyle = 7;
			npc.damage = 10;
			
			
			if (NPC.downedMoonlord)
			{
				npc.defense = 50;
			}
			else
			{
				npc.defense = 15;
			}
			
			
			if (NPC.downedMoonlord)
			{
				npc.lifeMax = 5000;
			}
			else
			{
				npc.lifeMax = 250;
			}
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.knockBackResist = 0.5f;
			animationType = NPCID.Guide;
			
			Main.npcCatchable[npc.type] = true;
            npc.catchItem = (short)mod.ItemType("Masochist");
		}

		//thorium bools
		public bool ThoriumModDownedThunderBird
		{
			 get { return ThoriumMod.ThoriumWorld.downedThunderBird; }
		}
		
		public bool ThoriumModDownedJelly
		{
			get { return ThoriumMod.ThoriumWorld.downedJelly; }
		}
		
		public bool ThoriumModDownedStorm
		{
			get { return ThoriumMod.ThoriumWorld.downedStorm; }
		}
		
		public bool ThoriumModDownedChampion
		{
			get { return ThoriumMod.ThoriumWorld.downedChampion; }
		}
		
			public bool ThoriumModDownedScout
        {
            get { return ThoriumMod.ThoriumWorld.downedScout; }
        }
		
		public bool ThoriumModDownedStrider
		{
			 get { return ThoriumMod.ThoriumWorld.downedStrider; }
		}
		
		public bool ThoriumModDownedFallenBeholder
		{
			get { return ThoriumMod.ThoriumWorld.downedFallenBeholder; }
		}
		
		public bool ThoriumModDownedLich
		{
			get { return ThoriumMod.ThoriumWorld.downedLich; }
		}
		
		public bool ThoriumModDownedAbyssion
		{
			get { return ThoriumMod.ThoriumWorld.downedDepthBoss; }
		}
		
		public bool ThoriumModDownedRealityBreaker
		{
			get { return ThoriumMod.ThoriumWorld.downedRealityBreaker; }
		}
		
		//calamity bools
		public bool CalamityModDownedDesertScourge
		{
			get { return CalamityMod.CalamityWorld.downedDesertScourge; }
		}
		
		public bool CalamityModDownedHiveMind
		{
			get { return CalamityMod.CalamityWorld.downedHiveMind; }
		}
		
		public bool CalamityModDownedPerforator
		{
			get { return CalamityMod.CalamityWorld.downedPerforator; }
		}
		
		public bool CalamityModDownedSlimeGod
		{
			get { return CalamityMod.CalamityWorld.downedSlimeGod; }
		}
		
		public bool CalamityModDownedCryogen
		{
			get { return CalamityMod.CalamityWorld.downedCryogen; }
		}
		
		public bool CalamityModDownedBrimstone
		{
			get { return CalamityMod.CalamityWorld.downedBrimstoneElemental; }
		}
		
		public bool CalamityModDownedCalamitas
		{
			get { return CalamityMod.CalamityWorld.downedCalamitas; }
		}
		
		public bool CalamityModDownedLeviathan
		{
			get { return CalamityMod.CalamityWorld.downedLeviathan; }
		}
		
		public bool CalamityModDownedPlaguebringer
		{
			get { return CalamityMod.CalamityWorld.downedPlaguebringer; }
		}
		
		public bool CalamityModDownedGuardian
		{
			get { return CalamityMod.CalamityWorld.downedGuardians; }
		}

		public bool CalamityModDownedProvidence
		{
			get { return CalamityMod.CalamityWorld.downedProvidence; }
		}
		
		public bool CalamityModDownedDOG
		{
			get { return CalamityMod.CalamityWorld.downedDoG; }
		}
		
		public bool CalamityModDownedYharon
		{
			get { return CalamityMod.CalamityWorld.downedYharon; }
		}
		
		public bool CalamityModDownedSCal
		{
			get { return CalamityMod.CalamityWorld.downedSCal; }
		}
		
		public bool CalamityModDownedRavager
		{
			get { return CalamityMod.CalamityWorld.downedScavenger; }
		}
		
		public bool CalamityModDownedCrab
		{
			get { return CalamityMod.CalamityWorld.downedCrabulon; }
		}
		
		public bool CalamityModDownedAstrum
		{
			get { return CalamityMod.CalamityWorld.downedStarGod; }
		}
		
		public bool CalamityModDownedBirb
		{
			get { return CalamityMod.CalamityWorld.downedBumble; }
		}
		
		public bool CalamityModDownedPolter
		{
			get { return CalamityMod.CalamityWorld.downedPolterghast; }
		}
		
		
		
		//sacred tools bools
		public bool SacredToolsDownedHarpy
		{
			get { return SacredTools.ModdedWorld.downedHarpy; }
		}
		
		public bool SacredToolsDownedRaynare
		{
			get { return SacredTools.ModdedWorld.downedRaynare; }
		}
		
		public bool SacredToolsDownedAbaddon
		{
			get { return SacredTools.ModdedWorld.OblivionSpawns; }
		}
		
		public bool SacredToolsDownedSerpent
		{
			get { return SacredTools.ModdedWorld.FlariumSpawns; }
		}
		
		public bool SacredToolsDownedLunarians
		{
			get { return SacredTools.ModdedWorld.downedLunarians; }
		}
		
		public bool SacredToolsDownedPump
		{
			get { return SacredTools.ModdedWorld.downedPumpboi; }
		}
		
		//gabe has won bools
		public bool GabeModDownedMurk
		{
			get { return GabeHasWonsMod.GabeWorld.downedMurk; }
		}
		
		//grealm bools
		public bool GRealmDownedFolivine
		{
			get { return GRealm.MWorld.downedFolivine; }
		}
		
		//pumpking
		public bool PumpkingDownedPumpkinHorse
		{
			get { return Pumpking.PumpkingWorld.downedPumpkingHorseman; }
		}
		
		public bool PumpkingDownedTerraLord
		{
			get { return Pumpking.PumpkingWorld.downedTerraLord; }
		}
		
		//joost
		public bool JoostDownedCactuar
		{
			get { return JoostMod.JoostWorld.downedJumboCactuar; }
		}
		
		public bool JoostDownedSAX
		{
			get { return JoostMod.JoostWorld.downedSAX; }
		}
		
		//tremor
		public bool TremorDownedCorn
		{
			get { return Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.EvilCorn]; }
		}
		
		public bool TremorDownedRukh
		{
			get { return Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.Rukh]; }
		}
		
		public bool TremorDownedFungus
		{
			get { return Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.FungusBeetle]; }
		}
		
		public bool TremorDownedWhale
		{
			get { return Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.SpaceWhale]; }
		}
		
		public bool TremorDownedTrinity
		{
			get { return Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.Trinity]; }
		}
		
		public bool TremorDownedTotem
		{
			get { return Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.TikiTotem]; }
		}                                              
		                                               
		public bool TremorDownedJelly                  
		{                                              
			get { return Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.StormJellyfish]; }
		}                                             
		                                              
		public bool TremorDownedCyberKing             
		{                                             
			get { return Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.CyberKing]; }
		}                                              
		                                               
		public bool TremorDownedHeater                 
		{                                              
			get { return Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.HeaterofWorlds]; }
		}                                             
		                                              
		public bool TremorDownedFrostKing             
		{                                             
			get { return Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.FrostKing]; }
		}                                              
		                                               
		public bool TremorDownedDarkEmperor            
		{                                              
			get { return Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.DarkEmperor]; }
		}
		
		public bool TremorDownedPixie
		{
			get { return Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.PixieQueen]; }
		}                                             
		                                              
		public bool TremorDownedAlchemaster           
		{                                             
			get { return Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.Alchemaster]; }
		}                                            
		                                             
		public bool TremorDownedBrutallisk           
		{                                            
			get { return Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.Brutallisk]; }
		}                                            
		                                             
		public bool TremorDownedParadoxTitan         
		{                                            
			get { return Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.ParadoxTitan]; }
		}                                             
		                                              
		public bool TremorDownedCogLord               
		{                                             
			get { return Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.CogLord]; }
		}                                             
		                                              
		public bool TremorDownedWall                  
		{                                             
			get { return Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.WallOfShadow]; }
		}                                             
		                                              
		public bool TremorDownedMotherboard           
		{                                             
			get { return Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.Motherboard]; }
		}
		
		public bool TremorDownedDragon         
		{                                             
			get { return Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.AncientDragon]; }
		}
		
		public bool TremorDownedAndas        
		{                                             
			get { return Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.Andas]; }
		}
		
		//spirit
		public bool SpiritDownedScarab
		{
			get { return SpiritMod.MyWorld.downedScarabeus; }
		}
		
		public bool SpiritDownedAncientFlier
		{
			get { return SpiritMod.MyWorld.downedAncientFlier; }
		}
		
		public bool SpiritDownedRaider
		{
			get { return SpiritMod.MyWorld.downedRaider; }
		}
		
		public bool SpiritDownedInfer
		{
			get { return SpiritMod.MyWorld.downedInfernon; }
		}
		
		public bool SpiritDownedDusking
		{
			get { return SpiritMod.MyWorld.downedDusking; }
		}
		
		public bool SpiritDownedIlluminant
		{
			get { return SpiritMod.MyWorld.downedIlluminantMaster; }
		}
		
		public bool SpiritDownedAtlas
		{
			get { return SpiritMod.MyWorld.downedAtlas; }
		}
		
		public bool SpiritDownedOverseer
		{
			get { return SpiritMod.MyWorld.downedOverseer; }
		}
		
		public bool SpiritDownedVine
		{
			get { return SpiritMod.MyWorld.downedReachBoss; }
		}
		
		public bool SpiritDownedUmbra
		{
			get { return SpiritMod.MyWorld.downedSpiritCore; }
		}
		
		//BTFA
		public bool BtfaTitan
		{
			get { return ForgottenMemories.TGEMWorld.downedTitanRock; }
		}
		
		//public bool BtfaArtery
		//{
		//	get { return ForgottenMemories.TGEMWorld.downedArterius; }
		//}
		
		public bool BtfaGhastly
		{
			get { return ForgottenMemories.TGEMWorld.downedGhastlyEnt; }
		}
		
		//Bluemagics
		public bool BlueDownedPhantom
		{
			get { return Bluemagic.BluemagicWorld.downedPhantom; }
		}
		
		public bool BlueDownedAbom
		{
			get { return Bluemagic.BluemagicWorld.downedAbomination; }
		}
		
		//Eota
		public bool AncientsDownedWorms
		{
			get { return EchoesoftheAncients.AncientWorld.downedWyrms; }		
		}
		
		//Crystilium
		public bool CrystiliumDownedKing
		{
			get { return CrystiliumMod.CrystalWorld.downedCrystalKing; }			
		}
		
		//exodus
		public bool ExodusDownedAbom
		{
			get { return Exodus.ExodusWorld.downedExodusAbomination; }			
		}
		
		public bool ExodusDownedBlob
		{
			get { return Exodus.ExodusWorld.downedExodusEvilBlob; }			
		}
		
		public bool ExodusDownedColoss
		{
			get { return Exodus.ExodusWorld.downedExodusColossus; }			
		}
		
		public bool ExodusDownedEmperor
		{
			get { return Exodus.ExodusWorld.downedExodusDesertEmperor; }			
		}
		
		public bool ExodusDownedHive
		{
			get { return Exodus.ExodusWorld.downedExodusHivemind; }			
		}
		
		public bool ExodusDownedMaster
		{
			get { return Exodus.ExodusWorld.downedExodusMaster; }			
		}

		public bool ExodusDownedHeart
		{
			get { return Exodus.ExodusWorld.downedExodusSludgeheart; }			
		}

		
		/*//Xervos
		public bool XervosDownedDeceased
		{
			get { return XervosMod.XervosGen.downedDeceasedEye; }
		}*/
		
		//end of bool sheeeeeeeeeeeeeet
		
		public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
            if (FargoWorld.downedBoss || NPC.downedBoss1 == true || NPC.downedSlimeKing == true)
            {
                return true;
            }    
            return false;
        }
		
		public override string TownNPCName()
		{
			switch (WorldGen.genRand.Next(9))
			{
				case 0:
					return "Flacken";
				case 1:
					return "Dorf";
				case 2:
					return "Bingo";
				case 3:
					return "Hans";
				case 4:
					return "Fargo";
				case 5:
					return "Grim";
				case 6:
					return "Furgo";
				case 7:
					return "Fargu";
				default:
					return "Polly";
			}
		}

		public override string GetChat()
		{
			int nurse = NPC.FindFirstNPC(NPCID.Nurse);
			int witchDoctor = NPC.FindFirstNPC(NPCID.WitchDoctor);
			
			if(Main.bloodMoon == true)
			{
				switch (Main.rand.Next(1))
				{
				case 0:
					return "Lovely night, isn't it?";
				default:
					return "I hope the constant arguing I'm hearing isn't my fault.";
				}
			}
			
			if(BirthdayParty.PartyIsUp == true)
			{
				return "I don't know what everyone's so happy about, but as long as nobody mistakes me for a Pigronata, I'm happy too.";
			}
			
			if (nurse >= 0 && Main.rand.Next(19) == 0)
			{
				return "Whenever we're alone, " + Main.npc[nurse].GivenName + " keeps throwing syringes at me, no matter how many times I tell her to stop!";
			}
			
			if (witchDoctor >= 0 && Main.rand.Next(18) == 0)
			{
				return "Please go tell " + Main.npc[witchDoctor].GivenName + " to drop the 'mystical' shtick, I mean, come on! I get it, you make tainted water or something.";
			}
			
			if(Main.dayTime != true && Main.rand.Next(8) == 0)
			{
				return "I'd follow and help, but I'd much rather sit around right now.";
			}
			
			
			switch (Main.rand.Next(16))
			{
				case 0:
					return "Savagery, barbarism, bloodthirst, that's what I like seeing in people.";
				case 1:
					return "The stronger you get, the more stuff I sell. Makes sense, right?";
				case 2:
					return "There's something all of you have that I don't... Death perception, I think it's called?";
				case 3:
					return "It would be pretty cool if I could sell a summon for myself...";
				case 4:
					return "The only way to get stronger is to keep buying from me and in bulk too!";
				case 5:
					return "What's that? You want to fight me? ...you're not worthy.";
				case 6:
					return "Don't bother with anyone else, all you'll ever need is right here.";
				case 7:
					return "You're lucky I'm on your side.";
				case 8:
					return "Thanks for the house, I guess.";
				case 9:
					return "Why yes I would love a ham and swiss sandwich.";
				case 10:
					return "Should I start wearing clothes? ...Nah.";
				case 11:
					return "It's not like I can actually use all the gold you're spending.";
				case 12:
					return "Violence for violence is the law of the beast.";
				case 13:
					return "Those guys really need to get more creative. All their first bosses are desert themed!";
				case 14:	
					return "I am proud to be known as the Mutant, but thank Fargo I'm no Abomination";
				default:
					return "Cthulhu's got nothing on me!";
			}
			
		}
		
		public override void SetChatButtons(ref string button, ref string button2)
		{
			
			if(shopnum == 1)
			{
				button = "Pre Hardmode";
			}
			
			else if(shopnum == 2)
			{
				button = "Hardmode";
			}
			
			else 
			{
				button = "Post Moon Lord";
			}
			
			if(Main.hardMode)
			{
			button2 = "Cycle Shop";
			}
		}

		public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if (firstButton)
            {
                shop = true;
			
				if(shopnum == 1)
				{
					shop1 = true;
					shop2 = false;
					shop3 = false;
				}
			
				else if(shopnum == 2)
				{
					shop2 = true;
					shop1 = false;
					shop3 = false;
				}
			
				else 
				{
					shop3 = true;
					shop1 = false;
					shop2 = false;
				}
            }
			
			if (!firstButton && Main.hardMode)
			{
                shopnum++;
                
				if(shopnum == 4)
				{
					shopnum = 1;
				}
			}
        }

		public override void SetupShop(Chest shop, ref int nextSlot)
		{
			if (shop1 == true)
			{        
				//PREHARDMODE BOSSES
				
						shop.item[nextSlot].SetDefaults(mod.ItemType("Overloader"));
						shop.item[nextSlot].value=500000;
						nextSlot++;
				
						shop.item[nextSlot].SetDefaults(mod.ItemType("PandorasBox"));
						shop.item[nextSlot].value=200000;
						nextSlot++;
				
				if (Fargowiltas.instance.ersionLoaded)
				{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Ersion").ItemType("SlimyFood"));
						shop.item[nextSlot].value=10000;
						nextSlot++;
				}
				
				if (ModLoader.GetLoadedMods().Contains("Exodus"))
				{
					if(ExodusDownedAbom)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Exodus").ItemType("ZombieMeat"));
						shop.item[nextSlot].value=20000;
						nextSlot++;
					}
				}
				
				if (Fargowiltas.instance.thoriumLoaded)
				{
					if(ThoriumModDownedThunderBird)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("ThoriumMod").ItemType("StormFlare"));
						shop.item[nextSlot].value=20000;
						nextSlot++;
					}
				}
				
				if (Fargowiltas.instance.spiritLoaded)
				{
					if(SpiritDownedScarab)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("SpiritMod").ItemType("ScarabIdol"));
						shop.item[nextSlot].value=10000;
						nextSlot++;
					}
				}
			
				if (NPC.downedSlimeKing == true)
				{
						shop.item[nextSlot].SetDefaults(mod.ItemType("SlimyCrown"));
						shop.item[nextSlot].value=30000;
						nextSlot++;
				} 
				
				if (ModLoader.GetLoadedMods().Contains("Exodus"))
				{
					if(ExodusDownedBlob)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Exodus").ItemType("DisgustingJelly"));
						shop.item[nextSlot].value=30000;
						nextSlot++;
					}
				}
				
				if(Fargowiltas.instance.gabeLoaded)
				{
					if(GabeModDownedMurk)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("GabeHasWonsMod").ItemType("MudGel"));
						shop.item[nextSlot].value=30000;
						nextSlot++;
					}
				}
			
				if (Fargowiltas.instance.calamityLoaded)
				{
					if(CalamityModDownedDesertScourge)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("DriedSeafood"));;
						shop.item[nextSlot].value=60000;
						nextSlot++;
					}
				}
			
				if (NPC.downedBoss1 == true)
				{			 
						shop.item[nextSlot].SetDefaults(mod.ItemType("SuspiciousEye"));
						shop.item[nextSlot].value=50000;
						nextSlot++;
					
					if(Fargowiltas.instance.w1kLoaded)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("W1KModRedux").ItemType("GoldenFeather"));
						shop.item[nextSlot].value=50000;
						nextSlot++;
					}
					
				}
				
				if (ModLoader.GetLoadedMods().Contains("Exodus"))
				{
					if(ExodusDownedColoss)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Exodus").ItemType("GraniteAnomaly"));
						shop.item[nextSlot].value=40000;
						nextSlot++;
					}
					
					if(ExodusDownedEmperor)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Exodus").ItemType("AncientArtifact"));
						shop.item[nextSlot].value=40000;
						nextSlot++;
					}
				}
				
				if (Fargowiltas.instance.tremorLoaded)
				{
					if(TremorDownedRukh)
					{
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("DesertCrown"));
					shop.item[nextSlot].value=50000;
					nextSlot++;
					}
				}
				
				if (Fargowiltas.instance.calamityLoaded)
				{					
					if(CalamityModDownedCrab)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("DecapoditaSprout"));;
						shop.item[nextSlot].value=70000;
						nextSlot++;
					}
				}

				if(Fargowiltas.instance.btfaLoaded)
				{
					if(BtfaGhastly)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("ForgottenMemories").ItemType("AncientLog"));
						shop.item[nextSlot].value=50000;
						nextSlot++;
					}
				}
			
				if (NPC.downedBoss2 == true)
				{
						shop.item[nextSlot].SetDefaults(mod.ItemType("WormyFood"));
						shop.item[nextSlot].value=60000;
						nextSlot++;
			
						shop.item[nextSlot].SetDefaults(mod.ItemType("GoreySpine"));
						shop.item[nextSlot].value=60000;
						nextSlot++;
			
					if (Fargowiltas.instance.cookieLoaded)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CookieMod").ItemType("BloodyCookie"));
						shop.item[nextSlot].value=60000;
						nextSlot++;
		
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CookieMod").ItemType("CursedCookie"));
						shop.item[nextSlot].value=60000;
						nextSlot++;
					}
				}
				
				
					
				if(Fargowiltas.instance.tremorLoaded)
				{
					if(TremorDownedTotem)
					{
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("MysteriousDrum"));
					shop.item[nextSlot].value=50000;
					nextSlot++;
					}
					
					if(TremorDownedCorn)
					{
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("CursedPopcorn"));
					shop.item[nextSlot].value=50000;
					nextSlot++;
					}
					
					if(TremorDownedJelly)
					{
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("StormJelly"));
					shop.item[nextSlot].value=60000;
					nextSlot++;
					}
				}
				
				if (Fargowiltas.instance.thoriumLoaded)
				{
					if(ThoriumModDownedJelly)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("ThoriumMod").ItemType("JellyfishResonator"));
						shop.item[nextSlot].value=60000;
						nextSlot++;
					}
				}
				
				if(Fargowiltas.instance.tremorLoaded)
				{
					if(TremorDownedDragon)
					{
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("RustyLantern"));
					shop.item[nextSlot].value=70000;
					nextSlot++;
					}
				}
				
				if (Fargowiltas.instance.spiritLoaded)
				{
					if (SpiritDownedVine)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("SpiritMod").ItemType("ReachBossSummon"));
						shop.item[nextSlot].value = 70000;
						nextSlot++;
					}
				}
			
				if (Fargowiltas.instance.shroomsLoaded)
				{
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Shrooms").ItemType("SLM"));
					shop.item[nextSlot].value=60000;
					nextSlot++;
				}
				
				if (NPC.downedQueenBee == true)
                {
                    shop.item[nextSlot].SetDefaults(mod.ItemType("Abeemination2"));
                    shop.item[nextSlot].value=90000;
                    nextSlot++;
                }

				if((NPC.downedBoss3 == true) && (NPC.downedQueenBee == true))
				{
					if (Fargowiltas.instance.nightmaresLoaded)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("TrueEater").ItemType("SpitterSpawner"));
						shop.item[nextSlot].value=70000;
						nextSlot++;
					}
				}
				
				if(Fargowiltas.instance.sacredToolsLoaded)
				{
					if(SacredToolsDownedPump)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("SacredTools").ItemType("PumpkinLantern"));
                        shop.item[nextSlot].value=70000;
                        nextSlot++;
					}
				}

                if (Fargowiltas.instance.spiritLoaded)
                {
                    if(SpiritDownedAncientFlier)
                    {
                        shop.item[nextSlot].SetDefaults(ModLoader.GetMod("SpiritMod").ItemType("JewelCrown"));
                        shop.item[nextSlot].value=70000;
                        nextSlot++;
                    }        
                }
				
				if(Fargowiltas.instance.grealmLoaded)
				{
					if(GRealmDownedFolivine)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("GRealm").ItemType("JungleBait"));
						shop.item[nextSlot].value=70000;
						nextSlot++;
					}
				}
				
				if (Fargowiltas.instance.calamityLoaded)
				{
					if((CalamityModDownedPerforator == true) || (CalamityModDownedHiveMind))
					{
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("BloodyWormFood"));
					shop.item[nextSlot].value=150000;
					nextSlot++;
			
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("Teratoma"));
					shop.item[nextSlot].value=150000;
					nextSlot++;
					}
				}
			
				if (NPC.downedBoss3 == true)
				{
						shop.item[nextSlot].SetDefaults(mod.ItemType("SuspiciousSkull"));
						shop.item[nextSlot].value=80000;
						nextSlot++;
				}
				
				if (ModLoader.GetLoadedMods().Contains("Exodus"))
				{
					if(ExodusDownedHive)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Exodus").ItemType("VineSerpent"));
						shop.item[nextSlot].value=80000;
						nextSlot++;
					}
				}
				
				if (Fargowiltas.instance.spiritLoaded)
				{
					if (SpiritDownedRaider)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("SpiritMod").ItemType("StarWormSummon"));
						shop.item[nextSlot].value = 80000;
						nextSlot++;
					}
				}
				
				if(Fargowiltas.instance.tremorLoaded)
				{
					if(TremorDownedFungus)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("MushroomCrystal"));
						shop.item[nextSlot].value=70000;
						nextSlot++;
					}
				}
				
				if (Fargowiltas.instance.thoriumLoaded)
				{
					if(ThoriumModDownedStorm)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("ThoriumMod").ItemType("UnstableCore"));
						shop.item[nextSlot].value=80000;
						nextSlot++;
					}
					
					if(ThoriumModDownedChampion)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("ThoriumMod").ItemType("AncientBlade"));
						shop.item[nextSlot].value=80000;
						nextSlot++;
					}
				}
				
				if (Fargowiltas.instance.sacredToolsLoaded)
				{
					if(SacredToolsDownedHarpy)
					{
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("SacredTools").ItemType("HarpySummon"));
					shop.item[nextSlot].value=60000;
					nextSlot++;
					}
				}	
					
				if(Fargowiltas.instance.tremorLoaded)
				{
					if(TremorDownedHeater)
					{
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("MoltenHeart"));
					shop.item[nextSlot].value=80000;
					nextSlot++;
					}
				}
			
				if (Fargowiltas.instance.thoriumLoaded)
				{
					if (ThoriumModDownedScout)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("ThoriumMod").ItemType("StarCaller"));
						shop.item[nextSlot].value=80000;
						nextSlot++;
					}
				}
				
				if (Fargowiltas.instance.calamityLoaded)
				{
						if(CalamityModDownedSlimeGod)
						{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("OverloadedSludge"));
						shop.item[nextSlot].value=250000;
						nextSlot++;
						}
				}
				
				if(Fargowiltas.instance.w1kLoaded)
				{
					if(Main.hardMode)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("W1KModRedux").ItemType("FieryEgg"));
						shop.item[nextSlot].value=150000;
						nextSlot++;
						
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("W1KModRedux").ItemType("GrassyEgg"));
						shop.item[nextSlot].value=150000;
						nextSlot++;
						
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("W1KModRedux").ItemType("WateryEgg"));
						shop.item[nextSlot].value=150000;
						nextSlot++;
					}
				}
				
				if(Main.hardMode)
				{
						shop.item[nextSlot].SetDefaults(mod.ItemType("FleshyDoll"));
						shop.item[nextSlot].value=120000;
						nextSlot++;
						
					if ((NPC.downedBoss1 == true) && (NPC.downedBoss2 == true) && (NPC.downedBoss3 == true) && (Main.hardMode == true) && (NPC.downedQueenBee == true) && (NPC.downedSlimeKing == true))
					{	
						shop.item[nextSlot].SetDefaults(mod.ItemType("DeathBringerFairy"));
						shop.item[nextSlot].value=160000;
						nextSlot++;
					}
				}
			}
		
		else if(shop2 == true)
		{			
			
			//HARDMODE BOSSES
			
				//if(Fargowiltas.instance.btfaLoaded)
				//{
					//if(BtfaArtery)
					//{
						//shop.item[nextSlot].SetDefaults(ModLoader.GetMod("ForgottenMemories").ItemType("BloodClot"));
					//	shop.item[nextSlot].value=60000;
					//	nextSlot++;
					//}
				//}
			
				if (ModLoader.GetLoadedMods().Contains("Exodus"))
				{
					if(ExodusDownedMaster)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Exodus").ItemType("GlowingSkull"));
						shop.item[nextSlot].value=100000;
						nextSlot++;
					}
				}
			
				if (Fargowiltas.instance.thoriumLoaded)
				{
						if(ThoriumModDownedStrider)
						{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("ThoriumMod").ItemType("StriderTear"));
						shop.item[nextSlot].value=100000;
						nextSlot++;
						}
				}
				
				if (Fargowiltas.instance.thoriumLoaded)
				{
					if(ThoriumModDownedFallenBeholder)
					{
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("ThoriumMod").ItemType("VoidLens"));
					shop.item[nextSlot].value=150000;
					nextSlot++;
					}
				}
			
				if (Fargowiltas.instance.calamityLoaded)
				{
					if(CalamityModDownedCryogen)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("CryoKey"));
						shop.item[nextSlot].value=350000;
						nextSlot++;
					}
				}
				
				if (Fargowiltas.instance.spiritLoaded)
				{
					if(SpiritDownedInfer)
					{
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("SpiritMod").ItemType("CursedCloth"));
					shop.item[nextSlot].value=90000;
					nextSlot++;
					}
				}
				
				if(Fargowiltas.instance.tremorLoaded)
				{
					if(TremorDownedAlchemaster)
					{
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("AncientMosaic"));
					shop.item[nextSlot].value=120000;
					nextSlot++;
					}
				}
			
			 if (NPC.downedMechBossAny)
                {				
					if (Fargowiltas.instance.ersionLoaded)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Ersion").ItemType("SuspiciousLookingGel"));
						shop.item[nextSlot].value=120000;
						nextSlot++;
						
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Ersion").ItemType("SuspiciousLookingChip"));
						shop.item[nextSlot].value=120000;
						nextSlot++;
					}
					
					if(Fargowiltas.instance.w1kLoaded)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("W1KModRedux").ItemType("CursedFlower"));
						shop.item[nextSlot].value=210000;
						nextSlot++;
						
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("W1KModRedux").ItemType("BloodySkull"));
						shop.item[nextSlot].value=380000;
						nextSlot++;
					}					
				}
				
				if(Fargowiltas.instance.btfaLoaded)
				{
					if(BtfaTitan)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("ForgottenMemories").ItemType("anomalydetector"));
						shop.item[nextSlot].value=100000;
						nextSlot++;
					}
				}
			
			if (NPC.downedMechBoss1 == true)
			{	
						shop.item[nextSlot].SetDefaults(mod.ItemType("MechWorm"));
						shop.item[nextSlot].value=120000;
						nextSlot++;
			}
			
			if (NPC.downedMechBoss2 == true)
			{	
						shop.item[nextSlot].SetDefaults(mod.ItemType("MechEye"));
						shop.item[nextSlot].value=120000;
						nextSlot++;
			}
			
			if (NPC.downedMechBoss3 == true)
			{	
						shop.item[nextSlot].SetDefaults(mod.ItemType("MechSkull"));
						shop.item[nextSlot].value=120000;
						nextSlot++;
			}
			
			if (Fargowiltas.instance.tremorLoaded)
			{
				if(TremorDownedMotherboard)
				{
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("MechanicalBrain"));
					shop.item[nextSlot].value=120000;
					nextSlot++;
				}
			}
			
			if ((NPC.downedMechBoss1 == true) && (NPC.downedMechBoss2 == true) && (NPC.downedMechBoss3 == true))
			{	
						shop.item[nextSlot].SetDefaults(mod.ItemType("MechanicalAmalgam"));
						shop.item[nextSlot].value=200000;
						nextSlot++;
				
				if(Fargowiltas.instance.w1kLoaded)
				{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("W1KModRedux").ItemType("MysteryTicket"));
						shop.item[nextSlot].value=380000;
						nextSlot++;
						
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("W1KModRedux").ItemType("MetroidCapsule"));
						shop.item[nextSlot].value=380000;
						nextSlot++;
						
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("W1KModRedux").ItemType("OminousMask"));
						shop.item[nextSlot].value=400000;
						nextSlot++;
				}	
			}
			
			if (Fargowiltas.instance.spiritLoaded)
				{
					if(SpiritDownedDusking)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("SpiritMod").ItemType("DuskCrown"));
						shop.item[nextSlot].value=100000;
						nextSlot++;
					}
					
					if(SpiritDownedUmbra)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("SpiritMod").ItemType("UmbraSummon"));
						shop.item[nextSlot].value=100000;
						nextSlot++;
					}
				}

			if (Fargowiltas.instance.calamityLoaded)
			{
				if(CalamityModDownedBrimstone)
				{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("CharredIdol"));
						shop.item[nextSlot].value=140000;
						nextSlot++;
				}
			}	
				
			if (Fargowiltas.instance.tremorLoaded)
			{
				if(TremorDownedPixie)
				{
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("PixieinaJar"));
					shop.item[nextSlot].value=120000;
					nextSlot++;
				}
			}
				
			if (Fargowiltas.instance.thoriumLoaded)
			{
					if(ThoriumModDownedLich)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("ThoriumMod").ItemType("LichCatalyst"));
						shop.item[nextSlot].value=150000;
						nextSlot++; 
					}
			}
			
			 if (Fargowiltas.instance.sacredToolsLoaded)
			 {
				 if(SacredToolsDownedRaynare)
				 {
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("SacredTools").ItemType("HarpySummon2"));
						shop.item[nextSlot].value=140000;
						nextSlot++;
				 }
             }

			if (Fargowiltas.instance.spiritLoaded)
			{
				if(SpiritDownedIlluminant)
				{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("SpiritMod").ItemType("ChaosFire"));
						shop.item[nextSlot].value=120000;
						nextSlot++;
				}
			}		
				
			if (Fargowiltas.instance.calamityLoaded)
			{
				if(CalamityModDownedCalamitas)
				{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("BlightedEyeball"));
						shop.item[nextSlot].value=1000000;
						nextSlot++;
				}
			}
			
			if (NPC.downedPlantBoss == true)
			{	
						shop.item[nextSlot].SetDefaults(mod.ItemType("Plantera"));
						shop.item[nextSlot].value=150000;
						nextSlot++;
			
				if (Fargowiltas.instance.nightmaresLoaded)
				{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("TrueEater").ItemType("MimicKey"));
						shop.item[nextSlot].value= (ModLoader.GetMod("TrueEater").ItemType("MimicKey"));
						nextSlot++;
				}
			}
			
			if (ModLoader.GetLoadedMods().Contains("Exodus"))
				{
					if(ExodusDownedHeart)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Exodus").ItemType("JungleCrown"));
						shop.item[nextSlot].value=120000;
						nextSlot++;
					}
				}
			
			if (Fargowiltas.instance.tremorLoaded)
				{
					if(TremorDownedFrostKing)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("FrostCrown"));
						shop.item[nextSlot].value=120000;
						nextSlot++;
					}
					
                }
			
			if (Fargowiltas.instance.calamityLoaded)
			{
				if(CalamityModDownedLeviathan)
				{
						shop.item[nextSlot].SetDefaults(mod.ItemType("LeviathanSummon"));
						shop.item[nextSlot].value=400000;
						nextSlot++;
				}
			}
			
			if (Fargowiltas.instance.tremorLoaded)
				{
					if(TremorDownedWall)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("ShadowRelic"));
						shop.item[nextSlot].value=120000;
						nextSlot++;
					}
					
                }
			
			/*if (Fargowiltas.instance.calamityLoaded)
			{
				if(CalamityModDownedAstrum)
				{
						shop.item[nextSlot].SetDefaults(mod.ItemType("Starcore"));
						shop.item[nextSlot].value=400000;
						nextSlot++;
				}
			}*/
			
			if (NPC.downedGolemBoss == true)
			{	
						shop.item[nextSlot].SetDefaults(mod.ItemType("LihzahrdPowerCell2"));
						shop.item[nextSlot].value=160000;
						nextSlot++;
			}
			
			if(FargoWorld.downedBetsy == true)
			{
						shop.item[nextSlot].SetDefaults(mod.ItemType("BetsyEgg"));
						shop.item[nextSlot].value=160000;
						nextSlot++;
			}
			
			if (Fargowiltas.instance.tremorLoaded)
				{
					if(TremorDownedCogLord)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("ArtifactEngine"));
						shop.item[nextSlot].value=120000;
						nextSlot++;
					}
                }
			
			if (Fargowiltas.instance.thoriumLoaded == true)
			{
					if(ThoriumModDownedAbyssion)
					{
						shop.item[nextSlot].SetDefaults(mod.ItemType("AbyssionSummon"));
						shop.item[nextSlot].value=150000;
						nextSlot++;
					}
			}
			
			if (Fargowiltas.instance.calamityLoaded)
				{	
					if(CalamityModDownedPlaguebringer)	
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("Abomination"));
						shop.item[nextSlot].value=2000000;
						nextSlot++;
					}
				}
			
			if (Fargowiltas.instance.tremorLoaded)
			{
					if(TremorDownedCyberKing)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("AdvancedCircuit"));
						shop.item[nextSlot].value=150000;
						nextSlot++;
					}
			}
			
			if (ModLoader.GetLoadedMods().Contains("CrystiliumMod"))
				{
					if(CrystiliumDownedKing)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CrystiliumMod").ItemType("CrypticCrystal"));
						shop.item[nextSlot].value=120000;
						nextSlot++;
					}
				}
				
				if (Fargowiltas.instance.calamityLoaded)
				{	
					if(CalamityModDownedRavager)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("AncientMedallion"));
						shop.item[nextSlot].value=2200000;
						nextSlot++;
					}
				}
			
			if (NPC.downedFishron == true)
			{	
						shop.item[nextSlot].SetDefaults(mod.ItemType("TruffleWorm2"));
						shop.item[nextSlot].value=150000;
						nextSlot++;
			
				
			
				if (ModLoader.GetLoadedMods().Contains("WaterBiomeMod"))
				{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("WaterBiomeMod").ItemType("SeaConch"));
						shop.item[nextSlot].value=2000000;
						nextSlot++;
				}
			}
			
			if (ModLoader.GetLoadedMods().Contains("Pumpking"))
			{
				if(PumpkingDownedPumpkinHorse)
				{
                        shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Pumpking").ItemType("PumpkingSoul"));
						shop.item[nextSlot].value=160000;
						nextSlot++;
				}							
			}
			
			if (Fargowiltas.instance.spiritLoaded)
			{
				if(SpiritDownedAtlas)
				{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("SpiritMod").ItemType("StoneSkin"));
						shop.item[nextSlot].value=150000;
						nextSlot++;
				}
			}	

				if (Fargowiltas.instance.blueMagicLoaded)
				{
					if(BlueDownedPhantom)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Bluemagic").ItemType("PaladinEmblem"));
						shop.item[nextSlot].value=180000;
						nextSlot++;
					}
                }

				if (Fargowiltas.instance.blueMagicLoaded)
				{
					if(BlueDownedAbom)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Bluemagic").ItemType("FoulOrb"));
						shop.item[nextSlot].value=250000;
						nextSlot++;
					}
                }
			
			if (NPC.downedMoonlord == true)
			{	
						shop.item[nextSlot].SetDefaults(mod.ItemType("CelestialSigil2"));
						shop.item[nextSlot].value=250000;
						nextSlot++;
						
						shop.item[nextSlot].SetDefaults(mod.ItemType("MutantVoodoo"));
						shop.item[nextSlot].value=500000;
						nextSlot++;
			}
		}
		
		else
		{
			
			if (Fargowiltas.instance.tremorLoaded)
			{
					if(TremorDownedDarkEmperor)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("EmperorCrown"));
						shop.item[nextSlot].value=200000;
						nextSlot++;
					}
			}
			
			if (Fargowiltas.instance.spiritLoaded)
			{
				if(SpiritDownedOverseer)
				{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("SpiritMod").ItemType("SpiritIdol"));
						shop.item[nextSlot].value=200000;
						nextSlot++;
				}
			}	
			
			if(Fargowiltas.instance.ancientsLoaded)
			{
				if(AncientsDownedWorms)
				{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("EchoesoftheAncients").ItemType("Wyrm_Rune"));
						shop.item[nextSlot].value=1000000;
						nextSlot++;
				}
			}
			
			if (Fargowiltas.instance.tremorLoaded)
			{
					if(TremorDownedBrutallisk)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("RoyalEgg"));
						shop.item[nextSlot].value=200000;
						nextSlot++;
					}
			}

			if (ModLoader.GetLoadedMods().Contains("Pumpking"))
			{
				if(PumpkingDownedTerraLord)
				{
                        shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Pumpking").ItemType("TerraCore"));
						shop.item[nextSlot].value=500000;
						nextSlot++;
				}
							
			}
			
			if (Fargowiltas.instance.sacredToolsLoaded)
			{
				if(SacredToolsDownedAbaddon)
				{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("SacredTools").ItemType("ShadowWrathSummonItem"));
						shop.item[nextSlot].value=200000;
						nextSlot++;
				}
            }
			
			if (Fargowiltas.instance.calamityLoaded)
			{
				if(CalamityModDownedGuardian)
				{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("ProfanedShard"));
						shop.item[nextSlot].value=3000000;
						nextSlot++;
				}
			}
			
			if (Fargowiltas.instance.tremorLoaded)
			{
					if(TremorDownedWhale)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("CosmicKrill"));
						shop.item[nextSlot].value=200000;
						nextSlot++;
					}
			}
			
			if (Fargowiltas.instance.joostLoaded)
			{
				if(JoostDownedCactuar)
				{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("JoostMod").ItemType("Cactusofdoom"));
						shop.item[nextSlot].value=2000000;
						nextSlot++;
				}
			}
			
			 if (Fargowiltas.instance.tremorLoaded)
			{
					if(TremorDownedTrinity)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("StoneofKnowledge"));
						shop.item[nextSlot].value=250000;
						nextSlot++;
					}
			}
			
			if (Fargowiltas.instance.thoriumLoaded == true)
			{
					if(ThoriumModDownedRealityBreaker)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("ThoriumMod").ItemType("RagSymbol"));
						shop.item[nextSlot].value=400000;
						nextSlot++;
					}
			}
			
			if (Fargowiltas.instance.tremorLoaded)
			{
					if(TremorDownedAndas)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("InfernoSkull"));
						shop.item[nextSlot].value=300000;
						nextSlot++;
					}
			}
			
			if (Fargowiltas.instance.calamityLoaded)
			{
				if(CalamityModDownedProvidence)
				{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("ProfanedCore"));
						shop.item[nextSlot].value=4000000;
						nextSlot++;
				}
			}
			
			 if (Fargowiltas.instance.sacredToolsLoaded)
             {
				if (SacredToolsDownedSerpent)
                {
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("SacredTools").ItemType("SerpentSummon"));
						shop.item[nextSlot].value=1000000;
						nextSlot++;
                }
			 }
			 
			  if (Fargowiltas.instance.joostLoaded)
            {
                if (JoostDownedSAX)
                {
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("JoostMod").ItemType("InfectedArmCannon"));
						shop.item[nextSlot].value=2000000;
						nextSlot++;
				}
            }
			
			 if (Fargowiltas.instance.sacredToolsLoaded)
             {
				if (SacredToolsDownedLunarians)
                {
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("SacredTools").ItemType("MoonEmblem"));
						shop.item[nextSlot].value=2000000;
						nextSlot++;
                }
			 }
			 
			 if (Fargowiltas.instance.calamityLoaded)
				{
					if(CalamityModDownedPolter)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("NecroplasmicBeacon"));
						shop.item[nextSlot].value=4000000;
						nextSlot++;
					}
				}
			 
			 if (Fargowiltas.instance.joostLoaded)
			{
				if(JoostDownedSAX)
				{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("JoostMod").ItemType("Excalipoor"));
						shop.item[nextSlot].value=10000000;
						nextSlot++;
				}
			}
			
			 	if (Fargowiltas.instance.calamityLoaded)
				{
					if(CalamityModDownedDOG)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("CosmicWorm"));
						shop.item[nextSlot].value=5000000;
						nextSlot++;
					}
				}
				
			//spirit of purity 
			 
			if (Fargowiltas.instance.calamityLoaded)
				{
					if(CalamityModDownedBirb)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("BirbPheromones"));
						shop.item[nextSlot].value=5000000;
						nextSlot++;
					}
				}
			
			if (Fargowiltas.instance.calamityLoaded)
             {
				if (CalamityModDownedYharon)
				{	
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("ChickenEgg"));
						shop.item[nextSlot].value=8000000;
						nextSlot++;
				}
			 }
			
			if (Fargowiltas.instance.calamityLoaded)
             {
				if (CalamityModDownedSCal)
				{	
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("EyeofExtinction"));
						shop.item[nextSlot].value=50000000;
						nextSlot++;
				}
			 }
			 
			 //spirit of chaos
			
			 if ((NPC.downedBoss1 == true) && (NPC.downedBoss2 == true) && (NPC.downedBoss3 == true) && (Main.hardMode == true) && (NPC.downedQueenBee == true) && (NPC.downedSlimeKing == true) && (NPC.downedMechBoss1 == true) && (NPC.downedMechBoss2 == true) && (NPC.downedMechBoss3 == true) && (NPC.downedGolemBoss == true) && (NPC.downedPlantBoss == true) && (NPC.downedFishron == true) && (NPC.downedMoonlord == true))
			{	
						shop.item[nextSlot].SetDefaults(mod.ItemType("AncientSeal"));
						shop.item[nextSlot].value=10000000;
						nextSlot++;
			}
				
		}
	}
	

		public override void TownNPCAttackStrength(ref int damage, ref float knockback)
		{
			if (NPC.downedMoonlord)
			{
				damage = 500;
				knockback = 10f;
			}
			else if (Main.hardMode)
			{
				damage = 60;
				knockback = 5f;
			}
			else
			{
				damage = 20;
				knockback = 4f;
			}
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
		{
			if (NPC.downedMoonlord == true)
			{
				cooldown = 1;
				//randExtraCooldown = 1;
			}
			else if (Main.hardMode == true)
			{
				cooldown = 20;
				randExtraCooldown = 25;
			}
			else
			{
				cooldown = 30;
				randExtraCooldown = 30;
			}
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
		{
			if (NPC.downedMoonlord == true)
			{
				projType = mod.ProjectileType("PhantasmalEyeProjectile");
				attackDelay = 1;
			}
			else if (Main.hardMode == true)
			{
				projType = mod.ProjectileType("MechEyeProjectile");
				attackDelay = 1;
			}
			else
			{
				projType = mod.ProjectileType("EyeProjectile");
				attackDelay = 1;
			}
		}

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
		{
			multiplier = 12f;
			randomOffset = 2f;
		}	
		
		public override void NPCLoot()
        {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("grabbag"));
        }
	}	
}


/*


"You try talking to [Guide] without him cowering in fear. I dare you."

I heard you liked fighting sealed bosses(reference to the ancient seal)

you want to fight me you say? You're not worthy you rat 

now that you defeated the big guy I'd say it's time to start collecting those materials;)

"You did all of this before, so make sure you don't fail."

it's clear I'm helping you out but uh what's in this for me? A house you say? I eat zombies for breakfast.  Something something something

"I really don't trust [Chef]... I don't know, I'm just saying."

I'm all you need for a calamity

oh is that a soul of the universe? Fascinating I'll get all mine from the back

Oh wow is that a speed soul. I coulda sold you one man

//all souls need one

"I know, I know, these souls look really pricy, buy I'm selling them at a loss here! Nobody would buy them otherwise! What a ripoff!"

Why does that cyborg guy even exist

You Are not my master guide is

The truffle guy said i could call him truffles... That reminds me of some guy i used to know

why does the dryads outfit make my wings flutter

"everything shall bow before me!... after you make this purchase"

[Stylist] once gave me a wig... I look hideous with long hair"

That mutated mushroom seems like my type of fella

That [tax collector name here] keeps asking me for money but he dosen't acept my spawners

"You are satan"
"You arent worthy,you fuckn rat"

"If any of us could play any instruments, I'd totally make a band with [Witch Docotoro], [Truffle] and [Cyborg]."

'The guide puts me off.. His exterior seems demonic.'

*/

=======
using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Events;
using System.Linq;
using Fargowiltas.NPCs;
using Fargowiltas;

namespace Fargowiltas.NPCs
{
	[AutoloadHead]
	public class Mutant : ModNPC
	{
		public override string Texture
		{
			get
			{
				return "Fargowiltas/NPCs/Mutant";
			}
		}	
		public static bool shop1 = false;
		public static bool shop2 = false;
		public static bool shop3 = false;
		
		public static int shopnum = 1;
	
		public override bool Autoload(ref string name)
		{
			name = "Mutant";
			return mod.Properties.Autoload;
		}
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mutant");
			Main.npcFrameCount[npc.type] = 25;
			NPCID.Sets.ExtraFramesCount[npc.type] = 9;
			NPCID.Sets.AttackFrameCount[npc.type] = 4;
			NPCID.Sets.DangerDetectRange[npc.type] = 700;
			NPCID.Sets.AttackType[npc.type] = 0;
			NPCID.Sets.AttackTime[npc.type] = 90;
			NPCID.Sets.AttackAverageChance[npc.type] = 30;
		}
		public override void SetDefaults()
		{
			npc.townNPC = true;
			npc.friendly = true;
			npc.width = 18;
			npc.height = 40;
			npc.aiStyle = 7;
			npc.damage = 10;
			
			
			if (NPC.downedMoonlord)
			{
				npc.defense = 50;
			}
			else
			{
				npc.defense = 15;
			}
			
			
			if (NPC.downedMoonlord)
			{
				npc.lifeMax = 5000;
			}
			else
			{
				npc.lifeMax = 250;
			}
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.knockBackResist = 0.5f;
			animationType = NPCID.Guide;
		}

		//thorium bools
		public bool ThoriumModDownedThunderBird
		{
			 get { return ThoriumMod.ThoriumWorld.downedThunderBird; }
		}
		
		public bool ThoriumModDownedJelly
		{
			get { return ThoriumMod.ThoriumWorld.downedJelly; }
		}
		
		public bool ThoriumModDownedStorm
		{
			get { return ThoriumMod.ThoriumWorld.downedStorm; }
		}
		
		public bool ThoriumModDownedChampion
		{
			get { return ThoriumMod.ThoriumWorld.downedChampion; }
		}
		
			public bool ThoriumModDownedScout
        {
            get { return ThoriumMod.ThoriumWorld.downedScout; }
        }
		
		public bool ThoriumModDownedStrider
		{
			 get { return ThoriumMod.ThoriumWorld.downedStrider; }
		}
		
		public bool ThoriumModDownedFallenBeholder
		{
			get { return ThoriumMod.ThoriumWorld.downedFallenBeholder; }
		}
		
		public bool ThoriumModDownedLich
		{
			get { return ThoriumMod.ThoriumWorld.downedLich; }
		}
		
		public bool ThoriumModDownedAbyssion
		{
			get { return ThoriumMod.ThoriumWorld.downedDepthBoss; }
		}
		
		public bool ThoriumModDownedRealityBreaker
		{
			get { return ThoriumMod.ThoriumWorld.downedRealityBreaker; }
		}
		
		//calamity bools
		public bool CalamityModDownedDesertScourge
		{
			get { return CalamityMod.CalamityWorld.downedDesertScourge; }
		}
		
		public bool CalamityModDownedHiveMind
		{
			get { return CalamityMod.CalamityWorld.downedHiveMind; }
		}
		
		public bool CalamityModDownedPerforator
		{
			get { return CalamityMod.CalamityWorld.downedPerforator; }
		}
		
		public bool CalamityModDownedSlimeGod
		{
			get { return CalamityMod.CalamityWorld.downedSlimeGod; }
		}
		
		public bool CalamityModDownedCryogen
		{
			get { return CalamityMod.CalamityWorld.downedCryogen; }
		}
		
		public bool CalamityModDownedBrimstone
		{
			get { return CalamityMod.CalamityWorld.downedBrimstoneElemental; }
		}
		
		public bool CalamityModDownedCalamitas
		{
			get { return CalamityMod.CalamityWorld.downedCalamitas; }
		}
		
		public bool CalamityModDownedLeviathan
		{
			get { return CalamityMod.CalamityWorld.downedLeviathan; }
		}
		
		public bool CalamityModDownedPlaguebringer
		{
			get { return CalamityMod.CalamityWorld.downedPlaguebringer; }
		}
		
		public bool CalamityModDownedGuardian
		{
			get { return CalamityMod.CalamityWorld.downedGuardians; }
		}

		public bool CalamityModDownedProvidence
		{
			get { return CalamityMod.CalamityWorld.downedProvidence; }
		}
		
		public bool CalamityModDownedDOG
		{
			get { return CalamityMod.CalamityWorld.downedDoG; }
		}
		
		public bool CalamityModDownedYharon
		{
			get { return CalamityMod.CalamityWorld.downedYharon; }
		}
		
		public bool CalamityModDownedSCal
		{
			get { return CalamityMod.CalamityWorld.downedSCal; }
		}
		
		public bool CalamityModDownedRavager
		{
			get { return CalamityMod.CalamityWorld.downedScavenger; }
		}
		
		public bool CalamityModDownedCrab
		{
			get { return CalamityMod.CalamityWorld.downedCrabulon; }
		}
		
		public bool CalamityModDownedAstrum
		{
			get { return CalamityMod.CalamityWorld.downedStarGod; }
		}
		
		public bool CalamityModDownedBirb
		{
			get { return CalamityMod.CalamityWorld.downedBumble; }
		}
		
		public bool CalamityModDownedPolter
		{
			get { return CalamityMod.CalamityWorld.downedPolterghast; }
		}
		
		
		
		//sacred tools bools
		public bool SacredToolsDownedHarpy
		{
			get { return SacredTools.ModdedWorld.downedHarpy; }
		}
		
		public bool SacredToolsDownedRaynare
		{
			get { return SacredTools.ModdedWorld.downedRaynare; }
		}
		
		public bool SacredToolsDownedAbaddon
		{
			get { return SacredTools.ModdedWorld.OblivionSpawns; }
		}
		
		public bool SacredToolsDownedSerpent
		{
			get { return SacredTools.ModdedWorld.FlariumSpawns; }
		}
		
		public bool SacredToolsDownedLunarians
		{
			get { return SacredTools.ModdedWorld.downedLunarians; }
		}
		
		//gabe has won bools
		public bool GabeModDownedMurk
		{
			get { return GabeHasWonsMod.GabeWorld.downedMurk; }
		}
		
		//grealm bools
		public bool GRealmDownedFolivine
		{
			get { return GRealm.MWorld.downedFolivine; }
		}
		
		//pumpking
		public bool PumpkingDownedPumpkinHorse
		{
			get { return Pumpking.PumpkingWorld.downedPumpkingHorseman; }
		}
		
		public bool PumpkingDownedTerraLord
		{
			get { return Pumpking.PumpkingWorld.downedTerraLord; }
		}
		
		//joost
		public bool JoostDownedCactuar
		{
			get { return JoostMod.JoostWorld.downedJumboCactuar; }
		}
		
		public bool JoostDownedSAX
		{
			get { return JoostMod.JoostWorld.downedSAX; }
		}
		
		//tremor
		public bool TremorDownedCorn
		{
			get { return Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.EvilCorn]; }
		}
		
		public bool TremorDownedRukh
		{
			get { return Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.Rukh]; }
		}
		
		public bool TremorDownedFungus
		{
			get { return Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.FungusBeetle]; }
		}
		
		public bool TremorDownedWhale
		{
			get { return Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.SpaceWhale]; }
		}
		
		public bool TremorDownedTrinity
		{
			get { return Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.Trinity]; }
		}
		
		public bool TremorDownedTotem
		{
			get { return Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.TikiTotem]; }
		}                                              
		                                               
		public bool TremorDownedJelly                  
		{                                              
			get { return Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.StormJellyfish]; }
		}                                             
		                                              
		public bool TremorDownedCyberKing             
		{                                             
			get { return Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.CyberKing]; }
		}                                              
		                                               
		public bool TremorDownedHeater                 
		{                                              
			get { return Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.HeaterofWorlds]; }
		}                                             
		                                              
		public bool TremorDownedFrostKing             
		{                                             
			get { return Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.FrostKing]; }
		}                                              
		                                               
		public bool TremorDownedDarkEmperor            
		{                                              
			get { return Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.DarkEmperor]; }
		}
		
		public bool TremorDownedPixie
		{
			get { return Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.PixieQueen]; }
		}                                             
		                                              
		public bool TremorDownedAlchemaster           
		{                                             
			get { return Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.Alchemaster]; }
		}                                            
		                                             
		public bool TremorDownedBrutallisk           
		{                                            
			get { return Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.Brutallisk]; }
		}                                            
		                                             
		public bool TremorDownedParadoxTitan         
		{                                            
			get { return Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.ParadoxTitan]; }
		}                                             
		                                              
		public bool TremorDownedCogLord               
		{                                             
			get { return Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.CogLord]; }
		}                                             
		                                              
		public bool TremorDownedWall                  
		{                                             
			get { return Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.WallOfShadow]; }
		}                                             
		                                              
		public bool TremorDownedMotherboard           
		{                                             
			get { return Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.Motherboard]; }
		}
		
		public bool TremorDownedDragon         
		{                                             
			get { return Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.AncientDragon]; }
		}
		
		public bool TremorDownedAndas        
		{                                             
			get { return Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.Andas]; }
		}
		
		//spirit
		public bool SpiritDownedScarab
		{
			get { return SpiritMod.MyWorld.downedScarabeus; }
		}
		
		public bool SpiritDownedAncientFlier
		{
			get { return SpiritMod.MyWorld.downedAncientFlier; }
		}
		
		public bool SpiritDownedRaider
		{
			get { return SpiritMod.MyWorld.downedRaider; }
		}
		
		public bool SpiritDownedInfer
		{
			get { return SpiritMod.MyWorld.downedInfernon; }
		}
		
		public bool SpiritDownedDusking
		{
			get { return SpiritMod.MyWorld.downedDusking; }
		}
		
		public bool SpiritDownedIlluminant
		{
			get { return SpiritMod.MyWorld.downedIlluminantMaster; }
		}
		
		public bool SpiritDownedAtlas
		{
			get { return SpiritMod.MyWorld.downedAtlas; }
		}
		
		public bool SpiritDownedOverseer
		{
			get { return SpiritMod.MyWorld.downedOverseer; }
		}
		
		public bool SpiritDownedVine
		{
			get { return SpiritMod.MyWorld.downedReachBoss; }
		}
		
		public bool SpiritDownedUmbra
		{
			get { return SpiritMod.MyWorld.downedSpiritCore; }
		}
		
		//BTFA
		public bool BtfaTitan
		{
			get { return ForgottenMemories.TGEMWorld.downedTitanRock; }
		}
		
		//public bool BtfaArtery
		//{
		//	get { return ForgottenMemories.TGEMWorld.downedArterius; }
		//}
		
		public bool BtfaGhastly
		{
			get { return ForgottenMemories.TGEMWorld.downedGhastlyEnt; }
		}
		
		//Bluemagics
		public bool BlueDownedPhantom
		{
			get { return Bluemagic.BluemagicWorld.downedPhantom; }
		}
		
		public bool BlueDownedAbom
		{
			get { return Bluemagic.BluemagicWorld.downedAbomination; }
		}
		
		//Eota
		public bool AncientsDownedWorms
		{
			get { return EchoesoftheAncients.AncientWorld.downedWyrms; }		
		}
		
		//Crystilium
		public bool CrystiliumDownedKing
		{
			get { return CrystiliumMod.CrystalWorld.downedCrystalKing; }			
		}
		
		//exodus
		public bool ExodusDownedAbom
		{
			get { return Exodus.ExodusWorld.downedExodusAbomination; }			
		}
		
		public bool ExodusDownedBlob
		{
			get { return Exodus.ExodusWorld.downedExodusEvilBlob; }			
		}
		
		public bool ExodusDownedColoss
		{
			get { return Exodus.ExodusWorld.downedExodusColossus; }			
		}
		
		public bool ExodusDownedEmperor
		{
			get { return Exodus.ExodusWorld.downedExodusDesertEmperor; }			
		}
		
		public bool ExodusDownedHive
		{
			get { return Exodus.ExodusWorld.downedExodusHivemind; }			
		}
		
		public bool ExodusDownedMaster
		{
			get { return Exodus.ExodusWorld.downedExodusMaster; }			
		}

		public bool ExodusDownedHeart
		{
			get { return Exodus.ExodusWorld.downedExodusSludgeheart; }			
		}

		
		/*//Xervos
		public bool XervosDownedDeceased
		{
			get { return XervosMod.XervosGen.downedDeceasedEye; }
		}*/
		
		//end of bool sheeeeeeeeeeeeeet
		
		public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
            if (FargoWorld.downedBoss || NPC.downedBoss1 == true || NPC.downedSlimeKing == true)
            {
                return true;
            }    
            return false;
        }
		
		public override string TownNPCName()
		{
			switch (WorldGen.genRand.Next(9))
			{
				case 0:
					return "Flacken";
				case 1:
					return "Dorf";
				case 2:
					return "Bingo";
				case 3:
					return "Hans";
				case 4:
					return "Fargo";
				case 5:
					return "Grim";
				case 6:
					return "Furgo";
				case 7:
					return "Fargu";
				default:
					return "Polly";
			}
		}

		public override string GetChat()
		{
			int nurse = NPC.FindFirstNPC(NPCID.Nurse);
			int witchDoctor = NPC.FindFirstNPC(NPCID.WitchDoctor);
			
			if(Main.bloodMoon == true)
			{
				switch (Main.rand.Next(1))
				{
				case 0:
					return "Lovely night, isn't it?";
				default:
					return "I hope the constant arguing I'm hearing isn't my fault.";
				}
			}
			
			if(BirthdayParty.PartyIsUp == true)
			{
				return "I don't know what everyone's so happy about, but as long as nobody mistakes me for a Pigronata, I'm happy too.";
			}
			
			if (nurse >= 0 && Main.rand.Next(19) == 0)
			{
				return "Whenever we're alone, " + Main.npc[nurse].GivenName + " keeps throwing syringes at me, no matter how many times I tell her to stop!";
			}
			
			if (witchDoctor >= 0 && Main.rand.Next(18) == 0)
			{
				return "Please go tell " + Main.npc[witchDoctor].GivenName + " to drop the 'mystical' shtick, I mean, come on! I get it, you make tainted water or something.";
			}
			
			if(Main.dayTime != true && Main.rand.Next(8) == 0)
			{
				return "I'd follow and help, but I'd much rather sit around right now.";
			}
			
			
			switch (Main.rand.Next(16))
			{
				case 0:
					return "Savagery, barbarism, bloodthirst, that's what I like seeing in people.";
				case 1:
					return "The stronger you get, the more stuff I sell. Makes sense, right?";
				case 2:
					return "There's something all of you have that I don't... Death perception, I think it's called?";
				case 3:
					return "It would be pretty cool if I could sell a summon for myself...";
				case 4:
					return "The only way to get stronger is to keep buying from me and in bulk too!";
				case 5:
					return "What's that? You want to fight me? ...you're not worthy.";
				case 6:
					return "Don't bother with anyone else, all you'll ever need is right here.";
				case 7:
					return "You're lucky I'm on your side.";
				case 8:
					return "Thanks for the house, I guess.";
				case 9:
					return "Why yes I would love a ham and swiss sandwich.";
				case 10:
					return "Should I start wearing clothes? ...Nah.";
				case 11:
					return "It's not like I can actually use all the gold you're spending.";
				case 12:
					return "Violence for violence is the law of the beast.";
				case 13:
					return "Those guys really need to get more creative. All their first bosses are desert themed!";
				case 14:	
					return "I am proud to be known as the Mutant, but thank Fargo I'm no Abomination";
				default:
					return "Cthulhu's got nothing on me!";
			}
			
		}
		
		public override void SetChatButtons(ref string button, ref string button2)
		{
			
			if(shopnum == 1)
			{
				button = "Pre Hardmode";
			}
			
			else if(shopnum == 2)
			{
				button = "Hardmode";
			}
			
			else 
			{
				button = "Post Moon Lord";
			}
			
			if(Main.hardMode)
			{
			button2 = "Cycle Shop";
			}
		}

		public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if (firstButton)
            {
                shop = true;
			
				if(shopnum == 1)
				{
					shop1 = true;
					shop2 = false;
					shop3 = false;
				}
			
				else if(shopnum == 2)
				{
					shop2 = true;
					shop1 = false;
					shop3 = false;
				}
			
				else 
				{
					shop3 = true;
					shop1 = false;
					shop2 = false;
				}
            }
			
			if (!firstButton && Main.hardMode)
			{
                shopnum++;
                
				if(shopnum == 4)
				{
					shopnum = 1;
				}
			}
        }

		public override void SetupShop(Chest shop, ref int nextSlot)
		{
			if (shop1 == true)
			{        
				//PREHARDMODE BOSSES
				
						shop.item[nextSlot].SetDefaults(mod.ItemType("Overloader"));
						shop.item[nextSlot].value=500000;
						nextSlot++;
				
						shop.item[nextSlot].SetDefaults(mod.ItemType("PandorasBox"));
						shop.item[nextSlot].value=200000;
						nextSlot++;
				
				if (Fargowiltas.instance.ersionLoaded)
				{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Ersion").ItemType("SlimyFood"));
						shop.item[nextSlot].value=10000;
						nextSlot++;
				}
				
				if (ModLoader.GetLoadedMods().Contains("Exodus"))
				{
					if(ExodusDownedAbom)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Exodus").ItemType("ZombieMeat"));
						shop.item[nextSlot].value=20000;
						nextSlot++;
					}
				}
				
				if (Fargowiltas.instance.thoriumLoaded)
				{
					if(ThoriumModDownedThunderBird)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("ThoriumMod").ItemType("StormFlare"));
						shop.item[nextSlot].value=20000;
						nextSlot++;
					}
				}
				
				if (Fargowiltas.instance.spiritLoaded)
				{
					if(SpiritDownedScarab)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("SpiritMod").ItemType("ScarabIdol"));
						shop.item[nextSlot].value=10000;
						nextSlot++;
					}
				}
			
				if (NPC.downedSlimeKing == true)
				{
						shop.item[nextSlot].SetDefaults(mod.ItemType("SlimyCrown"));
						shop.item[nextSlot].value=30000;
						nextSlot++;
				} 
				
				if (ModLoader.GetLoadedMods().Contains("Exodus"))
				{
					if(ExodusDownedBlob)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Exodus").ItemType("DisgustingJelly"));
						shop.item[nextSlot].value=30000;
						nextSlot++;
					}
				}
				
				if(Fargowiltas.instance.gabeLoaded)
				{
					if(GabeModDownedMurk)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("GabeHasWonsMod").ItemType("MudGel"));
						shop.item[nextSlot].value=30000;
						nextSlot++;
					}
				}
			
				if (Fargowiltas.instance.calamityLoaded)
				{
					if(CalamityModDownedDesertScourge)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("DriedSeafood"));;
						shop.item[nextSlot].value=60000;
						nextSlot++;
					}
				}
			
				if (NPC.downedBoss1 == true)
				{			 
						shop.item[nextSlot].SetDefaults(mod.ItemType("SuspiciousEye"));
						shop.item[nextSlot].value=50000;
						nextSlot++;
					
					if(Fargowiltas.instance.w1kLoaded)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("W1KModRedux").ItemType("GoldenFeather"));
						shop.item[nextSlot].value=50000;
						nextSlot++;
					}
					
				}
				
				if (ModLoader.GetLoadedMods().Contains("Exodus"))
				{
					if(ExodusDownedColoss)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Exodus").ItemType("GraniteAnomaly"));
						shop.item[nextSlot].value=40000;
						nextSlot++;
					}
					
					if(ExodusDownedEmperor)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Exodus").ItemType("AncientArtifact"));
						shop.item[nextSlot].value=40000;
						nextSlot++;
					}
				}
				
				if (Fargowiltas.instance.tremorLoaded)
				{
					if(TremorDownedRukh)
					{
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("DesertCrown"));
					shop.item[nextSlot].value=50000;
					nextSlot++;
					}
				}
				
				if (Fargowiltas.instance.calamityLoaded)
				{					
					if(CalamityModDownedCrab)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("DecapoditaSprout"));;
						shop.item[nextSlot].value=70000;
						nextSlot++;
					}
				}

				if(Fargowiltas.instance.btfaLoaded)
				{
					if(BtfaGhastly)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("ForgottenMemories").ItemType("AncientLog"));
						shop.item[nextSlot].value=50000;
						nextSlot++;
					}
				}
			
				if (NPC.downedBoss2 == true)
				{
						shop.item[nextSlot].SetDefaults(mod.ItemType("WormyFood"));
						shop.item[nextSlot].value=60000;
						nextSlot++;
			
						shop.item[nextSlot].SetDefaults(mod.ItemType("GoreySpine"));
						shop.item[nextSlot].value=60000;
						nextSlot++;
			
					if (Fargowiltas.instance.cookieLoaded)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CookieMod").ItemType("BloodyCookie"));
						shop.item[nextSlot].value=60000;
						nextSlot++;
		
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CookieMod").ItemType("CursedCookie"));
						shop.item[nextSlot].value=60000;
						nextSlot++;
					}
				}
				
				
					
				if(Fargowiltas.instance.tremorLoaded)
				{
					if(TremorDownedTotem)
					{
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("MysteriousDrum"));
					shop.item[nextSlot].value=50000;
					nextSlot++;
					}
					
					if(TremorDownedCorn)
					{
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("CursedPopcorn"));
					shop.item[nextSlot].value=50000;
					nextSlot++;
					}
					
					if(TremorDownedJelly)
					{
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("StormJelly"));
					shop.item[nextSlot].value=60000;
					nextSlot++;
					}
				}
				
				if (Fargowiltas.instance.thoriumLoaded)
				{
					if(ThoriumModDownedJelly)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("ThoriumMod").ItemType("JellyfishResonator"));
						shop.item[nextSlot].value=60000;
						nextSlot++;
					}
				}
				
				if(Fargowiltas.instance.tremorLoaded)
				{
					if(TremorDownedDragon)
					{
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("RustyLantern"));
					shop.item[nextSlot].value=70000;
					nextSlot++;
					}
				}
				
				if (Fargowiltas.instance.spiritLoaded)
				{
					if (SpiritDownedVine)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("SpiritMod").ItemType("ReachBossSummon"));
						shop.item[nextSlot].value = 70000;
						nextSlot++;
					}
				}
			
				if (Fargowiltas.instance.shroomsLoaded)
				{
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Shrooms").ItemType("SLM"));
					shop.item[nextSlot].value=60000;
					nextSlot++;
				}
				
				if (NPC.downedQueenBee == true)
                {
                    shop.item[nextSlot].SetDefaults(mod.ItemType("Abeemination2"));
                    shop.item[nextSlot].value=90000;
                    nextSlot++;
                }

				if((NPC.downedBoss3 == true) && (NPC.downedQueenBee == true))
				{
					if (Fargowiltas.instance.nightmaresLoaded)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("TrueEater").ItemType("SpitterSpawner"));
						shop.item[nextSlot].value=70000;
						nextSlot++;
					}
				}

                if (Fargowiltas.instance.spiritLoaded)
                {
                    if(SpiritDownedAncientFlier)
                    {
                        shop.item[nextSlot].SetDefaults(ModLoader.GetMod("SpiritMod").ItemType("JewelCrown"));
                        shop.item[nextSlot].value=70000;
                        nextSlot++;
                    }        
                }
				
				if(Fargowiltas.instance.grealmLoaded)
				{
					if(GRealmDownedFolivine)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("GRealm").ItemType("JungleBait"));
						shop.item[nextSlot].value=70000;
						nextSlot++;
					}
				}
				
				if (Fargowiltas.instance.calamityLoaded)
				{
					if((CalamityModDownedPerforator == true) || (CalamityModDownedHiveMind))
					{
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("BloodyWormFood"));
					shop.item[nextSlot].value=150000;
					nextSlot++;
			
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("Teratoma"));
					shop.item[nextSlot].value=150000;
					nextSlot++;
					}
				}
			
				if (NPC.downedBoss3 == true)
				{
						shop.item[nextSlot].SetDefaults(mod.ItemType("SuspiciousSkull"));
						shop.item[nextSlot].value=80000;
						nextSlot++;
				}
				
				if (ModLoader.GetLoadedMods().Contains("Exodus"))
				{
					if(ExodusDownedHive)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Exodus").ItemType("VineSerpent"));
						shop.item[nextSlot].value=80000;
						nextSlot++;
					}
				}
				
				if (Fargowiltas.instance.spiritLoaded)
				{
					if (SpiritDownedRaider)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("SpiritMod").ItemType("StarWormSummon"));
						shop.item[nextSlot].value = 80000;
						nextSlot++;
					}
				}
				
				if(Fargowiltas.instance.tremorLoaded)
				{
					if(TremorDownedFungus)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("MushroomCrystal"));
						shop.item[nextSlot].value=70000;
						nextSlot++;
					}
				}
				
				if (Fargowiltas.instance.thoriumLoaded)
				{
					if(ThoriumModDownedStorm)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("ThoriumMod").ItemType("UnstableCore"));
						shop.item[nextSlot].value=80000;
						nextSlot++;
					}
					
					if(ThoriumModDownedChampion)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("ThoriumMod").ItemType("AncientBlade"));
						shop.item[nextSlot].value=80000;
						nextSlot++;
					}
				}
				
				if (Fargowiltas.instance.sacredToolsLoaded)
				{
					if(SacredToolsDownedHarpy)
					{
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("SacredTools").ItemType("HarpySummon"));
					shop.item[nextSlot].value=60000;
					nextSlot++;
					}
				}	
					
				if(Fargowiltas.instance.tremorLoaded)
				{
					if(TremorDownedHeater)
					{
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("MoltenHeart"));
					shop.item[nextSlot].value=80000;
					nextSlot++;
					}
				}
			
				if (Fargowiltas.instance.thoriumLoaded)
				{
					if (ThoriumModDownedScout)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("ThoriumMod").ItemType("StarCaller"));
						shop.item[nextSlot].value=80000;
						nextSlot++;
					}
				}
				
				if (Fargowiltas.instance.calamityLoaded)
				{
						if(CalamityModDownedSlimeGod)
						{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("OverloadedSludge"));
						shop.item[nextSlot].value=250000;
						nextSlot++;
						}
				}
				
				if(Fargowiltas.instance.w1kLoaded)
				{
					if(Main.hardMode)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("W1KModRedux").ItemType("FieryEgg"));
						shop.item[nextSlot].value=150000;
						nextSlot++;
						
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("W1KModRedux").ItemType("GrassyEgg"));
						shop.item[nextSlot].value=150000;
						nextSlot++;
						
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("W1KModRedux").ItemType("WateryEgg"));
						shop.item[nextSlot].value=150000;
						nextSlot++;
					}
				}
				
				if(Main.hardMode)
				{
						shop.item[nextSlot].SetDefaults(mod.ItemType("FleshyDoll"));
						shop.item[nextSlot].value=120000;
						nextSlot++;
						
					if ((NPC.downedBoss1 == true) && (NPC.downedBoss2 == true) && (NPC.downedBoss3 == true) && (Main.hardMode == true) && (NPC.downedQueenBee == true) && (NPC.downedSlimeKing == true))
					{	
						shop.item[nextSlot].SetDefaults(mod.ItemType("DeathBringerFairy"));
						shop.item[nextSlot].value=160000;
						nextSlot++;
					}
				}
			}
		
		else if(shop2 == true)
		{			
			
			//HARDMODE BOSSES
			
				//if(Fargowiltas.instance.btfaLoaded)
				//{
					//if(BtfaArtery)
					//{
						//shop.item[nextSlot].SetDefaults(ModLoader.GetMod("ForgottenMemories").ItemType("BloodClot"));
					//	shop.item[nextSlot].value=60000;
					//	nextSlot++;
					//}
				//}
			
				if (ModLoader.GetLoadedMods().Contains("Exodus"))
				{
					if(ExodusDownedMaster)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Exodus").ItemType("GlowingSkull"));
						shop.item[nextSlot].value=100000;
						nextSlot++;
					}
				}
			
				if (Fargowiltas.instance.thoriumLoaded)
				{
						if(ThoriumModDownedStrider)
						{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("ThoriumMod").ItemType("StriderTear"));
						shop.item[nextSlot].value=100000;
						nextSlot++;
						}
				}
				
				if (Fargowiltas.instance.thoriumLoaded)
				{
					if(ThoriumModDownedFallenBeholder)
					{
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("ThoriumMod").ItemType("VoidLens"));
					shop.item[nextSlot].value=150000;
					nextSlot++;
					}
				}
			
				if (Fargowiltas.instance.calamityLoaded)
				{
					if(CalamityModDownedCryogen)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("CryoKey"));
						shop.item[nextSlot].value=350000;
						nextSlot++;
					}
				}
				
				if (Fargowiltas.instance.spiritLoaded)
				{
					if(SpiritDownedInfer)
					{
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("SpiritMod").ItemType("CursedCloth"));
					shop.item[nextSlot].value=90000;
					nextSlot++;
					}
				}
				
				if(Fargowiltas.instance.tremorLoaded)
				{
					if(TremorDownedAlchemaster)
					{
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("AncientMosaic"));
					shop.item[nextSlot].value=120000;
					nextSlot++;
					}
				}
			
			 if (NPC.downedMechBossAny)
                {				
					if (Fargowiltas.instance.ersionLoaded)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Ersion").ItemType("SuspiciousLookingGel"));
						shop.item[nextSlot].value=120000;
						nextSlot++;
						
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Ersion").ItemType("SuspiciousLookingChip"));
						shop.item[nextSlot].value=120000;
						nextSlot++;
					}
					
					if (Fargowiltas.instance.nightmaresLoaded)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("TrueEater").ItemType("MechaSpine"));
						shop.item[nextSlot].value=120000;
						nextSlot++;
						
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("TrueEater").ItemType("DroneSignal"));
						shop.item[nextSlot].value=120000;
						nextSlot++;
					}
					
					if(Fargowiltas.instance.w1kLoaded)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("W1KModRedux").ItemType("CursedFlower"));
						shop.item[nextSlot].value=210000;
						nextSlot++;
						
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("W1KModRedux").ItemType("BloodySkull"));
						shop.item[nextSlot].value=380000;
						nextSlot++;
					}					
				}
				
				if(Fargowiltas.instance.btfaLoaded)
				{
					if(BtfaTitan)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("ForgottenMemories").ItemType("anomalydetector"));
						shop.item[nextSlot].value=100000;
						nextSlot++;
					}
				}
			
			if (NPC.downedMechBoss1 == true)
			{	
						shop.item[nextSlot].SetDefaults(mod.ItemType("MechWorm"));
						shop.item[nextSlot].value=120000;
						nextSlot++;
			}
			
			if (NPC.downedMechBoss2 == true)
			{	
						shop.item[nextSlot].SetDefaults(mod.ItemType("MechEye"));
						shop.item[nextSlot].value=120000;
						nextSlot++;
			}
			
			if (NPC.downedMechBoss3 == true)
			{	
						shop.item[nextSlot].SetDefaults(mod.ItemType("MechSkull"));
						shop.item[nextSlot].value=120000;
						nextSlot++;
			}
			
			if (Fargowiltas.instance.tremorLoaded)
			{
				if(TremorDownedMotherboard)
				{
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("MechanicalBrain"));
					shop.item[nextSlot].value=120000;
					nextSlot++;
				}
			}
			
			if ((NPC.downedMechBoss1 == true) && (NPC.downedMechBoss2 == true) && (NPC.downedMechBoss3 == true))
			{	
						shop.item[nextSlot].SetDefaults(mod.ItemType("MechanicalAmalgam"));
						shop.item[nextSlot].value=200000;
						nextSlot++;
				
				if(Fargowiltas.instance.w1kLoaded)
				{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("W1KModRedux").ItemType("MysteryTicket"));
						shop.item[nextSlot].value=380000;
						nextSlot++;
						
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("W1KModRedux").ItemType("MetroidCapsule"));
						shop.item[nextSlot].value=380000;
						nextSlot++;
						
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("W1KModRedux").ItemType("OminousMask"));
						shop.item[nextSlot].value=400000;
						nextSlot++;
				}	
			}
			
			if (Fargowiltas.instance.spiritLoaded)
				{
					if(SpiritDownedDusking)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("SpiritMod").ItemType("DuskCrown"));
						shop.item[nextSlot].value=100000;
						nextSlot++;
					}
					
					if(SpiritDownedUmbra)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("SpiritMod").ItemType("UmbraSummon"));
						shop.item[nextSlot].value=100000;
						nextSlot++;
					}
				}

			if (Fargowiltas.instance.calamityLoaded)
			{
				if(CalamityModDownedBrimstone)
				{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("CharredIdol"));
						shop.item[nextSlot].value=140000;
						nextSlot++;
				}
			}	
				
			if (Fargowiltas.instance.tremorLoaded)
			{
				if(TremorDownedPixie)
				{
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("PixieinaJar"));
					shop.item[nextSlot].value=120000;
					nextSlot++;
				}
			}
				
			if (Fargowiltas.instance.thoriumLoaded)
			{
					if(ThoriumModDownedLich)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("ThoriumMod").ItemType("LichCatalyst"));
						shop.item[nextSlot].value=150000;
						nextSlot++; 
					}
			}
			
			 if (Fargowiltas.instance.sacredToolsLoaded)
			 {
				 if(SacredToolsDownedRaynare)
				 {
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("SacredTools").ItemType("HarpySummon2"));
						shop.item[nextSlot].value=140000;
						nextSlot++;
				 }
             }

			if (Fargowiltas.instance.spiritLoaded)
			{
				if(SpiritDownedIlluminant)
				{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("SpiritMod").ItemType("ChaosFire"));
						shop.item[nextSlot].value=120000;
						nextSlot++;
				}
			}		
				
			if (Fargowiltas.instance.calamityLoaded)
			{
				if(CalamityModDownedCalamitas)
				{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("BlightedEyeball"));
						shop.item[nextSlot].value=1000000;
						nextSlot++;
				}
			}
			
			if (NPC.downedPlantBoss == true)
			{	
						shop.item[nextSlot].SetDefaults(mod.ItemType("Plantera"));
						shop.item[nextSlot].value=150000;
						nextSlot++;
			
				if (Fargowiltas.instance.nightmaresLoaded)
				{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("TrueEater").ItemType("MimicKey"));
						shop.item[nextSlot].value= (ModLoader.GetMod("TrueEater").ItemType("MimicKey"));
						nextSlot++;
				}
			}
			
			if (ModLoader.GetLoadedMods().Contains("Exodus"))
				{
					if(ExodusDownedHeart)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Exodus").ItemType("JungleCrown"));
						shop.item[nextSlot].value=120000;
						nextSlot++;
					}
				}
			
			if (Fargowiltas.instance.tremorLoaded)
				{
					if(TremorDownedFrostKing)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("FrostCrown"));
						shop.item[nextSlot].value=120000;
						nextSlot++;
					}
					
                }
			
			if (Fargowiltas.instance.calamityLoaded)
			{
				if(CalamityModDownedLeviathan)
				{
						shop.item[nextSlot].SetDefaults(mod.ItemType("LeviathanSummon"));
						shop.item[nextSlot].value=400000;
						nextSlot++;
				}
			}
			
			if (Fargowiltas.instance.tremorLoaded)
				{
					if(TremorDownedWall)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("ShadowRelic"));
						shop.item[nextSlot].value=120000;
						nextSlot++;
					}
					
                }
			
			/*if (Fargowiltas.instance.calamityLoaded)
			{
				if(CalamityModDownedAstrum)
				{
						shop.item[nextSlot].SetDefaults(mod.ItemType("Starcore"));
						shop.item[nextSlot].value=400000;
						nextSlot++;
				}
			}*/
			
			if (NPC.downedGolemBoss == true)
			{	
						shop.item[nextSlot].SetDefaults(mod.ItemType("LihzahrdPowerCell2"));
						shop.item[nextSlot].value=160000;
						nextSlot++;
			}
			
			if(FargoWorld.downedBetsy == true)
			{
						shop.item[nextSlot].SetDefaults(mod.ItemType("BetsyEgg"));
						shop.item[nextSlot].value=160000;
						nextSlot++;
			}
			
			if (Fargowiltas.instance.tremorLoaded)
				{
					if(TremorDownedCogLord)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("ArtifactEngine"));
						shop.item[nextSlot].value=120000;
						nextSlot++;
					}
                }
			
			if (Fargowiltas.instance.thoriumLoaded == true)
			{
					if(ThoriumModDownedAbyssion)
					{
						shop.item[nextSlot].SetDefaults(mod.ItemType("AbyssionSummon"));
						shop.item[nextSlot].value=150000;
						nextSlot++;
					}
			}
			
			if (Fargowiltas.instance.calamityLoaded)
				{	
					if(CalamityModDownedPlaguebringer)	
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("Abomination"));
						shop.item[nextSlot].value=2000000;
						nextSlot++;
					}
				}
			
			if (Fargowiltas.instance.tremorLoaded)
			{
					if(TremorDownedCyberKing)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("AdvancedCircuit"));
						shop.item[nextSlot].value=150000;
						nextSlot++;
					}
			}
			
			if (ModLoader.GetLoadedMods().Contains("CrystiliumMod"))
				{
					if(CrystiliumDownedKing)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CrystiliumMod").ItemType("CrypticCrystal"));
						shop.item[nextSlot].value=120000;
						nextSlot++;
					}
				}
				
				if (Fargowiltas.instance.calamityLoaded)
				{	
					if(CalamityModDownedRavager)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("AncientMedallion"));
						shop.item[nextSlot].value=2200000;
						nextSlot++;
					}
				}
			
			if (NPC.downedFishron == true)
			{	
						shop.item[nextSlot].SetDefaults(mod.ItemType("TruffleWorm2"));
						shop.item[nextSlot].value=150000;
						nextSlot++;
			
				
			
				if (ModLoader.GetLoadedMods().Contains("WaterBiomeMod"))
				{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("WaterBiomeMod").ItemType("SeaConch"));
						shop.item[nextSlot].value=2000000;
						nextSlot++;
				}
			}
			
			if (ModLoader.GetLoadedMods().Contains("Pumpking"))
			{
				if(PumpkingDownedPumpkinHorse)
				{
                        shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Pumpking").ItemType("PumpkingSoul"));
						shop.item[nextSlot].value=160000;
						nextSlot++;
				}							
			}
			
			if (Fargowiltas.instance.spiritLoaded)
			{
				if(SpiritDownedAtlas)
				{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("SpiritMod").ItemType("StoneSkin"));
						shop.item[nextSlot].value=150000;
						nextSlot++;
				}
			}	

				if (Fargowiltas.instance.blueMagicLoaded)
				{
					if(BlueDownedPhantom)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Bluemagic").ItemType("PaladinEmblem"));
						shop.item[nextSlot].value=180000;
						nextSlot++;
					}
                }

				if (Fargowiltas.instance.blueMagicLoaded)
				{
					if(BlueDownedAbom)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Bluemagic").ItemType("FoulOrb"));
						shop.item[nextSlot].value=250000;
						nextSlot++;
					}
                }
			
			if (NPC.downedMoonlord == true)
			{	
						shop.item[nextSlot].SetDefaults(mod.ItemType("CelestialSigil2"));
						shop.item[nextSlot].value=250000;
						nextSlot++;
						
						shop.item[nextSlot].SetDefaults(mod.ItemType("MutantVoodoo"));
						shop.item[nextSlot].value=500000;
						nextSlot++;
			}
		}
		
		else
		{
			
			if (Fargowiltas.instance.tremorLoaded)
			{
					if(TremorDownedDarkEmperor)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("EmperorCrown"));
						shop.item[nextSlot].value=200000;
						nextSlot++;
					}
			}
			
			if (Fargowiltas.instance.spiritLoaded)
			{
				if(SpiritDownedOverseer)
				{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("SpiritMod").ItemType("SpiritIdol"));
						shop.item[nextSlot].value=200000;
						nextSlot++;
				}
			}	
			
			if(Fargowiltas.instance.ancientsLoaded)
			{
				if(AncientsDownedWorms)
				{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("EchoesoftheAncients").ItemType("Wyrm_Rune"));
						shop.item[nextSlot].value=1000000;
						nextSlot++;
				}
			}
			
			if (Fargowiltas.instance.tremorLoaded)
			{
					if(TremorDownedBrutallisk)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("RoyalEgg"));
						shop.item[nextSlot].value=200000;
						nextSlot++;
					}
			}

			if (ModLoader.GetLoadedMods().Contains("Pumpking"))
			{
				if(PumpkingDownedTerraLord)
				{
                        shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Pumpking").ItemType("TerraCore"));
						shop.item[nextSlot].value=500000;
						nextSlot++;
				}
							
			}
			
			if (Fargowiltas.instance.sacredToolsLoaded)
			{
				if(SacredToolsDownedAbaddon)
				{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("SacredTools").ItemType("ShadowWrathSummonItem"));
						shop.item[nextSlot].value=200000;
						nextSlot++;
				}
            }
			
			if (Fargowiltas.instance.calamityLoaded)
			{
				if(CalamityModDownedGuardian)
				{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("ProfanedShard"));
						shop.item[nextSlot].value=3000000;
						nextSlot++;
				}
			}
			
			if (Fargowiltas.instance.tremorLoaded)
			{
					if(TremorDownedWhale)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("CosmicKrill"));
						shop.item[nextSlot].value=200000;
						nextSlot++;
					}
			}
			
			if (Fargowiltas.instance.joostLoaded)
			{
				if(JoostDownedCactuar)
				{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("JoostMod").ItemType("Cactusofdoom"));
						shop.item[nextSlot].value=2000000;
						nextSlot++;
				}
			}
			
			 if (Fargowiltas.instance.tremorLoaded)
			{
					if(TremorDownedTrinity)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("StoneofKnowledge"));
						shop.item[nextSlot].value=250000;
						nextSlot++;
					}
			}
			
			if (Fargowiltas.instance.thoriumLoaded == true)
			{
					if(ThoriumModDownedRealityBreaker)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("ThoriumMod").ItemType("RagSymbol"));
						shop.item[nextSlot].value=400000;
						nextSlot++;
					}
			}
			
			if (Fargowiltas.instance.tremorLoaded)
			{
					if(TremorDownedAndas)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("InfernoSkull"));
						shop.item[nextSlot].value=300000;
						nextSlot++;
					}
			}
			
			if (Fargowiltas.instance.calamityLoaded)
			{
				if(CalamityModDownedProvidence)
				{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("ProfanedCore"));
						shop.item[nextSlot].value=4000000;
						nextSlot++;
				}
			}
			
			 if (Fargowiltas.instance.sacredToolsLoaded)
             {
				if (SacredToolsDownedSerpent)
                {
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("SacredTools").ItemType("SerpentSummon"));
						shop.item[nextSlot].value=1000000;
						nextSlot++;
                }
			 }
			 
			  if (Fargowiltas.instance.joostLoaded)
            {
                if (JoostDownedSAX)
                {
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("JoostMod").ItemType("InfectedArmCannon"));
						shop.item[nextSlot].value=2000000;
						nextSlot++;
				}
            }
			
			 if (Fargowiltas.instance.sacredToolsLoaded)
             {
				if (SacredToolsDownedLunarians)
                {
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("SacredTools").ItemType("MoonEmblem"));
						shop.item[nextSlot].value=2000000;
						nextSlot++;
                }
			 }
			 
			 if (Fargowiltas.instance.calamityLoaded)
				{
					if(CalamityModDownedPolter)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("NecroplasmicBeacon"));
						shop.item[nextSlot].value=4000000;
						nextSlot++;
					}
				}
			 
			 if (Fargowiltas.instance.joostLoaded)
			{
				if(JoostDownedSAX)
				{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("JoostMod").ItemType("Excalipoor"));
						shop.item[nextSlot].value=10000000;
						nextSlot++;
				}
			}
			
			 	if (Fargowiltas.instance.calamityLoaded)
				{
					if(CalamityModDownedDOG)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("CosmicWorm"));
						shop.item[nextSlot].value=5000000;
						nextSlot++;
					}
				}
				
			//spirit of purity 
			 
			if (Fargowiltas.instance.calamityLoaded)
				{
					if(CalamityModDownedBirb)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("BirbPheromones"));
						shop.item[nextSlot].value=5000000;
						nextSlot++;
					}
				}
			
			if (Fargowiltas.instance.calamityLoaded)
             {
				if (CalamityModDownedYharon)
				{	
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("ChickenEgg"));
						shop.item[nextSlot].value=8000000;
						nextSlot++;
				}
			 }
			
			if (Fargowiltas.instance.calamityLoaded)
             {
				if (CalamityModDownedSCal)
				{	
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("EyeofExtinction"));
						shop.item[nextSlot].value=50000000;
						nextSlot++;
				}
			 }
			 
			 //spirit of chaos
			
			 if ((NPC.downedBoss1 == true) && (NPC.downedBoss2 == true) && (NPC.downedBoss3 == true) && (Main.hardMode == true) && (NPC.downedQueenBee == true) && (NPC.downedSlimeKing == true) && (NPC.downedMechBoss1 == true) && (NPC.downedMechBoss2 == true) && (NPC.downedMechBoss3 == true) && (NPC.downedGolemBoss == true) && (NPC.downedPlantBoss == true) && (NPC.downedFishron == true) && (NPC.downedMoonlord == true))
			{	
						shop.item[nextSlot].SetDefaults(mod.ItemType("AncientSeal"));
						shop.item[nextSlot].value=10000000;
						nextSlot++;
			}
				
		}
	}
	

		public override void TownNPCAttackStrength(ref int damage, ref float knockback)
		{
			if (NPC.downedMoonlord)
			{
				damage = 500;
				knockback = 10f;
			}
			else if (Main.hardMode)
			{
				damage = 60;
				knockback = 5f;
			}
			else
			{
				damage = 20;
				knockback = 4f;
			}
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
		{
			if (NPC.downedMoonlord == true)
			{
				cooldown = 1;
				//randExtraCooldown = 1;
			}
			else if (Main.hardMode == true)
			{
				cooldown = 20;
				randExtraCooldown = 25;
			}
			else
			{
				cooldown = 30;
				randExtraCooldown = 30;
			}
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
		{
			if (NPC.downedMoonlord == true)
			{
				projType = mod.ProjectileType("PhantasmalEyeProjectile");
				attackDelay = 1;
			}
			else if (Main.hardMode == true)
			{
				projType = mod.ProjectileType("MechEyeProjectile");
				attackDelay = 1;
			}
			else
			{
				projType = mod.ProjectileType("EyeProjectile");
				attackDelay = 1;
			}
		}

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
		{
			multiplier = 12f;
			randomOffset = 2f;
		}	
		
		public override void NPCLoot()
        {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("grabbag"));
        }
	}	
}


/*


"You try talking to [Guide] without him cowering in fear. I dare you."

I heard you liked fighting sealed bosses(reference to the ancient seal)

you want to fight me you say? You're not worthy you rat 

now that you defeated the big guy I'd say it's time to start collecting those materials;)

"You did all of this before, so make sure you don't fail."

it's clear I'm helping you out but uh what's in this for me? A house you say? I eat zombies for breakfast.  Something something something

"I really don't trust [Chef]... I don't know, I'm just saying."

I'm all you need for a calamity

oh is that a soul of the universe? Fascinating I'll get all mine from the back

Oh wow is that a speed soul. I coulda sold you one man

//all souls need one

"I know, I know, these souls look really pricy, buy I'm selling them at a loss here! Nobody would buy them otherwise! What a ripoff!"

Why does that cyborg guy even exist

You Are not my master guide is

The truffle guy said i could call him truffles... That reminds me of some guy i used to know

why does the dryads outfit make my wings flutter

"everything shall bow before me!... after you make this purchase"

[Stylist] once gave me a wig... I look hideous with long hair"

That mutated mushroom seems like my type of fella

That [tax collector name here] keeps asking me for money but he dosen't acept my spawners

"You are satan"
"You arent worthy,you fuckn rat"

"If any of us could play any instruments, I'd totally make a band with [Witch Docotoro], [Truffle] and [Cyborg]."

'The guide puts me off.. His exterior seems demonic.'

*/

>>>>>>> 66ed39caf4938fca8e7009752b635e42f8a8a58f
