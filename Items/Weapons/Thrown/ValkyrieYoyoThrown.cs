using Terraria.ID;

namespace Fargowiltas.Items.Weapons.Thrown
{
    public class ValkyrieYoyoThrown : BaseThrownItem
    {
        public override int Type => ItemID.ValkyrieYoyo;

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'Great for impersonating devs!'");
        }
    }
}