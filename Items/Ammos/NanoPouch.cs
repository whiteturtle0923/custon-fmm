using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Ammos
{
	public class NanoPouch : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Endless Nano Pouch");
			Tooltip.SetDefault("Causes confusion");
		}
		
		public override void SetDefaults()
		{
			item.shootSpeed = 5.1f;
			item.shoot = ProjectileID.NanoBullet;
			item.damage = 10;
			item.width = 26;
			item.height = 26;
			item.ranged = true;
			item.ammo = AmmoID.Bullet;
			item.knockBack = 5f;
			item.rare = 4;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.NanoBullet, 3996);

			recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
		}
	}
}