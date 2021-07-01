using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Fargowiltas.NPCs
{
	[AutoloadHead]
	public class Squirrel : ModNPC
	{
        private static int shopNum;
        private static bool showCycleShop;

        private enum ShopGroups
        {
            Enchant,
            Essence,
            Force,
            Soul,
            Potion,
            Other
        }

        public override bool Autoload(ref string name)
		{
			name = "Squirrel";
			return ModLoader.GetMod("FargowiltasSouls") != null;
		}

		private readonly Mod fargosouls = ModLoader.GetMod("FargowiltasSouls");

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Squirrel");
			Main.npcFrameCount[npc.type] = 6;
			NPCID.Sets.ExtraFramesCount[npc.type] = 9;
			NPCID.Sets.AttackFrameCount[npc.type] = 4;
			NPCID.Sets.DangerDetectRange[npc.type] = 700;
			NPCID.Sets.AttackType[npc.type] = 0;
			NPCID.Sets.AttackTime[npc.type] = 90;
			NPCID.Sets.AttackAverageChance[npc.type] = 30;
			NPCID.Sets.HatOffsetY[npc.type] = 4;
		}

		public override void SetDefaults()
		{
			npc.townNPC = true;
			npc.friendly = true;
			npc.width = 50;
			npc.height = 32;
			npc.damage = 0;
			npc.defense = 0;
			npc.lifeMax = 100;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.knockBackResist = .25f;

			animationType = NPCID.Squirrel;
			npc.aiStyle = 7;

            if (GetInstance<FargoConfig>().CatchNPCs)
            {
                Main.npcCatchable[npc.type] = true;
                npc.catchItem = (short)mod.ItemType("Squirrel");
            }
        }

        public override void AI()
        {
            npc.dontTakeDamage = Main.bloodMoon;
        }

        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
		{
            if (FargoWorld.DownedBools["squirrel"])
            {
                return true;
            }

			for (int k = 0; k < Main.maxPlayers; k++)
			{
				Player player = Main.player[k];
				if (!player.active)
				{
					continue;
				}

				foreach (Item item in player.inventory)
				{
					if (item.type == fargosouls.ItemType("TopHatSquirrelCaught"))
					{
						return true;
					}
				}
			}
			return false;
		}

        public override bool CanGoToStatue(bool toKingStatue) => toKingStatue;

        public override string TownNPCName()
		{
			switch (WorldGen.genRand.Next(7))
			{
				case 0:
					return "Rick";
				case 1:
					return "Acorn";
                case 2:
                    return "Puff";
                case 3:
                    return "Coco";
                case 4:
                    return "Truffle";
                case 5:
                    return "Furgo";
                default:
					return "Squeaks";
			}
		}

		public override string GetChat()
		{
            showCycleShop = GetSellableItems().Count / 40 > 0;

            if (Main.bloodMoon)
                return $"[c/ff0000:You will suffer.]";

            switch (Main.rand.Next(3))
			{
				case 0:
					return "*squeak*";
				case 1:
					return "*chitter*";
				default:
					return "*crunch crunch*";
			}
		}

		public override void SetChatButtons(ref string button, ref string button2)
		{
            button = Language.GetTextValue("LegacyInterface.28");
            if (showCycleShop)
            {
                button += $" {shopNum + 1}";
                button2 = "Cycle Shop";
            }
        }

		public override void OnChatButtonClicked(bool firstButton, ref bool shop)
		{
			if (firstButton)
			{
				shop = true;
			}
            else
            {
                /*if (Main.hardMode) //ask player why they don't have biocluster
                {
                    bool playerHasBiocluster = false;
                    int type = ModLoader.GetMod("FargowiltasSouls").ItemType("BionomicCluster");
                    foreach (Item item in Main.LocalPlayer.inventory)
                    {
                        if (item.type == type)
                        {
                            playerHasBiocluster = true;
                            break;
                        }
                    }
                    foreach (Item item in Main.LocalPlayer.armor)
                    {
                        if (item.type == type)
                        {
                            playerHasBiocluster = true;
                            break;
                        }
                    }
                    if (!playerHasBiocluster)
                    {
                        CombatText.NewText(npc.Hitbox, Color.White, $"[i:{type}]?", true);
                    }
                }*/

                shopNum++;
            }
            
            if (shopNum > GetSellableItems().Count / 40) //check this when just opening shop too in case shop shrinks
                shopNum = 0;
        }

        private void TryAddItem(Item item, List<int>[] itemCollections)
        {
            void AddToCollection(int type, ShopGroups group)
            {
                Main.NewText($"add {type} {group.ToString()}");
                int groupCast = (int)group;
                if (!itemCollections[groupCast].Contains(type))
                    itemCollections[groupCast].Add(type);
            };

            if (item.type == ItemID.CellPhone || item.type == ItemID.AnkhShield || item.type == ItemID.RodofDiscord)
            {
                AddToCollection(item.type, ShopGroups.Other);
            }
            else if (item.stack >= 30 && item.buffType != 0)
            {
                AddToCollection(item.type, ShopGroups.Potion);
            }

            if (item.modItem == null || (!item.modItem.mod.Name.Equals("FargowiltasSouls") && !item.modItem.mod.Name.Equals("FargowiltasSoulsDLC")))
                return;

            if (item.modItem.Name.EndsWith("Enchant"))
            {
                AddToCollection(item.type, ShopGroups.Enchant);
            }
            else if (item.modItem.Name.EndsWith("Essence"))
            {
                AddToCollection(item.type, ShopGroups.Essence);
            }
            else if (item.type == ModLoader.GetMod("FargowiltasSouls").ItemType("BionomicCluster")
                || item.type == ModLoader.GetMod("FargowiltasSouls").ItemType("HeartoftheMasochist"))
            {
                AddToCollection(item.type, ShopGroups.Other);
            }
            else if (item.modItem.Name.EndsWith("Force"))
            {
                RecipeFinder finder = new RecipeFinder();
                finder.SetResult(item.type);
                Recipe exactRecipe = finder.SearchRecipes()[0];
                foreach (Item material in exactRecipe.requiredItem)
                {
                    if (material.modItem.Name.EndsWith("Enchant"))
                        AddToCollection(material.type, ShopGroups.Enchant);
                }
            }
            else if (item.modItem.Name.EndsWith("Soul"))
            {
                RecipeFinder finder = new RecipeFinder();
                finder.SetResult(item.type);
                Recipe exactRecipe = finder.SearchRecipes()[0];
                foreach (Item material in exactRecipe.requiredItem)
                {
                    if (material.modItem.Name.EndsWith("Essence"))
                    {
                        AddToCollection(material.type, ShopGroups.Essence);
                    }
                    else if (material.modItem.Name.EndsWith("Force"))
                    {
                        AddToCollection(material.type, ShopGroups.Force);
                    }
                    else if (material.modItem.Name.EndsWith("Soul"))
                    {
                        AddToCollection(material.type, ShopGroups.Soul);
                    }
                    else if (item.type == ModLoader.GetMod("FargowiltasSouls").ItemType("MasochistSoul") && material.type != ItemID.None)
                    {
                        RecipeFinder ingredientFinder = new RecipeFinder();
                        finder.SetResult(material.type);
                        if (finder.SearchRecipes().Count > 0) //only put in materials that have recipes themselves
                        {
                            AddToCollection(material.type, ShopGroups.Other);
                        }
                    }
                }
            }
            else if (item.type == ModLoader.GetMod("FargowiltasSouls").ItemType("AeolusBoots"))
            {
                AddToCollection(ItemID.FrostsparkBoots, ShopGroups.Other);
                AddToCollection(ItemID.BalloonHorseshoeFart, ShopGroups.Other);
            }
        }
        
        private List<int> GetSellableItems()
        {
            List<int>[] itemCollections = new List<int>[6]; //so they can be grouped by category
            for (int i = 0; i < itemCollections.Length; i++)
                itemCollections[i] = new List<int>();

            for (int i = 0; i < Main.maxPlayers; i++)
            {
                Player player = Main.player[i];
                if (!player.active)
                    continue;

                foreach (Item item in player.inventory)
                    TryAddItem(item, itemCollections);

                foreach (Item item in player.armor)
                    TryAddItem(item, itemCollections);
            }

            List<int> sellableItems = new List<int>();
            for (int i = 0; i < itemCollections.Length; i++)
            {
                sellableItems.AddRange(itemCollections[i]);
            }
            return sellableItems;
        }

        public override void SetupShop(Chest shop, ref int nextSlot)
		{
            if (shopNum == 0 && Fargowiltas.ModLoaded["FargowiltasSouls"]) //only on page 1
            {
                shop.item[nextSlot].SetDefaults(ModLoader.GetMod("FargowiltasSouls").ItemType("TopHatSquirrelCaught"));
                shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 10);
                nextSlot++;
            }
            
            List<int> sellableItems = GetSellableItems();
            int i = 0;
            int startOffset = shopNum * 40;
            const int maxShop = 40;

            foreach (int type in sellableItems)
            {
                if (++i < startOffset) //skip up to the minimum
                    continue;

                if (nextSlot >= maxShop) //only fill shop up to capacity
                    break;

                shop.item[nextSlot].SetDefaults(type);
                if (type == ItemID.RodofDiscord)
                {
                    shop.item[nextSlot].shopCustomPrice = 250;
                    shop.item[nextSlot].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
                }
                else
                {
                    shop.item[nextSlot].shopCustomPrice = shop.item[nextSlot].value * 5;
                }
                nextSlot++;
            }
        }

        public override void NPCLoot()
        {
            if (!FargoWorld.DownedBools["squirrel"])
            {
                FargoWorld.DownedBools["squirrel"] = true;
                if (Main.netMode == NetmodeID.Server)
                    NetMessage.SendData(MessageID.WorldData); //sync world
            }
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D texture2D13 = Main.npcTexture[npc.type];
            //int num156 = Main.npcTexture[npc.type].Height / Main.npcFrameCount[npc.type]; //ypos of lower right corner of sprite to draw
            //int y3 = num156 * npc.frame.Y; //ypos of upper left corner of sprite to draw
            Rectangle rectangle = npc.frame;//new Rectangle(0, y3, texture2D13.Width, num156);
            Vector2 origin2 = rectangle.Size() / 2f;

            Color color26 = lightColor;
            color26 = npc.GetAlpha(color26);

            SpriteEffects effects = npc.spriteDirection < 0 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;

            if (Main.bloodMoon)
            {
                Texture2D texture2D14 = mod.GetTexture("NPCs/Squirrel_Glow");
                float scale = (Main.mouseTextColor / 200f - 0.35f) * 0.3f + 0.9f;
                Main.spriteBatch.Draw(texture2D14, npc.Center - Main.screenPosition + new Vector2(0f, npc.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(rectangle), Color.White * npc.Opacity, npc.rotation, origin2, scale, effects, 0f);
            }

            Main.spriteBatch.Draw(texture2D13, npc.Center - Main.screenPosition + new Vector2(0f, npc.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(rectangle), npc.GetAlpha(lightColor), npc.rotation, origin2, npc.scale, effects, 0f);

            if (Main.bloodMoon)
            {
                Texture2D texture2D14 = mod.GetTexture("NPCs/Squirrel_Eyes");
                Main.spriteBatch.Draw(texture2D14, npc.Center - Main.screenPosition + new Vector2(0f, npc.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(rectangle), Color.White * npc.Opacity, npc.rotation, origin2, npc.scale, effects, 0f);
            }
            return false;
        }
    }
}