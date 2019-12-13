using Terraria.ID;

namespace Fargowiltas.Items.CaughtNPCs
{
    public class TravellingMerchant : CaughtNPC
    {
        public override int Type => NPCID.TravellingMerchant;

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'I sell wares from places that might not even exist!'");
        }
    }
}