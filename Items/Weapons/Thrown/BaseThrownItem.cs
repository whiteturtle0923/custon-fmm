using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Weapons.Thrown
{
    public abstract class BaseThrownItem : ModItem
    {
        public abstract int Type { get; }

        public override string Texture => $"Terraria/Item_{Type}";

        public override void SetDefaults()
        {
            item.CloneDefaults(Type);
            item.melee = false;
            item.magic = false;
            item.thrown = true;
            item.mana = 0;
        }

        public override bool CanRightClick()
        {
            return true;
        }

        public override void RightClick(Player player)
        {
            int num = Item.NewItem(player.getRect(), Type, prefixGiven: item.prefix);

            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                NetMessage.SendData(MessageID.SyncItem, number: num, number2: 1f);
            }
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int proj = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
            Main.projectile[proj].thrown = true;
            Main.projectile[proj].melee = false;
            Main.projectile[proj].magic = false;
            return false;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipLine line = new TooltipLine(mod, "help", "Right click to convert");
            tooltips.Add(line);
        }
    }
}
