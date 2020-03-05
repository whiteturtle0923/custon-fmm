using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.SwarmSummons.Energizers
{
    public class EnergizerWall : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wally Energizer");
            Tooltip.SetDefault("'You feel claustrophobic'");
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