using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Weapons
{
	public class BrainStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mind Break");
			Tooltip.SetDefault("Summons a mini Brain of Cthulhu to fight for you\nTakes up 2 minion slots");
		}
		public override void SetDefaults()
		{
			item.damage = 32; 
			item.summon = true;
			item.mana = 10;
			item.width = 26;
			item.height = 28;
			item.useTime = 36;
			item.useAnimation = 36;
			item.useStyle = 1;
			item.noMelee = true;
			item.knockBack = 3;
			item.rare = 2; 
			item.UseSound = SoundID.Item44; 
			item.shoot = mod.ProjectileType("BrainProj");
			item.shootSpeed = 10f;
			item.buffType = mod.BuffType("BrainMinion");	//The buff added to player after used the item
			item.buffTime = 3600;				//The duration of the buff, here is 60 seconds
			item.autoReuse = true;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BrainofCthulhuTrophy);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
