using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Ammos.Bullets
{
	public class SilverPouch : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Endless Silver Pouch");
		}
		
		public override void SetDefaults()
		{
			item.shootSpeed = 4.5f;
			item.shoot = ProjectileID.Bullet;
			item.damage = 9;
			item.width = 26;
			item.height = 26;
			item.ranged = true;
			item.ammo = AmmoID.Bullet;
			item.knockBack = 3f;
			item.rare = 2;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SilverBullet, 3996);
			recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
		}
	}
}