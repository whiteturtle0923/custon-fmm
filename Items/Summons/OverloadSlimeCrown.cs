<<<<<<< HEAD
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons
{
	public class OverloadSlimeCrown : ModItem
	{		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Swarm Crown");
			Tooltip.SetDefault("Summons several King Slimes");
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
			Fargowiltas.slimeNum = 10 * player.inventory[player.selectedItem].stack;
			
			player.inventory[player.selectedItem].stack = 0;
			
			Fargowiltas.slimeKills = 0;
			
			if(Fargowiltas.slimeNum <= 20)
			{
				Fargowiltas.slimeSpawned = Fargowiltas.slimeNum;
			}
			else if(Fargowiltas.slimeNum <= 100)
			{
				Fargowiltas.slimeSpawned = 20;
				Fargowiltas.instance.multiSlime = true;
			}
			else if(Fargowiltas.slimeNum != 1000)
			{
				Fargowiltas.slimeSpawned = 50;
				Fargowiltas.instance.multiSlime = true;
			}
			else
			{
				Fargowiltas.slimeSpawned = 100;
				Fargowiltas.instance.multiSlime = true;
			}
			
			for(int i = 0; i < Fargowiltas.slimeSpawned; i++)
			{
				NPC.NewNPC((int)player.position.X + Main.rand.Next(-1000, 1000), (int)player.position.Y + Main.rand.Next(-1000, -400), NPCID.KingSlime);
			}
			
			Main.NewText("Welcome to the true slime rain!", 175, 75, 255);
			
			Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
			return true;
		}
		
		public override void AddRecipes()
		{	
				ModRecipe recipe = new ModRecipe(mod);

				recipe.AddIngredient(null, "SlimyCrown");
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
	public class OverloadSlimeCrown : ModItem
	{		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Swarm Crown");
			Tooltip.SetDefault("Summons several King Slimes");
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
			Fargowiltas.slimeNum = 10 * player.inventory[player.selectedItem].stack;
			
			player.inventory[player.selectedItem].stack = 0;
			
			Fargowiltas.slimeKills = 0;
			
			if(Fargowiltas.slimeNum <= 20)
			{
				Fargowiltas.slimeSpawned = Fargowiltas.slimeNum;
			}
			else if(Fargowiltas.slimeNum <= 100)
			{
				Fargowiltas.slimeSpawned = 20;
				Fargowiltas.instance.multiSlime = true;
			}
			else if(Fargowiltas.slimeNum != 1000)
			{
				Fargowiltas.slimeSpawned = 50;
				Fargowiltas.instance.multiSlime = true;
			}
			else
			{
				Fargowiltas.slimeSpawned = 100;
				Fargowiltas.instance.multiSlime = true;
			}
			
			for(int i = 0; i < Fargowiltas.slimeSpawned; i++)
			{
				NPC.NewNPC((int)player.position.X + Main.rand.Next(-1000, 1000), (int)player.position.Y + Main.rand.Next(-1000, -400), NPCID.KingSlime);
			}
			
			Main.NewText("Welcome to the true slime rain!", 175, 75, 255);
			
			Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
			return true;
		}
		
		public override void AddRecipes()
		{	
				ModRecipe recipe = new ModRecipe(mod);

				recipe.AddIngredient(null, "SlimyCrown");
				recipe.AddIngredient(null, "Overloader");
				
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult(this);
				recipe.AddRecipe();
		}
	}
>>>>>>> 66ed39caf4938fca8e7009752b635e42f8a8a58f
}