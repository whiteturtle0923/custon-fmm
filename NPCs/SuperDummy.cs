using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.NPCs
{
    public class SuperDummy : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Super Dummy");
        }

        public override void SetDefaults()
        {
            npc.CloneDefaults(NPCID.TargetDummy);
            npc.aiStyle = -1;
            npc.width = 28;
            npc.height = 50;
            npc.immortal = false;
        }

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position) => false;

        public override bool CheckDead()
        {
            if (npc.ai[0] == 0)
                npc.life = npc.lifeMax;
            return npc.ai[0] == 0;
        }
    }
}
