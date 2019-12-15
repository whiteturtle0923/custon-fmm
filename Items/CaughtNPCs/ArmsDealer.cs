using Terraria.ID;

namespace Fargowiltas.Items.CaughtNPCs
{
    public class ArmsDealer : CaughtNPC
    {
        public override int Type => NPCID.ArmsDealer;

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'Keep your hands off my gun, buddy!'");
        }
    }
}