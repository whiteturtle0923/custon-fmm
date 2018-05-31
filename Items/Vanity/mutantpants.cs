using Terraria.ModLoader;
using Terraria.ID;

namespace Fargowiltas.Items.Vanity
{
	[AutoloadEquip(EquipType.Legs)]
	public class MutantPants : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mutant Pants");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.vanity = true;
			item.rare = 1;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BeeMask);
			recipe.AddIngredient(ItemID.PlanteraMask);
            recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}