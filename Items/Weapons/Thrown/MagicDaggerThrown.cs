using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Weapons.Thrown
{
	public class MagicDaggerThrown : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.MagicDagger);
			item.shoot = ProjectileID.MagicDagger;
			item.magic = false;
			item.thrown = true;
			item.mana = 0;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MagicDagger);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}