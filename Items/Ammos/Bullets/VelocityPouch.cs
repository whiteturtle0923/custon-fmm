using Terraria.ID;

namespace Fargowiltas.Items.Ammos.Bullets
{
    public class VelocityPouch : BaseAmmo
    {
        public override int AmmunitionItem => ItemID.HighVelocityBullet;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Endless High Velocity Pouch");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.shootSpeed = 28f;
        }
    }
}