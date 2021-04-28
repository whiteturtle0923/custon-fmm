using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.SwarmSummons.Energizers
{
    public class EnergizerDestroy : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Destruction Energizer");
            Tooltip.SetDefault("Formed after using 10 Seismic Actuator\n'It makes you want to break some kids'");
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