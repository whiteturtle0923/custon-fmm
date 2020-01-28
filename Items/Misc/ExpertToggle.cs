using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Misc
{
    public class ExpertToggle : ModItem
    {
        public override string Texture => "Fargowiltas/Items/Placeholder";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Expert's Token");
            Tooltip.SetDefault(@"Enables Expert mode
This cannot be reversed!");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.value = Item.buyPrice(1);
            item.rare = ItemRarityID.Blue;
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.consumable = true;
        }

        public override bool CanUseItem(Player player)
        {
            return !Main.expertMode;
        }

        public override bool UseItem(Player player)
        {
            Main.expertMode = true;

            string text = "Expert mode is now enabled!";
            if (Main.netMode == NetmodeID.SinglePlayer)
            {
                Main.NewText(text, new Color(175, 75, 255));
            }
            else if (Main.netMode == NetmodeID.Server)
            {
                NetMessage.BroadcastChatMessage(NetworkText.FromLiteral(text), new Color(175, 75, 255));
                NetMessage.SendData(7); //sync world
            }

            Main.PlaySound(15, player.Center, 0);

            return true;
        }
    }
}