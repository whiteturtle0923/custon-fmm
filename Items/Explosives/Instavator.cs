using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace Fargowiltas.Items.Explosives         
{
    public class Instavator : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Instavator");
			Tooltip.SetDefault("Creates a hellevator instantly \nDo not use if any important building is below");
		}
        public override void SetDefaults()
        {
            item.damage = 50;     
            item.width = 10;    
            item.height = 32;  
            item.maxStack = 99;   
            item.consumable = true;  
            item.useStyle = 1;   
            item.rare = 1;     
            item.UseSound = SoundID.Item1; 
            item.useAnimation = 20;  
            item.useTime = 20;   
            item.value = Item.buyPrice(0, 0, 3, 0); 
            item.noUseGraphic = true;
            item.noMelee = true;      
            item.shoot = mod.ProjectileType("InstaProj"); 
            item.shootSpeed = 5f; 
        }
        public override void AddRecipes()   
        {
            ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DesertFossil, 40); 
            recipe.AddIngredient(ItemID.Dynamite, 15);  
			recipe.AddIngredient(ItemID.RopeCoil, 10);  
			recipe.AddIngredient(ItemID.Torch, 99);  
			
			recipe.AddTile(TileID.Anvils); 
			recipe.SetResult(this);   
            recipe.AddRecipe();
        }
    }
}