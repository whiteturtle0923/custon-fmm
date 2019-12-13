using Terraria.ID;

namespace Fargowiltas.Items.Weapons.Thrown
{
    public class DaoofPowThrown : BaseThrownItem
    {
        public override int Type => ItemID.DaoofPow;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dao of Pow Thrown");
            Tooltip.SetDefault("Has a chance to confuse" +
                               "\n'Find your inner pieces'");
        }
    }
}