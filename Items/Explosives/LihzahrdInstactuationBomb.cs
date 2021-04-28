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
            Tooltip.SetDefault(@"Clears a space around the Lihzahrd Altar when used while standing in front of it
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

        public override bool CanUseItem(Player player)
        {
            Tile tile = Framing.GetTileSafely(player.Center);
            return tile.type == TileID.LihzahrdAltar && tile.wall == WallID.LihzahrdBrickUnsafe && NPC.downedPlantBoss;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Tile tile = Framing.GetTileSafely(player.Center);
            if (tile.type == TileID.LihzahrdAltar && tile.wall == WallID.LihzahrdBrickUnsafe && NPC.downedPlantBoss)
            {
                Projectile.NewProjectile(player.Bottom - Vector2.UnitY * 8f, Vector2.Zero, type, 0, 0, player.whoAmI);
            }
            return false;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Actuator, 500);
            recipe.AddIngredient(ItemID.Dynamite, 25);
            recipe.AddIngredient(ItemID.LunarTabletFragment, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}