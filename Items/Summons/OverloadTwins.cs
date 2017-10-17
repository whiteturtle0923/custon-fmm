using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons
{
	public class OverloadTwins : ModItem
	{		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Omnifocal Lens");
			Tooltip.SetDefault("Summons several sets of Twins");
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
			return Main.dayTime != true;
		}

		public override bool UseItem(Player player)
		{
			Fargowiltas.twinsNum = 10 * player.inventory[player.selectedItem].stack;
			
			player.inventory[player.selectedItem].stack = 0;
			
			Fargowiltas.spazKills = 0;
			Fargowiltas.retKills = 0;
			
			if(Fargowiltas.twinsNum <= 20)
			{
				Fargowiltas.twinsSpawned = Fargowiltas.twinsNum;
			}
			else if(Fargowiltas.twinsNum <= 100)
			{
				Fargowiltas.twinsSpawned = 20;
				Fargowiltas.instance.multiTwins = true;
			}
			else if(Fargowiltas.twinsNum != 1000)
			{
				Fargowiltas.twinsSpawned = 50;
				Fargowiltas.instance.multiTwins = true;
			}
			else
			{
				Fargowiltas.twinsSpawned = 100;
				Fargowiltas.instance.multiTwins = true;
			}
			
			for(int i = 0; i < Fargowiltas.twinsSpawned; i++)
			{
				NPC.SpawnOnPlayer(player.whoAmI, NPCID.Retinazer);
				NPC.SpawnOnPlayer(player.whoAmI, NPCID.Spazmatism);
			}
			
			Main.NewText("A legion of glowing iris sing a dreadful song.", 175, 75, 255);
			
			Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
			return true;
		}
		
		public override void AddRecipes()
		{	
			ModRecipe recipe = new ModRecipe(mod);
			
			recipe.AddIngredient(null, "MechEye");
			recipe.AddIngredient(null, "Overloader");
			
			recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
		}
	}
}