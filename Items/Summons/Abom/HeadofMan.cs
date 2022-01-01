using Terraria;
using Terraria.ID;

namespace Fargowiltas.Items.Summons.Abom
{
    public class HeadofMan : BaseSummon
    {
        public override int NPCType => NPCID.HeadlessHorseman;

        public override string NPCName => "Headless Horseman";

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Head of Man");
            Tooltip.SetDefault("Summons Headless Horseman" +
                               "\nOnly usable during Pumpkin Moon");
        }

        public override bool CanUseItem(Player player)
        {
            return Main.pumpkinMoon;

        }
    }
}