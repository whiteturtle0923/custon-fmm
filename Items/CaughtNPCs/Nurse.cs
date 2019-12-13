using Terraria.ID;

namespace Fargowiltas.Items.CaughtNPCs
{
    public class Nurse : CaughtNPC
    {
        public override int Type => NPCID.Nurse;

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'Show me where it hurts.'");
        }
    }
}