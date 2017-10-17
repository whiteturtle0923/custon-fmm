using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons
{
	public class OverloadPlant : ModItem
	{		
	public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Heart of the Jungle");
			Tooltip.SetDefault("Summons several Planteras");
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
			Fargowiltas.plantNum = 10 * player.inventory[player.selectedItem].stack;
			
			player.inventory[player.selectedItem].stack = 0;
			
			Fargowiltas.plantKills = 0;
			
			if(Fargowiltas.plantNum <= 20)
			{
				Fargowiltas.plantSpawned = Fargowiltas.plantNum;
			}
			else if(Fargowiltas.plantNum <= 100)
			{
				Fargowiltas.plantSpawned = 20;
				Fargowiltas.instance.multiPlant = true;
			}
			else if(Fargowiltas.plantNum != 1000)
			{
				Fargowiltas.plantSpawned = 50;
				Fargowiltas.instance.multiPlant = true;
			}
			else
			{
				Fargowiltas.plantSpawned = 100;
				Fargowiltas.instance.multiPlant = true;
			}
			
			for(int i = 0; i < Fargowiltas.plantSpawned; i++)
			{
				NPC.NewNPC((int)player.position.X + Main.rand.Next(-1000, 1000), (int)player.position.Y + Main.rand.Next(-1000, -400), NPCID.Plantera);
				Main.NewText("Plantera has awoken!", 175, 75, 255);
			}
			
			Main.NewText("The jungle beats as one!", 175, 75, 255);
			
			Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
			return true;
		}
		
		public override void AddRecipes()
		{	
			ModRecipe recipe = new ModRecipe(mod);
			
			recipe.AddIngredient(null, "Plantera");
			recipe.AddIngredient(null, "Overloader");
			
			recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
		}
	}
}