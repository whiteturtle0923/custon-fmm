using Terraria;
using Terraria.DataStructures;
using Terraria.ID;

namespace Fargowiltas.Items.CaughtNPCs
{
    public class Painter : CaughtNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Painter");
            Tooltip.SetDefault("'I know the difference between turquoise and blue-green. But I won't tell you.'");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.makeNPC = NPCID.Painter;
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(6, 25));
        }

        public override string Texture => "Terraria/NPC_227";
    }
}