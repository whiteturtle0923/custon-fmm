using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.SwarmSummons.Energizers
{
    public class EnergizerBetsy : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Draco Energizer");
            Tooltip.SetDefault("'You feel like you've waited three thousand years'");
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