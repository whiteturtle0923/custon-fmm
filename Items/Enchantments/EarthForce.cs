<<<<<<< HEAD
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Fargowiltas.Items.Enchantments
{
	public class EarthForce : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Force of Earth");
			Tooltip.SetDefault("'Gaia's blessing shines upon you'\n" +
								"30% increased weapon use speed\n" +
								"Enemies will explode into cobalt shards on death\n" +
								"Greatly increases life regeneration after striking an enemy\n" +
								"Very small chance for an attack to gain 33% life steal\n" + 
								"Chance for a fireball to spew from a hit enemy\n" +
								"20% chance to shoot multiple projectiles with single shot magic weapons \n" +
								"Briefly become invulnerable after striking an enemy\n" +
								"While a dodge is active, damage is increased by 25%\n" +
								"While on cooldown, damage is decreased by 15%\n" +
								"Shows the location of enemies, traps, and treasures\n" +
								"Other effects of material enchantments" );
		}
		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.accessory = true;
			ItemID.Sets.ItemNoGravity[item.type] = true;
			item.rare = 10; 
			item.value = 300000; 
		}
		
		public override void UpdateAccessory(Player player, bool hideVisual)
        {
			FargoPlayer modPlayer = player.GetModPlayer<FargoPlayer>(mod);
			
			//miner
			player.pickSpeed -= 0.3f; 
			if(soulcheck.light == true)
			{
			Lighting.AddLight(player.Center, 0.8f, 0.8f, 0f);
			}
			if(soulcheck.spelunk == true)
			{
				player.findTreasure = true;
			}
			if(soulcheck.hunt == true)
			{
				player.detectCreature = true;
			}
			if(soulcheck.danger == true)
			{
				player.dangerSense = true;
			}
			//cobalt
			modPlayer.cobaltEnchant = true;
			
			//palladium
			player.onHitRegen = true;
			modPlayer.palladEnchant = true;

			//mythril	
			if(soulcheck.useSpeed)
			{
				modPlayer.firingSpeed += .3f;
				modPlayer.castingSpeed += .3f;
				modPlayer.throwingSpeed += .3f;
				modPlayer.radiantSpeed += .3f;
				modPlayer.symphonicSpeed += .3f;
				modPlayer.healingSpeed += .3f;
				modPlayer.axeSpeed += .3f;
				modPlayer.hammerSpeed += .3f;
				modPlayer.pickSpeed += .3f;
			}
			
			//orichalcum
			if(soulcheck.ori == true)
			{
			player.onHitPetal = true;
			modPlayer.oriEnchant = true;
			}
			//adamantite
			if(soulcheck.splitter)
			{
				modPlayer.adamantiteEnchant = true;
			}
			
			//titanium
			player.onHitDodge = true;
			player.kbBuff = true;
			
			if(player.FindBuffIndex(59) == -1)
			{
				player.magicDamage-= .15f;
				player.meleeDamage-= .15f;
				player.rangedDamage-= .15f;
				player.minionDamage-= .15f;
				player.thrownDamage-= .15f;
			}
			else
			{
				player.magicDamage+= .25f;
				player.meleeDamage+= .25f;
				player.rangedDamage+= .25f;
				player.minionDamage+= .25f;
				player.thrownDamage+= .25f;
			}
			
			if (player.whoAmI == Main.myPlayer)
            {
				//if(soulcheck.facePet)
				//{
					modPlayer.lanternPet = true;
					
					if(player.FindBuffIndex(152) == -1)
					{
						if (player.ownedProjectileCounts[ProjectileID.MagicLantern] < 1)
						{
							Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, -1f, ProjectileID.MagicLantern, 0, 2f, Main.myPlayer, 0f, 0f);
						}
					}
				//}
				//else
				//{
				//	modPlayer.lanternPet = false;
				//}
            }
			
        }
		
		public override void AddRecipes()
		{
            ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "MinerEnchant");
            recipe.AddIngredient(null, "CobaltEnchant");
			recipe.AddIngredient(null, "PalladiumEnchant");
			recipe.AddIngredient(null, "MythrilEnchant");
			recipe.AddIngredient(null, "OrichalcumEnchant");
			recipe.AddIngredient(null, "AdamantiteEnchant");
			recipe.AddIngredient(null, "TitaniumEnchant");
			
			
			recipe.AddTile(null, "CrucibleCosmosSheet");
            recipe.SetResult(this);
            recipe.AddRecipe();
			
		}
	}
}
		

