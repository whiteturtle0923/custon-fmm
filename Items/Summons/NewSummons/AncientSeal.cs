using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
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

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 pos = new Vector2((int)player.position.X + Main.rand.Next(-800, 800), (int)player.position.Y + Main.rand.Next(-1000, -250));
            //all vanilla here
            Projectile.NewProjectile(pos, Vector2.Zero, mod.ProjectileType("SpawnProj"), 0, 0, Main.myPlayer, 1, 3);

            //max vanilla id is 579, update for 1.4 ech

            //all modded here
            for (int i = 580; i < NPCLoader.NPCCount; i++)
            {
                NPC npc = new NPC();
                npc.SetDefaults(i);

                if (npc.boss)
                {
                    SpawnBoss(player, i, npc.TypeName);
                }
            }

            if (Main.netMode == 2)
            {
                NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("Every boss has awoken!"), new Color(175, 75, 255));
            }
            else
            {
                Main.NewText("Every boss has awoken!", 175, 75, 255);

            }

            Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
            return true;
        }

        public int SpawnBoss(Player player, int NPCID, string name)
        {
            int i = NPC.NewNPC((int)player.position.X + Main.rand.Next(-800, 800), (int)player.position.Y + Main.rand.Next(-1000, -250), NPCID);
            Main.NewText($"{name} has awoken!", 175, 75);
            return i;
        }
    }
}