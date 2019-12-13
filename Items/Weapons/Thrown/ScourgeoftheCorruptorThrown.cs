using Terraria.ID;

namespace Fargowiltas.Items.Weapons.Thrown
{
    public class ScourgeoftheCorruptorThrown : BaseThrownItem
    {
        public override int Type => ItemID.ScourgeoftheCorruptor;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Scourge of the Corruptor Thrown");
            Tooltip.SetDefault("A powerful javelin that unleashes tiny eaters");
        }
    }
}