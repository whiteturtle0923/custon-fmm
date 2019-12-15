using Terraria.ID;

namespace Fargowiltas.Items.CaughtNPCs
{
    public class Dryad : CaughtNPC
    {
        public override int Type => NPCID.Dryad;

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'Be safe; Terraria needs you!'");
        }
    }
}