using System.Collections.Generic;
using Fargowiltas.Items.Summons.Deviantt;
using Fargowiltas.Items.Summons.Abom;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Audio;
using Fargowiltas.Items.Vanity;
using Terraria.GameContent.Bestiary;

namespace Fargowiltas.NPCs
{
    [AutoloadHead]
    public class Abominationn : ModNPC
    {
        private bool saidDefeatQuote;

        //public override bool Autoload(ref string name)
        //{
        //    name = "Abominationn";
        //    return mod.Properties.Autoload;
        //}

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Abominationn");

            Main.npcFrameCount[NPC.type] = 25;
            NPCID.Sets.ExtraFramesCount[NPC.type] = 9;
            NPCID.Sets.AttackFrameCount[NPC.type] = 4;
            NPCID.Sets.DangerDetectRange[NPC.type] = 700;
            NPCID.Sets.AttackType[NPC.type] = 0;
            NPCID.Sets.AttackTime[NPC.type] = 90;
            NPCID.Sets.AttackAverageChance[NPC.type] = 30;
            NPCID.Sets.HatOffsetY[NPC.type] = 2;

            NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            {
                Velocity = -1f,
                Direction = -1
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Sky,
                new FlavorTextBestiaryInfoElement("Can control the weather, but his weapons are fused to his hands. Thankfully, he doesn’t need to eat and doors magically open when he approaches.")
            });
        }

        public override void SetDefaults()
        {
            NPC.townNPC = true;
            NPC.friendly = true;
            NPC.width = 40;
            NPC.height = 40;
            NPC.aiStyle = 7;
            NPC.damage = 10;
            NPC.defense = NPC.downedMoonlord ? 50 : 15;
            NPC.lifeMax = NPC.downedMoonlord ? 5000 : 250;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.5f;
            AnimationType = NPCID.Guide;

            //if (GetInstance<FargoConfig>().CatchNPCs)
            //{
            //    Main.npcCatchable[NPC.type] = true;
            //    NPC.catchItem = (short)mod.ItemType("Abominationn");
            //}
                
            NPC.buffImmune[BuffID.Suffocation] = true;
        }

        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
            //if (Fargowiltas.ModLoaded["FargowiltasSouls"] && ((bool)ModLoader.GetMod("FargowiltasSouls").Call("MutantAlive") || (bool)ModLoader.GetMod("FargowiltasSouls").Call("AbomAlive")))
            //{
            //    return false;
            //}
            return GetInstance<FargoConfig>().Abom && NPC.downedGoblins && !FargoGlobalNPC.AnyBossAlive();
        }

        public override bool CanGoToStatue(bool toKingStatue) => toKingStatue;

        public override void AI()
        {
            NPC.breath = 200;
        }

        public override string TownNPCName()
        {
            string[] names = { "Wilta", "Jack", "Harley", "Reaper", "Stevenn", "Doof", "Baroo", "Fergus", "Entev", "Catastrophe", "Bardo", "Betson" };
            return Main.rand.Next(names);
        }

        public override string GetChat()
        {
            if (NPC.homeless && !saidDefeatQuote && Fargowiltas.ModLoaded["FargowiltasSouls"] && (bool)ModLoader.GetMod("FargowiltasSouls").Call("DownedAbom"))
            {
                saidDefeatQuote = true;
                return "You really defeated me... not bad. Now do it again without getting hit. Oh, and Copper Shortsword only.";
            }

            List<string> dialogue = new List<string>
            {
                "Where'd I get my scythe from? " + (!Main.hardMode ? "Ask me later." : "You'll figure it out."),
                "I have defeated everything in this land... nothing can beat me.",
                "Have you ever had a weapon stuck to your hand? It's not very handy.",
                "What happened to Yoramur? No idea who you're talking about.",
                "You wish you could dress like me? Ha! Maybe in 2020.",
                "You ever read the ancient classics, I love all the fighting in them.",
                "I'm a world class poet, ever read my piece about impending doom?",
                "You want swarm summons? Maybe next year.",
                "Like my wings? Thanks, the thing I got them from didn't like it much.",
                "Heroism has no place in this world, instead let's just play ping pong.",
                "Why are you looking at me like that? Your fashion sense isn't going to be winning you any awards either.",
                "No, you can't have my hat.",
                "Embrace suffering... Wait what do you mean that's already taken?",
                "Your attempt to exploit my anger is admirable, but I cannot be angered.",
                "Is it really a crime if everyone else does it.",
                "Inflicting suffering upon others is the most amusing thing there is.",
                "Irony is the best kind of humor, isn't that ironic?",
                "I like Cat... What do you mean who's Cat?",
                "Check the wiki if you need anything, the kirb is slowly getting it up to par.",
                "I've heard tales of a legendary Diver... Anyway what was that about a giant jellyfish?",
                "Overloaded events...? Yeah, they're pretty cool.",
                "It's not like I don't enjoy your company, but can you buy something?",
                "I have slain one thousand humans! Huh? You're a human? There's so much blood on your hands..",
            };

            int mutant = NPC.FindFirstNPC(NPCType<Mutant>());
            if (mutant != -1)
            {
                dialogue.Add($"That one guy, {Main.npc[mutant].GivenName}, he is my brother... I've fought more bosses than him.");
            }

            int deviantt = NPC.FindFirstNPC(NPCType<Deviantt>());
            if (deviantt != -1)
            {
                dialogue.Add($"That one girl, {Main.npc[deviantt].GivenName}, she is my sister... I've defeated more events than her.");
            }

            int mechanic = NPC.FindFirstNPC(NPCID.Mechanic);
            if (mechanic != -1)
            {
                dialogue.Add($"Can you please ask {Main.npc[mechanic].GivenName} to stop touching my laser arm please.");
            }

            return Main.rand.Next(dialogue);
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = Language.GetTextValue("LegacyInterface.28");
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
                    if (Main.netMode != NetmodeID.SinglePlayer)
                    {
                        var netMessage = Mod.GetPacket();
                        netMessage.Write((byte)2);
                        netMessage.Send();
                    }
                    else
                    {
                        Main.NewText("The event has been cancelled!", 175, 75, 255);
                    }

                    SoundEngine.PlaySound(SoundID.Roar, NPC.position, 0);
                    Main.npcChatText = "Hocus pocus, the event is over.";
                }
                else
                {
                    if (eventOccurring)
                    {
                        Main.npcChatText = "I'm not feeling it right now, come back in " + (FargoWorld.AbomClearCD / 60).ToString() + " seconds.";
                    }
                    else
                    {
                        Main.npcChatText = "I don't think there's an event right now.";
                    }
                }
            }
        }

        //public static void AddModItem(bool condition, string modName, string itemName, int price, ref Chest shop, ref int nextSlot)
        //{
        //    if (condition)
        //    {
        //        shop.item[nextSlot].SetDefaults(ModLoader.GetMod(modName).ItemType(itemName));
        //        shop.item[nextSlot].shopCustomPrice = price;
        //        nextSlot++;
        //    }
        //}

        public static void AddItem(bool check, int item, int price, ref Chest shop, ref int nextSlot)
        {
            if (check)
            {
                shop.item[nextSlot].SetDefaults(item);
                shop.item[nextSlot].shopCustomPrice = price;
                nextSlot++;
            }
        }

        //public static void AddItem(bool check, string mod, string item, int price, ref Chest shop, ref int nextSlot)
        //{
        //    if (!check || shop is null)
        //    {
        //        return;
        //    }

        //    shop.item[nextSlot].SetDefaults(ModLoader.GetMod(mod).ItemType(item));
        //    shop.item[nextSlot].shopCustomPrice = price;

        //    nextSlot++;
        //}

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            // Events
            AddItem(true, ItemType<PartyCone>(), 10000, ref shop, ref nextSlot);
            AddItem(true, ItemType<WeatherBalloon>(), 20000, ref shop, ref nextSlot);
            AddItem(true, ItemType<ForbiddenScarab>(), 30000, ref shop, ref nextSlot);
            AddItem(true, ItemType<SlimyBarometer>(), Item.buyPrice(0, 4), ref shop, ref nextSlot);
            AddItem(true, ItemID.BloodMoonStarter, Item.buyPrice(0, 5), ref shop, ref nextSlot);
            AddItem(true, ItemID.GoblinBattleStandard, Item.buyPrice(0, 6), ref shop, ref nextSlot);
            AddItem(Main.hardMode, ItemID.SnowGlobe, Item.buyPrice(0, 15), ref shop, ref nextSlot);
            AddItem(NPC.downedPirates, ItemID.PirateMap, Item.buyPrice(0, 20), ref shop, ref nextSlot);
            AddItem(NPC.downedPirates && FargoWorld.DownedBools["flyingDutchman"], ItemType<PlunderedBooty>(), Item.buyPrice(0, 15), ref shop, ref nextSlot);
            AddItem(NPC.downedMechBossAny, ItemID.SolarTablet, Item.buyPrice(0, 20), ref shop, ref nextSlot);
            AddItem(FargoWorld.DownedBools["darkMage"] || NPC.downedMechBossAny, ItemType<ForbiddenTome>(), Item.buyPrice(0, 5), ref shop, ref nextSlot);
            AddItem(FargoWorld.DownedBools["ogre"] || NPC.downedGolemBoss, ItemType<BatteredClub>(), Item.buyPrice(0, 15), ref shop, ref nextSlot);
            AddItem(FargoWorld.DownedBools["betsy"], ItemType<BetsyEgg>(), Item.buyPrice(0, 40), ref shop, ref nextSlot);

            AddItem(NPC.downedHalloweenKing, ItemID.PumpkinMoonMedallion, Item.buyPrice(0, 50), ref shop, ref nextSlot);
            AddItem(FargoWorld.DownedBools["headlessHorseman"], ItemType<HeadofMan>(), Item.buyPrice(0, 20), ref shop, ref nextSlot);
            AddItem(NPC.downedHalloweenTree, ItemType<SpookyBranch>(), Item.buyPrice(0, 20), ref shop, ref nextSlot);
            AddItem(NPC.downedHalloweenKing, ItemType<SuspiciousLookingScythe>(), Item.buyPrice(0, 30), ref shop, ref nextSlot);
            
            AddItem(NPC.downedChristmasIceQueen, ItemID.NaughtyPresent, Item.buyPrice(0, 50), ref shop, ref nextSlot);
            AddItem(NPC.downedChristmasTree, ItemType<FestiveOrnament>(), Item.buyPrice(0, 20), ref shop, ref nextSlot);
            AddItem(NPC.downedChristmasSantank, ItemType<NaughtyList>(), Item.buyPrice(0, 20), ref shop, ref nextSlot);
            AddItem(NPC.downedChristmasIceQueen, ItemType<IceKingsRemains>(), Item.buyPrice(0, 30), ref shop, ref nextSlot);
            
            AddItem(NPC.downedGolemBoss, ItemType<RunawayProbe>(), Item.buyPrice(0, 50), ref shop, ref nextSlot);
            AddItem(NPC.downedMartians, ItemType<MartianMemoryStick>(), Item.buyPrice(0, 30), ref shop, ref nextSlot);
            

            AddItem(NPC.downedTowers, ItemType<PillarSummon>(), Item.buyPrice(0, 75), ref shop, ref nextSlot);

            //foreach (MutantSummonInfo summon in Fargowiltas.summonTracker.EventSummons)
            //{
            //    AddItem(summon.downed(), summon.modSource, summon.itemName, summon.price, ref shop, ref nextSlot);
            //}

            AddItem(NPC.downedTowers, ItemType<AbominationnScythe>(), Item.buyPrice(0, 5), ref shop, ref nextSlot);
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage = NPC.downedMoonlord ? 150 : 20;
            knockback = NPC.downedMoonlord ? 10f : 4f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = NPC.downedMoonlord ? 1 : 30;
            if (!NPC.downedMoonlord)
            {
                randExtraCooldown = 30;
            }
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            projType = NPC.downedMoonlord ? ProjectileType<Projectiles.DeathScythe>() : ProjectileID.DeathSickle;
            attackDelay = 1;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 12f;
            randomOffset = 2f;
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (NPC.life <= 0)
            {
                for (int k = 0; k < 8; k++)
                {
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, 5, 2.5f * hitDirection, -2.5f, Scale: 0.8f);
                }

                Vector2 pos = NPC.position + new Vector2(Main.rand.Next(NPC.width - 8), Main.rand.Next(NPC.height / 2));
                Gore.NewGore(pos, NPC.velocity, ModContent.Find<ModGore>("Fargowiltas/AbomGore3").Type);

                pos = NPC.position + new Vector2(Main.rand.Next(NPC.width - 8), Main.rand.Next(NPC.height / 2));
                Gore.NewGore(pos, NPC.velocity, ModContent.Find<ModGore>("Fargowiltas/AbomGore2").Type);

                pos = NPC.position + new Vector2(Main.rand.Next(NPC.width - 8), Main.rand.Next(NPC.height / 2));
                Gore.NewGore(pos, NPC.velocity, ModContent.Find<ModGore>("Fargowiltas/AbomGore1").Type);
            }
            else
            {
                for (int k = 0; k < damage / NPC.lifeMax * 50.0; k++)
                {
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, 5, hitDirection, -1f, Scale: 0.6f);
                }
            }
        }
    }
}
