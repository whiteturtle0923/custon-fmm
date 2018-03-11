<<<<<<< HEAD
﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Projectiles
{
	public class BoomShurikenExplosion : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Explosion");
        	ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;
		}
		public override void SetDefaults()
		{
			projectile.width = 100;
			projectile.height = 100;
			projectile.aiStyle = 0;
			projectile.friendly = true;
			projectile.thrown = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 10;
			projectile.tileCollide = false;
			projectile.light = 0.75f;
			projectile.ignoreWater = true;
			projectile.extraUpdates = 1;
			aiType = ProjectileID.Bullet;
		}
	}
}
=======
﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Projectiles
{
    public class BoomShurikenExplosion : ModProjectile
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shuriken Explosion");
		}
        public override void SetDefaults()
        {
            projectile.width = 20;
            projectile.height = 20;
            projectile.friendly = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.penetrate = -1;
            projectile.timeLeft = 5;
        }
    }
}
>>>>>>> 66ed39caf4938fca8e7009752b635e42f8a8a58f
