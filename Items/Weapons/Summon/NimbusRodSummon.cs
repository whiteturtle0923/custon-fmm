using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Weapons.Summon
{
    public class NimbusRodSummon : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Summons a cloud to rain down on your foes");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.NimbusRod);
            item.shoot = ProjectileID.RainCloudMoving;
            item.magic = false;
            item.summon = true;
        }

        public override string Texture => "Terraria/Item_1244";

        public override bool CanRightClick()
        {
            return true;
        }

        public override void RightClick(Player player)
        {
            int num = Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, ItemID.NimbusRod, 1, false, item.prefix);

            if (Main.netMode == 1)
            {
                NetMessage.SendData(21, -1, -1, null, num, 1f, 0f, 0f, 0, 0, 0);
            }
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {          
            int proj = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
            Main.projectile[proj].ai[0] = (float)Main.mouseX + Main.screenPosition.X;
            Main.projectile[proj].ai[1] = (float)Main.mouseY + Main.screenPosition.Y;

            Main.projectile[proj].minion = true;
            Main.projectile[proj].magic = false;
            return false;
        }
    }
}