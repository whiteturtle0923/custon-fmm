using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons
{
	public class FleshyDoll : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fleshy Doll");
			Tooltip.SetDefault("Summons the Wall of Flesh \nMake sure you use it in the underworld");
		}
		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.maxStack = 20;
			item.value = 1000;
			item.rare = 0;
			item.useAnimation = 30;
			item.useTime = 30;
			item.useStyle = 4;
			item.consumable = true;
		}

		public override bool CanUseItem(Player player)
		{
			
		
            if ((int)(player.position.Y / 16) > Main.maxTilesY - 200 )
            {
                return true;
            }
            else
            {
                return false;
            }
		
		}

		public override bool UseItem(Player player)
		{
			NPC.SpawnWOF(player.Center);
			
			Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
			return true;
		}

		  public override void AddRecipes()  
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GuideVoodooDoll);    			
			recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);  
            recipe.AddRecipe();
        }
		
	}
}