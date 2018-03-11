using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Ammos
{
	public class MeteorPouch : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Endless Meteor Pouch");
		}
		
		public override void SetDefaults()
		{
			item.shootSpeed = 3f;
			item.shoot = ProjectileID.MeteorShot;
			item.damage = 9;
			item.width = 26;
			item.height = 26;
			item.ranged = true;
			item.ammo = AmmoID.Bullet;
			item.knockBack = 1f;
			item.rare = 3;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MeteorShot, 3996);

			recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
		}
	}
}