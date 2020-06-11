using Fargowiltas.Tiles;
using Microsoft.Xna.Framework;
using Terraria;
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
            projectile.width = 20;
            projectile.height = 36;
            projectile.aiStyle = 16;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 1;
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
            for (int x = -50; x < 50; x++)
            {
                int xPosition = (int)(x + position.X / 16.0f);
                int yPosition = (int)(position.Y / 16.0f);

                Tile tile = Main.tile[xPosition, yPosition];

                if (tile == null)
                {
                    continue;
                }

                // Testing for blocks that should not be destroyed
                bool noFossil = tile.type == TileID.DesertFossil && !NPC.downedBoss2;
                bool noDungeon = (tile.type == TileID.BlueDungeonBrick || tile.type == TileID.GreenDungeonBrick || tile.type == TileID.PinkDungeonBrick) && !NPC.downedBoss3;
                bool noHMOre = (tile.type == TileID.Cobalt || tile.type == TileID.Palladium || tile.type == TileID.Mythril || tile.type == TileID.Orichalcum || tile.type == TileID.Adamantite || tile.type == TileID.Titanium) && !NPC.downedMechBossAny;
                bool noChloro = tile.type == TileID.Chlorophyte && (!NPC.downedMechBoss1 || !NPC.downedMechBoss2 || !NPC.downedMechBoss3);
                bool noLihzahrd = tile.type == TileID.LihzahrdBrick && !NPC.downedGolemBoss;

                if (noFossil || noDungeon || noHMOre || noChloro || noLihzahrd)
                {
                    continue;
                }

                FargoGlobalTile.ClearEverything(xPosition, yPosition);

                // Spawn platforms
                WorldGen.PlaceTile(xPosition, yPosition, TileID.Platforms);

                NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
            }
        }
    }
}