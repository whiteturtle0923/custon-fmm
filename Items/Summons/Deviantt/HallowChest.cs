using Terraria.ID;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class HallowChest : DevianttSummon
    {
        public override int SummonType => NPCID.BigMimicHallow;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hallow Chest");
            Tooltip.SetDefault("Summons Hallowed Mimic");
        }
    }
}