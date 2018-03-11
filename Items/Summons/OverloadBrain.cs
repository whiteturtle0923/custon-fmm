using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons
{
	public class OverloadBrain : ModItem
	{		
	public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Brain Storm");
			Tooltip.SetDefault("Summons several Brains of Cthulhu");
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
			return player.ZoneCrimson;
		}

		public override bool UseItem(Player player)
		{
			Fargowiltas.brainNum = 10 * player.inventory[player.selectedItem].stack;
			
			player.inventory[player.selectedItem].stack = 0;
			
			Fargowiltas.brainKills = 0;
			
			if(Fargowiltas.brainNum <= 20)
			{
				Fargowiltas.brainSpawned = Fargowiltas.brainNum;
			}
			else if(Fargowiltas.brainNum <= 100)
			{
				Fargowiltas.brainSpawned = 20;
				Fargowiltas.instance.multiBrain = true;
			}
			else if(Fargowiltas.brainNum != 1000)
			{
				Fargowiltas.brainSpawned = 50;
				Fargowiltas.instance.multiBrain = true;
			}
			else
			{
				Fargowiltas.brainSpawned = 100;
				Fargowiltas.instance.multiBrain = true;
			}
			
			for(int i = 0; i < Fargowiltas.brainSpawned; i++)
			{
				NPC.NewNPC((int)player.position.X + Main.rand.Next(-1000, 1000), (int)player.position.Y + Main.rand.Next(-1000, -400), NPCID.BrainofCthulhu);
			}
			
			Main.NewText("You feel dumb among so many brains!", 175, 75, 255);
			
			Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
			return true;
		}
		
		public override void AddRecipes()
		{	
			ModRecipe recipe = new ModRecipe(mod);
			
			recipe.AddIngredient(null, "GoreySpine");
			recipe.AddIngredient(null, "Overloader");
			
			recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
		}	
	}
}