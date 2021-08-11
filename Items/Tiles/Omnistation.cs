using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Tiles
{
    public class Omnistation : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Omnistation");
            Tooltip.SetDefault(@"Effects of all vanilla buff stations
Grants Honey when touched
Right click while holding a weapon for its respective buff");
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.rare = ItemRarityID.Blue;
            Item.createTile = ModContent.TileType<OmnistationSheet>();
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Sunflower, 20)
                .AddIngredient(ItemID.Campfire, 20)
                .AddIngredient(ItemID.HeartLantern, 20)
                .AddIngredient(ItemID.StarinaBottle, 20)
                .AddIngredient(ItemID.HoneyBucket, 20)
                .AddIngredient(ItemID.SharpeningStation, 5)
                .AddIngredient(ItemID.AmmoBox, 5)
                .AddIngredient(ItemID.CrystalBall, 5)
                .AddIngredient(ItemID.BewitchingTable, 5)
                .AddIngredient(ItemID.AdamantiteBar, 5)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}