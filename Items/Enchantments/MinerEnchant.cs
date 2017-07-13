using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Fargowiltas.Items.Enchantments
{
	public class MinerEnchant : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Miner Enchantment");
			Tooltip.SetDefault("'The planet trembles with each swing of your pick' \n30% increased mining speed \nShows the location of enemies, traps, and treasures \nYou emit an aura of light");
		}
		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.accessory = true;
			ItemID.Sets.ItemNoGravity[item.type] = true;
			item.rare = 1; 
			item.value = 10000; 
		}
		
		public override void UpdateAccessory(Player player, bool hideVisual)
        {
			player.pickSpeed -= 0.3f;
			if(soulcheck.light == true)
			{
			Lighting.AddLight(player.Center, 0.8f, 0.8f, 0f);
			}
			if(soulcheck.spelunk == true)
			{
			player.findTreasure = true;
			}
			if(soulcheck.hunt == true)
			{
			player.detectCreature = true;
			}
			if(soulcheck.danger == true)
			{
			player.dangerSense = true;
			}
        }
		
		public override void AddRecipes()
		{
            ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MiningHelmet);
            recipe.AddIngredient(ItemID.MiningShirt);
			recipe.AddIngredient(ItemID.MiningPants);
			recipe.AddIngredient(ItemID.CactusPickaxe);
			recipe.AddIngredient(ItemID.MagicLantern);
			recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
		}
	}
}
		

