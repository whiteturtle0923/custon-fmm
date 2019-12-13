using Terraria;
using Terraria.ID;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class Eggplant : DevianttSummon
    {
        public override int SummonType => NPCID.DoctorBones;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Eggplant");
            Tooltip.SetDefault("Summons Doctor Bones" +
                               "\nOnly usable at night or underground");
        }

        public override bool CanUseItem(Player player)
        {
            return !Main.dayTime || player.ZoneRockLayerHeight || player.ZoneUnderworldHeight;
        }
    }
}