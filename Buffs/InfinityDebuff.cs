using Terraria;
using Terraria.ModLoader;

namespace Fargowiltas.Buffs
{
	public class InfinityDebuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Curse of Infinity");
			Description.SetDefault("You will hurt yourself when you attack an enemy");
			Main.buffNoSave[Type] = true;
			canBeCleared = false;
			Main.debuff[Type] = true;
		}
	}
}