using Terraria.ID;

namespace Fargowiltas.Items.CaughtNPCs
{
    public class Painter : CaughtNPC
    {
        public override int Type => NPCID.Painter;

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'I know the difference between turquoise and blue-green. But I won't tell you.'");
        }
    }
}