using Terraria.ID;

namespace Fargowiltas.Items.CaughtNPCs
{
    public class Wizard : CaughtNPC
    {
        public override int Type => NPCID.Wizard;

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'Want me to pull a coin from behind your ear? No? Ok.'");
        }
    }
}