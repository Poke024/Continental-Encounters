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

        // List Member Variables
        private List<string> _encounters = new List<string>();   //Encounters for this zone
        private List<string> _roamers = new List<string>();      //Roaming encounters for other zones
        private List<string> _environments = new List<string>();     //Environment features for this zone's encounters
        private List<string> _neighbors = new List<string>();      //Nearby zones to pull roaming encounters from

        // Constructor Method Definitions
        /**
         * @pre Constructor is called and passed a string name.
         * @post A Zone object instance is created with the given name assigned to it.
         * @param string newName: the name to be assigned to the zone
        **/
        public Zone(string newName) { _name = newName; }
        /**
         * @pre Copy Constructor is called and passed a Zone instance to copy.
         * @post A Zone object instance is created as a deep copy of the passed Zone.
         * @param Zone orig: the original Zone to create a copy of.
        **/
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
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        // List Setter Methods for Reassigning to Completed Lists
        /**
         * @pre Method is passed a list of strings.
         * @post Corresponding list member variable matches the given list.
         * @param List<string> newList: the list to be matched.
        **/
        public void SetEncounters(List<string> newList) { _encounters = newList; }
        public void SetRoamers(List<string> newList) { _roamers = newList; }
        public void SetEnvironments(List<string> newList) { _environments = newList; }
        public void SetNeighbors(List<string> newList) { _neighbors = newList; }

        // Check if <list> Empty Methods
        /**
         * @post Boolean value is given based on whether the tested list is empty or not.
         * @param List<string> newList: the list to be matched.
         * @return True if the corresponding list is empty, False otherwise.
        **/
        public bool EmptyEncounters() { return _encounters.Count == 0; }
        public bool EmptyRoamers() { return _roamers.Count == 0; }
        public bool EmptyEnvironments() { return _environments.Count == 0; }
        public bool EmptyNeighbors() { return _neighbors.Count == 0; }

        // Append to <list> Methods
        /**
         * @pre A string value is passed to the method.
         * @post The passed entry is appened to the end of the corresponding list.
         * @param string newEntry: the string to appended to the end of the list.
        **/
        public void AppendEncounter(string newEntry) { _encounters.Add(newEntry); }
        public void AppendRoamer(string newEntry) { _roamers.Add(newEntry); }
        public void AppendEnvironment(string newEntry) { _environments.Add(newEntry); }
        public void AppendNeighbor(string newEntry) { _neighbors.Add(newEntry); }

        // Count <list> Methods
        /**
         * @pre none
         * @post The number of entries in the corresponding list is counted and returned.
         * @return _listName.Count: the number of entries in the corresponding list.
        **/
        public int CountEncounters() { return _encounters.Count; }
        public int CountRoamers() { return _roamers.Count; }
        public int CountEnvironments() { return _environments.Count; }
        public int CountNeighbors() { return _neighbors.Count; }

        // Get All Entries from <list> Methods
        /**
         * @pre none
         * @post All entries in the corresponding list are returned as a list.
         * @return _listName: the corresponding list.
        **/
        public List<string> GetAllEncounters() { return _encounters; }
        public List<string> GetAllRoamers() { return _roamers; }
        public List<string> GetAllEnvironments() { return _environments; }
        public List<string> GetAllNeighbors() { return _neighbors; }

        // Get One from <list> Methods
        /**
         * @pre The corresponding list is not empty and a valid index is given.
         * @post Returns the entry at the given index from the corresponding list.
         * @param int index: the index of the entry to be retrieved.
         * @throw InvalidOperationException if the corresponding list is empty, ArgumentOutOfRangeException if the index is invalid.
         * @return A string entry from the corresponding list.
        **/
        public string GetEncounter(int index)
        {
            if (EmptyEncounters()) { throw new InvalidOperationException("Cannot get encounter from empty list."); }
            else
            {
                if (index < _encounters.Count && index >= 0) { return _encounters[index]; }
                else { throw new ArgumentOutOfRangeException("Encounter get index is outside valid range."); }
            }
        }
        public string GetRoamer(int index)
        {
            if (EmptyRoamers()) { throw new InvalidOperationException("Cannot get roamer from empty list."); }
            else
            {
                if (index < _roamers.Count && index >= 0) { return _roamers[index]; }
                else { throw new ArgumentOutOfRangeException("Roamer get index is outside valid range."); }
            }
        }
        public string GetEnvironment(int index)
        {
            if (EmptyEnvironments()) { throw new InvalidOperationException("Cannot get environment from empty list."); }
            else
            {
                if (index < _environments.Count && index >= 0) { return _environments[index]; }
                else { throw new ArgumentOutOfRangeException("Environment get index is outside valid range."); }
            }
        }
        public string GetNeighbor(int index)
        {
            if (EmptyNeighbors()) { throw new InvalidOperationException("Cannot get neighbor from empty list."); }
            else
            {
                if (index < _neighbors.Count && index >= 0) { return _neighbors[index]; }
                else { throw new ArgumentOutOfRangeException("Neighbor get index is outside valid range."); }
            }
        }

        // Remove One from <list> by Index Methods
        /**
         * @pre The corresponding list is not empty and a valid index is given.
         * @post Removes the entry at the given index from the corresponding list.
         * @param int index: the index of the entry to be removed.
         * @throw InvalidOperationException if the corresponding list is empty, ArgumentOutOfRangeException if the index is invalid.
        **/
        public void RemoveEncounter(int index)
        {
            if (EmptyEncounters()) { throw new InvalidOperationException("Cannot get roamer from empty list."); }
            else
            {
                if (index < _encounters.Count && index >= 0) { _encounters.RemoveAt(index); }
                else { throw new ArgumentOutOfRangeException("Encounter removal index is outside valid range."); }
            }
        }
        public void RemoveRoamer(int index)
        {
            if (EmptyRoamers()) { throw new InvalidOperationException("Cannot get roamer from empty list."); }
            else
            {
                if (index < _roamers.Count && index >= 0) { _roamers.RemoveAt(index); }
                else { throw new ArgumentOutOfRangeException("Roamer removal index is outside valid range."); }
            }
        }
        public void RemoveEnvironment(int index)
        {
            if (EmptyEnvironments()) { throw new InvalidOperationException("Cannot get roamer from empty list."); }
            else
            { 
                if (index < _environments.Count && index >= 0) { _environments.RemoveAt(index); }
                else { throw new ArgumentOutOfRangeException("Environment removal index is outside valid range."); }
            }
        }
        public void RemoveNeighbor(int index)
        {
            if (EmptyNeighbors()) { throw new InvalidOperationException("Cannot get roamer from empty list."); }
            else
            { 
                if (index < _neighbors.Count && index >= 0) { _neighbors.RemoveAt(index); }
                else { throw new ArgumentOutOfRangeException("Neighbor removal index is outside valid range."); }
            }
        }

        // Generate from <list> Methods
        /**
         * @pre The corresponding list cannot be empty.
         * @post Returns a random entry from the corresponding list.
         * @throw InvalidOperationException if the corresponding list is empty.
         * @return A string entry from the corresponding list.
        **/
        public string GenerateEncounter()
        {
            if (EmptyEncounters()) { throw new InvalidOperationException("Cannot generate from empty encounters list."); }
            else
            {
                Random rnd = new Random();
                int encIndex = rnd.Next(CountEncounters());
                return GetEncounter(encIndex);
            }
        }
        public string GenerateRoamer()
        {
            if (EmptyRoamers()) { throw new InvalidOperationException("Cannot generate from empty roamers list."); }
            else
            {
                Random rnd = new Random();
                int roamIndex = rnd.Next(CountRoamers());
                return GetRoamer(roamIndex);
            }
        }
        public string GenerateEnvironment()
        {
            if (EmptyEnvironments()) { throw new InvalidOperationException("Cannot generate from empty environments list."); }
            else
            {
                Random rnd = new Random();
                int envIndex = rnd.Next(CountEnvironments());
                return GetEnvironment(envIndex);
            }
        }
        public string GenerateNeighbor()
        {
            if (EmptyNeighbors()) { throw new InvalidOperationException("Cannot generate from empty neighbor list."); }
            else
            {
                Random rnd = new Random();
                int envIndex = rnd.Next(CountNeighbors());
                return GetNeighbor(envIndex);
            }
        }
    }
}
