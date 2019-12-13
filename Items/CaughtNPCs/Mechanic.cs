using Terraria.ID;

namespace Fargowiltas.Items.CaughtNPCs
{
    public class Mechanic : CaughtNPC
    {
        public override int Type => NPCID.Mechanic;

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'Always buy more wire than you need!'");
        }
    }
}