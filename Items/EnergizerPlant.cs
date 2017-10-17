using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;

namespace Fargowiltas.Items
{
	public class EnergizerPlant : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Leaf Energizer");
			Tooltip.SetDefault("'Being a leaf sounds like a good time'");
		}
		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.maxStack = 999;
			item.rare = 1;
		}
		public override string Texture
		{
			get
			{
				return "Fargowiltas/Items/Placeholder";
			}
		}
	}
}