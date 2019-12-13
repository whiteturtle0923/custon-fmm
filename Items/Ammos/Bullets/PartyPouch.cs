using Terraria.ID;

namespace Fargowiltas.Items.Ammos.Bullets
{
    public class PartyPouch : BaseAmmo
    {
        public override int AmmunitionItem => ItemID.PartyBullet;

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Explodes into confetti on impact");
        }
    }
}