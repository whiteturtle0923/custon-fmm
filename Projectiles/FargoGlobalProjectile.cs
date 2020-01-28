using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

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
            if (projectile.type == ProjectileID.FlyingPiggyBank && GetInstance<FargoConfig>().StalkerMoneyTrough)
            {
                Player player = Main.player[projectile.owner];
                float dist = Vector2.Distance(projectile.Center, player.Center);

                if (dist > 2000)
                {
                    projectile.Kill();
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