using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Projectiles
{
    public class FargoGlobalProjectile : GlobalProjectile
    {
        public override bool InstancePerEntity => true;

        public override void SetDefaults(Projectile projectile)
        {
            if (projectile.type == ProjectileID.BoneJavelin || projectile.type == ProjectileID.JavelinFriendly)
            {
                projectile.thrown = true;
            }
        }

        public override bool PreAI(Projectile projectile)
        {
            if (projectile.type == ProjectileID.FlyingPiggyBank)
            {
                Player player = Main.player[projectile.owner];
                float dist = Vector2.Distance(projectile.Center, player.Center);

                if (dist > 1000)
                {
                    projectile.position = player.position;
                }
                else if (dist > 100)
                {
                    Vector2 velocity = Vector2.Normalize(player.Center - projectile.Center) * 3;
                    projectile.position += velocity;
                }
            }

            return true;
        }
    }
}