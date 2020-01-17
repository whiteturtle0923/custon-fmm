using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Ammos.Bullets
{
    public class CrystalPouch : BaseAmmo
    {
        public override int AmmunitionItem => ItemID.CrystalBullet;

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            Tooltip.SetDefault("Creates several crystal shards on impact");
        }
    }
}