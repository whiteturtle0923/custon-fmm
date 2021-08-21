using Terraria;
using Terraria.ID;

namespace Fargowiltas.Items.Summons.Abom
{
    public class SpookyBranch : BaseSummon
    {
        public override int Type => NPCID.MourningWood;

        public override string NPCName => "Mourning Wood";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spooky Branch");
            Tooltip.SetDefault("Summons Mourning Wood" +
                               "\nOnly usable during Pumpkin Moon");
        }

        public override bool CanUseItem(Player player)
        {
            return !Main.dayTime && Main.pumpkinMoon;
        }
    }
}