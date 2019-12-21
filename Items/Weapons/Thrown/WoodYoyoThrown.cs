using Terraria.ID;

namespace Fargowiltas.Items.Weapons.Thrown
{
    public class WoodYoyoThrown : BaseThrownItem
    {
        public override int Type => ItemID.WoodYoyo;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wooden Yoyo Thrown");
        }
    }
}