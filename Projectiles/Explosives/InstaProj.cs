using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Projectiles.Explosives
{
    public class InstaProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Instavator");
        }

        public override void SetDefaults()
        {
            projectile.width = 20;
            projectile.height = 36;
            projectile.aiStyle = 16;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 170;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return true;
        }

        public override void Kill(int timeLeft)
        {
            Vector2 position = projectile.Center;
            Main.PlaySound(SoundID.Item14, (int)position.X, (int)position.Y);

            //7 across
            for (int x = -3; x <= 3; x++)
            {
                for (int y = (int)(1 + position.Y / 16.0f); y <= (Main.maxTilesY - 40); y++)
                {
                    int xPosition = (int)(x + position.X / 16.0f);
                    Tile tile = Main.tile[xPosition, y];

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

                    //tile destroy
                    WorldGen.KillTile(xPosition, y, false, false, false);
                    WorldGen.KillWall(xPosition, y);
                    Dust.NewDust(position, 22, 22, DustID.Smoke, 0.0f, 0.0f, 120, new Color(), 1f);

                    //kill liquids
                    if (tile != null)
                    {
                        tile.liquid = 0;
                        tile.lava(false);
                        tile.honey(false);
                        if (Main.netMode == 2)
                        {
                            NetMessage.sendWater(xPosition, y);
                        }
                    }

                    //spawn structure
                    WorldGen.PlaceWall(xPosition, y, WallID.Stone);

                    if ((x == -3) || (x == 3))
                    {
                        WorldGen.PlaceTile(xPosition, y, TileID.GrayBrick);
                    }

                    if ((x == -2 || x == 2) && (y % 10 == 0))
                    {
                        WorldGen.PlaceTile(xPosition, y, TileID.Torches);
                    }

                    if (x == 0)
                    {
                        WorldGen.PlaceTile(xPosition, y, TileID.Rope);
                    }
                }
            }
        }
    }
}