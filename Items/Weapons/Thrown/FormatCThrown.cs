using Terraria.ID;

namespace Fargowiltas.Items.Weapons.Thrown
{
    public class FormatCThrown : BaseThrownItem
    {
        public override int Type => ItemID.FormatC;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Format:C Thrown");
        }
    }
}