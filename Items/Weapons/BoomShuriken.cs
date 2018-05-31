using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Weapons
{
    public class BoomShuriken : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Boom Shuriken");
        }

        public override void SetDefaults()
        {
            item.width = 11;
            item.height = 11;
            item.damage = 15;
            item.thrown = true;
            item.noMelee = true;
            item.consumable = true;
            item.noUseGraphic = true;
            item.useAnimation = 9;
            item.scale = 0.75f;
            item.crit = 5;
            item.useStyle = 1;
            item.useTime = 13;
            item.knockBack = 3f;
            item.UseSound = SoundID.Item1;
            item.autoReuse = false;
            item.maxStack = 999;
            item.rare = 1;
            item.shoot = mod.ProjectileType("BoomShuriken");
            item.shootSpeed = 11f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Shuriken, 50);
            recipe.AddIngredient(ItemID.Grenade, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 50);
            recipe.AddRecipe();
        }
    }
}