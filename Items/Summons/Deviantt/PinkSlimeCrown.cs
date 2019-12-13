using Terraria.ID;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class PinkSlimeCrown : DevianttSummon
    {
        public override int SummonType => NPCID.Pinky;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pink Slime Crown");
            Tooltip.SetDefault("Summons Pinky");
        }
    }
}