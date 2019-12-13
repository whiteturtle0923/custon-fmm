using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Weapons.Summon
{
    public class WaspGunSummon : ModItem
    {
        public override string Texture => "Terraria/Item_1155";

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.WaspGun);
            item.shoot = ProjectileID.Wasp;
            item.magic = false;
            item.summon = true;
        }

        public override bool CanRightClick()
        {
            return true;
        }

        public override void RightClick(Player player)
        {
            int num = Item.NewItem(player.getRect(), ItemID.WaspGun, prefixGiven: item.prefix);

            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                NetMessage.SendData(MessageID.SyncItem, number: num, number2: 1f);
            }
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int amount = Main.rand.Next(2, 5);
            for (int i = 0; i <= 2; i++)
            {
                if (Main.rand.NextBool(5))
                {
                    amount++;
                }
            }

            for (int i = 0; i < amount; i++)
            {
                speedX += Main.rand.Next(-35, 36) * 0.02f;
                speedY += Main.rand.Next(-35, 36) * 0.02f;
                int proj = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
                Main.projectile[proj].minion = true;
                Main.projectile[proj].magic = false;
            }

            return false;
        }
    }
}