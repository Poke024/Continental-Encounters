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

        public Zone() { }
        public Zone(string name) { _name = name; }
        public Zone(Zone orig)
        {
            _name = orig._name;
            _encounters = orig._encounters;
            _roamers = orig._roamers;
            _envFeats = orig._envFeats;
            _neighbors = orig._neighbors;
        }



        public bool Equals(Zone z)
        {
            if (z is null) { return false; }
            if (Object.ReferenceEquals(this, z)) { return true; }
            if (this.GetType() != z.GetType()) { return false; }
            return (this._name == z._name);
        }



        public override bool Equals(object obj) => this.Equals(obj as Zone);
        public static bool operator ==(Zone lhs, Zone rhs)
        {
            if (lhs is null)
            {
                if (rhs is null) { return true; }
                else { return false; }
            }
            else
            {
                return lhs.Equals(rhs);
            }
        }
        public static bool operator !=(Zone lhs, Zone rhs) => !(lhs == rhs);



        private List<string> _encounters = new List<string>();   //Encounters for this zone
        private List<string> _roamers = new List<string>();      //Roaming encounters for other zones
        private List<string> _envFeats = new List<string>();     //Environment features for this zone's encounters
        private List<string> _neighbors = new List<string>();      //Nearby zones to pull roaming encounters from

        public void SetEncounters(List<string> encs) { _encounters = encs; }

        public void SetRoamers(List<string> roams) { _roamers = roams; }

        public void SetEnvFeats(List<string> envs) { _envFeats = envs; }

        public void SetNeighbors(List<string> nhbrs)
        {
            _neighbors = nhbrs;
        }



        public bool EmptyEnc()
        {
            if(_encounters.Count == 0) { return true; }
            else { return false; }
        }

        public bool EmptyRoam()
        {
            if (_roamers.Count == 0) { return true; }
            else { return false; }
        }

        public bool EmptyEnv()
        {
            if (_envFeats.Count == 0) { return true; }
            else { return false; }
        }

        public bool EmptyNhbr()
        {
            if (_neighbors.Count == 0) { return true; }
            else { return false; }
        }



        public void AddEncounter(string encounter) { _encounters.Add(encounter); }

        public int CountEncounters() { return _encounters.Count; }

        public List<string> GetAllEncounters() { return _encounters; }

        public string GetEncounter(int index)
        {
            if (index < _encounters.Count) { return _encounters[index]; }
            else { return string.Empty; }
        }

        public void RemEncounter(int index)
        {
            if (index < _encounters.Count) { _encounters.RemoveAt(index); }
        }



        public void AddRoamer(string roamer) { _roamers.Add(roamer); }

        public int CountRoamers() { return _roamers.Count; }

        public List<string> GetAllRoamers() { return _roamers; }

        public string GetRoamer(int index)
        {
            if (index < _roamers.Count) { return _roamers[index]; }
            else { return string.Empty; }
        }

        public void RemRoamer(int index)
        {
            if (index < _roamers.Count) { _roamers.RemoveAt(index); }
        }



        public void AddEnvFeat(string feat) { _envFeats.Add(feat); }

        public int CountEnvFeats() { return _envFeats.Count; }

        public List<string> GetAllEnvFeats() { return _envFeats; }

        public string GetEnvFeat(int index)
        {
            if (index < _envFeats.Count) { return _envFeats[index]; }
            else { return string.Empty; }
        }

        public void RemEnvFeat(int index)
        {
            if (index < _envFeats.Count) { _envFeats.RemoveAt(index); }
        }



        public void AddNeighbor(string nhbr) { _neighbors.Add(nhbr); }

        public int CountNeighbors() { return _neighbors.Count; }

        public List<string> GetAllNeighbors() { return _neighbors; }

        public string GetNeighbor(int index)
        {
            if (index < _neighbors.Count) { return _neighbors[index]; }
            else { return String.Empty; }
        }

        public void RemNeighbor(int index)
        {
            if (index < _neighbors.Count) { _neighbors.RemoveAt(index); }
        }



        public string GenerateLocal()
        {
            var rnd = new Random();
            if (!EmptyEnc())
            {
                int encIndex = rnd.Next(CountEncounters());
                return GetEncounter(encIndex);
            }
            else { return "Unable to generate encounter with current selections."; }
        }

        public string GenerateRoamer()
        {
            var rnd = new Random();
            if (!EmptyRoam())
            {
                int roamIndex = rnd.Next(CountRoamers());
                return GetRoamer(roamIndex);
            }
            else { return "Unable to generate encounter with current selections."; }
        }

        public List<string> GenerateFeatures(int encFeats)
        {
            List<string> generation = new List<string>();

            if (!EmptyEnv())
            {
                for (int i = 0; i < encFeats; i++)
                {
                    int envIndex = rnd.Next(CountEnvFeats());
                    string feat = GetEnvFeat(envIndex);
                    generation.Add(feat);
                }

                return generation;
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
