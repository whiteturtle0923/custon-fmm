using Terraria;
using Terraria.ID;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class RuneOrb : DevianttSummon
    {
        public override int SummonType => NPCID.RuneWizard;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rune Orb");
            Tooltip.SetDefault("Summons Rune Wizard" +
                               "\nOnly usable at night or underground");
        }

        public override bool CanUseItem(Player player)
        {
            return !Main.dayTime || player.ZoneRockLayerHeight || player.ZoneUnderworldHeight;
        }
    }
}