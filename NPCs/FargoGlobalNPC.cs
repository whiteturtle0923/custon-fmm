using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using System;

namespace Fargowiltas.NPCs
{
    public class FargoGlobalNPC : GlobalNPC
    {
        public override bool InstancePerEntity => true;

        public bool pillarSpawn = true;
        public bool swarmActive;
        public bool pandoraActive;
        public bool noLoot;

        public static int[] bosses = { NPCID.KingSlime, NPCID.EyeofCthulhu, NPCID.QueenBee, NPCID.SkeletronHead, NPCID.TheDestroyer, NPCID.SkeletronPrime, NPCID.Retinazer, NPCID.Spazmatism, NPCID.Plantera, NPCID.Golem, NPCID.DukeFishron, NPCID.CultistBoss, NPCID.MoonLordCore, NPCID.MartianSaucerCore, NPCID.Pumpking, NPCID.IceQueen, NPCID.DD2Betsy, NPCID.DD2OgreT3, NPCID.IceGolem, NPCID.SandElemental, NPCID.Paladin, NPCID.Everscream, NPCID.MourningWood, NPCID.SantaNK1, NPCID.HeadlessHorseman, NPCID.PirateShip };

        public override void SetDefaults(NPC npc)
        {
            #region bug net town NPCs!

            switch (npc.type)
            {
                case NPCID.Guide:
                    Main.npcCatchable[npc.type] = true;
                    npc.catchItem = (short)mod.ItemType("Guide");
                    break;
                case NPCID.Merchant:
                    Main.npcCatchable[npc.type] = true;
                    npc.catchItem = (short)mod.ItemType("Merchant");
                    break;
                case NPCID.Nurse:
                    Main.npcCatchable[npc.type] = true;
                    npc.catchItem = (short)mod.ItemType("Nurse");
                    break;
                case NPCID.Demolitionist:
                    Main.npcCatchable[npc.type] = true;
                    npc.catchItem = (short)mod.ItemType("Demolitionist");
                    break;
                case NPCID.DyeTrader:
                    Main.npcCatchable[npc.type] = true;
                    npc.catchItem = (short)mod.ItemType("DyeTrader");
                    break;
                case NPCID.Dryad:
                    Main.npcCatchable[npc.type] = true;
                    npc.catchItem = (short)mod.ItemType("Dryad");
                    break;
                case NPCID.DD2Bartender:
                    Main.npcCatchable[npc.type] = true;
                    npc.catchItem = (short)mod.ItemType("Tavernkeep");
                    break;
                case NPCID.ArmsDealer:
                    Main.npcCatchable[npc.type] = true;
                    npc.catchItem = (short)mod.ItemType("ArmsDealer");
                    break;
                case NPCID.Stylist:
                    Main.npcCatchable[npc.type] = true;
                    npc.catchItem = (short)mod.ItemType("Stylist");
                    break;
                case NPCID.Painter:
                    Main.npcCatchable[npc.type] = true;
                    npc.catchItem = (short)mod.ItemType("Painter");
                    break;
                case NPCID.Angler:
                    Main.npcCatchable[npc.type] = true;
                    npc.catchItem = (short)mod.ItemType("Angler");
                    break;
                case NPCID.GoblinTinkerer:
                    Main.npcCatchable[npc.type] = true;
                    npc.catchItem = (short)mod.ItemType("GoblinTinkerer");
                    break;
                case NPCID.WitchDoctor:
                    Main.npcCatchable[npc.type] = true;
                    npc.catchItem = (short)mod.ItemType("WitchDoctor");
                    break;
                case NPCID.Clothier:
                    Main.npcCatchable[npc.type] = true;
                    npc.catchItem = (short)mod.ItemType("Clothier");
                    break;
                case NPCID.Mechanic:
                    Main.npcCatchable[npc.type] = true;
                    npc.catchItem = (short)mod.ItemType("Mechanic");
                    break;
                case NPCID.PartyGirl:
                    Main.npcCatchable[npc.type] = true;
                    npc.catchItem = (short)mod.ItemType("PartyGirl");
                    break;
                case NPCID.Wizard:
                    Main.npcCatchable[npc.type] = true;
                    npc.catchItem = (short)mod.ItemType("Wizard");
                    break;
                case NPCID.TaxCollector:
                    Main.npcCatchable[npc.type] = true;
                    npc.catchItem = (short)mod.ItemType("TaxCollector");
                    break;
                case NPCID.Truffle:
                    Main.npcCatchable[npc.type] = true;
                    npc.catchItem = (short)mod.ItemType("Truffle");
                    break;
                case NPCID.Pirate:
                    Main.npcCatchable[npc.type] = true;
                    npc.catchItem = (short)mod.ItemType("Pirate");
                    break;
                case NPCID.Steampunker:
                    Main.npcCatchable[npc.type] = true;
                    npc.catchItem = (short)mod.ItemType("Steampunker");
                    break;
                case NPCID.Cyborg:
                    Main.npcCatchable[npc.type] = true;
                    npc.catchItem = (short)mod.ItemType("Cyborg");
                    break;
                case NPCID.TravellingMerchant:
                    Main.npcCatchable[npc.type] = true;
                    npc.catchItem = (short)mod.ItemType("TravellingMerchant");
                    break;
                case NPCID.SkeletonMerchant:
                    Main.npcCatchable[npc.type] = true;
                    npc.catchItem = (short)mod.ItemType("SkeletonMerchant");
                    break;
                case NPCID.SantaClaus:
                    Main.npcCatchable[npc.type] = true;
                    npc.catchItem = (short)mod.ItemType("SantaClaus");
                    break;
                default:
                    break;
            }

            #endregion
        }

