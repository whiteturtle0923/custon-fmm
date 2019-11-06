using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.NewSummons
{
    public class SlimyBarometer : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Slimy Barometer");
            Tooltip.SetDefault("Summons Slime Rain");
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
            return !Main.slimeRain;
        }

        public override bool UseItem(Player player)
        {
            Main.StartSlimeRain();
            Main.slimeWarningDelay = 1;
            Main.slimeWarningTime = 1;
            return true;
        }
    }
}