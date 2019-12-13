using Terraria.ID;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class MothLamp : DevianttSummon
    {
        public override int SummonType => NPCID.Moth;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Moth Lamp");
            Tooltip.SetDefault("Summons Moth");
        }
    }
}