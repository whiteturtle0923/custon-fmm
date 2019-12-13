using Terraria;
using Terraria.DataStructures;

namespace Fargowiltas.Items.CaughtNPCs
{
    public class Mutant : CaughtNPC
    {
        public override string Texture => "Fargowiltas/NPCs/Mutant";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mutant");
            Tooltip.SetDefault("'You're lucky I'm on your side.'");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.makeNPC = (short)mod.NPCType("Mutant");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(6, 25));
        }
    }
}