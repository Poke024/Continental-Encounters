using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Continental_Encounters
{
    internal class Zone
    {
        private string _name;
        public string _Name
        {
            get { return _name; }
            set { _name = value; }
        }

        Random rnd = new Random();

        public Zone(string name)
        {
            _name = name;
        }

        private List<string> _encounters;   //Encounters for this zone
        private List<string> _roamers;      //Roaming encounters for other zones
        private List<string> _envFeats;     //Environment features for this zone's encounters
        private List<Zone> _neighbors;      //Nearby zones to pull roaming encounters from

        public void addEncounter(string encounter)
        {
            _encounters.Add(encounter);
        }

        public string getEncounter(int index)
        {
            if (index < _encounters.Count)
            {
                return _encounters[index];
            }
            else
            {
                return string.Empty;
            }
        }

        public void addRoamer(string roamer)
        {
            _roamers.Add(roamer);
        }

        public string getRoamer(int index)
        {
            if (index < _roamers.Count)
            {
                return _roamers[index];
            }
            else
            {
                return string.Empty;
            }
        }

        public int countRoamers()
        {
            return _roamers.Count;
        }

        public void addEnvFeat(string feat)
        {
            _envFeats.Add(feat);
        }

        public string getEnvFeat(int index)
        {
            if (index < _envFeats.Count)
            {
                return _envFeats[index];
            }
            else
            {
                return string.Empty;
            }
        }

        public void addNeighbor(Zone nghbr)
        {
            _neighbors.Add(nghbr);
        }

        public Zone getNeighbor(int index)
        {
            if (index < _neighbors.Count)
            {
                return _neighbors[index];
            }
            else
            {
                throw new ArgumentOutOfRangeException("index");
            }
        }
        public string generateEncounter()
        {
            int type = rnd.Next(1, 11);
            if (type < 7)
            {
                int selection = rnd.Next(_encounters.Count);
                return getEncounter(selection);
            }
            else if (type == 7 || type == 8)
            {
                int roamZone = rnd.Next(_neighbors.Count);
                int selection = rnd.Next(getNeighbor(roamZone).countRoamers());
                return getNeighbor(roamZone).getRoamer(selection);
            }
            else
            {
                int choiceOne = rnd.Next(_encounters.Count);
                int roamZone = rnd.Next(_neighbors.Count);
                int choiceTwo = rnd.Next(getNeighbor(roamZone).countRoamers());
                string enc1 = getEncounter(choiceOne);
                string enc2 = getNeighbor(roamZone).getRoamer(choiceTwo);
                return $"{enc1} and {enc2}";
            }
        }
    }
}
