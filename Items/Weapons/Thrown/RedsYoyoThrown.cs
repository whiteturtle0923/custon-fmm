using Terraria.ID;

namespace Fargowiltas.Items.Weapons.Thrown
{
    public class RedsYoyoThrown : BaseThrownItem
    {
        public override int Type => ItemID.RedsYoyo;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Red's Throw Thrown");
            Tooltip.SetDefault("'Great for impersonating devs!'");
        }
    }
}