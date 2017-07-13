using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Fargowiltas.Items.Enchantments
{
	public class SpiderEnchant : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spider Enchantment");
			Tooltip.SetDefault("'Arachniphobia is punishable by death... by arachnids' \n10% increased minion damage \nSummons a super buffed spider minion at no cost");
		}
		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.accessory = true;
			ItemID.Sets.ItemNoGravity[item.type] = true;
			item.rare = 4; 
			item.value = 30000; 
		}
		
		public override void UpdateAccessory(Player player, bool hideVisual)
        {
			
			player.minionDamage += 0.1f;
			
			//spider minion
			if (player.whoAmI == Main.myPlayer)
            {
				if(soulcheck.spid == true)
				{
					//no one can know
					player.maxMinions += 1;
					((FargoPlayer)player.GetModPlayer(mod, "FargoPlayer")).spiderEnchant = true;
					
					if(player.FindBuffIndex(133) == -1)
					{
						if (player.ownedProjectileCounts[390] < 1 && player.ownedProjectileCounts[391] < 1 && player.ownedProjectileCounts[392] < 1)
						{
							int i = Main.rand.Next(390, 393);
							Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, -1f, i, 50, 3f, Main.myPlayer, 0f, 0f);
						}
					}
					else
					{
						Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, -1f, 392, 50, 3f, Main.myPlayer, 0f, 0f);
					}
				}
				else
				{
					((FargoPlayer)player.GetModPlayer(mod, "FargoPlayer")).spiderEnchant = false;
				}
            }
        }
		
		public override void AddRecipes()
		{
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SpiderMask);
			recipe.AddIngredient(ItemID.SpiderBreastplate);
			recipe.AddIngredient(ItemID.SpiderGreaves);
			recipe.AddIngredient(ItemID.SpiderStaff);
			recipe.AddIngredient(ItemID.VenomStaff);
			recipe.AddIngredient(ItemID.WebSlinger);
			recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
		}
	}	
}
		
