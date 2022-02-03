using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Continental_Encounters
{
    internal class Creatures
    {
        public string Name { get; set; }
        public string Alignment { get; set; }
        public int ArmorClass { get; set; }
        public int[] HitDice { get; set; }

    }

    internal class Player : Creatures
    {
    }

    internal class Monster : Creatures
    {
    }
}
