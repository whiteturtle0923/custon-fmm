using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Terraria.Localization;


namespace Fargowiltas.NPCs
{
	public class FargoGlobalNPC : GlobalNPC
	{
		public override void SetDefaults (NPC npc)
		{
			if(Fargowiltas.instance.multiSlime && npc.type == NPCID.KingSlime)
			{
				
			}
		}
		
		public override void EditSpawnRate (Player player, ref int spawnRate, ref int maxSpawns)
		{
			FargoPlayer modPlayer = player.GetModPlayer<FargoPlayer>(mod);
			
			if(modPlayer.builderMode)
			{
				//spawnRate = (int)((double)spawnRate * 0.1);
				maxSpawns = (int)((float)maxSpawns * 0f);
			}
			
			if(modPlayer.npcBoost)
			{
				spawnRate = (int)((double)spawnRate * 0.1);
				maxSpawns = (int)((float)maxSpawns * 10f);
			}
			
		}
		
		public override void EditSpawnPool(IDictionary<int, float> pool, NPCSpawnInfo spawnInfo)
		{
			int y = spawnInfo.spawnTileY;
			bool Cavern = (y >= (Main.maxTilesY * 0.4f) && y <= (Main.maxTilesY * 0.8f)); 
			//season enemies
			if(Main.hardMode)
			{
				if(Fargowiltas.NormalSpawn(spawnInfo) && spawnInfo.spawnTileY < Main.worldSurface && !Main.dayTime)
				{
					pool[NPCID.HoppinJack] = .04f;
				}
			
				if(Fargowiltas.NormalSpawn(spawnInfo) && Cavern && Fargowiltas.NoBiome(spawnInfo))
				{
					pool[NPCID.Ghost] = .04f;
				}
				
				if(Fargowiltas.NormalSpawn(spawnInfo) && spawnInfo.spawnTileY < Main.worldSurface && !Main.dayTime)
				{
					pool[NPCID.Raven] = .015f;
				}
			}
			
			else
			{
				if(Fargowiltas.NormalSpawn(spawnInfo) && spawnInfo.spawnTileY < Main.worldSurface && !Main.dayTime)
				{
					pool[NPCID.Raven] = .04f;
				}
			}
			
			if(Fargowiltas.NormalSpawn(spawnInfo) && Fargowiltas.NoBiome(spawnInfo) && spawnInfo.spawnTileY < Main.worldSurface && Main.dayTime)
			{
					pool[NPCID.SlimeRibbonWhite] = .01f;
			}
			if(Fargowiltas.NormalSpawn(spawnInfo) && Fargowiltas.NoBiome(spawnInfo) && spawnInfo.spawnTileY < Main.worldSurface && Main.dayTime)
			{
					pool[NPCID.SlimeRibbonYellow] = .01f;
			}
			if(Fargowiltas.NormalSpawn(spawnInfo) && Fargowiltas.NoBiome(spawnInfo) && spawnInfo.spawnTileY < Main.worldSurface && Main.dayTime)
			{
					pool[NPCID.SlimeRibbonGreen] = .01f;
			}
			if(Fargowiltas.NormalSpawn(spawnInfo) && Fargowiltas.NoBiome(spawnInfo) && spawnInfo.spawnTileY < Main.worldSurface && Main.dayTime)
			{
					pool[NPCID.SlimeRibbonRed] = .01f;
			}
			
			if(Fargowiltas.instance.multiSlime)
            {
				pool[NPCID.KingSlime] = 10f;
			}
			
		
		}
		
