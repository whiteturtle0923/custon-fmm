using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Weapons.Summon
{
    public class BatScepterSummon : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Summons bats to attack your enemies");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.BatScepter);
            item.shoot = ProjectileID.Bat;
            item.magic = false;
            item.summon = true;
        }

        public override string Texture => "Terraria/Item_1801";

        public override bool CanRightClick()
        {
            return true;
        }

        public override void RightClick(Player player)
        {
            int num = Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, ItemID.BatScepter, 1, false, item.prefix);

            if (Main.netMode == 1)
            {
                NetMessage.SendData(21, -1, -1, null, num, 1f, 0f, 0f, 0, 0, 0);
            }
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int num171 = Main.rand.Next(1, 4);
            for (int num172 = 0; num172 < num171; num172++)
            {
                speedX += (float)Main.rand.Next(-35, 36) * 0.05f;
                speedY += (float)Main.rand.Next(-35, 36) * 0.05f;
                int proj = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
                Main.projectile[proj].minion = true;
                Main.projectile[proj].magic = false;
            }
            
            return false;
        }
    }
}