using Fargowiltas.Tiles;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
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
            Projectile.width = 30;
            Projectile.height = 30;
            Projectile.aiStyle = 16;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 300;
        }

        public override bool? CanDamage()
        {
            return false;
        }

        public override void Kill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Item15, Projectile.Center);
            SoundEngine.PlaySound(SoundID.Item14, Projectile.Center);

            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                return;
            }

            Vector2 position = Projectile.Center;
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
                    tile.LiquidType = 0;
                    tile.LiquidAmount = 0;
                    //tile.lava(false);
                    //tile.honey(false);

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