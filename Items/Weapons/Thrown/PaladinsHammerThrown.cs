using Terraria.ID;

namespace Fargowiltas.Items.Weapons.Thrown
{
    public class PaladinsHammerThrown : BaseThrownItem
    {
        public override int Type => ItemID.PaladinsHammer;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Paladin's Hammer Thrown");
            Tooltip.SetDefault("A powerful returning hammer");
        }
    }
}