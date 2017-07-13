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
	public class Abominationn : ModNPC
	{
		public override string Texture
		{
			get
			{
				return "Fargowiltas/NPCs/Abominationn";
			}
		}	
	
		public override bool Autoload(ref string name)
		{
			name = "Abominationn";
			return mod.Properties.Autoload;
		}
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Abominationn");
			Main.npcFrameCount[npc.type] = 25;
			NPCID.Sets.ExtraFramesCount[npc.type] = 9;
			NPCID.Sets.AttackFrameCount[npc.type] = 4;
			NPCID.Sets.DangerDetectRange[npc.type] = 700;
			NPCID.Sets.AttackType[npc.type] = 0;
			NPCID.Sets.AttackTime[npc.type] = 90;
			NPCID.Sets.AttackAverageChance[npc.type] = 30;
			NPCID.Sets.HatOffsetY[npc.type] = 2;
		}
		public override void SetDefaults()
		{
			npc.townNPC = true;
			npc.friendly = true;
			npc.width = 40;
			npc.height = 40;
			npc.aiStyle = 7;
			npc.damage = 10;
			npc.defense = 15;
			npc.lifeMax = 250;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.knockBackResist = 0.5f;
			animationType = NPCID.Guide;
		}
		
		public bool GRealmDownedZombies
		{
			get { return GRealm.MWorld.downedZombieInvasion; }
		}

		public override bool CanTownNPCSpawn(int numTownNPCs, int money)
		{
			 if (NPC.downedGoblins == true)
            {
                return true;
            }    
			return false;
		}
		
		public override string TownNPCName()
		{
			switch (WorldGen.genRand.Next(5))
			{
				case 0:
					return "Wilta";
				case 1:
					return "Jack";
				case 2:
					return "Harley";
				case 3:
					return "Reaper";
				default:
					return "Betson";
			}
		}

		public override string GetChat()
		{
			
			int mutant = NPC.FindFirstNPC(mod.NPCType("Mutant"));
			if (mutant >= 0 && Main.rand.Next(7) == 0)
			{
				return "That one guy, " + Main.npc[mutant].GivenName + ", he is my brother... I've fought more bosses than him.";
			}
			switch (Main.rand.Next(6))
			{
				
				case 0:
					return "I have defeated everything in this land... nothing can beat me.";
				case 1:
					return "Have you ever had a weapon stuck to your hand? It's not very handy.";
				case 2:
					return "What happened to Yoramur? No idea who you're talking about.";
				case 3:
					return "I sure wish I was a boss.";
				case 4:
					return "You wish you could dress like me? Ha! Maybe in 2018.";
				default:
					return "I have slain one thousand humans! Huh? You're a human? There's so much blood on your hands..";
			}
		}

		public override void SetChatButtons(ref string button, ref string button2)
		{
			button = Lang.inter[28].Value;
			
			//button2 = "Trade Trophy";
		}

		public override void OnChatButtonClicked(bool firstButton, ref bool shop)
		{
			if (firstButton)
			{
				shop = true;
			}
			
		}

		public override void SetupShop(Chest shop, ref int nextSlot)
		{
			//EVENTS
	
			if (ModLoader.GetLoadedMods().Contains("ThoriumMod"))
            {
				if (NPC.downedBoss1 == true)
                {
                    shop.item[nextSlot].SetDefaults(ModLoader.GetMod("ThoriumMod").ItemType("BloodMoonMedallion"));
                    shop.item[nextSlot].value=20000;
                    nextSlot++;
               }
		    }
			 
			if (ModLoader.GetLoadedMods().Contains("SacredTools"))
             {
				if (NPC.downedBoss1 == true)
				{
                    shop.item[nextSlot].SetDefaults(ModLoader.GetMod("SacredTools").ItemType("SandstormMedallion"));
                    shop.item[nextSlot].value=20000;
                    nextSlot++;
				}
			 }
			 
			if (ModLoader.GetLoadedMods().Contains("GRealm"))
			{
				if (GRealmDownedZombies)
				{
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("GRealm").ItemType("HordeStaff"));
					shop.item[nextSlot].value = 30000;
					nextSlot++;
				}
			}
	
			shop.item[nextSlot].SetDefaults(ItemID.GoblinBattleStandard);
			shop.item[nextSlot].value=50000;
	     	nextSlot++;
			
			if (Fargowiltas.instance.tremorLoaded)
			{
				if(NPC.downedBoss2)
				{
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("ScrollofUndead"));
					shop.item[nextSlot].value=50000;
					nextSlot++;
				}
			}
			
			 
			/*if (ModLoader.GetLoadedMods().Contains("SpiritMod"))
			{
				if (SpiritMod.MyWorld.downedAncientFlier)
				{
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("SpiritMod").ItemType("BlackPearl"));
					shop.item[nextSlot].value = 60000;
					nextSlot++;
				}
			}*/

			if (Main.hardMode == true)
			{
			shop.item[nextSlot].SetDefaults(ItemID.SnowGlobe);
			shop.item[nextSlot].value=80000;
			nextSlot++;
			}
			
			if (NPC.downedPirates == true)
			{	
			shop.item[nextSlot].SetDefaults(ItemID.PirateMap);
			shop.item[nextSlot].value=100000;
			nextSlot++;
			}
			
			if (NPC.downedGolemBoss == true)
			{	
			shop.item[nextSlot].SetDefaults(ItemID.SolarTablet);
			shop.item[nextSlot].value=100000;
			nextSlot++;
			}
		
			if (NPC.downedMartians == true)
            {
                    shop.item[nextSlot].SetDefaults(mod.ItemType("RunawayProbe"));
                    shop.item[nextSlot].value=100000;
                    nextSlot++;
            }
			
			if (NPC.downedHalloweenKing == true)
			{	
			shop.item[nextSlot].SetDefaults(ItemID.PumpkinMoonMedallion);
			shop.item[nextSlot].value=150000;
			nextSlot++;
			}
			
			if (NPC.downedChristmasIceQueen == true)
			{	
			shop.item[nextSlot].SetDefaults(ItemID.NaughtyPresent);
			shop.item[nextSlot].value=150000;
			nextSlot++;
			}
			
			if (Fargowiltas.instance.tremorLoaded)
			{
				if(NPC.downedMoonlord == true)
				{
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("AncientWatch"));
					shop.item[nextSlot].value=200000;
					nextSlot++;
				}
			}
		
		}

		public override void TownNPCAttackStrength(ref int damage, ref float knockback)
		{
			damage = 20;
			knockback = 4f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
		{
			cooldown = 30;
			randExtraCooldown = 30;
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
		{
			projType = ProjectileID.DeathSickle;
			attackDelay = 1;
		}

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
		{
			multiplier = 12f;
			randomOffset = 2f;
		}
	}
}