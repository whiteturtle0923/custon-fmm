using Terraria;
using Terraria.ID;

namespace Fargowiltas.Items.Summons.Abom
{
    public class FestiveOrnament : BaseSummon
    {
        public override int Type => NPCID.Everscream;

        public override string NPCName => "Everscream";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Festive Ornament");
            Tooltip.SetDefault("Summons Everscream" +
                               "\nOnly usable during Frost Moon");
        }

        public override bool CanUseItem(Player player)
        {
            return !Main.dayTime && Main.snowMoon;
        }
    }
}