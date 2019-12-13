using Terraria.ID;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class ForbiddenForbiddenFragment : DevianttSummon
    {
        public override int SummonType => NPCID.SandElemental;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Forbidden Forbidden Fragment");
            Tooltip.SetDefault("Summons Sand Elemental");
        }
    }
}