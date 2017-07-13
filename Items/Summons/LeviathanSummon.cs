using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;

namespace Fargowiltas.Items.Summons
{
	public class LeviathanSummon : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Siren's Pearl");
			Tooltip.SetDefault("Summons The Leviathan");
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
			
			if (ModLoader.GetLoadedMods().Contains("CalamityMod"))
             {
				NPC.NewNPC((int)player.position.X, (int)player.position.Y - 220, ModLoader.GetMod("CalamityMod").NPCType("Siren"));
				NPC.NewNPC((int)player.position.X, (int)player.position.Y - 220, ModLoader.GetMod("CalamityMod").NPCType("Leviathan"));
			 }
			
            Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
            return true;
 
        }

		
	}
}