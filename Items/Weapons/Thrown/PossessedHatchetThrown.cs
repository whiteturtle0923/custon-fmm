using Terraria.ID;

namespace Fargowiltas.Items.Weapons.Thrown
{
    public class PossessedHatchetThrown : BaseThrownItem
    {
        public override int Type => ItemID.PossessedHatchet;

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Chases after your enemy");
        }
    }
}