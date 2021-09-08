using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Vanity
{
    [AutoloadEquip(EquipType.Head)]
    public class LumberHat : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("LumberJack Hat");
        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.rare = ItemRarityID.Blue;
            Item.vanity = true;
        }
    }
}