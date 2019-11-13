using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using System;
using Terraria.GameContent.Events;

namespace Fargowiltas.NPCs
{
    public class FargoGlobalNPC : GlobalNPC
    {
        public override bool InstancePerEntity => true;

        public bool pillarSpawn = true;
        public bool swarmActive;
        public bool pandoraActive;
        public bool noLoot = false;
        private bool transform = true;

        public static int[] bosses = { NPCID.KingSlime, NPCID.EyeofCthulhu, NPCID.BrainofCthulhu, NPCID.QueenBee, NPCID.SkeletronHead, NPCID.TheDestroyer, NPCID.SkeletronPrime, NPCID.Retinazer, NPCID.Spazmatism, NPCID.Plantera, NPCID.Golem, NPCID.DukeFishron, NPCID.CultistBoss, NPCID.MoonLordCore, NPCID.MartianSaucerCore, NPCID.Pumpking, NPCID.IceQueen, NPCID.DD2Betsy, NPCID.DD2OgreT3, NPCID.IceGolem, NPCID.SandElemental, NPCID.Paladin, NPCID.Everscream, NPCID.MourningWood, NPCID.SantaNK1, NPCID.HeadlessHorseman, NPCID.PirateShip };

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

        public override void AI(NPC npc)
        {

            if (transform && Main.rand.Next(10) == 0)
            {
                if (npc.type == NPCID.DemonEye && !Main.halloween)
                {
                    npc.Transform(NPCID.Raven);
                }
                else if (npc.type == NPCID.BlueSlime && !Main.xMas)
                {
                    npc.Transform(NPCID.SlimeRibbonRed);
                }
            }

            transform = false;

            if (Fargowiltas.swarmActive && Fargowiltas.instance.thoriumLoaded)
            {
                Mod thorium = ModLoader.GetMod("ThoriumMod");

                if (npc.type == thorium.NPCType("BoreanStriderPopped") || npc.type == thorium.NPCType("FallenDeathBeholder2") || npc.type == thorium.NPCType("LichHeadless") || npc.type == thorium.NPCType("AbyssionReleased"))// || npc.type == thorium.NPCType("RealityBreaker"))
                {
                    swarmActive = true;
                }
            }
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
                case NPCID.Painter:
                    if (player.ZoneDungeon)
                    {
                        shop.item[nextSlot].SetDefaults(ItemID.TheGuardiansGaze);
                        nextSlot++;
                    }

                    if (player.ZoneUnderworldHeight)
                    {
                        shop.item[nextSlot].SetDefaults(ItemID.DemonsEye);
                        nextSlot++;
                    }

                    break;
            }
        }

        public override void EditSpawnRate (Player player, ref int spawnRate, ref int maxSpawns)
		{
		    if (!player.GetModPlayer<FargoPlayer>().battleCry) return;

		    spawnRate = (int)(spawnRate * 0.1);
		    maxSpawns = (int)(maxSpawns * 10f);
		}

        private void SpawnBoss(NPC npc, int boss)
        {
            int spawn;

            if (swarmActive)
            {
                spawn = NPC.NewNPC((int)npc.position.X + Main.rand.Next(-1000, 1000), (int)npc.position.Y + Main.rand.Next(-400, -100), boss);

                if (spawn < 200)
                {
                    Main.npc[spawn].GetGlobalNPC<FargoGlobalNPC>().swarmActive = true;
                    NetMessage.SendData(23, -1, -1, null, boss, 0f, 0f, 0f, 0);
                }
            }
            else //pandora
            {
                int rando;

                do
                {
                    rando = bosses[Main.rand.Next(bosses.Length)];
                } while (NPC.CountNPCS(rando) >= 4);

                spawn = NPC.NewNPC((int)npc.position.X + Main.rand.Next(-1000, 1000), (int)npc.position.Y + Main.rand.Next(-400, -100), rando);
                Main.npc[spawn].GetGlobalNPC<FargoGlobalNPC>().pandoraActive = true;
                NetMessage.SendData(23, -1, -1, null, rando, 0f, 0f, 0f, 0);
            }
        }

