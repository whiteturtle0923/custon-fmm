using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons
{
    public class WormyFood : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wormy Food");
            Tooltip.SetDefault("Summons the Eater of Worlds");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 20;
            item.value = 1000;
            item.rare = 0;
            item.useAnimation = 30;
            item.useTime = 30;
            item.useStyle = 4;
            item.consumable = true;
        }

        public override string Texture => "Terraria/Item_70";

        public override bool CanUseItem(Player player)
        {
            if (player.ZoneCorrupt || player.ZoneCrimson)
            {
                return true;
            }

            return false;
        }

        public override bool UseItem(Player player)
        {
            NPC.SpawnOnPlayer(player.whoAmI, NPCID.EaterofWorldsHead);
            Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.WormFood);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}