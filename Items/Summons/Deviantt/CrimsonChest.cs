using Terraria.ID;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class CrimsonChest : BaseSummon
    {
        public override int Type => NPCID.BigMimicCrimson;

        public override string NPCName => "Crimson Mimic";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crimson Chest");
            Tooltip.SetDefault("Summons Crimson Mimic");
        }
    }
}