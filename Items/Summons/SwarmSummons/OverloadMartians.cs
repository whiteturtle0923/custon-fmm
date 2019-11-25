using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.SwarmSummons
{
    class OverloadMartians : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Overloaded Runaway Probe");
            Tooltip.SetDefault("Summons an Overloaded Martian Invasion\nUse again to stop the event");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 1;
            item.value = 1000;
            item.rare = 1;
            item.useAnimation = 30;
            item.useTime = 30;
            item.useStyle = 4;
            item.consumable = false;
        }

        public override string Texture => "Fargowiltas/Items/Summons/NewSummons/RunawayProbe";

        public override bool UseItem(Player player)
        {
            if (FargoWorld.OverloadMartians)
            {
                //cancel it
                Main.invasionSize = 1;
                FargoWorld.OverloadMartians = false;

                if (Main.netMode == 2)
                {
                    NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("The martians have calmed down!"), new Color(175, 75, 255));
                }
                else
                {
                    Main.NewText("The martians have calmed down!", 175, 75, 255);
                }
            }
            else
            {
                if (Main.netMode != 1)
                {
                    Main.invasionDelay = 0;
                    Main.StartInvasion(4);
                    Main.invasionSize = 15000;
                    Main.invasionSizeStart = 15000;
                }
                else
                {
                    NetMessage.SendData(61, -1, -1, null, player.whoAmI, -7f);
                }

                FargoWorld.OverloadMartians = true;
                Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
            }

            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "RunawayProbe");
            recipe.AddIngredient(null, "Overloader", 10);
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
