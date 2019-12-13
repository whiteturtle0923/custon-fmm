using Terraria.ID;

namespace Fargowiltas.Items.Weapons.Thrown
{
    public class Code1Thrown : BaseThrownItem
    {
        public override int Type => ItemID.Code1;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Code 1 Thrown");
        }
    }
}