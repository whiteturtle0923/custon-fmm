using Terraria.ID;

namespace Fargowiltas.Items.CaughtNPCs
{
    public class WitchDoctor : CaughtNPC
    {
        public override int Type => NPCID.WitchDoctor;

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'Which doctor am I? The Witch Doctor am I.'");
        }
    }
}