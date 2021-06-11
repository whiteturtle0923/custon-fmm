using Fargowiltas.Tiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Projectiles.Explosives
{
    public class DoubleObsInstaBridgeProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Double Obsidian Instabridge");
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

        public override bool CanDamage()
        {
            return false;
        }

        public override void Kill(int timeLeft)
        {
            Vector2 position = projectile.Center;
            Main.PlaySound(SoundID.Item14, (int)position.X, (int)position.Y);

            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                return;
            }

            // All the way across
            for (int x = 1; x < Main.maxTilesX; x++)
            {
                // Six down, last is platforms
                for (int y = -40; y <= 0; y++)
                {
                    int xPosition = x;
                    int yPosition = (int)(y + position.Y / 16.0f);

                    if (xPosition < 0 || xPosition >= Main.maxTilesX || yPosition < 0 || yPosition >= Main.maxTilesY)
                        continue;

                    Tile tile = Main.tile[xPosition, yPosition];

                    if (tile == null)
                        continue;

                    if (!FargoGlobalProjectile.OkayToDestroyTile(tile))
                        continue;

                    FargoGlobalTile.ClearEverything(xPosition, yPosition);

                    if (y == -20 || y == 0)
                    {
                        // Spawn platforms
                        WorldGen.PlaceTile(xPosition, yPosition, TileID.Platforms, false, false, -1, 13);
                    }

                    if (Main.netMode == NetmodeID.Server)
                        NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                }
            }
        }
    }
}