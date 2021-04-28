using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.SwarmSummons.Energizers
{
    public class EnergizerPlant : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Leafy Energizer");
            Tooltip.SetDefault("Formed after using 10 Heart of the Jungles\n'Being a leaf sounds like a good time'");
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