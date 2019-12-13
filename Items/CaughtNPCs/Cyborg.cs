using Terraria.ID;

namespace Fargowiltas.Items.CaughtNPCs
{
    public class Cyborg : CaughtNPC
    {
        public override int Type => NPCID.Cyborg;

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'My expedition efficiency was critically reduced when a projectile impacted my locomotive actuator.'");
        }
    }
}