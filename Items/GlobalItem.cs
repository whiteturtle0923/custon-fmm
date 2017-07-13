using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items
{
	public class VanillaItems : GlobalItem
	{
		
		public virtual void SetDefaults(Item item)
		{
			/*if ((item.type == ItemID.WoodenBoomerang)&& ( wboom/2 == 0))
            { 
			item.melee = false;
			item.thrown = true; 
			}
			
			else
			{
			item.thrown = false;
			item.melee = true; 
			}*/
		}
	}
}