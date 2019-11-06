using Fargowiltas.NPCs;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework;

namespace Fargowiltas.Items.Summons.SwarmSummons.Thorium
{
    public class OverloadRag : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Doom Sayer's Coin 2.0");
            Tooltip.SetDefault("Summons several Ragnaroks");
        }

        public override bool Autoload(ref string name)
        {
            return false;// return ModLoader.GetMod("ThoriumMod") != null;;
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 100;
            item.value = 1000;
            item.rare = 10;
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
            Fargowiltas.swarmTotal = 30 * player.inventory[player.selectedItem].stack;
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
                Fargowiltas.swarmSpawned = 40;
            }
            else
            {
                Fargowiltas.swarmSpawned = 50;
            }

            for (int i = 0; i < Fargowiltas.swarmSpawned; i++)
            {
                int boss = NPC.NewNPC((int)player.position.X + Main.rand.Next(-1000, 1000), (int)player.position.Y + Main.rand.Next(-1000, -400), thorium.NPCType("Aquaius"));
                Main.npc[boss].GetGlobalNPC<FargoGlobalNPC>().swarmActive = true;
                boss = NPC.NewNPC((int)player.position.X + Main.rand.Next(-1000, 1000), (int)player.position.Y + Main.rand.Next(-1000, -400), thorium.NPCType("Omnicide"));
                Main.npc[boss].GetGlobalNPC<FargoGlobalNPC>().swarmActive = true;
                boss = NPC.NewNPC((int)player.position.X + Main.rand.Next(-1000, 1000), (int)player.position.Y + Main.rand.Next(-1000, -400), thorium.NPCType("SlagFury"));
                Main.npc[boss].GetGlobalNPC<FargoGlobalNPC>().swarmActive = true;
            }

            NPC.NewNPC((int)player.Center.X, (int)player.Center.Y, thorium.NPCType("RagSkyChanger"), 0, player.whoAmI, 0f, 0f, 0f, 255);

            if (Main.netMode == 2)
            {
                NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("The Ultimate Doomsday!"), new Color(175, 75, 255));
            }
            else
            {
                Main.NewText("The Ultimate Doomsday!", 175, 75, 255);
            }

            Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(thorium, "LichCatalyst");
            recipe.AddIngredient(null, "Overloader");
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}