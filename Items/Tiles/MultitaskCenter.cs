using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Tiles
{
    public class MultitaskCenter : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Multitask Center");
            Tooltip.SetDefault("Functions as several basic crafting stations");
        }

        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 14;
            item.maxStack = 99;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.createTile = mod.TileType("MultitaskCenterSheet");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ItemID.WorkBench);
            recipe.AddIngredient(ItemID.HeavyWorkBench);
            recipe.AddIngredient(ItemID.Furnace);
            recipe.AddRecipeGroup("Fargowiltas:AnyAnvil");
            recipe.AddIngredient(ItemID.Bottle);
            recipe.AddIngredient(ItemID.Sawmill);
            recipe.AddIngredient(ItemID.Loom);
            recipe.AddIngredient(ItemID.WoodenTable);
            recipe.AddIngredient(ItemID.WoodenChair);
            recipe.AddRecipeGroup("Fargowiltas:AnyCookingPot");
            recipe.AddIngredient(ItemID.WoodenSink);
            recipe.AddIngredient(ItemID.Keg);
            recipe.AddTile(TileID.DemonAltar);

            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}