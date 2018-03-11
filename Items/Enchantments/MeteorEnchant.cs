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
	public class MeteorEnchant : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Meteor Enchantment");
			Tooltip.SetDefault("'Cosmic power builds your magical prowess'\n" +
								"10% increased magic damage \n" +
								"A meteor shower initiates upon reaching less than 5 mana");
								
								//check that uh blue magic sword rain
		}
		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.accessory = true;
			ItemID.Sets.ItemNoGravity[item.type] = true;
			item.rare = 5; 
			item.value = 100000; 
		}
		
		public override void UpdateAccessory(Player player, bool hideVisual)
        {
			FargoPlayer modPlayer = (FargoPlayer)player.GetModPlayer(mod, "FargoPlayer");
			modPlayer.meteorEnchant = true;
			
			player.magicDamage += .10f;
        }
		
		public override void AddRecipes()
		{
            ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MeteorHelmet);
            recipe.AddIngredient(ItemID.MeteorSuit);
			recipe.AddIngredient(ItemID.MeteorLeggings);
			recipe.AddIngredient(ItemID.SpaceGun);
			recipe.AddIngredient(ItemID.MeteorStaff);
			recipe.AddIngredient(ItemID.PlaceAbovetheClouds);
			recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
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
	public class MeteorEnchant : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Meteor Enchantment");
			Tooltip.SetDefault("'Cosmic power builds your magical prowess' \n10% reduced magic damage \nCertain magic guns will use no mana");
		}
		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.accessory = true;
			ItemID.Sets.ItemNoGravity[item.type] = true;
			item.rare = 1; 
			item.value = 10000; 
		}
		
		public override void UpdateAccessory(Player player, bool hideVisual)
        {
			FargoPlayer modPlayer = (FargoPlayer)player.GetModPlayer(mod, "FargoPlayer");
			modPlayer.meteorEnchant = true;
			
			player.magicDamage -= .10f;
        }
		
		public override void AddRecipes()
		{
            ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MeteorHelmet);
            recipe.AddIngredient(ItemID.MeteorSuit);
			recipe.AddIngredient(ItemID.MeteorLeggings);
			recipe.AddIngredient(ItemID.SpaceGun);
			recipe.AddIngredient(ItemID.LaserRifle);
			recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
		}
	}
>>>>>>> 66ed39caf4938fca8e7009752b635e42f8a8a58f
}