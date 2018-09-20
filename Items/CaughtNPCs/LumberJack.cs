using Terraria;
using Terraria.DataStructures;

namespace Fargowiltas.Items.CaughtNPCs
{
    public class LumberJack : CaughtNPC
    {
        public override bool Autoload(ref string name)
        {
            return true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The LumberJack");
            Tooltip.SetDefault("'I eat a bowl of woodchips for breakfast... without any milk.'");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.makeNPC = (short)mod.NPCType("LumberJack");
            
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(6, 25));
        }

        public override string Texture => "Fargowiltas/NPCs/LumberJack";
    }
}