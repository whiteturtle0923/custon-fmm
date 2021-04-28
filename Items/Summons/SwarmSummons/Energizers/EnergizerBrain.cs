using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.SwarmSummons.Energizers
{
    public class EnergizerBrain : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Brainy Energizer");
            Tooltip.SetDefault("Formed after using 10 Brain Storms\n'You still feel dumb'");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 999;
            item.rare = 1;
            item.value = 100000;
        }
    }
}