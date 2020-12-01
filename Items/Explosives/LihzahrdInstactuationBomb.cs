using Fargowiltas.Projectiles.Explosives;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Explosives
{
    public class LihzahrdInstactuationBomb : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lihzahrd Instactuation Bomb");
            Tooltip.SetDefault(@"Clears a space around the Lihzahrd Altar
Actuates Lihzahrd Brick and destroys others
Only works in the Jungle Temple and after Plantera is defeated");
        }

        public override void SetDefaults()
        {
            item.width = 10;
            item.height = 32;
            item.maxStack = 99;
            item.consumable = true;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.rare = ItemRarityID.Yellow;
            item.UseSound = SoundID.Item1;
            item.useAnimation = 20;
            item.useTime = 20;
            item.value = Item.buyPrice(0, 0, 3);
            item.noUseGraphic = true;
            item.noMelee = true;
            item.shoot = ModContent.ProjectileType<LihzahrdInstactuationBombProj>();
        }

        private Point FindAltar(Vector2 center)
        {
            int xPos = (int)center.X / 16;
            int yPos = (int)center.Y / 16;
            for (int i = -20; i <= 20; i++)
            {
                for (int j = -20; j <= 20; j++)
                {
                    int tileX = xPos + i;
                    int tileY = yPos + j;
                    if (tileX < 0 || tileX > Main.maxTilesX || tileY < 0 || tileY > Main.maxTilesY)
                        continue;

                    Tile tile = Framing.GetTileSafely(tileX, tileY);
                    if (tile.type == TileID.LihzahrdAltar && tile.wall == WallID.LihzahrdBrickUnsafe)
                    {
                        //proceed until past altar, then offset back to find actual bottom middle
                        for (int k = 0; k < 5; k++)
                        {
                            if (tileX < Main.maxTilesX && Framing.GetTileSafely(tileX, tileY).type == TileID.LihzahrdAltar)
                                tileX++;
                            if (tileY < Main.maxTilesY && Framing.GetTileSafely(tileX, tileY).type == TileID.LihzahrdAltar)
                                tileY++;
                        }

                        tileX -= 2;
                        tileY -= 1;
                        return new Point(tileX, tileY);
                    }
                }
            }

            return new Point(-1, -1);
        }

        public override bool CanUseItem(Player player)
        {
            Point altar = FindAltar(player.Center);
            return altar.X != -1 && altar.Y != -1 && Collision.CanHitLine(player.Center, 0, 0, new Vector2(altar.X * 16, altar.Y * 16), 0, 0);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Point altar = FindAltar(player.Center);
            if (altar.X != -1 && altar.Y != -1 && Collision.CanHitLine(player.Center, 0, 0, new Vector2(altar.X * 16, altar.Y * 16), 0, 0))
            {
                Projectile.NewProjectile(altar.X * 16, altar.Y * 16, 0f, 0f, type, 0, 0, player.whoAmI);
            }
            return false;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Actuator, 500);
            recipe.AddIngredient(ItemID.Dynamite, 25);
            recipe.AddIngredient(ItemID.FossilOre, 20);
            recipe.AddIngredient(ItemID.LunarTabletFragment, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}