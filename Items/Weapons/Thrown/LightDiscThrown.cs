using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Weapons.Thrown
{
	public class LightDiscThrown : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.LightDisc);
			item.shoot = ProjectileID.LightDisc;
			item.melee = false;
			item.thrown = true;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LightDisc);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}