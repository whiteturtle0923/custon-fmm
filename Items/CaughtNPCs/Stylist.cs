using Terraria;
using Terraria.DataStructures;
using Terraria.ID;

namespace Fargowiltas.Items.CaughtNPCs
{
    public class Stylist : CaughtNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Stylist");
            Tooltip.SetDefault("'Did you even try to brush your hair today?'");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.makeNPC = NPCID.Stylist;
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(6, 23));
        }

        public override string Texture => "Terraria/NPC_353";
    }
}