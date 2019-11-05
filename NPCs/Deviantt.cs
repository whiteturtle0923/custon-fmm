using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.NPCs
{
    [AutoloadHead]
    public class Deviantt : ModNPC
    {
        public override bool Autoload(ref string name)
        {
            name = "Deviantt";
            return mod.Properties.Autoload;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Deviantt");
            Main.npcFrameCount[npc.type] = 23;
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
            npc.breathCounter = 9999;

            npc.defense = NPC.downedMoonlord ? 50 : 15;
            npc.lifeMax = NPC.downedMoonlord ? 2500 : 250;

            /*if (Fargowiltas.instance.fargoLoaded && FargoDownedMutant)
            {
                npc.lifeMax = 7700000;
                npc.defense = 400;
            }*/

            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 0.5f;
            animationType = NPCID.Angler;
            Main.npcCatchable[npc.type] = true;
            npc.catchItem = (short)mod.ItemType("Deviantt");

            npc.buffImmune[BuffID.Suffocation] = true;
        }

        public override bool CanTownNPCSpawn(int numTownnpcs, int money)
        {
            return NPC.AnyNPCs(mod.NPCType("Mutant"));
        }

        public override string TownNPCName()
        {
            switch (WorldGen.genRand.Next(10))
            {
                case 0:
                    return "Akira";

                case 1:
                    return "Remi";

                case 2:
                    return "Bloom";

                case 3:
                    return "Yuuki";

                case 4:
                    return "Seira";

                case 5:
                    return "Koi";

                case 6:
                    return "Elly";

                case 7:
                    return "Lori";

                case 8:
                    return "Calius";

                default:
                    return "Teri";
            }
        }

        public override string GetChat()
        {
            IList<string> dialogue = new List<string>();


            
            dialogue.Add("Did you know? The only real music genres are death metal and artcore.");

            return dialogue[Main.rand.Next(dialogue.Count)];


            if (NPC.downedMoonlord && Fargowiltas.instance.fargoLoaded && Main.rand.Next(32) == 0)
            {
                return "Now that you've defeated the big guy, I'd say it's time to start collecting those materials!";
            }

            if (Fargowiltas.instance.calamityLoaded && Main.rand.Next(63) == 0)
            {
                return "Why would you do this.";
            }

            if (Fargowiltas.instance.calamityLoaded && Fargowiltas.instance.thoriumLoaded && Main.rand.Next(62) == 0)
            {
                return "I feel a great imbalance in this world.";
            }

            if (Fargowiltas.instance.thoriumLoaded && Main.rand.Next(61) == 0)
            {
                return "A great choice, shame about that first desert boss thing though.";
            }

            if (Main.pumpkinMoon)
            {
                return "A bit spooky tonight, isn't it.";
            }

            if (Main.snowMoon)
            {
                return "I'd ask for a coat, but I don't think you have any my size.";
            }

            if (Main.slimeRain)
            {
                return "Weather seems odd today, wouldn't you agree?";
            }

            if (Main.bloodMoon)
            {
                switch (Main.rand.Next(1))
                {
                    case 0:
                        return "Lovely night, isn't it?";

                    default:
                        return "I hope the constant arguing I'm hearing isn't my fault.";
                }
            }

            //specific other npc quotes
            int nurse = NPC.FindFirstNPC(NPCID.Nurse);
            int witchDoctor = NPC.FindFirstNPC(NPCID.WitchDoctor);
            int dryad = NPC.FindFirstNPC(NPCID.Dryad);
            int stylist = NPC.FindFirstNPC(NPCID.Stylist);
            int guide = NPC.FindFirstNPC(NPCID.Guide);
            int tax = NPC.FindFirstNPC(NPCID.TaxCollector);
            int truffle = NPC.FindFirstNPC(NPCID.Truffle);
            int cyborg = NPC.FindFirstNPC(NPCID.Cyborg);
            int partyGirl = NPC.FindFirstNPC(NPCID.PartyGirl);
            int demoman = NPC.FindFirstNPC(NPCID.Demolitionist);
            int tavernkeep = NPC.FindFirstNPC(NPCID.DD2Bartender);
            int dyeTrader = NPC.FindFirstNPC(NPCID.DyeTrader);
            int lumberJack = NPC.FindFirstNPC(mod.NPCType("LumberJack"));

            if (BirthdayParty.PartyIsUp)
            {
                switch (Main.rand.Next(2))
                {
                    case 0:
                        return Main.npc[partyGirl].GivenName + " is the one who invited me, I don't understand why though.";

                    default:
                        return "I don't know what everyone's so happy about, but as long as nobody mistakes me for a Pigronata, I'm happy too.";
                }
            }

            if (lumberJack >= 0 && Main.rand.Next(60) == 0)
            {
                return "It's okay " + Main.npc[npc.whoAmI].GivenName + ", just don't look straight into " + Main.npc[lumberJack].GivenName + "'s eyes. He can't scare you that way...";
            }
            if (nurse >= 0 && Main.rand.Next(59) == 0)
            {
                return "Whenever we're alone, " + Main.npc[nurse].GivenName + " keeps throwing syringes at me, no matter how many times I tell her to stop!";
            }
            if (witchDoctor >= 0 && Main.rand.Next(58) == 0)
            {
                return "Please go tell " + Main.npc[witchDoctor].GivenName + " to drop the 'mystical' shtick, I mean, come on! I get it, you make tainted water or something.";
            }
            if (dryad >= 0 && Main.rand.Next(57) == 0)
            {
                return "Why does " + Main.npc[dryad].GivenName + "'s outfit make my wings flutter?";
            }
            if (stylist >= 0 && Main.rand.Next(56) == 0)
            {
                return Main.npc[stylist].GivenName + " once gave me a wig... I look hideous with long hair.";
            }
            if (truffle >= 0 && Main.rand.Next(55) == 0)
            {
                return "That mutated mushroom seems like my type of fella.";
            }
            if (tax >= 0 && Main.rand.Next(54) == 0)
            {
                return Main.npc[tax].GivenName + " keeps asking me for money, but he won't accept my spawners!";
            }
            if (guide >= 0 && Main.rand.Next(53) == 0)
            {
                return "Any idea why " + Main.npc[guide].GivenName + " is always cowering in fear when I get near him?";
            }
            if (truffle >= 0 && witchDoctor >= 0 && cyborg >= 0 && Main.rand.Next(52) == 0)
            {
                return "If any of us could play instruments, I'd totally start a band with " + Main.npc[witchDoctor].GivenName + ", " + Main.npc[truffle].GivenName + ", and " + Main.npc[cyborg].GivenName + ".";
            }
            if (partyGirl >= 0 && Main.rand.Next(51) == 0)
            {
                return "Man," + Main.npc[partyGirl].GivenName + "'s confetti keeps getting stuck to my wings";
            }
            if (demoman >= 0 && Main.rand.Next(50) == 0)
            {
                return "I'm surprised " + Main.npc[demoman].GivenName + " hasn't blown a hole in the floor yet, on second thought that sounds fun.";
            }
            if (tavernkeep >= 0 && Main.rand.Next(49) == 0)
            {
                return Main.npc[tavernkeep].GivenName + " keeps suggesting I drink some beer, something tells me he wouldn't like me when I'm drunk though.";
            }
            if (dyeTrader >= 0 && Main.rand.Next(48) == 0)
            {
                return Main.npc[dyeTrader].GivenName + " wants to see what I would look like in blue... I don't know how to feel.";
            }

            if (Main.dayTime != true && Main.rand.Next(20) == 0)
            {
                return "I'd follow and help, but I'd much rather sit around right now.";
            }

            switch (Main.rand.Next(45))
            {
                case 0:
                    return "Savagery, barbarism, bloodthirst, that's what I like seeing in people.";
                case 1:
                    return "The stronger you get, the more stuff I sell. Makes sense, right?";
                case 2:
                    return "There's something all of you have that I don't... Death perception, I think it's called?";
                case 3:
                    return "It would be pretty cool if I sold a summon for myself...";
                case 4:
                    return "The only way to get stronger is to keep buying from me and in bulk too!";
                case 5:
                    return "Why are you looking at me like that, all I did was eat an apple.";
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
                    return "Those guys really need to get more creative. All of their first bosses are desert themed!";
                case 14:
                    return "You say you want to know how a Mutant and Abominationn are brothers? You're better off not knowing.";
                case 15:
                    return "I'm all you need for a calamity.";
                case 16:
                    return "Everything shall bow before me! ...after you make this purchase.";
                case 17:
                    return "It's clear that I'm helping you out, but uh.. what's in this for me? A house you say? I eat zombies for breakfast.";
                case 18:
                    return "Can I jump? No, I don't have something called a 'spacebar'.";
                case 19:
                    return "Got your nose, I needed one to replace mine.";
                case 20:
                    return "What's a Terry?";
                case 21:
                    return "Why do so many creatures carry around a weird looking blue doll? The world may never know.";
                case 22:
                    return "Impending doom approaches. ...If you don't buy anything of course.";
                case 23:
                    return "I've heard of a '3rd dimension', I wonder what that looks like.";
                case 24:
                    return "Boy don't I look fabulous today.";
                case 25:
                    return "You have fewer friends than I do eyes.";
                case 26:
                    return "The ocean is a dangerous place, I wonder where Diver is?";
                case 27:
                    return "Do you know what an Ee-arth is?";
                case 28:
                    return "I can't even spell 'apotheosis', do you expect me to know what it is?";
                case 29:
                    return "Where do monsters get their gold from? ...I don't have pockets you know.";
                case 30:
                    return "Dogs are cool and all, but cats dont try to bite my brain.";
                case 31:
                    return "Beware the green dragon... What's that face mean?";
                case 32:
                    return "Where is this O-hi-o I keep hearing about.";
                case 33:
                    return "I've told you 56 times already, I'm busy... Oh wait you want to buy something, I suppose I have time.";
                case 34:
                    return "I've heard of a 'Soul of Souls' that only exists in 2015.";
                case 35:
                    return "Adding EX after everything makes it way more difficult.";
                case 36:
                    return "I think that all modern art looks great, especially the bloody stuff.";
                case 37:
                    return "How many guides does it take to change a lightbulb? ... I don't know, how about you ask him.";
                case 38:
                    return "Good thing I don't have a bed, I'd probably never leave it.";
                case 39:
                    return "What's this about an update? Sounds rare.";
                case 40:
                    return "If you need me I'll be slacking off somewhere.";
                case 41:
                    return "What do you mean who is Fargo!";
                case 42:
                    return "Have you seen the ech cat?";
                case 43:
                    return "I don't understand music nowadays, I prefer some smooth jazz... or the dying screams of monsters.";
                default:
                    return "Cthulhu's got nothing on me!";
            }
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = "Shop";
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if (firstButton)
                shop = true;
        }

        private void AddItem(bool check, string mod, string item, int price, ref Chest shop, ref int nextSlot)
        {
            if (!check) return;
            shop.item[nextSlot].SetDefaults(ModLoader.GetMod(mod).ItemType(item));
            shop.item[nextSlot].value = price;
            nextSlot++;
        }

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            //Eye of Cthulhu
            AddItem(NPC.downedBoss1, "Fargowiltas", "SuspiciousEye", 80000, ref shop, ref nextSlot);

            /*if (Fargowiltas.instance.sacredToolsLoaded)
                AddItem(SacreddownedDecree, "SacredTools", "DecreeSummon", 80000, ref shop, ref nextSlot);*/
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            /*if (Fargowiltas.instance.fargoLoaded && FargoDownedMutant)
            {
                damage = 720;
                knockback = 10f;
            }
            else*/
            if (NPC.downedMoonlord)
            {
                damage = 80;
                knockback = 4f;
            }
            else if (Main.hardMode)
            {
                damage = 40;
                knockback = 4f;
            }
            else
            {
                damage = 20;
                knockback = 2f;
            }
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            if (NPC.downedMoonlord)
            {
                cooldown = 1;
            }
            else if (Main.hardMode)
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
            /*if (Fargowiltas.instance.fargoLoaded && FargoDownedMutant)
            {
                projType = ModLoader.GetMod("FargowiltasSouls").ProjectileType("MutantSpearThrownFriendly");
            }
            else */if (NPC.downedMoonlord)
                projType = mod.ProjectileType("FakeHeartMarkDeviantt");
            else
                projType = mod.ProjectileType("FakeHeartDeviantt");

            attackDelay = 1;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 10f;
            randomOffset = 0f;
        }

        //gore
        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                for (int k = 0; k < 8; k++)
                {
                    Dust.NewDust(npc.position, npc.width, npc.height, 5, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.8f);
                }
                for (int k = 0; k < 1; k++)
                {
                    Vector2 pos = npc.position + new Vector2(Main.rand.Next(npc.width - 8), Main.rand.Next(npc.height / 2));
                    Gore.NewGore(pos, npc.velocity, mod.GetGoreSlot("Gores/DevianttGore3"));
                }
                for (int k = 0; k < 1; k++)
                {
                    Vector2 pos = npc.position + new Vector2(Main.rand.Next(npc.width - 8), Main.rand.Next(npc.height / 2));
                    Gore.NewGore(pos, npc.velocity, mod.GetGoreSlot("Gores/DevianttGore2"));
                }
                for (int k = 0; k < 1; k++)
                {
                    Vector2 pos = npc.position + new Vector2(Main.rand.Next(npc.width - 8), Main.rand.Next(npc.height / 2));
                    Gore.NewGore(pos, npc.velocity, mod.GetGoreSlot("Gores/DevianttGore1"));
                }
            }
            else
            {
                for (int k = 0; k < damage / npc.lifeMax * 50.0; k++)
                {
                    Dust.NewDust(npc.position, npc.width, npc.height, 5, (float)hitDirection, -1f, 0, default(Color), 0.6f);
                }
            }
        }
    }
}
