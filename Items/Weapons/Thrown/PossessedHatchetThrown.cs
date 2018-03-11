<<<<<<< HEAD
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Weapons.Thrown
{
	public class PossessedHatchetThrown : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.PossessedHatchet);
			item.shoot = ProjectileID.PossessedHatchet;
			item.melee = false;
			item.thrown = true;
			item.damage = 89;
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {

			int proj = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI, 0f, 0f);
			Main.projectile[proj].thrown = true;
			Main.projectile[proj].melee = false;
			
            return false;
        }
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.PossessedHatchet);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
=======
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Weapons.Thrown
{
	public class PossessedHatchetThrown : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.PossessedHatchet);
			item.shoot = ProjectileID.PossessedHatchet;
			item.melee = false;
			item.thrown = true;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.PossessedHatchet);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
>>>>>>> 66ed39caf4938fca8e7009752b635e42f8a8a58f
}