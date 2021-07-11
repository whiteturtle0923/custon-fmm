using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Fargowiltas.NPCs;
using System;
using System.Linq;
using Terraria.ModLoader.IO;

//using Fargowiltas.Toggler;

namespace Fargowiltas
{
    public class FargoPlayer : ModPlayer
    {
        //public ToggleBackend Toggler = new ToggleBackend();
        public Dictionary<string, bool> TogglesToSync = new Dictionary<string, bool>();



        public bool extractSpeed;
        internal bool BattleCry;

        internal int originalSelectedItem;
        internal bool autoRevertSelectedItem = false;


        internal Dictionary<string, bool> FirstDyeIngredients = new Dictionary<string, bool>();
            
        private readonly string[] tags = new string[]
       {
            "RedHusk",
            "OrangeBloodroot",
            "YellowMarigold",
            "LimeKelp",
            "GreenMushroom",
            "TealMushroom",
            "CyanHusk",
            "SkyBlueFlower",
            "BlueBerries",
            "PurpleMucos",
            "VioletHusk",
            "PinkPricklyPear",
            "BlackInk"
       };

        public override TagCompound Save()
        {
            string name = "FargoDyes" + player.name;
            List<string> dyes = new List<string>();
            foreach (string tag in tags)
            {
                bool value;

                if (FirstDyeIngredients.TryGetValue(tag, out value))
                {
                    dyes.AddWithCondition(tag, FirstDyeIngredients[tag]);
                }
                else
                {
                    dyes.AddWithCondition(tag, false);
                }
            }

            //Toggler.Save();

            return new TagCompound
            {
                { name, dyes },
            };
        }

        public override void Initialize()
        {
            //Toggler.Load(this);
        }

        public override void Load(TagCompound tag)
        {
            string name = "FargoDyes" + player.name;

            IList<string> dyes = tag.GetList<string>(name);
            foreach (string downedTag in tags)
            {
                FirstDyeIngredients[downedTag] = dyes.Contains(downedTag);
            }
        }

        public override void SetupStartInventory(IList<Item> items, bool mediumCoreDeath)
        {
            foreach (string tag in tags)
            {
                FirstDyeIngredients[tag] = false;
            }
        }

        public override void ResetEffects()
        {
            extractSpeed = false;
        }

        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            if (Fargowiltas.CustomKey.JustPressed)
            {
                QuickUseItemAt(40);
            }

            if (Fargowiltas.RodKey.JustPressed)
            {
                AutoUseRod();
            }

            if (Fargowiltas.HomeKey.JustPressed)
            {
                AutoUseMirror();
            }

            if (Fargowiltas.StatKey.JustPressed)
            {
                Fargowiltas.UserInterfaceManager.ToggleStatSheet();
            }
        }

        /*private void Fargos()
        {
            if (player.GetModPlayer<FargowiltasSouls.FargoPlayer>().NinjaEnchant)
            {
                player.AddBuff(ModLoader.GetMod("FargowiltasSouls").BuffType("FirstStrike"), 60);
            }
        }*/

        public override void PostUpdate()
        {
            if (autoRevertSelectedItem)
            {
                if (player.itemTime == 0 && player.itemAnimation == 0)
                {
                    player.selectedItem = originalSelectedItem;
                    autoRevertSelectedItem = false;
                }
            }

            if (FargoWorld.OverloadedSlimeRain && Main.rand.Next(20) == 0)
            {
                SlimeRainSpawns();
            }
        }

        public void SlimeRainSpawns()
        {
            int type = NPCID.GreenSlime;

            int[] slimes = { NPCID.SlimeSpiked, NPCID.SandSlime, NPCID.IceSlime, NPCID.SpikedIceSlime, NPCID.MotherSlime, NPCID.SpikedJungleSlime, NPCID.DungeonSlime, NPCID.UmbrellaSlime, NPCID.ToxicSludge, NPCID.CorruptSlime, NPCID.Crimslime, NPCID.IlluminantSlime };

            int rand = Main.rand.Next(50);

            if (rand == 0)
            {
                type = NPCID.Pinky;
            }
            else  if(rand < 20)
            {
                type = slimes[Main.rand.Next(slimes.Length)];
            }

            Vector2 pos = new Vector2((int)player.position.X + Main.rand.Next(-800, 800), (int)player.position.Y + Main.rand.Next(-800, -250));

            Projectile.NewProjectile(pos, Vector2.Zero, mod.ProjectileType("SpawnProj"), 0, 0, Main.myPlayer, type);
        }

