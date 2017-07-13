using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Weapons.Thrown
{
	public class ToxicFlaskThrown : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.ToxicFlask);
			item.shoot = ProjectileID.ToxicFlask;
			item.magic = false;
			item.thrown = true;
			item.mana = 0;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ToxicFlask);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}