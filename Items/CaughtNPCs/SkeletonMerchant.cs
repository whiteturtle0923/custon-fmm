using Terraria.ID;

namespace Fargowiltas.Items.CaughtNPCs
{
    public class SkeletonMerchant : CaughtNPC
    {
        public override int Type => NPCID.SkeletonMerchant;

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'You would not believe some of the things people throw at me... Wanna buy some of it?'");
        }
    }
}