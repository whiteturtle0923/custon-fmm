using Terraria.ID;

namespace Fargowiltas.Items.Weapons.Thrown
{
    public class HelFireThrown : BaseThrownItem
    {
        public override int Type => ItemID.HelFire;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hel-Fire Thrown");
        }
    }
}