=======
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Fargowiltas.Items.Enchantments
{
	public class EarthForce : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Force of Earth");
			Tooltip.SetDefault("'Gaia's blessing shines upon you'\n" +
								"30% increased weapon use speed\n" +
								"Enemies will explode into cobalt shards on death\n" +
								"Greatly increases life regeneration after striking an enemy\n" +
								"Very small chance for an attack to gain 33% life steal\n" + 
								"Chance for a fireball to spew from a hit enemy\n" +
								"20% chance to shoot multiple projectiles with single shot magic weapons \n" +
								"Briefly become invulnerable after striking an enemy\n" +
								"While a dodge is active, damage is increased by 25%\n" +
								"While on cooldown, damage is decreased by 15%\n" +
								"Shows the location of enemies, traps, and treasures with vanity on\n" +
								"Other effects of material enchantments" );
		}
		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.accessory = true;
			ItemID.Sets.ItemNoGravity[item.type] = true;
			item.rare = 10; 
			item.value = 300000; 
		}
		
		public override void UpdateAccessory(Player player, bool hideVisual)
        {
			FargoPlayer modPlayer = player.GetModPlayer<FargoPlayer>(mod);
			
			//miner
			player.pickSpeed -= 0.3f; 
			if(soulcheck.light == true)
			{
			Lighting.AddLight(player.Center, 0.8f, 0.8f, 0f);
			}
			if(soulcheck.spelunk == true)
			{
				player.findTreasure = true;
			}
			if(soulcheck.hunt == true)
			{
				player.detectCreature = true;
			}
			if(soulcheck.danger == true)
			{
				player.dangerSense = true;
			}
			//cobalt
			modPlayer.cobaltEnchant = true;
			
			//palladium
			player.onHitRegen = true;
			modPlayer.palladEnchant = true;

			//mythril	
			if(soulcheck.useSpeed)
			{
				modPlayer.firingSpeed += .3f;
				modPlayer.castingSpeed += .3f;
				modPlayer.throwingSpeed += .3f;
				modPlayer.radiantSpeed += .3f;
				modPlayer.symphonicSpeed += .3f;
				modPlayer.healingSpeed += .3f;
				modPlayer.axeSpeed += .3f;
				modPlayer.hammerSpeed += .3f;
				modPlayer.pickSpeed += .3f;
			}
			
			//orichalcum
			if(soulcheck.ori == true)
			{
			player.onHitPetal = true;
			modPlayer.oriEnchant = true;
			}
			//adamantite
			if(soulcheck.splitter)
			{
				modPlayer.adamantiteEnchant = true;
			}
			
			//titanium
			player.onHitDodge = true;
			player.kbBuff = true;
			
			if(player.FindBuffIndex(59) == -1)
			{
				player.magicDamage-= .15f;
				player.meleeDamage-= .15f;
				player.rangedDamage-= .15f;
				player.minionDamage-= .15f;
				player.thrownDamage-= .15f;
			}
			else
			{
				player.magicDamage+= .25f;
				player.meleeDamage+= .25f;
				player.rangedDamage+= .25f;
				player.minionDamage+= .25f;
				player.thrownDamage+= .25f;
			}
			
        }
		
		public override void AddRecipes()
		{
            ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "MinerEnchant");
            recipe.AddIngredient(null, "CobaltEnchant");
			recipe.AddIngredient(null, "PalladiumEnchant");
			recipe.AddIngredient(null, "MythrilEnchant");
			recipe.AddIngredient(null, "OrichalcumEnchant");
			recipe.AddIngredient(null, "AdamantiteEnchant");
			recipe.AddIngredient(null, "TitaniumEnchant");
			
			
			recipe.AddTile(null, "CrucibleCosmosSheet");
            recipe.SetResult(this);
            recipe.AddRecipe();
			
		}
	}
}
		

>>>>>>> 66ed39caf4938fca8e7009752b635e42f8a8a58f
