<<<<<<< HEAD
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Projectiles
{
	public class MechEyeProjectile : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("MechEyeProjectile");
		}
		public override void SetDefaults()
		{
			projectile.width = 20;
			projectile.height = 24;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.ranged = true;
			projectile.penetrate = 5;
			projectile.timeLeft = 600;
			aiType = ProjectileID.Bullet;
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
	public class MechEyeProjectile : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("MechEyeProjectile");
		}
		public override void SetDefaults()
		{
			projectile.width = 20;
			projectile.height = 24;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.ranged = true;
			projectile.penetrate = 5;
			projectile.timeLeft = 600;
			aiType = ProjectileID.Bullet;
		}
		
		
	}
>>>>>>> 66ed39caf4938fca8e7009752b635e42f8a8a58f
}