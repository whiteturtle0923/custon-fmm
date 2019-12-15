using Terraria.ID;

namespace Fargowiltas.Items.Weapons.Thrown
{
    public class FlyingKnifeThrown : BaseThrownItem
    {
        public override int Type => ItemID.FlyingKnife;

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Throws a controllable flying knife");
        }
    }
}