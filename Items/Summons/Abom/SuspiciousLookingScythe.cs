using Terraria;
using Terraria.ID;

namespace Fargowiltas.Items.Summons.Abom
{
    public class SuspiciousLookingScythe : AbomSummon
    {
        public override int SummonType => NPCID.Pumpking;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Suspicious Looking Scythe");
            Tooltip.SetDefault("Summons Pumpking" +
                               "\nOnly usable at night");
        }

        public override bool CanUseItem(Player player)
        {
            return !Main.dayTime;
        }
    }
}