        private void Swarm(NPC npc, int boss, int minion, int bossbag, string reward)
        {
            if (bossbag >= 0)
            {
                npc.DropItemInstanced(npc.Center, npc.Size, bossbag, 1);
            }

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
                Item.NewItem(npc.Hitbox, mod.ItemType(reward));
            }

            if (Main.netMode == 2)
            {
                NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("Killed: " + Fargowiltas.swarmKills), new Color(206, 12, 15));
                NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("Total: " + Fargowiltas.swarmTotal), new Color(206, 12, 15));
            }
            else
            {
                Main.NewText("Killed: " + Fargowiltas.swarmKills, 206, 12, 15);
                Main.NewText("Total: " + Fargowiltas.swarmTotal, 206, 12, 15);
            }

            if (minion != -1 && NPC.CountNPCS(minion) >= Fargowiltas.swarmSpawned)
            {
                for (int i = 0; i < 200; i++)
                {
                    if (Main.npc[i].active && Main.npc[i].type == minion)
                    {
                        Main.npc[i].StrikeNPCNoInteraction(Main.npc[i].lifeMax, 0f, -Main.npc[i].direction, true);
                    }
                }
            }

            //if theres still more to spawn
            if (Fargowiltas.swarmKills <= Fargowiltas.swarmTotal - Fargowiltas.swarmSpawned)
            {
                int spawned = 0;

                for (int i = 0; i < 200; i++)
                {
                    //count npcs
                    int num = 0;
                    for (int j = 0; j < 200; j++)
                    {
                        if (Main.npc[j].active)
                        {
                            num++;
                        }
                    }
                    //kill a minion and spawn boss if too many npcs
                    if (num >= 200)
                    {
                        if (swarmActive && minion > 0 && i < 199)
                        {
                            if (Main.npc[i].type == minion)
                            {
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
                    NPC kill = Main.npc[i];
                    if (kill.active && !kill.friendly && kill.type != NPCID.LunarTowerNebula && kill.type != NPCID.LunarTowerSolar && kill.type != NPCID.LunarTowerStardust && kill.type != NPCID.LunarTowerVortex)
                    {
                        Main.npc[i].GetGlobalNPC<FargoGlobalNPC>().noLoot = true;
                        Main.npc[i].StrikeNPCNoInteraction(Main.npc[i].lifeMax, 0f, -Main.npc[i].direction, true);
                    }
                }

                Fargowiltas.swarmActive = false;
            }
            //make sure theres enough left to beat it
            else
            {
                //spawn more if needed
                if (count >= Fargowiltas.swarmSpawned || Fargowiltas.swarmTotal <= 20) return;

                int extraSpawn = 0;

                for (int i = 0; i < 200; i++)
                {
                    //count npcs
                    int num = 0;
                    for (int j = 0; j < 200; j++)
                    {
                        if (Main.npc[j].active)
                        {
                            num++;
                        }
                    }
                    //kill a minion and spawn boss if too many npcs
                    if (num >= 200)
                    {
                        if (swarmActive && minion > 0 && i < 199)
                        {
                            if (Main.npc[i].type == minion)
                            {
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
                    }

                    SpawnBoss(npc, boss);
                    extraSpawn++;

                    if (extraSpawn < 5)
                    {
                        continue;
                    }

                    break;
                }
            }
        }

        public override bool PreNPCLoot (NPC npc)
		{
            if (noLoot)
            {
                return false;
            }

            if(Fargowiltas.swarmActive /*|| Fargowiltas.pandoraActive*/ && (npc.type == NPCID.BlueSlime || npc.type == NPCID.EaterofWorldsBody || npc.type == NPCID.EaterofWorldsTail || npc.type == NPCID.Creeper || npc.type == NPCID.PirateCorsair || npc.type == NPCID.PirateDeadeye || npc.type == NPCID.PirateCrossbower))
            {
                return false;
            }

            if(swarmActive && Fargowiltas.swarmActive)
            {
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
                        Swarm(npc, NPCID.DungeonGuardian, -1, ItemID.BoneKey, "");
                        break;
                }

                if (Fargowiltas.instance.thoriumLoaded)
                {
                     Mod thorium = ModLoader.GetMod("ThoriumMod");

                    if (npc.type == thorium.NPCType("TheGrandThunderBirdv2"))
                    {
                        Swarm(npc, thorium.NPCType("TheGrandThunderBirdv2"), thorium.NPCType("Hatchling"), thorium.ItemType("ThunderBirdBag"), "");
                    }
                    else if (npc.type == thorium.NPCType("QueenJelly"))
                    {
                        Swarm(npc, thorium.NPCType("QueenJelly"), thorium.NPCType("ZealousJelly"), thorium.ItemType("JellyFishBag"), "");
                    }
                    else if (npc.type == thorium.NPCType("GraniteEnergyStorm"))
                    {
                        Swarm(npc, thorium.NPCType("GraniteEnergyStorm"), thorium.NPCType("EncroachingEnergy"), thorium.ItemType("GraniteBag"), "");
                    }
                    else if (npc.type == thorium.NPCType("TheBuriedWarrior"))
                    {
                        Swarm(npc, thorium.NPCType("TheBuriedWarrior"), -1, thorium.ItemType("HeroBag"), "");
                    }
                    else if (npc.type == thorium.NPCType("Viscount"))
                    {
                        Swarm(npc, thorium.NPCType("Viscount"), -1, thorium.ItemType("CountBag"), "");
                    }
                    else if (npc.type == thorium.NPCType("ThePrimeScouter"))
                    {
                        Swarm(npc, thorium.NPCType("ThePrimeScouter"), -1, thorium.ItemType("ScouterBag"), "");
                    }
                    else if (npc.type == thorium.NPCType("BoreanStriderPopped"))
                    {
                        Swarm(npc, thorium.NPCType("BoreanStrider"), thorium.ItemType("BoreanMyte1"), thorium.ItemType("BoreanBag"), "");
                    }
                    else if (npc.type == thorium.NPCType("FallenDeathBeholder2"))
                    {
                        Swarm(npc, thorium.NPCType("FallenDeathBeholder"), thorium.ItemType("EnemyBeholder"), thorium.ItemType("BeholderBag"), "");
                    }
                    else if (npc.type == thorium.NPCType("LichHeadless"))
                    {
                        Swarm(npc, thorium.NPCType("Lich"), -1, thorium.ItemType("LichBag"), "");
                    }
                    else if (npc.type == thorium.NPCType("AbyssionReleased"))
                    {
                        Swarm(npc, thorium.NPCType("Abyssion"), thorium.NPCType("AbyssalSpawn"), thorium.ItemType("AbyssionBag"), "");
                    }
                    else if (npc.type == thorium.NPCType("RealityBreaker"))
                    {
                        Swarm(npc, thorium.NPCType("Aquaius"), thorium.NPCType("AquaiusBubble"), thorium.ItemType("RagBag"), "");
                        Swarm(npc, thorium.NPCType("Omnicide"), -1, -1, "");
                        Swarm(npc, thorium.NPCType("SlagFury"), -1, -1, "");
                    }
                }

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
            if (npc.FindBuffIndex(mod.BuffType("WoodDrop")) != -1)
			{
				Item.NewItem(npc.Hitbox, ItemID.Wood, Main.rand.Next(10, 30));
			}

            switch(npc.type)
            {
                case NPCID.CultistBoss: //avoid lunar event with cultist summon
                    if (!pillarSpawn)
                    {
                        for (int i = 0; i < 200; i++)
                        {
                            NPC npc2 = Main.npc[i];
                            NPC.LunarApocalypseIsUp = false;

                            if (npc2.type == NPCID.LunarTowerNebula || npc2.type == NPCID.LunarTowerSolar || npc2.type == NPCID.LunarTowerStardust || npc2.type == NPCID.LunarTowerVortex)
                            {
                                NPC.TowerActiveSolar = true;
                                npc2.active = false;
                            }

                            NPC.TowerActiveSolar = false;
                        }
                    }
                    break;

                case NPCID.GreekSkeleton:
                    if (Main.rand.Next(15) == 0)
                    {
                        int i = Main.rand.Next(3);
                        switch (i)
                        {
                            case 0:
                                Item.NewItem(npc.Hitbox,
                                    ItemID.GladiatorHelmet);
                                break;
                            case 1:
                                Item.NewItem(npc.Hitbox,
                                    ItemID.GladiatorBreastplate);
                                break;
                            default:
                                Item.NewItem(npc.Hitbox,
                                    ItemID.GladiatorLeggings);
                                break;
                        }
                    }
                    break;

                case NPCID.Merchant:
                    if (Main.rand.Next(8) == 0)
                    {
                        Item.NewItem(npc.Hitbox, ItemID.MiningShirt);
                        Item.NewItem(npc.Hitbox, ItemID.MiningPants);
                    }
                    break;

                case NPCID.Nurse:
                    if (Main.rand.Next(5) == 0)
                        Item.NewItem(npc.Hitbox, ItemID.LifeCrystal);
                    break;

                case NPCID.Demolitionist:
                    if (Main.rand.Next(2) == 0)
                        Item.NewItem(npc.Hitbox, ItemID.Dynamite, 5);
                    break;

                case NPCID.Dryad:
                    if (Main.rand.Next(3) == 0)
                        Item.NewItem(npc.Hitbox, ItemID.HerbBag);
                    break;

                case NPCID.DD2Bartender:
                    if (Main.rand.Next(2) == 0)
                        Item.NewItem(npc.Hitbox, ItemID.Ale, 4);
                    break;

                case NPCID.ArmsDealer:
                    if (Main.rand.Next(4) == 0)
                        Item.NewItem(npc.Hitbox, ItemID.CrystalBullet, 30);
                    break;

                case NPCID.Painter:
                    if (NPC.AnyNPCs(NPCID.MoonLordCore))
                        Item.NewItem(npc.Hitbox, mod.ItemType("EchPainting"));
                    break;

                case NPCID.Angler:
                    if (Main.rand.Next(4) == 0)
                    {
                        int[] drops = { ItemID.FishermansGuide, ItemID.Sextant, ItemID.WeatherRadio };
                        Item.NewItem(npc.Hitbox,
                            drops[Main.rand.Next(drops.Length)]);
                    }
                    break;

                case NPCID.Clothier:
                    if (Main.rand.Next(20) == 0)
                        Item.NewItem(npc.Hitbox, ItemID.Skull);
                    break;

                case NPCID.Mechanic:
                    if (Main.rand.Next(5) == 0)
                        Item.NewItem(npc.Hitbox, ItemID.Wire, 40);
                    break;

                case NPCID.Wizard:
                    if (Main.rand.Next(5) == 0)
                        Item.NewItem(npc.Hitbox, ItemID.FallenStar, 5);
                    break;

                case NPCID.TaxCollector:
                    if (Main.rand.Next(8) == 0)
                        Item.NewItem(npc.Hitbox, ItemID.GoldCoin, 10);
                    break;

                case NPCID.Truffle:
                    if (Main.rand.Next(8) == 0)
                        Item.NewItem(npc.Hitbox, ItemID.MushroomStatue);
                    break;

                case NPCID.GoblinTinkerer:
                    if (Main.rand.Next(10) == 0)
                        Item.NewItem(npc.Hitbox, mod.ItemType("GoblinHead"), 1, false, 0, false, false);
                    break;

                case NPCID.DD2OgreT3:
                    if (!DD2Event.Ongoing)
                    {
                        if (Main.rand.Next(14) == 0)
                        {
                            Item.NewItem(npc.position, npc.Size, 3865, 1, false, 0, false, false);
                        }
                        if (Main.rand.Next(6) == 0)
                        {
                            Item.NewItem(npc.position, npc.Size, (int)Utils.SelectRandom<short>(Main.rand, new short[]
                            {
                            3809,
                            3811,
                            3810,
                            3812
                            }), 1, false, 0, false, false);
                        }
                        if (Main.rand.Next(6) == 0)
                        {
                            Item.NewItem(npc.position, npc.Size, (int)Utils.SelectRandom<short>(Main.rand, new short[]
                            {
                            3852,
                            3854,
                            3823,
                            3835,
                            3836
                            }), 1, false, 0, false, false);
                        }
                        if (Main.rand.Next(10) == 0)
                        {
                            Item.NewItem(npc.position, npc.Size, 3856, 1, false, 0, false, false);
                        }
                    }
                    break;

                case NPCID.DD2DarkMageT3:
                    if (!DD2Event.Ongoing)
                    {
                        if (Main.rand.Next(14) == 0)
                        {
                            Item.NewItem(npc.position, npc.Size, 3864, 1, false, 0, false, false);
                        }
                        if (Main.rand.Next(10) == 0)
                        {
                            if (Main.rand.Next(2) == 0)
                            {
                                Item.NewItem(npc.position, npc.Size, 3815, 4, false, 0, false, false);
                            }
                            else
                            {
                                Item.NewItem(npc.position, npc.Size, 3814, 1, false, 0, false, false);
                            }
                        }
                        if (Main.rand.Next(6) == 0)
                        {
                            Item.NewItem(npc.position, npc.Size, (int)Utils.SelectRandom<short>(Main.rand, new short[]
                            {
                            3857,
                            3855
                            }), 1, false, 0, false, false);
                        }
                        if (DD2Event.ShouldDropCrystals())
                        {
                            Item.NewItem(npc.position, npc.Size, 3822, 1, false, 0, false, false);
                        }
                    }
                    break;

                case NPCID.Raven:
                    if (!Main.halloween)
                        Item.NewItem(npc.Hitbox, ItemID.GoodieBag);
                    break;

                case NPCID.SlimeRibbonRed:
                    if (!Main.xMas)
                        Item.NewItem(npc.Hitbox, ItemID.Present);
                    break;

                case NPCID.BloodZombie:
                    if (Main.rand.Next(200) == 0)
                        Item.NewItem(npc.Hitbox, Main.rand.Next(2) == 0 ? ItemID.BladedGlove : ItemID.BloodyMachete);
                    break;

                case NPCID.Clown:
                    Item.NewItem(npc.Hitbox, ItemID.Bananarang);

                    FargoWorld.downedRareEnemy = true;
                    FargoWorld.downedClown = true;
                    break;

                case NPCID.BlueSlime:
                    if (npc.netID == NPCID.Pinky)
                    {
                        FargoWorld.downedRareEnemy = true;
                        FargoWorld.downedPinky = true;
                    }
                    break;

                case NPCID.UndeadMiner:
                    FargoWorld.downedRareEnemy = true;
                    FargoWorld.downedUndeadMiner = true;
                    break;

                case NPCID.Tim:
                    FargoWorld.downedRareEnemy = true;
                    FargoWorld.downedTim = true;
                    break;

                case NPCID.DoctorBones:
                    FargoWorld.downedRareEnemy = true;
                    FargoWorld.downedDoctorBones = true;
                    break;

                case NPCID.Mimic:
                    FargoWorld.downedRareEnemy = true;
                    FargoWorld.downedMimic = true;
                    break;

                case NPCID.WyvernHead:
                    FargoWorld.downedRareEnemy = true;
                    FargoWorld.downedWyvern = true;
                    break;

                case NPCID.RuneWizard:
                    FargoWorld.downedRareEnemy = true;
                    FargoWorld.downedRuneWizard = true;
                    break;

                case NPCID.Nymph:
                    FargoWorld.downedRareEnemy = true;
                    FargoWorld.downedNymph = true;
                    break;

                case NPCID.Moth:
                    FargoWorld.downedRareEnemy = true;
                    FargoWorld.downedMoth = true;
                    break;

                case NPCID.RainbowSlime:
                    FargoWorld.downedRareEnemy = true;
                    FargoWorld.downedRainbowSlime = true;
                    break;

                case NPCID.Paladin:
                    FargoWorld.downedRareEnemy = true;
                    FargoWorld.downedPaladin = true;
                    break;

                case NPCID.Medusa:
                    FargoWorld.downedRareEnemy = true;
                    FargoWorld.downedMedusa = true;
                    break;

                case NPCID.IceGolem:
                    FargoWorld.downedRareEnemy = true;
                    FargoWorld.downedIceGolem = true;
                    break;

                case NPCID.SandElemental:
                    FargoWorld.downedRareEnemy = true;
                    FargoWorld.downedSandElemental = true;
                    break;

                case NPCID.Mothron:
                    FargoWorld.downedRareEnemy = true;
                    FargoWorld.downedMothron = true;
                    break;

                case NPCID.BigMimicCorruption:
                    FargoWorld.downedRareEnemy = true;
                    FargoWorld.downedMimicCorrupt = true;
                    break;

                case NPCID.BigMimicHallow:
                    FargoWorld.downedRareEnemy = true;
                    FargoWorld.downedMimicHallow = true;
                    break;

                case NPCID.BigMimicCrimson:
                    FargoWorld.downedRareEnemy = true;
                    FargoWorld.downedMimicCrimson = true;
                    break;

                case NPCID.BigMimicJungle:
                    FargoWorld.downedRareEnemy = true;
                    FargoWorld.downedMimicJungle = true;
                    break;

                case NPCID.GoblinSummoner:
                    FargoWorld.downedRareEnemy = true;
                    FargoWorld.downedGoblinSummoner = true;
                    break;

                case NPCID.PirateShip:
                    FargoWorld.downedRareEnemy = true;
                    FargoWorld.downedFlyingDutchman = true;
                    break;

                case NPCID.DungeonSlime:
                    FargoWorld.downedRareEnemy = true;
                    FargoWorld.downedDungeonSlime = true;
                    break;

                case NPCID.PirateCaptain:
                    FargoWorld.downedRareEnemy = true;
                    FargoWorld.downedPirateCaptain = true;
                    break;

                case NPCID.SkeletonSniper:
                case NPCID.TacticalSkeleton:
                case NPCID.SkeletonCommando:
                    FargoWorld.downedRareEnemy = true;
                    FargoWorld.downedSkeletonGunAny = true;
                    break;

                case NPCID.Necromancer:
                case NPCID.NecromancerArmored:
                case NPCID.DiabolistRed:
                case NPCID.DiabolistWhite:
                case NPCID.RaggedCaster:
                case NPCID.RaggedCasterOpenCoat:
                    FargoWorld.downedRareEnemy = true;
                    FargoWorld.downedSkeletonMageAny = true;
                    break;

                case NPCID.BoneLee:
                    FargoWorld.downedRareEnemy = true;
                    FargoWorld.downedBoneLee = true;
                    break;

                default:
                    break;
            }
        }
		
		public override bool CheckDead(NPC npc)
		{
			Player player = Main.player[Main.myPlayer];
			FargoPlayer modPlayer = player.GetModPlayer<FargoPlayer>();

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

        public override void OnChatButtonClicked(NPC npc, bool firstButton)
        {
            if (FargoConfig.Instance.AnglerQuestInstantReset && Main.anglerQuestFinished) //no angler check enables luiafk compat
            {
                if (Main.netMode == 0)
                {
                    Main.AnglerQuestSwap();
                }
                else if (Main.netMode == 1)
                {
                    //broadcast swap request to server
                    var netMessage = mod.GetPacket();
                    netMessage.Write((byte)3);
                    netMessage.Send();
                }
            }
        }
    }
}