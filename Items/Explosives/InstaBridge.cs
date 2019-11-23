using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Explosives
{
    public class Instabridge : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Instabridge");
            Tooltip.SetDefault("Creates a bridge of platforms instantly \nDo not use if any important building is nearby");
        }

        public override void SetDefaults()
        {
            item.damage = 50;
            item.width = 10;
            item.height = 32;
            item.maxStack = 99;
            item.consumable = true;
            item.useStyle = 1;
            item.rare = 2;
            item.UseSound = SoundID.Item1;
            item.useAnimation = 20;
            item.useTime = 20;
            item.value = Item.buyPrice(0, 0, 3);
            item.noUseGraphic = true;
            item.noMelee = true;
            item.shoot = mod.ProjectileType("InstabridgeProj");
            item.shootSpeed = 5f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.WoodPlatform, 1000);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}