using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Misc
{
	public class SuperDummy : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Super Dummy");
			Tooltip.SetDefault(
@"Creates a super dummy
Regenerates 1 million life per second
Will not die when taking damage over time from debuffs
Right click to kill all super dummies");
		}
        
		public override void SetDefaults()
		{
			item.damage = 0;
			item.width = 20;
			item.height = 30;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 1;
			item.useTurn = true;
            item.value = 0;
			item.rare = 1;
			item.autoReuse = true;
		}

		public override bool AltFunctionUse (Player player)
		{
			return true;
		}

        public override bool UseItem(Player player)
		{
            if (player.altFunctionUse == 2)
			{
				for (int i = 0; i < 200; i++)
				{
					if (Main.npc[i].type == mod.NPCType("SuperDummy"))
					{
						Main.npc[i].life = 0;
						Main.npc[i].lifeRegen = 0;
						Main.npc[i].checkDead();
					}
				}
			}
			else if (player.whoAmI == Main.myPlayer)
			{
                Vector2 pos = new Vector2((int)Main.MouseWorld.X - 9, (int)Main.MouseWorld.Y - 20);

                Projectile.NewProjectile(pos, Vector2.Zero, mod.ProjectileType("SpawnProj"), 0, 0, Main.myPlayer, mod.NPCType("SuperDummy"));
            }

            return true;
		}

		public override void AddRecipes()
		{
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TargetDummy);
            recipe.AddIngredient(ItemID.FallenStar);
            recipe.AddTile(TileID.CookingPots);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}