using System.Linq;
using Terraria;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.NewSummons
{
    public class ViscountSummon : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Activated Blood Altar");
            Tooltip.SetDefault("Summons Viscount\nCan only be used underground");
        }

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 20;
            item.value = 1000;
            item.rare = 3;
            item.useAnimation = 30;
            item.useTime = 30;
            item.useStyle = 4;
            item.consumable = true;
        }

        public override bool CanUseItem(Player player)
        {
            return player.ZoneDirtLayerHeight || player.ZoneRockLayerHeight;
        }

        public override bool UseItem(Player player)
        {
            if (Fargowiltas.instance.thoriumLoaded)
            {
                NPC.SpawnOnPlayer(player.whoAmI, ModLoader.GetMod("ThoriumMod").NPCType("Viscount"));
            }

            Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
            return true;
        }
    }
}
