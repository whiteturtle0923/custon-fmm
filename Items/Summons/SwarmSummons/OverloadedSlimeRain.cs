using Fargowiltas.Items.Summons.Abom;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.SwarmSummons
{
    public class OverloadedSlimeRain : ModItem
    {
        public override string Texture => "Fargowiltas/Items/Summons/Abom/SlimyBarometer";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Slimy Stormcaller");
            Tooltip.SetDefault("Summons an Overloaded Slime Rain\nUse again to stop the event");
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

        public override bool UseItem(Player player)
        {
            if (FargoWorld.OverloadedSlimeRain)
            {
                // cancel it
                Main.StopSlimeRain();
                FargoWorld.OverloadedSlimeRain = false;
            }
            else
            {
                if (Main.netMode != 1)
                {
                    
                    Main.StartSlimeRain();
                    Main.slimeWarningDelay = 1;
                    Main.slimeWarningTime = 1;
                    Main.slimeRainKillCount = -10000; 
                }
                else
                {
                    NetMessage.SendData(61, -1, -1, null, player.whoAmI, -1f);
                }

                FargoWorld.OverloadedSlimeRain = true;
                Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
            }

            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<SlimyBarometer>());
            recipe.AddIngredient(null, "Overloader", 10);
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
