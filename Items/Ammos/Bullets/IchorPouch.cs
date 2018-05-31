using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Ammos.Bullets
{
	public class IchorPouch : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Endless Ichor Pouch");
			Tooltip.SetDefault("Decreases target's defense");
		}
		
		public override void SetDefaults()
		{
			item.shootSpeed = 5.25f;
			item.shoot = ProjectileID.IchorBullet;
			item.damage = 13;
			item.width = 26;
			item.height = 26;
			item.ranged = true;
			item.ammo = AmmoID.Bullet;
			item.knockBack = 4f;
			item.rare = 4;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.IchorBullet, 3996);
			recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
		}
	}
}