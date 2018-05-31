using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Ammos.Arrows
{
    public class IchorQuiver : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Endless Ichor Quiver");
            Tooltip.SetDefault("Decreases target's defense");
        }

        public override void SetDefaults()
        {
            item.shootSpeed = 4.25f;
            item.shoot = ProjectileID.IchorArrow;
            item.damage = 16;
            item.width = 26;
            item.height = 26;
            item.ranged = true;
            item.ammo = AmmoID.Arrow;
            item.knockBack = 3f;
            item.rare = 4;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.IchorArrow, 3996);
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}