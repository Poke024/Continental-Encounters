using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Continental_Encounters
{
    internal class TraitsFeatures
    {
        public string TraitFeatName { get; set; }
        public string TraitFeatDesc { get; set; }
    }

    internal class Spell
    {
        public string SpellName;
        public int SpellLvl
        {
            set
            {
                if (value >= 0) { SpellLvl = value; }
            }
        }
        public string SpellSchool { get; set; }
        public bool Ritual { get; set; }
        public string CastTime { get; set; }
        public string Range { get; set; }
        public bool Verbal { get; set; }
        public bool Somatic { get; set; }
        public bool Material { get; set; }
        public string MaterialDesc { get; set; }
        public string Duration { get; set; }
        public bool Concentration { get; set; }
        public string Desc { get; set; }
        public string HighLvlDesc { get; set; }
        public string Src { get; set; }
        public List<string> Classes = new List<string>();

    }
}
