using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Ammos.Arrows
{
    public class FlameQuiver : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Endless Flame Quiver");
        }

        public override void SetDefaults()
        {
            item.shootSpeed = 3.5f;
            item.shoot = ProjectileID.FireArrow;
            item.damage = 7;
            item.width = 26;
            item.height = 26;
            item.ranged = true;
            item.ammo = AmmoID.Arrow;
            item.knockBack = 2f;
            item.rare = 2;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FlamingArrow, 3996);
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}