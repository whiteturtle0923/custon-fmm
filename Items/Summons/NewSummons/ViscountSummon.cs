using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.NewSummons
{
    public class ViscountSummon : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Activated Blood Altar");
            Tooltip.SetDefault("Summons Viscount" +
                               "\nCan only be used underground");
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
            item.value = Item.sellPrice(0, 0, 2);
            item.rare = ItemRarityID.Orange;
            item.useAnimation = 30;
            item.useTime = 30;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.consumable = true;
        }

        public override bool CanUseItem(Player player)
        {
            return player.ZoneDirtLayerHeight || player.ZoneRockLayerHeight;
        }

        public override bool UseItem(Player player)
        {
            if (Fargowiltas.ModLoaded["ThoriumMod"])
            {
                NPC.SpawnOnPlayer(player.whoAmI, ModLoader.GetMod("ThoriumMod").NPCType("Viscount"));
            }

            Main.PlaySound(SoundID.Roar, player.position, 0);

            return true;
        }
    }
}
