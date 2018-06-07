using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Projectiles
{
    public class TrollbombProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Trollbomb");
        }

        public override void SetDefaults()
        {
            projectile.width = 22; 
            projectile.height = 30;   
            projectile.aiStyle = 16;  //explosives AI
            projectile.penetrate = -1; 
            projectile.timeLeft = 150;
        }

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 43);

            NPC.NewNPC((int)projectile.Center.X, (int)projectile.Center.Y - 10, NPCID.DungeonGuardian, 0, projectile.whoAmI, 0, 0);
            Main.NewText("RUN YOU SCRUB", 175, 75, 255);
        }
    }
}