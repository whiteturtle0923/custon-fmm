<<<<<<< HEAD
using Terraria;
using Terraria.ModLoader;

namespace Fargowiltas.Buffs
{
	public class Revived : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Revived");
			Description.SetDefault("Revived recently");
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
	public class Revived : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Revived");
			Description.SetDefault("Revived recently");
			Main.buffNoSave[Type] = true;
			canBeCleared = false;
			Main.debuff[Type] = true;
		}

	}
>>>>>>> 66ed39caf4938fca8e7009752b635e42f8a8a58f
}