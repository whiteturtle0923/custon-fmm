using Terraria.ID;

namespace Fargowiltas.Items.Weapons.Thrown
{
    public class LightDiscThrown : BaseThrownItem
    {
        public override int Type => ItemID.LightDisc;

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Stacks up to 5");
        }
    }
}