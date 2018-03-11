<<<<<<< HEAD
﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Projectiles
{
    public class GlaiveProj : ModProjectile
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Glaive");
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
            projectile.timeLeft = 600;
            aiType = 48;
        }

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			projectile.Kill();
		}
		
        
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return false;
        }
        
        public override void Kill(int timeLeft)
        {
        	Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0f, 0f, mod.ProjectileType("MiniRocketExplosion"), projectile.damage, projectile.knockBack, projectile.owner, 0f, 0f);
        	Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 14);
			projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
			projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
			projectile.width = 20;
			projectile.height = 20;
			projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
			projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
			
			 Vector2 position = projectile.Center;
            Main.PlaySound(SoundID.Item14, (int)position.X, (int)position.Y);
            int radius = 20;     //this is the explosion radius, the highter is the value the bigger is the explosion
 
            for (int x = -radius; x <= (radius); x++)
            {
                for (int y = -radius; y <= (radius); y++)
                {
                    int xPosition = (int)(x + position.X / 16.0f);
                    int yPosition = (int)(y + position.Y / 16.0f);
 
                    if ((x * x + y * y) <= radius)   //this make so the explosion radius is a circle
                    {
                        WorldGen.KillTile(xPosition, yPosition, false, false, false);  //this make the explosion destroy tiles  
                        Dust.NewDust(position, 22, 22, DustID.Smoke, 0.0f, 0.0f, 120, new Color(), 1f);  //this is the dust that will spawn after the explosion
                    }
                }
            }
			
			
			
			for (int num621 = 0; num621 < 40; num621++)
			{
				int num622 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 31, 0f, 0f, 100, default(Color), 2f);
				Main.dust[num622].velocity *= 3f;
				if (Main.rand.Next(2) == 0)
				{
					Main.dust[num622].scale = 0.5f;
					Main.dust[num622].fadeIn = 1f + (float)Main.rand.Next(10) * 0.1f;
				}
			}
			for (int num623 = 0; num623 < 70; num623++)
			{
				int num624 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, default(Color), 2f);
				Main.dust[num624].noGravity = true;
				Main.dust[num624].velocity *= 5f;
				num624 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, default(Color), 1.5f);
				Main.dust[num624].velocity *= 2f;
			}
			for (int num625 = 0; num625 < 3; num625++)
			{
				float scaleFactor10 = 0.33f;
				if (num625 == 1)
				{
					scaleFactor10 = 0.66f;
				}
				if (num625 == 2)
				{
					scaleFactor10 = 1f;
				}
				int num626 = Gore.NewGore(new Vector2(projectile.position.X + (float)(projectile.width / 2) - 24f, projectile.position.Y + (float)(projectile.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
				Main.gore[num626].velocity *= scaleFactor10;
				Gore expr_13AB6_cp_0 = Main.gore[num626];
				expr_13AB6_cp_0.velocity.X = expr_13AB6_cp_0.velocity.X + 1f;
				Gore expr_13AD6_cp_0 = Main.gore[num626];
				expr_13AD6_cp_0.velocity.Y = expr_13AD6_cp_0.velocity.Y + 1f;
				num626 = Gore.NewGore(new Vector2(projectile.position.X + (float)(projectile.width / 2) - 24f, projectile.position.Y + (float)(projectile.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
				Main.gore[num626].velocity *= scaleFactor10;
				Gore expr_13B79_cp_0 = Main.gore[num626];
				expr_13B79_cp_0.velocity.X = expr_13B79_cp_0.velocity.X - 1f;
				Gore expr_13B99_cp_0 = Main.gore[num626];
				expr_13B99_cp_0.velocity.Y = expr_13B99_cp_0.velocity.Y + 1f;
				num626 = Gore.NewGore(new Vector2(projectile.position.X + (float)(projectile.width / 2) - 24f, projectile.position.Y + (float)(projectile.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
				Main.gore[num626].velocity *= scaleFactor10;
				Gore expr_13C3C_cp_0 = Main.gore[num626];
				expr_13C3C_cp_0.velocity.X = expr_13C3C_cp_0.velocity.X + 1f;
				Gore expr_13C5C_cp_0 = Main.gore[num626];
				expr_13C5C_cp_0.velocity.Y = expr_13C5C_cp_0.velocity.Y - 1f;
				num626 = Gore.NewGore(new Vector2(projectile.position.X + (float)(projectile.width / 2) - 24f, projectile.position.Y + (float)(projectile.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
				Main.gore[num626].velocity *= scaleFactor10;
				Gore expr_13CFF_cp_0 = Main.gore[num626];
				expr_13CFF_cp_0.velocity.X = expr_13CFF_cp_0.velocity.X - 1f;
				Gore expr_13D1F_cp_0 = Main.gore[num626];
				expr_13D1F_cp_0.velocity.Y = expr_13D1F_cp_0.velocity.Y - 1f;
			}
			projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
			projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
			projectile.width = 8;
			projectile.height = 8;
			projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
			projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
        }
	   
    }
=======
﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Projectiles
{
    public class GlaiveProj : ModProjectile
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Glaive");
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
            projectile.timeLeft = 600;
            aiType = 48;
        }

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			projectile.Kill();
		}
		
        
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return false;
        }
        
        public override void Kill(int timeLeft)
        {
        	Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0f, 0f, mod.ProjectileType("MiniRocketExplosion"), projectile.damage, projectile.knockBack, projectile.owner, 0f, 0f);
        	Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 14);
			projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
			projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
			projectile.width = 20;
			projectile.height = 20;
			projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
			projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
			
			 Vector2 position = projectile.Center;
            Main.PlaySound(SoundID.Item14, (int)position.X, (int)position.Y);
            int radius = 20;     //this is the explosion radius, the highter is the value the bigger is the explosion
 
            for (int x = -radius; x <= (radius); x++)
            {
                for (int y = -radius; y <= (radius); y++)
                {
                    int xPosition = (int)(x + position.X / 16.0f);
                    int yPosition = (int)(y + position.Y / 16.0f);
 
                    if ((x * x + y * y) <= radius)   //this make so the explosion radius is a circle
                    {
                        WorldGen.KillTile(xPosition, yPosition, false, false, false);  //this make the explosion destroy tiles  
                        Dust.NewDust(position, 22, 22, DustID.Smoke, 0.0f, 0.0f, 120, new Color(), 1f);  //this is the dust that will spawn after the explosion
                    }
                }
            }
			
			
			
			for (int num621 = 0; num621 < 40; num621++)
			{
				int num622 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 31, 0f, 0f, 100, default(Color), 2f);
				Main.dust[num622].velocity *= 3f;
				if (Main.rand.Next(2) == 0)
				{
					Main.dust[num622].scale = 0.5f;
					Main.dust[num622].fadeIn = 1f + (float)Main.rand.Next(10) * 0.1f;
				}
			}
			for (int num623 = 0; num623 < 70; num623++)
			{
				int num624 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, default(Color), 2f);
				Main.dust[num624].noGravity = true;
				Main.dust[num624].velocity *= 5f;
				num624 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, default(Color), 1.5f);
				Main.dust[num624].velocity *= 2f;
			}
			for (int num625 = 0; num625 < 3; num625++)
			{
				float scaleFactor10 = 0.33f;
				if (num625 == 1)
				{
					scaleFactor10 = 0.66f;
				}
				if (num625 == 2)
				{
					scaleFactor10 = 1f;
				}
				int num626 = Gore.NewGore(new Vector2(projectile.position.X + (float)(projectile.width / 2) - 24f, projectile.position.Y + (float)(projectile.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
				Main.gore[num626].velocity *= scaleFactor10;
				Gore expr_13AB6_cp_0 = Main.gore[num626];
				expr_13AB6_cp_0.velocity.X = expr_13AB6_cp_0.velocity.X + 1f;
				Gore expr_13AD6_cp_0 = Main.gore[num626];
				expr_13AD6_cp_0.velocity.Y = expr_13AD6_cp_0.velocity.Y + 1f;
				num626 = Gore.NewGore(new Vector2(projectile.position.X + (float)(projectile.width / 2) - 24f, projectile.position.Y + (float)(projectile.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
				Main.gore[num626].velocity *= scaleFactor10;
				Gore expr_13B79_cp_0 = Main.gore[num626];
				expr_13B79_cp_0.velocity.X = expr_13B79_cp_0.velocity.X - 1f;
				Gore expr_13B99_cp_0 = Main.gore[num626];
				expr_13B99_cp_0.velocity.Y = expr_13B99_cp_0.velocity.Y + 1f;
				num626 = Gore.NewGore(new Vector2(projectile.position.X + (float)(projectile.width / 2) - 24f, projectile.position.Y + (float)(projectile.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
				Main.gore[num626].velocity *= scaleFactor10;
				Gore expr_13C3C_cp_0 = Main.gore[num626];
				expr_13C3C_cp_0.velocity.X = expr_13C3C_cp_0.velocity.X + 1f;
				Gore expr_13C5C_cp_0 = Main.gore[num626];
				expr_13C5C_cp_0.velocity.Y = expr_13C5C_cp_0.velocity.Y - 1f;
				num626 = Gore.NewGore(new Vector2(projectile.position.X + (float)(projectile.width / 2) - 24f, projectile.position.Y + (float)(projectile.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
				Main.gore[num626].velocity *= scaleFactor10;
				Gore expr_13CFF_cp_0 = Main.gore[num626];
				expr_13CFF_cp_0.velocity.X = expr_13CFF_cp_0.velocity.X - 1f;
				Gore expr_13D1F_cp_0 = Main.gore[num626];
				expr_13D1F_cp_0.velocity.Y = expr_13D1F_cp_0.velocity.Y - 1f;
			}
			projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
			projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
			projectile.width = 8;
			projectile.height = 8;
			projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
			projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
        }
	   
    }
>>>>>>> 66ed39caf4938fca8e7009752b635e42f8a8a58f
}