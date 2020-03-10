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
            npc.width = 28;
            npc.height = 50;
            npc.damage = 0;
            npc.defense = 0;
            npc.lifeMax = 1000;
            npc.HitSound = SoundID.NPCHit15;
            npc.DeathSound = SoundID.NPCDeath2;
            npc.knockBackResist = 0f;
            npc.aiStyle = -1;
            npc.immortal = true;
        }

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            return false;
        }
    }
}
