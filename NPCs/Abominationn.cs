using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.NPCs
{
    [AutoloadHead]
    public class Abominationn : ModNPC
    {

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
            npc.defense = NPC.downedMoonlord ? 50 : 15;
            npc.lifeMax = NPC.downedMoonlord ? 5000 : 250;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 0.5f;
            animationType = NPCID.Guide;
            Main.npcCatchable[npc.type] = true;
            npc.catchItem = (short)mod.ItemType("Abominationn");
            npc.buffImmune[BuffID.Suffocation] = true;
        }

        public bool MasochistMode => FargowiltasSouls.FargoSoulsWorld.MasochistMode;

        public bool GRealmInvasion => GRealm.MWorld.downedZombieInvasion;

        public bool BtfaInvasion => ForgottenMemories.TGEMWorld.downedForestInvasion;

        public bool SpiritInvasion => SpiritMod.MyWorld.downedAncientFlier;

        public bool TremorInvasion => Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.ParadoxTitan];

        public bool RedePatientZero => Redemption.RedeWorld.downedPatientZero;

        public bool ChickenArmy => (Redemption.RedeWorld.downedChickenInv || Redemption.RedeWorld.downedChickenInvPZ);

        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
            if (Fargowiltas.instance.fargoLoaded && NPC.AnyNPCs(ModLoader.GetMod("FargowiltasSouls").NPCType("MutantBoss")))
                return false;
            return NPC.downedGoblins;
        }

        public override void AI()
        {
            npc.breath = 200;
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
                case 4:
                    return "Stevenn";
                case 5:
                    return "Doof";
                case 6:
                    return "Baroo";
                case 7:
                    return "Fergus";
                case 8:
                    return "Entev";
                case 9:
                    return "Catastrophe";
                case 10:
                    return "Bardo";
                default:
                    return "Betson";
            }
        }

        public override string GetChat()
        {
            int mutant = NPC.FindFirstNPC(mod.NPCType("Mutant"));
            int deviantt = NPC.FindFirstNPC(mod.NPCType("Deviantt"));
            int mechanic = NPC.FindFirstNPC(NPCID.Mechanic);

            if (mutant >= 0 && Main.rand.Next(26) == 0)
            {
                return "That one guy, " + Main.npc[mutant].GivenName + ", he is my brother... I've fought more bosses than him.";
            }
            if (deviantt >= 0 && Main.rand.Next(26) == 0)
            {
                return "That one girl, " + Main.npc[deviantt].GivenName + ", she is my sister... I've defeated more events than her.";
            }
            if (mechanic >= 0 && Main.rand.Next(25) == 0)
            {
                return "Can you please ask " + Main.npc[mechanic].GivenName + " to stop touching my laser arm please.";
            }
            if (!Main.hardMode && Main.rand.Next(24) == 0)
            {
                return "Where'd I get my scythe from? Ask me later.";
            }
            if (Main.hardMode && Main.rand.Next(24) == 0)
            {
                return "Where'd I get my scythe from? You'll figure it out.";
            }

            switch (Main.rand.Next(23))
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
                    return "You wish you could dress like me? Ha! Maybe in 2020.";
                case 5:
                    return "You ever read the ancient classics, I love all the fighting in them.";
                case 6:
                    return "I'm a world class poet, ever read my piece about impending doom?";
                case 7:
                    return "You want swarm summons? Maybe next year.";
                case 8:
                    return "Like my wings? Thanks, the thing I got them from didn't like it much.";
                case 9:
                    return "Heroism has no place in this world, instead let's just play ping pong.";
                case 10:
                    return "Why are you looking at me like that? Your fashion sense isn't going to be winning you any awards either.";
                case 11:
                    return "No, you can't have my hat.";
                case 12:
                    return "Embrace suffering... Wait what do you mean that's already taken?";
                case 13:
                    return "Your attempt to exploit my anger is admirable, but I cannot be angered.";
                case 14:
                    return "Is it really a crime if everyone else does it.";
                case 15:
                    return "Inflicting suffering upon others is the most amusing thing there is.";
                case 16:
                    return "Irony is the best kind of humor, isn't that ironic?";
                case 17:
                    return "I like Cat... What do you mean who's Cat?";
                case 18:
                    return "Check the wiki if you need anything, the kirb is slowly getting it up to par.";
                case 19:
                    return "I've heard tales of a legendary Diver... Anyway what was that about a giant jellyfish?";
                case 20:
                    return "Overloaded events...? Maybe in 10 Fargo years.";
                case 21:
                    return "It's not like I don't enjoy your company, but can you buy something?";
                default:
                    return "I have slain one thousand humans! Huh? You're a human? There's so much blood on your hands..";
            }
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = Lang.inter[28].Value;
            button2 = "Cancel Event";
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if (firstButton)
            {
                shop = true;
            }
            else
            {
                bool eventOccurring = false;
                if (Fargowiltas.ClearEvents(ref eventOccurring))
                {
                    if (Main.netMode != 0)
                    {
                        var netMessage = mod.GetPacket();
                        netMessage.Write((byte)2);
                        netMessage.Send();
                    }
                    else
                    {
                        Main.NewText("The event has been cancelled!", 175, 75, 255);
                    }
                    Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 0, 1f, 0.0f);
                    Main.npcChatText = "Hocus pocus, the event is over.";
                }
                else
                {
                    if (eventOccurring)
                        Main.npcChatText = "I'm not feeling it right now, come back in " + (FargoWorld.AbomClearCD / 60).ToString() + " seconds.";
                    else
                        Main.npcChatText = "I don't think there's an event right now.";
                }
            }
        }

        void AddItem(bool check, string mod, string item, int price, ref Chest shop, ref int nextSlot)
        {
            if (!check) return;
            shop.item[nextSlot].SetDefaults(ModLoader.GetMod(mod).ItemType(item));
            shop.item[nextSlot].value = price;
            nextSlot++;
        }

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            //EVENTS
            AddItem(NPC.downedSlimeKing, "Fargowiltas", "SlimyBarometer", 40000, ref shop, ref nextSlot);
            AddItem(NPC.downedBoss1, "Fargowiltas", "CursedSextant", 50000, ref shop, ref nextSlot);

            if (Fargowiltas.instance.sacredToolsLoaded)
            {
                AddItem(NPC.downedBoss1, "SacredTools", "SandstormMedallion", 40000, ref shop, ref nextSlot);
            }

            if (Fargowiltas.instance.grealmLoaded)
            {
                AddItem(GRealmInvasion, "GRealm", "HordeStaff", 50000, ref shop, ref nextSlot);
            }

            if (Fargowiltas.instance.redemptionLoaded)
            {
                AddItem(ChickenArmy, "Redemption", "ChickenContract", RedePatientZero ? 100000 : 10000, ref shop, ref nextSlot);
            }

            shop.item[nextSlot].SetDefaults(ItemID.GoblinBattleStandard);
            shop.item[nextSlot].value = 60000;
            nextSlot++;

            if (Fargowiltas.instance.tremorLoaded)
            {
                AddItem(NPC.downedBoss2, "Tremor", "ScrollofUndead", 60000, ref shop, ref nextSlot);
            }

            if (Fargowiltas.instance.spiritLoaded)
            {
                AddItem(SpiritInvasion, "SpiritMod", "BlackPearl", 80000, ref shop, ref nextSlot);
            }

            if (Fargowiltas.instance.btfaLoaded)
            {
                AddItem(BtfaInvasion, "ForgottenMemories", "AncientLog", 80000, ref shop, ref nextSlot);
            }

            if (Main.hardMode)
            {
                shop.item[nextSlot].SetDefaults(ItemID.SnowGlobe);
                shop.item[nextSlot].value = 100000;
                nextSlot++;
            }

            if (NPC.downedPirates)
            {
                shop.item[nextSlot].SetDefaults(ItemID.PirateMap);
                shop.item[nextSlot].value = 120000;
                nextSlot++;
            }

            if (NPC.downedGolemBoss)
            {
                shop.item[nextSlot].SetDefaults(ItemID.SolarTablet);
                shop.item[nextSlot].value = 120000;
                nextSlot++;
            }

            AddItem(FargoWorld.downedDarkMage3, "Fargowiltas", "ForbiddenTome", 150000, ref shop, ref nextSlot);
            AddItem(FargoWorld.downedOgre3, "Fargowiltas", "BatteredClub", 250000, ref shop, ref nextSlot);
            AddItem(FargoWorld.downedBetsy, "Fargowiltas", "BetsyEgg", 400000, ref shop, ref nextSlot);
            AddItem(NPC.downedMartians, "Fargowiltas", "RunawayProbe", 150000, ref shop, ref nextSlot);

            if (NPC.downedHalloweenKing)
            {
                shop.item[nextSlot].SetDefaults(ItemID.PumpkinMoonMedallion);
                shop.item[nextSlot].value = 150000;
                nextSlot++;
            }

            if (NPC.downedChristmasIceQueen)
            {
                shop.item[nextSlot].SetDefaults(ItemID.NaughtyPresent);
                shop.item[nextSlot].value = 150000;
                nextSlot++;
            }

            AddItem(NPC.downedTowers, "Fargowiltas", "PillarSummon", 750000, ref shop, ref nextSlot);

            if (Fargowiltas.instance.tremorLoaded)
            {
                AddItem(TremorInvasion, "Tremor", "AncientWatch", 200000, ref shop, ref nextSlot);
            }
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            if (NPC.downedMoonlord)
            {
                damage = 250;
                knockback = 10f;
            }
            else
            {
                damage = 20;
                knockback = 4f;
            }
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            if (NPC.downedMoonlord)
            {
                cooldown = 1;
            }
            else
            {
                cooldown = 30;
                randExtraCooldown = 30;
            }
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            if (NPC.downedMoonlord)
            {
                projType = mod.ProjectileType("DeathScythe");
                attackDelay = 1;
            }
            else
            {
                projType = ProjectileID.DeathSickle;
                attackDelay = 1;
            }
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 12f;
            randomOffset = 2f;
        }

        //gore
        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                for (int k = 0; k < 8; k++)
                {
                    Dust.NewDust(npc.position, npc.width, npc.height, 5, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.8f);
                }
                for (int k = 0; k < 1; k++)
                {
                    Vector2 pos = npc.position + new Vector2(Main.rand.Next(npc.width - 8), Main.rand.Next(npc.height / 2));
                    Gore.NewGore(pos, npc.velocity, mod.GetGoreSlot("Gores/AbomGore3"));
                }
                for (int k = 0; k < 1; k++)
                {
                    Vector2 pos = npc.position + new Vector2(Main.rand.Next(npc.width - 8), Main.rand.Next(npc.height / 2));
                    Gore.NewGore(pos, npc.velocity, mod.GetGoreSlot("Gores/AbomGore2"));
                }
                for (int k = 0; k < 1; k++)
                {
                    Vector2 pos = npc.position + new Vector2(Main.rand.Next(npc.width - 8), Main.rand.Next(npc.height / 2));
                    Gore.NewGore(pos, npc.velocity, mod.GetGoreSlot("Gores/AbomGore1"));
                }
            }
            else
            {
                for (int k = 0; k < damage / npc.lifeMax * 50.0; k++)
                {
                    Dust.NewDust(npc.position, npc.width, npc.height, 5, hitDirection, -1f, 0, default(Color), 0.6f);
                }
            }
        }
    }
}
