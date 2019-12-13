using Terraria.ID;

namespace Fargowiltas.Items.CaughtNPCs
{
    public class Tavernkeep : CaughtNPC
    {
        public override int Type => NPCID.DD2Bartender;

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'What am I doing here...'");
        }
    }
}