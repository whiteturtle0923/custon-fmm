using Terraria.ID;

namespace Fargowiltas.Items.Weapons.Thrown
{
    public class ShadowFlameKnifeThrown : BaseThrownItem
    {
        public override int Type => ItemID.ShadowFlameKnife;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shadowflame Knife");
            Tooltip.SetDefault("Inflicts Shadowflame on hit");
        }
    }
}