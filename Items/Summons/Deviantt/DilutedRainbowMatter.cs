using Terraria.ID;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class DilutedRainbowMatter : DevianttSummon
    {
        public override int SummonType => NPCID.RainbowSlime;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Diluted Rainbow Matter");
            Tooltip.SetDefault("Summons Rainbow Slime");
        }
    }
}