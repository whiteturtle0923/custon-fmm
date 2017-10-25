using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace Fargowiltas.Items.Explosives             
{
    public class Trollbomb : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Troll Bomb");
			Tooltip.SetDefault("'What could go wrong?' \nOnly Snek knows");
		}
        public override void SetDefaults()
        {
            item.damage = 1;     		
            item.width = 10;    
            item.height = 32;   
            item.maxStack = 1;   
            item.consumable = false;  
            item.useStyle = 5;   
			item.mana = 10;
            item.rare = 1;    
            item.UseSound = SoundID.Item18; 
			item.autoReuse = true;
            item.useAnimation = 20;  
            item.useTime = 20;     
            item.value = Item.buyPrice(0, 0, 3, 0);   
            item.noMelee = true;      
            item.shoot = 1;
            item.shootSpeed = 5f; 
        }
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float spread = 45f * 0.0174f;
            double startAngle = Math.Atan2(speedX, speedY)- spread/2;
            double deltaAngle = spread/8f;
            double offsetAngle;
            int i;
			int j = Main.rand.Next(100);
			
			if(j < 25)
			{
				for (i = 0; i < 1; i++ )
				{
					offsetAngle = (startAngle + deltaAngle * (i + i*i) / 2f) + 32f * i;
					Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ProjectileID.Bomb, damage, knockBack, player.whoAmI, 0f, 0f);
				}
			}
			else if(j < 40)
			{
				for (i = 0; i < 1; i++ )
				{
					offsetAngle = (startAngle + deltaAngle * (i + i*i) / 2f) + 32f * i;
					Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ProjectileID.BouncyBomb, damage, knockBack, player.whoAmI, 0f, 0f);
				}
			}
			else if(j < 55)
			{
				for (i = 0; i < 1; i++ )
				{
					offsetAngle = (startAngle + deltaAngle * (i + i*i) / 2f) + 32f * i;
					Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ProjectileID.StickyBomb, damage, knockBack, player.whoAmI, 0f, 0f);
				}
			}
			else if(j < 60)
			{
				for (i = 0; i < 1; i++ )
				{
					offsetAngle = (startAngle + deltaAngle * (i + i*i) / 2f) + 32f * i;
					Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ProjectileID.SmokeBomb, damage, knockBack, player.whoAmI, 0f, 0f);
				}
			}
			else if(j < 75)
			{
				for (i = 0; i < 1; i++ )
				{
					offsetAngle = (startAngle + deltaAngle * (i + i*i) / 2f) + 32f * i;
					Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ProjectileID.Dynamite, damage, knockBack, player.whoAmI, 0f, 0f);
				}
			}
			else if(j < 90)
			{
				for (i = 0; i < 1; i++ )
				{
					offsetAngle = (startAngle + deltaAngle * (i + i*i) / 2f) + 32f * i;
					Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ProjectileID.Grenade, damage, knockBack, player.whoAmI, 0f, 0f);
				}
			}
			else if(j < 98)
			{
				for (i = 0; i < 1; i++ )
				{
					offsetAngle = (startAngle + deltaAngle * (i + i*i) / 2f) + 32f * i;
					Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ProjectileID.BouncyDynamite, damage, knockBack, player.whoAmI, 0f, 0f);
				}
			}
			else
			{
				for (i = 0; i < 1; i++ )
				{
					offsetAngle = (startAngle + deltaAngle * (i + i*i) / 2f) + 32f * i;
					Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("TrollbombProj"), damage, knockBack, player.whoAmI, 0f, 0f);
				}
			}
            return false;
        }
		
		
        public override void AddRecipes()  
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Bomb, 10);    
			recipe.AddIngredient(ItemID.StickyBomb, 10);   
			recipe.AddIngredient(ItemID.BouncyBomb, 10);
			recipe.AddIngredient(ItemID.Dynamite, 10);
			recipe.AddIngredient(ItemID.ManaCrystal);
			
            recipe.AddTile(TileID.Anvils);  
            recipe.SetResult(this);  
            recipe.AddRecipe();
        }
    }
}