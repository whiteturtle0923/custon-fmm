<<<<<<< HEAD
using Terraria.ModLoader;

namespace Fargowiltas.Projectiles.Minions
{
	public abstract class Minion : ModProjectile
	{
		public override void AI()
		{
			CheckActive();
			Behavior();
		}

		public abstract void CheckActive();

		public abstract void Behavior();
	}
=======
using Terraria.ModLoader;

namespace Fargowiltas.Projectiles.Minions
{
	public abstract class Minion : ModProjectile
	{
		public override void AI()
		{
			CheckActive();
			Behavior();
		}

		public abstract void CheckActive();

		public abstract void Behavior();
	}
>>>>>>> 66ed39caf4938fca8e7009752b635e42f8a8a58f
}