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
			item.maxStack = 20;
			item.value = 1000;
			item.rare = 1;
			item.useAnimation = 30;
			item.useTime = 30;
			item.useStyle = 4;
			item.consumable = true;
			
		}

		public override bool UseItem(Player player)
		{
			Fargowiltas.instance.multiSlime = true;
			Fargowiltas.slime100 = 0;
		
			for(int i = 0; i < 10; i++)
			{
				
				NPC.NewNPC((int)player.position.X + Main.rand.Next(-1000, 1000), (int)player.position.Y + Main.rand.Next(-1000, -400), NPCID.KingSlime);
				//Main.NewText("KingSlime has awoken!", 175, 75, 255);
			}
			
			Main.NewText("Welcome to the true slime rain!", 175, 75, 255);
			
			Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
			return true;
		}
		
		public override void AddRecipes()
		{	
			if(Main.hardMode)
			{
				ModRecipe recipe = new ModRecipe(mod);
			
				recipe.AddIngredient(ItemID.SlimeCrown);
				recipe.AddIngredient(null, "Overloader");
			
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult(this);
				recipe.AddRecipe();
			}
		}

	}
}