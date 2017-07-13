using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;

namespace Fargowiltas.Items
{
	public class PortableSundial : ModItem
	{		
	public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Portable Sundial");
			Tooltip.SetDefault("Left click to instantly switch from day to night\n" +
								"Right click to activate the Enchanted Sundial effect");
		}
		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.maxStack = 1;
			item.value = 1000;
			item.rare = 4;
			item.useAnimation = 30;
			item.useTime = 30;
			item.useStyle = 4;
			item.consumable = false;
			item.mana = 50;
		}
		
		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool UseItem(Player player)
		{
			if (player.altFunctionUse == 2) //right click
			{
				Main.sundialCooldown = 0;
				Main.Sundialing();
				Main.PlaySound(SoundID.Item4, player.position);
				
			}
			
			else //left click
			{
				Main.dayTime = !Main.dayTime;
			}
			
			return true;
		}
		
		public override void AddRecipes()
		{	
			ModRecipe recipe = new ModRecipe(mod);
			
			recipe.AddIngredient(ItemID.Sundial);
			recipe.AddIngredient(ItemID.SoulofLight, 10);
			recipe.AddIngredient(ItemID.SoulofNight, 10);
			recipe.AddIngredient(ItemID.SoulofFlight, 10);
			
			recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
		}
	
	}
}