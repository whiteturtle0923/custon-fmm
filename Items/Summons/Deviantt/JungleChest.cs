using Terraria.ID;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class JungleChest : DevianttSummon
    {
        public override int SummonType => NPCID.BigMimicJungle;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Jungle Chest");
            Tooltip.SetDefault("Summons Jungle Mimic");
        }
    }
}