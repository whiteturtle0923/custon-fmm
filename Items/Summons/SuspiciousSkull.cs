using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons
{
	public class SuspiciousSkull : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Suspicious Skull");
			Tooltip.SetDefault("Summons Skeletron without killing the Clothier\n" +
								"Summons the Dungeon Guardian during the day");
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
		
		public override bool UseItem(Player player)
		{
			if(!Main.dayTime)
			{
				NPC.NewNPC((int)player.position.X + Main.rand.Next(-800, 800), (int)player.position.Y + Main.rand.Next(-1000, -250), NPCID.SkeletronHead);
				Main.NewText("Skeletron has awoken!", 175, 75, 255);
			}
			else
			{
				NPC.NewNPC((int)player.position.X + Main.rand.Next(-800, 800), (int)player.position.Y + Main.rand.Next(-1000, -250), NPCID.DungeonGuardian);
				Main.NewText("Dungeon Guardian has awoken!", 175, 75, 255);
			}
			
			Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
			return true;
		}
		
		public override void AddRecipes()
		{
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ClothierVoodooDoll);
			recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
		}	
	}
}