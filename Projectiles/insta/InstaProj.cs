using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace Fargowiltas.Projectiles.insta
{
    public class InstaProj : ModProjectile
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Instavator");
		}
        public override void SetDefaults()
        {
            projectile.width = 20;   //This defines the hitbox width
            projectile.height = 36;    //This defines the hitbox height
            projectile.aiStyle = 16;  //explosive ai
			
            projectile.friendly = true; 
            projectile.penetrate = -1; 
            projectile.timeLeft = 170; 
        }
		
		public override bool OnTileCollide (Vector2 oldVelocity)
		{
			projectile.Kill();
			return true;
		}
 
        public override void Kill(int timeLeft)
        {			
            Vector2 position = projectile.Center;
            Main.PlaySound(SoundID.Item14, (int)position.X, (int)position.Y);
			//4 across
            for (int x = -3; x <= 3; x++)
            {
                for (int y = (int)(1 + position.Y / 16.0f); y <= (Main.maxTilesY - 40); y++)
                {
                    int xPosition = (int)(x + position.X / 16.0f);
                    //int yPosition = (int)(y + position.Y / 16.0f);
 
                    WorldGen.KillTile(xPosition, y, false, false, false);  //tile destroy
					WorldGen.KillWall(xPosition, y);
                    Dust.NewDust(position, 22, 22, DustID.Smoke, 0.0f, 0.0f, 120, new Color(), 1f); 
					
					WorldGen.PlaceWall(xPosition, y, 1);
					
					Tile tile = Main.tile[xPosition, y];
					
					if(tile != null)
					{
						tile.liquid = 0;
						tile.lava(false);
						tile.honey(false);
						if (Main.netMode == 2)
						{
							NetMessage.sendWater(xPosition, y);
						}
					}
					
					if((x == -3) || (x == 3))
					{
						WorldGen.PlaceTile(xPosition, y, 38);
					}
					
					if((x == -2 || x == 2) && (y % 10 == 0))
					{
						WorldGen.PlaceTile(xPosition, y, 4);
					}
					
					if(x == 0)
					{
						WorldGen.PlaceTile(xPosition, y, 213);
					}
					//Projectile.NewProjectile(player.Center.X, player.Center.Y, -0.75f, 0.75f, 145, 0, 0, Main.myPlayer, 0f, 0f);
                    
                }
            }
        }
    }
}