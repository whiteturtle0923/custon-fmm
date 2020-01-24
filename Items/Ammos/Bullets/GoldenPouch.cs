using Terraria.ID;

namespace Fargowiltas.Items.Ammos.Bullets
{
    public class GoldenPouch : BaseAmmo
    {
        public override int AmmunitionItem => ItemID.GoldenBullet;

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            Tooltip.SetDefault("Enemies killed will drop more money");
        }
    }
}