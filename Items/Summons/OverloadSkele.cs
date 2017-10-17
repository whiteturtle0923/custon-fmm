using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons
{
	public class OverloadSkele : ModItem
	{		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Skull Chain Necklace");
			Tooltip.SetDefault("Summons several Skeletrons");
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
			Fargowiltas.skeleNum = 10 * player.inventory[player.selectedItem].stack;
			
			player.inventory[player.selectedItem].stack = 0;
			
			Fargowiltas.skeleKills = 0;
			
			if(Fargowiltas.skeleNum <= 20)
			{
				Fargowiltas.skeleSpawned = Fargowiltas.skeleNum;
			}
			else if(Fargowiltas.skeleNum <= 100)
			{
				Fargowiltas.skeleSpawned = 20;
				Fargowiltas.instance.multiSkele = true;
			}
			else if(Fargowiltas.skeleNum != 1000)
			{
				Fargowiltas.skeleSpawned = 50;
				Fargowiltas.instance.multiSkele = true;
			}
			else
			{
				Fargowiltas.skeleSpawned = 65;
				Fargowiltas.instance.multiSkele = true;
			}
			
			for(int i = 0; i < Fargowiltas.skeleSpawned; i++)
			{
				NPC.NewNPC((int)player.position.X + Main.rand.Next(-1000, 1000), (int)player.position.Y + Main.rand.Next(-800, -400), NPCID.SkeletronHead);
			}
			
			Main.NewText("A great clammering of bones rises from the dungeon!", 175, 75, 255);
			
			Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
			return true;
		}
		
		public override void AddRecipes()
		{	
				ModRecipe recipe = new ModRecipe(mod);

				recipe.AddIngredient(null, "SuspiciousSkull");
				recipe.AddIngredient(null, "Overloader");
				
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult(this);
				recipe.AddRecipe();
		}
	}
}