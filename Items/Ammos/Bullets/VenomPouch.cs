using Terraria.ID;

namespace Fargowiltas.Items.Ammos.Bullets
{
    public class VenomPouch : BaseAmmo
    {
        public override int AmmunitionItem => ItemID.VenomBullet;

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            Tooltip.SetDefault("Inflicts target with venom");
        }
    }
}