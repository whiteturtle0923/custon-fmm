using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Vanity
{
    [AutoloadEquip(EquipType.Body)]
    public class LumberjackBody : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lumberjack Body");
        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.vanity = true;
            Item.rare = ItemRarityID.Blue;
        }
    }
}
