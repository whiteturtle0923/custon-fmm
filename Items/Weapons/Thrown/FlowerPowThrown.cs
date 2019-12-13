using Terraria.ID;

namespace Fargowiltas.Items.Weapons.Thrown
{
    public class FlowerPowThrown : BaseThrownItem
    {
        public override int Type => ItemID.FlowerPow;

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Shoots razor sharp flower petals at nearby enemies");
        }
    }
}