        public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
            Player player = Main.player[Main.myPlayer];

            switch (type)
            {
                case NPCID.Clothier:
                    shop.item[nextSlot].SetDefaults(ItemID.PharaohsMask);
                    nextSlot++;

                    shop.item[nextSlot].SetDefaults(ItemID.PharaohsRobe);
                    nextSlot++;

                    if (player.anglerQuestsFinished >= 10)
                    {
                        shop.item[nextSlot].SetDefaults(ItemID.AnglerHat);
                        nextSlot++;
                    }

                    if (player.anglerQuestsFinished >= 15)
                    {
                        shop.item[nextSlot].SetDefaults(ItemID.AnglerVest);
                        nextSlot++;
                    }

                    if (player.anglerQuestsFinished >= 20)
                    {
                        shop.item[nextSlot].SetDefaults(ItemID.AnglerPants);
                        nextSlot++;
                    }

                    break;
                case NPCID.Merchant:
                    if (player.anglerQuestsFinished >= 5)
                    {
                        shop.item[nextSlot].SetDefaults(ItemID.FuzzyCarrot);
                        nextSlot++;
                    }

                    if (player.anglerQuestsFinished >= 10)
                    {
                        shop.item[nextSlot].SetDefaults(ItemID.AnglerEarring);
                        nextSlot++;

                        shop.item[nextSlot].SetDefaults(ItemID.HighTestFishingLine);
                        nextSlot++;

                        shop.item[nextSlot].SetDefaults(ItemID.TackleBox);
                        nextSlot++;

                        shop.item[nextSlot].SetDefaults(ItemID.GoldenBugNet);
                        nextSlot++;

                        shop.item[nextSlot].SetDefaults(ItemID.FishHook);
                        nextSlot++;

                        if(Main.hardMode)
                        {
                            shop.item[nextSlot].SetDefaults(ItemID.FinWings);
                            nextSlot++;

                            shop.item[nextSlot].SetDefaults(ItemID.SuperAbsorbantSponge);
                            nextSlot++;

                            shop.item[nextSlot].SetDefaults(ItemID.BottomlessBucket);
                            nextSlot++;
                        }
                    }

                    if (player.anglerQuestsFinished >= 25 && Main.hardMode)
                    {
                        shop.item[nextSlot].SetDefaults(ItemID.HotlineFishingHook);
                        nextSlot++;
                    }

                    if (player.anglerQuestsFinished >= 30)
                    {
                        shop.item[nextSlot].SetDefaults(ItemID.GoldenFishingRod);
                        nextSlot++;
                    }

                    break;
            }
        }

