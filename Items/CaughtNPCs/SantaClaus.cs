using Terraria.ID;

namespace Fargowiltas.Items.CaughtNPCs
{
    public class SantaClaus : CaughtNPC
    {
        public override int Type => NPCID.SantaClaus;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Santa Claus");
            Tooltip.SetDefault("'What? You thought I wasn't real?'");
        }
    }
}