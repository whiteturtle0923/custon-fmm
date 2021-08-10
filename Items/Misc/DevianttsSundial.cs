using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Misc
{
    public class DevianttsSundial : ModItem
    {
        public override string Texture => "Fargowiltas/Items/Misc/PortableSundial";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Deviantt's Sundial");
            Tooltip.SetDefault("'For getting through those early nights'\nActivates the Enchanted Sundial effect\nCan only be used once");
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.rare = ItemRarityID.Blue;
            Item.useAnimation = 30;
            Item.useTime = 30;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.UseSound = SoundID.Item4;
            Item.consumable = true;
        }

        public override bool CanUseItem(Player player)
        {
            return !Main.fastForwardTime;
        }

        public override bool? UseItem(Player player)
        {
            Main.sundialCooldown = 0;
            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                NetMessage.SendData(MessageID.WorldData, number: Main.myPlayer, number2: 3f);
                return true;
            }

            Main.fastForwardTime = true;
            NetMessage.SendData(MessageID.WorldData);
            SoundEngine.PlaySound(SoundID.Item4, player.position);

            return true;
        }
    }
}