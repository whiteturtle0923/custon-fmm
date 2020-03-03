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
            Description.SetDefault("Effects of all vanilla stations");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.buffImmune[BuffID.Sunflower] = true;
            player.buffImmune[BuffID.Campfire] = true;
            player.buffImmune[BuffID.HeartLamp] = true;
            player.buffImmune[BuffID.StarInBottle] = true;
            player.buffImmune[BuffID.DryadsWard] = true;

            if (player.whoAmI == Main.myPlayer)
            {
                Main.sunflower = true;
                Main.campfire = true;
                Main.heartLantern = true;
                Main.starInBottle = true;

                //dryad's blessing
                player.lifeRegen += 6;
                player.statDefense += 8;
                if (player.thorns < 1f)
                {
                    player.thorns += 0.2f;
                }
            }

            int type = Framing.GetTileSafely(player.Center).type;
            if (type == ModContent.TileType<OmnistationSheet>() || type == ModContent.TileType<OmnistationSheet2>())
            {
                player.AddBuff(BuffID.Honey, 30 * 60 + 1);
            }
        }
    }
}