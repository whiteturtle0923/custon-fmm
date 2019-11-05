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

        public override bool CanTownNPCSpawn(int numTownnpcs, int money)
        {
            return FargoWorld.downedRareEnemy || NPC.AnyNPCs(mod.NPCType("Mutant"));
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
            if (Main.rand.Next(25) == 0)
                return "What's that? You want to fight me? ...nah, I can't put up a good fight on my own.";

            if (Main.bloodMoon && Main.rand.Next(2) == 0)
                return "The blood moon's effects? I'm not exactly human, so...";

            IList<string> dialogue = new List<string>();

            int mutant = NPC.FindFirstNPC(mod.NPCType("Mutant"));
            if (mutant != -1)
            {
                dialogue.Add("Can you help me tell " + Main.npc[mutant].GivenName + "to put some clothes on?");
                dialogue.Add("One day, I'll sell a summon for myself! ...Just kidding. That'd be " + Main.npc[mutant].GivenName + "'s job.");
                dialogue.Add(Main.npc[mutant].GivenName + " is here! That's my big brother!");
            }

            int abom = NPC.FindFirstNPC(mod.NPCType("Abominationn"));
            if (abom != -1)
            {
                if (Fargowiltas.instance.fargoLoaded && MasochistMode && Main.rand.Next(5) == 0)
                    return "You made a good choice with this world! Don't forget to chat with " + Main.npc[abom].GivenName + " if you need any tips!";

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
                dialogue.Add("Embrace suffering... and while you're at it, why not embrace another purchase?");

            dialogue.Add("Did you know? The only real music genres are death metal and artcore.");
            dialogue.Add("I'll have you know I'm over a hundred Fargo years old! Don't ask me how long a Fargo year is.");
            dialogue.Add("I might be able to afford a taller body if you keep buying!");
            dialogue.Add("Where's that screm cat?");
            dialogue.Add(Main.player[Main.myPlayer].name + "! I saw something rodent-y just now! You don't a hamster infestation here, right? Right!?");
            dialogue.Add("You're the Terrarian? Honestly, I was expecting someone a little... taller.");
            dialogue.Add("Don't look at me like that! The only thing I've deviated from is my humanity.");
            dialogue.Add("Rip and tear and buy from me for more things to rip and tear!");
            dialogue.Add("What's a chee-bee doe-goe?");
            dialogue.Add("Wait a second. Are you sure this house isn't what they call 'prison?'");
            dialogue.Add("Deviantt has awoken! Quick, give her all your money to defeat her!");
            dialogue.Add("One day, I'll sell a summon for myself! ...Just kidding.");

            return dialogue[Main.rand.Next(dialogue.Count)];
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
            //pinky
            AddItem(true, "Fargowiltas", "PinkSlimeCrown", Item.buyPrice(0, 5), ref shop, ref nextSlot);

            //undead miner
            AddItem(FargoWorld.downedUndeadMiner, "Fargowiltas", "AttractiveOre", Item.buyPrice(0, 3), ref shop, ref nextSlot);

            //tim
            AddItem(FargoWorld.downedTim, "Fargowiltas", "HolyGrail", Item.buyPrice(0, 5), ref shop, ref nextSlot);

            //doctor bones
            AddItem(FargoWorld.downedDoctorBones, "Fargowiltas", "GoldArtifact", Item.buyPrice(0, 2), ref shop, ref nextSlot);

            //mimics
            AddItem(FargoWorld.downedMimic, "Fargowiltas", "SuspiciousLookingChest", Item.buyPrice(0, 20), ref shop, ref nextSlot);

            //wyvern
            AddItem(FargoWorld.downedWyvern, "Fargowiltas", "CloudSnack", Item.buyPrice(0, 10), ref shop, ref nextSlot);

            //rune wizard
            AddItem(FargoWorld.downedRuneWizard, "Fargowiltas", "WizardHatofLegend", Item.buyPrice(0, 15), ref shop, ref nextSlot);

            //nymph
            AddItem(FargoWorld.downedNymph, "Fargowiltas", "HeartChocolate", Item.buyPrice(0, 10), ref shop, ref nextSlot);

            //moth
            AddItem(FargoWorld.downedMoth, "Fargowiltas", "SupremeMothDust", Item.buyPrice(0, 10), ref shop, ref nextSlot);

            //rainbow slime
            AddItem(FargoWorld.downedRainbowSlime, "Fargowiltas", "DilutedRainbowMatter", Item.buyPrice(0, 10), ref shop, ref nextSlot);

            //paladin
            AddItem(FargoWorld.downedPaladin, "Fargowiltas", "GrandCross", Item.buyPrice(0, 15), ref shop, ref nextSlot);

            //medusa
            AddItem(FargoWorld.downedMedusa, "Fargowiltas", "AthenianIdol", Item.buyPrice(0, 5), ref shop, ref nextSlot);

            //clown
            AddItem(FargoWorld.downedClown, "Fargowiltas", "ClownShoe", Item.buyPrice(0, 5), ref shop, ref nextSlot);

            //ice golem
            AddItem(FargoWorld.downedIceGolem, "Fargowiltas", "CoreoftheFrostCore", Item.buyPrice(0, 10), ref shop, ref nextSlot);

            //sand elemental
            AddItem(FargoWorld.downedSandElemental, "Fargowiltas", "ForbiddenForbiddenFragment", Item.buyPrice(0, 10), ref shop, ref nextSlot);

            //mothron
            AddItem(FargoWorld.downedMothron, "Fargowiltas", "MothronEgg", Item.buyPrice(0, 15), ref shop, ref nextSlot);

            //hallow mimic
            AddItem(FargoWorld.downedMimicHallow, "Fargowiltas", "HallowChest", Item.buyPrice(0, 25), ref shop, ref nextSlot);

            //corrupt mimic
            AddItem(FargoWorld.downedMimicCorrupt, "Fargowiltas", "CorruptChest", Item.buyPrice(0, 25), ref shop, ref nextSlot);

            //crimson mimic
            AddItem(FargoWorld.downedMimicCrimson, "Fargowiltas", "CrimsonChest", Item.buyPrice(0, 25), ref shop, ref nextSlot);

            //jungle mimic
            AddItem(FargoWorld.downedMimicJungle, "Fargowiltas", "JungleChest", Item.buyPrice(0, 25), ref shop, ref nextSlot);

            //goblin summoner
            AddItem(FargoWorld.downedGoblinSummoner, "Fargowiltas", "ShadowflameIcon", Item.buyPrice(0, 10), ref shop, ref nextSlot);

            //flying dutchman
            AddItem(FargoWorld.downedFlyingDutchman, "Fargowiltas", "PlunderedBooty", Item.buyPrice(0, 10), ref shop, ref nextSlot);
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
