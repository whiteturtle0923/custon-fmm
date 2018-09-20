using Terraria;
using Terraria.DataStructures;

namespace Fargowiltas.Items.CaughtNPCs
{
    public class Abominationn : CaughtNPC
    {
        public override bool Autoload(ref string name)
        {
            return true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Abominationn");
            Tooltip.SetDefault("'I sure wish I was a boss.'");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.makeNPC = (short)mod.NPCType("Abominationn");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(6, 25));
        }

        public override string Texture => "Fargowiltas/NPCs/Abominationn";
    }
}