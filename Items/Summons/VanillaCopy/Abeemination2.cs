using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons
{
    public class Abeemination2 : BaseSummon
    {
        public override string Texture => "Terraria/Item_1133";

        public override int Type => NPCID.QueenBee;

        public override string NPCName => "Queen Bee";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("A Bee In My Nation");
            Tooltip.SetDefault("Summons Queen Bee");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Abeemination);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}