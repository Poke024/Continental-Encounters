using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Continental_Encounters
{
    class Speed
    {
        public int distance { get; set; }
        public string type { get; set; }
    }
    class Skill
    {
        public string name { get; set; }
        public bool proficiency { get; set; }
    }
    class Sense
    {
        public string name { get; set; }
        public int distance { get; set; }
    }

    abstract class Creature
    {
        public string name { get; set; }
        public string size { get; set; }
        public string alignment { get; set; }
        public abstract int hitPoints { get; set; }
        public int armorClass { get; set; }
        public string armorType { get; set; }
        public Speed[] speeds { get; set; }
        public int[] abilityScores { get; set; }
        public int[] abilityModifiers { get; set; }
        public Skill[] skills { get; set; }
        public Sense[] senses { get; set; }
        public int passivePerception { get; set; }
        public string[] languages { get; set; }
        
        public void GetAbilityScores()
        {

        }
        public void CalculateModifiers()
        {

        }

    }
}
