using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.VanillaCopy
{
    public class LihzahrdPowerCell2 : BaseSummon
    {
        public override int Type => NPCID.Golem;

        public override string NPCName => "Golem";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lihzahrd Battery Pack");
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