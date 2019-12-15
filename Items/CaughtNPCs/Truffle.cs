using Terraria.ID;

namespace Fargowiltas.Items.CaughtNPCs
{
    public class Truffle : CaughtNPC
    {
        public override int Type => NPCID.Truffle;

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'Everyone in this town feels a bit off.'");
        }
    }
}