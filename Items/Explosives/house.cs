using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace Fargowiltas.Items.Explosives        
{
    public class house : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("autohouse");
			Tooltip.SetDefault("Cbuilds an NPC house to the right when you right click it \n warning: this will destroy any blocks in the way amd won't work properly if you are in the way when it builds (so stay to the left");
		}
        public override void SetDefaults()
        {   
            item.width = 10;    
            item.height = 32;  
            item.maxStack = 99;   
            item.consumable = true;  
            item.useStyle = 1;   
            item.rare = 4;     //
            item.UseSound = SoundID.Item1; //
            item.useAnimation = 20;  
            item.useTime = 20;   
			item.autoReuse = true;
            item.value = Item.buyPrice(0, 0, 3, 0);     
			item.createTile = mod.TileType("HouseBlock");
        }
        public override void AddRecipes()   
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Wood, 51);  
			recipe.AddIngredient(ItemID.Torch);  
			
			recipe.AddTile(TileID.Anvils); 
			recipe.SetResult(this);   
            recipe.AddRecipe();
        }
    }
}