using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Fargowiltas.Items.Vanity
{
	[AutoloadEquip(EquipType.Head)]
	public class mutantmask : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mutant Mask");
		}
		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.rare = 1;
			item.vanity = true;
		}

		
		
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
			
			recipe.AddIngredient(ItemID.EyeMask);
			recipe.AddIngredient(ItemID.BrainMask);
			recipe.AddIngredient(ItemID.EaterMask);
			
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
}
	}
}