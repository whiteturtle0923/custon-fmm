using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Weapons.Summon
{
    public class NimbusRodSummon : ModItem
    {
        public override string Texture => "Terraria/Item_1244";

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

        public override bool CanRightClick()
        {
            return true;
        }

        public override void RightClick(Player player)
        {
            int num = Item.NewItem(player.getRect(), ItemID.NimbusRod, prefixGiven: item.prefix);

            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                NetMessage.SendData(MessageID.SyncItem, number: num, number2: 1f);
            }
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int proj = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
            Main.projectile[proj].ai[0] = Main.MouseWorld.X;
            Main.projectile[proj].ai[1] = Main.MouseWorld.Y;

            Main.projectile[proj].minion = true;
            Main.projectile[proj].magic = false;
            return false;
        }
    }
}