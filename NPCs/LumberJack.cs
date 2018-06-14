using Microsoft.Xna.Framework;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.NPCs
{
    [AutoloadHead]
    public class LumberJack : ModNPC
    {
        public bool dayOver;
        public bool nightOver;
        public int woodAmount = 100;

        public override bool Autoload(ref string name)
        {
            name = "LumberJack";
            return mod.Properties.Autoload;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("LumberJack");
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
            npc.catchItem = (short)mod.ItemType("LumberJack");
        }

        public bool SacredToolsDownedSerpent => SacredTools.ModdedWorld.FlariumSpawns;

        public override bool CanTownNPCSpawn(int numTownnpcs, int money)
        {
            return FargoWorld.movedLumberjack || Main.player.Where(player => player.active).Any(player => player.inventory.Any(t => t.type == mod.ItemType("WoodenToken")));
        }

        public override void AI()
        {
            if (!Main.dayTime)
            {
                nightOver = true;
            }
            if (Main.dayTime)
            {
                dayOver = true;
            }
        }

        public override string TownNPCName()
        {
            switch (WorldGen.genRand.Next(5))
            {
                case 0:
                    return "Griff";
                case 1:
                    return "Jack";
                case 2:
                    return "Bruce";
                case 3:
                    return "Larry";
                default:
                    return "Paul";
            }
        }

        public override string GetChat()
        {
            int dryad = NPC.FindFirstNPC(NPCID.Dryad);

            if (dryad >= 0 && Main.rand.Next(10) == 0)
            {
                return Main.npc[dryad].GivenName + " told me to start hugging trees... I hug trees with my chainsaw.";
            }

            switch (Main.rand.Next(9))
            {
                case 0:
                    return "Dynasty wood? Between you and me, that stuff ain't real wood!";
                case 1:
                    return "Sure cactus isn't wood, but I can still chop it with me trusty axe.";
                case 2:
                    return "You wouldn't by chance have any fantasies about me... right?";
                case 3:
                    return "I eat a bowl of woodchips for breakfast... without any milk.";
                case 4:
                    return "TIIIIIIIIIMMMBEEEEEEEERRR!";
                case 5:
                    return "I'm a lumberjack and I'm okay, I sleep all night and I work all day!";
                case 6:
                    return "You won't ever need an axe again with me around.";
                case 7:
                    return "I have heard of people cutting trees with fish, who does that?";
                default:
                    return "It's always flannel season.";
            }
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = Lang.inter[28].Value;
            button2 = "Free Wood";
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            Player player = Main.player[Main.myPlayer];
            FargoPlayer p = player.GetModPlayer<FargoPlayer>(mod);

            if (firstButton)
            {
                shop = true;
            }

            if (firstButton) return;
            if (dayOver && nightOver)
            {
                Main.npcChatText = "Here you go. I'm glad my wood put such a big smile on your face.";

                if (NPC.downedBoss1)
                {
                    woodAmount = 200;
                }
                if (Main.hardMode)
                {
                    woodAmount = 500;
                }

                player.QuickSpawnItem(ItemID.Wood, woodAmount);
                dayOver = false;
                nightOver = false;
            }
            else
            {
                Main.npcChatText = "The trees need time to regrow, come back later for more wood.";
            }
        }

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            shop.item[nextSlot].SetDefaults(ItemID.Wood);
            shop.item[nextSlot].value = 10;
            nextSlot++;

            shop.item[nextSlot].SetDefaults(ItemID.BorealWood);
            shop.item[nextSlot].value = 10;
            nextSlot++;

            shop.item[nextSlot].SetDefaults(ItemID.RichMahogany);
            shop.item[nextSlot].value = 15;
            nextSlot++;

            shop.item[nextSlot].SetDefaults(ItemID.PalmWood);
            shop.item[nextSlot].value = 15;
            nextSlot++;

            shop.item[nextSlot].SetDefaults(ItemID.Ebonwood);
            shop.item[nextSlot].value = 15;
            nextSlot++;

            shop.item[nextSlot].SetDefaults(ItemID.Shadewood);
            shop.item[nextSlot].value = 15;
            nextSlot++;

            if (Fargowiltas.instance.tremorLoaded)
            {
                shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("GlacierWood"));
                shop.item[nextSlot].value = 15;
                nextSlot++;
            }

            if (Fargowiltas.instance.crystiliumLoaded)
            {
                shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CrystiliumMod").ItemType("CrystalWood"));
                shop.item[nextSlot].value = 20;
                nextSlot++;
            }

            if (ModLoader.GetLoadedMods().Contains("CosmeticVariety") && (NPC.downedBoss2))
            {
                shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CosmeticVariety").ItemType("Starwood"));
                shop.item[nextSlot].value = 20;
                nextSlot++;
            }

            shop.item[nextSlot].SetDefaults(ItemID.Pearlwood);
            shop.item[nextSlot].value = 20;
            nextSlot++;

            if (NPC.downedHalloweenKing)
            {
                shop.item[nextSlot].SetDefaults(ItemID.SpookyWood);
                shop.item[nextSlot].value = 50;
                nextSlot++;
            }

            if (Fargowiltas.instance.sacredToolsLoaded)
            {
                if (SacredToolsDownedSerpent)
                {
                    shop.item[nextSlot].SetDefaults(ModLoader.GetMod("SacredTools").ItemType("FlameWood"));
                    shop.item[nextSlot].value = 2000;
                    nextSlot++;
                }
            }

            shop.item[nextSlot].SetDefaults(ItemID.Cactus);
            shop.item[nextSlot].value = 10;
            nextSlot++;

            shop.item[nextSlot].SetDefaults(mod.ItemType("LumberJaxe"));
            shop.item[nextSlot].value = 10000;
            nextSlot++;
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
            projType = mod.ProjectileType("LumberJaxe");
            attackDelay = 1;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 12f;
            randomOffset = 2f;
        }

        public override void NPCLoot()
        {
            FargoWorld.movedLumberjack = true;
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
                    Gore.NewGore(pos, npc.velocity, mod.GetGoreSlot("Gores/LumberGore3"));
                }
                for (int k = 0; k < 1; k++)
                {
                    Vector2 pos = npc.position + new Vector2(Main.rand.Next(npc.width - 8), Main.rand.Next(npc.height / 2));
                    Gore.NewGore(pos, npc.velocity, mod.GetGoreSlot("Gores/LumberGore2"));
                }
                for (int k = 0; k < 1; k++)
                {
                    Vector2 pos = npc.position + new Vector2(Main.rand.Next(npc.width - 8), Main.rand.Next(npc.height / 2));
                    Gore.NewGore(pos, npc.velocity, mod.GetGoreSlot("Gores/LumberGore1"));
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