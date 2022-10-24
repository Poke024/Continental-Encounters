using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Continental_Encounters
{
    internal class Zone
    {
        // Name Member Variables
        private string _name;
        public string _Name
        {
            get { return _name; }
            set { _name = value; }
        }

        // Constructor Method Definitions
        public Zone() { }
        public Zone(string name) { _name = name; }
        public Zone(Zone orig)
        {
            _name = orig._name;
            _encounters = orig._encounters;
            _roamers = orig._roamers;
            _environments = orig._environments;
            _neighbors = orig._neighbors;
        }

        // Overloading Equals Operator
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
            if (lhs is null )
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

        // List Member Variables - Stores a zone's lists
        private List<string> _encounters = new List<string>();   //Encounters for this zone
        private List<string> _roamers = new List<string>();      //Roaming encounters for other zones
        private List<string> _environments = new List<string>();     //Environment features for this zone's encounters
        private List<string> _neighbors = new List<string>();      //Nearby zones to pull roaming encounters from

        // List Setter Methods - Reassigns to Completed Lists
        public void SetEncounters(List<string> encs) { _encounters = encs; }
        public void SetRoamers(List<string> roams) { _roamers = roams; }
        public void SetEnvironments(List<string> envs) { _environments = envs; }
        public void SetNeighbors(List<string> nhbrs) { _neighbors = nhbrs; }

        // Check if <list> Empty Methods - Returns a boolean of whether a list is empty
        public bool EmptyEncounters() { return _encounters.Count == 0; }
        public bool EmptyRoamers() { return _roamers.Count == 0; }
        public bool EmptyEnvironments() { return _environments.Count == 0; }
        public bool EmptyNeighbors() { return _neighbors.Count == 0; }

        // Add to <list> Methods - Adds a single string element to a list
        public void AddEncounter(string encounter) { _encounters.Add(encounter); }
        public void AddRoamer(string roamer) { _roamers.Add(roamer); }
        public void AddEnvironment(string feat) { _environments.Add(feat); }
        public void AddNeighbor(string nhbr) { _neighbors.Add(nhbr); }

        // Count <list> Methods - Returns an integer of the list's length
        public int CountEncounters() { return _encounters.Count; }
        public int CountRoamers() { return _roamers.Count; }
        public int CountEnvironments() { return _environments.Count; }
        public int CountNeighbors() { return _neighbors.Count; }

        // Get All Entries from <list> Methods - Returns a list of strings
        public List<string> GetAllEncounters() { return _encounters; }
        public List<string> GetAllRoamers() { return _roamers; }
        public List<string> GetAllEnvironments() { return _environments; }
        public List<string> GetAllNeighbors() { return _neighbors; }

        // Get One from <list> Methods - Returns the elements from a list at the specified integer index
        public string GetEncounter(int index)
        {
            if (index < _encounters.Count) { return _encounters[index]; }
            else { throw new ArgumentOutOfRangeException("Encounter index is outside valid range."); }
        }
        public string GetRoamer(int index)
        {
            if (index < _roamers.Count) { return _roamers[index]; }
            else { throw new ArgumentOutOfRangeException("Roamer index is outside valid range."); }
        }
        public string GetEnvironment(int index)
        {
            if (index < _environments.Count) { return _environments[index]; }
            else { throw new ArgumentOutOfRangeException("Environment index is outside valid range."); }
        }
        public string GetNeighbor(int index)
        {
            if (index < _neighbors.Count) { return _neighbors[index]; }
            else { throw new ArgumentOutOfRangeException("Neighbor index is outside valid range."); }
        }

        // Remove One from <list> by Index Methods - Removes an element from a list at the given integer index
        public void RemoveEncounter(int index)
        {
            if (index < _encounters.Count) { _encounters.RemoveAt(index); }
        }
        public void RemoveRoamer(int index)
        {
            if (index < _roamers.Count) { _roamers.RemoveAt(index); }
        }
        public void RemoveEnvironment(int index)
        {
            if (index < _environments.Count) { _environments.RemoveAt(index); }
        }
        public void RemoveNeighbor(int index)
        {
            if (index < _neighbors.Count) { _neighbors.RemoveAt(index); }
        }

        // Generate from <list> Methods - Generate a random integer index and use it to retrieve an encounter
        public string GenerateEncounter()
        {
            if (!EmptyEncounters())
            {
                Random rnd = new Random();
                int encIndex = rnd.Next(CountEncounters());
                return GetEncounter(encIndex);
            }
            else { throw new InvalidOperationException("Cannot generate from empty encounters list."); }
        }
        public string GenerateRoamer()
        {
            if (!EmptyRoamers())
            {
                Random rnd = new Random();
                int roamIndex = rnd.Next(CountRoamers());
                return GetRoamer(roamIndex);
            }
            else { throw new InvalidOperationException("Cannot generate from empty roamers list."); }
        }
        public string GenerateEnvironment()
        {
            if (!EmptyEnvironments())
            {
                Random rnd = new Random();
                int envIndex = rnd.Next(CountEnvironments());
                return GetEnvironment(envIndex);
            }
            else { throw new InvalidOperationException("Cannot generate from empty environments list."); }
        }
        public string GenerateNeighbor()
        {
            if (!EmptyNeighbors())
            {
                Random rnd = new Random();
                int envIndex = rnd.Next(CountNeighbors());
                return GetNeighbor(envIndex);
            }
            else { throw new InvalidOperationException("Cannot generate from empty neighbor list."); }
        }
    }
}
