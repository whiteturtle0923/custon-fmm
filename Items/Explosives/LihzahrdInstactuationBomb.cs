using Fargowiltas.Projectiles.Explosives;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
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
            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 10;
        }

        public override void SetDefaults()
        {
            Item.width = 10;
            Item.height = 32;
            Item.maxStack = 99;
            Item.consumable = true;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.rare = ItemRarityID.Yellow;
            Item.UseSound = SoundID.Item1;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.value = Item.buyPrice(0, 0, 3);
            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.shoot = ModContent.ProjectileType<LihzahrdInstactuationBombProj>();
        }

        public override bool CanUseItem(Player player)
        {
            Tile tile = Framing.GetTileSafely(player.Center);
            return tile.TileType == TileID.LihzahrdAltar && tile.WallType == WallID.LihzahrdBrickUnsafe && NPC.downedPlantBoss;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Tile tile = Framing.GetTileSafely(player.Center);
            if (tile.TileType == TileID.LihzahrdAltar && tile.WallType == WallID.LihzahrdBrickUnsafe && NPC.downedPlantBoss)
            {
                Projectile.NewProjectile(player.GetSource_ItemUse(source.Item), player.Bottom - Vector2.UnitY * 8f, Vector2.Zero, type, 0, 0, player.whoAmI);
            }
            return false;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Actuator, 500)
                .AddIngredient(ItemID.Dynamite, 25)
                .AddIngredient(ItemID.LunarTabletFragment, 10)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}