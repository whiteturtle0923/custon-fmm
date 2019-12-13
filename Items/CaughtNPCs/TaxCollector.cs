using Terraria.ID;

namespace Fargowiltas.Items.CaughtNPCs
{
    public class TaxCollector : CaughtNPC
    {
        public override int Type => NPCID.TaxCollector;

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'You again? Suppose you want more money!?'");
        }
    }
}