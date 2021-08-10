using Fargowiltas.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.Chat;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.Mutant
{
    public class SuspiciousSkull : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Suspicious Skull");
            Tooltip.SetDefault("Summons Skeletron without killing the Clothier" +
                               "\nSummons the Dungeon Guardian during the day");
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.maxStack = 20;
            Item.value = Item.sellPrice(0, 0, 2);
            Item.rare = ItemRarityID.Blue;
            Item.useAnimation = 30;
            Item.useTime = 30;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.consumable = true;
            Item.shoot = ModContent.ProjectileType<SpawnProj>();
        }

        public override bool Shoot(Player player, ProjectileSource_Item_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 pos = new Vector2((int)player.position.X + Main.rand.Next(-800, 800), (int)player.position.Y + Main.rand.Next(-1000, -250));

            if (!Main.dayTime)
            {
                if (!NPC.downedBoss3)
                {
                    Main.dayTime = false;
                    Main.time = 0;

                    if (Main.netMode == NetmodeID.Server) //sync time
                        NetMessage.SendData(MessageID.WorldData, -1, -1, null, 0, 0f, 0f, 0f, 0, 0, 0);
                }

                Projectile.NewProjectile(player.GetProjectileSource_Item(source.Item), pos, Vector2.Zero, ModContent.ProjectileType<SpawnProj>(), 0, 0, Main.myPlayer, NPCID.SkeletronHead);

                if (Main.netMode == NetmodeID.Server)
                {
                    ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral("Skeletron has awoken!"), new Color(175, 75, 255));
                }
                else
                {
                    Main.NewText("Skeletron has awoken!", new Color(175, 75, 255));
                }
            }
            else
            {
                pos.X = player.position.X;
                pos.Y = player.position.Y - 500;

                Projectile.NewProjectile(player.GetProjectileSource_Item(source.Item), pos, Vector2.Zero, ModContent.ProjectileType<SpawnProj>(), 0, 0, Main.myPlayer, NPCID.DungeonGuardian);

                if (Main.netMode == NetmodeID.Server)
                {
                    ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral("Dungeon Guardian has awoken!"), new Color(175, 75, 255));
                }
                else
                {
                    Main.NewText("Dungeon Guardian has awoken!", new Color(175, 75, 255));
                }
            }

            SoundEngine.PlaySound(SoundID.Roar, player.position, 0);

            return false;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
              .AddIngredient(ItemID.ClothierVoodooDoll)
              .AddTile(TileID.WorkBenches)
              .Register();
        }
    }
}