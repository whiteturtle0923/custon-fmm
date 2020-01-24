using Terraria.ID;

namespace Fargowiltas.Items.Ammos.Bullets
{
    public class ChlorophytePouch : BaseAmmo
    {
        public override int AmmunitionItem => ItemID.ChlorophyteBullet;

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            Tooltip.SetDefault("Chases after your enemy");
        }
    }
}