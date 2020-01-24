using Terraria.ID;

namespace Fargowiltas.Items.Ammos.Bullets
{
    public class NanoPouch : BaseAmmo
    {
        public override int AmmunitionItem => ItemID.NanoBullet;

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            Tooltip.SetDefault("Causes confusion");
        }
    }
}