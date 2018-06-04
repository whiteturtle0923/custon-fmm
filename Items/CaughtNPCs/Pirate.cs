using Terraria;
using Terraria.DataStructures;
using Terraria.ID;

namespace Fargowiltas.Items.CaughtNPCs
{
    public class Pirate : CaughtNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Pirate");
            Tooltip.SetDefault("'Stay off me booty, ya scallywag!'");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.makeNPC = NPCID.Pirate;
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(6, 26));
        }

        public override string Texture => "Terraria/NPC_229";
    }
}