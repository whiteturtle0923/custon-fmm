using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Ammos.Arrows
{
    public class HolyQuiver : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Endless Holy Quiver");
            Tooltip.SetDefault("Summons falling stars on impact");
        }

        public override void SetDefaults()
        {
            item.shootSpeed = 3.5f;
            item.shoot = ProjectileID.HolyArrow;
            item.damage = 13;
            item.width = 26;
            item.height = 26;
            item.ranged = true;
            item.ammo = AmmoID.Arrow;
            item.knockBack = 2f;
            item.rare = 4;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HolyArrow, 3996);
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}