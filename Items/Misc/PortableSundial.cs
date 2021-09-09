using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Misc
{
    public class PortableSundial : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Portable Sundial");
            Tooltip.SetDefault("Left click to instantly switch from day to night" +
                               "\nRight click to activate the Enchanted Sundial effect" +
                               "\nThis will also reset travelling merchant's shops");
            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.value = Item.sellPrice(0, 5);
            Item.rare = ItemRarityID.LightRed;
            Item.useAnimation = 30;
            Item.useTime = 30;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.mana = 50;
            Item.UseSound = SoundID.Item4;
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            return !Main.fastForwardTime;
        }

        public override bool? UseItem(Player player)
        {
            if (player.altFunctionUse == ItemAlternativeFunctionID.ActivatedAndUsed)
            {
                Main.sundialCooldown = 0;
                if (Main.netMode == NetmodeID.MultiplayerClient)
                {
                    NetMessage.SendData( MessageID.WorldData, number: Main.myPlayer, number2: 3f);
                    return true;
                }

                Main.fastForwardTime = true;
                NetMessage.SendData(MessageID.WorldData);
                SoundEngine.PlaySound(SoundID.Item4, player.position);
            }
            else
            {
                Main.dayTime = !Main.dayTime;
                Main.time = 0;
                Chest.SetupTravelShop();

                //change moon phases when switching to night
                if (!Main.dayTime && ++Main.moonPhase > 7)
                {
                    Main.moonPhase = 0;
                }

                if (Main.dayTime)
                    BirthdayParty.CheckMorning();
                else
                    BirthdayParty.CheckNight();
            }

            return true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Sundial)
                .AddTile(TileID.SkyMill)
                .Register();
        }
    }
}