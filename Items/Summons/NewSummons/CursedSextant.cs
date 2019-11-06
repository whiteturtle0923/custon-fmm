using Terraria;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.NewSummons
{
    public class CursedSextant : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cursed Sextant");
            Tooltip.SetDefault("Starts the Blood Moon");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 20;
            item.value = 1000;
            item.rare = 1;
            item.useAnimation = 30;
            item.useTime = 30;
            item.useStyle = 4;
            item.consumable = true;
        }

        public override bool CanUseItem(Player player)
        {
            return !Main.dayTime;
        }

        public override bool UseItem(Player player)
        {
            Main.bloodMoon = true;
            Main.NewText("The Blood Moon is rising...", 175, 75, 255);
            Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
            return true;
        }
    }
}