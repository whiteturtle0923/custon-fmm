using Terraria;
using Terraria.DataStructures;
using Terraria.ID;

namespace Fargowiltas.Items.CaughtNPCs
{
    public class Angler : CaughtNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Angler");
            Tooltip.SetDefault("'You'd be a great helper minion!'");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.makeNPC = NPCID.Angler;
            item.bait = 15;
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(6, 23));
        }

        public override string Texture => "Terraria/NPC_369";
    }
}