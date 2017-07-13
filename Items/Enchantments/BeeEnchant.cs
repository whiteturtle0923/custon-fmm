using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Fargowiltas.Items.Enchantments
{
	public class BeeEnchant : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bee Enchantment");
			Tooltip.SetDefault("'According to all known laws of aviation, there is no way a bee should be able to fly' \n5% increased minion damage \nIncreases the strength of friendly bees \nSummons a buffed hornet minion at no cost, turn off vanity to despawn it");
		}
		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.accessory = true;			
			ItemID.Sets.ItemNoGravity[item.type] = true;
			item.rare = 3; 
			item.value = 20000; 
		}
		
		public override void UpdateAccessory(Player player, bool hideVisual)
        {
			player.minionDamage += 0.05f;
			player.strongBees = true;
			
			
			//bee minion
			if (player.whoAmI == Main.myPlayer)
            {
				if(soulcheck.bee == true)
				{
					((FargoPlayer)player.GetModPlayer(mod, "FargoPlayer")).beeEnchant = true;
					//no one can know
					player.maxMinions += 1;
					
					if(player.FindBuffIndex(125) == -1)
					{
						if (player.ownedProjectileCounts[373] < 1)
						{
							Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, -1f, 373, 30, 2f, Main.myPlayer, 0f, 0f);
						}
					}
					else
					{
						Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, -1f, 373, 30, 2f, Main.myPlayer, 0f, 0f);
					}
				}
				else
				{
					((FargoPlayer)player.GetModPlayer(mod, "FargoPlayer")).beeEnchant = false;
				}
			}
                
				
        }
		
		public override void AddRecipes()
		{
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BeeHeadgear);
			recipe.AddIngredient(ItemID.BeeBreastplate);
			recipe.AddIngredient(ItemID.BeeGreaves);
			recipe.AddIngredient(ItemID.HiveBackpack);
			recipe.AddIngredient(ItemID.Nectar);
			recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
		}
	}	
}
		
