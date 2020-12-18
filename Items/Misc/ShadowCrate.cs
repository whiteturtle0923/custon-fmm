using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Misc
{
    public class ShadowCrate : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shadow Crate");
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
        }

        public override bool CanRightClick()
        {
            return true;
        }

        public override void RightClick(Player player)
        {
            if (Main.rand.NextBool(6))
            {
                int index = Item.NewItem(player.getRect(), mod.ItemType("ShadowLockBox"), prefixGiven: -1);

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