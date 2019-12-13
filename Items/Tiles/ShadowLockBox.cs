using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Tiles
{
    public class ShadowLockBox : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shadow Lock Box");
            Tooltip.SetDefault("Right click to open\nRequires a Shadow Key");
        }

        public override void SetDefaults()
        {
            item.width = 12;
            item.height = 12;
            item.rare = ItemRarityID.Green;
            item.maxStack = 99;
            item.useAnimation = 15;
            item.useTime = 15;
            item.autoReuse = true;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.value = Item.sellPrice(0, 1);
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

                int index = Item.NewItem(player.getRect(), drop, prefixGiven: -1);

                if (Main.netMode == NetmodeID.MultiplayerClient)
                {
                    NetMessage.SendData(MessageID.SyncItem, number: index, number2: 1f);
                }
            }
            else
            {
                item.stack++;
            }
        }
    }
}