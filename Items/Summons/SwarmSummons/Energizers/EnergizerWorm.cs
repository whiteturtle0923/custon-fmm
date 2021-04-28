using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.SwarmSummons.Energizers
{
    public class EnergizerWorm : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wormy Energizer");
            Tooltip.SetDefault("Formed after using 10 Worm Chickens\n'It's a little squishy'");
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