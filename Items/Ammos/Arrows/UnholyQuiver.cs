using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Ammos.Arrows
{
	public class UnholyQuiver : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Endless Unholy Quiver");
		}
		
		public override void SetDefaults()
		{
			item.shootSpeed = 3.4f;
			item.shoot = ProjectileID.UnholyArrow;
			item.damage = 12;
			item.width = 26;
			item.height = 26;
			item.ranged = true;
			item.ammo = AmmoID.Arrow;
			item.knockBack = 3f;
			item.rare = 3;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.UnholyArrow, 3996);
			recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
		}
	}
}