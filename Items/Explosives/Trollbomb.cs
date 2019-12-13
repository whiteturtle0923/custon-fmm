using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Explosives
{
    public class Trollbomb : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Troll Bomb");
            Tooltip.SetDefault("'What could go wrong?'" +
                               "\nOnly Snek knows");
        }

        public override void SetDefaults()
        {
            item.width = 10;
            item.height = 32;
            item.consumable = false;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.mana = 10;
            item.rare = ItemRarityID.Green;
            item.UseSound = SoundID.Item18;
            item.autoReuse = true;
            item.useAnimation = 20;
            item.useTime = 20;
            item.value = Item.buyPrice(0, 0, 3);
            item.noMelee = true;
            item.shoot = ProjectileID.WoodenArrowFriendly;
            item.shootSpeed = 5f;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int j = Main.rand.Next(100);

            if (j < 25)
            {
                type = ProjectileID.Bomb;
            }
            else if (j < 40)
            {
                type = ProjectileID.BouncyBomb;
            }
            else if (j < 55)
            {
                type = ProjectileID.StickyBomb;
            }
            else if (j < 60)
            {
                type = ProjectileID.SmokeBomb;
            }
            else if (j < 75)
            {
                type = ProjectileID.Dynamite;
            }
            else if (j < 90)
            {
                type = ProjectileID.Grenade;
            }
            else if (j < 98)
            {
                type = ProjectileID.BouncyDynamite;
            }
            else
            {
                type = mod.ProjectileType("TrollbombProj");
            }

            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, Main.myPlayer);

            return false;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Bomb, 10);
            recipe.AddIngredient(ItemID.StickyBomb, 10);
            recipe.AddIngredient(ItemID.BouncyBomb, 10);
            recipe.AddIngredient(ItemID.Dynamite, 10);
            recipe.AddIngredient(ItemID.ManaCrystal);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}