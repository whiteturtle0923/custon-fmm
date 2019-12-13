using Terraria.ID;

namespace Fargowiltas.Items.Ammos.Bullets
{
    public class IchorPouch : BaseAmmo
    {
        public override int AmmunitionItem => ItemID.IchorBullet;

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Decreases target's defense");
        }
    }
}