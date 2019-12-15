using Terraria.ID;

namespace Fargowiltas.Items.CaughtNPCs
{
    public class PartyGirl : CaughtNPC
    {
        public override int Type => NPCID.PartyGirl;

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'We have to talk. It's... it's about parties.'");
        }
    }
}