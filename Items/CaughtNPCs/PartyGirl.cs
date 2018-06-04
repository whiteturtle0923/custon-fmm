using Terraria;
using Terraria.DataStructures;
using Terraria.ID;

namespace Fargowiltas.Items.CaughtNPCs
{
    public class PartyGirl : CaughtNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Party Girl");
            Tooltip.SetDefault("'We have to talk. It's... it's about parties.'");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.makeNPC = NPCID.PartyGirl;
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(6, 23));
        }

        public override string Texture => "Terraria/NPC_208";
    }
}