using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.SwarmSummons.Energizers
{
    public class EnergizerBee : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Buzzy Energizer");
            Tooltip.SetDefault("Formed after using 10 Overstuffed Larva\n'Smells like it tastes like honey'");
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