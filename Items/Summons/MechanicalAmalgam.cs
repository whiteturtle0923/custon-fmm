<<<<<<< HEAD
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons
{
	public class MechanicalAmalgam : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mechanical Amalgam");
			Tooltip.SetDefault("Summons all 3 mechanical bosses");
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

		public override bool CanUseItem(Player player)
		{
		return Main.dayTime != true;
		}

		public override bool UseItem(Player player)
		{
			NPC.SpawnOnPlayer(player.whoAmI, NPCID.TheDestroyer);
			NPC.SpawnOnPlayer(player.whoAmI, NPCID.SkeletronPrime);
			NPC.SpawnOnPlayer(player.whoAmI, NPCID.Retinazer);
			NPC.SpawnOnPlayer(player.whoAmI, NPCID.Spazmatism);
			Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
			return true;
		}

		
	}
=======
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons
{
	public class MechanicalAmalgam : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mechanical Amalgam");
			Tooltip.SetDefault("Summons all 3 mechanical bosses");
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

		public override bool CanUseItem(Player player)
		{
		return Main.dayTime != true;
		}

		public override bool UseItem(Player player)
		{
			NPC.SpawnOnPlayer(player.whoAmI, NPCID.TheDestroyer);
			NPC.SpawnOnPlayer(player.whoAmI, NPCID.SkeletronPrime);
			NPC.SpawnOnPlayer(player.whoAmI, NPCID.Retinazer);
			NPC.SpawnOnPlayer(player.whoAmI, NPCID.Spazmatism);
			Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
			return true;
		}

		
	}
>>>>>>> 66ed39caf4938fca8e7009752b635e42f8a8a58f
}