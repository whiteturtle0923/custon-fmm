using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.Abom
{
    public class CursedSextant : ModItem
    {
        public override void SetStaticDefaults() => Tooltip.SetDefault("Starts the Blood Moon");

        public override void SetDefaults()
        {
            Item.width = Item.height = 20;
            Item.maxStack = 20;
            Item.value = Item.sellPrice(silver: 2);
            Item.rare = ItemRarityID.Blue;
            Item.useAnimation = Item.useTime = 30;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.consumable = true;
        }

        public override bool CanUseItem(Player player) => !Main.dayTime && !Main.bloodMoon;

        public override bool? UseItem(Player player)
        {
            Main.bloodMoon = true;

            NetMessage.SendData(MessageID.WorldData);
            Main.NewText("The Blood Moon is rising...", new Color(175, 75, 255));
            SoundEngine.PlaySound(SoundID.Roar, player.position, 0);

            return true;
        }
    }
}