        public override void PostUpdateEquips()
        {
            if (Fargowiltas.SwarmActive)
            {
                player.buffImmune[BuffID.Horrified] = true;
            }

            if (GetInstance<FargoConfig>().PiggyBankAcc)
            {
                for (int i = 0; i < player.bank.item.Length; i++)
                {
                    Item item = player.bank.item[i];

                    if (item.active && Array.IndexOf(Informational, item.type) > -1)
                    {
                        Item item2 = new Item();
                        item2.SetDefaults(item.type);

                        player.VanillaUpdateEquip(item2);
                    }
                    else
                    {
                        switch (item.type)
                        {
                            case ItemID.Toolbelt:
                                player.blockRange = 1;
                                break;
                            case ItemID.Toolbox:
                                if (player.whoAmI == Main.myPlayer)
                                {
                                    Player.tileRangeX++;
                                    Player.tileRangeY++;
                                }
                                break;
                            case ItemID.ExtendoGrip:
                                if (player.whoAmI == Main.myPlayer)
                                {
                                    Player.tileRangeX += 3;
                                    Player.tileRangeY += 2;
                                }
                                break;
                            case ItemID.PaintSprayer:
                                player.autoPaint = true;
                                break;
                            case ItemID.BrickLayer:
                                player.tileSpeed += 0.5f;
                                break;
                            case ItemID.PortableCementMixer:
                                player.wallSpeed += 0.5f;
                                break;
                            case ItemID.ActuationAccessory:
                                player.autoActuator = true;
                                break;
                            case ItemID.ArchitectGizmoPack:
                                player.autoPaint = true;
                                player.tileSpeed += 0.5f;
                                player.wallSpeed += 0.5f;

                                if (player.whoAmI == Main.myPlayer)
                                {
                                    Player.tileRangeX += 3;
                                    Player.tileRangeY += 2;
                                }
                                break;

                            default:
                                break;
                        }
                    }
                }
            }
        }

        int[] Informational = { ItemID.CopperWatch, ItemID.TinWatch, ItemID.TungstenWatch, ItemID.SilverWatch, ItemID.GoldWatch, ItemID.PlatinumWatch, ItemID.DepthMeter, ItemID.Compass, ItemID.Radar, ItemID.LifeformAnalyzer, ItemID.TallyCounter, ItemID.MetalDetector, ItemID.Stopwatch, ItemID.Ruler, ItemID.FishermansGuide, ItemID.Sextant, ItemID.WeatherRadio, ItemID.GPS, ItemID.REK, ItemID.GoblinTech, ItemID.FishFinder, ItemID.PDA, ItemID.CellPhone }; 

        public override void UpdateBiomes()
        {
            if (FargoGlobalNPC.SpecificBossIsAlive(ref FargoGlobalNPC.eaterBoss, NPCID.EaterofWorldsHead))
            {
                player.ZoneCorrupt = true;
            }

            if (FargoGlobalNPC.SpecificBossIsAlive(ref FargoGlobalNPC.brainBoss, NPCID.BrainofCthulhu))
            {
                player.ZoneCrimson = true;
            }

            if (FargoGlobalNPC.SpecificBossIsAlive(ref FargoGlobalNPC.plantBoss, NPCID.Plantera))
            {
                player.ZoneJungle = true;
            }

            if (GetInstance<FargoConfig>().Fountains)
            {
                switch (Main.fountainColor)
                {
                    case 0:
                        player.ZoneBeach = true;
                        break;
                    case 6:
                        player.ZoneDesert = true;
                        if (player.Center.Y > 3200f)
                            player.ZoneUndergroundDesert = true;
                        break;
                    case 3:
                        player.ZoneJungle = true;
                        break;
                    case 5:
                        player.ZoneSnow = true;
                        break;
                    case 2:
                        player.ZoneCorrupt = true;
                        break;
                    case 10:
                        player.ZoneCrimson = true;
                        break;
                    case 4:
                        if (Main.hardMode)
                        {
                            player.ZoneHoly = true;
                        }
                        break;

                        //oasis and cavern fountains
                }
            }
            

        }

        public void AutoUseMirror()
        {
            for (int i = 0; i < player.inventory.Length; i++)
            {
                switch (player.inventory[i].type)
                {
                    case ItemID.RecallPotion:
                    case ItemID.MagicMirror:
                    case ItemID.IceMirror:
                    case ItemID.CellPhone:
                        QuickUseItemAt(i);
                        break;
                }
            }
        }

        public void AutoUseRod()
        {
            for (int i = 0; i < player.inventory.Length; i++)
            {
                if (player.inventory[i].type == ItemID.RodofDiscord)
                {
                    QuickUseItemAt(i);
                    break;
                }
            }
        }

        public void QuickUseItemAt(int index, bool use = true)
        {
            if (!autoRevertSelectedItem && player.selectedItem != index && player.inventory[index].type != 0)
            {
                originalSelectedItem = player.selectedItem;
                autoRevertSelectedItem = true;
                player.selectedItem = index;
                player.controlUseItem = true;
                if (use)
                {
                    player.ItemCheck(Main.myPlayer);
                }
            }
        }

