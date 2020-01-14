using Terraria;
using Terraria.ID;

namespace Fargowiltas.Items.Summons.Abom
{
    public class IceKingsRemains : AbomSummon
    {
        public override int SummonType => NPCID.IceQueen;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ice King's Remains");
            Tooltip.SetDefault("Summons Ice Queen" +
                               "\nOnly usable at night");
        }

        public override bool CanUseItem(Player player)
        {
            return !Main.dayTime;
        }
    }
}