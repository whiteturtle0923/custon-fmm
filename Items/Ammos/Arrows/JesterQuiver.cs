using Terraria.ID;

namespace Fargowiltas.Items.Ammos.Arrows
{
    public class JesterQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ItemID.JestersArrow;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Endless Jester's Quiver");
        }
    }
}