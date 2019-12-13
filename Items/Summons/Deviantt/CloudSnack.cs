using Terraria.ID;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class CloudSnack : DevianttSummon
    {
        public override int SummonType => NPCID.WyvernHead;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cloud Snack");
            Tooltip.SetDefault("Summons Wyvern");
        }
    }
}