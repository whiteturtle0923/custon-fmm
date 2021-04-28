using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.SwarmSummons.Energizers
{
    public class EnergizerTwins : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sibling Energizer");
            Tooltip.SetDefault("Formed after using 10 Omnifocal Lens\n'You wish you had more'");
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