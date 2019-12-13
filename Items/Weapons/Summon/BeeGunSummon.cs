using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Weapons.Summon
{
    public class BeeGunSummon : ModItem
    {
        public override string Texture => "Terraria/Item_1121";

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

        public override bool CanRightClick()
        {
            return true;
        }

        public override void RightClick(Player player)
        {
            int num = Item.NewItem(player.getRect(), ItemID.BeeGun, prefixGiven: item.prefix);

            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                NetMessage.SendData(MessageID.SyncItem, number: num, number2: 1f);
            }
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int amount = Main.rand.Next(1, 4);
            for (int i = 0; i <= 2; i++)
            {
                if (Main.rand.NextBool(6))
                {
                    amount++;
                }
            }

            if (player.strongBees && Main.rand.NextBool(3))
            {
                amount++;
            }

            for (int i = 0; i < amount; i++)
            {
                speedX += Main.rand.Next(-35, 36) * 0.02f;
                speedY += Main.rand.Next(-35, 36) * 0.02f;
                int proj = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, player.beeType(), player.beeDamage(damage), player.beeKB(knockBack), player.whoAmI);
                Main.projectile[proj].minion = true;
                Main.projectile[proj].magic = false;
            }

            return false;
        }
    }
}