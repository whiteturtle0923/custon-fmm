using Terraria;
using Terraria.DataStructures;
using Terraria.ID;

namespace Fargowiltas.Items.CaughtNPCs
{
    public class TravellingMerchant : CaughtNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Travelling Merchant");
            Tooltip.SetDefault("'I sell wares from places that might not even exist!'");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.makeNPC = NPCID.TravellingMerchant;
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(6, 26));
        }

        public override string Texture => "Terraria/NPC_368";
    }
}