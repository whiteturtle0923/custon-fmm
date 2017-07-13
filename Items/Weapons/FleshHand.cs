using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace Fargowiltas.Items.Weapons
{
	public class FleshHand : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Flesh Hand");
			Tooltip.SetDefault("'The enslaved minions of a defeated foe..'");
		}
		 public override void SetDefaults()
	    {
			item.damage = 32;
			item.thrown = true;
			item.width = 24;
			item.height = 24;
			item.useTime = 15;
			item.useAnimation = 15;// must be the same^
			item.useStyle = 5; 
			item.noMelee = true; 
			item.knockBack = 1.5f; 
			item.UseSound = new LegacySoundStyle(4, 13);
			item.value = 50000; 
			item.rare = 5; 
			item.autoReuse = true; 
			item.shoot = mod.ProjectileType("Hungry"); 
			item.shootSpeed = 20f; 
			item.noUseGraphic = true;
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float spread = 45f * 0.0174f;
            double startAngle = Math.Atan2(speedX, speedY)- spread/2;
            double deltaAngle = spread/8f;
            double offsetAngle;
            int i;
			
				for (i = 0; i < 1; i++ )
				{
					offsetAngle = (startAngle + deltaAngle * (i + i*i) / 2f) + 32f * i;
					Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("Hungry"), damage, knockBack, player.whoAmI, 0f, 0f);
				}
			
            return false;
        }
		
		public override void AddRecipes()
		{	
			ModRecipe recipe = new ModRecipe(mod);
			
			recipe.AddIngredient(ItemID.WallofFleshTrophy);
			
			recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
		}
		
		
	}
}