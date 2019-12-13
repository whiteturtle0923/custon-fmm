using Terraria.ID;

namespace Fargowiltas.Items.Weapons.Thrown
{
    public class DaybreakThrown : BaseThrownItem
    {
        public override int Type => ItemID.DayBreak;

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'Rend your foes asunder with a spear of light!'");
        }
    }
}