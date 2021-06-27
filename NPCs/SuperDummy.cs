using Microsoft.Xna.Framework;
using Terraria;
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
            npc.lifeMax = int.MaxValue;
            npc.aiStyle = -1;
            npc.width = 28;
            npc.height = 50;
            npc.immortal = false;
            npc.npcSlots = 0;
            npc.dontCountMe = true;
        }

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position) => false;

        public override void AI()
        {
            npc.life = npc.lifeMax;

            if (FargoGlobalNPC.AnyBossAlive())
            {
                npc.life = 0;
                npc.HitEffect();
                npc.StrikeNPCNoInteraction(int.MaxValue, 0, 0, false, false, false);
            }
        }

        public override bool CheckDead() => false;
    }
}
