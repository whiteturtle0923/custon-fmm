using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Tiles
{
    public abstract class BaseOmnistation : ModItem
    {
        protected int bar;

        public BaseOmnistation(int bar)
        {
            this.bar = bar;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Omnistation");
            Tooltip.SetDefault(@"Effects of all vanilla buff stations
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
                .AddIngredient(ItemID.GardenGnome, 5)
                .AddIngredient(ItemID.CatBast, 5)
                .AddIngredient(ItemID.SliceOfCake, 5)
                .AddIngredient(ItemID.GoldLadyBug, 5)
                .AddIngredient(bar, 5)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }

    public class Omnistation : BaseOmnistation
    {
        public Omnistation() : base(ItemID.AdamantiteBar) { }
    }

    public class Omnistation2 : BaseOmnistation
    {
        public Omnistation2() : base(ItemID.TitaniumBar) { }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.createTile = ModContent.TileType<OmnistationSheet2>();
        }
    }
}