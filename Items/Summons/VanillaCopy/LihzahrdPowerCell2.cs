using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons
{
    public class LihzahrdPowerCell2 : BaseSummon
    {
        public override string Texture => "Terraria/Item_1293";

        public override int Type => NPCID.Golem;

        public override string NPCName => "Golem";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lihzahrdy Power Cell");
            Tooltip.SetDefault("Summons the Golem without an altar");
        }

        public override bool CanUseItem(Player player)
        {
            return NPC.downedPlantBoss;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LihzahrdPowerCell);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}