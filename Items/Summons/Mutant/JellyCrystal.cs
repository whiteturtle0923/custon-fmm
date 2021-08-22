using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.Mutant
{
    public class JellyCrystal : BaseSummon
    {
        public override string Texture => "Terraria/Images/Item_4988";

        public override int Type => NPCID.QueenSlimeBoss;

        public override string NPCName => "Queen Slime";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Jelly Crystal");
            Tooltip.SetDefault("Summons Queen Slime");
        }

        //public override void AddRecipes()
        //{
        //    CreateRecipe()
        //       .AddIngredient(ItemID.ChlorophyteBar, 2)
        //       .AddIngredient(ItemID.Moonglow, 5)
        //       .AddIngredient(ItemID.Blinkroot, 5)
        //       .AddTile(TileID.DemonAltar)
        //       .Register();
        //}
    }
}