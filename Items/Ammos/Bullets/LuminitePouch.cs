using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Ammos.Bullets
{
    public class LuminitePouch : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Endless Luminite Pouch");
            Tooltip.SetDefault("'Line 'em up and knock 'em down...'");
        }

        public override void SetDefaults()
        {
            item.shootSpeed = 2f;
            item.shoot = ProjectileID.MoonlordBullet;
            item.damage = 22;
            item.width = 26;
            item.height = 26;
            item.ranged = true;
            item.ammo = AmmoID.Bullet;
            item.knockBack = 3f;
            item.rare = 10;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MoonlordBullet, 3996);
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}