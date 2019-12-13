using Terraria;
using Terraria.ID;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class AttractiveOre : DevianttSummon
    {
        public override int SummonType => NPCID.UndeadMiner;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Attractive Ore");
            Tooltip.SetDefault("Summons Undead Miner" +
                               "\nOnly usable at night or underground");
        }

        public override bool CanUseItem(Player player)
        {
            return !Main.dayTime || player.ZoneRockLayerHeight || player.ZoneUnderworldHeight;
        }
    }
}