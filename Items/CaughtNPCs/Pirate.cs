using Terraria.ID;

namespace Fargowiltas.Items.CaughtNPCs
{
    public class Pirate : CaughtNPC
    {
        public override int Type => NPCID.Pirate;

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'Stay off me booty, ya scallywag!'");
        }
    }
}