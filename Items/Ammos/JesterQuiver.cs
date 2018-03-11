using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Ammos
{
	public class JesterQuiver : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Endless Jester's Quiver");
		}
		
		public override void SetDefaults()
		{
			item.shootSpeed = 0.5f;
			item.shoot = ProjectileID.JestersArrow;
			item.damage = 10;
			item.width = 26;
			item.height = 26;
			item.ranged = true;
			item.ammo = AmmoID.Arrow;
			item.knockBack = 4f;
			item.rare = 3;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.JestersArrow, 3996);

			recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
		}
	}
}