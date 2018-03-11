<<<<<<< HEAD
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons
{
	public class OverloadEye : ModItem
	{		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Eyemalgamation");
			Tooltip.SetDefault("Summons several Eyes of Cthulhu");
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
		
		public override bool CanUseItem(Player player)
		{
			return Main.dayTime != true;
		}

		public override bool UseItem(Player player)
		{
			Fargowiltas.eyeNum = 10 * player.inventory[player.selectedItem].stack;
			
			player.inventory[player.selectedItem].stack = 0;
			
			Fargowiltas.eyeKills = 0;
			
			if(Fargowiltas.eyeNum <= 20)
			{
				Fargowiltas.eyeSpawned = Fargowiltas.eyeNum;
			}
			else if(Fargowiltas.eyeNum <= 100)
			{
				Fargowiltas.eyeSpawned = 20;
				Fargowiltas.instance.multiEye = true;
			}
			else if(Fargowiltas.eyeNum != 1000)
			{
				Fargowiltas.eyeSpawned = 50;
				Fargowiltas.instance.multiEye = true;
			}
			else
			{
				Fargowiltas.eyeSpawned = 100;
				Fargowiltas.instance.multiEye = true;
			}
			
			for(int i = 0; i < Fargowiltas.eyeSpawned; i++)
			{
				NPC.NewNPC((int)player.position.X + Main.rand.Next(-1000, 1000), (int)player.position.Y + Main.rand.Next(-1000, -400), NPCID.EyeofCthulhu);
			}
			
			Main.NewText("Countless eyes pierce the veil staring in your direction!", 175, 75, 255);
			
			Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
			return true;
		}
		
		public override void AddRecipes()
		{	
				ModRecipe recipe = new ModRecipe(mod);
			
				recipe.AddIngredient(null, "SuspiciousEye");
				recipe.AddIngredient(null, "Overloader");
				
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult(this);
				recipe.AddRecipe();
		}
	}
=======
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons
{
	public class OverloadEye : ModItem
	{		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Eyemalgamation");
			Tooltip.SetDefault("Summons several Eyes of Cthulhu");
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
		
		public override bool CanUseItem(Player player)
		{
			return Main.dayTime != true;
		}

		public override bool UseItem(Player player)
		{
			Fargowiltas.eyeNum = 10 * player.inventory[player.selectedItem].stack;
			
			player.inventory[player.selectedItem].stack = 0;
			
			Fargowiltas.eyeKills = 0;
			
			if(Fargowiltas.eyeNum <= 20)
			{
				Fargowiltas.eyeSpawned = Fargowiltas.eyeNum;
			}
			else if(Fargowiltas.eyeNum <= 100)
			{
				Fargowiltas.eyeSpawned = 20;
				Fargowiltas.instance.multiEye = true;
			}
			else if(Fargowiltas.eyeNum != 1000)
			{
				Fargowiltas.eyeSpawned = 50;
				Fargowiltas.instance.multiEye = true;
			}
			else
			{
				Fargowiltas.eyeSpawned = 100;
				Fargowiltas.instance.multiEye = true;
			}
			
			for(int i = 0; i < Fargowiltas.eyeSpawned; i++)
			{
				NPC.NewNPC((int)player.position.X + Main.rand.Next(-1000, 1000), (int)player.position.Y + Main.rand.Next(-1000, -400), NPCID.EyeofCthulhu);
			}
			
			Main.NewText("Countless eyes pierce the veil staring in your direction!", 175, 75, 255);
			
			Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
			return true;
		}
		
		public override void AddRecipes()
		{	
				ModRecipe recipe = new ModRecipe(mod);
			
				recipe.AddIngredient(null, "SuspiciousEye");
				recipe.AddIngredient(null, "Overloader");
				
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult(this);
				recipe.AddRecipe();
		}
	}
>>>>>>> 66ed39caf4938fca8e7009752b635e42f8a8a58f
}