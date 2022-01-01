using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons
{
    public class SuspiciousEye : BaseSummon
    {
        public override string Texture => "Terraria/Images/Item_43";

        public override int NPCType => NPCID.EyeofCthulhu;

        public override string NPCName => "Eye of Cthulhu";

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Eye That Could Be Seen As Suspicious");
            Tooltip.SetDefault("Summons the Eye of Cthulhu");
        }

        public override bool CanUseItem(Player player)
        {
            return !Main.dayTime;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
               .AddIngredient(ItemID.SuspiciousLookingEye)
               .AddTile(TileID.WorkBenches)
               .Register();
        }
    }
}