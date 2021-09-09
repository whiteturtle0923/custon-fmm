using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.Abom
{
    public class PartyCone : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Party Cone");
            Tooltip.SetDefault("Starts a Party!");
            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 3;
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.maxStack = 20;
            Item.value = Item.sellPrice(0, 0, 2);
            Item.rare = ItemRarityID.Blue;
            Item.useAnimation = 30;
            Item.useTime = 30;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.consumable = true;
        }

        public override bool CanUseItem(Player player)
        {
            return Main.dayTime && !BirthdayParty.PartyIsUp;
        }

        public override bool? UseItem(Player player)
        {
            if (!BirthdayParty.PartyIsUp)
                BirthdayParty.ToggleManualParty();
            NPC.freeCake = true;

            NetMessage.SendData(MessageID.WorldData);

            if (!NPC.AnyNPCs(NPCID.PartyGirl))
                NPC.SpawnOnPlayer(player.whoAmI, NPCID.PartyGirl);

            Main.NewText("Looks like someone's throwing a Party!", new Color(255, 0, 160));
            //SoundEngine.PlaySound(28, player.position);

            return true;
        }
    }
}