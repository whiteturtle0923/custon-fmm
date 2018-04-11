using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Terraria.Localization;
using Terraria.GameContent.Events;
using Terraria.DataStructures;
using Fargowiltas.Projectiles;
using System.Reflection;

namespace Fargowiltas.NPCs
{
    public class FargoGlobalNPC : GlobalNPC
    {
        public override bool InstancePerEntity
        {
            get
            {
                return true;
            }
        }
        public bool sBleed = false;
        public bool shock = false;
        public bool rotting = false;

        //masochist doom
        public bool transform = false;
        public int regenTimer;
        public int counter = 1;
        public int sharkCount = 0;
        private static MethodInfo _startSandstormMethod;

        public override void ResetEffects(NPC npc)
        {
            sBleed = false;
            shock = false;
            rotting = false;
        }

        public override void SetDefaults(NPC npc)
        {
            if (FargoWorld.masochistMode)
            {
                ResetRegenTimer(npc);

                if (npc.type == NPCID.Salamander || npc.type == NPCID.Salamander2 || npc.type == NPCID.Salamander3 || npc.type == NPCID.Salamander4 || npc.type == NPCID.Salamander5 || npc.type == NPCID.Salamander6 || npc.type == NPCID.Salamander7 || npc.type == NPCID.Salamander8 || npc.type == NPCID.Salamander9)
                {
                    npc.Opacity /= 25;
                }

                //boss scaling 
                // +2.5% hp each kill 
                // +1.25% damage each kill
                // max of 4x hp and 2.5x damage

                //pre hm get 8x and 5x

                if (npc.type == NPCID.EyeofCthulhu || npc.type == NPCID.ServantofCthulhu)
                {
                    npc.lifeMax = (int)(npc.lifeMax * (1 + FargoWorld.eyeCount * .025));
                    npc.damage = (int)(npc.damage * (1 + FargoWorld.eyeCount * .0125));
                }
                if (npc.type == NPCID.KingSlime)
                {
                    npc.lifeMax = (int)(npc.lifeMax * (1 + FargoWorld.slimeCount * .025));
                    npc.damage = (int)(npc.damage * (1 + FargoWorld.slimeCount * .0125));
                }
                if (npc.type == NPCID.EaterofWorldsHead || npc.type == NPCID.EaterofWorldsBody || npc.type == NPCID.EaterofWorldsTail)
                {
                    npc.lifeMax = (int)(npc.lifeMax * (1 + FargoWorld.eyeCount * .025));
                    npc.damage = (int)(npc.damage * (1 + FargoWorld.eyeCount * .0125));
                }
                if (npc.type == NPCID.BrainofCthulhu || npc.type == NPCID.Creeper)
                {
                    npc.lifeMax = (int)(npc.lifeMax * (1 + FargoWorld.brainCount * .025));
                    npc.damage = (int)(npc.damage * (1 + FargoWorld.brainCount * .0125));
                }
                if (npc.type == NPCID.QueenBee)
                {
                    npc.lifeMax = (int)(npc.lifeMax * (1 + FargoWorld.beeCount * .025));
                    npc.damage = (int)(npc.damage * (1 + FargoWorld.beeCount * .0125));
                }
                if (npc.type == NPCID.SkeletronHead || npc.type == NPCID.SkeletronHand)
                {
                    npc.lifeMax = (int)(npc.lifeMax * (1 + FargoWorld.skeletronCount * .025));
                    npc.damage = (int)(npc.damage * (1 + FargoWorld.skeletronCount * .0125));
                }
                if (npc.type == NPCID.WallofFlesh || npc.type == NPCID.WallofFleshEye)
                {
                    npc.lifeMax = (int)(npc.lifeMax * (1 + FargoWorld.wallCount * .025));
                    npc.damage = (int)(npc.damage * (1 + FargoWorld.wallCount * .0125));
                }
                if (npc.type == NPCID.TheDestroyer || npc.type == NPCID.TheDestroyerBody || npc.type == NPCID.TheDestroyerTail)
                {
                    npc.lifeMax = (int)(npc.lifeMax * (1 + FargoWorld.destroyerCount * .025));
                    npc.damage = (int)(npc.damage * (1 + FargoWorld.destroyerCount * .0125));
                }
                if (npc.type == NPCID.SkeletronPrime || npc.type == NPCID.PrimeCannon || npc.type == NPCID.PrimeLaser || npc.type == NPCID.PrimeSaw || npc.type == NPCID.PrimeVice)
                {
                    npc.lifeMax = (int)(npc.lifeMax * (1 + FargoWorld.primeCount * .025));
                    npc.damage = (int)(npc.damage * (1 + FargoWorld.primeCount * .0125));
                }
                if (npc.type == NPCID.Retinazer || npc.type == NPCID.Spazmatism)
                {
                    npc.lifeMax = (int)(npc.lifeMax * (1 + FargoWorld.twinsCount * .025));
                    npc.damage = (int)(npc.damage * (1 + FargoWorld.twinsCount * .0125));
                }
                if (npc.type == NPCID.Plantera || npc.type == NPCID.PlanterasHook || npc.type == NPCID.PlanterasTentacle)
                {
                    npc.lifeMax = (int)(npc.lifeMax * (1 + FargoWorld.planteraCount * .025));
                    npc.damage = (int)(npc.damage * (1 + FargoWorld.planteraCount * .0125));
                }
                if (npc.type == NPCID.Golem || npc.type == NPCID.GolemFistLeft || npc.type == NPCID.GolemFistRight || npc.type == NPCID.GolemHead || npc.type == NPCID.GolemHeadFree)
                {
                    npc.lifeMax = (int)(npc.lifeMax * (1 + FargoWorld.golemCount * .025));
                    npc.damage = (int)(npc.damage * (1 + FargoWorld.golemCount * .0125));
                }
                if (npc.type == NPCID.CultistBoss)
                {
                    npc.lifeMax = (int)(npc.lifeMax * (1 + FargoWorld.cultistCount * .025));
                    npc.damage = (int)(npc.damage * (1 + FargoWorld.cultistCount * .0125));
                }
                if (npc.type == NPCID.DukeFishron)
                {
                    npc.lifeMax = (int)(npc.lifeMax * (1 + FargoWorld.fishronCount * .025));
                    npc.damage = (int)(npc.damage * (1 + FargoWorld.fishronCount * .0125));
                }
                if (npc.type == NPCID.MoonLordCore || npc.type == NPCID.MoonLordHand || npc.type == NPCID.MoonLordHead || npc.type == NPCID.MoonLordFreeEye || npc.type == NPCID.MoonLordLeechBlob)
                {
                    npc.lifeMax = (int)(npc.lifeMax * (1 + FargoWorld.moonlordCount * .025));
                    npc.damage = (int)(npc.damage * (1 + FargoWorld.moonlordCount * .0125));
                }

                if (npc.type == NPCID.WalkingAntlion)
                {
                    npc.knockBackResist = 0f;
                }
            }

            // bug net town NPCs!
            if (npc.type == NPCID.Guide)
            {
                Main.npcCatchable[npc.type] = true;
                npc.catchItem = (short)mod.ItemType("Guide");
            }
            if (npc.type == NPCID.Merchant)
            {
                Main.npcCatchable[npc.type] = true;
                npc.catchItem = (short)mod.ItemType("Merchant");
            }
            if (npc.type == NPCID.Nurse)
            {
                Main.npcCatchable[npc.type] = true;
                npc.catchItem = (short)mod.ItemType("Nurse");
            }
            if (npc.type == NPCID.Demolitionist)
            {
                Main.npcCatchable[npc.type] = true;
                npc.catchItem = (short)mod.ItemType("Demolitionist");
            }
            if (npc.type == NPCID.DyeTrader)
            {
                Main.npcCatchable[npc.type] = true;
                npc.catchItem = (short)mod.ItemType("DyeTrader");
            }
            if (npc.type == NPCID.Dryad)
            {
                Main.npcCatchable[npc.type] = true;
                npc.catchItem = (short)mod.ItemType("Dryad");
            }
            if (npc.type == NPCID.DD2Bartender)
            {
                Main.npcCatchable[npc.type] = true;
                npc.catchItem = (short)mod.ItemType("Tavernkeep");
            }
            if (npc.type == NPCID.ArmsDealer)
            {
                Main.npcCatchable[npc.type] = true;
                npc.catchItem = (short)mod.ItemType("ArmsDealer");
            }
            if (npc.type == NPCID.Stylist)
            {
                Main.npcCatchable[npc.type] = true;
                npc.catchItem = (short)mod.ItemType("Stylist");
            }
            if (npc.type == NPCID.Painter)
            {
                Main.npcCatchable[npc.type] = true;
                npc.catchItem = (short)mod.ItemType("Painter");
            }
            if (npc.type == NPCID.Angler)
            {
                Main.npcCatchable[npc.type] = true;
                npc.catchItem = (short)mod.ItemType("Angler");
            }
            if (npc.type == NPCID.GoblinTinkerer)
            {
                Main.npcCatchable[npc.type] = true;
                npc.catchItem = (short)mod.ItemType("GoblinTinkerer");
            }
            if (npc.type == NPCID.WitchDoctor)
            {
                Main.npcCatchable[npc.type] = true;
                npc.catchItem = (short)mod.ItemType("WitchDoctor");
            }
            if (npc.type == NPCID.Clothier)
            {
                Main.npcCatchable[npc.type] = true;
                npc.catchItem = (short)mod.ItemType("Clothier");
            }
            if (npc.type == NPCID.Mechanic)
            {
                Main.npcCatchable[npc.type] = true;
                npc.catchItem = (short)mod.ItemType("Mechanic");
            }
            if (npc.type == NPCID.PartyGirl)
            {
                Main.npcCatchable[npc.type] = true;
                npc.catchItem = (short)mod.ItemType("PartyGirl");
            }
            if (npc.type == NPCID.Wizard)
            {
                Main.npcCatchable[npc.type] = true;
                npc.catchItem = (short)mod.ItemType("Wizard");
            }
            if (npc.type == NPCID.TaxCollector)
            {
                Main.npcCatchable[npc.type] = true;
                npc.catchItem = (short)mod.ItemType("TaxCollector");
            }
            if (npc.type == NPCID.Truffle)
            {
                Main.npcCatchable[npc.type] = true;
                npc.catchItem = (short)mod.ItemType("Truffle");
            }
            if (npc.type == NPCID.Pirate)
            {
                Main.npcCatchable[npc.type] = true;
                npc.catchItem = (short)mod.ItemType("Pirate");
            }
            if (npc.type == NPCID.Steampunker)
            {
                Main.npcCatchable[npc.type] = true;
                npc.catchItem = (short)mod.ItemType("Steampunker");
            }
            if (npc.type == NPCID.Cyborg)
            {
                Main.npcCatchable[npc.type] = true;
                npc.catchItem = (short)mod.ItemType("Cyborg");
            }
            if (npc.type == NPCID.TravellingMerchant)
            {
                Main.npcCatchable[npc.type] = true;
                npc.catchItem = (short)mod.ItemType("TravellingMerchant");
            }
            if (npc.type == NPCID.SkeletonMerchant)
            {
                Main.npcCatchable[npc.type] = true;
                npc.catchItem = (short)mod.ItemType("SkeletonMerchant");
            }

        }

