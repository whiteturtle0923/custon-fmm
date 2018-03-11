<<<<<<< HEAD
using Terraria;
using Terraria.ModLoader;

namespace Fargowiltas.Buffs
{
	public class SpookyCD : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Scythe Cooldown");
			Description.SetDefault("No Scythes for a bit");
			Main.buffNoSave[Type] = true;
			canBeCleared = false;
			Main.debuff[Type] = true;
		}

	}
=======
using Terraria;
using Terraria.ModLoader;

namespace Fargowiltas.Buffs
{
	public class SpookyCD : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Scythe Cooldown");
			Description.SetDefault("No Scythes for a bit");
			Main.buffNoSave[Type] = true;
			canBeCleared = false;
			Main.debuff[Type] = true;
		}

	}
>>>>>>> 66ed39caf4938fca8e7009752b635e42f8a8a58f
}