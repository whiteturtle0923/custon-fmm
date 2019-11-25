using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Renewals
{
    public class CorruptRenewalSupreme : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Corruption Renewal Supreme");
            Tooltip.SetDefault("Corrupts the entire world");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 26;
            item.maxStack = 99;
            item.consumable = true;
            item.useStyle = 1;
            item.rare = 3;
            item.UseSound = SoundID.Item1;
            item.useAnimation = 20;
            item.useTime = 20;
            item.value = Item.buyPrice(0, 0, 3, 0);
            item.noUseGraphic = true;
            item.noMelee = true;
            item.shoot = mod.ProjectileType("CorruptNukeSupremeProj");
            item.shootSpeed = 5f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("CorruptRenewal"), 10);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 5);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}