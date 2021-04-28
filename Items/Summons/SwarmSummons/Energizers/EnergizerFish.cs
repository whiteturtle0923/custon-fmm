using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.SwarmSummons.Energizers
{
    public class EnergizerFish : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fishy Energizer");
            Tooltip.SetDefault("Formed after using 10 Truffle Worm Clumps\n'You feel content'");
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