using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Weapons.Thrown
{
	public class PaladinsHammerThrown : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.PaladinsHammer);
			item.shoot = ProjectileID.PaladinsHammerFriendly;
			item.melee = false;
			item.thrown = true;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.PaladinsHammer);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}