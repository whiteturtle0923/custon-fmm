using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Projectiles
{
    public class PhantasmalEyeProjectile : ModProjectile
    {
        private float HomingCooldown
        {
            get => Projectile.ai[0];
            set => Projectile.ai[0] = value;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("PhantasmalEyeProjectile");
        }

        public override void SetDefaults()
        {
            Projectile.width = 9;
            Projectile.height = 16;
            Projectile.aiStyle = 1;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.penetrate = 50;
            Projectile.timeLeft = 600;
            AIType = ProjectileID.Bullet;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Ichor, 240, true);
            target.AddBuff(BuffID.CursedInferno, 240, true);
            target.AddBuff(BuffID.Confused, 120, true);
            target.AddBuff(BuffID.Venom, 240, true);
            target.AddBuff(BuffID.ShadowFlame, 240, true);
            target.AddBuff(BuffID.OnFire, 240, true);
            target.AddBuff(BuffID.Frostburn, 240, true);
        }

        public override void AI()
        {
            const int homingDelay = 10;
            const float flySpeed = 60; // fly speed in pixels per frame
            const int lerpFrameAmount = 20; // minimum of 1

            HomingCooldown++;
            if (HomingCooldown > homingDelay)
            {
                HomingCooldown = homingDelay; // cap this value

                int foundTarget = HomeOnTarget();
                if (foundTarget != -1)
                {
                    NPC n = Main.npc[foundTarget];
                    Vector2 desiredVelocity = Projectile.DirectionTo(n.Center) * flySpeed;
                    Projectile.velocity = Vector2.Lerp(Projectile.velocity, desiredVelocity, 1f / lerpFrameAmount);
                }
            }
        }

        public override void Kill(int timeLeft)
        {
            for (int num468 = 0; num468 < 20; num468++)
            {
                int num469 = Dust.NewDust(new Vector2(Projectile.Center.X, Projectile.Center.Y), Projectile.width, Projectile.height, DustID.BlueCrystalShard, -Projectile.velocity.X * 0.2f, -Projectile.velocity.Y * 0.2f, 100, default, 1.5f);
                Main.dust[num469].noGravity = true;
                Main.dust[num469].velocity *= 2f;
                num469 = Dust.NewDust(new Vector2(Projectile.Center.X, Projectile.Center.Y), Projectile.width, Projectile.height, DustID.BlueCrystalShard, -Projectile.velocity.X * 0.2f, -Projectile.velocity.Y * 0.2f, 100, default, .75f);
                Main.dust[num469].velocity *= 2f;
            }
        }

        private int HomeOnTarget()
        {
            const bool HOMING_CAN_AIM_AT_WET_ENEMIES = true;
            const float HOMING_MAXIMUM_RANGE_IN_PIXELS = 1000;

            int selectedTarget = -1;
            for (int i = 0; i < Main.maxNPCs; i++)
            {
                NPC n = Main.npc[i];
                if (n.CanBeChasedBy(Projectile) && (!n.wet || HOMING_CAN_AIM_AT_WET_ENEMIES))
                {
                    float distance = Projectile.Distance(n.Center);
                    if (distance <= HOMING_MAXIMUM_RANGE_IN_PIXELS && (selectedTarget == -1 || Projectile.Distance(Main.npc[selectedTarget].Center) > distance))
                    {
                        selectedTarget = i;
                    }
                }
            }

            return selectedTarget;
        }
    }
}