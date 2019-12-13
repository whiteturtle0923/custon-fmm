using Terraria.ID;

namespace Fargowiltas.Items.Ammos.Arrows
{
    public class IchorQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ItemID.IchorArrow;

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Decreases target's defense");
        }
    }
}