using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Vanity
{
    [AutoloadEquip(EquipType.Legs)]
    public class DevianttPants : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Deviantt Pants");
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
            //eeeee


            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TopHat);
            recipe.AddIngredient(ItemID.ChristmasHook); 
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
