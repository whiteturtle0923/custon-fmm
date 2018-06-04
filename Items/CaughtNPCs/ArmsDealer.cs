using Terraria;
using Terraria.DataStructures;
using Terraria.ID;

namespace Fargowiltas.Items.CaughtNPCs
{
    public class ArmsDealer : CaughtNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Arms Dealer");
            Tooltip.SetDefault("'Keep your hands off my gun, buddy!'");
        }

        public override void SetDefaults()
        {
            base.SetDefaults()

            item.makeNPC = NPCID.ArmsDealer;
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(6, 25));
        }

        public override string Texture => "Terraria/NPC_19";
    }
}