        public override void CatchFish(Item fishingRod, Item bait, int power, int liquidType, int poolSize, int worldLayer, int questFish, ref int caughtType, ref bool junk)
        {
            int num15 = 150;
            int num18 = num15 * 7 / power;
            if (num18 < 4)
            {
                num18 = 4;
            }
            bool flag5 = false;
            if (Main.rand.Next(num18) == 0)
            {
                flag5 = true;
            }
            int num21 = 10;
            if (player.cratePotion)
            {
                num21 += 10;
            }
            if (Main.rand.Next(100) < num21)
            {
                if (flag5 && liquidType == 0 && player.ZoneSnow)
                {
                    caughtType = mod.ItemType("IceCrate");
                }
                else if (flag5 && liquidType == 1 && ItemID.Sets.CanFishInLava[fishingRod.type] && player.ZoneUnderworldHeight)
                {
                    caughtType = mod.ItemType("ShadowCrate");
                }
            }
        }

        public static readonly PlayerLayer DebuffsLayer = new PlayerLayer("FargowiltasSouls", "MiscEffects", PlayerLayer.MiscEffectsFront, delegate (PlayerDrawInfo drawInfo)
        {
            Player drawPlayer = drawInfo.drawPlayer;
            if (drawPlayer.whoAmI != Main.myPlayer)
                return;
            int[] debuffsToIgnore = { BuffID.Campfire, BuffID.HeartLamp, BuffID.Sunflower, BuffID.PeaceCandle, BuffID.StarInBottle, BuffID.Tipsy, BuffID.MonsterBanner };
            List<int> debuffs = drawPlayer.buffType.Where(d => Main.debuff[d] && !debuffsToIgnore.Contains(d)).ToList();
            if (debuffs.Count == 0)
                return;
            const int maxPerLine = 10;
            int yOffset = 0;
            for (int j = 0; j < debuffs.Count; j += maxPerLine)
            {
                int maxForThisLine = Math.Min(maxPerLine, debuffs.Count - j);
                float midpoint = maxForThisLine / 2f - 0.5f;
                for (int i = 0; i < maxForThisLine; i++)
                {
                    Texture2D buffIcon = Main.buffTexture[debuffs[j + i]];
                    Color buffColor = Color.White * GetInstance<FargoConfig>().DebuffOpacity;
                    Vector2 drawPos = drawPlayer.Top - Main.screenPosition;
                    drawPos.Y -= 32f + yOffset;
                    drawPos.X += 32f * (i - midpoint);
                    DrawData data = new DrawData(buffIcon, drawPos, buffIcon.Bounds, buffColor, 0f, buffIcon.Bounds.Size() / 2, 1f, SpriteEffects.None, 0);
                    Main.playerDrawData.Add(data);
                }
                yOffset += 32;
            }
        });

        public override void ModifyDrawLayers(List<PlayerLayer> layers)
        {
            if (player.whoAmI == Main.myPlayer && GetInstance<FargoConfig>().DebuffDisplay)
            {
                DebuffsLayer.visible = true;
                layers.Add(DebuffsLayer);
            }
        }

        /*public override void clientClone(ModPlayer clientClone)
        {
            FargoPlayer modPlayer = clientClone as FargoPlayer;
            modPlayer.Toggler = Toggler;
        }*/

        /*public void SyncToggle(string key)
        {
            if (!TogglesToSync.ContainsKey(key))
                TogglesToSync.Add(key, player.GetToggle(key).ToggleBool);
        }*/

        public override void SyncPlayer(int toWho, int fromWho, bool newPlayer)
        {
            foreach (KeyValuePair<string, bool> toggle in TogglesToSync)
            {
                ModPacket packet = mod.GetPacket();

                packet.Write((byte)80);
                packet.Write((byte)player.whoAmI);
                packet.Write(toggle.Key);
                packet.Write(toggle.Value);

                packet.Send(toWho, fromWho);
            }

            TogglesToSync.Clear();
        }

        /*public override void SendClientChanges(ModPlayer clientPlayer)
        {
            FargoPlayer modPlayer = clientPlayer as FargoPlayer;
            if (modPlayer.Toggler.Toggles != Toggler.Toggles)
            {
                ModPacket packet = mod.GetPacket();
                packet.Write((byte)79);
                packet.Write((byte)player.whoAmI);
                packet.Write((byte)Toggler.Toggles.Count);

                for (int i = 0; i < Toggler.Toggles.Count; i++)
                {
                    packet.Write(Toggler.Toggles.Values.ElementAt(i).ToggleBool);
                }

                packet.Send();
            }
        }*/
    }
}
