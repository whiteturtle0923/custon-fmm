using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons
{
	public class MechWorm : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Some Kind of Metallic Worm");
			Tooltip.SetDefault("Summons the Destroyer");
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.maxStack = 20;
			item.value = 1000;
			item.rare = 3;
			item.useAnimation = 30;
			item.useTime = 30;
			item.useStyle = 4;
			item.consumable = true;
		}

        public override string Texture
        {
            get
            {
                return "Terraria/Item_556";
            }
        }

        public override bool CanUseItem(Player player)
		{
			return Main.dayTime != true;
		}
		
		public override bool UseItem(Player player)
		{
			NPC.NewNPC((int)player.position.X + Main.rand.Next(-800, 800), (int)player.position.Y + Main.rand.Next(250, 1000), NPCID.TheDestroyer);
			Main.NewText("The Destroyer has awoken!", 175, 75, 255);
			Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
			return true;
		}
		
		public override void AddRecipes()
		{
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MechanicalWorm);
			recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
		}
	}
}