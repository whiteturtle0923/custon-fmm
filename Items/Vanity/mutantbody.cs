<<<<<<< HEAD
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Vanity
{
	[AutoloadEquip(EquipType.Body)]
	public class mutantbody : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mutant Body");
		}
		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.vanity = true;
			item.rare = 1;
		}


		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
			
			recipe.AddIngredient(ItemID.SkeletronMask);
			recipe.AddIngredient(ItemID.GolemMask);
			recipe.AddIngredient(ItemID.BossMaskMoonlord);
			
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
		}
	}
=======
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Vanity
{
	[AutoloadEquip(EquipType.Body)]
	public class mutantbody : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mutant Body");
		}
		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.vanity = true;
			item.rare = 1;
		}


		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
			
			recipe.AddIngredient(ItemID.SkeletronMask);
			recipe.AddIngredient(ItemID.GolemMask);
			recipe.AddIngredient(ItemID.BossMaskMoonlord);
			
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
		}
	}
>>>>>>> 66ed39caf4938fca8e7009752b635e42f8a8a58f
}