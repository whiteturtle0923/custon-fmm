using Fargowiltas.NPCs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.SwarmSummons
{
	public class OverloadPrime : ModItem
	{		
	    public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Primal Control Chip");
			Tooltip.SetDefault("Summons several Skeletron Primes");
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.maxStack = 100;
			item.value = 1000;
			item.rare = 4;
			item.useAnimation = 30;
			item.useTime = 30;
			item.useStyle = 4;
			item.consumable = true;
		}

        public override bool CanUseItem(Player player)
        {
            return !Fargowiltas.swarmActive && !Main.dayTime;
        }

        public override bool UseItem(Player player)
        {
            Fargowiltas.swarmActive = true;
            Fargowiltas.swarmTotal = 10 * player.inventory[player.selectedItem].stack;
            Fargowiltas.swarmKills = 0;

            //kill whole stack
            player.inventory[player.selectedItem].stack = 0;

            if (Fargowiltas.swarmTotal <= 20)
            {
                Fargowiltas.swarmSpawned = Fargowiltas.swarmTotal;
            }
            else if (Fargowiltas.swarmTotal <= 100)
            {
                Fargowiltas.swarmSpawned = 20;
            }
            else if (Fargowiltas.swarmTotal != 1000)
            {
                Fargowiltas.swarmSpawned = 30;
            }
            else
            {
                Fargowiltas.swarmSpawned = 40;
            }

            for (int i = 0; i < Fargowiltas.swarmSpawned; i++)
            {
                int prime = NPC.NewNPC((int)player.position.X + Main.rand.Next(-1000, 1000), (int)player.position.Y + Main.rand.Next(-1000, -400), NPCID.SkeletronPrime);
                Main.npc[prime].GetGlobalNPC<FargoGlobalNPC>().swarmActive = true;
            }

            Main.NewText("A sickly chill envelops the world!", 175, 75, 255);
			Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
			return true;
		}
		
		public override void AddRecipes()
		{	
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "MechSkull");
			recipe.AddIngredient(null, "Overloader");
			recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
		}
	}
}