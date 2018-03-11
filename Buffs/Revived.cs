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
}