        public override void AI(NPC npc)
        {

            if (FargoWorld.masochistMode)
            {

                if (regenTimer > 0)
                {
                    regenTimer--;
                }

                //transformations
                if(!transform)
                {
                    if (npc.type == NPCID.BlueSlime && npc.netID == 1 && NPC.downedSlimeKing && Main.rand.Next(5) == 0)
                    {
                        npc.Transform(NPCID.SlimeSpiked);
                    }
                    if (npc.type == NPCID.Zombie && NPC.downedBoss1 && Main.rand.Next(5) == 0)
                    {
                        npc.Transform(NPCID.ArmedZombie);
                    }
                    if (npc.type == NPCID.ZombieEskimo && NPC.downedBoss1 && Main.rand.Next(5) == 0)
                    {
                        npc.Transform(NPCID.ArmedZombieEskimo);
                    }
                    if (npc.type == NPCID.PincushionZombie && NPC.downedBoss1 && Main.rand.Next(5) == 0)
                    {
                        npc.Transform(NPCID.ArmedZombiePincussion);
                    }
                    if (npc.type == NPCID.FemaleZombie && NPC.downedBoss1 && Main.rand.Next(5) == 0)
                    {
                        npc.Transform(NPCID.ArmedZombieCenx);
                    }
                    if (npc.type == NPCID.SlimedZombie && NPC.downedBoss1 && Main.rand.Next(5) == 0)
                    {
                        npc.Transform(NPCID.ArmedZombieSlimed);
                    }
                    if (npc.type == NPCID.TwiggyZombie && NPC.downedBoss1 && Main.rand.Next(5) == 0)
                    {
                        npc.Transform(NPCID.ArmedZombieTwiggy);
                    }
                    if (npc.type == NPCID.SwampZombie && NPC.downedBoss1 && Main.rand.Next(5) == 0)
                    {
                        npc.Transform(NPCID.ArmedZombieSwamp);
                    }
                    if (npc.type == NPCID.Skeleton && NPC.downedBoss1 && Main.rand.Next(4) == 0)
                    {
                        npc.Transform(NPCID.BoneThrowingSkeleton);
                    }
                    if (npc.type == NPCID.HeadacheSkeleton && NPC.downedBoss1 && Main.rand.Next(4) == 0)
                    {
                        npc.Transform(NPCID.BoneThrowingSkeleton2);
                    }
                    if (npc.type == NPCID.MisassembledSkeleton && NPC.downedBoss1 && Main.rand.Next(4) == 0)
                    {
                        npc.Transform(NPCID.BoneThrowingSkeleton3);
                    }
                    if (npc.type == NPCID.PantlessSkeleton && NPC.downedBoss1 && Main.rand.Next(4) == 0)
                    {
                        npc.Transform(NPCID.BoneThrowingSkeleton4);
                    }
                    if(npc.type == NPCID.JungleSlime && NPC.downedBoss1 && Main.rand.Next(4) == 0)
                    {
                        npc.Transform(NPCID.SpikedJungleSlime);
                    }
                    if (npc.type == NPCID.IceSlime && NPC.downedBoss1 && Main.rand.Next(4) == 0)
                    {
                        npc.Transform(NPCID.SpikedIceSlime);
                    }
                    if (npc.type == NPCID.Harpy && NPC.downedBoss2 && Main.rand.Next(8) == 0)
                    {
                        npc.Transform(NPCID.Demon);
                    }

                    //zombie horde
                    if (npc.type == NPCID.Zombie && NPC.downedBoss1 && Main.rand.Next(5) == 0)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            Vector2 pos = new Vector2(npc.position.X + Main.rand.Next(-10, 10), npc.position.Y);

                            if (!Collision.SolidCollision(pos, npc.width, npc.height))
                            {
                                int j = NPC.NewNPC((int)pos.X, (int)pos.Y, (int)npc.position.Y, NPCID.Zombie);
                                NPC zombie = Main.npc[j];
                                zombie.GetGlobalNPC<FargoGlobalNPC>().transform = true;
                            }
                        }
                    }

                    if ((npc.type == NPCID.Crawdad || npc.type == NPCID.GiantShelly2) && Main.rand.Next(5) == 0)
                    {
                        //pick a random salamander
                        int sal = Main.rand.Next(498, 507);
                        npc.Transform(sal);
                    }
                    if ((npc.type == NPCID.Salamander || npc.type == NPCID.Salamander2 || npc.type == NPCID.Salamander3 || npc.type == NPCID.Salamander4 || npc.type == NPCID.GiantShelly2) && Main.rand.Next(5) == 0)
                    {
                        //pick a random crawdad
                        int craw = Main.rand.Next(494, 496);
                        npc.Transform(craw);
                    }
                    if ((npc.type == NPCID.Salamander5 || npc.type == NPCID.Salamander6 || npc.type == NPCID.Salamander7 || npc.type == NPCID.Salamander8 || npc.type == NPCID.Crawdad2) && Main.rand.Next(5) == 0)
                    {
                        //pick a random shelly
                        int shell = Main.rand.Next(496, 498);
                        npc.Transform(shell);
                    }

                    transform = true;
                }

                if(npc.type == NPCID.BoneSerpentHead && counter % 300 == 0 && npc.Distance(Main.player[npc.FindClosestPlayer()].Center) < 600) 
                {
                    NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.BurningSphere);
                    counter = 1;
                }

                if(npc.type == NPCID.Tim)
                {
                    foreach(Player p in Main.player)
                    {
                        if(npc.Distance(p.Center) < 800f)
                        {
                            p.AddBuff(BuffID.Silenced, 2);
                        }
                       
                    }
                }

                if (npc.type == NPCID.SkeletronHead)
                {
                    foreach (Player p in Main.player)
                    {
                        if (npc.Distance(p.Center) < 1000f)
                        {
                            p.AddBuff(BuffID.Darkness, 2);
                        }

                    }
                }

