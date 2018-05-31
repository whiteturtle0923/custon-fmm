using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Ammos.Arrows
{
	public class FrostburnQuiver : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Endless Frostburn Quiver");
		}
		
		public override void SetDefaults()
		{
			item.shootSpeed = 3.75f;
			item.shoot = ProjectileID.FrostburnArrow;
			item.damage = 9;
			item.width = 26;
			item.height = 26;
			item.ranged = true;
			item.ammo = AmmoID.Arrow;
			item.knockBack = 2.2f;
			item.rare = 2;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FrostburnArrow, 3996);
			recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
		}
	}
}