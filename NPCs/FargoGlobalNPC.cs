using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Fargowiltas.NPCs
{
    public class FargoGlobalNPC : GlobalNPC
    {
        internal static int[] Bosses = { NPCID.KingSlime, NPCID.EyeofCthulhu, NPCID.BrainofCthulhu, NPCID.QueenBee, NPCID.SkeletronHead, NPCID.TheDestroyer, NPCID.SkeletronPrime, NPCID.Retinazer, NPCID.Spazmatism, NPCID.Plantera, NPCID.Golem, NPCID.DukeFishron, NPCID.CultistBoss, NPCID.MoonLordCore, NPCID.MartianSaucerCore, NPCID.Pumpking, NPCID.IceQueen, NPCID.DD2Betsy, NPCID.DD2OgreT3, NPCID.IceGolem, NPCID.SandElemental, NPCID.Paladin, NPCID.Everscream, NPCID.MourningWood, NPCID.SantaNK1, NPCID.HeadlessHorseman, NPCID.PirateShip };

        internal bool PillarSpawn = true;
        internal bool SwarmActive;
        internal bool PandoraActive;
        internal bool NoLoot = false;

        private bool transform = true;

        public override bool InstancePerEntity => true;

        public override void SetDefaults(NPC npc)
        {
            if (npc.townNPC && npc.type < NPCID.Count && npc.type != NPCID.OldMan)
            {
                Main.npcCatchable[npc.type] = true;
                npc.catchItem = npc.type == NPCID.DD2Bartender ? (short)mod.ItemType("Tavernkeep") : (npc.type == NPCID.SkeletonMerchant ? (short)mod.ItemType("SkeletonMerchant") : (short)mod.ItemType(NPCID.GetUniqueKey(npc.type).Replace("Terraria ", string.Empty)));
            }
        }

        public override void AI(NPC npc)
        {
            // Wack ghost saucers begone
            if (FargoWorld.OverloadMartians && npc.type == NPCID.MartianSaucerCore && npc.dontTakeDamage)
            {
                npc.dontTakeDamage = false;
            }

            if (transform && Main.rand.NextBool(10))
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

            if (Fargowiltas.SwarmActive && Fargowiltas.ModLoaded["ThoriumMod"])
            {
                Mod thorium = ModLoader.GetMod("ThoriumMod");

                if (npc.type == thorium.NPCType("BoreanStriderPopped") || npc.type == thorium.NPCType("FallenDeathBeholder2") || npc.type == thorium.NPCType("LichHeadless") || npc.type == thorium.NPCType("AbyssionReleased"))
                {
                    SwarmActive = true;
                }
            }
        }

        public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
            Player player = Main.LocalPlayer;

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

                        if (player.anglerQuestsFinished >= 15)
                        {
                            shop.item[nextSlot].SetDefaults(ItemID.AnglerVest);
                            nextSlot++;

                            if (player.anglerQuestsFinished >= 20)
                            {
                                shop.item[nextSlot].SetDefaults(ItemID.AnglerPants);
                                nextSlot++;
                            }
                        }
                    }

                    break;

                case NPCID.Merchant:
                    if (player.anglerQuestsFinished >= 5)
                    {
                        shop.item[nextSlot].SetDefaults(ItemID.FuzzyCarrot);
                        nextSlot++;

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

                            if (Main.hardMode)
                            {
                                shop.item[nextSlot].SetDefaults(ItemID.FinWings);
                                nextSlot++;

                                shop.item[nextSlot].SetDefaults(ItemID.SuperAbsorbantSponge);
                                nextSlot++;

                                shop.item[nextSlot].SetDefaults(ItemID.BottomlessBucket);
                                nextSlot++;

                                if (player.anglerQuestsFinished >= 25)
                                {
                                    shop.item[nextSlot].SetDefaults(ItemID.HotlineFishingHook);
                                    nextSlot++;

                                    if (player.anglerQuestsFinished >= 30)
                                    {
                                        shop.item[nextSlot].SetDefaults(ItemID.GoldenFishingRod);
                                        nextSlot++;
                                    }
                                }
                            }
                        }
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

                case NPCID.Steampunker:
                    shop.item[nextSlot].SetDefaults(WorldGen.crimson ? ItemID.PurpleSolution : ItemID.RedSolution);
                    nextSlot++;

                    break;
            }
        }

        public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
        {
            if (player.GetFargoPlayer().BattleCry)
            {
                spawnRate = (int)(spawnRate * 0.1);
                maxSpawns = (int)(maxSpawns * 10f);
            }

            if ((FargoWorld.OverloadGoblins || FargoWorld.OverloadPirates) && player.position.X > Main.invasionX * 16.0 - 3000 && player.position.X < Main.invasionX * 16.0 + 3000)
            {
                if (FargoWorld.OverloadGoblins)
                {
                    spawnRate = (int)(spawnRate * 0.2);
                    maxSpawns = (int)(maxSpawns * 10f);
                }
                else if (FargoWorld.OverloadPirates)
                {
                    spawnRate = (int)(spawnRate * 0.2);
                    maxSpawns = (int)(maxSpawns * 30f);
                }
            }

            if (FargoWorld.OverloadPumpkinMoon || FargoWorld.OverloadFrostMoon)
            {
                spawnRate = (int)(spawnRate * 0.2);
                maxSpawns = (int)(maxSpawns * 10f);
            }
            else if (FargoWorld.OverloadMartians)
            {
                spawnRate = (int)(spawnRate * 0.2);
                maxSpawns = (int)(maxSpawns * 30f);
            }
        }

        public override void EditSpawnPool(IDictionary<int, float> pool, NPCSpawnInfo spawnInfo)
        {
            Player player = Main.LocalPlayer;

            if (FargoWorld.OverloadGoblins && player.position.X > Main.invasionX * 16.0 - 3000 && player.position.X < Main.invasionX * 16.0 + 3000)
            {
                // Literally nothing in the pool in the invasion so set everything to custom
                pool[NPCID.GoblinSummoner] = 1f;
                pool[NPCID.GoblinArcher] = 3f;
                pool[NPCID.GoblinPeon] = 5f;
                pool[NPCID.GoblinSorcerer] = 3f;
                pool[NPCID.GoblinWarrior] = 5f;
                pool[NPCID.GoblinThief] = 5f;
                pool[NPCID.GoblinScout] = 3f;
            }

            if (FargoWorld.OverloadPirates && player.position.X > Main.invasionX * 16.0 - 3000 && player.position.X < Main.invasionX * 16.0 + 3000)
            {
                // Literally nothing in the pool in the invasion so set everything to custom
                if (NPC.CountNPCS(NPCID.PirateShip) < 4)
                {
                    pool[NPCID.PirateShip] = .5f;
                }

                pool[NPCID.Parrot] = 2f;
                pool[NPCID.PirateCaptain] = 1f;
                pool[NPCID.PirateCrossbower] = 3f;
                pool[NPCID.PirateCorsair] = 5f;
                pool[NPCID.PirateDeadeye] = 4f;
                pool[NPCID.PirateDeckhand] = 5f;
            }

            if (FargoWorld.OverloadPumpkinMoon)
            {
                pool[NPCID.Pumpking] = 4f;
                pool[NPCID.MourningWood] = 4f;
                pool[NPCID.HeadlessHorseman] = 3f;
                pool[NPCID.Scarecrow1] = .5f;
                pool[NPCID.Scarecrow2] = .5f;
                pool[NPCID.Scarecrow3] = .5f;
                pool[NPCID.Scarecrow4] = .5f;
                pool[NPCID.Scarecrow5] = .5f;
                pool[NPCID.Scarecrow6] = .5f;
                pool[NPCID.Scarecrow7] = .5f;
                pool[NPCID.Scarecrow8] = .5f;
                pool[NPCID.Scarecrow9] = .5f;
                pool[NPCID.Scarecrow10] = .5f;
                pool[NPCID.Hellhound] = 3f;
                pool[NPCID.Poltergeist] = 3f;
                pool[NPCID.Splinterling] = 3f;
            }
            else if (FargoWorld.OverloadFrostMoon)
            {
                pool[NPCID.IceQueen] = 5f;
                pool[NPCID.Everscream] = 5f;
                pool[NPCID.SantaNK1] = 5f;
                pool[NPCID.ZombieElf] = 1f;
                pool[NPCID.ZombieElfBeard] = 1f;
                pool[NPCID.ZombieElfGirl] = 1f;
                pool[NPCID.GingerbreadMan] = 2f;
                pool[NPCID.ElfArcher] = 2f;
                pool[NPCID.Nutcracker] = 3f;
                pool[NPCID.ElfCopter] = 3f;
                pool[NPCID.Flocko] = 2f;
                pool[NPCID.Yeti] = 4f;
                pool[NPCID.PresentMimic] = 2f;
                pool[NPCID.Krampus] = 4f;
            }
            else if (FargoWorld.OverloadMartians)
            {
                pool[NPCID.MartianSaucerCore] = 1f;
                pool[NPCID.Scutlix] = 3f;
                pool[NPCID.MartianWalker] = 3f;
                pool[NPCID.MartianDrone] = 2f;
                pool[NPCID.GigaZapper] = 1f;
                pool[NPCID.MartianEngineer] = 2f;
                pool[NPCID.MartianOfficer] = 2f;
                pool[NPCID.RayGunner] = 1f;
                pool[NPCID.GrayGrunt] = 1f;
                pool[NPCID.BrainScrambler] = 1f;
            }
        }

        public override bool PreNPCLoot(NPC npc)
        {
            if (NoLoot)
            {
                return false;
            }

            if (Fargowiltas.SwarmActive && (npc.type == NPCID.BlueSlime || npc.type == NPCID.EaterofWorldsBody || npc.type == NPCID.EaterofWorldsTail || npc.type == NPCID.Creeper || (npc.type >= NPCID.PirateCorsair && npc.type <= NPCID.PirateCrossbower)))
            {
                return false;
            }

            if (SwarmActive && Fargowiltas.SwarmActive)
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
                        Swarm(npc, NPCID.EaterofWorldsHead, NPCID.EaterofWorldsTail, ItemID.EaterOfWorldsBossBag, "EnergizerWorm");
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
                        Swarm(npc, NPCID.Spazmatism, -1, -1, string.Empty);
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
                        Swarm(npc, NPCID.CultistBoss, -1, ItemID.CultistBossBag, string.Empty);
                        break;

                    case NPCID.MoonLordCore:
                        Swarm(npc, NPCID.MoonLordCore, NPCID.MoonLordFreeEye, ItemID.MoonLordBossBag, "EnergizerMoon");
                        break;

                    case NPCID.MourningWood:
                        Swarm(npc, NPCID.MourningWood, -1, -1, string.Empty);
                        break;

                    case NPCID.Pumpking:
                        Swarm(npc, NPCID.Pumpking, -1, -1, string.Empty);
                        break;

                    case NPCID.Everscream:
                        Swarm(npc, NPCID.Everscream, -1, -1, string.Empty);
                        break;

                    case NPCID.SantaNK1:
                        Swarm(npc, NPCID.SantaNK1, -1, -1, string.Empty);
                        break;

                    case NPCID.IceQueen:
                        Swarm(npc, NPCID.IceQueen, -1, -1, string.Empty);
                        break;

                    case NPCID.DD2Betsy:
                        Swarm(npc, NPCID.DD2Betsy, -1, -1, string.Empty);
                        break;

                    case NPCID.DD2OgreT3:
                        Swarm(npc, NPCID.DD2OgreT3, -1, -1, string.Empty);
                        break;

                    case NPCID.PirateShip:
                        Swarm(npc, NPCID.PirateShip, -1, -1, string.Empty);
                        break;

                    case NPCID.MartianSaucerCore:
                        Swarm(npc, NPCID.MartianSaucerCore, -1, -1, string.Empty);
                        break;

                    case NPCID.DungeonGuardian:
                        Swarm(npc, NPCID.DungeonGuardian, -1, ItemID.BoneKey, string.Empty);
                        break;
                }

                if (Fargowiltas.ModLoaded["ThoriumMod"])
                {
                    Mod thorium = ModLoader.GetMod("ThoriumMod");

                    if (npc.type == thorium.NPCType("TheGrandThunderBirdv2"))
                    {
                        Swarm(npc, thorium.NPCType("TheGrandThunderBirdv2"), thorium.NPCType("Hatchling"), thorium.ItemType("ThunderBirdBag"), string.Empty);
                    }
                    else if (npc.type == thorium.NPCType("QueenJelly"))
                    {
                        Swarm(npc, thorium.NPCType("QueenJelly"), thorium.NPCType("ZealousJelly"), thorium.ItemType("JellyFishBag"), string.Empty);
                    }
                    else if (npc.type == thorium.NPCType("GraniteEnergyStorm"))
                    {
                        Swarm(npc, thorium.NPCType("GraniteEnergyStorm"), thorium.NPCType("EncroachingEnergy"), thorium.ItemType("GraniteBag"), string.Empty);
                    }
                    else if (npc.type == thorium.NPCType("TheBuriedWarrior"))
                    {
                        Swarm(npc, thorium.NPCType("TheBuriedWarrior"), -1, thorium.ItemType("HeroBag"), string.Empty);
                    }
                    else if (npc.type == thorium.NPCType("Viscount"))
                    {
                        Swarm(npc, thorium.NPCType("Viscount"), -1, thorium.ItemType("CountBag"), string.Empty);
                    }
                    else if (npc.type == thorium.NPCType("ThePrimeScouter"))
                    {
                        Swarm(npc, thorium.NPCType("ThePrimeScouter"), -1, thorium.ItemType("ScouterBag"), string.Empty);
                    }
                    else if (npc.type == thorium.NPCType("BoreanStriderPopped"))
                    {
                        Swarm(npc, thorium.NPCType("BoreanStrider"), thorium.ItemType("BoreanMyte1"), thorium.ItemType("BoreanBag"), string.Empty);
                    }
                    else if (npc.type == thorium.NPCType("FallenDeathBeholder2"))
                    {
                        Swarm(npc, thorium.NPCType("FallenDeathBeholder"), thorium.ItemType("EnemyBeholder"), thorium.ItemType("BeholderBag"), string.Empty);
                    }
                    else if (npc.type == thorium.NPCType("LichHeadless"))
                    {
                        Swarm(npc, thorium.NPCType("Lich"), -1, thorium.ItemType("LichBag"), string.Empty);
                    }
                    else if (npc.type == thorium.NPCType("AbyssionReleased"))
                    {
                        Swarm(npc, thorium.NPCType("Abyssion"), thorium.NPCType("AbyssalSpawn"), thorium.ItemType("AbyssionBag"), string.Empty);
                    }
                    else if (npc.type == thorium.NPCType("RealityBreaker"))
                    {
                        Swarm(npc, thorium.NPCType("Aquaius"), thorium.NPCType("AquaiusBubble"), thorium.ItemType("RagBag"), string.Empty);
                        Swarm(npc, thorium.NPCType("Omnicide"), -1, -1, string.Empty);
                        Swarm(npc, thorium.NPCType("SlagFury"), -1, -1, string.Empty);
                    }
                }

                return false;
            }

            if (!PandoraActive)
            {
                return true;
            }

            Swarm(npc, 0, -1, -1, string.Empty);

            return false;
        }

        public override void NPCLoot(NPC npc)
        {
            // Lumber Jaxe
            if (npc.FindBuffIndex(mod.BuffType("WoodDrop")) != -1)
            {
                Item.NewItem(npc.Hitbox, ItemID.Wood, Main.rand.Next(10, 30));
            }

            switch (npc.type)
            {
                // Avoid lunar event with cultist summon
                case NPCID.CultistBoss:
                    if (!PillarSpawn)
                    {
                        for (int i = 0; i < Main.maxNPCs; i++)
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
                    if (Main.rand.NextBool(15))
                    {
                        int i = Main.rand.Next(3);
                        switch (i)
                        {
                            case 0:
                                Item.NewItem(npc.Hitbox, ItemID.GladiatorHelmet);
                                break;

                            case 1:
                                Item.NewItem(npc.Hitbox, ItemID.GladiatorBreastplate);
                                break;

                            default:
                                Item.NewItem(npc.Hitbox, ItemID.GladiatorLeggings);
                                break;
                        }
                    }

                    break;

                case NPCID.Merchant:
                    if (Main.rand.NextBool(8))
                    {
                        Item.NewItem(npc.Hitbox, ItemID.MiningShirt);
                        Item.NewItem(npc.Hitbox, ItemID.MiningPants);
                    }

                    break;

                case NPCID.Nurse:
                    if (Main.rand.NextBool(5))
                    {
                        Item.NewItem(npc.Hitbox, ItemID.LifeCrystal);
                    }

                    break;

                case NPCID.Demolitionist:
                    if (Main.rand.NextBool(2))
                    {
                        Item.NewItem(npc.Hitbox, ItemID.Dynamite, 5);
                    }

                    break;

                case NPCID.Dryad:
                    if (Main.rand.NextBool(3))
                    {
                        Item.NewItem(npc.Hitbox, ItemID.HerbBag);
                    }

                    break;

                case NPCID.DD2Bartender:
                    if (Main.rand.NextBool(2))
                    {
                        Item.NewItem(npc.Hitbox, ItemID.Ale, 4);
                    }

                    break;

                case NPCID.ArmsDealer:
                    if (Main.rand.NextBool(4))
                    {
                        Item.NewItem(npc.Hitbox, ItemID.CrystalBullet, 30);
                    }

                    break;

                case NPCID.Painter:
                    if (NPC.AnyNPCs(NPCID.MoonLordCore))
                    {
                        Item.NewItem(npc.Hitbox, mod.ItemType("EchPainting"));
                    }

                    break;

                case NPCID.Angler:
                    if (Main.rand.NextBool(4))
                    {
                        int[] drops = { ItemID.FishermansGuide, ItemID.Sextant, ItemID.WeatherRadio };
                        Item.NewItem(npc.Hitbox, Main.rand.Next(drops));
                    }

                    break;

                case NPCID.Clothier:
                    if (Main.rand.NextBool(20))
                    {
                        Item.NewItem(npc.Hitbox, ItemID.Skull);
                    }

                    break;

                case NPCID.Mechanic:
                    if (Main.rand.NextBool(5))
                    {
                        Item.NewItem(npc.Hitbox, ItemID.Wire, 40);
                    }

                    break;

                case NPCID.Wizard:
                    if (Main.rand.NextBool(5))
                    {
                        Item.NewItem(npc.Hitbox, ItemID.FallenStar, 5);
                    }

                    break;

                case NPCID.TaxCollector:
                    if (Main.rand.NextBool(8))
                    {
                        Item.NewItem(npc.Hitbox, ItemID.GoldCoin, 10);
                    }

                    break;

                case NPCID.Truffle:
                    if (Main.rand.NextBool(8))
                    {
                        Item.NewItem(npc.Hitbox, ItemID.MushroomStatue);
                    }

                    break;

                case NPCID.GoblinTinkerer:
                    if (Main.rand.NextBool(10))
                    {
                        Item.NewItem(npc.Hitbox, mod.ItemType("GoblinHead"));
                    }

                    break;

                case NPCID.DD2OgreT3:
                    FargoWorld.DownedBools["ogre"] = true;
                    if (!DD2Event.Ongoing)
                    {
                        if (Main.rand.NextBool(14))
                        {
                            Item.NewItem(npc.Hitbox, ItemID.BossMaskOgre);
                        }

                        if (Main.rand.NextBool(6))
                        {
                            Item.NewItem(npc.Hitbox, Main.rand.Next(new short[] { ItemID.ApprenticeScarf, ItemID.SquireShield, ItemID.HuntressBuckler, ItemID.MonkBelt }));
                        }

                        if (Main.rand.NextBool(6))
                        {
                            Item.NewItem(npc.Hitbox, Main.rand.Next(new short[] { ItemID.DD2SquireDemonSword, ItemID.MonkStaffT1, ItemID.MonkStaffT2, ItemID.BookStaff, ItemID.DD2PhoenixBow }));
                        }

                        if (Main.rand.NextBool(10))
                        {
                            Item.NewItem(npc.Hitbox, ItemID.DD2PetGhost);
                        }
                    }

                    break;

                case NPCID.DD2DarkMageT3:
                    FargoWorld.DownedBools["darkMage3"] = true;
                    if (!DD2Event.Ongoing)
                    {
                        if (Main.rand.NextBool(14))
                        {
                            Item.NewItem(npc.Hitbox, ItemID.BossMaskDarkMage);
                        }

                        if (Main.rand.NextBool(10))
                        {
                            if (Main.rand.NextBool(2))
                            {
                                Item.NewItem(npc.Hitbox, ItemID.WarTableBanner);
                            }
                            else
                            {
                                Item.NewItem(npc.Hitbox, ItemID.WarTable);
                            }
                        }

                        if (Main.rand.NextBool(6))
                        {
                            Item.NewItem(npc.Hitbox, Main.rand.Next(new short[] { ItemID.DD2PetGato, ItemID.DD2PetDragon }));
                        }

                        if (DD2Event.ShouldDropCrystals())
                        {
                            Item.NewItem(npc.Hitbox, ItemID.DD2EnergyCrystal);
                        }
                    }

                    break;

                case NPCID.Raven:
                    if (!Main.halloween)
                    {
                        Item.NewItem(npc.Hitbox, ItemID.GoodieBag);
                    }

                    break;

                case NPCID.SlimeRibbonRed:
                    if (!Main.xMas)
                    {
                        Item.NewItem(npc.Hitbox, ItemID.Present);
                    }

                    break;

                case NPCID.BloodZombie:
                    if (Main.rand.NextBool(200))
                    {
                        Item.NewItem(npc.Hitbox, Main.rand.NextBool(2) ? ItemID.BladedGlove : ItemID.BloodyMachete);
                    }

                    break;

                case NPCID.Clown:
                    Item.NewItem(npc.Hitbox, ItemID.Bananarang);

                    FargoWorld.DownedBools["rareEnemy"] = true;
                    FargoWorld.DownedBools["clown"] = true;
                    break;

                case NPCID.BlueSlime:
                    if (npc.netID == NPCID.Pinky)
                    {
                        FargoWorld.DownedBools["rareEnemy"] = true;
                        FargoWorld.DownedBools["pinky"] = true;
                    }

                    break;

                case NPCID.UndeadMiner:
                    FargoWorld.DownedBools["rareEnemy"] = true;
                    FargoWorld.DownedBools["undeadMiner"] = true;
                    break;

                case NPCID.Tim:
                    FargoWorld.DownedBools["rareEnemy"] = true;
                    FargoWorld.DownedBools["tim"] = true;
                    break;

                case NPCID.DoctorBones:
                    FargoWorld.DownedBools["rareEnemy"] = true;
                    FargoWorld.DownedBools["doctorBones"] = true;
                    break;

                case NPCID.Mimic:
                    FargoWorld.DownedBools["rareEnemy"] = true;
                    FargoWorld.DownedBools["mimic"] = true;
                    break;

                case NPCID.WyvernHead:
                    FargoWorld.DownedBools["rareEnemy"] = true;
                    FargoWorld.DownedBools["wyvern"] = true;
                    break;

                case NPCID.RuneWizard:
                    FargoWorld.DownedBools["rareEnemy"] = true;
                    FargoWorld.DownedBools["runeWizard"] = true;
                    break;

                case NPCID.Nymph:
                    FargoWorld.DownedBools["rareEnemy"] = true;
                    FargoWorld.DownedBools["nymph"] = true;
                    break;

                case NPCID.Moth:
                    FargoWorld.DownedBools["rareEnemy"] = true;
                    FargoWorld.DownedBools["moth"] = true;
                    break;

                case NPCID.RainbowSlime:
                    FargoWorld.DownedBools["rareEnemy"] = true;
                    FargoWorld.DownedBools["rainbowSlime"] = true;
                    break;

                case NPCID.Paladin:
                    FargoWorld.DownedBools["rareEnemy"] = true;
                    FargoWorld.DownedBools["paladin"] = true;
                    break;

                case NPCID.Medusa:
                    FargoWorld.DownedBools["rareEnemy"] = true;
                    FargoWorld.DownedBools["medusa"] = true;
                    break;

                case NPCID.IceGolem:
                    FargoWorld.DownedBools["rareEnemy"] = true;
                    FargoWorld.DownedBools["iceGolem"] = true;
                    break;

                case NPCID.SandElemental:
                    FargoWorld.DownedBools["rareEnemy"] = true;
                    FargoWorld.DownedBools["sandElemental"] = true;
                    break;

                case NPCID.Mothron:
                    FargoWorld.DownedBools["rareEnemy"] = true;
                    FargoWorld.DownedBools["mothron"] = true;
                    break;

                case NPCID.BigMimicCorruption:
                    FargoWorld.DownedBools["rareEnemy"] = true;
                    FargoWorld.DownedBools["mimicCorrupt"] = true;
                    break;

                case NPCID.BigMimicHallow:
                    FargoWorld.DownedBools["rareEnemy"] = true;
                    FargoWorld.DownedBools["mimicHallow"] = true;
                    break;

                case NPCID.BigMimicCrimson:
                    FargoWorld.DownedBools["rareEnemy"] = true;
                    FargoWorld.DownedBools["mimicCrimson"] = true;
                    break;

                case NPCID.BigMimicJungle:
                    FargoWorld.DownedBools["rareEnemy"] = true;
                    FargoWorld.DownedBools["mimicJungle"] = true;
                    break;

                case NPCID.GoblinSummoner:
                    FargoWorld.DownedBools["rareEnemy"] = true;
                    FargoWorld.DownedBools["goblinSummoner"] = true;
                    break;

                case NPCID.PirateShip:
                    FargoWorld.DownedBools["rareEnemy"] = true;
                    FargoWorld.DownedBools["flyingDutchman"] = true;
                    break;

                case NPCID.DungeonSlime:
                    FargoWorld.DownedBools["rareEnemy"] = true;
                    FargoWorld.DownedBools["dungeonSlime"] = true;
                    break;

                case NPCID.PirateCaptain:
                    FargoWorld.DownedBools["rareEnemy"] = true;
                    FargoWorld.DownedBools["pirateCaptain"] = true;
                    break;

                case NPCID.SkeletonSniper:
                case NPCID.TacticalSkeleton:
                case NPCID.SkeletonCommando:
                    FargoWorld.DownedBools["rareEnemy"] = true;
                    FargoWorld.DownedBools["skeletonGun"] = true;
                    break;

                case NPCID.Necromancer:
                case NPCID.NecromancerArmored:
                case NPCID.DiabolistRed:
                case NPCID.DiabolistWhite:
                case NPCID.RaggedCaster:
                case NPCID.RaggedCasterOpenCoat:
                    FargoWorld.DownedBools["rareEnemy"] = true;
                    FargoWorld.DownedBools["skeletonMage"] = true;
                    break;

                case NPCID.BoneLee:
                    FargoWorld.DownedBools["rareEnemy"] = true;
                    FargoWorld.DownedBools["boneLee"] = true;
                    break;

                default:
                    break;
            }
        }

        public override bool CheckDead(NPC npc)
        {
            if (npc.type == NPCID.DD2Betsy && !PandoraActive)
            {
                Main.NewText("Betsy has been defeated!", 175, 75);
                FargoWorld.DownedBools["betsy"] = true;
            }

            if (npc.boss)
            {
                FargoWorld.DownedBools["boss"] = true;
            }

            return true;
        }

        public override void ModifyHitByProjectile(NPC npc, Projectile projectile, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            if (projectile.type == ProjectileID.RottenEgg && npc.townNPC)
            {
                damage *= 20;
            }
        }

        public override void OnChatButtonClicked(NPC npc, bool firstButton)
        {
            // No angler check enables luiafk compatibility
            if (GetInstance<FargoConfig>().AnglerQuestInstantReset && Main.anglerQuestFinished)
            {
                if (Main.netMode == NetmodeID.SinglePlayer)
                {
                    Main.AnglerQuestSwap();
                }
                else if (Main.netMode == NetmodeID.MultiplayerClient)
                {
                    // Broadcast swap request to server
                    var netMessage = mod.GetPacket();
                    netMessage.Write((byte)3);
                    netMessage.Send();
                }
            }
        }

        private void SpawnBoss(NPC npc, int boss)
        {
            int spawn;

            if (SwarmActive)
            {
                spawn = NPC.NewNPC((int)npc.position.X + Main.rand.Next(-1000, 1000), (int)npc.position.Y + Main.rand.Next(-400, -100), boss);

                if (spawn < Main.maxNPCs)
                {
                    Main.npc[spawn].GetGlobalNPC<FargoGlobalNPC>().SwarmActive = true;
                    NetMessage.SendData(MessageID.SyncNPC, number: boss);
                }
            }
            else
            {
                // Pandora
                int random;

                do
                {
                    random = Main.rand.Next(Bosses);
                }
                while (NPC.CountNPCS(random) >= 4);

                spawn = NPC.NewNPC((int)npc.position.X + Main.rand.Next(-1000, 1000), (int)npc.position.Y + Main.rand.Next(-400, -100), random);
                Main.npc[spawn].GetGlobalNPC<FargoGlobalNPC>().PandoraActive = true;
                NetMessage.SendData(MessageID.SyncNPC, number: random);
            }
        }

        private void Swarm(NPC npc, int boss, int minion, int bossbag, string reward)
        {
            if (bossbag >= 0)
            {
                npc.DropItemInstanced(npc.Center, npc.Size, bossbag);
            }

            int count = 0;
            if (SwarmActive)
            {
                count = NPC.CountNPCS(boss) - 1; // Since this one is about to be dead
            }
            else
            {
                // Pandora
                for (int i = 0; i < Main.maxNPCs; i++)
                {
                    if (Main.npc[i].active && Array.IndexOf(Bosses, Main.npc[i].type) > -1)
                    {
                        count++;
                    }
                }
            }

            int missing = Fargowiltas.SwarmSpawned - count;

            Fargowiltas.SwarmKills++;

            // Drop swarm reward every 100 kills
            if (Fargowiltas.SwarmKills % 100 == 0 && !string.IsNullOrEmpty(reward))
            {
                Item.NewItem(npc.Hitbox, mod.ItemType(reward));
            }

            if (Main.netMode == NetmodeID.Server)
            {
                NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("Killed: " + Fargowiltas.SwarmKills), new Color(206, 12, 15));
                NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("Total: " + Fargowiltas.SwarmTotal), new Color(206, 12, 15));
            }
            else
            {
                Main.NewText("Killed: " + Fargowiltas.SwarmKills, new Color(206, 12, 15));
                Main.NewText("Total: " + Fargowiltas.SwarmTotal, new Color(206, 12, 15));
            }

            if (minion != -1 && NPC.CountNPCS(minion) >= Fargowiltas.SwarmSpawned)
            {
                for (int i = 0; i < Main.maxNPCs; i++)
                {
                    if (Main.npc[i].active && Main.npc[i].type == minion)
                    {
                        Main.npc[i].StrikeNPCNoInteraction(Main.npc[i].lifeMax, 0f, -Main.npc[i].direction, true);
                    }
                }
            }

            // If theres still more to spawn
            if (Fargowiltas.SwarmKills <= Fargowiltas.SwarmTotal - Fargowiltas.SwarmSpawned)
            {
                int spawned = 0;

                for (int i = 0; i < Main.maxNPCs; i++)
                {
                    // Count NPCs
                    int num = 0;
                    for (int j = 0; j < Main.maxNPCs; j++)
                    {
                        if (Main.npc[j].active)
                        {
                            num++;
                        }
                    }

                    // Kill a minion and spawn boss if too many npcs
                    if (num >= Main.maxNPCs)
                    {
                        if (SwarmActive && minion > 0 && i < Main.maxNPCs - 1)
                        {
                            if (Main.npc[i].type == minion)
                            {
                                Main.npc[i].StrikeNPCNoInteraction(Main.npc[i].lifeMax, 0f, -Main.npc[i].direction, true);
                            }
                        }
                        else
                        {
                            // Pandora
                            if (Array.IndexOf(Bosses, Main.npc[i].type) == -1 && !Main.npc[i].boss)
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
            else if (Fargowiltas.SwarmKills >= Fargowiltas.SwarmTotal)
            {
                if (Main.netMode == NetmodeID.Server)
                {
                    NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("The swarm has been defeated!"), new Color(206, 12, 15));
                }
                else
                {
                    Main.NewText("The swarm has been defeated!", new Color(206, 12, 15));
                }

                for (int i = 0; i < Main.maxNPCs; i++)
                {
                    NPC kill = Main.npc[i];
                    if (kill.active && !kill.friendly && kill.type != NPCID.LunarTowerNebula && kill.type != NPCID.LunarTowerSolar && kill.type != NPCID.LunarTowerStardust && kill.type != NPCID.LunarTowerVortex)
                    {
                        Main.npc[i].GetGlobalNPC<FargoGlobalNPC>().NoLoot = true;
                        Main.npc[i].StrikeNPCNoInteraction(Main.npc[i].lifeMax, 0f, -Main.npc[i].direction, true);
                    }
                }

                Fargowiltas.SwarmActive = false;
            }

            // Make sure theres enough left to beat it
            else
            {
                // Spawn more if needed
                if (count >= Fargowiltas.SwarmSpawned || Fargowiltas.SwarmTotal <= 20)
                {
                    return;
                }

                int extraSpawn = 0;

                for (int i = 0; i < Main.maxNPCs; i++)
                {
                    // Count NPCs
                    int num = 0;
                    for (int j = 0; j < Main.maxNPCs; j++)
                    {
                        if (Main.npc[j].active)
                        {
                            num++;
                        }
                    }

                    // Kill a minion and spawn boss if too many NPCs
                    if (num >= Main.maxNPCs)
                    {
                        if (SwarmActive && minion > 0 && i < Main.maxNPCs - 1)
                        {
                            if (Main.npc[i].type == minion)
                            {
                                Main.npc[i].StrikeNPCNoInteraction(Main.npc[i].lifeMax, 0f, -Main.npc[i].direction, true);
                            }
                        }
                        else
                        {
                            // Pandora
                            if (Array.IndexOf(Bosses, Main.npc[i].type) == -1 && !Main.npc[i].boss)
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
    }
}