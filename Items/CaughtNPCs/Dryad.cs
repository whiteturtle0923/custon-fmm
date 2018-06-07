using Terraria;
using Terraria.DataStructures;
using Terraria.ID;

namespace Fargowiltas.Items.CaughtNPCs
{
    public class Dryad : CaughtNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Dryad");
            Tooltip.SetDefault("'Be safe; Terraria needs you!'");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.makeNPC = NPCID.Dryad;
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(6, 21));
        }

        public override string Texture => "Terraria/NPC_20";
    }
}