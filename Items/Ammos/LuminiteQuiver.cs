using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Ammos
{
	public class LuminiteQuiver : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Endless Luminite Quiver");
			Tooltip.SetDefault("'Shooting them down at the speed of sound!'");
		}
		
		public override void SetDefaults()
		{
			item.shootSpeed = 3f;
			item.shoot = ProjectileID.MoonlordArrow;
			item.damage = 15;
			item.width = 26;
			item.height = 26;
			item.ranged = true;
			item.ammo = AmmoID.Arrow;
			item.knockBack = 3.5f;
			item.rare = 10;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MoonlordArrow, 3996);

			recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
		}
	}
}