        public override void EditSpawnRate (Player player, ref int spawnRate, ref int maxSpawns)
		{
			FargoPlayer modPlayer = player.GetModPlayer<FargoPlayer>(mod);

		    if (!modPlayer.npcBoost) return;
		    spawnRate = (int)(spawnRate * 0.1);
		    maxSpawns = (int)(maxSpawns * 10f);
		}

        private void SpawnBoss(NPC npc, int boss)
        {
            if(swarmActive)
            {
                int spawn = NPC.NewNPC((int)npc.position.X + Main.rand.Next(-1000, 1000), (int)npc.position.Y + Main.rand.Next(-400, -100), boss);
                Main.npc[spawn].GetGlobalNPC<FargoGlobalNPC>().swarmActive = true;
            }
            else //pandora
            {
                int rando;

                do
                {
                    rando = bosses[Main.rand.Next(bosses.Length)];
                } while (NPC.CountNPCS(rando) >= 4);

                int spawn = NPC.NewNPC((int)npc.position.X + Main.rand.Next(-1000, 1000), (int)npc.position.Y + Main.rand.Next(-400, -100), rando);
                Main.npc[spawn].GetGlobalNPC<FargoGlobalNPC>().pandoraActive = true;
            }
        }

        private void Swarm(NPC npc, int boss, int minion, int bossbag, string reward)
        {
            int count = 0;

            if(swarmActive)
            {
                count = NPC.CountNPCS(boss) - 1; //since this one is about to be dead 
            }
            else //pandora
            {
                for (int i = 0; i < 200; i++)
                {
                    if (Main.npc[i].active && Array.IndexOf(bosses, Main.npc[i].type) > -1)
                    {
                        count++;
                    }
                }
            }

            int missing = Fargowiltas.swarmSpawned - count;

            Fargowiltas.swarmKills++;

            //drop swarm reward every 100 kills
            if (Fargowiltas.swarmKills % 100 == 0 && reward != "")
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType(reward));
            }

            Main.NewText("Killed: " + Fargowiltas.swarmKills, 206, 12, 15);
            Main.NewText("Total: " + Fargowiltas.swarmTotal, 206, 12, 15);

            //if theres still more to spawn
            if (Fargowiltas.swarmKills <= Fargowiltas.swarmTotal - Fargowiltas.swarmSpawned)
            {
                int spawned = 0;

                for (int i = 0; i < 200; i++)
                {
                    //kill a minion and spawn boss (to make sure there's spawn room)
                    if(swarmActive && minion > 0 && i < 199)
                    {
                        if (Main.npc[i].type == minion)
                        {
                            //Main.npc[i].active = false;
                            //Main.npc[i].StrikeNPC(Main.npc[i].lifeMax * 2, 0f, 0);
                            Main.npc[i].StrikeNPCNoInteraction(Main.npc[i].lifeMax, 0f, -Main.npc[i].direction, true);
                        }
                    }
                    else //pandora
                    {
                        if (Array.IndexOf(bosses, Main.npc[i].type) == -1 && !Main.npc[i].boss)
                        {
                            Main.npc[i].StrikeNPCNoInteraction(Main.npc[i].lifeMax, 0f, -Main.npc[i].direction, true);
                        }
                    }

                    SpawnBoss(npc, boss);
                    spawned++;

                    if (spawned <= missing)
                    {
                        continue;
                    }

                    break;
                }
            }
            //swarm over
            else if (Fargowiltas.swarmKills >= Fargowiltas.swarmTotal)
            {
                if (Main.netMode == 2)
                {
                    NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("The swarm has been defeated!"), new Color(206, 12, 15));
                }
                else
                {
                    Main.NewText("The swarm has been defeated!", 206, 12, 15);
                }

                for (int i = 0; i < 200; i++)
                {
                    if (Main.npc[i].active)
                    {
                        Main.npc[i].GetGlobalNPC<FargoGlobalNPC>().noLoot = true;
                        Main.npc[i].StrikeNPCNoInteraction(Main.npc[i].lifeMax, 0f, -Main.npc[i].direction, true);
                    }
                }

                if (bossbag >= 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, bossbag, Fargowiltas.swarmTotal);
                }
                
                Fargowiltas.swarmActive = false;
            }
            //make sure theres enough left to beat it
            else
            {
                //spawn more if needed
                if (count >= Fargowiltas.swarmSpawned) return;
                for (int i = 0; i < 5; i++)
                {
                    SpawnBoss(npc, boss);
                }
            }
        }
		
		public override bool PreNPCLoot (NPC npc)
		{
            if(noLoot)
            {
                return false;
            }

            //avoid lunar event with cultist summon
            if(npc.type == NPCID.CultistBoss && !pillarSpawn)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.CultistBossBag);
                return false;
            }

            if(Fargowiltas.swarmActive /*|| Fargowiltas.pandoraActive*/ && (npc.type == NPCID.BlueSlime || npc.type == NPCID.EaterofWorldsBody || npc.type == NPCID.EaterofWorldsTail || npc.type == NPCID.Creeper || npc.type == NPCID.PirateCorsair || npc.type == NPCID.PirateDeadeye || npc.type == NPCID.PirateCrossbower))
            {
                return false;
            }

            if(swarmActive)
            {
                // ReSharper disable once SwitchStatementMissingSomeCases
                switch (npc.type)
                {
                    case NPCID.KingSlime:
                        Swarm(npc, NPCID.KingSlime, NPCID.BlueSlime, ItemID.KingSlimeBossBag, "EnergizerSlime");
                        break;
                    case NPCID.EyeofCthulhu:
                        Swarm(npc, NPCID.EyeofCthulhu, NPCID.ServantofCthulhu, ItemID.EyeOfCthulhuBossBag, "EnergizerEye");
                        break;
                    case NPCID.EaterofWorldsHead:
                        Swarm(npc, NPCID.EaterofWorldsHead, NPCID.EaterofWorldsTail, ItemID.EaterOfWorldsBossBag,
                            "EnergizerWorm");
                        break;
                    case NPCID.BrainofCthulhu:
                        Swarm(npc, NPCID.BrainofCthulhu, NPCID.Creeper, ItemID.BrainOfCthulhuBossBag, "EnergizerBrain");
                        break;
                    case NPCID.QueenBee:
                        Swarm(npc, NPCID.QueenBee, NPCID.BeeSmall, ItemID.QueenBeeBossBag, "EnergizerBee");
                        break;
                    case NPCID.SkeletronHead:
                        Swarm(npc, NPCID.SkeletronHead, -1, ItemID.SkeletronBossBag, "EnergizerSkele");
                        break;
                    case NPCID.TheDestroyer:
                        Swarm(npc, NPCID.TheDestroyer, NPCID.TheDestroyerTail, ItemID.DestroyerBossBag, "EnergizerDestroy");
                        break;
                    case NPCID.Retinazer:
                        Swarm(npc, NPCID.Retinazer, -1, ItemID.TwinsBossBag, "EnergizerTwins");
                        break;
                    case NPCID.Spazmatism:
                        Swarm(npc, NPCID.Spazmatism, -1, -1, "");
                        break;
                    case NPCID.SkeletronPrime:
                        Swarm(npc, NPCID.SkeletronPrime, -1, ItemID.SkeletronPrimeBossBag, "EnergizerPrime");
                        break;
                    case NPCID.Plantera:
                        Swarm(npc, NPCID.Plantera, NPCID.PlanterasHook, ItemID.PlanteraBossBag, "EnergizerPlant");
                        break;
                    case NPCID.Golem:
                        Swarm(npc, NPCID.Golem, NPCID.GolemHeadFree, ItemID.GolemBossBag, "EnergizerGolem");
                        break;
                    case NPCID.DukeFishron:
                        Swarm(npc, NPCID.DukeFishron, NPCID.Sharkron, ItemID.FishronBossBag, "EnergizerFish");
                        break;
                    case NPCID.CultistBoss:
                        Swarm(npc, NPCID.CultistBoss, -1, ItemID.CultistBossBag, "");
                        break;
                    case NPCID.MoonLordCore:
                        Swarm(npc, NPCID.MoonLordCore, NPCID.MoonLordFreeEye, ItemID.MoonLordBossBag, "EnergizerMoon");
                        break;
                    case NPCID.MourningWood:
                        Swarm(npc, NPCID.MourningWood, -1, -1, "");
                        break;
                    case NPCID.Pumpking:
                        Swarm(npc, NPCID.Pumpking, -1, -1, "");
                        break;
                    case NPCID.Everscream:
                        Swarm(npc, NPCID.Everscream, -1, -1, "");
                        break;
                    case NPCID.SantaNK1:
                        Swarm(npc, NPCID.SantaNK1, -1, -1, "");
                        break;
                    case NPCID.IceQueen:
                        Swarm(npc, NPCID.IceQueen, -1, -1, "");
                        break;
                    case NPCID.DD2Betsy:
                        Swarm(npc, NPCID.DD2Betsy, -1, -1, "");
                        break;
                    case NPCID.DD2OgreT3:
                        Swarm(npc, NPCID.DD2OgreT3, -1, -1, "");
                        break;
                    case NPCID.PirateShip:
                        Swarm(npc, NPCID.PirateShip, -1, -1, "");
                        break;
                    case NPCID.MartianSaucerCore:
                        Swarm(npc, NPCID.MartianSaucerCore, -1, -1, "");
                        break;
                    case NPCID.DungeonGuardian:
                        Swarm(npc, NPCID.DungeonGuardian, -1, -1, "");
                        break;
                }

                //PANDORA SWARM

                return false;
            }

		    if (!pandoraActive) return true;
		    Swarm(npc, 0, -1, -1, "");

		    return false;

		}

		public override void NPCLoot(NPC npc)
		{
            Player player = Main.player[Main.myPlayer];
			
			//lumber jaxe
			if(npc.FindBuffIndex(mod.BuffType("WoodDrop")) != -1)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Wood, Main.rand.Next(10, 30));
			}

			// ReSharper disable once SwitchStatementMissingSomeCases
			if (npc.type == NPCID.GreekSkeleton && Main.rand.Next(15) == 0)
			{
				int i = Main.rand.Next(3);

				switch (i)
				{
					case 0:
						Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
							ItemID.GladiatorHelmet);
						break;
					case 1:
						Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
							ItemID.GladiatorBreastplate);
						break;
					default:
						Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
							ItemID.GladiatorLeggings);
						break;
				}
			}
			else if (npc.type == NPCID.Clown)
			{
				Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, ItemID.Bananarang);
			}
			else if (npc.type == NPCID.Guide)
			{
				FargoWorld.guide = true;
			}
			else if (npc.type == NPCID.Merchant)
			{
				if (Main.rand.Next(8) == 0)
				{
					Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, ItemID.MiningShirt);
					Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, ItemID.MiningPants);
				}

				FargoWorld.merch = true;
			}
			else if (npc.type == NPCID.Nurse)
			{
				if (Main.rand.Next(5) == 0)
				{
					Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, ItemID.LifeCrystal);
				}

				FargoWorld.nurse = true;
			}
			else if (npc.type == NPCID.Demolitionist)
			{
				if (Main.rand.Next(2) == 0)
				{
					Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, ItemID.Dynamite, 5);
				}

				FargoWorld.demo = true;
			}
			else if (npc.type == NPCID.DyeTrader)
			{
				FargoWorld.dye = true;
			}
			else if (npc.type == NPCID.Dryad)
			{
				if (Main.rand.Next(3) == 0)
				{
					Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, ItemID.HerbBag);
				}

				FargoWorld.dryad = true;
			}
			else if (npc.type == NPCID.DD2Bartender)
			{
				if (Main.rand.Next(2) == 0)
				{
					Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, ItemID.Ale, 4);
				}

				FargoWorld.keep = true;
			}
			else if (npc.type == NPCID.ArmsDealer)
			{
				if (Main.rand.Next(4) == 0)
				{
					Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
						ItemID.CrystalBullet, 30);
				}

				FargoWorld.dealer = true;
			}
			else if (npc.type == NPCID.Stylist)
			{
				FargoWorld.style = true;
			}
			else if (npc.type == NPCID.Painter)
			{
				FargoWorld.paint = true;

				if (NPC.AnyNPCs(NPCID.MoonLordCore))
				{
					Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
						mod.ItemType("EchPainting"));
				}
			}
			else if (npc.type == NPCID.Angler)
			{
				if (Main.rand.Next(4) == 0)
				{
					int[] drops = {ItemID.FishermansGuide, ItemID.Sextant, ItemID.WeatherRadio};

					Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
						drops[Main.rand.Next(drops.Length)]);
				}

				FargoWorld.angler = true;
			}
			else if (npc.type == NPCID.GoblinTinkerer)
			{
				FargoWorld.goblin = true;
			}
			else if (npc.type == NPCID.WitchDoctor)
			{
				FargoWorld.doc = true;
			}
			else if (npc.type == NPCID.Clothier)
			{
				if (Main.rand.Next(20) == 0)
				{
					Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, ItemID.Skull);
				}

				FargoWorld.cloth = true;
			}
			else if (npc.type == NPCID.Mechanic)
			{
				if (Main.rand.Next(5) == 0)
				{
					Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, ItemID.Wire, 40);
				}

				FargoWorld.mech = true;
			}
			else if (npc.type == NPCID.PartyGirl)
			{
				FargoWorld.party = true;
			}
			else if (npc.type == NPCID.Wizard)
			{
				if (Main.rand.Next(5) == 0)
				{
					Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, ItemID.FallenStar,
						5);
				}

				FargoWorld.wiz = true;
			}
			else if (npc.type == NPCID.TaxCollector)
			{
				if (Main.rand.Next(8) == 0)
				{
					Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, ItemID.GoldCoin,
						10);
				}

				FargoWorld.tax = true;
			}
			else if (npc.type == NPCID.Truffle)
			{
				if (Main.rand.Next(8) == 0)
				{
					Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
						ItemID.MushroomStatue);
				}

				FargoWorld.truf = true;
			}
			else if (npc.type == NPCID.Pirate)
			{
				FargoWorld.pirate = true;
			}
			else if (npc.type == NPCID.Steampunker)
			{
				FargoWorld.steam = true;
			}
			else if (npc.type == NPCID.Cyborg)
			{
				FargoWorld.borg = true;
			}
			else if (npc.type == NPCID.SantaClaus && FargoWorld.xmas)
			{
				NPC.NewNPC((int) npc.position.X, (int) npc.position.Y, NPCID.SantaClaus);
			}
		}
		
		public override bool CheckDead(NPC npc)
		{
			Player player = Main.player[Main.myPlayer];
			FargoPlayer modPlayer = player.GetModPlayer<FargoPlayer>(mod);

            if(npc.type == NPCID.DD2Betsy && !pandoraActive)
            {
                 Main.NewText("Betsy has been defeated!", 175, 75);
				 FargoWorld.downedBetsy = true;
            }
			
			if(npc.boss)
            {
				 FargoWorld.downedBoss = true;
            }

            return true;
		}  

        public override void ModifyHitByProjectile (NPC npc, Projectile projectile, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			if(projectile.type == ProjectileID.RottenEgg && npc.townNPC)
			{
				damage *= 20;
			}
		}
	}
}