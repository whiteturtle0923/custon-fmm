using Terraria.ID;

namespace Fargowiltas.Items.Weapons.Thrown
{
    public class JungleYoyoThrown : BaseThrownItem
    {
        public override int Type => ItemID.JungleYoyo;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Amazon Thrown");
        }
    }
}