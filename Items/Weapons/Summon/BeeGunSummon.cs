using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Weapons.Summon
{
    public class BeeGunSummon : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Shoots bees that will chase your enemy");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.BeeGun);
            item.shoot = ProjectileID.Bee;
            item.magic = false;
            item.summon = true;
        }

        public override string Texture => "Terraria/Item_1121";

        public override bool CanRightClick()
        {
            return true;
        }

        public override void RightClick(Player player)
        {
            int num = Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, ItemID.BeeGun, 1, false, item.prefix);

            if (Main.netMode == 1)
            {
                NetMessage.SendData(21, -1, -1, null, num, 1f, 0f, 0f, 0, 0, 0);
            }
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int num162 = Main.rand.Next(1, 4);
            if (Main.rand.Next(6) == 0)
            {
                num162++;
            }
            if (Main.rand.Next(6) == 0)
            {
                num162++;
            }
            if (player.strongBees && Main.rand.Next(3) == 0)
            {
                num162++;
            }
            for (int num163 = 0; num163 < num162; num163++)
            {
                speedX += (float)Main.rand.Next(-35, 36) * 0.02f;
                speedY += (float)Main.rand.Next(-35, 36) * 0.02f;
                int proj = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, player.beeType(), player.beeDamage(damage), player.beeKB(knockBack), player.whoAmI);
                Main.projectile[proj].minion = true;
                Main.projectile[proj].magic = false;
            }

            return false;
        }
    }
}