using Terraria.ID;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class CrimsonChest : DevianttSummon
    {
        public override int SummonType => NPCID.BigMimicCrimson;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crimson Chest");
            Tooltip.SetDefault("Summons Crimson Mimic");
        }
    }
}