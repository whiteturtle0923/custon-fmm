using Fargowiltas.Tiles;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Projectiles.Explosives
{
    public class CityBuster : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("City Buster");
        }

        public override void SetDefaults()
        {
            projectile.width = 30;
            projectile.height = 30;
            projectile.aiStyle = 16;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 300;
        }

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.Item15, projectile.Center);
            Main.PlaySound(SoundID.Item14, projectile.Center);

            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                return;
            }

            Vector2 position = projectile.Center;
            int radius = 50;     //bigger = boomer

            for (int x = -radius; x <= (radius); x++)
            {
                for (int y = -radius; y <= (radius); y++)
                {
                    if (Math.Sqrt(x * x + y * y) <= radius)   //circle
                    {
                        int xPosition = (int)(x + position.X / 16.0f);
                        int yPosition = (int)(y + position.Y / 16.0f);

                        if (xPosition < 0 || xPosition >= Main.maxTilesX || yPosition < 0 || yPosition >= Main.maxTilesY)
                            continue;

                        Tile tile = Main.tile[xPosition, yPosition];
                        if (tile == null)
                            continue;

                        // Testing for blocks that should not be destroyed
                        bool noFossil = tile.type == TileID.DesertFossil && !NPC.downedBoss2;
                        bool noDungeon = (tile.type == TileID.BlueDungeonBrick || tile.type == TileID.GreenDungeonBrick || tile.type == TileID.PinkDungeonBrick) && !NPC.downedBoss3;
                        bool noHMOre = (tile.type == TileID.Cobalt || tile.type == TileID.Palladium || tile.type == TileID.Mythril || tile.type == TileID.Orichalcum || tile.type == TileID.Adamantite || tile.type == TileID.Titanium) && !NPC.downedMechBossAny;
                        bool noChloro = tile.type == TileID.Chlorophyte && (!NPC.downedMechBoss1 || !NPC.downedMechBoss2 || !NPC.downedMechBoss3);
                        bool noLihzahrd = tile.type == TileID.LihzahrdBrick && !NPC.downedGolemBoss;

                        if (noFossil || noDungeon || noHMOre || noChloro || noLihzahrd)
                            continue;

                        FargoGlobalTile.FindChestTopLeft(xPosition, yPosition, true);
                        
                        WorldGen.KillTile(xPosition, yPosition, noItem: true);
                        tile.lava(false);
                        tile.honey(false);

                        if (Main.netMode == NetmodeID.Server)
                        {
                            NetMessage.sendWater(xPosition, yPosition);
                            NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                        }
                    }
                }
            }

            Main.refreshMap = true;
        }
    }
}