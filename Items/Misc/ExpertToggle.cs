//using Microsoft.Xna.Framework;
//using Terraria;
//using Terraria.Audio;
//using Terraria.Chat;
//using Terraria.ID;
//using Terraria.Localization;
//using Terraria.ModLoader;

//namespace Fargowiltas.Items.Misc
//{
//    public class ExpertToggle : ModItem
//    {
//        public override void SetStaticDefaults()
//        {
//            DisplayName.SetDefault("Expert's Token");
//            Tooltip.SetDefault(@"Toggles Expert mode");
//        }

//        public override void SetDefaults()
//        {
//            Item.width = 20;
//            Item.height = 20;
//            Item.value = Item.buyPrice(1);
//            Item.rare = ItemRarityID.Blue;
//            Item.useAnimation = 45;
//            Item.useTime = 45;
//            Item.useStyle = ItemUseStyleID.Shoot;
//            Item.consumable = false;
//        }

//        public override bool CanUseItem(Player player)
//        {
//            for (int i = 0; i < Main.maxNPCs; i++) //cant use while boss alive
//            {
//                if (Main.npc[i].active && Main.npc[i].boss)
//                {
//                    return false;
//                }
//            }
//            return true;
//        }

//        public override bool? UseItem(Player player)
//        {
//            Main.expertMode = !Main.expertMode; 

//            string text = Main.expertMode ? "Expert mode is now enabled!" : "Expert mode is now disabled!";
//            if (Main.netMode == NetmodeID.SinglePlayer)
//            {
//                Main.NewText(text, new Color(175, 75, 255));
//            }
//            else if (Main.netMode == NetmodeID.Server)
//            {
//                ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral(text), new Color(175, 75, 255));
//                NetMessage.SendData(7); //sync world
//            }

//            SoundEngine.PlaySound(15, player.Center, 0);

//            return true;
//        }
//    }
//}