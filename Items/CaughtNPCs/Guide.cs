using Terraria;
using Terraria.DataStructures;
using Terraria.ID;

namespace Fargowiltas.Items.CaughtNPCs
{
    public class Guide : CaughtNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Guide");
            Tooltip.SetDefault("'They say there is a person who will tell you how to survive in this land.'");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.makeNPC = NPCID.Guide;
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(6, 26));
        }

        public override string Texture => "Terraria/NPC_22";

        public override void PostUpdate()
        {
            if (item.lavaWet && !NPC.AnyNPCs(NPCID.WallofFlesh))
            {
                NPC.SpawnWOF(item.position);
                item.active = false;
                item.type = 0;
                item.stack = 0;
            }
        }
    }
}