using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Fargowiltas.NPCs;

namespace Fargowiltas.Items.Summons
{
	public class CultistSummon : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lunar Idol");
			Tooltip.SetDefault("Summons the Lunatic Cultist");
		}
		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.maxStack = 20;
			item.value = 1000;
			item.rare = 1;
			item.useAnimation = 30;
			item.useTime = 30;
			item.useStyle = 4;
			item.consumable = true;
		}
        public override string Texture
		{
			get
			{
				return "Fargowiltas/Items/Placeholder";
			}
		}

		public override bool UseItem(Player player)
		{
            int cultist = NPC.NewNPC((int)player.position.X, (int)player.position.Y - 400, NPCID.CultistBoss);

            //so pillars wont spawn when he dies
            Main.npc[cultist].GetGlobalNPC<FargoGlobalNPC>().pillarSpawn = false;

            //NPC.LunarShieldPowerNormal
            NPC.LunarApocalypseIsUp = false;

            Main.NewText("Lunatic Cultist has awoken!", 175, 75, 255);

			Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
			return true;

            
		}
	}
}