using Terraria;
using Terraria.ModLoader;

namespace Fargowiltas.Buffs
{
	public class Unstable : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Unstable");
			Description.SetDefault("You don't quite fit into reality.");
			Main.buffNoSave[Type] = true;
			canBeCleared = false;
			Main.debuff[Type] = true;
		}

        public override bool Autoload(ref string name, ref string texture)
        {
            texture = "Fargowiltas/Buffs/PlaceholderDebuff";

            return true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<FargoPlayer>().unstable = true;
        }

    }
}