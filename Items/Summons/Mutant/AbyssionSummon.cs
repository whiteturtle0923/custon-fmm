using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.Mutant
{
    public class AbyssionSummon : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Forgotten Claw");
            Tooltip.SetDefault("Summons Abyssion");
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
            item.rare = ItemRarityID.Blue;
            item.useAnimation = 30;
            item.useTime = 30;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.consumable = true;
        }

        public override bool UseItem(Player player)
        {
            if (Fargowiltas.ModLoaded["ThoriumMod"])
            {
                NPC.SpawnOnPlayer(player.whoAmI, ModLoader.GetMod("ThoriumMod").NPCType("Abyssion"));
            }

            Main.PlaySound(SoundID.Roar, player.position, 0);

            return true;
        }
    }
}
