using Terraria.ID;

namespace Fargowiltas.Items.Weapons.Thrown
{
    public class CrimsonYoyoThrown : BaseThrownItem
    {
        public override int Type => ItemID.CrimsonYoyo;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Artery Thrown");
        }
    }
}