using Terraria;
using Terraria.ID;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class HeartChocolate : DevianttSummon
    {
        public override int SummonType => NPCID.Nymph;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Heart Chocolate");
            Tooltip.SetDefault("Summons Nymph" +
                               "\nOnly usable at night or underground");
        }

        public override bool CanUseItem(Player player)
        {
            return !Main.dayTime || player.ZoneRockLayerHeight || player.ZoneUnderworldHeight;
        }
    }
}