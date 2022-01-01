using Terraria.ID;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class SuspiciousLookingChest : BaseSummon
    {
        public override int NPCType => NPCID.Mimic;

        public override string NPCName => "Mimic";

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Suspicious Looking Chest");
            Tooltip.SetDefault("Summons Mimic"
            + "\nSummons Ice Mimic when in underground snow biome");
        }
    }
}
