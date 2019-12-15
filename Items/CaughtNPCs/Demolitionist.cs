using Terraria;
using Terraria.DataStructures;
using Terraria.ID;

namespace Fargowiltas.Items.CaughtNPCs
{
    public class Demolitionist : CaughtNPC
    {
        public override string Texture => "Terraria/NPC_38";

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'It's a good day to die!'");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.makeNPC = NPCID.Demolitionist;
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(6, 25));
        }
    }
}