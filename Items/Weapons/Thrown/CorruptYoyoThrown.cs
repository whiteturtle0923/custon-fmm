using Terraria.ID;

namespace Fargowiltas.Items.Weapons.Thrown
{
    public class CorruptYoyoThrown : BaseThrownItem
    {
        public override int Type => ItemID.CorruptYoyo;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Malaise Thrown");
        }
    }
}