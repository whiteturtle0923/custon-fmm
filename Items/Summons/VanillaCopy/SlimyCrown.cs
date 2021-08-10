using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons
{
    public class SlimyCrown : BaseSummon
    {
        public override string Texture => "Terraria/Images/Item_560";

        public override int Type => NPCID.KingSlime;

        public override string NPCName => "King Slime";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Slimy Crown");
            Tooltip.SetDefault("Summons King Slime");
        }

        public override void AddRecipes()
        {
            CreateRecipe()
               .AddIngredient(ItemID.SlimeCrown)
               .AddTile(TileID.WorkBenches)
               .Register();
        }
    }
}