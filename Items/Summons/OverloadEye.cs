using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons
{
	public class OverloadEye : ModItem
	{		
	public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Eyemalgamation");
			Tooltip.SetDefault("Summons several Eyes of Cthulhu");
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
		
		public override bool CanUseItem(Player player)
		{
			return Main.dayTime != true;
		}

		public override bool UseItem(Player player)
		{
			Fargowiltas.instance.multiEye = true;
			Fargowiltas.eye100 = 0;
			
			for(int i = 0; i < 10; i++)
			{
				NPC.NewNPC((int)player.position.X + Main.rand.Next(-1000, 1000), (int)player.position.Y + Main.rand.Next(-1000, -400), NPCID.EyeofCthulhu);
				Main.NewText("Eye of Cthulhu has awoken!", 175, 75, 255);
			}
			
			Main.NewText("Countless eyes pierce the veil staring in your direction!", 175, 75, 255);
			
			Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
			return true;
		}
		
		public override void AddRecipes()
		{	
			if(Main.hardMode)
			{
				ModRecipe recipe = new ModRecipe(mod);
			
				recipe.AddIngredient(ItemID.SuspiciousLookingEye);
				recipe.AddIngredient(null, "Overloader");
			
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult(this);
				recipe.AddRecipe();
			}
		}
	
	}
}