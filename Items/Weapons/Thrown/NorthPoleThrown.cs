using Terraria.ID;

namespace Fargowiltas.Items.Weapons.Thrown
{
    public class NorthPoleThrown : BaseThrownItem
    {
        public override int Type => ItemID.NorthPole;

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Shoots an icy spear that rains snowflakes");
        }
    }
}