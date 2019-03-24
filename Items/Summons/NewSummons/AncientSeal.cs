using Fargowiltas.NPCs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.NewSummons
{
    public class AncientSeal : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ancient Seal");
            Tooltip.SetDefault("Summons ALL the bosses modded included \n'Use at your own risk'");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 20;
            item.value = 1000;
            item.rare = 11;
            item.useAnimation = 30;
            item.useTime = 30;
            item.useStyle = 4;
            item.consumable = true;
            item.shoot = mod.ProjectileType("SpawnProj");
        }

        public override bool CanUseItem(Player player)
        {
            return Main.dayTime != true;
        }

        public bool SacredToolsDownedLunarians => SacredTools.ModdedWorld.downedLunarians;

        private readonly string[] SacredToolsBosses = 
        {
            "HarpyBoss",
            "ArmoredHarpy",
            "ShadowWrath",
            "StardustLunarian",
            "VortexLunarian",
            "SolarLunarian"
        };

        private readonly string[] ThoriumBosses =
        {
            "TheGrandThunderBird",
            "QueenJellyDiverless",
            "GraniteEnergyStorm",
            "TheBuriedWarrior",
            "ThePrimeScouter",
            "BoreanStrider",
            "FallenDeathBeholder",
            "Lich",
            "Abyssion",
            "Aquaius",
            "Omnicide",
            "SlagFury",
        };

        private readonly string[] CalamityBosses =
        {
            "HiveMind",
            "PerforatorHive",
            "SlimeGod",
            "SlimeGodRun",
            "SlimeGodCore",
            "Cryogen",
            "BrimstoneElemental",
            "Calamitas",
            "Siren",
            "Leviathan",
            "PlaguebringerGoliath",
            "ProfanedGuardianBoss",
            "ProfanedGuardianBoss2",
            "ProfanedGuardianBoss3",
            "Providence",
            "CeaselessVoid",
            "CosmicWraith",
            "Bumblefuck",
            "Yharon",
        };

        private readonly string[] SpiritBosses =
        {
            "Scarabeus",
            "AncientFlyer",
            "Infernon",
            "Dusking",
            "IlluminantMaster",
            "Scarabeus",
            "Atlas",
            "Overseer",
        };

        private readonly string[] PumpkingBosses =
        {
            "PumpkingHorseman",
            "TerraLord",
            "TerraGuard",
        };

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 pos = new Vector2((int)player.position.X + Main.rand.Next(-800, 800), (int)player.position.Y + Main.rand.Next(-1000, -250));
            Projectile.NewProjectile(pos, Vector2.Zero, mod.ProjectileType("SpawnProj"), 0, 0, Main.myPlayer, 1, 3);

            //other mods
            if (Fargowiltas.instance.sacredToolsLoaded)
            {
                foreach (string i in SacredToolsBosses)
                {
                    NPC.SpawnOnPlayer(player.whoAmI, ModLoader.GetMod("SacredTools").NPCType(i));
                }
                NPC.SpawnOnPlayer(player.whoAmI,
                    SacredToolsDownedLunarians
                        ? ModLoader.GetMod("SacredTools").NPCType("NebulaLunarian")
                        : ModLoader.GetMod("SacredTools").NPCType("ShadowLunarian"));
            }

            if (Fargowiltas.instance.pumpkingLoaded)
            {
                foreach (string i in PumpkingBosses)
                    NPC.SpawnOnPlayer(player.whoAmI, ModLoader.GetMod("Pumpking").NPCType(i));

            }

            if (Fargowiltas.instance.crystiliumLoaded)
            {
                NPC.SpawnOnPlayer(player.whoAmI, ModLoader.GetMod("CrystiliumMod").NPCType("CrystalKing"));
            }

            if (Fargowiltas.instance.thoriumLoaded)
            {
                foreach (string i in ThoriumBosses)
                    NPC.SpawnOnPlayer(player.whoAmI, ModLoader.GetMod("ThoriumMod").NPCType(i));
                player.AddBuff(ModLoader.GetMod("ThoriumMod").BuffType("TouchOfOmnicide"), 14400);
            }

            if (Fargowiltas.instance.calamityLoaded)
            {
                foreach (string i in CalamityBosses)
                    NPC.SpawnOnPlayer(player.whoAmI, ModLoader.GetMod("CalamityMod").NPCType(i));
            }

            if (Fargowiltas.instance.spiritLoaded)
            {
                foreach (string i in SpiritBosses)
                    NPC.SpawnOnPlayer(player.whoAmI, ModLoader.GetMod("SpiritMod").NPCType(i));
            }

            Main.NewText("Several bosses have awoken!", 175, 75, 255);

            Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
            return true;
        }

        public int SpawnBoss(Player player, int NPCID, string name)
        {
            int i = NPC.NewNPC((int)player.position.X + Main.rand.Next(-800, 800), (int)player.position.Y + Main.rand.Next(-1000, -250), NPCID);
            Main.NewText($"{name} has awoken!", 175, 75);
            return i;
        }
        
        public int SpawnBossAtOffset(Player player, int NPCID, string name, int offset)
        {
            int i = NPC.NewNPC((int)player.position.X, (int)player.position.Y + offset, NPCID);
            Main.NewText($"{name} has awoken!", 175, 75);
            //NetMessage.SendData(23, -1, -1, null, NPCID, 0f, 0f, 0f, 0);
            return i;
        }
    }
}