using Terraria.ID;

namespace Fargowiltas.Items.CaughtNPCs
{
    public class Clothier : CaughtNPC
    {
        public override int Type => NPCID.Clothier;

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'Thanks again for freeing me from my curse.'");
        }
    }
}