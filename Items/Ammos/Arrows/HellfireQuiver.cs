using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Ammos.Arrows
{
    public class HellfireQuiver : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Endless Hellfire Quiver");
        }

        public override void SetDefaults()
        {
            item.shootSpeed = 6.5f;
            item.shoot = ProjectileID.HellfireArrow;
            item.damage = 13;
            item.width = 26;
            item.height = 26;
            item.ranged = true;
            item.ammo = AmmoID.Arrow;
            item.knockBack = 8f;
            item.rare = 3;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HellfireArrow, 3996);
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}