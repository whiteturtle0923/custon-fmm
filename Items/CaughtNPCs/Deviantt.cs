using Terraria;
using Terraria.DataStructures;

namespace Fargowiltas.Items.CaughtNPCs
{
    public class Deviantt : CaughtNPC
    {
        public override string Texture => "Fargowiltas/NPCs/Deviantt";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Deviantt");
            Tooltip.SetDefault("'Embrace suffering... and while you're at it, embrace another purchase!'");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.makeNPC = (short)mod.NPCType("Deviantt");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(6, 23));
        }
    }
}