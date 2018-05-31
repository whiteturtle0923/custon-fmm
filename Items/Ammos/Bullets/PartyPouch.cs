using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Ammos.Bullets
{
    public class PartyPouch : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Endless Party Pouch");
            Tooltip.SetDefault("Explodes into confetti on impact");
        }

        public override void SetDefaults()
        {
            item.shootSpeed = 5.1f;
            item.shoot = ProjectileID.PartyBullet;
            item.damage = 10;
            item.width = 26;
            item.height = 26;
            item.ranged = true;
            item.ammo = AmmoID.Bullet;
            item.knockBack = 5f;
            item.rare = 4;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PartyBullet, 3996);
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}