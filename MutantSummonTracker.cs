using Fargowiltas.Items.Summons;
using Fargowiltas.Items.Summons.Mutant;
using Fargowiltas.Items.Summons.VanillaCopy;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace Fargowiltas
{
    internal class MutantSummonTracker
    {
        public const float KingSlime = 1f;
        public const float EyeOfCthulhu = 2f;
        public const float EaterOfWorlds = 3f;
        public const float QueenBee = 4f;
        public const float Skeletron = 5f;
        public const float WallOfFlesh = 6f;
        public const float TheTwins = 7f;
        public const float TheDestroyer = 8f;
        public const float SkeletronPrime = 9f;
        public const float Plantera = 10f;
        public const float Golem = 11f;
        public const float DukeFishron = 12f;
        public const float LunaticCultist = 13f;
        public const float Moonlord = 14f;

        internal List<MutantSummonInfo> SortedSummons;
        internal List<MutantSummonInfo> EventSummons;

        internal bool SummonsFinalized = false;

        public MutantSummonTracker()
        {
            Fargowiltas.summonTracker = this;
            InitializeVanillaSummons();
        }

        private void InitializeVanillaSummons()
        {
            SortedSummons = new List<MutantSummonInfo> {
                // Vanilla bosses
                new MutantSummonInfo(KingSlime, ModContent.ItemType<SlimyCrown>(), () => NPC.downedSlimeKing, 50000),
                new MutantSummonInfo(EyeOfCthulhu, ModContent.ItemType<SuspiciousEye>(), () => NPC.downedBoss1, 80000),
                new MutantSummonInfo(EaterOfWorlds, ModContent.ItemType<WormyFood>(), () => NPC.downedBoss2, 100000),
                new MutantSummonInfo(EaterOfWorlds, ModContent.ItemType<GoreySpine>(), () => NPC.downedBoss2, 100000),
                new MutantSummonInfo(QueenBee, ModContent.ItemType<Abeemination2>(), () => NPC.downedQueenBee, 150000),
                new MutantSummonInfo(Skeletron, ModContent.ItemType<SuspiciousSkull>(), () => NPC.downedBoss3, 150000),
                new MutantSummonInfo(WallOfFlesh, ModContent.ItemType<FleshyDoll>(), () => Main.hardMode  , 200000),
                new MutantSummonInfo(WallOfFlesh + 0.01f, ModContent.ItemType<DeathBringerFairy>(), () => Main.hardMode  , 500000),
                new MutantSummonInfo(TheTwins, ModContent.ItemType<MechEye>(), () => NPC.downedMechBoss2, 400000),
                new MutantSummonInfo(TheDestroyer, ModContent.ItemType<MechWorm>(), () => NPC.downedMechBoss1, 400000),
                new MutantSummonInfo(SkeletronPrime, ModContent.ItemType<MechSkull>(), () => NPC.downedMechBoss3, 400000),
                new MutantSummonInfo(SkeletronPrime + 0.01f, ModContent.ItemType<MechanicalAmalgam>(), () => (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3), 1000000),
                new MutantSummonInfo(Plantera, ModContent.ItemType<PlanterasFruit>(), () => NPC.downedPlantBoss, 500000),
                new MutantSummonInfo(Golem, ModContent.ItemType<LihzahrdPowerCell2>(), () => NPC.downedGolemBoss, 600000),
                new MutantSummonInfo(DukeFishron, ModContent.ItemType<TruffleWorm2>(), () => NPC.downedFishron, 600000),
                new MutantSummonInfo(LunaticCultist, ModContent.ItemType<CultistSummon>(), () => NPC.downedAncientCultist, 750000),
                new MutantSummonInfo(Moonlord, ModContent.ItemType<CelestialSigil2>(), () => NPC.downedMoonlord, 1000000),
                new MutantSummonInfo(Moonlord + 0.01f, ModContent.ItemType<MutantVoodoo>(), () => NPC.downedMoonlord, 2000000)
            };

            EventSummons = new List<MutantSummonInfo>();
        }

        internal void FinalizeSummonData()
        {
            SortedSummons.Sort((x, y) => x.progression.CompareTo(y.progression));
            SummonsFinalized = true;
        }

        internal void AddSummon(float progression, int itemId, Func<bool> downed, int price)
        {
            SortedSummons.Add(new MutantSummonInfo(progression, itemId, downed, price));
        }

        internal void AddEventSummon(float progression, int itemId, Func<bool> downed, int price)
        {
            EventSummons.Add(new MutantSummonInfo(progression, itemId, downed, price));
        }
    }

    internal class MutantSummonInfo
    {
        internal float progression;
        internal string modSource;
        internal int itemId;
        internal Func<bool> downed;
        internal int price;

        internal MutantSummonInfo(float progression, int itemId, Func<bool> downed, int price)
        {
            this.progression = progression;
            this.itemId = itemId;
            this.downed = downed;
            this.price = price;
        }
    }
}