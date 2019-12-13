using Terraria.ID;

namespace Fargowiltas.Items.CaughtNPCs
{
    public class Steampunker : CaughtNPC
    {
        public override int Type => NPCID.Steampunker;

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'Show me some gears!'");
        }
    }
}