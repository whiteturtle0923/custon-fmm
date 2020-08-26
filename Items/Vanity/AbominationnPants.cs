using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Vanity
{
    [AutoloadEquip(EquipType.Legs)]
    public class AbominationnPants : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Abominationn Pants");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.vanity = true;
            item.rare = ItemRarityID.Blue;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TreeTrunks);
            recipe.AddIngredient(ItemID.FallenTuxedoPants);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
