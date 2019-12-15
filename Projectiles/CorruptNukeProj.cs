using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Projectiles
{
    public class CorruptNukeProj : ModProjectile
    {
        public override string Texture => "Fargowiltas/Items/Renewals/CorruptRenewal";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Corrupt Nuke");
        }

        public override void SetDefaults()
        {
            projectile.width = 20;
            projectile.height = 20;
            projectile.aiStyle = 2;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 170;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return true;
        }

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.Shatter, projectile.Center);

            int radius = 100;
            float[] speedX = { 0, 0, 5, 5, 5, -5, -5, -5 };
            float[] speedY = { 5, -5, 0, 5, -5, 0, 5, -5 };

            for (int i = 0; i < 8; i++)
            {
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, speedX[i], speedY[i], ProjectileID.CorruptSpray, 0, 0, Main.myPlayer);
            }

            for (int x = -radius; x <= radius; x++)
            {
                for (int y = -radius; y <= radius; y++)
                {
                    int xPosition = (int)(x + projectile.Center.X / 16.0f);
                    int yPosition = (int)(y + projectile.Center.Y / 16.0f);

                    // Circle
                    if (Math.Sqrt(x * x + y * y) <= radius + 0.5)
                    {
                        WorldGen.Convert(xPosition, yPosition, 1, 1); // convert to corrupt
                    }
                }
            }
        }
    }
}