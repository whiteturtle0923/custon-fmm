using Terraria.ID;

namespace Fargowiltas.Items.Summons.NewSummons
{
    public class ForbiddenTome : BaseSummon
    {
        public override int Type => NPCID.DD2DarkMageT3;

        public override string NPCName => "Dark Mage";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Forbidden Tome");
            Tooltip.SetDefault("Summons a Dark Mage");
        }
    }
}