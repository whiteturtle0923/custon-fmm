using Terraria;
using Terraria.ModLoader;

namespace Fargowiltas.Buffs
{
	public class InfinityDebuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Curse of Infinity");
			Description.SetDefault("Damage is reduced and you have lost your natural life regen");
			Main.buffNoSave[Type] = true;
			canBeCleared = false;
			Main.debuff[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			//bleed
			player.lifeRegenTime = 0;
			
			player.rangedDamage-= .25f;
			player.magicDamage-= .25f;
			player.meleeDamage-= .25f;
			player.minionDamage-= .25f;
			player.thrownDamage-= .25f;
		}
	}
}