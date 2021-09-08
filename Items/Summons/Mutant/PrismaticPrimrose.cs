using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.Mutant
{
    public class PrismaticPrimrose : BaseSummon
    {
        public override int Type => NPCID.HallowBoss;

        public override string NPCName => "Empress of Light";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Prismatic Primrose");
            Tooltip.SetDefault("Summons the Empress of Light");
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