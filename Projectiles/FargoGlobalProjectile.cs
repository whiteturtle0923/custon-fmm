using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Projectiles
{
    public class FargoGlobalProjectile : GlobalProjectile
    {
        public override bool InstancePerEntity
        {
            get
            {
                return true;
            }
        }

        public override void SetDefaults(Projectile projectile)
        {
            if (projectile.type == ProjectileID.BoneJavelin || projectile.type == ProjectileID.JavelinFriendly)
            {
                projectile.thrown = true;
            }
        }
    }
}