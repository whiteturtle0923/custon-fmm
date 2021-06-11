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

        public override bool CanDamage()
        {
            return false;
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
            int radius = 60;     //bigger = boomer

            for (int x = -radius; x <= (radius); x++)
            {
                for (int y = -radius * 2; y <= 0; y++)
                {
                    int xPosition = (int)(x + position.X / 16.0f);
                    int yPosition = (int)(y + position.Y / 16.0f);

                    if (xPosition < 0 || xPosition >= Main.maxTilesX || yPosition < 0 || yPosition >= Main.maxTilesY)
                        continue;

                    Tile tile = Main.tile[xPosition, yPosition];
                    if (tile == null)
                        continue;

                    if (!FargoGlobalProjectile.OkayToDestroyTile(tile))
                        continue;

                    FargoGlobalTile.FindChestTopLeft(xPosition, yPosition, true);

                    WorldGen.KillTile(xPosition, yPosition, noItem: true);
                    tile.liquid = 0;
                    tile.lava(false);
                    tile.honey(false);

                    if (Main.netMode == NetmodeID.Server)
                    {
                        NetMessage.sendWater(xPosition, yPosition);
                        NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                    }
                }
            }

            Main.refreshMap = true;
        }
    }
}