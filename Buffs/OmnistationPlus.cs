//using CalamityMod.CalPlayer;
//using Fargowiltas.Items.Tiles;
//using Terraria;
//using Terraria.ID;
//using Terraria.ModLoader;
//using ThoriumMod;
//using static Terraria.ModLoader.ModContent;

//namespace Fargowiltas.Buffs
//{
//    public class OmnistationPlus : ModBuff
//    {
//        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");

//        private readonly Mod calamity = ModLoader.GetMod("CalamityMod");

//        public override void SetDefaults()
//        {
//            DisplayName.SetDefault("Omnistation+");
//            Description.SetDefault("Effects of all stations, vanilla and modded");
//            Main.buffNoSave[Type] = true;
//            Main.buffNoTimeDisplay[Type] = true;
//        }

//        public override bool Autoload(ref string name, ref string texture)
//        {
//            texture = "Fargowiltas/Buffs/Omnistation";
//            return true;
//        }

//        public override void Update(Player player, ref int buffIndex)
//        {
//            player.buffImmune[BuffType<Buffs.Omnistation>()] = true;
//            player.buffImmune[BuffID.Sunflower] = true;
//            player.buffImmune[BuffID.Campfire] = true;
//            player.buffImmune[BuffID.HeartLamp] = true;
//            player.buffImmune[BuffID.StarInBottle] = true;
//            player.buffImmune[BuffID.DryadsWard] = true;

//            if (player.whoAmI == Main.myPlayer)
//            {
//                Main.sunflower = true;
//                Main.campfire = true;
//                Main.heartLantern = true;
//                Main.starInBottle = true;

//                //dryad's blessing
//                player.lifeRegen += 6;
//                player.statDefense += 8;
//                if (player.thorns < 1f)
//                {
//                    player.thorns += 0.2f;
//                }

//                if (Fargowiltas.ModLoaded["ThoriumMod"]) Thorium(player);

//                if (Fargowiltas.ModLoaded["CalamityMod"]) Calamity(player);
//            }

//            int type = Framing.GetTileSafely(player.Center).type;
//            if (type == ModContent.TileType<OmnistationPlusSheet>())
//            {
//                player.AddBuff(BuffID.Honey, 30 * 60 + 1);
//            }
//        }

//        private void Thorium(Player player)
//        {
//            player.buffImmune[thorium.BuffType("SeasonsGreeting")] = true;

//            //mistletoe effect
//            player.lifeRegenTime++;
//            player.lifeRegen++;
//            player.manaRegenBonus++;
//            player.manaRegenDelayBonus++;
//            player.GetModPlayer<ThoriumPlayer>().inspirationRegenBonus += 0.02f;
//        }

//        private void Calamity(Player player)
//        {
//            player.buffImmune[calamity.BuffType("PurpleDefenseCandle")] = true;
//            player.buffImmune[calamity.BuffType("YellowDamageCandle")] = true;
//            player.buffImmune[calamity.BuffType("PinkHealthCandle")] = true;
//            player.buffImmune[calamity.BuffType("BlueSpeedCandle")] = true;

//            player.GetModPlayer<CalamityPlayer>().purpleCandle = true;
//            player.GetModPlayer<CalamityPlayer>().yellowCandle = true;
//            player.GetModPlayer<CalamityPlayer>().pinkCandle = true;
//            player.GetModPlayer<CalamityPlayer>().blueCandle = true;

//        }
//    }
//}