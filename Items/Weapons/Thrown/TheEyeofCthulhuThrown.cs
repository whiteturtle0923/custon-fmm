using Terraria.ID;

namespace Fargowiltas.Items.Weapons.Thrown
{
    public class TheEyeOfCthulhuThrown : BaseThrownItem
    {
        public override int Type => ItemID.TheEyeOfCthulhu;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Eye of Cthulhu Thrown");
        }
    }
}