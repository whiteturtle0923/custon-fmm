using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.SwarmSummons.Energizers
{
    public class EnergizerCultist : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Insanity Energizer");
            Tooltip.SetDefault("'You're probably insane'");
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