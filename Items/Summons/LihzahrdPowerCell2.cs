using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons
{
	public class LihzahrdPowerCell2 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lihzahrdy Power Cell");
			Tooltip.SetDefault("Summons the Golem without an altar");
		}
		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.maxStack = 20;
			item.value = 1000;
			item.rare = 1;
			item.useAnimation = 30;
			item.useTime = 30;
			item.useStyle = 4;
			item.consumable = true;
		}

		public override bool UseItem(Player player)
        {
			
			NPC.NewNPC((int)player.position.X, (int)player.position.Y - 300, NPCID.Golem);
			Main.NewText("Golem has awoken!", 175, 75, 255);
		
            Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
            return true;
        }
	}
}