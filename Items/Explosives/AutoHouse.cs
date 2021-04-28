using Fargowiltas.Projectiles.Explosives;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Explosives
{
    public class AutoHouse : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("InstaHouse");
            Tooltip.SetDefault("Places an NPC house instantly");
        }

        public override void SetDefaults()
        {
            item.width = 10;
            item.height = 32;
            item.maxStack = 99;
            item.consumable = true;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.rare = ItemRarityID.Blue;
            item.UseSound = SoundID.Item1;
            item.useAnimation = 20;
            item.useTime = 20;
            item.value = Item.buyPrice(0, 0, 3);
            item.createTile = ModContent.TileType<AutoHouseTile>();
        }

        public override void HoldItem(Player player)
        {
            if (player.ownedProjectileCounts[ModContent.ProjectileType<InstaHouseVisual>()] < 1)
            {
                Vector2 mouse = Main.MouseWorld;
                Projectile.NewProjectile(mouse, Vector2.Zero, ModContent.ProjectileType<InstaHouseVisual>(), 0, 0, player.whoAmI);
            }

            //Player.tileRangeX += 20;
            //Player.tileRangeY += 20;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("Wood", 50);
            recipe.AddIngredient(ItemID.Torch);
            recipe.AddTile(TileID.Sawmill);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}