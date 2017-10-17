using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons
{
	public class OverloadMoon : ModItem
	{		
	public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Runic Inscription ");
			Tooltip.SetDefault("Summons several Moon Lords");
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
			Fargowiltas.moonNum = 10 * player.inventory[player.selectedItem].stack;
			
			player.inventory[player.selectedItem].stack = 0;
			
			Fargowiltas.moonKills = 0;
			
			if(Fargowiltas.moonNum <= 20)
			{
				Fargowiltas.moonSpawned = Fargowiltas.moonNum;
			}
			else if(Fargowiltas.moonNum <= 100)
			{
				Fargowiltas.moonSpawned = 20;
				Fargowiltas.instance.multiMoon = true;
			}
			else if(Fargowiltas.moonNum != 1000)
			{
				Fargowiltas.moonSpawned = 50;
				Fargowiltas.instance.multiMoon = true;
			}
			else
			{
				Fargowiltas.moonSpawned = 100;
				Fargowiltas.instance.multiMoon = true;
			}
			
			for(int i = 0; i < Fargowiltas.moonSpawned; i++)
			{
				NPC.NewNPC((int)player.position.X + Main.rand.Next(-1000, 1000), (int)player.position.Y + Main.rand.Next(-1000, -400), NPCID.MoonLordCore);
				Main.NewText("Moon Lord has awoken!", 175, 75, 255);
			}
	
			Main.NewText("The wind whispers of death's approach!", 175, 75, 255);
			
			Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
			return true;
		}
		
		public override void AddRecipes()
		{	
			ModRecipe recipe = new ModRecipe(mod);
			
			recipe.AddIngredient(null, "CelestialSigil2");
			recipe.AddIngredient(null, "Overloader");
			
			recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
		}
	}
}