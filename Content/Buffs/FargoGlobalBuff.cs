using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Buffs
{
    public class FargoGlobalBuff : GlobalBuff
    {
        public override void Update(int type, Player player, ref int buffIndex)
        {
            if (type == BuffID.Lucky && player.GetModPlayer<FargoPlayer>().luckPotionBoost > 0 && player.buffTime[buffIndex] > 2)
            {
                player.buffTime[buffIndex] = 2;
            }
        }
    }
}