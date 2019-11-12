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

        public bool MasochistMode => FargowiltasSouls.FargoSoulsWorld.MasochistMode;
        public bool FargoDownedMutant => FargowiltasSouls.FargoSoulsWorld.downedMutant;
        public bool FargoDownedFishEX => FargowiltasSouls.FargoSoulsWorld.downedFishronEX;

        public override bool CanTownNPCSpawn(int numTownnpcs, int money)
        {
            return FargoWorld.downedRareEnemy || (Fargowiltas.instance.fargoLoaded && MasochistMode);
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
            if (Main.bloodMoon && Main.rand.Next(2) == 0)
                return "The blood moon's effects? I'm not human anymore, so nope!";

            IList<string> dialogue = new List<string>();

            int mutant = NPC.FindFirstNPC(mod.NPCType("Mutant"));
            if (mutant != -1)
            {
                dialogue.Add("Can you tell " + Main.npc[mutant].GivenName + " to put some clothes on?");
                dialogue.Add("One day, I'll sell a summon for myself! ...Just kidding. That'd be " + Main.npc[mutant].GivenName + "'s job.");
                dialogue.Add(Main.npc[mutant].GivenName + " is here! That's my big brother!");
            }

            int abom = NPC.FindFirstNPC(mod.NPCType("Abominationn"));
            if (abom != -1)
            {
                dialogue.Add(Main.npc[abom].GivenName + " is here! That's my big-but-not-biggest brother!");
            }

            int lumberjack = NPC.FindFirstNPC(mod.NPCType("LumberJack"));
            if (lumberjack != -1)
            {
                dialogue.Add("What's that? You want to fight " + Main.npc[lumberjack].GivenName + "? ...even I know better than to try.");
            }

            int angler = NPC.FindFirstNPC(NPCID.Angler);
            if (angler != -1)
            {
                dialogue.Add("Have you ever considered throwing " + Main.npc[angler].GivenName + " back where you found him?");
            }

            if (Fargowiltas.instance.fargoLoaded && MasochistMode)
                dialogue.Add("Embrace suffering... and while you're at it, embrace another purchase!");
            
            dialogue.Add("Did you know? The only real music genres are death metal and artcore.");
            dialogue.Add("I'll have you know I'm over a hundred Fargo years old! Don't ask me how long a Fargo year is.");
            dialogue.Add("I might be able to afford a taller body if you keep buying!");
            dialogue.Add("Where's that screm cat?");
            dialogue.Add(Main.player[Main.myPlayer].name + "! I saw something rodent-y just now! You don't have a hamster infestation, right? Right!?");
            dialogue.Add("You're the Terrarian? Honestly, I was expecting someone a little... taller.");
            dialogue.Add("Don't look at me like that! The only thing I've deviated from is my humanity.");
            dialogue.Add("Rip and tear and buy from me for more things to rip and tear!");
            dialogue.Add("What's a chee-bee doe-goe?");
            dialogue.Add("Wait a second. Are you sure this house isn't what they call 'prison?'");
            dialogue.Add("Deviantt has awoken! Quick, give her all your money to defeat her!");
            dialogue.Add("One day, I'll sell a summon for myself! ...Just kidding.");
            dialogue.Add("Hmm, I can tell! You've killed a lot, but you haven't killed enough!");
            dialogue.Add("Why the extra letter, you ask? Only the strongest sibling is allowed to remove their own!");

            return dialogue[Main.rand.Next(dialogue.Count)];
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
            else if (Fargowiltas.instance.fargoLoaded && MasochistMode)
            {   
                Fargos(); 
            }
        }

        private void Fargos()
        {
            Player p = Main.player[Main.myPlayer];
            FargowiltasSouls.FargoPlayer fargoPlayer = p.GetModPlayer<FargowiltasSouls.FargoPlayer>();

            if (!fargoPlayer.ReceivedMasoGift && !NPC.downedBoss1)
            {
                fargoPlayer.ReceivedMasoGift = true;
                Item.NewItem(p.Center, ItemID.SilverPickaxe);
                Item.NewItem(p.Center, ItemID.SilverAxe);
                Item.NewItem(p.Center, ItemID.HermesBoots);
                Item.NewItem(p.Center, ItemID.LifeCrystal, 5);
                Main.npcChatText = "This world looks tougher than usual, so you can have these on the house just this once! Talk to me if you need any tips, yeah?";
                return;
            }

            if (Main.rand.Next(4) == 0)
            {
                if (FargoDownedMutant)
                    Main.npcChatText = "What's that? You want to fight me? ...nah, I can't put up a good fight on my own.";
                else if (FargoDownedFishEX)
                    Main.npcChatText = "What's that? You want to fight my big brother? ...maybe if he had a reason to.";
                else if (NPC.downedMoonlord)
                    Main.npcChatText = "When you're ready, go fishing with a Truffle Worm EX. But until then... yeah, keep farming. So what are you buying today?";
                else if (NPC.downedAncientCultist)
                    Main.npcChatText = "Only a specific type of weapon will work against each specific pillar. As for that moon guy, his weakness will keep changing.";
                else if (NPC.downedFishron)
                    Main.npcChatText = "Some powerful enemies like that dungeon guy can create their own arenas. You won't be able to escape, so make full use of the room you do have.";
                else if (NPC.downedGolemBoss)
                    Main.npcChatText = "Did you beat that fish pig dragon yet? He's strong enough to break defenses in one hit. Too bad you don't have any reinforced plating to prevent that, right?";
                else if (NPC.downedPlantBoss)
                    Main.npcChatText = "That golem? It gets upset when you leave the temple, so fighting in there is best. It'll also try to take the high ground against you...";
                else if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
                    Main.npcChatText = "That overgrown plant inflicts a special venom that works her into an enraged frenzy. She also has a ring of crystal leaves, but minions go through it.";
                else if (Main.hardMode)
                {
                    if (!NPC.downedPirates)
                        Main.npcChatText = "Watch out when you break your fourth altar! It might attract the pirates, so be sure you're ready when you do it.";
                    if (!NPC.downedMechBoss1)
                        Main.npcChatText = "That metal worm has a few upgrades. It'll start shooting dark stars and start flying as you damage it. Too bad you can't stay in the air forever, right?";
                    else if (!NPC.downedMechBoss2)
                        Main.npcChatText = "I saw that metal eye spinning while firing a huge laser the other day. Too bad you can't teleport through an attack like that on command, right?";
                    else if (!NPC.downedMechBoss3)
                        Main.npcChatText = "You'll have to destroy the limbs before you can hurt that metal skull. But once it reveals its true form, focus on taking down the head instead.";
                    else
                        Main.npcChatText = "Ever tried out those 'enchantment' thingies? Try breaking a couple altars and see what you can make.";
                }
                else if (NPC.downedBoss3)
                    Main.npcChatText = "That thing's mouth is as good as immune to damage, so you'll have to aim for the eyes. What thing? You know, that thing.";
                else if (NPC.downedQueenBee)
                    Main.npcChatText = "The master of the dungeon can revive itself with a sliver of life for a last stand. Be ready to run for it when you make the killing blow.";
                else if (NPC.downedBoss2)
                    Main.npcChatText = "The queen bee will summon her progeny for backup. She's harder to hurt while they're there, so take them out first.";
                else if (NPC.downedBoss1)
                    Main.npcChatText = WorldGen.crimson ? "When the brain gets mad, it'll confuse you every few seconds. Knowledge is power!" : "When you hurt the world eater, its segments will break off as smaller eaters. Don't let them pile up!";
                else if (NPC.downedSlimeKing)
                    Main.npcChatText = "Keep an eye on Cthulhu's eye when you're fighting. It might just teleport behind you whenever it finishes a set of mad dashes.";
                else if (!NPC.downedGoblins)
                    Main.npcChatText = "Watch out when you break your second " + (WorldGen.crimson ? "Crimson Heart" : "Shadow Orb") + "! It might attract the goblins, so prepare before you do it.";
                else
                    Main.npcChatText = "Gonna fight that slime king soon? Don't spend too long up and out of his reach or he'll get mad. Very, very mad.";
            }
            else
            {
                IList<string> dialogue = new List<string>();

                dialogue.Add("You're more masochistic than I thought, aren't you?");
                dialogue.Add("Seems like everyone's learning to project auras these days. If you look at the particles, you can see whether it'll affect you at close range or a distance.");
                dialogue.Add("There's probably a thousand items to protect against all these debuffs. It's a shame you don't have a thousand hands to carry them all at once.");
                dialogue.Add("I've always wondered why those other monsters never bothered to carry any healing potions. Well, you probably shouldn't wait and see if they actually do.");
                dialogue.Add("Powerful enemies can drop all sorts of helpful loot. They'll also come back for revenge after you beat them, so keep an eye out for that.");
                dialogue.Add("Why bother fishing when you can massacre bosses for the same goods? With spawners provided by my big brother, of course!");
                dialogue.Add("Watch out for those fish! Sharks will leave you alone if you leave them alone, but piranhas go wild when they smell blood.");
                dialogue.Add("Don't forget you can turn off your soul toggles in the Mod Configurations menu!");
                dialogue.Add("Remember to disable any soul toggles you don't need in the Mod Configurations menu!");

                if (!p.accFlipper && !p.gills && !fargoPlayer.MutantAntibodies)
                    dialogue.Add("The water is bogging you down? Never had an issue with it, personally... Have you tried breathing water instead of air?");
                if (!p.fireWalk && !p.buffImmune[BuffID.OnFire])
                    dialogue.Add("The underworld has gotten a lot hotter since the last time I visited. I hear an obsidian skull is a good luck charm against burning alive, though.");
                if (!p.buffImmune[BuffID.Suffocation] && !fargoPlayer.PureHeart)
                    dialogue.Add("Want to have a breath-holding contest? The empty vacuum of space would be perfect.");

                if (p.statLifeMax < 400)
                    dialogue.Add("I don't have any Life Crystals for you, but Cthulhu's eye is going on a new diet of them. Not that they would share.");
                if (NPC.downedBoss3)
                    dialogue.Add("Dungeon Guardian sent me photos of their kids earlier. Cute little skull demons hiding in other skeletons, aren't they? Oh, and their drop wards off random boss spawns, I guess.");

                if (Main.hardMode)
                {
                    if (!fargoPlayer.PureHeart)
                        dialogue.Add("The spirits of light and dark stopped by and they sounded pretty upset with you. Don't be too surprised if something happens to you for entering their territory!");
                    dialogue.Add("Why not go hunting for some rare monsters every once in a while? Plenty of treasure to be looted and all that.");
                    dialogue.Add("The desert monsters keep sending me letters about all the fossils they're collecting. I don't get the craze about it, myself!");
                    if (p.statLifeMax < 500)
                        dialogue.Add("If you ask me, Plantera is really letting herself go. Chlorophyte and Life Fruit aren't THAT healthy!");
                }

                if (NPC.downedPlantBoss)
                    dialogue.Add("Trick or treat? Merry Christmas? I don't have anything for you, but go ask Pumpking or Ice Queen!");

                Main.npcChatText = dialogue[Main.rand.Next(dialogue.Count)];
            }
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
            AddItem(Main.hardMode && Fargowiltas.instance.fargoLoaded, "FargowiltasSouls", "PandorasBox", 250000, ref shop, ref nextSlot);

            //pinky
            AddItem(FargoWorld.downedPinky, "Fargowiltas", "PinkSlimeCrown", Item.buyPrice(0, 5), ref shop, ref nextSlot);

            //doctor bones
            AddItem(FargoWorld.downedDoctorBones, "Fargowiltas", "Eggplant", Item.buyPrice(0, 2), ref shop, ref nextSlot);

            //undead miner
            AddItem(FargoWorld.downedUndeadMiner, "Fargowiltas", "AttractiveOre", Item.buyPrice(0, 3), ref shop, ref nextSlot);

            //tim
            AddItem(FargoWorld.downedTim, "Fargowiltas", "HolyGrail", Item.buyPrice(0, 5), ref shop, ref nextSlot);

            //dungeon slime
            AddItem(FargoWorld.downedDungeonSlime, "Fargowiltas", "SlimyLockBox", Item.buyPrice(0, 10), ref shop, ref nextSlot);

            //medusa
            AddItem(FargoWorld.downedMedusa, "Fargowiltas", "AthenianIdol", Item.buyPrice(0, 5), ref shop, ref nextSlot);

            //clown
            AddItem(FargoWorld.downedClown, "Fargowiltas", "ClownLicense", Item.buyPrice(0, 5), ref shop, ref nextSlot);

            //nymph
            AddItem(FargoWorld.downedNymph, "Fargowiltas", "HeartChocolate", Item.buyPrice(0, 10), ref shop, ref nextSlot);

            //moth
            AddItem(FargoWorld.downedMoth, "Fargowiltas", "MothLamp", Item.buyPrice(0, 10), ref shop, ref nextSlot);

            //rainbow slime
            AddItem(FargoWorld.downedRainbowSlime, "Fargowiltas", "DilutedRainbowMatter", Item.buyPrice(0, 10), ref shop, ref nextSlot);

            //wyvern
            AddItem(FargoWorld.downedWyvern, "Fargowiltas", "CloudSnack", Item.buyPrice(0, 10), ref shop, ref nextSlot);

            //rune wizard
            AddItem(FargoWorld.downedRuneWizard, "Fargowiltas", "RuneOrb", Item.buyPrice(0, 15), ref shop, ref nextSlot);

            //mimics
            AddItem(FargoWorld.downedMimic, "Fargowiltas", "SuspiciousLookingChest", Item.buyPrice(0, 20), ref shop, ref nextSlot);

            //hallow mimic
            AddItem(FargoWorld.downedMimicHallow, "Fargowiltas", "HallowChest", Item.buyPrice(0, 25), ref shop, ref nextSlot);

            //corrupt mimic
            AddItem(FargoWorld.downedMimicCorrupt, "Fargowiltas", "CorruptChest", Item.buyPrice(0, 25), ref shop, ref nextSlot);

            //crimson mimic
            AddItem(FargoWorld.downedMimicCrimson, "Fargowiltas", "CrimsonChest", Item.buyPrice(0, 25), ref shop, ref nextSlot);

            //jungle mimic
            AddItem(FargoWorld.downedMimicJungle, "Fargowiltas", "JungleChest", Item.buyPrice(0, 25), ref shop, ref nextSlot);

            //ice golem
            AddItem(FargoWorld.downedIceGolem, "Fargowiltas", "CoreoftheFrostCore", Item.buyPrice(0, 10), ref shop, ref nextSlot);

            //sand elemental
            AddItem(FargoWorld.downedSandElemental, "Fargowiltas", "ForbiddenForbiddenFragment", Item.buyPrice(0, 10), ref shop, ref nextSlot);

            //goblin summoner
            AddItem(FargoWorld.downedGoblinSummoner, "Fargowiltas", "ShadowflameIcon", Item.buyPrice(0, 10), ref shop, ref nextSlot);

            //pirate captain
            AddItem(FargoWorld.downedPirateCaptain, "Fargowiltas", "PirateFlag", Item.buyPrice(0, 10), ref shop, ref nextSlot);

            //flying dutchman
            AddItem(FargoWorld.downedFlyingDutchman, "Fargowiltas", "PlunderedBooty", Item.buyPrice(0, 15), ref shop, ref nextSlot);

            //mothron
            AddItem(FargoWorld.downedMothron, "Fargowiltas", "MothronEgg", Item.buyPrice(0, 15), ref shop, ref nextSlot);

            //bone lee
            AddItem(FargoWorld.downedBoneLee, "Fargowiltas", "LeesHeadband", Item.buyPrice(0, 15), ref shop, ref nextSlot);

            //paladin
            AddItem(FargoWorld.downedPaladin, "Fargowiltas", "GrandCross", Item.buyPrice(0, 15), ref shop, ref nextSlot);

            //skeleton gunners
            AddItem(FargoWorld.downedSkeletonGunAny, "Fargowiltas", "AmalgamatedSkull", Item.buyPrice(0, 30), ref shop, ref nextSlot);

            //skeleton mages
            AddItem(FargoWorld.downedSkeletonMageAny, "Fargowiltas", "AmalgamatedSpirit", Item.buyPrice(0, 30), ref shop, ref nextSlot);
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
