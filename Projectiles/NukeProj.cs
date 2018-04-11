using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace Fargowiltas.Projectiles
{
    public class NukeProj : ModProjectile
    {
		public int countdown = 4;
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nukem");
		}
        public override void SetDefaults()
        {
            projectile.width = 10;   //This defines the hitbox width
            projectile.height = 32;    //This defines the hitbox height
            projectile.aiStyle = 16;  //How the projectile works, 16 is the aistyle Used for: Grenades, Dynamite, Bombs, Sticky Bomb.
            projectile.friendly = true; //Tells the game whether it is friendly to players/friendly npcs or not
            projectile.penetrate = -1; //Tells the game how many enemies it can hit before being destroyed
            projectile.timeLeft = 800; //The amount of time the projectile is alive for
			Main.projFrames[projectile.type] = 4;
        }
		
		public override void AI()
		{
			if(projectile.timeLeft % 200 == 0)
			{
				Main.NewText(countdown.ToString(), 51, 102, 0);
				countdown--;
			}
		}
 
		public override bool PreDraw(SpriteBatch sb, Color lightColor)
		{
             projectile.frameCounter++;   //Making the timer go up.
            if (projectile.frameCounter >= 200)  //how fast animation is
            {
                projectile.frame++; //Making the frame go up...
                projectile.frameCounter = 0; //Resetting the timer.
                if (projectile.frame > 3) //amt of frames - 1
                    projectile.frame = 0;
            }
            return true;

		} 
 
        public override void Kill(int timeLeft)
        {
 
            Vector2 position = projectile.Center;
            //Main.PlaySound(SoundID.Item14, (int)position.X, (int)position.Y);
            int radius = 300;     //bigger = boomer
 
            for (int x = -radius; x <= radius; x++)
            {
                for (int y = -radius; y <= radius; y++)
                {
                    int xPosition = (int)(x + position.X / 16.0f);
                    int yPosition = (int)(y + position.Y / 16.0f);
 
                    if (Math.Sqrt(x * x + y * y) <= radius + 0.5)   //change the shape
                    {
                        WorldGen.KillTile(xPosition, yPosition, false, false, false);  //tile ded
						WorldGen.KillWall(xPosition, yPosition);
						
						Tile tile = Main.tile[xPosition, yPosition];
					
						if(tile != null)
						{
							tile.liquid = 0;
							tile.lava(false);
							tile.honey(false);
							if (Main.netMode == 2)
							{
								NetMessage.sendWater(xPosition, yPosition);
							}
						}
                    }
                }
            }
			
			// Play explosion sound
			Main.PlaySound(SoundID.Item15, projectile.position);
			/*// Smoke Dust spawn
			for (int i = 0; i < 50; i++)
			{
				int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 31, 0f, 0f, 100, default(Color), 2f);
				Main.dust[dustIndex].velocity *= 1.4f;
			}
			// Fire Dust spawn
			for (int i = 0; i < 80; i++)
			{
				int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, default(Color), 3f);
				Main.dust[dustIndex].noGravity = true;
				Main.dust[dustIndex].velocity *= 5f;
				dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, default(Color), 2f);
				Main.dust[dustIndex].velocity *= 3f;
			}*/
			
		}
        
    }
}