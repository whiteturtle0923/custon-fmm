<<<<<<< HEAD
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace Fargowiltas.Projectiles.insta
{
    public class dia : ModProjectile
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
 
        public override void Kill(int timeLeft)
        {			
            Vector2 position = projectile.Center;
            Main.PlaySound(SoundID.Item14, (int)position.X, (int)position.Y);
            int radius = 4;     //size
			int ye = 0;
            for (int x = -radius; x <= (radius); x++)
            {
                for (int y = 0; y <= (325*radius); y++)
                {
                    int xdiaPosition = (int)(y + x + position.X / 16.0f);
                    int ydiaPosition = (int)(y + position.Y / 16.0f);
					int ydiadow = (int)(ye - x + position.X / 16.0f);
					int yodiadow = (int)(ye + position.Y / 16.0f);
					int xadiaPosition = (int)(ye - x + position.X / 16.0f);
                    int yadiaPosition = (int)(y + position.Y / 16.00f);
					int yadiadow = (int)(y + x + position.X / 16.0f);
					int yoadiadow = (int)(ye + position.Y / 16.0f);
 
                    if ((x * y) <= radius)   //rectangle
                    {
                        WorldGen.KillTile(xdiaPosition, ydiaPosition, false, false, false);  //tile destroy
						WorldGen.KillTile(ydiadow, yodiadow, false, false, false);  //tile destroy
						WorldGen.KillTile(xadiaPosition, yadiaPosition, false, false, false);  //tile destroy
						WorldGen.KillTile(yadiadow, yoadiadow, false, false, false);  //tile destroy
                        Dust.NewDust(position, 22, 22, DustID.Smoke, 0.0f, 0.0f, 120, new Color(), 1f); 
                    }
					ye = y*-1;
                }
            }
        }
    }
=======
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace Fargowiltas.Projectiles.insta
{
    public class dia : ModProjectile
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
 
        public override void Kill(int timeLeft)
        {			
            Vector2 position = projectile.Center;
            Main.PlaySound(SoundID.Item14, (int)position.X, (int)position.Y);
            int radius = 4;     //size
			int ye = 0;
            for (int x = -radius; x <= (radius); x++)
            {
                for (int y = 0; y <= (325*radius); y++)
                {
                    int xdiaPosition = (int)(y + x + position.X / 16.0f);
                    int ydiaPosition = (int)(y + position.Y / 16.0f);
					int ydiadow = (int)(ye - x + position.X / 16.0f);
					int yodiadow = (int)(ye + position.Y / 16.0f);
					int xadiaPosition = (int)(ye - x + position.X / 16.0f);
                    int yadiaPosition = (int)(y + position.Y / 16.00f);
					int yadiadow = (int)(y + x + position.X / 16.0f);
					int yoadiadow = (int)(ye + position.Y / 16.0f);
 
                    if ((x * y) <= radius)   //rectangle
                    {
                        WorldGen.KillTile(xdiaPosition, ydiaPosition, false, false, false);  //tile destroy
						WorldGen.KillTile(ydiadow, yodiadow, false, false, false);  //tile destroy
						WorldGen.KillTile(xadiaPosition, yadiaPosition, false, false, false);  //tile destroy
						WorldGen.KillTile(yadiadow, yoadiadow, false, false, false);  //tile destroy
                        Dust.NewDust(position, 22, 22, DustID.Smoke, 0.0f, 0.0f, 120, new Color(), 1f); 
                    }
					ye = y*-1;
                }
            }
        }
    }
>>>>>>> 66ed39caf4938fca8e7009752b635e42f8a8a58f
}