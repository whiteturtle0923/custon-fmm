using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

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
            //projectile.scale = 0.75f;
            projectile.friendly = true;
            projectile.thrown = true;
            projectile.penetrate = 5;
            projectile.aiStyle = 2;
			
            projectile.timeLeft = 150;
            aiType = 48;
			//aiType = ProjectileID.Grenade;
        }

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			projectile.Kill();
		}
		
        
        public override void Kill(int timeLeft)
        {
			Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 14);
			projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
			projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
			projectile.width = 100;
			projectile.height = 100;
			projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
			projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
			for (int num615 = 0; num615 < 30; num615++)
			{
				int num616 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 31, 0f, 0f, 100, default(Color), 1.5f);
				Main.dust[num616].velocity *= 1.4f;
			}
			for (int num617 = 0; num617 < 20; num617++)
			{
				int num618 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, default(Color), 3.5f);
				Main.dust[num618].noGravity = true;
				Main.dust[num618].velocity *= 7f;
				num618 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, default(Color), 1.5f);
				Main.dust[num618].velocity *= 3f;
			}
			for (int num619 = 0; num619 < 2; num619++)
			{
				float scaleFactor9 = 0.4f;
				if (num619 == 1)
				{
					scaleFactor9 = 0.8f;
				}
				int num620 = Gore.NewGore(new Vector2(projectile.position.X, projectile.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
				Main.gore[num620].velocity *= scaleFactor9;
				Gore gore97 = Main.gore[num620];
				gore97.velocity.X = gore97.velocity.X + 1f;
				Gore gore98 = Main.gore[num620];
				gore98.velocity.Y = gore98.velocity.Y + 1f;
				num620 = Gore.NewGore(new Vector2(projectile.position.X, projectile.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
				Main.gore[num620].velocity *= scaleFactor9;
				Gore gore99 = Main.gore[num620];
				gore99.velocity.X = gore99.velocity.X - 1f;
				Gore gore100 = Main.gore[num620];
				gore100.velocity.Y = gore100.velocity.Y + 1f;
				num620 = Gore.NewGore(new Vector2(projectile.position.X, projectile.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
				Main.gore[num620].velocity *= scaleFactor9;
				Gore gore101 = Main.gore[num620];
				gore101.velocity.X = gore101.velocity.X + 1f;
				Gore gore102 = Main.gore[num620];
				gore102.velocity.Y = gore102.velocity.Y - 1f;
				num620 = Gore.NewGore(new Vector2(projectile.position.X, projectile.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
				Main.gore[num620].velocity *= scaleFactor9;
				Gore gore103 = Main.gore[num620];
				gore103.velocity.X = gore103.velocity.X - 1f;
				Gore gore104 = Main.gore[num620];
				gore104.velocity.Y = gore104.velocity.Y - 1f;
			}
			
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, projectile.velocity.X * 0, projectile.velocity.Y * 0, mod.ProjectileType("BoomShurikenExplosion"), (int)(projectile.damage * 1f), projectile.knockBack, projectile.owner);
        }
	   
    }
}