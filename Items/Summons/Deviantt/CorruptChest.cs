using Terraria.ID;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class CorruptChest : DevianttSummon
    {
        public override int SummonType => NPCID.BigMimicCorruption;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Corrupt Chest");
            Tooltip.SetDefault("Summons Corrupt Mimic");
        }
    }
}