using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
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
            npc.defense = 15;
            npc.lifeMax = 250;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 0.5f;
            animationType = NPCID.Guide;
            Main.npcCatchable[npc.type] = true;
            npc.catchItem = (short)mod.ItemType("Abominationn");
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
            int mechanic = NPC.FindFirstNPC(NPCID.Mechanic);

            if (mutant >= 0 && Main.rand.Next(26) == 0)
            {
                return "That one guy, " + Main.npc[mutant].GivenName + ", he is my brother... I've fought more bosses than him.";
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

            if (Fargowiltas.instance.fargoLoaded && MasochistMode)
            {
                button2 = "Help";
            }
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if (firstButton)
            {
                shop = true;
            }
            else
            {
                Player p = Main.player[Main.myPlayer];
                FargowiltasSouls.FargoPlayer fargoPlayer = p.GetModPlayer<FargowiltasSouls.FargoPlayer>();

                IList<string> dialogue = new List<string>();

                if (Main.rand.Next(3) == 0)
                {
                    if (FargowiltasSouls.FargoSoulsWorld.downedMutant)
                        dialogue.Add("What's that? You want to fight me? ...maybe in 2023.");
                    else if (FargowiltasSouls.FargoSoulsWorld.downedFishronEX)
                        dialogue.Add("What's that? You want to fight my brother? ...maybe if he had a reason to.");
                }

                if (NPC.downedMoonlord && !FargowiltasSouls.FargoSoulsWorld.downedFishronEX && Main.rand.Next(3) == 0)
                    dialogue.Add("When you're ready, go fishing with a Truffle Worm EX. But until then... yeah, keep farming. So what are you buying today?");

                dialogue.Add("You're more masochistic than I thought, aren't you?");
                dialogue.Add("Seems like everyone's learning to project auras these days. If you look at the particles, you can see whether it'll affect you at close range or a distance.");
                dialogue.Add("There's probably a thousand items to protect against all these debuffs. It's a shame you don't have a thousand hands to carry them all at once.");
                dialogue.Add("I've always wondered why those other monsters never bothered to carry any healing potions. Well, you probably shouldn't wait and see if they actually do.");
                dialogue.Add("Powerful enemies can drop all sorts of helpful loot. They'll also come back for revenge after you beat them, so keep an eye out for that.");
                dialogue.Add("Why bother fishing when you can massacre bosses for the same goods? With spawners provided by my brother of course!");

                if (!p.accFlipper && !p.gills && !fargoPlayer.MutantAntibodies)
                    dialogue.Add("The water is bogging you down? Never had an issue with it, personally... Have you tried breathing water instead of air?");
                if (!p.fireWalk && !p.buffImmune[BuffID.OnFire])
                    dialogue.Add("The underworld has gotten a lot hotter since the last time I visited. I hear an obsidian is a good luck charm against burning alive, though.");
                if (!p.buffImmune[BuffID.Suffocation] && !fargoPlayer.PureHeart)
                    dialogue.Add("Want to have a breath-holding contest? The empty vacuum of space would be perfect.");

                if (p.statLifeMax < 400)
                    dialogue.Add("I don't have any Life Crystals for you, but Cthulhu's eye is going on a new diet of them. Not that they would share...");
                if (NPC.downedBoss3)
                    dialogue.Add("Dungeon Guardian sent me photos of their kids earlier. Cute little skull demons hiding in other skeletons, aren't they? Oh, and their drop wards off random boss spawns, I guess.");

                if (Main.hardMode)
                {
                    if (!fargoPlayer.PureHeart)
                        dialogue.Add("The spirits of light and dark stopped by and they sounded pretty upset with you. Don't be too surprised if something happens to you for entering their territory.");
                    dialogue.Add("They're not in my shop, but why not go hunting for some rare monsters every once in a while? Plenty of treasure to be looted and all that.");
                    dialogue.Add("The desert monsters keep sending me letters about all the fossils they're collecting. I don't get the craze about it, myself.");
                    if (p.statLifeMax < 500)
                        dialogue.Add("If you ask me, Plantera is really letting herself go. Chlorophyte and Life Fruit aren't THAT healthy!");
                }

                if (NPC.downedPlantBoss)
                    dialogue.Add("Trick or treat? Merry Christmas? I don't have anything for you, go ask Pumpking or Ice Queen.");

                Main.npcChatText = dialogue[Main.rand.Next(dialogue.Count)];
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
            //AddItem(NPC.downedBoss1, "Fargowiltas", "BloodMoonMedallion", 20000, ref shop, ref nextSlot);

            if (Fargowiltas.instance.sacredToolsLoaded)
            {
                AddItem(NPC.downedBoss1, "SacredTools", "SandstormMedallion", 20000, ref shop, ref nextSlot);
            }

            if (Fargowiltas.instance.grealmLoaded)
            {
                AddItem(GRealmInvasion, "GRealm", "HordeStaff", 30000, ref shop, ref nextSlot);
            }

            if (Fargowiltas.instance.redemptionLoaded)
            {
                AddItem(ChickenArmy, "Redemption", "ChickenContract", RedePatientZero ? 100000 : 10000, ref shop, ref nextSlot);
            }

            shop.item[nextSlot].SetDefaults(ItemID.GoblinBattleStandard);
            shop.item[nextSlot].value = 50000;
            nextSlot++;

            if (Fargowiltas.instance.tremorLoaded)
            {
                AddItem(NPC.downedBoss2, "Tremor", "ScrollofUndead", 50000, ref shop, ref nextSlot);
            }

            if (Fargowiltas.instance.spiritLoaded)
            {
                AddItem(SpiritInvasion, "SpiritMod", "BlackPearl", 60000, ref shop, ref nextSlot);
            }

            if (Fargowiltas.instance.btfaLoaded)
            {
                AddItem(BtfaInvasion, "ForgottenMemories", "AncientLog", 50000, ref shop, ref nextSlot);
            }

            if (Main.hardMode)
            {
                shop.item[nextSlot].SetDefaults(ItemID.SnowGlobe);
                shop.item[nextSlot].value = 80000;
                nextSlot++;
            }

            if (NPC.downedPirates)
            {
                shop.item[nextSlot].SetDefaults(ItemID.PirateMap);
                shop.item[nextSlot].value = 100000;
                nextSlot++;
            }

            if (NPC.downedGolemBoss)
            {
                shop.item[nextSlot].SetDefaults(ItemID.SolarTablet);
                shop.item[nextSlot].value = 100000;
                nextSlot++;
            }

            AddItem(FargoWorld.downedBetsy, "Fargowiltas", "ForbiddenTome", 200000, ref shop, ref nextSlot);
            AddItem(FargoWorld.downedBetsy, "Fargowiltas", "BatteredClub", 400000, ref shop, ref nextSlot);
            AddItem(FargoWorld.downedBetsy, "Fargowiltas", "BetsyEgg", 600000, ref shop, ref nextSlot);
            AddItem(NPC.downedMartians, "Fargowiltas", "RunawayProbe", 100000, ref shop, ref nextSlot);

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
