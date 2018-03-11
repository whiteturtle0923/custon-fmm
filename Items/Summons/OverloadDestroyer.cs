using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons
{
	public class OverloadDestroyer : ModItem
	{		
	public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Seismic Actuator");
			Tooltip.SetDefault("Summons several Destroyers");
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
			Fargowiltas.destroyNum = 10 * player.inventory[player.selectedItem].stack;
			
			player.inventory[player.selectedItem].stack = 0;
			
			Fargowiltas.destroyKills = 0;
			
			if(Fargowiltas.destroyNum <= 20)
			{
				Fargowiltas.destroySpawned = Fargowiltas.destroyNum;
			}
			else if(Fargowiltas.destroyNum <= 100)
			{
				Fargowiltas.destroySpawned = 20;
				Fargowiltas.instance.multiDestroy = true;
			}
			else if(Fargowiltas.destroyNum != 1000)
			{
				Fargowiltas.destroySpawned = 50;
				Fargowiltas.instance.multiDestroy = true;
			}
			else
			{
				Fargowiltas.destroySpawned = 65;
				Fargowiltas.instance.multiDestroy = true;
			}
			
			for(int i = 0; i < Fargowiltas.destroySpawned; i++)
			{
				NPC.NewNPC((int)player.position.X + Main.rand.Next(-1000, 1000), (int)player.position.Y + Main.rand.Next(-1000, -400), NPCID.TheDestroyer);
			}

			Main.NewText("The planet trembles from the core!", 175, 75, 255);
			
			Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
			return true;
		}
		
		public override void AddRecipes()
		{	
			ModRecipe recipe = new ModRecipe(mod);
			
			recipe.AddIngredient(null, "MechWorm");
			recipe.AddIngredient(null, "Overloader");
			
			recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
		}
	}
}