using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.NewSummons
{
    public class PillarSummon : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Outsider's Portal");
            Tooltip.SetDefault("Summons the Celestial Pillars");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 20;
            item.value = 1000;
            item.rare = 9;
            item.useAnimation = 30;
            item.useTime = 30;
            item.useStyle = 4;
            item.consumable = true;
            item.shoot = mod.ProjectileType("SpawnProj");
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int[] pillars = new int[] { NPCID.LunarTowerNebula, NPCID.LunarTowerSolar, NPCID.LunarTowerStardust, NPCID.LunarTowerVortex };

            for (int i = 0; i < pillars.Length; i++)
            {
                Vector2 pos = new Vector2((int)player.position.X + (400 * i) - 600, (int)player.position.Y - 200);

                Projectile.NewProjectile(pos, Vector2.Zero, type, 0, 0, Main.myPlayer, pillars[i]);
            }

            if (Main.netMode == 2)
            {
                NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("The Celestial Pillars have awoken!"), new Color(175, 75, 255));
            }
            else
            {
                Main.NewText("The Celestial Pillars have awoken!", 175, 75, 255);
            }

            Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
            return true;
        }
    }
}