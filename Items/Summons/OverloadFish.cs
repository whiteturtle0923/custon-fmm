<<<<<<< HEAD
using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;

namespace Fargowiltas.Items.Summons
{
	public class OverloadFish : ModItem
	{		
	public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Truffle Worm Clump");
			Tooltip.SetDefault("Summons several Duke Fishrons");
		}
		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.maxStack = 100;
			item.value = 1000;
			item.rare = 1;
			item.useAnimation = 30;
			item.useTime = 30;
			item.useStyle = 4;
			item.consumable = true;
		}

		public override bool UseItem(Player player)
		{
			Fargowiltas.fishNum = 10 * player.inventory[player.selectedItem].stack;
			
			player.inventory[player.selectedItem].stack = 0;
			
			Fargowiltas.fishKills = 0;
			
			if(Fargowiltas.fishNum <= 20)
			{
				Fargowiltas.fishSpawned = Fargowiltas.fishNum;
			}
			else if(Fargowiltas.fishNum <= 100)
			{
				Fargowiltas.fishSpawned = 20;
				Fargowiltas.instance.multiFish = true;
			}
			else if(Fargowiltas.fishNum != 1000)
			{
				Fargowiltas.fishSpawned = 50;
				Fargowiltas.instance.multiFish = true;
			}
			else
			{
				Fargowiltas.fishSpawned = 100;
				Fargowiltas.instance.multiFish = true;
			}
			
			for(int i = 0; i < Fargowiltas.fishSpawned; i++)
			{
				NPC.NewNPC((int)player.position.X + Main.rand.Next(-1000, 1000), (int)player.position.Y + Main.rand.Next(-1000, -400), NPCID.DukeFishron);
			}
			
			Main.NewText("The ocean swells with ferocious pigs!", 175, 75, 255);
			
			Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
			return true;
		}
		
		public override void AddRecipes()
		{	
				ModRecipe recipe = new ModRecipe(mod);
			
				recipe.AddIngredient(null, "TruffleWorm2");
				recipe.AddIngredient(null, "Overloader");
				
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult(this);
				recipe.AddRecipe();
		}
	}
=======
using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;

namespace Fargowiltas.Items.Summons
{
	public class OverloadFish : ModItem
	{		
	public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Truffle Worm Clump");
			Tooltip.SetDefault("Summons several Duke Fishrons");
		}
		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.maxStack = 100;
			item.value = 1000;
			item.rare = 1;
			item.useAnimation = 30;
			item.useTime = 30;
			item.useStyle = 4;
			item.consumable = true;
		}

		public override bool UseItem(Player player)
		{
			Fargowiltas.fishNum = 10 * player.inventory[player.selectedItem].stack;
			
			player.inventory[player.selectedItem].stack = 0;
			
			Fargowiltas.fishKills = 0;
			
			if(Fargowiltas.fishNum <= 20)
			{
				Fargowiltas.fishSpawned = Fargowiltas.fishNum;
			}
			else if(Fargowiltas.fishNum <= 100)
			{
				Fargowiltas.fishSpawned = 20;
				Fargowiltas.instance.multiFish = true;
			}
			else if(Fargowiltas.fishNum != 1000)
			{
				Fargowiltas.fishSpawned = 50;
				Fargowiltas.instance.multiFish = true;
			}
			else
			{
				Fargowiltas.fishSpawned = 100;
				Fargowiltas.instance.multiFish = true;
			}
			
			for(int i = 0; i < Fargowiltas.fishSpawned; i++)
			{
				NPC.NewNPC((int)player.position.X + Main.rand.Next(-1000, 1000), (int)player.position.Y + Main.rand.Next(-1000, -400), NPCID.DukeFishron);
			}
			
			Main.NewText("The ocean swells with ferocious pigs!", 175, 75, 255);
			
			Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
			return true;
		}
		
		public override void AddRecipes()
		{	
				ModRecipe recipe = new ModRecipe(mod);
			
				recipe.AddIngredient(null, "TruffleWorm2");
				recipe.AddIngredient(null, "Overloader");
				
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult(this);
				recipe.AddRecipe();
		}
	}
>>>>>>> 66ed39caf4938fca8e7009752b635e42f8a8a58f
}