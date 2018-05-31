using Terraria.ModLoader;

namespace Fargowiltas.Items.Vanity
{
    [AutoloadEquip(EquipType.Head)]
    public class AbominationMask : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Abominationn Mask");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.rare = 1;
            item.vanity = true;
        }
    }
}