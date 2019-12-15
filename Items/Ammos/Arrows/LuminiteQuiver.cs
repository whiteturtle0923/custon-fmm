using Terraria.ID;

namespace Fargowiltas.Items.Ammos.Arrows
{
    public class LuminiteQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ItemID.MoonlordArrow;

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'Shooting them down at the speed of sound!'");
        }
    }
}