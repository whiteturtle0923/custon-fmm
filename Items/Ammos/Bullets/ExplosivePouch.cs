using Terraria.ID;

namespace Fargowiltas.Items.Ammos.Bullets
{
    public class ExplosivePouch : BaseAmmo
    {
        public override int AmmunitionItem => ItemID.ExplodingBullet;

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Explodes on impact");
        }
    }
}