using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Projectiles
{
    public class HallowNukeProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hallow Nuke");
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

        public override string Texture
        {
            get
            {
                return "Fargowiltas/Items/Misc/HallowRenewal";
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return true;
        }

        public override void Kill(int timeLeft)
        {
            Vector2 position = projectile.Center;
            Main.PlaySound(SoundID.Shatter, (int)position.X, (int)position.Y);

            int radius = 100;
            float[] speedX = { 0, 0, 5, 5, 5, -5, -5, -5 };
            float[] speedY = { 5, -5, 0, 5, -5, 0, 5, -5 };

            for (int i = 0; i < 8; i++)
            {
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, speedX[i], speedY[i], ProjectileID.HallowSpray, 0, 0, Main.myPlayer);
            }

            for (int x = -radius; x <= radius; x++)
            {
                for (int y = -radius; y <= radius; y++)
                {
                    int xPosition = (int)(x + position.X / 16.0f);
                    int yPosition = (int)(y + position.Y / 16.0f);

                    if (Math.Sqrt(x * x + y * y) <= radius + 0.5)   //circle
                    {
                        WorldGen.Convert(xPosition, yPosition, 2, 1); // convert to hallow 
                    }
                }
            }
        }
    }
}