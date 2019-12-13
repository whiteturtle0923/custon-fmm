using Terraria;
using Terraria.ID;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class ClownLicense : DevianttSummon
    {
        public override int SummonType => NPCID.Clown;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Clown License");
            Tooltip.SetDefault("Summons Clown" +
                               "\nOnly usable at night or underground");
        }

        public override bool CanUseItem(Player player)
        {
            return !Main.dayTime || player.ZoneRockLayerHeight || player.ZoneUnderworldHeight;
        }
    }
}