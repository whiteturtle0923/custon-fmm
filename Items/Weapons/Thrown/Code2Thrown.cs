using Terraria.ID;

namespace Fargowiltas.Items.Weapons.Thrown
{
    public class Code2Thrown : BaseThrownItem
    {
        public override int Type => ItemID.Code2;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Code 2 Thrown");
        }
    }
}