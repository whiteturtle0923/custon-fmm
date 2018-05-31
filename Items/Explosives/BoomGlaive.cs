using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Explosives
 {
    public class BoomGlaive : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Boom Glaive");
            Tooltip.SetDefault("Rapid firing explosives");
        }
    
        public override void SetDefaults()
    	{
    		item.width = 11;  
            item.height = 11;
            item.damage = 16;  
    		item.thrown = true;  
    		item.noMelee = true;
    		item.consumable = true; 
    		item.noUseGraphic = true;
    		item.useAnimation = 9;  
    		item.scale = 0.75f; 
    		item.crit = 5; 
    		item.useStyle = 1; 
    		item.useTime = 7; 
    		item.knockBack = 3f; 
    		item.UseSound = SoundID.Item1; 
    		item.autoReuse = true;  
    		item.maxStack = 999;
    		item.rare = 1;  
    		item.shoot = mod.ProjectileType("GlaiveProj");
    		item.shootSpeed = 11f; 
    	}
    	
    	public override void AddRecipes()
    	{
    		ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("BoomShuriken"), 50);
            recipe.AddIngredient(ItemID.Dynamite, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 50);
            recipe.AddRecipe();
    	}
    }
}
