using Terraria;
using Terraria.DataStructures;
using Terraria.ID;

namespace Fargowiltas.Items.CaughtNPCs
{
    public class Truffle : CaughtNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Truffle");
            Tooltip.SetDefault("'Everyone in this town feels a bit off.'");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.makeNPC = NPCID.Truffle;
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(6, 23));
        }

        public override string Texture => "Terraria/NPC_160";
    }
}