using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Misc
{
	public class DeathFruit : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Death Fruit");
			// Tooltip.SetDefault("Permanently decreases maximum life by 20\nEffects may not be reversible for characters that have used modded life-increasing items");
		}

		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.maxStack = 99;
			Item.rare = 1;
			Item.useStyle = 4;
			Item.useAnimation = 30;
			Item.useTime = 30;
			Item.consumable = true;

			Item.UseSound = SoundID.Item27;
		}
		public override bool ConsumeItem (Player player)
		{
			if (!CanUse(player) && player.altFunctionUse != 2)
			{
				return false;
			}
			if (!CanUse(player) && player.altFunctionUse == 2)
			{
				return false;
			}

			return true;
		}
		public override bool AltFunctionUse(Player player) => true;
		public override bool? UseItem(Player player)
		{
			int effectSign;
			if (player.altFunctionUse == 2)
            {
				if (CanUse(player, true))
				{
					effectSign = 1;
				}
				else
				{
					return false;
				}
            }
            else
            {
				if (CanUse(player))
				{
					effectSign = -1;
				}
				else
				{
					return false;
				}
            }
            if (effectSign != 0)
            {
                player.GetModPlayer<FargoPlayer>().DeathFruits -= effectSign;
                player.statLife += 20 * effectSign;
                if (Main.myPlayer == player.whoAmI)
                {
                    player.HealEffect(20 * effectSign, true);
                }
            }
			
			return true;
		}

        public bool CanUse(Player player, bool rightClick = false)
        {
            if (!rightClick && player.statLifeMax - (player.ConsumedLifeFruit * 5) > 20)
            {
                return true;
            }
            if (rightClick && player.GetModPlayer<FargoPlayer>().DeathFruits > 0)
            {
                return true;
            }
            return false;
        }
    }
}
