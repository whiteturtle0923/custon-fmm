using Fargowiltas.NPCs;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework;

namespace Fargowiltas.Items.Summons.SwarmSummons.Thorium
{
    public class OverloadThunderbird : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Grand Flare Gun 2.0");
            Tooltip.SetDefault("Summons several Grand Thunder Birds");
        }

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 100;
            item.value = 1000;
            item.rare = 1;
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
                Fargowiltas.swarmSpawned = 80;
            }

            for (int i = 0; i < Fargowiltas.swarmSpawned; i++)
            {
                int boss = NPC.NewNPC((int)player.position.X + Main.rand.Next(-1000, 1000), (int)player.position.Y + Main.rand.Next(-1000, -400), thorium.NPCType("TheGrandThunderBirdv2"));
                Main.npc[boss].GetGlobalNPC<FargoGlobalNPC>().swarmActive = true;
            }

            if (Main.netMode == 2)
            {
                NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("Electricity fills the air!"), new Color(175, 75, 255));
            }
            else
            {
                Main.NewText("Electricity fills the air!", 175, 75, 255);
            }

            Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(thorium, "StormFlare");
            recipe.AddIngredient(null, "Overloader");
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}