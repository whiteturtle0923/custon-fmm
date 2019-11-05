using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Projectiles
{
    public class SpawnProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spawn");
        }

        public override void SetDefaults()
        {
            projectile.width = 2; 
            projectile.height = 2;
            projectile.aiStyle = -1;
            projectile.timeLeft = 1;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.hide = true;
        }

        public override bool CanDamage()
        {
            return false;
        }

        public override void Kill(int timeLeft)
        {
            if (Main.netMode != 1)
            {
                int n = NPC.NewNPC((int)projectile.Center.X, (int)projectile.Center.Y, (int)projectile.ai[0]);
                if (n != 200 && Main.netMode == 2)
                    NetMessage.SendData(23, -1, -1, null, n);
            }
        }
    }
}