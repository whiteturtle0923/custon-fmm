using Terraria;
using Terraria.DataStructures;
using Terraria.ID;

namespace Fargowiltas.Items.CaughtNPCs
{
    public class Clothier : CaughtNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Clothier");
            Tooltip.SetDefault("'Thanks again for freeing me from my curse.'");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.makeNPC = NPCID.Clothier;
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(6, 23));
        }

        public override string Texture => "Terraria/NPC_54";
    }
}