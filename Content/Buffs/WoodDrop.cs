using Terraria;
using Terraria.ModLoader;

namespace Fargowiltas.Buffs
{
    public class WoodDrop : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoSave[Type] = true;
        }
    }
}