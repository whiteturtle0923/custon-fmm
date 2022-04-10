using Fargowiltas.Tiles;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Projectiles.Explosives
{
    public class GraveBuster : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Grave Buster");
        }

        public override void SetDefaults()
        {
            Projectile.width = 30;
            Projectile.height = 30;
            Projectile.aiStyle = 16;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 180;
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
            int radius = 120;     //bigger = boomer

            for (int x = -radius; x <= radius; x++)
            {
                for (int y = -radius; y <= radius; y++)
                {
                    int xPosition = (int)(x + position.X / 16.0f);
                    int yPosition = (int)(y + position.Y / 16.0f);

                    if (xPosition < 0 || xPosition >= Main.maxTilesX || yPosition < 0 || yPosition >= Main.maxTilesY)
                        continue;

                    Tile tile = Main.tile[xPosition, yPosition];

                    if (!FargoGlobalProjectile.OkayToDestroyTile(tile) || FargoGlobalProjectile.TileIsLiterallyAir(tile))
                        continue;

                    if (tile.TileType == TileID.Tombstones)
                        tile.Clear(TileDataType.Tile);
                }
            }

            Main.refreshMap = true;
        }
    }
}