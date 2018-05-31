using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Projectiles.Explosives
{
    public class GlaiveProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Glaive");
        }

        public override void SetDefaults()
        {
            projectile.width = 11;
            projectile.height = 11;
            projectile.friendly = true;
            projectile.thrown = true;
            projectile.penetrate = 5;
            projectile.aiStyle = 2;
            projectile.timeLeft = 600;
            aiType = 48;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            projectile.Kill();
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return false;
        }

        public override void Kill(int timeLeft)
        {
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 0, mod.ProjectileType("Explosion"), 0, projectile.knockBack, projectile.owner);

            Vector2 position = projectile.Center;
            Main.PlaySound(SoundID.Item14, (int)position.X, (int)position.Y);
            int radius = 20;     //bigger = boomer

            for (int x = -radius; x <= (radius); x++)
            {
                for (int y = -radius; y <= (radius); y++)
                {
                    int xPosition = (int)(x + position.X / 16.0f);
                    int yPosition = (int)(y + position.Y / 16.0f);

                    Tile tile = Main.tile[xPosition, yPosition];

                    //testing for blocks that should not be destroyed
                    bool noFossil = tile.type == TileID.DesertFossil && !NPC.downedBoss2;
                    bool noDungeon = (tile.type == TileID.BlueDungeonBrick || tile.type == TileID.GreenDungeonBrick || tile.type == TileID.PinkDungeonBrick) && !NPC.downedBoss3;
                    bool noHMOre = (tile.type == TileID.Cobalt || tile.type == TileID.Palladium || tile.type == TileID.Mythril || tile.type == TileID.Orichalcum || tile.type == TileID.Adamantite || tile.type == TileID.Titanium) && !NPC.downedMechBossAny;
                    bool noChloro = tile.type == TileID.Chlorophyte && (!NPC.downedMechBoss1 || !NPC.downedMechBoss2 || NPC.downedMechBoss3);
                    bool noLihzahrd = (tile.type == TileID.LihzahrdBrick && !NPC.downedGolemBoss);

                    if (noFossil || noDungeon || noHMOre || noChloro || noLihzahrd)
                    {
                        continue;
                    }

                    if ((x * x + y * y) <= radius)   //circle
                    {
                        WorldGen.KillTile(xPosition, yPosition);
                        Dust.NewDust(position, 22, 22, DustID.Smoke, 0.0f, 0.0f, 120, new Color());
                    }
                }
            }
        }
    }
}