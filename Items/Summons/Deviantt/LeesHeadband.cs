using Terraria;
using Terraria.ID;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class LeesHeadband : DevianttSummon
    {
        public override int SummonType => NPCID.BoneLee;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lee's Headband");
            Tooltip.SetDefault("Summons Bone Lee" +
                               "\nOnly usable at night or underground");
        }

        public override bool CanUseItem(Player player)
        {
            return !Main.dayTime || player.ZoneRockLayerHeight || player.ZoneUnderworldHeight;
        }
    }
}