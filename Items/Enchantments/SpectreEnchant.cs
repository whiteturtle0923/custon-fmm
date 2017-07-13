using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Fargowiltas.Items.Enchantments
{
	public class SpectreEnchant : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spectre Enchantment");
			Tooltip.SetDefault("'Their lifeforce will be their own undoing' \n12% increased magic damage \nMagic damage has a chance to spawn damaging orbs \nSummons a Wisp to provide light, turn vanity off to despawn it");
		}
		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.accessory = true;
			ItemID.Sets.ItemNoGravity[item.type] = true;
			item.rare = 8; 
			item.value = 250000; 
		}
		
		public override void UpdateAccessory(Player player, bool hideVisual)
        {
			FargoPlayer modPlayer = player.GetModPlayer<FargoPlayer>(mod);
			modPlayer.spectreEnchant = true;
			
			player.magicDamage+= .12f;
			
			if(modPlayer.specHeal)
			{
				player.ghostHeal = true;
			}
			else
			{
				player.ghostHurt = true;	
			}
			
			if (player.whoAmI == Main.myPlayer)
            {
				if(!hideVisual)
				{
					modPlayer.spectrePet = true;
					
					if(player.FindBuffIndex(57) == -1)
					{
						if (player.ownedProjectileCounts[ProjectileID.Wisp] < 1)
						{
							Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, -1f, ProjectileID.Wisp, 0, 2f, Main.myPlayer, 0f, 0f);
						}
					}
				}
				else
				{
						modPlayer.spectrePet = false;
				}
            }
        }
		
		public override void AddRecipes()
		{
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("Fargowiltas:AnySpectreHead");;
			recipe.AddIngredient(ItemID.SpectreRobe);
			recipe.AddIngredient(ItemID.SpectrePants);
			recipe.AddIngredient(ItemID.UnholyTrident);
			recipe.AddIngredient(ItemID.SpectreStaff);
			recipe.AddIngredient(ItemID.WispinaBottle);
			recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
		}
	}	
}
		
