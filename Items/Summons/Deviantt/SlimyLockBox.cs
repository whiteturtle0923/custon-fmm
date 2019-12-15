using Terraria.ID;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class SlimyLockBox : DevianttSummon
    {
        public override int SummonType => NPCID.DungeonSlime;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Slimy Lock Box");
            Tooltip.SetDefault("Summons Dungeon Slime");
        }
    }
}