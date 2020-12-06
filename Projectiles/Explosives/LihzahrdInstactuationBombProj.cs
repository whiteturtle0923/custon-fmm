using Fargowiltas.Tiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Fargowiltas.Projectiles.Explosives
{
    public class LihzahrdInstactuationBombProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lihzahrd Instactuation Bomb");
        }

        public override void SetDefaults()
        {
            projectile.width = 20;
            projectile.height = 36;
            projectile.aiStyle = 16;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 1;
        }

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.Item14, projectile.Center);

            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                return;
            }

            int xPos = (int)projectile.Center.X / 16;
            int yPos = (int)projectile.Center.Y / 16;

            for (int i = -45; i <= 45; i++)
            {
                for (int j = -50; j <= 0; j++)
                {
                    int tileX = xPos + i;
                    int tileY = yPos + j;

                    if (tileX < 0 || tileX > Main.maxTilesX || tileY <= 0 || tileY > Main.maxTilesY)
                        continue;

                    Tile tile = Framing.GetTileSafely(tileX, tileY);

                    if (tile.type == TileID.LihzahrdAltar)
                        continue;

                    if (tile.wall != WallID.LihzahrdBrickUnsafe)
                        continue;

                    //check for chest above this block
                    Tile tileAbove = Framing.GetTileSafely(tileX, tileY - 1);
                    if (TileID.Sets.BasicChest[tileAbove.type])
                    {
                        TileObjectData data = TileObjectData.GetTileData(tileAbove.type, 0);
                        int x = tileX - (tile.frameX / 18 % data.Width);
                        int y = tileY - 1 - (tile.frameY / 18 % data.Height); //get top left of chest

                        WorldGen.KillTile(x, y);
                        if (Main.netMode == NetmodeID.Server)
                            NetMessage.SendTileSquare(-1, x, y, 3);

                        //if couldnt destroy chest, ignore this block
                        if (TileID.Sets.BasicChest[tileAbove.type])
                            continue;
                    }

                    if (TileID.Sets.BasicChest[tile.type])
                    {
                        TileObjectData data = TileObjectData.GetTileData(tile.type, 0);
                        int x = tileX - tile.frameX / 18 % data.Width;
                        int y = tileY - tile.frameY / 18 % data.Height; //get top left of chest

                        WorldGen.KillTile(x, y); //try to kill chest
                        if (Main.netMode == NetmodeID.Server)
                            NetMessage.SendTileSquare(-1, x, y, 3);

                        continue;
                    }

                    if (tile.type == TileID.LihzahrdBrick)
                    {
                        tile.inActive(true); //actuate it
                        if (Main.netMode == NetmodeID.Server)
                            NetMessage.SendTileSquare(-1, tileX, tileY, 1);

                        continue;
                    }

                    WorldGen.KillTile(tileX, tileY);
                    if (Main.netMode == NetmodeID.Server)
                        NetMessage.SendTileSquare(-1, tileX, tileY, 1);
                }
            }
        }
    }
}