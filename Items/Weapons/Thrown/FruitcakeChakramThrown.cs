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
	public class FruitcakeChakramThrown : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.FruitcakeChakram);
			item.shoot = ProjectileID.FruitcakeChakram;
			item.melee = false;
			item.thrown = true;
			item.damage = 16;
		}
		
		public override bool CanUseItem(Player player)       //this make that you can shoot only 1 boomerang at once
        {
            for (int i = 0; i < 1000; ++i)
            {
                if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && Main.projectile[i].type == item.shoot)
                {
                    return false;
                }
            }
            return true;
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
			recipe.AddIngredient(ItemID.FruitcakeChakram);
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
	public class FruitcakeChakramThrown : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.FruitcakeChakram);
			item.shoot = ProjectileID.FruitcakeChakram;
			item.melee = false;
			item.thrown = true;
		}
		
		public override bool CanUseItem(Player player)       //this make that you can shoot only 1 boomerang at once
        {
            for (int i = 0; i < 1000; ++i)
            {
                if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && Main.projectile[i].type == item.shoot)
                {
                    return false;
                }
            }
            return true;
        }
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FruitcakeChakram);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
>>>>>>> 66ed39caf4938fca8e7009752b635e42f8a8a58f
}