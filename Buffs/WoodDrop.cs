using Terraria;
using Terraria.ModLoader;
using Fargowiltas.NPCs;
using Fargowiltas;

namespace Fargowiltas.Buffs
{
	public class WoodDrop : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Wood Drop");
			//Description.SetDefault("drops wood");
			Main.buffNoSave[Type] = true;
			//Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			//player.GetModPlayer<FargoPlayer>(mod).wood = true;
		}

		public override void Update(NPC npc, ref int buffIndex)
		{
			//npc.GetGlobalNPC<FargoGlobalNPC>(mod).wood = true;
		}
	}
}