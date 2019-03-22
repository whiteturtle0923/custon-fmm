using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.NewSummons
{
    public class DeathBringerFairy : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Death Bringer Fairy");
            Tooltip.SetDefault("Summons all pre-hardmode bosses \nCertain bosses will only spawn if you're in their specific biome");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 20;
            item.value = 1000;
            item.rare = 2;
            item.useAnimation = 30;
            item.useTime = 30;
            item.useStyle = 4;
            item.consumable = true;
        }

        public override bool CanUseItem(Player player)
        {
            return !Main.dayTime;
        }

        public override bool UseItem(Player player)
        {
            mod.GetItem("SuspiciousEye").UseItem(player);
            mod.GetItem("SlimyCrown").UseItem(player);
            NPC.SpawnOnPlayer(player.whoAmI, NPCID.EaterofWorldsHead);
            mod.GetItem("GoreySpine").UseItem(player);
            mod.GetItem("SuspiciousSkull").UseItem(player);
            mod.GetItem("SuspiciousEye").UseItem(player);
            mod.GetItem("Abeemination2").UseItem(player);
            NPC.SpawnWOF(player.Center);
            Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
            return true;
        }
    }
}