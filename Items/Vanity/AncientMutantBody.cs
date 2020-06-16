using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Vanity
{
    [AutoloadEquip(EquipType.Body)]
    public class AncientMutantBody : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ancient Mutant Body");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.vanity = true;
            item.rare = ItemRarityID.Blue;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SkeletronMask);
            recipe.AddIngredient(ItemID.DestroyerMask);
            recipe.AddIngredient(ItemID.SkeletronPrimeMask);
            recipe.AddIngredient(ItemID.TwinMask);
            recipe.AddIngredient(ItemID.GolemMask);
            //add empress mask
            recipe.AddIngredient(ItemID.BossMaskMoonlord);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
