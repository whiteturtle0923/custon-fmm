using Fargowiltas.NPCs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.SwarmSummons
{
    public class OverloadFish : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Truffle Worm Clump");
            Tooltip.SetDefault("Summons several Duke Fishrons");
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
            return !Fargowiltas.swarmActive;
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
                Fargowiltas.swarmSpawned = 50;
            }
            else
            {
                Fargowiltas.swarmSpawned = 100;
            }

            for (int i = 0; i < Fargowiltas.swarmSpawned; i++)
            {
                int fish = NPC.NewNPC((int)player.position.X + Main.rand.Next(-1000, 1000), (int)player.position.Y + Main.rand.Next(-1000, -400), NPCID.DukeFishron);
                Main.npc[fish].GetGlobalNPC<FargoGlobalNPC>().swarmActive = true;
            }

            Main.NewText("The ocean swells with ferocious pigs!", 175, 75, 255);
            Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "TruffleWorm2");
            recipe.AddIngredient(null, "Overloader");
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}