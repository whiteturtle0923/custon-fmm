using Terraria.ID;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class ForbiddenForbiddenFragment : BaseSummon
    {
        public override int Type => NPCID.SandElemental;

        public override string NPCName => "Sand Elemental";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Forbidden Forbidden Fragment");
            Tooltip.SetDefault("Summons Sand Elemental");
        }
    }
}