                if (npc.type == NPCID.VoodooDemon && npc.lavaWet && !NPC.AnyNPCs(NPCID.WallofFlesh))
                {
                    NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.WallofFlesh);
                    Main.NewText("Wall of Flesh has awoken!", 175, 75, 255);
                    npc.Transform(NPCID.Demon);
                }

                if(npc.type == NPCID.Piranha && NPC.CountNPCS(NPCID.Piranha) <= 10 && counter % 120 == 0 && Main.rand.Next(2) == 0)
                {
                    Player player = Main.player[npc.FindClosestPlayer()];
                    if(player.wet && player.HasBuff(BuffID.Bleeding))
                    {
                        int piranha = NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-20, 20), (int)npc.Center.Y + Main.rand.Next(-20, 20), NPCID.Piranha);
                        Main.npc[piranha].GetGlobalNPC<FargoGlobalNPC>().counter = 1;
                    }
                    counter = 1;
                }

                if(npc.type == NPCID.Shark && counter % 240 == 0 && sharkCount < 5)
                {
                    Player player = Main.player[npc.FindClosestPlayer()];
                    if (player.HasBuff(BuffID.Bleeding) && player.wet && npc.wet)
                    {
                        npc.damage = (int)(npc.damage * 1.5);
                        sharkCount++;
                    }
                    
                    counter = 1;
                }

                if(npc.type == NPCID.Vulture && counter % 300 == 0)
                {
                    Player player = Main.player[npc.FindClosestPlayer()];
                    if(npc.Distance(player.Center) < 500f)
                    {
                        Vector2 velocity = Vector2.Normalize(player.Center - npc.Center) * 10;
                        Projectile proj = Projectile.NewProjectileDirect(npc.Center, velocity, ProjectileID.HarpyFeather, npc.damage / 2, 1f);
                        proj.GetGlobalProjectile<FargoGlobalProjectile>().isRecolor = true;
                    }
                   
                    counter = 1;
                }

                if (npc.type == NPCID.BoneSerpentHead && counter % 300 == 0 && npc.Distance(Main.player[npc.FindClosestPlayer()].Center) < 500f)
                { 
                    NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.BurningSphere);
                    counter = 1;
                }

                if(npc.type == NPCID.DoctorBones && counter % 600 == 0)
                {
                    Player player = Main.player[npc.FindClosestPlayer()];
                    if (npc.Distance(player.Center) < 1000)
                    {
                        Vector2 velocity = Vector2.Normalize(player.Center - npc.Center) * 14;
                        Projectile.NewProjectile(npc.Center, velocity, ProjectileID.Boulder, 200, 1f);
                    }

                    counter = 1;
                }

                if (npc.type == NPCID.Crab && counter % 300 == 0)
                {
                    Player player = Main.player[npc.FindClosestPlayer()];
                    if (npc.Distance(player.Center) < 800)
                    {
                        Vector2 velocity = Vector2.Normalize(player.Center - npc.Center) * 14;
                        
                        Projectile bubble = Projectile.NewProjectileDirect(npc.Center, velocity, ProjectileID.Bubble, npc.damage / 2, 1f);
                        bubble.hostile = true;
                        bubble.friendly = false;
                        
                    }

                    counter = 1;
                }

                if((npc.type == NPCID.Crawdad || npc.type == NPCID.Crawdad2) && counter % 300 == 0)
                {
                    Player player = Main.player[npc.FindClosestPlayer()];
                    if (npc.Distance(player.Center) < 800)
                    {
                        Vector2 velocity = Vector2.Normalize(player.Center - npc.Center) * 10;
                        int bubble = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.DetonatingBubble);
                        Main.npc[bubble].velocity = velocity;
                        Main.npc[bubble].damage = npc.damage / 2;
                    }

                    counter = 1;
                }

                if ((npc.type == NPCID.BloodCrawlerWall || npc.type == NPCID.WallCreeperWall) && counter % 600 == 0)
                {
                    Player player = Main.player[npc.FindClosestPlayer()];
                    if (npc.Distance(player.Center) < 400)
                    {
                        Vector2 velocity = Vector2.Normalize(player.Center - npc.Center) * 14;
                        Projectile.NewProjectile(npc.Center, velocity, ProjectileID.WebSpit, npc.damage / 4, 0f);
                    }

                    counter = 1;
                }

                //phase 2 EoC 
                if (npc.type == NPCID.EyeofCthulhu && npc.life <= npc.lifeMax * 0.65 && counter % 240 == 0 && NPC.CountNPCS(NPCID.ServantofCthulhu) < 12)
                {
                    int[] eyes = new int[4];

                    for (int i = 0; i < 4; i++)
                    {
                        eyes[i] = NPC.NewNPC((int)(npc.position.X + (float)(npc.width / 2)), (int)(npc.position.Y + (float)npc.height), NPCID.ServantofCthulhu);
                    }

                    Main.npc[eyes[0]].velocity = npc.velocity * new Vector2(2, 2);
                    Main.npc[eyes[1]].velocity = npc.velocity * new Vector2(-2, 2);
                    Main.npc[eyes[2]].velocity = npc.velocity * new Vector2(-2, -2);
                    Main.npc[eyes[3]].velocity = npc.velocity * new Vector2(2, -2);

                    counter = 1;
                }

                if (npc.type == NPCID.LunarTowerNebula)
                {
                    foreach (Player p in Main.player)
                    {
                        if (npc.Distance(p.Center) < 5000)
                        {
                            p.AddBuff(mod.BuffType("Atrophied"), 2);
                            p.AddBuff(mod.BuffType("Jammed"), 2);
                            p.AddBuff(mod.BuffType("Antisocial"), 2);
                        }

                    }
                }

                if (npc.type == NPCID.LunarTowerSolar)
                {
                    foreach (Player p in Main.player)
                    {
                        if (npc.Distance(p.Center) < 5000)
                        {
                            p.buffImmune[BuffID.Silenced] = false;
                            p.AddBuff(BuffID.Silenced, 2);
                            p.AddBuff(mod.BuffType("Jammed"), 2);
                            p.AddBuff(mod.BuffType("Antisocial"), 2);
                        }

                    }
                }

                if (npc.type == NPCID.LunarTowerStardust)
                {
                    foreach (Player p in Main.player)
                    {
                        if (npc.Distance(p.Center) < 5000)
                        {
                            p.AddBuff(mod.BuffType("Atrophied"), 2);
                            p.AddBuff(mod.BuffType("Jammed"), 2);
                            p.buffImmune[BuffID.Silenced] = false;
                            p.AddBuff(BuffID.Silenced, 2);
                        }

                    }
                }

                if (npc.type == NPCID.LunarTowerVortex)
                {
                    foreach (Player p in Main.player)
                    {
                        if (npc.Distance(p.Center) < 5000)
                        {
                            p.AddBuff(mod.BuffType("Atrophied"), 2);
                            p.buffImmune[BuffID.Silenced] = false;
                            p.AddBuff(BuffID.Silenced, 2);
                            p.AddBuff(mod.BuffType("Antisocial"), 2);
                        }

                    }
                }

                if (npc.type == NPCID.CochinealBeetle || npc.type == NPCID.CyanBeetle || npc.type == NPCID.LacBeetle)
                {
                    foreach (Player p in Main.player)
                    {
                        if (npc.Distance(p.Center) < 400)
                        {
                            p.AddBuff(mod.BuffType("Lethargic"), 2);
                        }

                    }
                }

                if (npc.type == NPCID.MeteorHead)
                {
                    Player player = Main.player[npc.FindClosestPlayer()];
                    if (counter % 120 == 0 && npc.Distance(player.Center) < 600)
                    {
                        npc.velocity *= 5;
                        counter = 1;
                    }
                    
                    foreach (Player p in Main.player)
                    {
                        if (npc.Distance(p.Center) < 100)
                        {
                            p.AddBuff(BuffID.Burning, 2);
                        }

                    }
                }

                if (npc.type == NPCID.SeekerHead && counter % 10 == 0)
                {
                    Player player = Main.player[npc.FindClosestPlayer()];
                    if (npc.Distance(player.Center) < 500)
                    {
                        Projectile.NewProjectile(npc.Center, npc.velocity, ProjectileID.EyeFire, npc.damage / 3, 0f);
                    }

                    counter = 1;
                }

                if (npc.type == NPCID.Demon && counter % 600 == 0)
                {
                    Player player = Main.player[npc.FindClosestPlayer()];
                    if (npc.Distance(player.Center) < 800)
                    {
                        Projectile.NewProjectile(npc.Center, npc.velocity * new Vector2(0, -2), ProjectileID.DemonSickle, npc.damage / 2, 0f);
                        Projectile.NewProjectile(npc.Center, npc.velocity * new Vector2(0, 2), ProjectileID.DemonSickle, npc.damage / 2, 0f);
                        Projectile.NewProjectile(npc.Center, npc.velocity * new Vector2(2, 0), ProjectileID.DemonSickle, npc.damage / 2, 0f);
                        Projectile.NewProjectile(npc.Center, npc.velocity * new Vector2(-2, 0), ProjectileID.DemonSickle, npc.damage / 2, 0f);
                        Projectile.NewProjectile(npc.Center, npc.velocity * new Vector2(2, 2), ProjectileID.DemonSickle, npc.damage / 2, 0f);
                        Projectile.NewProjectile(npc.Center, npc.velocity * new Vector2(2, -2), ProjectileID.DemonSickle, npc.damage / 2, 0f);
                        Projectile.NewProjectile(npc.Center, npc.velocity * new Vector2(-2, 2), ProjectileID.DemonSickle, npc.damage / 2, 0f);
                        Projectile.NewProjectile(npc.Center, npc.velocity * new Vector2(-2, -2), ProjectileID.DemonSickle, npc.damage / 2, 0f);
                    }

                    counter = 1;
                }



                counter++;
            }
        }

        public override Color? GetAlpha(NPC npc, Color drawColor)
        {
            if(npc.type == NPCID.Shark && sharkCount > 0)
            {
                Color r = new Color(0, 0, 0, 255);
                r.R = (byte)(sharkCount * 20 + 155);
                return r;
            }

            return null;
        }

        public override void OnHitPlayer(NPC npc, Player target, int damage, bool crit)
        {
            if(FargoWorld.masochistMode)
            {
                if (Main.hardMode && !NPC.AnyNPCs(NPCID.KingSlime) && Main.rand.Next(2) == 0)
                {
                    if (npc.type == NPCID.SlimeSpiked)
                    {
                        npc.Transform(NPCID.KingSlime);
                        npc.velocity.Y = -20f;
                        Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 0);
                    }
                }

                if (npc.netID == NPCID.Pinky && !target.noKnockback)
                {
                    Vector2 velocity = Vector2.Normalize(target.Center - npc.Center) * 30;
                    target.velocity = velocity;
                }

                if(npc.type == NPCID.SandSlime && Main.rand.Next(2) == 0)
                {
                    _startSandstormMethod = typeof(Sandstorm).GetMethod("StartSandstorm", BindingFlags.NonPublic | BindingFlags.Static);
                    _startSandstormMethod.Invoke(null, null);
                    Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 0);
                }
            }
            

            
        }

        public void ResetRegenTimer(NPC npc)
        {
            if (npc.boss)
            {
                //5 sec
                npc.GetGlobalNPC<FargoGlobalNPC>().regenTimer = 300;
            }
            else
            {
                //10 sec
                npc.GetGlobalNPC<FargoGlobalNPC>().regenTimer = 600;
            }
        }
		
		public override void UpdateLifeRegen(NPC npc, ref int damage)
		{
			Player player = Main.player[Main.myPlayer];
			FargoPlayer modPlayer = player.GetModPlayer<FargoPlayer>(mod);
			int dmg;

            if (FargoWorld.masochistMode && !npc.dontTakeDamage && regenTimer <= 0)
            {
                npc.lifeRegen += 1 + npc.lifeMax / 25;
            }

            if (sBleed)
			{
				if (npc.lifeRegen > 0)
				{
					npc.lifeRegen = 0;
				}
				npc.lifeRegen -= 40;
				if (damage < 10)
				{
					damage = 10;
				}
				
				if(Main.rand.Next(4) == 0)
				{
					if(npc.lifeMax < 2000)
					{
						dmg = 20;
					}
					else
					{
						dmg = npc.lifeMax / 100;
					}
					
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y - 40, 0f + Main.rand.Next(-5, 5), -5f, mod.ProjectileType("SuperBlood"), dmg, 0f, Main.myPlayer, 0f, 0f);
				}
				
			}
			
			if(shock && Main.rand.Next(2) == 0)
			{
				if(npc.FindBuffIndex(BuffID.Wet) != -1)  
				{
					dmg = 20;
				}
				else
				{
					dmg = 10;
				}
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0f, 0f, mod.ProjectileType("Shock"), dmg, 0f, Main.myPlayer, 0f, 0f);
			}

            if (rotting)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }

                npc.lifeRegen -= 100;

                if (damage < 5)
                { 
                    damage = 5;
                }
            }
		}
		
		public override void EditSpawnRate (Player player, ref int spawnRate, ref int maxSpawns)
		{
			FargoPlayer modPlayer = player.GetModPlayer<FargoPlayer>(mod);
			
            if(FargoWorld.masochistMode)
            {
                if(!Main.hardMode)
                {
                    //1.3x spawn rate
                    spawnRate = (int)((double)spawnRate * 0.75);
                    //2x max spawn
                    maxSpawns = (int)((float)maxSpawns * 2f);
                }
                else
                {
                    //2x spawn rate
                    spawnRate = (int)((double)spawnRate * 0.5);
                    //3x max spawn
                    maxSpawns = (int)((float)maxSpawns * 3f);
                }
                
            }

            if (modPlayer.bloodthirst)
            {
                //20x spawn rate
                spawnRate = (int)((double)spawnRate * 0.05);
                //20x max spawn
                maxSpawns = (int)((float)maxSpawns * 20f);
            }

            if (modPlayer.npcBoost)
            {
                spawnRate = (int)((double)spawnRate * 0.1);
                maxSpawns = (int)((float)maxSpawns * 10f);
            }

            if (modPlayer.builderMode)
			{
				maxSpawns = (int)((float)maxSpawns * 0f);
			}
			
			

            
			
		}
		
		public override void EditSpawnPool(IDictionary<int, float> pool, NPCSpawnInfo spawnInfo)
		{
            //layers
			int y = spawnInfo.spawnTileY;
			bool Cavern = (y >= (Main.maxTilesY * 0.4f) && y <= (Main.maxTilesY * 0.8f));
            bool Underground = y > Main.worldSurface && y <= (Main.maxTilesY * 0.4f);
            bool Underground2 = spawnInfo.player.ZoneDirtLayerHeight;
            bool Surface = y < Main.worldSurface;
            bool Underworld = spawnInfo.player.ZoneUnderworldHeight;
            bool Sky = spawnInfo.sky;

            //times
            bool Night = !Main.dayTime;
            bool Day = Main.dayTime;

            //biomes
            bool NoBiome = Fargowiltas.NoBiomeNormalSpawn(spawnInfo);
            bool Ocean = spawnInfo.player.ZoneBeach;
            bool Dungeon = spawnInfo.player.ZoneDungeon;
            bool Meteor = spawnInfo.player.ZoneMeteor;
            bool SpiderCave = spawnInfo.spiderCave;
            bool Mushroom = spawnInfo.player.ZoneGlowshroom;
            bool Jungle = spawnInfo.player.ZoneJungle;
            bool Granite = spawnInfo.granite;
            bool Marble = spawnInfo.marble;
            bool Corruption = spawnInfo.player.ZoneCorrupt;
            bool Crimson = spawnInfo.player.ZoneCrimson;
            bool Snow = spawnInfo.player.ZoneSnow;

            bool NebulaTower = spawnInfo.player.ZoneTowerNebula;
            bool VortexTower = spawnInfo.player.ZoneTowerVortex;
            bool StardustTower = spawnInfo.player.ZoneTowerStardust;
            bool SolarTower = spawnInfo.player.ZoneTowerSolar;

            bool Water = spawnInfo.water;

            //events
            bool GoblinArmy = Main.invasionType == 1;
            bool FrostLegion = Main.invasionType == 2;
            bool Pirates = Main.invasionType == 3;
            bool MartianMadness = Main.invasionType == 4;
            bool OldOnesArmy = DD2Event.Ongoing && spawnInfo.player.ZoneOldOneArmy;
            bool FrostMoon = Surface && Night && Main.snowMoon;
            bool PumpkinMoon = Surface && Night && Main.pumpkinMoon;
            bool SolarEclipse = Surface && Day && Main.eclipse;
            

            //no work?
            //is lava on screen
            bool nearLava = Collision.LavaCollision(spawnInfo.player.position, spawnInfo.spawnTileX, spawnInfo.spawnTileY);


            //ZoneCorrupt
            //ZoneHoly
            //ZoneMeteor
            //ZoneJungle
            //ZoneSnow
            //ZoneCrimson

            //ZoneDesert
            //ZoneGlowshroom
            //ZoneUndergroundDesert
            //ZoneSkyHeight
            //ZoneOverworldHeight
            //ZoneDirtLayerHeight
            //ZoneRockLayerHeight
            //ZoneUnderworldHeight
            //ZoneBeach
            //ZoneRain
            //ZoneSandstorm
            //Main.raining
            //NPC.AnyNPCs(NPCID.IceGolem)
            //TileID.Sets.Conversion.Sand[spawnInfo.spawnTileType]
            //spawnInfo.granite
            //spawnInfo.lihzahrd
            //spawnInfo.marble
            //spawnInfo.sky
            //spawnInfo.spiderCave
            //spawnInfo.player.adjLava


            //season enemies
            if (soulcheck.seasonalSpawns)
			{
				/*if(Main.hardMode)
				{
					if(NoBiome && Surface && Night)
					{
						pool[NPCID.HoppinJack] = .04f;
					}
				
					if(NoBiome && Cavern)
					{
						pool[NPCID.Ghost] = .04f;
					}
					
					if(NoBiome && Surface && Night)
					{
						pool[NPCID.Raven] = .015f;
					}
				}
				
				else
				{
					if(NoBiome && Surface && Night)
					{
						pool[NPCID.Raven] = .04f;
					}
				}
				
				if(NoBiome && Surface && Day)
				{
						pool[NPCID.SlimeRibbonWhite] = .01f;
						pool[NPCID.SlimeRibbonYellow] = .01f;
						pool[NPCID.SlimeRibbonGreen] = .01f;
						pool[NPCID.SlimeRibbonRed] = .01f;
				}*/
			}
			
			
			
			//MASOCHIST MODE
			if(FargoWorld.masochistMode)
			{
				//all the pre hardmode
				if(!Main.hardMode)
				{
                    //bosses
					if(Surface && Day && NPC.downedSlimeKing && NPC.downedBoss2 && Main.slimeRain)
					{
                        if(!NPC.AnyNPCs(NPCID.KingSlime))
                        {
                            pool[NPCID.KingSlime] = .04f;
                        }
                        else
                        {
                            pool[NPCID.KingSlime] = .01f;
                        }
					}
					
					if(Fargowiltas.NormalSpawn(spawnInfo) && Surface && Night && NPC.downedBoss1 && NPC.downedBoss3)
					{
                        if (!NPC.AnyNPCs(NPCID.EyeofCthulhu))
                        {
                            pool[NPCID.EyeofCthulhu] = .004f;
                        }
                        else
                        {
                            pool[NPCID.EyeofCthulhu] = .001f;
                        }
                    }
					
					if(Surface && Night && NPC.downedBoss1 && NPC.downedBoss3 && Main.bloodMoon)
					{
                        if (!NPC.AnyNPCs(NPCID.EyeofCthulhu))
                        {
                            pool[NPCID.EyeofCthulhu] = .01f;
                        }
                        else
                        {
                            pool[NPCID.EyeofCthulhu] = .0025f;
                        }
                    }
					
					if(Fargowiltas.NormalSpawn(spawnInfo) && NPC.downedBoss2 && NPC.downedBoss3 && NPC.downedQueenBee && Corruption && !Underworld)
					{
                        if (!NPC.AnyNPCs(NPCID.EaterofWorldsHead))
                        {
                            pool[NPCID.EaterofWorldsHead] = .005f;
                        }
                        else
                        {
                            pool[NPCID.EaterofWorldsHead] = .00125f;
                        }
                    }
					
					if(Fargowiltas.NormalSpawn(spawnInfo) && NPC.downedBoss2 && NPC.downedBoss3 && NPC.downedQueenBee && Crimson && !Underworld)
					{
                        if (!NPC.AnyNPCs(NPCID.BrainofCthulhu))
                        {
                            pool[NPCID.BrainofCthulhu] = .005f;
                        }
                        else
                        {
                            pool[NPCID.BrainofCthulhu] = .00125f;
                        }
                    }

                    //random
                    if(NoBiome && Cavern && NPC.downedBoss3)
                    {
                        pool[NPCID.DarkCaster] = .1f;
                    }

                    //maybe working?
                    if(nearLava && !Surface)
                    {
                        pool[NPCID.FireImp] = .1f;
                        pool[NPCID.LavaSlime] = .1f;
                    }

                    if(Night && Surface && NoBiome)
                    {
                        pool[NPCID.CorruptBunny] = .1f;
                        pool[NPCID.CrimsonBunny] = .1f;
                    }

                    if(Night && Ocean)
                    {
                        pool[NPCID.CorruptGoldfish] = .1f;
                        pool[NPCID.CrimsonGoldfish] = .1f;
                    }

                    if(Night && Snow && Surface)
                    {
                        pool[NPCID.CorruptPenguin] = .1f;
                        pool[NPCID.CrimsonPenguin] = .1f;
                    }

                    if(Marble && NPC.downedBoss2)
                    {
                        pool[NPCID.Medusa] = .1f;
                    }

                    if(Fargowiltas.NormalSpawn(spawnInfo) && Night && Jungle && NPC.downedBoss1)
                    {
                        pool[NPCID.DoctorBones] = .05f;
                    }

                    if(Granite)
                    {
                        pool[NPCID.GraniteFlyer] = .1f;
                        pool[NPCID.GraniteGolem] = .1f;
                    }

                    if(Mushroom)
                    {
                        pool[NPCID.FungiBulb] = .1f;
                        pool[NPCID.MushiLadybug] = .1f;
                        pool[NPCID.ZombieMushroom] = .1f;
                        pool[NPCID.ZombieMushroomHat] = .1f;
                        pool[NPCID.AnomuraFungus] = .1f;
                    }

                    if(Underworld)
                    {
                        pool[NPCID.LeechHead] = .05f;
                    }

                    if(Corruption && NPC.downedBoss2)
                    {
                        pool[NPCID.SeekerHead] = .01f;
                    }

                    if (Crimson && NPC.downedBoss2)
                    {
                        pool[NPCID.IchorSticker] = .01f;
                    }

                    if(Fargowiltas.NormalSpawn(spawnInfo) && NPC.downedMechBoss2 && !Surface)
                    {
                        pool[NPCID.Mimic] = .01f;
                    }

                }
				
				//all the hardmode
				if(Main.hardMode == true)
				{
                    //bosses
					if(Fargowiltas.NormalSpawn(spawnInfo) && Surface && Day && Main.slimeRain)
					{
                        if (!NPC.AnyNPCs(NPCID.KingSlime))
                        {
                            pool[NPCID.KingSlime] = .1f;
                        }
                        else
                        {
                            pool[NPCID.KingSlime] = .025f;
                        }
                    }
				
					if(Surface && Day && NoBiome)
					{
                        if (!NPC.AnyNPCs(NPCID.KingSlime))
                        {
                            pool[NPCID.KingSlime] = .04f;
                        }
                        else
                        {
                            pool[NPCID.KingSlime] = .01f;
                        }
                    }
					
					if(Surface && Night && Fargowiltas.NormalSpawn(spawnInfo))
					{
                        if (!NPC.AnyNPCs(NPCID.EyeofCthulhu))
                        {
                            pool[NPCID.EyeofCthulhu] = .02f;
                        }
                        else
                        {
                            pool[NPCID.EyeofCthulhu] = .005f;
                        }
                    }
					
					if(Surface && Night && Main.bloodMoon)
					{
                        if (!NPC.AnyNPCs(NPCID.EyeofCthulhu))
                        {
                            pool[NPCID.EyeofCthulhu] = .05f;
                        }
                        else
                        {
                            pool[NPCID.EyeofCthulhu] = .0125f;
                        }
                    }
					
					if(Fargowiltas.NormalSpawn(spawnInfo) && Corruption && !Underworld)
					{
                        if (!NPC.AnyNPCs(NPCID.EaterofWorldsHead))
                        {
                            pool[NPCID.EaterofWorldsHead] = .01f;
                        }
                        else
                        {
                            pool[NPCID.EaterofWorldsHead] = .0025f;
                        }
                    }
					
					if(Fargowiltas.NormalSpawn(spawnInfo) && Crimson && !Underworld)
					{
                        if (!NPC.AnyNPCs(NPCID.BrainofCthulhu))
                        {
                            pool[NPCID.BrainofCthulhu] = .01f;
                        }
                        else
                        {
                            pool[NPCID.BrainofCthulhu] = .0025f;
                        }
                    }			
					
					if(Fargowiltas.NormalSpawn(spawnInfo) && Night && spawnInfo.player.ZoneDungeon && NPC.downedMechBossAny)
					{
                        if (!NPC.AnyNPCs(NPCID.SkeletronHead))
                        {
                            pool[NPCID.SkeletronHead] = .005f;
                        }
                        else
                        {
                            pool[NPCID.SkeletronHead] = .00125f;
                        }
                    }
					
					if(Fargowiltas.NormalSpawn(spawnInfo) && Day && spawnInfo.player.ZoneJungle && NPC.downedMechBossAny)
					{
                        if (!NPC.AnyNPCs(NPCID.QueenBee))
                        {
                            pool[NPCID.QueenBee] = .005f;
                        }
                        else
                        {
                            pool[NPCID.QueenBee] = .00125f;
                        }
                    }
				
					//all the hard mode bosses
					if(Fargowiltas.NormalSpawn(spawnInfo) && Surface && Night && NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3 && Main.bloodMoon)
					{
                        if (!NPC.AnyNPCs(NPCID.Retinazer) || !NPC.AnyNPCs(NPCID.Spazmatism) || !NPC.AnyNPCs(NPCID.SkeletronPrime) || !NPC.AnyNPCs(NPCID.TheDestroyer))
                        {
                            pool[NPCID.Retinazer] = .005f;
                            pool[NPCID.Spazmatism] = .005f;
                            pool[NPCID.TheDestroyer] = .005f;
                            pool[NPCID.SkeletronPrime] = .005f;
                        }
                        else
                        {
                            pool[NPCID.Retinazer] = .0025f;
                            pool[NPCID.Spazmatism] = .0025f;
                            pool[NPCID.TheDestroyer] = .0025f;
                            pool[NPCID.SkeletronPrime] = .0025f;
                        }
                    }
					
					if(Surface && Night && NPC.downedPlantBoss && Main.bloodMoon)
					{
                        if (!NPC.AnyNPCs(NPCID.Retinazer) || !NPC.AnyNPCs(NPCID.Spazmatism) || !NPC.AnyNPCs(NPCID.SkeletronPrime) || !NPC.AnyNPCs(NPCID.TheDestroyer))
                        {
                            pool[NPCID.Retinazer] = .05f;
                            pool[NPCID.Spazmatism] = .05f;
                            pool[NPCID.TheDestroyer] = .05f;
                            pool[NPCID.SkeletronPrime] = .05f;
                        }
                        else
                        {
                            pool[NPCID.Retinazer] = .025f;
                            pool[NPCID.Spazmatism] = .025f;
                            pool[NPCID.TheDestroyer] = .025f;
                            pool[NPCID.SkeletronPrime] = .025f;
                        }
                    }

                    //random
                    if(Surface && Day && NPC.downedMechBossAny)
                    {
                        pool[NPCID.CultistArcherWhite] = .05f;
                    }

                }
			}
		
			
		
		}
		
		public override bool PreNPCLoot (NPC npc)
		{
            if((npc.type == NPCID.Medusa || npc.type == NPCID.IchorSticker || npc.type == NPCID.SeekerHead || npc.type == NPCID.Mimic) && !Main.hardMode)
            {
                return false;
            }

			//make a damn method for swarms
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
			
			//spider enchant
			if(modPlayer.spiderEnchant && Main.rand.Next(5) == 0)
			{
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0f + Main.rand.Next(-5, 5), -5f, ProjectileID.SpiderEgg, 26, 0f, Main.myPlayer, 0f, 0f);
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0f + Main.rand.Next(-5, 5), -5f, ProjectileID.SpiderEgg, 26, 0f, Main.myPlayer, 0f, 0f);
			}
			
			//SoT
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
			/*if((npc.type == NPCID.Ghost) || (npc.type == NPCID.HoppinJack) || (npc.type == NPCID.Raven))
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoodieBag, 1);
			}
			
			if((npc.type == NPCID.SlimeRibbonGreen) || (npc.type == NPCID.SlimeRibbonRed) || (npc.type == NPCID.SlimeRibbonWhite) || (npc.type == NPCID.SlimeRibbonYellow))
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Present, 1);
			}*/
			
			//bonus drops
			if(((npc.type == NPCID.BloodZombie) || (npc.type == NPCID.Drippler)) && Main.rand.Next(75) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BloodyMachete, 1);
			}
			
			if(((npc.type == NPCID.BloodZombie) || (npc.type == NPCID.Drippler)) && Main.rand.Next(75) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BladedGlove, 1);
			}
			
			if((npc.type == NPCID.GreekSkeleton) && Main.rand.Next(15) == 0)
			{
				int i = Main.rand.Next(3);
				
				switch(i)
				{
					case 0:
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GladiatorHelmet, 1);
						break;
					case 1:
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GladiatorBreastplate, 1);
						break;
					default:
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GladiatorLeggings, 1);
						break;
				}
			}

			
			//TOWN NPCS
			if(npc.type == NPCID.Guide)
            {
				//drops green cap
				
				FargoWorld.guide = true;
			}
			if(npc.type == NPCID.Merchant)
            {
				if(Main.rand.Next(8) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MiningShirt);
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MiningPants);
				}
				
				FargoWorld.merch = true;
			}
			if(npc.type == NPCID.Nurse)
            {
				if(Main.rand.Next(10) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.NurseHat);
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.NurseShirt);
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.NursePants);
				}
				
				if(Main.rand.Next(5) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.LifeCrystal);
				}
				
				FargoWorld.nurse = true;
			}
			if(npc.type == NPCID.Demolitionist)
            {
				if(Main.rand.Next(5) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Dynamite, 5);
				}
				
				FargoWorld.demo = true;
			}
			if(npc.type == NPCID.DyeTrader)
            {
				//drops scimitar
				
				if(Main.rand.Next(10) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.DyeTraderRobe);
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.DyeTraderTurban);
				}
				
				FargoWorld.dye = true;
			}
			if(npc.type == NPCID.Dryad)
            {
				if(Main.rand.Next(10) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.DryadCoverings);
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.DryadLoincloth);
				}
				
				if(Main.rand.Next(8) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.FlowerBoots);
				}
				
				FargoWorld.dryad = true;
			}
			if(npc.type == NPCID.DD2Bartender)
            {
				//drops ale tosser
				
				FargoWorld.keep = true;
			}
			if(npc.type == NPCID.ArmsDealer)
            {
				if(Main.rand.Next(8) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.RedRyder);
				}
				
				FargoWorld.dealer = true;
			}
			if(npc.type == NPCID.Stylist)
            {				
				//drops scissors
				
				FargoWorld.style = true;
			}
			if(npc.type == NPCID.Painter)
            {
				//drops paintball gun
				
				FargoWorld.paint = true;
			}
			if(npc.type == NPCID.Angler)
            {
				if(Main.rand.Next(2) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MasterBait, 5);
				}
				
				FargoWorld.angler = true;
			}
			if(npc.type == NPCID.GoblinTinkerer)
            {
				//drop a thing
				
				FargoWorld.goblin = true;
			}
			if(npc.type == NPCID.WitchDoctor)
            {				
				if(Main.rand.Next(8) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Cauldron);
				}
				
				FargoWorld.doc = true;
			}
			if(npc.type == NPCID.Clothier)
            {
				if(Main.rand.Next(10) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.ClothierJacket);
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.ClothierPants);
				}
				
				if(Main.rand.Next(20) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Skull);
				}
				
				FargoWorld.cloth = true;
			}
			if(npc.type == NPCID.Mechanic)
            {				
				//drop a thing
				
				FargoWorld.mech = true;
			}
			if(npc.type == NPCID.PartyGirl)
            {
				//drops happy grenades
				
				FargoWorld.party = true;
			}
			if(npc.type == NPCID.Wizard)
            {
				if(Main.rand.Next(10) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.WizardsHat);
				}
				
				//drop a thing
				
				FargoWorld.wiz = true;
			}
			if(npc.type == NPCID.TaxCollector)
            {
				if(Main.rand.Next(10) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.TaxCollectorHat);
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.TaxCollectorSuit);
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.TaxCollectorPants);
				}
				
				//drops classy cane
				
				FargoWorld.tax = true;
			}
			if(npc.type == NPCID.Truffle)
            {
				if(Main.rand.Next(8) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MushroomStatue);
				}
				FargoWorld.truf = true;
			}
			if(npc.type == NPCID.Pirate)
            {
				if(Main.rand.Next(8) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BunnyHood);
				}
				
				FargoWorld.pirate = true;
			}
			if(npc.type == NPCID.Steampunker)
            {
				if(Main.rand.Next(10) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SteampunkGoggles);
				}
				
				FargoWorld.steam = true;
			}
			if(npc.type == NPCID.Cyborg)
            {
				if(Main.rand.Next(10) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.CyborgHelmet);
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.CyborgShirt);
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.CyborgPants);
				}
				
				FargoWorld.borg = true;
			}
			//santa?
			//trav merch pulse bow in hardmode, revolver in pre
			//skel merch?
			
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
			
			if(npc.boss)
            {
				 FargoWorld.downedBoss = true;
            }

            if(FargoWorld.masochistMode)
            {
                if(npc.type == NPCID.Drippler)
                {
                    int[] eyes = new int[4];

                    for(int i = 0; i < 4; i++)
                    {
                        eyes[i] = NPC.NewNPC((int)(npc.position.X + (float)(npc.width / 2)), (int)(npc.position.Y + (float)npc.height), NPCID.DemonEye);
                    }

                    Main.npc[eyes[0]].velocity = new Vector2(2, 2);
                    Main.npc[eyes[1]].velocity = new Vector2(-2, 2);
                    Main.npc[eyes[2]].velocity = new Vector2(-2, -2);
                    Main.npc[eyes[3]].velocity = new Vector2(2, -2);
                }

                if(npc.type == NPCID.GoblinPeon || npc.type == NPCID.GoblinWarrior)
                {
                    //Projectile.NewProjectile(npc.Center, new Vector2(0, -10), ProjectileID.SpikyBallTrap, 15, 0);
                    Projectile ball = Projectile.NewProjectileDirect(npc.Center, new Vector2(0, -5), ProjectileID.SpikyBall, 15, 0);
                    ball.hostile = true;
                    ball.friendly = true;
                    ball.GetGlobalProjectile<FargoGlobalProjectile>().isRecolor = true;
                }

                if((npc.type == NPCID.AngryBones || npc.type == NPCID.AngryBonesBig || npc.type == NPCID.AngryBonesBigHelmet || npc.type == NPCID.AngryBonesBigMuscle) && Main.rand.Next(10) == 0)
                {
                    NPC.NewNPC((int)(npc.position.X + (float)(npc.width / 2)), (int)(npc.position.Y + (float)npc.height), NPCID.CursedSkull);
                }
                //yellow slime
                if (npc.netID == -9)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        int spawn = NPC.NewNPC((int)(npc.position.X + (float)(npc.width / 2)), (int)(npc.position.Y + (float)npc.height), 1, 0, 0f, 0f, 0f, 0f, 255);
                        Main.npc[spawn].SetDefaults(NPCID.PurpleSlime);
                        Main.npc[spawn].velocity.X = npc.velocity.X * 2f;
                        Main.npc[spawn].velocity.Y = npc.velocity.Y;

                        NPC spawn2 = Main.npc[spawn];
                        spawn2.velocity.X = spawn2.velocity.X + ((float)Main.rand.Next(-20, 20) * 0.1f + (float)(i * npc.direction) * 0.3f);
                        NPC spawn3 = Main.npc[spawn];
                        spawn3.velocity.Y = spawn3.velocity.Y - ((float)Main.rand.Next(0, 10) * 0.1f + (float)i);
                        Main.npc[spawn].ai[0] = (float)(-1000 * Main.rand.Next(3));
                    }
                }
                //purple slime
                if (npc.netID == -7)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        int spawn = NPC.NewNPC((int)(npc.position.X + (float)(npc.width / 2)), (int)(npc.position.Y + (float)npc.height), 1, 0, 0f, 0f, 0f, 0f, 255);
                        Main.npc[spawn].SetDefaults(NPCID.RedSlime);
                        Main.npc[spawn].velocity.X = npc.velocity.X * 2f;
                        Main.npc[spawn].velocity.Y = npc.velocity.Y;

                        NPC spawn2 = Main.npc[spawn];
                        spawn2.velocity.X = spawn2.velocity.X + ((float)Main.rand.Next(-20, 20) * 0.1f + (float)(i * npc.direction) * 0.3f);
                        NPC spawn3 = Main.npc[spawn];
                        spawn3.velocity.Y = spawn3.velocity.Y - ((float)Main.rand.Next(0, 10) * 0.1f + (float)i);
                        Main.npc[spawn].ai[0] = (float)(-1000 * Main.rand.Next(3));
                    }
                }
                //red slime
                if (npc.netID == -8)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        int spawn = NPC.NewNPC((int)(npc.position.X + (float)(npc.width / 2)), (int)(npc.position.Y + (float)npc.height), 1, 0, 0f, 0f, 0f, 0f, 255);
                        Main.npc[spawn].SetDefaults(NPCID.GreenSlime);
                        Main.npc[spawn].velocity.X = npc.velocity.X * 2f;
                        Main.npc[spawn].velocity.Y = npc.velocity.Y;

                        NPC spawn2 = Main.npc[spawn];
                        spawn2.velocity.X = spawn2.velocity.X + ((float)Main.rand.Next(-20, 20) * 0.1f + (float)(i * npc.direction) * 0.3f);
                        NPC spawn3 = Main.npc[spawn];
                        spawn3.velocity.Y = spawn3.velocity.Y - ((float)Main.rand.Next(0, 10) * 0.1f + (float)i);
                        Main.npc[spawn].ai[0] = (float)(-1000 * Main.rand.Next(3));
                    }
                }

                if(npc.type == NPCID.EyeofCthulhu && FargoWorld.eyeCount < 280)
                {
                    FargoWorld.eyeCount++;
                }
                if (npc.type == NPCID.KingSlime && FargoWorld.slimeCount < 280)
                {
                    FargoWorld.slimeCount++;
                }
                if (npc.type == NPCID.EaterofWorldsHead && !NPC.AnyNPCs(NPCID.EaterofWorldsBody) && !NPC.AnyNPCs(NPCID.EaterofWorldsTail) && FargoWorld.eaterCount < 280)
                {
                    FargoWorld.eaterCount++;
                }
                if (npc.type == NPCID.BrainofCthulhu && FargoWorld.brainCount < 280)
                {
                    FargoWorld.brainCount++;
                }
                if (npc.type == NPCID.QueenBee && FargoWorld.beeCount < 280)
                {
                    FargoWorld.beeCount++;
                }
                if (npc.type == NPCID.SkeletronHead && FargoWorld.skeletronCount < 280)
                {
                    FargoWorld.skeletronCount++;
                }
                if (npc.type == NPCID.WallofFlesh && FargoWorld.wallCount < 280)
                {
                    FargoWorld.wallCount++;
                }
                if (npc.type == NPCID.TheDestroyer && FargoWorld.destroyerCount < 120)
                {
                    FargoWorld.destroyerCount++;
                }
                if (npc.type == NPCID.SkeletronPrime && FargoWorld.primeCount < 120)
                {
                    FargoWorld.primeCount++;
                }
                if (npc.type == NPCID.Retinazer && FargoWorld.twinsCount < 120)
                {
                    FargoWorld.twinsCount++;
                }
                if (npc.type == NPCID.Plantera && FargoWorld.planteraCount < 120)
                {
                    FargoWorld.planteraCount++;
                }
                if (npc.type == NPCID.Golem && FargoWorld.golemCount < 120)
                {
                    FargoWorld.golemCount++;
                }
                if (npc.type == NPCID.DukeFishron && FargoWorld.fishronCount < 120)
                {
                    FargoWorld.fishronCount++;
                }
                if (npc.type == NPCID.CultistBoss && FargoWorld.cultistCount < 120)
                {
                    FargoWorld.cultistCount++;
                }
                if (npc.type == NPCID.MoonLordCore && FargoWorld.moonlordCount < 120)
                {
                    FargoWorld.moonlordCount++;
                }
            }
            


            return true;
		}  

        public override void HitEffect(NPC npc, int hitDirection, double damage)
        {
               
        }


        public override void ModifyHitNPC (NPC npc, NPC target, ref int damage, ref float knockback, ref bool crit)
		{
			
			
			
		}

        public override void ModifyHitByItem(NPC npc, Player player, Item item, ref int damage, ref float knockback, ref bool crit)
        {
            if (FargoWorld.masochistMode)
            {
                if(npc.type == NPCID.Salamander || npc.type == NPCID.Salamander2 || npc.type == NPCID.Salamander3 || npc.type == NPCID.Salamander4 || npc.type == NPCID.Salamander5 || npc.type == NPCID.Salamander6 || npc.type == NPCID.Salamander7 || npc.type == NPCID.Salamander8 || npc.type == NPCID.Salamander9)
                {
                    npc.Opacity *= 25;
                }

                if(npc.type == NPCID.GiantShelly || npc.type == NPCID.GiantShelly2)
                {
                    player.Hurt(PlayerDeathReason.ByCustomReason(player.name + " was impaled by a Giant Shelly."), damage / 4, 0);
                }
            }
        }

        public override void ModifyHitByProjectile (NPC npc, Projectile projectile, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
            if (FargoWorld.masochistMode)
            {
                if (npc.type == NPCID.Salamander || npc.type == NPCID.Salamander2 || npc.type == NPCID.Salamander3 || npc.type == NPCID.Salamander4 || npc.type == NPCID.Salamander5 || npc.type == NPCID.Salamander6 || npc.type == NPCID.Salamander7 || npc.type == NPCID.Salamander8 || npc.type == NPCID.Salamander9)
                {
                    npc.Opacity *= 25;
                }
            }

            if (projectile.type == mod.ProjectileType("FishNuke"))
			{
				damage = npc.lifeMax / 10;
				if(damage < 50)
				{
					damage = 50;
				}
			}
			
			if(projectile.type == ProjectileID.RottenEgg && npc.townNPC)
			{
				damage *= 20;
			}
			
			
		}

        public override void ModifyHitPlayer(NPC npc, Player target, ref int damage, ref bool crit)
        {
            if(FargoWorld.masochistMode)
            {
                //SLIMES
                if (npc.netID == NPCID.GreenSlime || npc.netID == NPCID.BlueSlime || npc.type == NPCID.BunnySlimed || npc.type == NPCID.SlimeRibbonGreen || (npc.type == NPCID.SlimeRibbonRed) || (npc.type == NPCID.SlimeRibbonWhite) || (npc.type == NPCID.SlimeRibbonYellow))
                {
                    target.AddBuff(BuffID.Slimed, 300);
                }
                if (npc.netID == NPCID.RedSlime || npc.netID == NPCID.PurpleSlime || npc.netID == NPCID.YellowSlime)
                {
                    target.AddBuff(BuffID.Slimed, 600);
                }
                if (npc.netID == NPCID.BlackSlime)
                {
                    target.AddBuff(BuffID.Slimed, 600);
                    target.AddBuff(BuffID.Darkness, 1200);
                }
                if (npc.type == NPCID.IceSlime)
                {
                    target.AddBuff(BuffID.Slimed, 360);
                }
                if (npc.type == NPCID.SandSlime)
                {
                    target.AddBuff(BuffID.Slimed, 360);
                }
                if (npc.netID == NPCID.JungleSlime)
                {
                    target.AddBuff(BuffID.Slimed, 480);
                }
                if (npc.type == NPCID.SpikedIceSlime)
                {
                    target.AddBuff(BuffID.Slimed, 600);
                    target.AddBuff(BuffID.Frostburn, 600);
                }
                if (npc.type == NPCID.SpikedJungleSlime)
                {
                    target.AddBuff(BuffID.Slimed, 600);
                    target.AddBuff(BuffID.Venom, 600);
                }
                if (npc.type == NPCID.MotherSlime)
                {
                    target.AddBuff(BuffID.Slimed, 600);
                    target.AddBuff(mod.BuffType("Antisocial"), 1800);
                }
                if (npc.netID == NPCID.BabySlime)
                {
                    target.AddBuff(BuffID.Slimed, 240);
                }
                if (npc.type == NPCID.LavaSlime)
                {
                    target.AddBuff(BuffID.Slimed, 900);
                    target.AddBuff(BuffID.OnFire, 900);
                }
                if (npc.type == NPCID.DungeonSlime)
                {
                    target.AddBuff(BuffID.Slimed, 900);
                    target.AddBuff(BuffID.Blackout, 1200);
                }
                if (npc.netID == NPCID.Pinky)
                {
                    target.AddBuff(BuffID.Slimed, 900);
                    target.AddBuff(BuffID.Ichor, 1200);
                }
                if (npc.type == NPCID.KingSlime)
                {
                    target.AddBuff(BuffID.Slimed, 1200);
                    target.AddBuff(mod.BuffType("Lethargic"), 1200);
                    target.AddBuff(mod.BuffType("ClippedWings"), 1200);

                    if(Main.rand.Next(20) == 0)
                    {
                        target.AddBuff(mod.BuffType("Stunned"), 60);
                    }
                }
                if (npc.type == NPCID.SlimeSpiked)
                {
                    target.AddBuff(BuffID.Slimed, 300);
                }
                if (npc.type == NPCID.UmbrellaSlime)
                {
                    target.AddBuff(BuffID.Slimed, 600);
                }
                if (npc.type == NPCID.SlimedZombie || npc.type == NPCID.ArmedZombieSlimed)
                {
                    target.AddBuff(BuffID.Slimed, 360);
                }
                
                if (npc.type == NPCID.ToxicSludge)
                {
                    target.AddBuff(BuffID.Slimed, 1200);
                    target.AddBuff(mod.BuffType("Infested"), 600);
                }
                if (npc.type == NPCID.CorruptSlime)
                {
                    target.AddBuff(BuffID.Slimed, 1200);
                    target.AddBuff(mod.BuffType("Rotting"), 1200);
                }
                if (npc.netID == NPCID.Slimeling)
                {
                    target.AddBuff(BuffID.Slimed, 300);
                }
                if (npc.type == NPCID.Slimer)
                {
                    target.AddBuff(BuffID.Slimed, 1200);
                    target.AddBuff(mod.BuffType("ClippedWings"), 900);
                }
                if (npc.type == NPCID.Crimslime)
                {
                    target.AddBuff(BuffID.Slimed, 1200);
                    target.AddBuff(mod.BuffType("Bloodthirsty"), 600);
                }
                if (npc.type == NPCID.Gastropod)
                {
                    target.AddBuff(BuffID.Slimed, 1500);
                    target.AddBuff(mod.BuffType("Fused"), 1800);
                }
                if (npc.type == NPCID.IlluminantSlime)
                {
                    target.AddBuff(BuffID.Slimed, 1200);
                    target.AddBuff(mod.BuffType("Purified"), 600);
                }
                if (npc.type == NPCID.RainbowSlime)
                {
                    target.AddBuff(BuffID.Slimed, 1800);
                    target.AddBuff(mod.BuffType("FlamesoftheUniverse"), 600);
                }

                if ((npc.type == NPCID.DemonEye || npc.type == NPCID.DemonEyeOwl || npc.type == NPCID.DemonEyeSpaceship) && NPC.downedBoss2 && Main.rand.Next(4) == 0 && !target.HasBuff(BuffID.Stoned))
                {
                    target.AddBuff(BuffID.Stoned, 120);
                }

                if((npc.type == NPCID.EaterofSouls || npc.type == NPCID.Crimera) && Main.rand.Next(5) == 0)
                {
                    target.AddBuff(BuffID.Weak, 1800);
                }

                if(npc.type == NPCID.EyeofCthulhu)
                {
                    target.AddBuff(BuffID.Slow, 600);

                    if(!target.HasBuff(mod.BuffType("Berserked")))
                    {
                        target.AddBuff(mod.BuffType("Berserked"), Main.rand.Next(300, 900));
                    }
                    
                }

                if (npc.type == NPCID.ServantofCthulhu)
                {
                    target.AddBuff(mod.BuffType("Hexed"), 300);
                }

                if (npc.type == NPCID.QueenBee)
                {
                    target.AddBuff(BuffID.Venom, 300);
                }

                if(npc.type == NPCID.WallofFlesh || npc.type == NPCID.WallofFleshEye)
                {
                    target.AddBuff(mod.BuffType("Unstable"), 240);
                }

                if (npc.type == NPCID.TheHungry || npc.type == NPCID.TheHungryII)
                {
                    target.AddBuff(mod.BuffType("Crippled"), 240);
                }

                if (npc.type == NPCID.EaterofWorldsHead || npc.type == NPCID.EaterofWorldsBody || npc.type == NPCID.EaterofWorldsTail)
                {
                    target.AddBuff(mod.BuffType("Rotting"), 600);
                }

                if (npc.type == NPCID.EaterofWorldsHead)
                {
                    target.AddBuff(BuffID.Weak, 36000);
                }

                if(npc.type == NPCID.CursedSkull)
                {
                    target.AddBuff(BuffID.Cursed, 600);
                }

                if(npc.type == NPCID.Snatcher && Main.rand.Next(2) == 0)
                {
                    target.AddBuff(BuffID.Bleeding, 1200);
                }

                if(npc.type == NPCID.ManEater && target.statLife < 100)
                {
                    target.KillMe(PlayerDeathReason.ByCustomReason(target.name + " was eaten alive by a Man Eater."), 999, 0);
                }

                if (npc.type == NPCID.TombCrawlerHead && target.statLife < 60)
                {
                    target.KillMe(PlayerDeathReason.ByCustomReason(target.name + " was eaten alive by a Tomb Crawler."), 999, 0);
                }

                if (npc.type == NPCID.DevourerHead && target.statLife < 50)
                {
                    target.KillMe(PlayerDeathReason.ByCustomReason(target.name + " was eaten alive by a Devourer."), 999, 0);
                }

                if (npc.type == NPCID.SkeletronHead && Main.rand.Next(2) == 0)
                {
                    target.AddBuff(mod.BuffType("Lethargic"), 360);
                }

                if (npc.type == NPCID.SkeletronHand && Main.rand.Next(5) == 0)
                {
                    target.AddBuff(mod.BuffType("Stunned"), 45);
                }

                if(npc.type == NPCID.CaveBat)
                {
                    target.AddBuff(BuffID.Bleeding, 1200);
                    target.AddBuff(BuffID.Rabies, 7200);
                }

                if (npc.type == NPCID.Hellbat)
                {
                    target.AddBuff(BuffID.OnFire, 600);
                    target.AddBuff(BuffID.Rabies, 7200);
                }

                if (npc.type == NPCID.JungleBat)
                {
                    target.AddBuff(BuffID.Poisoned, 600);
                    target.AddBuff(BuffID.Rabies, 7200);
                }

                if (npc.type == NPCID.IceBat)
                {
                    if(target.HasBuff(BuffID.Chilled) && !target.HasBuff(BuffID.Frozen))
                    {
                        target.AddBuff(BuffID.Frozen, 120);
                    }

                    target.AddBuff(BuffID.Frostburn, 600);
                    target.AddBuff(BuffID.Rabies, 7200);
                }

                if (npc.type == NPCID.Lavabat)
                {
                    target.AddBuff(BuffID.Rabies, 7200);
                    target.AddBuff(BuffID.CursedInferno, 600);
                }

                if (npc.type == NPCID.GiantBat)
                {
                    target.AddBuff(BuffID.Rabies, 7200);

                    if(Main.rand.Next(2) == 0)
                    {
                        target.AddBuff(BuffID.Confused, 900);
                    }
                }

                if (npc.type == NPCID.IlluminantBat)
                {
                    target.AddBuff(BuffID.Rabies, 7200);

                    if (Main.rand.Next(2) == 0)
                    {
                        target.AddBuff(mod.BuffType("Flipped"), 1800);
                    }
                }

                if (npc.type == NPCID.GiantFlyingFox)
                {
                    target.AddBuff(BuffID.Rabies, 7200);

                    if (Main.rand.Next(2) == 0)
                    {
                        target.AddBuff(mod.BuffType("Bloodthirsty"), 600);

                    }
                }

                if (npc.type == NPCID.VampireBat || npc.type == NPCID.Vampire)
                {
                    target.AddBuff(BuffID.Rabies, 7200);
                    target.AddBuff(BuffID.Darkness, 1800);
                    target.AddBuff(BuffID.Weak, 1800);
                    target.AddBuff(mod.BuffType("LivingWasteland"), 900);
                }

                if(npc.type == NPCID.SnowFlinx)
                {
                    target.AddBuff(mod.BuffType("Purified"), 600);
                }

                if (npc.type == NPCID.Vulture && Main.rand.Next(3) == 0)
                {
                    target.AddBuff(BuffID.Confused, 120);
                }

                if(npc.type == NPCID.Piranha)
                {
                    target.AddBuff(BuffID.Bleeding, 600);
                }

                if(npc.type == NPCID.Medusa)
                {
                    if(!target.HasBuff(BuffID.Stoned))
                    {
                        target.AddBuff(BuffID.Stoned, 120);
                    }
                    
                    target.AddBuff(mod.BuffType("Flipped"), 180);
                }

                if (npc.type == NPCID.SpikeBall && Main.rand.Next(2) == 0)
                {
                    target.AddBuff(BuffID.BrokenArmor, 1200);
                }

                if (npc.type == NPCID.BlazingWheel)
                {
                    target.AddBuff(BuffID.OnFire, 600);
                }

                if (npc.type == NPCID.Shark)
                {
                    target.AddBuff(BuffID.Bleeding, 300);
                }

                if ((npc.type == NPCID.BlueJellyfish || npc.type == NPCID.PinkJellyfish) && target.wet && Main.rand.Next(2) == 0)
                {
                    target.AddBuff(BuffID.Electrified, 240);
                }

                if (npc.type == NPCID.GraniteFlyer && Main.rand.Next(10) == 0 && !target.HasBuff(BuffID.Stoned))
                {
                    target.AddBuff(BuffID.Stoned, 120);
                }

                if (npc.type == NPCID.GraniteGolem && Main.rand.Next(2) == 0 && !target.HasBuff(BuffID.Stoned))
                {
                    target.AddBuff(BuffID.Stoned, 120);
                }

                if (npc.type == NPCID.GoblinScout && NPC.downedGoblins && Main.rand.Next(4) == 0)
                {
                    //goblins
                    Main.StartInvasion(1);
                }

                if(npc.type == NPCID.LeechHead)
                {
                    target.AddBuff(BuffID.Bleeding, 900);
                    target.AddBuff(BuffID.Slow, 240);
                }

                if(npc.type == NPCID.GoblinThief && Main.rand.Next(3) == 0)
                {
                    target.AddBuff(BuffID.Midas, 1200);
                }

                if(npc.type == NPCID.AnomuraFungus && Main.rand.Next(2) == 0)
                {
                    target.AddBuff(BuffID.Poisoned, 600);
                }

                if (npc.type == NPCID.WaterSphere && Main.rand.Next(4) == 0)
                {
                    target.AddBuff(mod.BuffType("Flipped"), 1200);
                }

                if (npc.type == NPCID.DevourerHead)
                {
                    target.AddBuff(BuffID.BrokenArmor, 900);
                }

                if (npc.type == NPCID.GiantShelly || npc.type == NPCID.GiantShelly2)
                {
                    target.AddBuff(BuffID.Slow, 600);
                }

                if (npc.type == NPCID.Squid && Main.rand.Next(2) == 0)
                {
                    target.AddBuff(BuffID.Obstructed, 240);
                }

                if (npc.type == NPCID.BloodZombie && Main.rand.Next(3) == 0)
                {
                    target.AddBuff(mod.BuffType("Bloodthirsty"), 240);     
                }

                if(npc.type == NPCID.Drippler && Main.rand.Next(2) == 0)
                {
                    target.AddBuff(mod.BuffType("Rotting"), 600);
                }

                if (npc.type == NPCID.FlyingFish && Main.rand.Next(3) == 0)
                {
                    target.AddBuff(BuffID.Confused, 240);
                }

                if (npc.type == NPCID.ChaosBall)
                {
                    target.AddBuff(BuffID.ShadowFlame, 600);
                }

                if (npc.type == NPCID.Demon || npc.type == NPCID.VoodooDemon)
                {
                    target.AddBuff(BuffID.Darkness, 1800);
                }

                if (npc.type == NPCID.Tumbleweed && Main.rand.Next(2) == 0)
                {
                    target.AddBuff(mod.BuffType("Crippled"), 300);
                }

                if ((npc.type == NPCID.CorruptBunny || npc.type == NPCID.CrimsonBunny || npc.type == NPCID.CorruptGoldfish || npc.type == NPCID.CrimsonGoldfish || npc.type == NPCID.CorruptPenguin || npc.type == NPCID.CrimsonPenguin) && Main.rand.Next(2) == 0)
                {
                    target.AddBuff(mod.BuffType("SqueakyToy"), 600);
                }

                if (npc.type == NPCID.FaceMonster)
                {
                    target.AddBuff(BuffID.Rabies, 1800);
                }

                if (npc.type == NPCID.Harpy && Main.rand.Next(2) == 0)
                {
                    target.AddBuff(mod.BuffType("ClippedWings"), 480);
                }

                if (npc.type == NPCID.SeaSnail)
                {
                    target.AddBuff(BuffID.OgreSpit, 600);
                }

                if (npc.type == NPCID.BrainofCthulhu)
                {
                    target.AddBuff(mod.BuffType("Infested"), 600);
                }

                if(npc.type == NPCID.Creeper && Main.rand.Next(30) == 0)
                {
                    int[] debuffs = {mod.BuffType("Berserked"), mod.BuffType("Lethargic"), mod.BuffType("Flipped")};
                    target.AddBuff(debuffs[Main.rand.Next(debuffs.Length)], 900);
                }

                /*if (npc.type == NPCID.GiantFlyingFox)
                {
                    target.AddBuff(mod.BuffType("Infested"), 600);
                }*/


            }
           
        }


        public override bool StrikeNPC (NPC npc, ref double damage, int defense, ref float knockback, int hitDirection, ref bool crit)
		{
			Player player = Main.player[Main.myPlayer];
			FargoPlayer modPlayer = player.GetModPlayer<FargoPlayer>(mod);
			
			if (FargoWorld.masochistMode)
            {
                NPC damagedNPC = npc;
                //basically, is this a segment?
                if (npc.realLife >= 0)
                {
                    damagedNPC = Main.npc[damagedNPC.realLife];
                }

                ResetRegenTimer(damagedNPC);
			}

			if(modPlayer.universeEffect)
			{
				if(crit)
				{
					damage *= 4;
					//return false;
				}
			}
			
			if(modPlayer.shroomEnchant && crit)
			{
				if(modPlayer.isStandingStill)
				{
					damage *= 2;
					//return false;
				}
				else
				{
					crit = false;
				}
			}
			
			if(modPlayer.firstStrike && npc.lifeMax == npc.life)
			{
				crit = true;
			}
			
			//normal damage calc
			return true;
		}
		
		public override void OnHitByItem (NPC npc, Player player, Item item, int damage, float knockback, bool crit)
		{
			FargoPlayer modPlayer = player.GetModPlayer<FargoPlayer>(mod);
			
			
			if((soulcheck.splitEnemy && modPlayer.meleeEffect || modPlayer.universeEffect) && !npc.boss && Main.rand.Next(5) == 0)
			{
				NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, npc.type);
			}
		}
		
		public override void DrawEffects(NPC npc, ref Color drawColor)
		{
			
		}

	}
}