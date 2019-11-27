using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Fargowiltas.Items.Tiles
{
    public class OmnistationSheet : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
            TileObjectData.newTile.Height = 4;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16, 16 };
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Omnistation");
            AddMapEntry(new Color(100, 255, 100), name);
            disableSmartCursor = true;
        }

        public override void NearbyEffects(int i, int j, bool closer)
        {
            Main.player[Main.myPlayer].AddBuff(mod.BuffType("Omnistation"), 10);
        }

        public override void MouseOver(int i, int j)
        {
            Player player = Main.LocalPlayer;
            player.noThrow = 2;
            player.showItemIcon = true;
            player.showItemIcon2 = mod.ItemType("Omnistation");
        }

        public override bool NewRightClick(int i, int j)
        {
            Item item = Main.player[Main.myPlayer].HeldItem;
            if (item.melee)
                Main.player[Main.myPlayer].AddBuff(BuffID.Sharpened, 60 * 60 * 10);
            if (item.ranged)
                Main.player[Main.myPlayer].AddBuff(BuffID.AmmoBox, 60 * 60 * 10);
            if (item.magic)
                Main.player[Main.myPlayer].AddBuff(BuffID.Clairvoyance, 60 * 60 * 10);
            if (item.summon)
                Main.player[Main.myPlayer].AddBuff(BuffID.Bewitched, 60 * 60 * 10);
            if (item.melee || item.ranged || item.magic || item.summon)
                Main.PlaySound(SoundID.Item44, i * 16 + 8, j * 16 + 8);
            return true;
        }
    }
}