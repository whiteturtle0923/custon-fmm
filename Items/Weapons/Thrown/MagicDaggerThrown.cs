using Terraria.ID;

namespace Fargowiltas.Items.Weapons.Thrown
{
    public class MagicDaggerThrown : BaseThrownItem
    {
        public override int Type => ItemID.MagicDagger;

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("A magical returning dagger");
        }
    }
}