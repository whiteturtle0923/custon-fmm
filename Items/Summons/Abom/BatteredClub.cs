using Terraria.ID;

namespace Fargowiltas.Items.Summons.Abom
{
    public class BatteredClub : AbomSummon
    {
        public override int SummonType => NPCID.DD2OgreT3;

        //public override string NPCName => "Ogre";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Battered Club ");
            Tooltip.SetDefault("Summons the Ogre");
        }
    }
}