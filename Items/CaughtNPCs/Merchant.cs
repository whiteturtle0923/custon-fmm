using Terraria.ID;

namespace Fargowiltas.Items.CaughtNPCs
{
    public class Merchant : CaughtNPC
    {
        public override int Type => NPCID.Merchant;

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'Did you say gold? I'll take that off of ya.'");
        }
    }
}