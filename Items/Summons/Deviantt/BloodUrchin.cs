using Terraria;
using Terraria.ID;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class BloodUrchin : BaseSummon
    {
        public override int NPCType => NPCID.BloodEelHead;

        public override string NPCName => "Blood Eel";

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Blood Urchin");
            Tooltip.SetDefault("Summons Blood Eel" +
                               "\nOnly usable at night");
        }

        public override bool CanUseItem(Player player)
        {
            return !Main.dayTime;
        }
    }
}