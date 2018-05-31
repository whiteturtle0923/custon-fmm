using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Ammos.Bullets
{
	public class VenomPouch : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Endless Venom Pouch");
			Tooltip.SetDefault("Inflicts target with venom");
		}
		
		public override void SetDefaults()
		{
			item.shootSpeed = 5.3f;
			item.shoot = ProjectileID.VenomBullet;
			item.damage = 14;
			item.width = 26;
			item.height = 26;
			item.ranged = true;
			item.ammo = AmmoID.Bullet;
			item.knockBack = 4.1f;
			item.rare = 4;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.VenomBullet, 3996);
			recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
		}
	}
}