using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.NewSummons
{
    public class Plantera : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Plantera's Bulb");
            Tooltip.SetDefault("Summons Plantera");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 20;
            item.value = 1000;
            item.rare = 4;
            item.useAnimation = 30;
            item.useTime = 30;
            item.useStyle = 4;
            item.consumable = true;
            item.shoot = mod.ProjectileType("SpawnProj");
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 pos = new Vector2((int)player.position.X + Main.rand.Next(-800, 800), (int)player.position.Y + Main.rand.Next(250, 1000));

            Projectile.NewProjectile(pos, Vector2.Zero, mod.ProjectileType("SpawnProj"), 0, 0, Main.myPlayer, NPCID.Plantera);

            if (Main.netMode == 2)
            {
                NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("Plantera has awoken!"), new Color(175, 75, 255));
            }
            else
            {
                Main.NewText("Plantera has awoken!", 175, 75, 255);
            }

            Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 2);
            recipe.AddIngredient(ItemID.Moonglow, 5);
            recipe.AddIngredient(ItemID.Blinkroot, 5);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}