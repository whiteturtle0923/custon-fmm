using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;

namespace Fargowiltas.Items.Ammos.Rockets
{
    class Rocket1Bag : BaseAmmo
    {
        public override int AmmunitionItem => ItemID.RocketI;
    }

    class Rocket2Bag : BaseAmmo
    {
        public override int AmmunitionItem => ItemID.RocketII;
    }

    class Rocket3Bag : BaseAmmo
    {
        public override int AmmunitionItem => ItemID.RocketIII;
    }

    class Rocket4Bag : BaseAmmo
    {
        public override int AmmunitionItem => ItemID.RocketIV;
    }
}
