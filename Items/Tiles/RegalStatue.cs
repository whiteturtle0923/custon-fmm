using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Tiles
{
    public class RegalStatue : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Regal Statue");
            Tooltip.SetDefault("Town NPCs respawn extremely quickly when nearby");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.rare = 1;
            item.createTile = mod.TileType("RegalStatueSheet");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.KingStatue);
            recipe.AddIngredient(ItemID.QueenStatue);
            recipe.AddIngredient(ItemID.Bone, 15);
            recipe.AddTile(TileID.HeavyWorkBench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}