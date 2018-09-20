using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Tiles
{
    public class ShadowLockBox : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 12;
            item.height = 12;
            item.rare = 2;
            item.maxStack = 99;
            item.useAnimation = 15;
            item.useTime = 15;
            item.autoReuse = true;
            item.useStyle = 1;
            //item.consumable = true;
            item.value = Item.sellPrice(0, 1, 0, 0);
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shadow Lock Box");
            Tooltip.SetDefault("Right click to open\nRequires a Shadow Key");
        }

        public override bool CanRightClick()
        {
            return true;
        }

        public override void RightClick(Player player)
        {
            if (player.HasItem(ItemID.ShadowKey))
            {
                int drop = Main.rand.Next(5);

                switch (drop)
                {
                    case 0:
                        drop = ItemID.DarkLance;
                        break;
                    case 1:
                        drop = ItemID.Flamelash;
                        break;
                    case 2:
                        drop = ItemID.FlowerofFire;
                        break;
                    case 3:
                        drop = ItemID.Sunfury;
                        break;
                    default:
                        drop = ItemID.HellwingBow;
                        break;
                }

                int index = Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, drop, 1, false, -1, false, false);

                if (Main.netMode == 1)
                {
                    NetMessage.SendData(21, -1, -1, null, index, 1f, 0f, 0f, 0, 0, 0);
                }
            }
            else
            {
                item.stack++;
            }
        }
    }
}