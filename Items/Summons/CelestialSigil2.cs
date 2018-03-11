<<<<<<< HEAD
using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;

namespace Fargowiltas.Items.Summons
{
	public class CelestialSigil2 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Celestially Sigil");
			Tooltip.SetDefault("Summons the Moon Lord instantly");
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

		public override bool UseItem(Player player)
        {
			NPC.NewNPC((int)player.position.X + Main.rand.Next(-800, 800), (int)player.position.Y + Main.rand.Next(-1000, -250), NPCID.MoonLordCore);
			Main.NewText("The Moon Lord has awoken!", 175, 75, 255);
            Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
            return true;
        }
		
		public override void AddRecipes()
		{
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CelestialSigil);
			recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
		}

	}
=======
using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;

namespace Fargowiltas.Items.Summons
{
	public class CelestialSigil2 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Celestially Sigil");
			Tooltip.SetDefault("Summons the Moon Lord instantly");
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

		public override bool UseItem(Player player)
        {
			NPC.NewNPC((int)player.position.X + Main.rand.Next(-800, 800), (int)player.position.Y + Main.rand.Next(-1000, -250), NPCID.MoonLordCore);
			Main.NewText("The Moon Lord has awoken!", 175, 75, 255);
            Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
            return true;
        }
		
		public override void AddRecipes()
		{
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CelestialSigil);
			recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
		}

	}
>>>>>>> 66ed39caf4938fca8e7009752b635e42f8a8a58f
}