using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Tiles
{
    public class Omnistation2 : Omnistation
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.createTile = ModContent.TileType<OmnistationSheet2>();
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
               .AddIngredient(ItemID.TitaniumBar, 5)
               .AddTile(TileID.MythrilAnvil)
               .Register();
        }
    }
}