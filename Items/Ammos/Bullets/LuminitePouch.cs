using Terraria.ID;

namespace Fargowiltas.Items.Ammos.Bullets
{
    public class LuminitePouch : BaseAmmo
    {
        public override int AmmunitionItem => ItemID.MoonlordBullet;

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            Tooltip.SetDefault("'Line 'em up and knock 'em down...'");
        }
    }
}