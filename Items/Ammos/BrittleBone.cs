using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Ammos
{
    public class BrittleBone : ModItem
    {
        public override string Texture => "Terraria/Images/Item_154";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Brittle Bone");
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.Bone);
            Item.shoot = 0;
            Item.useAnimation = 0;
            Item.useTime = 0;
            Item.useStyle = 0;
        }
    }
}
