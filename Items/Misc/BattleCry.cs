using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.Chat;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Misc
{
    public class BattleCry : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Battle Cry");
            Tooltip.SetDefault("Increase spawn rates by 10x on use" +
                               "\nUse it again to decrease them");
            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 38;
            Item.value = Item.sellPrice(0, 0, 2);
            Item.rare = ItemRarityID.Pink;
            Item.useAnimation = 30;
            Item.useTime = 30;
            Item.useStyle = ItemUseStyleID.Shoot;
        }

        public override bool? UseItem(Player player)
        {
            FargoPlayer modPlayer = player.GetFargoPlayer();
            modPlayer.BattleCry = !modPlayer.BattleCry;

            string text = "Spawn rates " + (modPlayer.BattleCry ? "increased!" : "decreased!");
            if (Main.netMode == NetmodeID.SinglePlayer)
            {
                Main.NewText(text, new Color(175, 75, 255));
            }
            else if (Main.netMode == NetmodeID.Server)
            {
                ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral(text), new Color(175, 75, 255));
            }

            if (!Main.dedServ)
            {
                SoundEngine.PlaySound(SoundLoader.GetLegacySoundSlot(Mod, "Sounds/Horn").WithVolume(1f), player.Center);
            }

            return true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.BattlePotion, 15)
                .AddIngredient(ItemID.WaterCandle, 10)
                .AddTile(TileID.DemonAltar)
                .Register();
        }
    }
}