using Fargowiltas.Items.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Buffs
{
    public class Omnistation : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Omnistation");
            Description.SetDefault("Effects of all stations");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.buffImmune[BuffID.Sunflower] = true;
            player.buffImmune[BuffID.Campfire] = true;
            player.buffImmune[BuffID.HeartLamp] = true;
            player.buffImmune[BuffID.StarInBottle] = true;

            Main.sunflower = true;
            Main.campfire = true;
            Main.heartLantern = true;
            Main.starInBottle = true;

            if (Framing.GetTileSafely(player.Center).type == ModContent.TileType<OmnistationSheet>())
            {
                player.AddBuff(BuffID.Honey, 30 * 60 + 1);
            }
        }
    }
}