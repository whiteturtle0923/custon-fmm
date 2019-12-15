using Terraria;
using Terraria.ID;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class GrandCross : DevianttSummon
    {
        public override int SummonType => NPCID.Paladin;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Grand Cross");
            Tooltip.SetDefault("Summons Paladin" +
                               "\nOnly usable at night or underground");
        }

        public override bool CanUseItem(Player player)
        {
            return !Main.dayTime || player.ZoneRockLayerHeight || player.ZoneUnderworldHeight;
        }
    }
}