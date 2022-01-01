using Terraria;
using Terraria.ID;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class HemoclawCrab : BaseSummon
    {
        public override int NPCType => NPCID.GoblinShark;

        public override string NPCName => "Hemogoblin Shark";

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Hemoclaw Crab");
            Tooltip.SetDefault("Summons Hemogoblin Shark" +
                               "\nOnly usable at night");
        }

        public override bool CanUseItem(Player player)
        {
            return !Main.dayTime;
        }
    }
}