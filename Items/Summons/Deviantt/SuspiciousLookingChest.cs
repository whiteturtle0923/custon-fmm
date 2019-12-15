using Terraria.ID;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class SuspiciousLookingChest : DevianttSummon
    {
        public override int SummonType => NPCID.Mimic;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Suspicious Looking Chest");
            Tooltip.SetDefault("Summons Mimic");
        }
    }
}