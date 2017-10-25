using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Fargowiltas.Items.Enchantments
{
	public class SpiderEnchant : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spider Enchantment");
			Tooltip.SetDefault("'Arachniphobia is punishable by arachnid induced death' \n10% increased minion damage \nSummon damage causes venom and has a chance to spawn additional spiders");
		}
		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.accessory = true;
			ItemID.Sets.ItemNoGravity[item.type] = true;
			item.rare = 4; 
			item.value = 30000; 
		}
		
		public override void UpdateAccessory(Player player, bool hideVisual)
        {
			FargoPlayer modPlayer = player.GetModPlayer<FargoPlayer>(mod);
			modPlayer.spiderEnchant = true;
			
			player.minionDamage += 0.1f;
			
			
        }
		
		public override void AddRecipes()
		{
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SpiderMask);
			recipe.AddIngredient(ItemID.SpiderBreastplate);
			recipe.AddIngredient(ItemID.SpiderGreaves);
			recipe.AddIngredient(ItemID.SpiderStaff);
			recipe.AddIngredient(ItemID.VenomStaff);
			recipe.AddIngredient(ItemID.WebSlinger);
			recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
		}
	}	
}
		
