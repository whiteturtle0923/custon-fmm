using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons
{
    public class CelestialSigil2 : BaseSummon
    {
        public override string Texture => "Terraria/Item_3601";

        public override int Type => NPCID.MoonLordCore;

        public override string NPCName => "Moon Lord";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Celestially Sigil");
            Tooltip.SetDefault("Summons the Moon Lord instantly");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CelestialSigil);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}