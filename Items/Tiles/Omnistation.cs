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
            Tooltip.SetDefault(@"Can be reused infinitely
Effects of all vanilla buff stations
Right click while holding a weapon for its respective buff");
            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
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
                .AddIngredient(ItemID.Sunflower, 5)
                .AddIngredient(ItemID.Campfire, 5)
                .AddIngredient(ItemID.HeartLantern, 5)
                .AddIngredient(ItemID.StarinaBottle, 5)
                .AddIngredient(ItemID.HoneyBucket, 5)
                .AddIngredient(ItemID.SharpeningStation, 3)
                .AddIngredient(ItemID.AmmoBox, 3)
                .AddIngredient(ItemID.CrystalBall, 3)
                .AddIngredient(ItemID.BewitchingTable, 3)
                .AddIngredient(ItemID.GardenGnome, 3)
                .AddIngredient(ItemID.CatBast, 3)
                .AddIngredient(ItemID.SliceOfCake, 3)
                .AddIngredient(ItemID.GoldLadyBug, 3)
                .AddIngredient(bar, 10)
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