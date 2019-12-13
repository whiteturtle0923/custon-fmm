using Terraria.ID;

namespace Fargowiltas.Items.CaughtNPCs
{
    public class Angler : CaughtNPC
    {
        public override int Type => NPCID.Angler;

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'You'd be a great helper minion!'");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.bait = 15;
        }
    }
}