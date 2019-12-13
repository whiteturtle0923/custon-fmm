using Terraria;
using Terraria.ID;

namespace Fargowiltas.Items.CaughtNPCs
{
    public class Guide : CaughtNPC
    {
        public override int Type => NPCID.Guide;

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'They say there is a person who will tell you how to survive in this land.'");
        }

        public override void PostUpdate()
        {
            if (item.lavaWet && !NPC.AnyNPCs(NPCID.WallofFlesh))
            {
                NPC.SpawnWOF(item.position);
                item.TurnToAir();
            }
        }
    }
}