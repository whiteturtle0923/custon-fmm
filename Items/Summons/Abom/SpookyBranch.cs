using Terraria;
using Terraria.ID;

namespace Fargowiltas.Items.Summons.Abom
{
    public class SpookyBranch : AbomSummon
    {
        public override int SummonType => NPCID.MourningWood;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spooky Branch");
            Tooltip.SetDefault("Summons Mourning Wood" +
                               "\nOnly usable at night");
        }

        public override bool CanUseItem(Player player)
        {
            return !Main.dayTime;
        }
    }
}