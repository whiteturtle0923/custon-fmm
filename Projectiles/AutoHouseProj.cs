using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Projectiles
{
    public class AutoHouseProj : ModProjectile
    {

        public override void SetDefaults()
        {
            projectile.width = 1;
            projectile.height = 1;
            projectile.timeLeft = 1;
        }

        public void MakeHouse(int x, int y, Vector2 position, int side)
        {
            int xPosition = (int)((side * -1) + x + position.X / 16.0f);
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
                return;
            }

            //tile destroy
            WorldGen.KillTile(xPosition, yPosition, false, false, false);
            WorldGen.KillWall(xPosition, yPosition);
            Dust.NewDust(position, 22, 22, DustID.Smoke, 0.0f, 0.0f, 120, new Color(), 1f);

            //kill liquids
            if (tile != null)
            {
                tile.liquid = 0;
                tile.lava(false);
                tile.honey(false);
                if (Main.netMode == 2)
                {
                    NetMessage.sendWater(xPosition, yPosition);
                }
            }

            //spawn walls
            if (y != -6 && y != -1 && x != (10 * side) && x != (1 * side))
            {
                WorldGen.PlaceWall(xPosition, yPosition, WallID.Wood);
            }

            //spawn border
            if ((y == -6) || (y == -1) || (x == (10 * side)) || (x == (1 * side) && y == -5))
            {
                WorldGen.PlaceTile(xPosition, yPosition, TileID.WoodBlock);
            }
        }

        public void MakeHouse2(int x, int y, Vector2 position, int side)
        {
            int xPosition = (int)((side * -1) + x + position.X / 16.0f);
            int yPosition = (int)(y + position.Y / 16.0f);

            if (x == (1 * side) && y == -2)
            {
                WorldGen.PlaceTile(xPosition, yPosition, TileID.ClosedDoor);
            }
            if (x == (5 * side) && y == -2)
            {
                WorldGen.PlaceObject(xPosition, yPosition, TileID.Chairs, false, 0, 0, -1, side);
            }
            if (x == (7 * side) && y == -2)
            {
                WorldGen.PlaceTile(xPosition, yPosition, TileID.Tables);
            }
            if (x == (7 * side) && y == -5)
            {
                WorldGen.PlaceTile(xPosition, yPosition, TileID.Torches);
            }
        }

        public override void Kill(int timeLeft)
        {
            Vector2 position = projectile.Center;
            Main.PlaySound(SoundID.Item14, (int)position.X, (int)position.Y);

            if(Main.player[projectile.owner].Center.X < position.X)
            {
                for(int i = 0; i < 2; i++)
                {
                    //10 wide
                    for (int x = 10; x > 0; x--)
                    {
                        //6 tall
                        for (int y = -6; y < 0; y++)
                        {
                            if(i == 0)
                            {
                                MakeHouse(x, y, position, 1);
                            }
                            else
                            {
                                MakeHouse2(x, y, position, 1);
                            }
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < 2; i++)
                {
                    //10 wide
                    for (int x = -10; x < 0; x++)
                    {
                        //6 tall
                        for (int y = -6; y < 0; y++)
                        {
                            if (i == 0)
                            {
                                MakeHouse(x, y, position, -1);
                            }
                            else
                            {
                                MakeHouse2(x, y, position, -1);
                            }
                        }
                    }
                }
            }
        }
    }
}