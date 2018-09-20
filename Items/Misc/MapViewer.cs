using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons
{
    public class MapViewer : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Ancient Master's Map of the Lost King's Great Ancestors");
            Tooltip.SetDefault("Reveals the whole map");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 1;
            item.value = 1000;
            item.rare = 0;
            item.useAnimation = 30;
            item.useTime = 30;
            item.useStyle = 4;
            item.consumable = true;
        }

        public override string Texture => "Terraria/Map_4";

        public override bool UseItem(Player player)
        {
            for (int i = 0; i < Main.maxTilesX; i++)
            {
                for (int j = 0; j < Main.maxTilesY; j++)
                {
                    if (WorldGen.InWorld(i, j))
                        Main.Map.Update(i, j, 255);
                }
            }

            Main.refreshMap = true;
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TrifoldMap);
            recipe.AddIngredient(ItemID.Goggles, 30);
            recipe.AddIngredient(ItemID.Sunglasses, 5);
            recipe.AddIngredient(ItemID.SuspiciousLookingEye, 20);
            recipe.AddIngredient(ItemID.MechanicalEye, 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}