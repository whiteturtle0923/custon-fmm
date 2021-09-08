using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;

namespace Fargowiltas.Items.Tiles
{
    public class UnsafeWall : ModItem
    {
        private readonly string name;
        private readonly int createWall;
        private readonly int wall;
        private readonly int tile;

        protected UnsafeWall(string name, int createWall, int wall = -1, int tile = -1)
        {
            this.name = name;
            this.createWall = createWall;
            this.wall = wall;
            this.tile = wall;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault(name);
            Tooltip.SetDefault("Allows area-specific enemies to spawn");
        }

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 14;
            Item.rare = ItemRarityID.White;
            Item.maxStack = 999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.createWall = createWall;
        }

        public override void AddRecipes()
        {
            if (wall != -1)
            {
                var recipe = Mod.CreateRecipe(Type);
                recipe.AddIngredient(wall);
                recipe.AddTile(TileID.WorkBenches);
            }
            if (tile != -1)
            {
                var recipe = Mod.CreateRecipe(Type, 4);
                recipe.AddIngredient(tile);
                recipe.AddTile(TileID.WorkBenches);
            }
        }
    }

    public class UnsafeBlueSlabWall : UnsafeWall
    {
        public UnsafeBlueSlabWall() : base("Unsafe Blue Slab Wall", WallID.BlueDungeonSlabUnsafe) { }
    }

    public class UnsafeBlueTileWall : UnsafeWall
    {
        public UnsafeBlueTileWall() : base("Unsafe Blue Slab Wall", WallID.BlueDungeonTileUnsafe) { }
    }

    public class UnsafeBlueBrickWall : UnsafeWall
    {
        public UnsafeBlueBrickWall() : base("Unsafe Blue Brick Wall", WallID.BlueDungeonUnsafe) { }
    }

    public class UnsafeGreenSlabWall : UnsafeWall
    {
        public UnsafeGreenSlabWall() : base("Unsafe Green Slab Wall", WallID.GreenDungeonSlabUnsafe) { }
    }

    public class UnsafeGreenTileWall : UnsafeWall
    {
        public UnsafeGreenTileWall() : base("Unsafe Green Slab Wall", WallID.GreenDungeonTileUnsafe) { }
    }

    public class UnsafeGreenBrickWall : UnsafeWall
    {
        public UnsafeGreenBrickWall() : base("Unsafe Green Brick Wall", WallID.GreenDungeonUnsafe) { }
    }

    public class UnsafePinkSlabWall : UnsafeWall
    {
        public UnsafePinkSlabWall() : base("Unsafe Pink Slab Wall", WallID.PinkDungeonSlabUnsafe) { }
    }

    public class UnsafePinkTileWall : UnsafeWall
    {
        public UnsafePinkTileWall() : base("Unsafe Pink Slab Wall", WallID.PinkDungeonTileUnsafe) { }
    }

    public class UnsafePinkBrickWall : UnsafeWall
    {
        public UnsafePinkBrickWall() : base("Unsafe Pink Brick Wall", WallID.PinkDungeonUnsafe) { }
    }

    public class UnsafeLihzahrdBrickWall : UnsafeWall
    {
        public UnsafeLihzahrdBrickWall() : base("Unsafe Lihzahrd Brick Wall", WallID.LihzahrdBrickUnsafe, ItemID.LihzahrdBrickWall, ItemID.LihzahrdBrick) { }
    }

    public class UnsafeSpiderWall : UnsafeWall
    {
        public UnsafeSpiderWall() : base("Unsafe Spider Wall", WallID.SpiderUnsafe, ItemID.SpiderEcho) { }
    }

    public class UnsafeMarbleWall : UnsafeWall
    {
        public UnsafeMarbleWall() : base("Unsafe Marble Wall", WallID.MarbleUnsafe, ItemID.MarbleWall, ItemID.Marble) { }
    }

    public class UnsafeGraniteWall : UnsafeWall
    {
        public UnsafeGraniteWall() : base("Unsafe Granite Wall", WallID.GraniteUnsafe, ItemID.GraniteWall, ItemID.Granite) { }
    }
}