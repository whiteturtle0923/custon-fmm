using Terraria;
using Terraria.ID;

namespace Fargowiltas.Items.Summons.Abom
{
    public class SpookyBranch : BaseSummon
    {
        public override int NPCType => NPCID.MourningWood;

        public override string NPCName => "Mourning Wood";

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Spooky Branch");
            Tooltip.SetDefault("Summons Mourning Wood" +
                               "\nOnly usable during Pumpkin Moon");
        }

        public override bool CanUseItem(Player player)
        {
            return Main.pumpkinMoon;
        }
    }
}