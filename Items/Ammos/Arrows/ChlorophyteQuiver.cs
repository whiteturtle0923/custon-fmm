using Terraria.ID;

namespace Fargowiltas.Items.Ammos.Arrows
{
    public class ChlorophyteQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ItemID.ChlorophyteArrow;

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Bounces back after hitting a wall");
        }
    }
}