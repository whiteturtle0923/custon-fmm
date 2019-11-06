using Fargowiltas.NPCs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Projectiles
{
    public class SpawnProj : ModProjectile
    {
        private int[] bosses = new int[] { NPCID.KingSlime, NPCID.EyeofCthulhu, NPCID.EaterofWorldsHead, NPCID.BrainofCthulhu, NPCID.QueenBee, NPCID.SkeletronHead, NPCID.TheDestroyer, NPCID.SkeletronPrime, NPCID.Retinazer, NPCID.Spazmatism, NPCID.Plantera, NPCID.Golem, NPCID.DukeFishron, NPCID.CultistBoss, NPCID.MoonLordCore, }; 

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spawn");
        }

        public override void SetDefaults()
        {
            projectile.width = 1;
            projectile.height = 1;
            projectile.aiStyle = 0;
            projectile.friendly = true;
            projectile.timeLeft = 10;
        }

        public override void Kill(int timeLeft)
        {
            //for cultist meme
            if (projectile.ai[1] == 1)
            {
                int npc = NPC.NewNPC((int)projectile.Center.X, (int)projectile.Center.Y, (int)projectile.ai[0]);
                Main.npc[npc].GetGlobalNPC<FargoGlobalNPC>().pillarSpawn = false;
            }
            //death fairy
            else if (projectile.ai[1] == 2)
            {
                for (int i = 0; i < 6; i++)
                {
                    int spawn = NPC.NewNPC((int)projectile.Center.X, (int)projectile.Center.Y, bosses[i]);
                }

                NPC.SpawnWOF(Main.player[projectile.owner].Center);
            }
            //mutant voodoo
            else if (projectile.ai[1] == 3)
            {
                foreach (int boss in bosses)
                {
                    int spawn = NPC.NewNPC((int)projectile.Center.X, (int)projectile.Center.Y, boss);

                    if (boss == NPCID.CultistBoss)
                    {
                        Main.npc[spawn].GetGlobalNPC<FargoGlobalNPC>().pillarSpawn = false;
                    }
                }

                NPC.SpawnWOF(Main.player[projectile.owner].Center);
            }
            else
            {
                int npc = NPC.NewNPC((int)projectile.Center.X, (int)projectile.Center.Y, (int)projectile.ai[0]);
            }
        }
    }
}