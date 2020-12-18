using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Fargowiltas.Items.Misc
{
    public class IceCrate : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ice Crate");
            Tooltip.SetDefault("Right click to open");
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
            item.consumable = true;
            item.value = Item.sellPrice(0, 1);
            //item.createTile = TileType<IceCrateSheet>();
        }

        public override bool CanRightClick()
        {
            return true;
        }

        public override void RightClick(Player player)
        {
            if (Main.rand.NextBool(6))
            {
                int item = Main.rand.Next(8);

                switch (item)
                {
                    case 0:
                        item = ItemID.BlizzardinaBottle;
                        break;
                    case 1:
                        item = ItemID.IceBoomerang;
                        break;
                    case 2:
                        item = ItemID.IceBlade;
                        break;
                    case 3:
                        item = ItemID.IceSkates;
                        break;
                    case 4:
                        item = ItemID.SnowballCannon;
                        break;
                    case 5:
                        item = ItemID.FlurryBoots;
                        break;
                    case 6:
                        item = ItemID.IceMirror;
                        break;
                    default:
                        item = ItemID.Fish;
                        break;
                }

                int index = Item.NewItem(player.getRect(), item, prefixGiven: -1);

                if (Main.netMode == NetmodeID.MultiplayerClient)
                {
                    NetMessage.SendData(MessageID.SyncItem, number: index, number2: 1f);
                }
            }

            // Bypass all checks and spawn defaults
            player.openCrate(4000);
        }
    }
}