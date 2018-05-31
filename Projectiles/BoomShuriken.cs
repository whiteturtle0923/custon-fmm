using Terraria;
using Terraria.ModLoader;

namespace Fargowiltas.Projectiles
{
    public class BoomShuriken : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Boom Shuriken");
        }

        public override void SetDefaults()
        {
            projectile.width = 11;
            projectile.height = 11;
            projectile.friendly = true;
            projectile.thrown = true;
            projectile.penetrate = 5;
            projectile.aiStyle = 2;
            projectile.timeLeft = 150;
            aiType = 48;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            projectile.Kill();
        }

        public override void Kill(int timeLeft)
        {
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, projectile.velocity.X * 0, projectile.velocity.Y * 0, mod.ProjectileType("Explosion"), (int)(projectile.damage * 1f), projectile.knockBack, projectile.owner);
        }
    }
}