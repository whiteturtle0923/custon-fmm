using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Fargowiltas.Projectiles
{
    public class FargoGlobalProjectile : GlobalProjectile
    {
        public override bool InstancePerEntity => true;
        private bool firstTick = true;
        public bool lowRender;

        public override void SetDefaults(Projectile projectile)
        {
            if (projectile.minion || projectile.sentry || projectile.minionSlots > 0 || ProjectileID.Sets.MinionShot[projectile.type])
                lowRender = true;
            switch (projectile.type)
            {
                case ProjectileID.FlowerPetal:
                case ProjectileID.HallowStar:
                case ProjectileID.RainbowFront:
                case ProjectileID.RainbowBack:
                    lowRender = true;
                    break;

                default:
                    break;
            }
        }

        public override bool PreAI(Projectile projectile)
        {
            if (projectile.owner == Main.myPlayer)
            {
                if (firstTick)
                {
                    if (GetInstance<FargoConfig>().ExtraLures && projectile.bobber)
                    {
                        int split = 1;

                        switch (projectile.type)
                        {
                            case ProjectileID.BobberFiberglass:
                            case ProjectileID.BobberFisherOfSouls:
                            case ProjectileID.BobberFleshcatcher:
                                split = 2;
                                break;

                            case ProjectileID.BobberMechanics:
                            case ProjectileID.BobbersittingDuck:
                                split = 3;
                                break;

                            case ProjectileID.BobberHotline:
                            case ProjectileID.BobberGolden:
                                split = 5;
                                break;
                        }

                        if (Main.player[projectile.owner].HasBuff(BuffID.Fishing))
                        {
                            split++;
                        }

                        if (split > 1)
                        {
                            SplitProj(projectile, split);
                        }
                    }
                }
            }

            if (projectile.type == ProjectileID.FlyingPiggyBank && GetInstance<FargoConfig>().StalkerMoneyTrough)
            {
                Player player = Main.player[projectile.owner];
                float dist = Vector2.Distance(projectile.Center, player.Center);

                if (dist > 2000)
                {
                    projectile.Kill();
                }
                else if (dist > 100)
                {
                    Vector2 velocity = Vector2.Normalize(player.Center - projectile.Center) * 3;
                    projectile.position += velocity;
                }
            }

            if (firstTick)
            {
                firstTick = false;

                if (projectile.owner != Main.myPlayer)
                    lowRender = true;
            }

            return true;
        }

        public static void SplitProj(Projectile projectile, int number)
        {
            Projectile split;

            double spread = 0.6 / number;

            for (int i = 0; i < number / 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    int factor = (j == 0) ? 1 : -1;
                    split = NewProjectileDirectSafe(projectile.GetProjectileSource_FromThis(), projectile.Center, projectile.velocity.RotatedBy(factor * spread * (i + 1)), projectile.type, projectile.damage, projectile.knockBack, projectile.owner, projectile.ai[0], projectile.ai[1]);

                    if (split != null)
                    {
                        split.friendly = true;
                        split.GetGlobalProjectile<FargoGlobalProjectile>().firstTick = false;
                    }
                }
            }

            if (number % 2 == 0)
            {
                projectile.active = false;
            }
        }

        public static Projectile NewProjectileDirectSafe(IProjectileSource source, Vector2 pos, Vector2 vel, int type, int damage, float knockback, int owner = 255, float ai0 = 0f, float ai1 = 0f)
        {
            int p = Projectile.NewProjectile(source, pos, vel, type, damage, knockback, owner, ai0, ai1);
            return (p < Main.maxProjectiles) ? Main.projectile[p] : null;
        }

        public override Color? GetAlpha(Projectile projectile, Color lightColor)
        {
            if (lowRender && !projectile.hostile && GetInstance<FargoConfig>().TransparentMinions)
            {
                lightColor *= 0.25f;
                return lightColor;
            }
            return base.GetAlpha(projectile, lightColor);
        }

        public static bool OkayToDestroyTile(Tile tile) // Testing for blocks that should not be destroyed
        {
            bool noFossil = tile.type == TileID.DesertFossil && !NPC.downedBoss2;
            bool noDungeon = !NPC.downedBoss3 &&
                (tile.type == TileID.BlueDungeonBrick || tile.type == TileID.GreenDungeonBrick || tile.type == TileID.PinkDungeonBrick
                || tile.wall == WallID.BlueDungeonSlabUnsafe || tile.wall == WallID.BlueDungeonTileUnsafe || tile.wall == WallID.BlueDungeonUnsafe
                || tile.wall == WallID.GreenDungeonSlabUnsafe || tile.wall == WallID.GreenDungeonTileUnsafe || tile.wall == WallID.GreenDungeonUnsafe
                || tile.wall == WallID.PinkDungeonSlabUnsafe || tile.wall == WallID.PinkDungeonTileUnsafe || tile.wall == WallID.PinkDungeonUnsafe
            );
            bool noHMOre = (tile.type == TileID.Cobalt || tile.type == TileID.Palladium || tile.type == TileID.Mythril || tile.type == TileID.Orichalcum || tile.type == TileID.Adamantite || tile.type == TileID.Titanium) && !NPC.downedMechBossAny;
            bool noChloro = tile.type == TileID.Chlorophyte && (!NPC.downedMechBoss1 || !NPC.downedMechBoss2 || NPC.downedMechBoss3);
            bool noLihzahrd = (tile.type == TileID.LihzahrdBrick || tile.wall == WallID.LihzahrdBrickUnsafe) && !NPC.downedGolemBoss;

            if (noFossil || noDungeon || noHMOre || noChloro || noLihzahrd)
                return false;

            return true;
        }
    }
}