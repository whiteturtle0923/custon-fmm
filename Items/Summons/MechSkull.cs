<<<<<<< HEAD
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons
{
	public class MechSkull : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Some Kind of Metallic Skull");
			Tooltip.SetDefault("Summons Skeletron Prime");
		}
		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.maxStack = 20;
			item.value = 1000;
			item.rare = 0;
			item.useAnimation = 30;
			item.useTime = 30;
			item.useStyle = 4;
			item.consumable = true;
		}
		
		public override bool CanUseItem(Player player)
		{
			return Main.dayTime != true;
		}
		
		public override bool UseItem(Player player)
		{
			NPC.NewNPC((int)player.position.X + Main.rand.Next(-800, 800), (int)player.position.Y + Main.rand.Next(-1000, -250), NPCID.SkeletronPrime);
			Main.NewText("Skeletron Prime has awoken!", 175, 75, 255);
			
			Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
			return true;
		}
		
		public override void AddRecipes()
		{
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MechanicalSkull);
			recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
		}

		
	}
=======
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons
{
	public class MechSkull : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Some Kind of Metallic Skull");
			Tooltip.SetDefault("Summons Skeletron Prime");
		}
		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.maxStack = 20;
			item.value = 1000;
			item.rare = 0;
			item.useAnimation = 30;
			item.useTime = 30;
			item.useStyle = 4;
			item.consumable = true;
		}
		
		public override bool CanUseItem(Player player)
		{
			return Main.dayTime != true;
		}
		
		public override bool UseItem(Player player)
		{
			NPC.NewNPC((int)player.position.X + Main.rand.Next(-800, 800), (int)player.position.Y + Main.rand.Next(-1000, -250), NPCID.SkeletronPrime);
			Main.NewText("Skeletron Prime has awoken!", 175, 75, 255);
			
			Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
			return true;
		}
		
		public override void AddRecipes()
		{
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MechanicalSkull);
			recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
		}

		
	}
>>>>>>> 66ed39caf4938fca8e7009752b635e42f8a8a58f
}