using Terraria.ID;

namespace Fargowiltas.Items.CaughtNPCs
{
    public class DyeTrader : CaughtNPC
    {
        public override int Type => NPCID.DyeTrader;

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'My dear, what you're wearing is much too drab.'");
        }
    }
}