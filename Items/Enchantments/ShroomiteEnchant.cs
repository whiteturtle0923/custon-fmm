using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Fargowiltas.Items.Enchantments
{
	public class ShroomiteEnchant : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shroomite Enchantment");
			Tooltip.SetDefault("'Made with real shrooms!' \n12% increased ranged damage \nNot moving puts you in stealth \nSpores spawn on enemies when you attack in stealth mode");
		}
		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.accessory = true;
			ItemID.Sets.ItemNoGravity[item.type] = true;
			item.rare = 8; 
			item.value = 250000; 
		}
		
		public override void UpdateAccessory(Player player, bool hideVisual)
        {
			
			player.rangedDamage+= .12f;
			if(soulcheck.shrooms == true)
			{
			player.shroomiteStealth = true;
			
			//when standing still
			if ((double)Math.Abs(player.velocity.X) < 0.05 && (double)Math.Abs(player.velocity.Y) < 0.05 && player.itemAnimation == 0)
			{
				((FargoPlayer)player.GetModPlayer(mod, "FargoPlayer")).shroomEnchant = true;
			}
			}
        }
		
		public override void AddRecipes()
		{
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("Fargowiltas:AnyShroomHead");
			recipe.AddIngredient(ItemID.ShroomiteBreastplate);
			recipe.AddIngredient(ItemID.ShroomiteLeggings);
			recipe.AddIngredient(ItemID.Hammush);
			recipe.AddIngredient(ItemID.Uzi);
			recipe.AddIngredient(ItemID.GrenadeLauncher);
			recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
		}
	}
}

