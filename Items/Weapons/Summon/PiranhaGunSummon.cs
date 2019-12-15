using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Weapons.Summon
{
    public class PiranhaGunSummon : ModItem
    {
        public override string Texture => "Terraria/Item_1156";

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Latches on to enemies for continuous damage");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.PiranhaGun);
            item.shoot = ProjectileID.MechanicalPiranha;
            item.ranged = false;
            item.summon = true;
        }

        public override bool CanRightClick()
        {
            return true;
        }

        public override void RightClick(Player player)
        {
            int num = Item.NewItem(player.getRect(), ItemID.PiranhaGun, prefixGiven: item.prefix);

            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                NetMessage.SendData(MessageID.SyncItem, number: num, number2: 1f);
            }
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int proj = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
            Main.projectile[proj].minion = true;
            Main.projectile[proj].ranged = false;
            return false;
        }
    }
}