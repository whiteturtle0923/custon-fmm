using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.SwarmSummons.Energizers
{
    public class EnergizerGolem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lihzahrd Energizer");
            Tooltip.SetDefault("Formed after using 10 Runic Power Cells\n'You wish it was spelled \"lizard\"");
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