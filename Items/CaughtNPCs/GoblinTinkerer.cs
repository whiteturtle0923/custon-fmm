using Terraria.ID;

namespace Fargowiltas.Items.CaughtNPCs
{
    public class GoblinTinkerer : CaughtNPC
    {
        public override int Type => NPCID.GoblinTinkerer;

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'Looking for a gadgets expert? I'm your goblin!'");
        }
    }
}