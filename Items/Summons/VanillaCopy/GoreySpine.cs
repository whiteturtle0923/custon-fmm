using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons
{
    public class GoreySpine : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Red Stained Spine");
            Tooltip.SetDefault("Summons the Brain of Cthulhu");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 20;
            item.value = 1000;
            item.rare = 0;
            item.useAnimation = 30;
            item.useTime = 30;
            item.useStyle = 4;
            item.consumable = true;
            item.shoot = mod.ProjectileType("SpawnProj");
        }

        public override string Texture => "Terraria/Item_1331";

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 pos = new Vector2((int)player.position.X + Main.rand.Next(-800, 800), (int)player.position.Y + Main.rand.Next(-1000, -250));

            Projectile.NewProjectile(pos, Vector2.Zero, mod.ProjectileType("SpawnProj"), 0, 0, Main.myPlayer, NPCID.BrainofCthulhu);

            if (Main.netMode == 2)
            {
                NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("Brain of Cthulhu has awoken!"), new Color(175, 75, 255));
            }
            else
            {
                Main.NewText("Brain of Cthulhu has awoken!", 175, 75, 255);
            }

            Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BloodySpine);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}