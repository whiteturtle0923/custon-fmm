using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons
{
	public class OverloadPrime : ModItem
	{		
	public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Primal Control Chip");
			Tooltip.SetDefault("Summons several Skeletron Primes");
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
			Fargowiltas.primeNum = 10 * player.inventory[player.selectedItem].stack;
			
			player.inventory[player.selectedItem].stack = 0;
			
			Fargowiltas.primeKills = 0;
			
			if(Fargowiltas.primeNum <= 20)
			{
				Fargowiltas.primeSpawned = Fargowiltas.primeNum;
			}
			else if(Fargowiltas.primeNum <= 100)
			{
				Fargowiltas.primeSpawned = 20;
				Fargowiltas.instance.multiPrime = true;
			}
			else
			{
				Fargowiltas.primeSpawned = 40;
				Fargowiltas.instance.multiPrime = true;
			}
			
			for(int i = 0; i < Fargowiltas.primeSpawned; i++)
			{
				NPC.NewNPC((int)player.position.X + Main.rand.Next(-1000, 1000), (int)player.position.Y + Main.rand.Next(-1000, -400), NPCID.SkeletronPrime);
			}

			Main.NewText("A sickly chill envelops the world!", 175, 75, 255);
			
			Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
			return true;
		}
		
		public override void AddRecipes()
		{	
			ModRecipe recipe = new ModRecipe(mod);
			
			recipe.AddIngredient(null, "MechSkull");
			recipe.AddIngredient(null, "Overloader");
			
			recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
		}
	}
}