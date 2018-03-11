using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons
{
	public class OverloadWorm : ModItem
	{	
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Worm Feast");
			Tooltip.SetDefault("Summons several Eater of Worlds");
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
		public override string Texture
		{
			get
			{
				return "Fargowiltas/Items/Placeholder";
			}
		}
		
		public override bool CanUseItem(Player player)
		{
			return player.ZoneCorrupt;
		}
		
		public override bool UseItem(Player player)
		{
			Fargowiltas.wormNum = 10 * player.inventory[player.selectedItem].stack;
			
			player.inventory[player.selectedItem].stack = 0;
			
			Fargowiltas.wormKills = 0;
			
			if(Fargowiltas.wormNum <= 20)
			{
				Fargowiltas.wormSpawned = Fargowiltas.wormNum;
			}
			else if(Fargowiltas.wormNum <= 100)
			{
				Fargowiltas.wormSpawned = 20;
				Fargowiltas.instance.multiWorm = true;
			}
			else if(Fargowiltas.wormNum != 1000)
			{
				Fargowiltas.wormSpawned = 50;
				Fargowiltas.instance.multiWorm = true;
			}
			else
			{
				Fargowiltas.wormSpawned = 100;
				Fargowiltas.instance.multiWorm = true;
			}
			
			for(int i = 0; i < Fargowiltas.wormSpawned; i++)
			{
				NPC.SpawnOnPlayer(player.whoAmI, NPCID.EaterofWorldsHead);
			}
			
			Main.NewText("The ground shifts with formulated precision!", 175, 75, 255);
			
			Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
			return true;
		}
		
		public override void AddRecipes()
		{	
			ModRecipe recipe = new ModRecipe(mod);
			
			recipe.AddIngredient(null, "WormyFood");
			recipe.AddIngredient(null, "Overloader");
			
			recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
		}
	}
}