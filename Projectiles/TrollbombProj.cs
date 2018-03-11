<<<<<<< HEAD
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace Fargowiltas.Projectiles
{
    public class TrollbombProj : ModProjectile
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Trollbomb");
		}
        public override void SetDefaults()
        {
			projectile.damage = 0;
            projectile.width = 10;   //This defines the hitbox width
            projectile.height = 32;    //This defines the hitbox height
            projectile.aiStyle = 16;  //How the projectile works, 16 is the aistyle Used for: Grenades, Dynamite, Bombs, Sticky Bomb.
            projectile.friendly = false; //Tells the game whether it is friendly to players/friendly npcs or not
            projectile.penetrate = -1; //Tells the game how many enemies it can hit before being destroyed
            projectile.timeLeft = 150; //The amount of time the projectile is alive for
        }
 
 
 
       public override void Kill(int timeLeft)
        {
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 43);
           
                NPC.NewNPC((int)projectile.Center.X, (int)projectile.Center.Y - 10, NPCID.DungeonGuardian, 0, projectile.whoAmI, 0, 0);
				Main.NewText("RUN YOU SCRUB", 175, 75, 255);
		}
	}
=======
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace Fargowiltas.Projectiles
{
    public class TrollbombProj : ModProjectile
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Trollbomb");
		}
        public override void SetDefaults()
        {
			projectile.damage = 0;
            projectile.width = 10;   //This defines the hitbox width
            projectile.height = 32;    //This defines the hitbox height
            projectile.aiStyle = 16;  //How the projectile works, 16 is the aistyle Used for: Grenades, Dynamite, Bombs, Sticky Bomb.
            projectile.friendly = false; //Tells the game whether it is friendly to players/friendly npcs or not
            projectile.penetrate = -1; //Tells the game how many enemies it can hit before being destroyed
            projectile.timeLeft = 150; //The amount of time the projectile is alive for
        }
 
 
 
       public override void Kill(int timeLeft)
        {
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 43);
           
                NPC.NewNPC((int)projectile.Center.X, (int)projectile.Center.Y - 10, NPCID.DungeonGuardian, 0, projectile.whoAmI, 0, 0);
				Main.NewText("RUN YOU SCRUB", 175, 75, 255);
		}
	}
>>>>>>> 66ed39caf4938fca8e7009752b635e42f8a8a58f
}