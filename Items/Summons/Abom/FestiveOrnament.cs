using Terraria;
using Terraria.ID;

namespace Fargowiltas.Items.Summons.Abom
{
    public class FestiveOrnament : AbomSummon
    {
        public override int SummonType => NPCID.Everscream;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Festive Ornament");
            Tooltip.SetDefault("Summons Everscream" +
                               "\nOnly usable at night");
        }

        public override bool CanUseItem(Player player)
        {
            return !Main.dayTime;
        }
    }
}