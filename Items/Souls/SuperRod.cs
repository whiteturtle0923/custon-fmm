using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;

namespace Fargowiltas.Items.Souls
{
	public class SuperRod : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Super Rod Attachment");
			Tooltip.SetDefault("'As long as they aren't all shoes, you can go home happily' \n" +
								"Increases fishing skill\n" +
								"All fishing rods will have 4 extra lures" );
		}
		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.accessory = true;
			item.value = 100000; 
			item.rare = 5; 
		}
		public override string Texture
		{
			get
			{
				return "Fargowiltas/Items/Placeholder";
			}
		}
		
		public override void UpdateAccessory(Player player, bool hideVisual)
        {
		  ((FargoPlayer)player.GetModPlayer(mod, "FargoPlayer")).fishSoul1 = true;
		   
		  player.fishingSkill += 10;
        }
		
		public override void AddRecipes()
        {
			//too much hmm
            ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.WoodFishingPole);
			recipe.AddIngredient(ItemID.FiberglassFishingPole);
			recipe.AddIngredient(ItemID.ArmoredCavefish);
			recipe.AddIngredient(ItemID.DoubleCod);
			recipe.AddIngredient(ItemID.FrostMinnow);
			recipe.AddIngredient(ItemID.Honeyfin);
			recipe.AddIngredient(ItemID.Salmon);
			recipe.AddIngredient(ItemID.GoldenCarp);
			recipe.AddIngredient(ItemID.Prismite);
			recipe.AddIngredient(ItemID.Rockfish);
			recipe.AddIngredient(ItemID.SawtoothShark);
			recipe.AddIngredient(ItemID.ReaverShark);
			recipe.AddTile(TileID.CookingPots);
            recipe.SetResult(this);
            recipe.AddRecipe();
		}
		
	}
}


