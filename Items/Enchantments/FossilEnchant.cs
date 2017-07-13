using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Fargowiltas.Items.Enchantments
{
	public class FossilEnchant : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fossil Enchantment");
			Tooltip.SetDefault("'Beyond a forgotten age' \n10% increased throwing damage and velocity \nYou cheat death, returning with 20 HP \n5 minute cooldown");
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
			((FargoPlayer)player.GetModPlayer(mod, "FargoPlayer")).fossilEnchant = true;
			player.thrownVelocity += 0.1f;
			player.thrownDamage += 0.1f;
			
        }
		
		public override void AddRecipes()
		{
            ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FossilHelm);
            recipe.AddIngredient(ItemID.FossilShirt);
			recipe.AddIngredient(ItemID.FossilPants);
			recipe.AddIngredient(ItemID.BoneJavelin, 100);
			recipe.AddIngredient(ItemID.SecretoftheSands);
			recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
		}
	}
}
		
