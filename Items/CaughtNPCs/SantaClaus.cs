using Terraria;
using Terraria.DataStructures;
using Terraria.ID;

namespace Fargowiltas.Items.CaughtNPCs
{
    public class SantaClaus : CaughtNPC
    {
        public override bool Autoload(ref string name)
        {
            return true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Santa Claus");
            Tooltip.SetDefault("'What? You thought I wasn't real?'");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.makeNPC = NPCID.SantaClaus;
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(6, 25));
        }

        public override string Texture => "Terraria/NPC_142";
    }
}