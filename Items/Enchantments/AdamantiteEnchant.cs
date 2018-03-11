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
	public class AdamantiteEnchant : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Adamantite Enchantment");
			Tooltip.SetDefault("'This world cannot know me. So I will destroy it with my magic' \n10% increased magic damage \n20% chance to shoot multiple projectiles with single shot magic weapons \n5% chance to cast the wrong spell with single shot magic weapons");
		}
		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.accessory = true;
			ItemID.Sets.ItemNoGravity[item.type] = true;
			item.rare = 4;  
			item.value = 80000;  
		}
		
		public override void UpdateAccessory(Player player, bool hideVisual)
        {
			FargoPlayer modPlayer = player.GetModPlayer<FargoPlayer>(mod);
			if(soulcheck.splitter)
			{
				modPlayer.adamantiteEnchant = true;
			}
			
			player.magicDamage+= .1f;
			
        }
		
		public override void AddRecipes()
		{
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("Fargowiltas:AnyAdamHead");
			recipe.AddIngredient(ItemID.AdamantiteBreastplate);
			recipe.AddIngredient(ItemID.AdamantiteLeggings);
			recipe.AddIngredient(ItemID.SkyFracture);
			recipe.AddIngredient(ItemID.NimbusRod);
			recipe.AddIngredient(ItemID.BookStaff);
			recipe.AddTile(TileID.CrystalBall);
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
	public class AdamantiteEnchant : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Adamantite Enchantment");
			Tooltip.SetDefault("'This world cannot know me. So I will destroy it with my magic' \n10% increased magic damage \n20% chance to shoot multiple projectiles with single shot magic weapons \n5% chance to cast the wrong spell with single shot magic weapons");
		}
		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.accessory = true;
			ItemID.Sets.ItemNoGravity[item.type] = true;
			item.rare = 4;  
			item.value = 80000;  
		}
		
		public override void UpdateAccessory(Player player, bool hideVisual)
        {
			FargoPlayer modPlayer = player.GetModPlayer<FargoPlayer>(mod);
			if(soulcheck.splitter)
			{
				modPlayer.adamantiteEnchant = true;
			}
			
			player.magicDamage+= .1f;
			
        }
		
		public override void AddRecipes()
		{
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("Fargowiltas:AnyAdamHead");
			recipe.AddIngredient(ItemID.AdamantiteBreastplate);
			recipe.AddIngredient(ItemID.AdamantiteLeggings);
			recipe.AddIngredient(ItemID.SkyFracture);
			recipe.AddIngredient(ItemID.NimbusRod);
			recipe.AddIngredient(ItemID.BookStaff);
			recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
		}
	}	
}
		
>>>>>>> 66ed39caf4938fca8e7009752b635e42f8a8a58f
