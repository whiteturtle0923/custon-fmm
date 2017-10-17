using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Projectiles
{
	class DicerProjectile2 : ModProjectile
	{
		public int counter = 1;

		public override void SetDefaults()
		{
			projectile.extraUpdates = 0;
			projectile.width = 19;
			projectile.height = 19;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.melee = true;
			projectile.scale = 1f;
			projectile.timeLeft = 90;
		}
		
		public override void AI()
		{
			if(counter >= 75)
			{
				projectile.scale += .1f;
				projectile.rotation += 0.2f;

			}
			
			counter++;
		}
		
		public override void Kill(int timeLeft)
        {
				int proj2 = 484;//374;
				
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0f, 5f, proj2, (int)(projectile.damage * 0.5f), 2/*kb*/, Main.myPlayer, 0f, 0f);
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 5f, 0f, proj2, (int)(projectile.damage * 0.5f), 2, Main.myPlayer, 0f, 0f);
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0f, -5f, proj2, (int)(projectile.damage * 0.5f), 2, Main.myPlayer, 0f, 0f);
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -5f, 0f, proj2, (int)(projectile.damage * 0.5f), 2, Main.myPlayer, 0f, 0f);
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 4f, 4f, proj2, (int)(projectile.damage * 0.5f), 2, Main.myPlayer, 0f, 0f);
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -4f, -4f, proj2, (int)(projectile.damage * 0.5f), 2, Main.myPlayer, 0f, 0f);
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 4f, -4f, proj2, (int)(projectile.damage * 0.5f), 2, Main.myPlayer, 0f, 0f);
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -4f, 4f, proj2, (int)(projectile.damage * 0.5f), 2, Main.myPlayer, 0f, 0f);
		}
		
		public override void PostAI()
		{
			/*if (Main.rand.Next(2) == 0)
			{
				int dustIndex = Dust.NewDust(projectile.position, projectile.width, projectile.height, 16, 0f, 0f, 0, default(Color), 1f);
				Main.dust[dustIndex].noGravity = true;
				Main.dust[dustIndex].scale = 1.6f;
			}*/
		}
	}
}
