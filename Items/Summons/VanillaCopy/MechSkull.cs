using Fargowiltas.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.Chat;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons
{
    public class MechSkull : ModItem
    {
        public override string Texture => "Terraria/Images/Item_557";

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Some Kind of Metallic Skull");
            Tooltip.SetDefault("Summons Skeletron Prime");
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.maxStack = 20;
            Item.value = 1000;
            Item.rare = 3;
            Item.useAnimation = 30;
            Item.useTime = 30;
            Item.useStyle = 4;
            Item.consumable = true;
            Item.shoot = ModContent.ProjectileType<SpawnProj>();
        }

        public override bool CanUseItem(Player player)
        {
            return Main.dayTime != true;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 pos = new Vector2((int)player.position.X + Main.rand.Next(-800, 800), (int)player.position.Y + Main.rand.Next(-1000, -250));

            if (!Main.dayTime)
            {
                if (!NPC.downedMechBoss3)
                {
                    Main.dayTime = false;
                    Main.time = 0;

                    if (Main.netMode == NetmodeID.Server) //sync time
                        NetMessage.SendData(MessageID.WorldData, -1, -1, null, 0, 0f, 0f, 0f, 0, 0, 0);
                }

                Projectile.NewProjectile(player.GetProjectileSource_Item(source.Item), pos, Vector2.Zero, ModContent.ProjectileType<SpawnProj>(), 0, 0, Main.myPlayer, NPCID.SkeletronPrime);

                if (Main.netMode == NetmodeID.Server)
                {
                    ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral("Skeletron Prime has awoken!"), new Color(175, 75, 255));
                }
                else
                {
                    Main.NewText("Skeletron Prime has awoken!", new Color(175, 75, 255));
                }
            }

            SoundEngine.PlaySound(SoundID.Roar, player.position, 0);

            return false;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
               .AddIngredient(ItemID.MechanicalSkull)
               .AddTile(TileID.WorkBenches)
               .Register();
        }
    }
}