using Fargowiltas.Items.Explosives;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Fargowiltas.Projectiles.Explosives
{
    public class InstaHouseVisual : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 160;
            projectile.height = 96;
            projectile.timeLeft = 10;
            projectile.tileCollide = false;
        }

        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            Vector2 mouse = Main.MouseWorld;

            if (player.position.X > mouse.X)
            {
                projectile.position.X = mouse.X - projectile.width + 4;
                projectile.position.Y = mouse.Y - projectile.height + 8 + 16;
            }
            else
            {
                projectile.position.X = mouse.X - 4;
                projectile.position.Y = mouse.Y - projectile.height + 8 + 16;
            }

            projectile.timeLeft++;

            if (player.HeldItem.type != ModContent.ItemType<AutoHouse>())
            {
                projectile.Kill();
            }

            projectile.hide = projectile.owner != Main.myPlayer;
        }
    }
}