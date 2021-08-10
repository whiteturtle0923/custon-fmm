using Fargowiltas.Tiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Projectiles.Explosives
{
    public class MiniInstabridgeProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mini Instabridge");
        }

        public override void SetDefaults()
        {
            Projectile.width = 20;
            Projectile.height = 36;
            Projectile.aiStyle = 16;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 1;
        }

        public override bool? CanDamage()
        {
            return false;
        }

        public override void Kill(int timeLeft)
        {
            Vector2 position = Projectile.Center;
            SoundEngine.PlaySound(SoundID.Item14, (int)position.X, (int)position.Y);

            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                return;
            }

            // All the way across
            const int length = 400;
            bool goLeft = Projectile.Center.X < Main.player[Projectile.owner].Center.X;
            int min = goLeft ? -length : 0;
            int max = goLeft ? 0 : length;
            for (int x = min; x < max; x++)
            {
                int xPosition = (int)(x + position.X / 16.0f);
                int yPosition = (int)(position.Y / 16.0f);

                if (xPosition < 0 || xPosition >= Main.maxTilesX || yPosition < 0 || yPosition >= Main.maxTilesY)
                    continue;

                Tile tile = Main.tile[xPosition, yPosition];

                if (tile == null)
                {
                    continue;
                }

                if (tile.type == TileID.Trees || tile.type == TileID.Cactus)
                {
                    FargoGlobalTile.ClearEverything(xPosition, yPosition);
                }

                // Spawn platforms
                WorldGen.PlaceTile(xPosition, yPosition, TileID.Platforms);

                NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
            }
        }
    }
}