using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Weapons
 {
public class BoomGlaive : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Boom Glaive");
        Tooltip.SetDefault("");
    }

    public override void SetDefaults()
	{
		item.width = 11;  //The width of the .png file in pixels divided by 2.
		item.damage = 16;  
		item.thrown = true;  
		item.noMelee = true;
		item.consumable = true; 
		item.noUseGraphic = true;
		item.useAnimation = 9;  
		item.scale = 0.75f; 
		item.crit = 5; 
		item.useStyle = 1; 
		item.useTime = 13; 
		item.knockBack = 3f;  //Ranges from 1 to 9.
		item.UseSound = SoundID.Item1; //?
		item.autoReuse = true;  
		item.height = 11;  //The height of the .png file in pixels divided by 2.
		item.maxStack = 999;
		item.rare = 1;  
		item.shoot = mod.ProjectileType("GlaiveProj");
		item.shootSpeed = 11f; // ?
	}
	
	public override void AddRecipes()
	{
		ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(ItemID.Dynamite);
		recipe.AddIngredient(ItemID.Shuriken, 50);
        recipe.AddTile(TileID.Anvils);
        recipe.SetResult(this, 50);
        recipe.AddRecipe();
	}
}}
