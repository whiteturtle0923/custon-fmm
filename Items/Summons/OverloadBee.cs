using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons
{
	public class OverloadBee : ModItem
	{		
	public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Overstuffed Larva");
			Tooltip.SetDefault("Summons several Queen Bees");
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
			Fargowiltas.beeNum = 10 * player.inventory[player.selectedItem].stack;
			
			player.inventory[player.selectedItem].stack = 0;
			
			Fargowiltas.beeKills = 0;
			
			if(Fargowiltas.beeNum <= 20)
			{
				Fargowiltas.beeSpawned = Fargowiltas.beeNum;
			}
			else if(Fargowiltas.beeNum <= 100)
			{
				Fargowiltas.beeSpawned = 20;
				Fargowiltas.instance.multiBee = true;
			}
			else if(Fargowiltas.beeNum != 1000)
			{
				Fargowiltas.beeSpawned = 50;
				Fargowiltas.instance.multiBee = true;
			}
			else
			{
				Fargowiltas.beeSpawned = 100;
				Fargowiltas.instance.multiBee = true;
			}
			
			for(int i = 0; i < Fargowiltas.beeSpawned; i++)
			{
				NPC.NewNPC((int)player.position.X + Main.rand.Next(-1000, 1000), (int)player.position.Y + Main.rand.Next(-1000, -400), NPCID.QueenBee);
			}
			
			Main.NewText("A deafening buzz pierces through you!", 175, 75, 255);
			
			Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
			return true;
		}
		
		public override void AddRecipes()
		{	
				ModRecipe recipe = new ModRecipe(mod);
				recipe.AddIngredient(null, "Abeemination2");
				recipe.AddIngredient(null, "Overloader");
				
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult(this);
				recipe.AddRecipe();
		}
	}
}