		public override bool PreNPCLoot (NPC npc)
		{
			//slime multi
			if(npc.type == NPCID.KingSlime && Fargowiltas.instance.multiSlime)
            {
				Fargowiltas.slimeKills++;
				
				if(Fargowiltas.slimeKills % 100 == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EnergizerSlime"), 1);
				}
				Main.NewText("Killed: " + Fargowiltas.slimeKills.ToString(), 206, 12, 15);
				Main.NewText("Total: " + Fargowiltas.slimeNum.ToString(), 206, 12, 15);
				if(Fargowiltas.slimeKills <= Fargowiltas.slimeNum - Fargowiltas.slimeSpawned) 
				{
					int count = 0;
					for(int i = 0; i < 200; i++)
					{
						if(Main.npc[i].type == NPCID.KingSlime)
						{
							count++;
						}
					}
					int count2 = 0;
					for(int i = 0; i < 200; i++)
					{
						if(Main.npc[i].type == NPCID.BlueSlime || Main.npc[i].type == NPCID.SlimeSpiked)
						{
							Main.npc[i].StrikeNPC(Main.npc[i].lifeMax, 0f, 0);
							NPC.NewNPC((int)npc.position.X + Main.rand.Next(-1000, 1000), (int)npc.position.Y + Main.rand.Next(-800, -400), NPCID.KingSlime);
							count2++;
							if((count2 == Fargowiltas.slimeSpawned - count) || (count > Fargowiltas.slimeSpawned))
							{
								break;
							}
						}
					}
				}
				else if(Fargowiltas.slimeKills >= Fargowiltas.slimeNum )
				{					
					if (Main.netMode == 2) 
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("The swarm has been defeated!"), new Color(206, 12, 15));
					}
					else
					{
						Main.NewText("The swarm has been defeated!", 206, 12, 15);
					}
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.KingSlimeBossBag, Fargowiltas.slimeNum);
					Fargowiltas.instance.multiSlime = false;
				}
				else
				{
					int count = 0;
					for(int i = 0; i < 200; i++)
					{
						if(Main.npc[i].type == NPCID.KingSlime)
						{
							count++;
						}
					}
					if(count < Fargowiltas.slimeNum - Fargowiltas.slimeKills)
					{
						for(int i = 0; i < Fargowiltas.slimeSpawned; i++)
						{
							NPC.NewNPC((int)npc.position.X + Main.rand.Next(-1000, 1000), (int)npc.position.Y + Main.rand.Next(-800, -400), NPCID.KingSlime);
						}
					}
				}
				return false;
			}
			if(Fargowiltas.instance.multiSlime && npc.type == NPCID.BlueSlime)
			{
				return false;
			}
			//eye multi
			if(npc.type == NPCID.EyeofCthulhu && Fargowiltas.instance.multiEye)
			{
				Fargowiltas.eyeKills++;
				
				if(Fargowiltas.eyeKills % 100 == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EnergizerEye"), 1);
				}
				Main.NewText("Killed: " + Fargowiltas.eyeKills.ToString(), 206, 12, 15);
				Main.NewText("Total: " + Fargowiltas.eyeNum.ToString(), 206, 12, 15);
				if(Fargowiltas.eyeKills <= Fargowiltas.eyeNum - Fargowiltas.eyeSpawned)
				{
					NPC.NewNPC((int)npc.position.X + Main.rand.Next(-1000, 1000), (int)npc.position.Y + Main.rand.Next(-600, -200), NPCID.EyeofCthulhu);
				}
				else if(Fargowiltas.eyeKills == Fargowiltas.eyeNum)
				{
					if (Main.netMode == 2) 
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("The swarm has been defeated!"), new Color(206, 12, 15));
					}
					else
					{
						Main.NewText("The swarm has been defeated!", 206, 12, 15);
					}
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.EyeOfCthulhuBossBag, Fargowiltas.eyeNum);
					Fargowiltas.instance.multiEye = false;
				}
				return false;
			}
			//worm multi
			if(npc.type == NPCID.EaterofWorldsHead && Fargowiltas.instance.multiWorm)
			{
				Fargowiltas.wormKills++;
				
				if(Fargowiltas.wormKills % 1000 == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EnergizerWorm"), 1);
				}
				Main.NewText("Killed: " + Fargowiltas.wormKills.ToString(), 206, 12, 15);
				Main.NewText("Total: " + Fargowiltas.wormNum.ToString(), 206, 12, 15);
				if(Fargowiltas.wormKills <= Fargowiltas.wormNum - Fargowiltas.wormSpawned)
				{
					NPC.NewNPC((int)npc.position.X + Main.rand.Next(-1000, 1000), (int)npc.position.Y + Main.rand.Next(300, 600), NPCID.EaterofWorldsHead);
				}
				else if(Fargowiltas.wormKills >= Fargowiltas.wormNum)
				{
					if (Main.netMode == 2) 
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("The swarm has been defeated!"), new Color(206, 12, 15));
					}
					else
					{
						Main.NewText("The swarm has been defeated!", 206, 12, 15);
					}
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.EaterOfWorldsBossBag, Fargowiltas.wormNum);
					Fargowiltas.instance.multiWorm = false;
				}
				else
				{
					int count = 0;
					for(int i = 0; i < 200; i++)
					{
						if(Main.npc[i].type == NPCID.EaterofWorldsHead)
						{
							count++;
						}
					}
					if(count < Fargowiltas.wormNum - Fargowiltas.wormKills)
					{
						for(int i = 0; i < Fargowiltas.wormSpawned; i++)
						{
							NPC.NewNPC((int)npc.position.X + Main.rand.Next(-1000, 1000), (int)npc.position.Y + Main.rand.Next(300, 600), NPCID.EaterofWorldsHead);
						}
					}
				}
				return false;
			}
			if(Fargowiltas.instance.multiWorm && (npc.type == NPCID.EaterofWorldsBody || npc.type == NPCID.EaterofWorldsTail))
			{
				return false;
			}
			//brain multi
			if(npc.type == NPCID.BrainofCthulhu && Fargowiltas.instance.multiBrain)
			{
				Fargowiltas.brainKills++;
				
				if(Fargowiltas.brainKills % 100 == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EnergizerBrain"), 1);
				}
				Main.NewText("Killed: " + Fargowiltas.brainKills.ToString(), 206, 12, 15);
				Main.NewText("Total: " + Fargowiltas.brainNum.ToString(), 206, 12, 15);
				if(Fargowiltas.brainKills <= Fargowiltas.brainNum - Fargowiltas.brainSpawned)
				{
					int count = 0;
					for(int i = 0; i < 200; i++)
					{
						if(Main.npc[i].type == NPCID.BrainofCthulhu)
						{
							count++;
						}
					}
					int count2 = 0;
					for(int i = 0; i < 200; i++)
					{
						if(Main.npc[i].type == NPCID.Creeper)
						{
							Main.npc[i].StrikeNPC(Main.npc[i].lifeMax, 0f, 0);
							NPC.NewNPC((int)npc.position.X + Main.rand.Next(-1000, 1000), (int)npc.position.Y + Main.rand.Next(-800, -400), NPCID.BrainofCthulhu);
							count2++;
							if((count2 == Fargowiltas.brainSpawned - count) || (count > Fargowiltas.brainSpawned))
							{
								break;
							}
						}
					}
				}
				else if(Fargowiltas.brainKills == Fargowiltas.brainNum)
				{	
					if (Main.netMode == 2) 
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("The swarm has been defeated!"), new Color(206, 12, 15));
					}
					else
					{
						Main.NewText("The swarm has been defeated!", 206, 12, 15);
					}
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BrainOfCthulhuBossBag, Fargowiltas.brainNum);
					Fargowiltas.instance.multiBrain = false;
				}
				return false;
			}
			if(Fargowiltas.instance.multiBrain && npc.type == NPCID.Creeper)
			{
				return false;
			}
			//skele multi
			if(npc.type == NPCID.SkeletronHead && Fargowiltas.instance.multiSkele)
			{
				Fargowiltas.skeleKills++;
				
				if(Fargowiltas.skeleKills % 100 == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EnergizerSkele"), 1);
				}
				Main.NewText("Killed: " + Fargowiltas.skeleKills.ToString(), 206, 12, 15);
				Main.NewText("Total: " + Fargowiltas.skeleNum.ToString(), 206, 12, 15);
				if(Fargowiltas.skeleKills <= Fargowiltas.skeleNum - Fargowiltas.skeleSpawned)
				{
					int count = 0;
					for(int i = 0; i < 200; i++)
					{
						if(Main.npc[i].type == NPCID.SkeletronHead)
						{
							count++;
						}
					}
					int count2 = 0;
					for(int i = 0; i < 200; i++)
					{
							NPC.NewNPC((int)npc.position.X + Main.rand.Next(-1000, 1000), (int)npc.position.Y + Main.rand.Next(-500, -100), NPCID.SkeletronHead);
							count2++;
							if((count2 == Fargowiltas.skeleSpawned - count) || (count > Fargowiltas.skeleSpawned))
							{
								break;
							}
					}
				}
				else if(Fargowiltas.skeleKills >= Fargowiltas.skeleNum)
				{
					if (Main.netMode == 2) 
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("The swarm has been defeated!"), new Color(206, 12, 15));
					}
					else
					{
						Main.NewText("The swarm has been defeated!", 206, 12, 15);
					}
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SkeletronBossBag, Fargowiltas.skeleNum);
					Fargowiltas.instance.multiSkele = false;
				}
				else
				{
					int count = 0;
					for(int i = 0; i < 200; i++)
					{
						if(Main.npc[i].type == NPCID.SkeletronHead)
						{
							count++;
						}
					}
					if(count < Fargowiltas.skeleNum - Fargowiltas.skeleKills)
					{
						for(int i = 0; i < Fargowiltas.skeleNum - Fargowiltas.skeleKills - count; i++)
						{
							NPC.NewNPC((int)npc.position.X + Main.rand.Next(-1000, 1000), (int)npc.position.Y + Main.rand.Next(-500, -100), NPCID.SkeletronHead);
						}
					}
				}
				return false;
			}
			//bee multi
			if(npc.type == NPCID.QueenBee && Fargowiltas.instance.multiBee)
			{
				Fargowiltas.beeKills++;
				
				if(Fargowiltas.beeKills % 100 == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EnergizerBee"), 1);
				}
				Main.NewText("Killed: " + Fargowiltas.beeKills.ToString(), 206, 12, 15);
				Main.NewText("Total: " + Fargowiltas.beeNum.ToString(), 206, 12, 15);
				if(Fargowiltas.beeKills <= Fargowiltas.beeNum - Fargowiltas.beeSpawned)
				{
					NPC.NewNPC((int)npc.position.X + Main.rand.Next(-1000, 1000), (int)npc.position.Y + Main.rand.Next(-800, -400), NPCID.QueenBee);
				}
				else if(Fargowiltas.beeKills == Fargowiltas.beeNum)
				{
					if (Main.netMode == 2) 
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("The swarm has been defeated!"), new Color(206, 12, 15));
					}
					else
					{
						Main.NewText("The swarm has been defeated!", 206, 12, 15);
					}
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.QueenBeeBossBag, Fargowiltas.beeNum);
					Fargowiltas.instance.multiBee = false;
				}
				return false;
			}
			//Wall Multi???
			//destroyer multi
			if(npc.type == NPCID.TheDestroyer && Fargowiltas.instance.multiDestroy)
			{
				Fargowiltas.destroyKills++;
				
				if(Fargowiltas.destroyKills % 100 == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EnergizerDestroy"), 1);
				}
				Main.NewText("Killed: " + Fargowiltas.destroyKills.ToString(), 206, 12, 15);
				Main.NewText("Total: " + Fargowiltas.destroyNum.ToString(), 206, 12, 15);
				if(Fargowiltas.destroyKills <= Fargowiltas.destroyNum - Fargowiltas.destroySpawned)
				{
					int count = 0;
					for(int i = 0; i < 200; i++)
					{
						if(Main.npc[i].type == NPCID.TheDestroyer)
						{
							count++;
						}
					}
					int count2 = 0;
					for(int i = 0; i < 200; i++)
					{
						if(Main.npc[i].type == NPCID.TheDestroyerBody)
						{
							Main.npc[i].StrikeNPC(Main.npc[i].lifeMax, 0f, 0);
							NPC.NewNPC((int)npc.position.X + Main.rand.Next(-1000, 1000), (int)npc.position.Y + Main.rand.Next(400, 800), NPCID.TheDestroyer);
							count2++;
							if((count2 == Fargowiltas.destroySpawned - count) || (count > Fargowiltas.destroySpawned))
							{
								break;
							}
						}
					}
				}
				else if(Fargowiltas.destroyKills == Fargowiltas.destroyNum)
				{
					if (Main.netMode == 2) 
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("The swarm has been defeated!"), new Color(206, 12, 15));
					}
					else
					{
						Main.NewText("The swarm has been defeated!", 206, 12, 15);
					}
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.DestroyerBossBag, Fargowiltas.destroyNum);
					Fargowiltas.instance.multiDestroy = false;
				}
				return false;
			}
			//twins multi
			if(Fargowiltas.instance.multiTwins)
			{
				if(npc.type == NPCID.Spazmatism)
				{
					Fargowiltas.spazKills++;
				
					if(Fargowiltas.spazKills % 100 == 0)
					{
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EnergizerTwin"), 1);
					}
					Main.NewText("Killed: " + ((Fargowiltas.spazKills + Fargowiltas.retKills) / 2).ToString(), 206, 12, 15);
					Main.NewText("Total: " + Fargowiltas.twinsNum.ToString(), 206, 12, 15);					
					if(Fargowiltas.spazKills <= Fargowiltas.twinsNum - Fargowiltas.twinsSpawned || Fargowiltas.retKills <= Fargowiltas.twinsNum - Fargowiltas.twinsSpawned)
					{
						NPC.NewNPC((int)npc.position.X + Main.rand.Next(-1000, 1000), (int)npc.position.Y + Main.rand.Next(-800, -400), NPCID.Spazmatism);
					}
					if((Fargowiltas.spazKills + Fargowiltas.retKills) / 2 >= Fargowiltas.twinsNum)
					{
						if (Main.netMode == 2) 
						{
							NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("The swarm has been defeated!"), new Color(206, 12, 15));
						}
						else
						{
							Main.NewText("The swarm has been defeated!", 206, 12, 15);
						}
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.TwinsBossBag, Fargowiltas.twinsNum);
						Fargowiltas.instance.multiTwins = false;
					}
					return false;
				}
				if(npc.type == NPCID.Retinazer)
				{
					Fargowiltas.retKills++;
					
					if(Fargowiltas.retKills <= Fargowiltas.twinsNum - Fargowiltas.twinsSpawned || Fargowiltas.spazKills <= Fargowiltas.twinsNum - Fargowiltas.twinsSpawned)
					{
						NPC.NewNPC((int)npc.position.X + Main.rand.Next(-1000, 1000), (int)npc.position.Y + Main.rand.Next(-800, -400), NPCID.Retinazer);
					}
					return false;
				}
			}
			//prime multi
			if(npc.type == NPCID.SkeletronPrime && Fargowiltas.instance.multiPrime)
			{
				Fargowiltas.primeKills++;
				
				if(Fargowiltas.primeKills % 100 == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EnergizerPrime"), 1);
				}
				Main.NewText("Killed: " + Fargowiltas.primeKills.ToString(), 206, 12, 15);
				Main.NewText("Total: " + Fargowiltas.primeNum.ToString(), 206, 12, 15);
				int count3 = 0;
					for(int i = 0; i < 200; i++)
					{
						if(Main.npc[i].type == NPCID.SkeletronPrime)
						{
							count3++;
						}
					}
				Main.NewText("Primes Active: " + count3.ToString(), 206, 12, 15);
				if(Fargowiltas.primeKills <= Fargowiltas.primeNum - Fargowiltas.primeSpawned)
				{
					NPC.NewNPC((int)npc.position.X + Main.rand.Next(-1000, 1000), (int)npc.position.Y + Main.rand.Next(-600, -300), NPCID.SkeletronPrime);
				}
				else if(Fargowiltas.primeKills == Fargowiltas.primeNum)
				{
					if (Main.netMode == 2) 
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("The swarm has been defeated!"), new Color(206, 12, 15));
					}
					else
					{
						Main.NewText("The swarm has been defeated!", 206, 12, 15);
					}
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SkeletronPrimeBossBag, Fargowiltas.primeNum);
					Fargowiltas.instance.multiPrime = false;
				}
				return false;
			}
			//plantera multi
			if(npc.type == NPCID.Plantera && Fargowiltas.instance.multiPlant)
			{
				Fargowiltas.plantKills++;
				
				if(Fargowiltas.plantKills % 100 == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EnergizerPlant"), 1);
				}
				Main.NewText("Killed: " + Fargowiltas.plantKills.ToString(), 206, 12, 15);
				Main.NewText("Total: " + Fargowiltas.plantNum.ToString(), 206, 12, 15);
				if(Fargowiltas.plantKills <= Fargowiltas.plantNum - Fargowiltas.plantSpawned)
				{
					int count = 0;
					for(int i = 0; i < 200; i++)
					{
						if(Main.npc[i].type == NPCID.Plantera)
						{
							count++;
						}
					}
					int count2 = 0;
					for(int i = 0; i < 200; i++)
					{
						if(Main.npc[i].type == NPCID.PlanterasHook || Main.npc[i].type == NPCID.PlanterasTentacle)
						{
							Main.npc[i].StrikeNPC(Main.npc[i].lifeMax, 0f, 0);
							NPC.NewNPC((int)npc.position.X + Main.rand.Next(-1000, 1000), (int)npc.position.Y + Main.rand.Next(400, 800), NPCID.Plantera);
							count2++;
							if((count2 == Fargowiltas.plantSpawned - count) || (count > Fargowiltas.plantSpawned))
							{
								break;
							}
						}
					}
				}
				else if(Fargowiltas.plantKills == Fargowiltas.plantNum)
				{
					if (Main.netMode == 2) 
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("The swarm has been defeated!"), new Color(206, 12, 15));
					}
					else
					{
						Main.NewText("The swarm has been defeated!", 206, 12, 15);
					}
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.PlanteraBossBag, Fargowiltas.plantNum);
					Fargowiltas.instance.multiPlant = false;
				}
				return false;
			}
			//golem multi
			if(npc.type == NPCID.Golem && Fargowiltas.instance.multiGolem)
			{
				Fargowiltas.golemKills++;
				
				if(Fargowiltas.golemKills % 100 == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EnergizerGolem"), 1);
				}
				Main.NewText("Killed: " + Fargowiltas.golemKills.ToString(), 206, 12, 15);
				Main.NewText("Total: " + Fargowiltas.golemNum.ToString(), 206, 12, 15);
				int count3 = 0;
					for(int i = 0; i < 200; i++)
					{
						if(Main.npc[i].type == NPCID.Golem)
						{
							count3++;
						}
					}
				Main.NewText("Golems Active: " + count3.ToString(), 206, 12, 15);
				if(Fargowiltas.golemKills <= Fargowiltas.golemNum - Fargowiltas.golemSpawned)
				{
					NPC.NewNPC((int)npc.position.X + Main.rand.Next(-1000, 1000), (int)npc.position.Y + Main.rand.Next(400, 800), NPCID.GolemHead);
					NPC.NewNPC((int)npc.position.X + Main.rand.Next(-1000, 1000), (int)npc.position.Y + Main.rand.Next(400, 800), NPCID.GolemFistLeft);
					NPC.NewNPC((int)npc.position.X + Main.rand.Next(-1000, 1000), (int)npc.position.Y + Main.rand.Next(400, 800), NPCID.GolemFistRight);
				}
				else if(Fargowiltas.golemKills == Fargowiltas.golemNum)
				{
					if (Main.netMode == 2) 
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("The swarm has been defeated!"), new Color(206, 12, 15));
					}
					else
					{
						Main.NewText("The swarm has been defeated!", 206, 12, 15);
					}
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GolemBossBag, Fargowiltas.golemNum);
					Fargowiltas.instance.multiGolem = false;
				}
				return false;
			}
			//fishron multi
			if(npc.type == NPCID.DukeFishron && Fargowiltas.instance.multiFish)
			{
				Fargowiltas.fishKills++;
				
				if(Fargowiltas.fishKills % 100 == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EnergizerFish"), 1);
				}
				Main.NewText("Killed: " + Fargowiltas.fishKills.ToString(), 206, 12, 15);
				Main.NewText("Total: " + Fargowiltas.fishNum.ToString(), 206, 12, 15);
				int count3 = 0;
					for(int i = 0; i < 200; i++)
					{
						if(Main.npc[i].type == NPCID.DukeFishron)
						{
							count3++;
						}
					}
				Main.NewText("Dukes Active: " + count3.ToString(), 206, 12, 15);
				if(Fargowiltas.fishKills <= Fargowiltas.fishNum - Fargowiltas.fishSpawned)
				{
					NPC.NewNPC((int)npc.position.X + Main.rand.Next(-1000, 1000), (int)npc.position.Y + Main.rand.Next(-800, -400), NPCID.DukeFishron);
				}
				else if(Fargowiltas.fishKills == Fargowiltas.fishNum)
				{
					if (Main.netMode == 2) 
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("The swarm has been defeated!"), new Color(206, 12, 15));
					}
					else
					{
						Main.NewText("The swarm has been defeated!", 206, 12, 15);
					}
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.FishronBossBag, Fargowiltas.fishNum);
					Fargowiltas.instance.multiFish = false;
				}
				return false;
			}
			//moon lord multi
			if(npc.type == NPCID.MoonLordCore && Fargowiltas.instance.multiMoon)
			{
				Fargowiltas.moonKills++;
				
				if(Fargowiltas.moonKills % 100 == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EnergizerMoon"), 1);
				}
				Main.NewText("Killed: " + Fargowiltas.moonKills.ToString(), 206, 12, 15);
				Main.NewText("Total: " + Fargowiltas.moonNum.ToString(), 206, 12, 15);
				int count3 = 0;
					for(int i = 0; i < 200; i++)
					{
						if(Main.npc[i].type == NPCID.MoonLordCore)
						{
							count3++;
						}
					}
				Main.NewText("Moons Active: " + count3.ToString(), 206, 12, 15);
				if(Fargowiltas.moonKills <= Fargowiltas.moonNum - Fargowiltas.moonSpawned)
				{
					NPC.NewNPC((int)npc.position.X + Main.rand.Next(-1000, 1000), (int)npc.position.Y + Main.rand.Next(-800, -400), NPCID.MoonLordCore);
				}
				else if(Fargowiltas.moonKills == Fargowiltas.moonNum)
				{
					if (Main.netMode == 2) 
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("The swarm has been defeated!"), new Color(206, 12, 15));
					}
					else
					{
						Main.NewText("The swarm has been defeated!", 206, 12, 15);
					}
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MoonLordBossBag, Fargowiltas.moonNum);
					Fargowiltas.instance.multiMoon = false;
				}
				return false;
			}
			//DG multi
			//cultist
			//betsy
			//saucer
			//dutchman
			//ogre
			//mourning wood
			//pumpking
			//everscream
			//santa tank
			//frost queen

			return true;
		}

		public override void NPCLoot(NPC npc)
		{
			Player player = Main.player[Main.myPlayer];
			
			//crimson enchant
			FargoPlayer modPlayer = player.GetModPlayer<FargoPlayer>(mod);
			if(modPlayer.crimsonEnchant && Main.rand.Next(8) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Heart, 1);
			}
			
			//elemental
			if(modPlayer.terrariaSoul && Main.rand.Next(3) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Heart, 1);
			}
			
			//lumber jaxe
			if(npc.FindBuffIndex(mod.BuffType("WoodDrop")) != -1)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Wood, Main.rand.Next(10, 30));
			}		
			
			//halloween and xmas
			if((npc.type == NPCID.Ghost) || (npc.type == NPCID.HoppinJack) || (npc.type == NPCID.Raven))
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoodieBag, 1);
			}
			
			if((npc.type == NPCID.SlimeRibbonGreen) || (npc.type == NPCID.SlimeRibbonRed) || (npc.type == NPCID.SlimeRibbonWhite) || (npc.type == NPCID.SlimeRibbonYellow))
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Present, 1);
			}
			
			if(((npc.type == NPCID.BloodZombie) || (npc.type == NPCID.Drippler)) && Main.rand.Next(75) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BloodyMachete, 1);
			}
			
			if(((npc.type == NPCID.BloodZombie) || (npc.type == NPCID.Drippler)) && Main.rand.Next(75) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BladedGlove, 1);
			}

			
			//TOWN NPCS
			if(npc.type == NPCID.Guide)
            {
				FargoWorld.guide = true;
			}
			if(npc.type == NPCID.Merchant)
            {
				if(Main.rand.Next(10) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MiningShirt);
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MiningPants);
				}
				
				FargoWorld.merch = true;
			}
			if(npc.type == NPCID.Nurse)
            {
				FargoWorld.nurse = true;
			}
			if(npc.type == NPCID.Demolitionist)
            {
				FargoWorld.demo = true;
			}
			if(npc.type == NPCID.DyeTrader)
            {
				FargoWorld.dye = true;
			}
			if(npc.type == NPCID.Dryad)
            {
				FargoWorld.dryad = true;
			}
			if(npc.type == NPCID.DD2Bartender)
            {
				FargoWorld.keep = true;
			}
			if(npc.type == NPCID.ArmsDealer)
            {
				FargoWorld.dealer = true;
			}
			if(npc.type == NPCID.Stylist)
            {
				FargoWorld.style = true;
			}
			if(npc.type == NPCID.Painter)
            {
				FargoWorld.paint = true;
			}
			if(npc.type == NPCID.Angler)
            {
				FargoWorld.angler = true;
			}
			if(npc.type == NPCID.GoblinTinkerer)
            {
				FargoWorld.goblin = true;
			}
			if(npc.type == NPCID.WitchDoctor)
            {
				FargoWorld.doc = true;
			}
			if(npc.type == NPCID.Clothier)
            {
				FargoWorld.cloth = true;
			}
			if(npc.type == NPCID.Mechanic)
            {
				FargoWorld.mech = true;
			}
			if(npc.type == NPCID.PartyGirl)
            {
				FargoWorld.party = true;
			}
			if(npc.type == NPCID.Wizard)
            {
				FargoWorld.wiz = true;
			}
			if(npc.type == NPCID.TaxCollector)
            {
				FargoWorld.tax = true;
			}
			if(npc.type == NPCID.Truffle)
            {
				FargoWorld.truf = true;
			}
			if(npc.type == NPCID.Pirate)
            {
				FargoWorld.pirate = true;
			}
			if(npc.type == NPCID.Steampunker)
            {
				FargoWorld.steam = true;
			}
			if(npc.type == NPCID.Cyborg)
            {
				FargoWorld.borg = true;
			}
			
		}
		
		public override bool CheckDead(NPC npc)
		{
			Player player = Main.player[Main.myPlayer];
			FargoPlayer modPlayer = player.GetModPlayer<FargoPlayer>(mod);
			
			if (modPlayer.cobaltEnchant && !npc.friendly && (npc.damage > 0 || npc.lifeMax > 5))
			{
				Main.PlaySound(2, (int)player.position.X, (int)player.position.Y, 27);
			                                        
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0f, 5f, 90, 50/*dmg*/, 2, Main.myPlayer, 0f, 0f);
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 5f, 0f, 90, 50, 2, Main.myPlayer, 0f, 0f);
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0f, -5f, 90, 50, 2, Main.myPlayer, 0f, 0f);
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -5f, 0f, 90, 50, 2, Main.myPlayer, 0f, 0f);
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 4f, 4f, 90, 50, 2, Main.myPlayer, 0f, 0f);
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -4f, -4f, 90, 50, 2, Main.myPlayer, 0f, 0f);
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 4f, -4f, 90, 50, 2, Main.myPlayer, 0f, 0f);
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -4f, 4f, 90, 50, 2, Main.myPlayer, 0f, 0f);
			}
			
            if(npc.type == NPCID.DD2Betsy)
            {
                 Main.NewText("Betsy has been defeated!", 175, 75, 255);
				 FargoWorld.downedBetsy = true;
            }
			
            return true;
		}
		
		public override void ModifyHitNPC (NPC npc, NPC target, ref int damage, ref float knockback, ref bool crit)
		{
			
			
			
		}
		
		public override void ModifyHitByProjectile (NPC npc, Projectile projectile, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			if(projectile.type == mod.ProjectileType("FishNuke"))
			{
				damage = npc.lifeMax / 10;
				if(damage < 50)
				{
					damage = 50;
				}
			}
			
			
		}
		public override bool StrikeNPC (NPC npc, ref double damage, int defense, ref float knockback, int hitDirection, ref bool crit)
		{
			Player player = Main.player[Main.myPlayer];
			FargoPlayer modPlayer = player.GetModPlayer<FargoPlayer>(mod);
			if(modPlayer.universeEffect)
			{
				if(crit)
				{
					damage *= 4;
					return false;
				}
				
			}
			//normal damage calc
			return true;
		}
		
		public override void DrawEffects(NPC npc, ref Color drawColor)
		{
			
		}

	}
}