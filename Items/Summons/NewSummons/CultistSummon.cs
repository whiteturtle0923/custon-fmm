using Fargowiltas.NPCs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.NewSummons
{
    public class CultistSummon : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Zealot's Possession");
            Tooltip.SetDefault("Summons the Lunatic Cultist");
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
            Vector2 pos = new Vector2((int)player.position.X + Main.rand.Next(-800, 800), (int)player.position.Y + Main.rand.Next(-1000, -250));

            Projectile.NewProjectile(pos, Vector2.Zero, type, 0, 0, Main.myPlayer, NPCID.CultistBoss, 1);

            if (Main.netMode == 2)
            {
                NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("Lunatic Cultist has awoken!"), new Color(175, 75, 255));
            }
            else
            {
                Main.NewText("Lunatic Cultist has awoken!", 175, 75, 255);

            }

            Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
            return true;
        }
    }
}