using Microsoft.Xna.Framework;
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

            if (Main.netMode != 1)
                Tooltip.SetDefault("Reveals the whole map");
            else
                Tooltip.SetDefault("Reveals an area of the map around you");
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
            item.consumable = false;
        }

        public override string Texture => "Terraria/Map_4";

        public override bool UseItem(Player player)
        {
            if (Main.netMode != 1)
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
            }
            else
            {
                Point center = Main.player[Main.myPlayer].Center.ToTileCoordinates();

                int range = 300;

                for (int i = center.X - range / 2; i < center.X + range / 2; i++)
                {
                    for (int j = center.Y - range / 2; j < center.Y + range / 2; j++)
                    {
                        if (WorldGen.InWorld(i, j))
                            Main.Map.Update(i, j, 255);
                    }
                }
                Main.refreshMap = true;
            }

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