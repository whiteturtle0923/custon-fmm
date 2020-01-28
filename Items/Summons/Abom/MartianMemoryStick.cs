using Terraria;
using Terraria.ID;

namespace Fargowiltas.Items.Summons.Abom
{
    public class MartianMemoryStick : AbomSummon
    {
        public override int SummonType => NPCID.MartianSaucer;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Martian Memory Stick");
            Tooltip.SetDefault("Summons Martian Saucer");
        }
    }
}