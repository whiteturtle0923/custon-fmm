using Terraria.ID;

namespace Fargowiltas.Items.CaughtNPCs
{
    public class Stylist : CaughtNPC
    {
        public override int Type => NPCID.Stylist;

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'Did you even try to brush your hair today?'");
        }
    }
}