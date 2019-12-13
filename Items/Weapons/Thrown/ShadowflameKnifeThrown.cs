using Terraria.ID;

namespace Fargowiltas.Items.Weapons.Thrown
{
    public class ShadowflameKnifeThrown : BaseThrownItem
    {
        public override int Type => ItemID.ShadowFlameKnife;

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Inflicts Shadowflame on hit");
        }
    }
}