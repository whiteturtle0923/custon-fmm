using Terraria.ID;

namespace Fargowiltas.Items.Ammos.Arrows
{
    public class HolyQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ItemID.HolyArrow;

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            Tooltip.SetDefault("Summons falling stars on impact");
        }
    }
}