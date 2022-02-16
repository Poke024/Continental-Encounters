using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Continental_Encounters
{
    internal class Dice
    {
        // Dice Format: <# of dice>D<# of sides> + <Bonus amount>, Ex: 2d12 + 5
        // The bonus amount depends on what the dice is being used for. Ex: Hit Dice use Constitution modifier, Attack Dice use Strength or Dexterity modifier.
        private uint _numDice;
        private uint _numSides;
        private int _flatBonus;
        public Dice()       // Parameterless Constructor
        {
            _numDice = _numSides = 0;
            _flatBonus = 0;
        }
        public Dice(uint newDice, uint newSides, int newBonus)      // Constructor with Parameters
        {
            if (newDice > 0 && newSides > 0)
            {
                _numDice = newDice;
                _numSides = newSides;
                _flatBonus = newBonus;
            }
            else { throw new ArgumentException("A dice object cannot be created with the given parameters."); }
        }
        public Dice(Dice orig)      // Copy Constructor
        {
            _numDice = orig._numDice;
            _numSides = orig._numSides;
            _flatBonus = orig._flatBonus;
        }
        public void ChangeAll(uint newDice, uint newSides, int newBonus)
        {
            if (newDice > 0 && newSides > 0)
            {
                _numDice = newDice;
                _numSides = newSides;
                _flatBonus = newBonus;
            }
            else { throw new ArgumentException("A dice object cannot be created with the given parameters."); }
        }
        public void ChangeAmount(uint newDice)
        {
            if (newDice > 0) { _numDice = newDice; }
            else { throw new ArgumentOutOfRangeException("The number of dice must be a positive integer."); }
        }
        public void ChangeSides(uint newSides)
        {
            if (newSides > 0) { _numSides = newSides; }
            else { throw new ArgumentOutOfRangeException("The number of sides must be a positive integer."); }
        }
        public void ChangeBonus(int newBonus) { _flatBonus = newBonus; }
        public uint GetAmount() { return _numDice; }
        public uint GetSides() { return _numSides; }
        public int GetBonus() { return _flatBonus; }

        public int[] ShowRolls()        // Returns an array of format { Total, Flat Bonus, 1st Roll, ..., Last Roll }
        {
            var rnd = new Random();
            int[] rolls = { 0, _flatBonus };
            for (int i = 1; i <= _numDice; i++)
            {
                int roll = rnd.Next(1, (int)_numSides + 1);
                rolls.Append(roll);
            }
            rolls[0] = rolls.Sum();
            return rolls;
        }

        public int RollTotal()
        {
            var rnd = new Random();
            int total = 0;
            for (int i = 1; i<= _numDice; i++) { total += rnd.Next(1, (int)_numSides + 1); }
            return total + _flatBonus;
        }
    }

    internal class AbilityScores
    {
        // Indices: Strength = 0, Dexterity = 1, Constitution = 2, Intelligence = 3, Wisdom = 4, Charisma = 5
        private uint[] _rawScores;
        private int[] _modifiers;
        private bool zeroRaw;

        private void _calculateMods()
        {
            for (int i = 0; i < _rawScores.Length; i++)
            {
                if(_rawScores[i] > 0) { _modifiers[i] = (int)Math.Floor(((float)_rawScores[i] - 10) / 2); }
                else
                {
                    _modifiers[i] = 0;
                    zeroRaw = true;
                }
            }
        }
        public AbilityScores()
        {
            _rawScores = new uint[] { 0, 0, 0, 0, 0, 0 };
            _modifiers = new int[] { 0, 0, 0, 0, 0, 0 };
            zeroRaw = true;
        }

        public AbilityScores(uint[] stats)
        {
            if (stats.Length == 6)
            {
                _rawScores = stats;
                _calculateMods();
            }
            else { throw new ArgumentException("Stats array parameter must be of size 6."); }
        }

        public uint[] getScores()
        {
            return _rawScores;
        }
        public int[] getModifiers()
        {
            return _modifiers;
        }

        public void changeScore(string target, uint value)
        {
            if (value >= 0)
            {
                switch (target.ToLower())
                {
                    case "strength":
                    case "str":
                        _rawScores[0] = value;
                        break;
                    case "dexterity":
                    case "dex":
                        _rawScores[1] = value;
                        break;
                    case "constitution":
                    case "con":
                        _rawScores[2] = value;
                        break;
                    case "intelligence":
                    case "int":
                        _rawScores[3] = value;
                        break;
                    case "wisdom":
                    case "wis":
                        _rawScores[4] = value;
                        break;
                    case "charisma":
                    case "cha":
                        _rawScores[5] = value;
                        break;
                    default:
                        throw new ArgumentException("Invalid target parameter.");
                }
                _calculateMods();
            }
            else { throw new ArgumentOutOfRangeException("New score is out of range."); }
        }
    }

    internal class TraitFeature
    {
        public TraitFeature() { }
        public TraitFeature(string name, string desc)
        {
            TraitFeatName = name;
            TraitFeatDesc = desc;
        }
        public string TraitFeatName { get; set; }
        public string TraitFeatDesc { get; set; }
    }

    internal class Spell
    {
        private uint _spellLvl;
        private bool[] _vsm;        //Indices: 0 - Verbal, 1 - Somatic, 2 - Material ; A true value means the spell requires that type of component.
        private string[] _classList;
        private string _materialDesc;
        private bool _validVSM(string[] VSM)
        {
            if (VSM.Length == 3) { return true; }
            else { return false; }
        }
        public string SpellName { get; set; }
        public string School { get; set; }
        public bool Ritual { get; set; }
        public string CastTime { get; set; }
        public string Range { get; set; }
        public string Duration { get; set; }
        public bool Concentration { get; set; }
        public string SpellDesc { get; set; }
        public string HighLvlDesc { get; set; }
        public string Source { get; set; }
        public Spell() { }
        public Spell(uint lvl, string name, string schl, bool rit, string time, string rng, bool[] VSM, string matDesc, bool conc, string spellDesc, string lvlDesc, string[] classes, string src)
        {
            if (_spellLvl < 0 || VSM.Length != 3) { throw new ArgumentException("A spell object cannot be created with the given parameters."); }
            else
            {
                if (VSM[2] == string.IsNullOrEmpty(matDesc)) { throw new ArgumentException("Material component traits mismatched."); }
                else
                {
                    _spellLvl = lvl;
                    SpellName = name;
                    School = schl;
                    Ritual = rit;
                    CastTime = time;
                    Range = rng;
                    _vsm = VSM;
                    _materialDesc = matDesc;
                    Concentration = conc;
                    SpellDesc = spellDesc;
                    HighLvlDesc = lvlDesc;
                    _classList = classes;
                    Source = src;
                }
            }
        }
        public void setComponents(bool[] VSM, string matDesc)
        {
            if (VSM[2] == string.IsNullOrEmpty(matDesc)) { throw new ArgumentException("Material component traits mismatched."); }
            else
            {
                _vsm = VSM;
                _materialDesc = matDesc;
            }
        }
        public void setClasses(string[] classes) { _classList = classes; }
        public void addClass(string cls) { _classList.Append(cls); }
    }

    internal class Attack
    {
        public string AttackName { get; set; }
        public string AttackType { get; set; }
        public string AttackRange { get; set; }
        public string Target { get; set; }
        public int toHit { get; set; }
        public Dice Damage;
        public Dice SecondDmg;

        public Attack() { }
        public Attack(string name, string type, string rng, string targ, int hit, Dice dmg)
        {
            AttackName = name;
            AttackType = type;
            AttackRange = rng;
            Target = targ;
            toHit = hit;
            Damage = dmg;
        }
        public Attack(string name, string type, string rng, string targ, int hit, Dice dmg, Dice dmg2)
        {
            AttackName = name;
            AttackType = type;
            AttackRange = rng;
            Target = targ;
            toHit = hit;
            Damage = dmg;
            SecondDmg = dmg2;
        }

        public int[] RollToHit()     // Returns an array of format { Total, Flat bonus, 1d20 Roll }
        {
            Dice d20 = new Dice(1, 20, toHit);
            return d20.ShowRolls();
        }
        public int[] RollDamage(uint choice)
        {
            int[] rollData;
            switch (choice)
            {
                case 1:
                    rollData = Damage.ShowRolls();
                    break;
                case 2:
                    rollData = SecondDmg.ShowRolls();
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Damage option to roll must be indicated by a 1 (Default Damage) or a 2 (Secondary Damage).");
            }
            return rollData;
        }
    }

    internal class Action
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool PlayerAttack { get; set; }
        public Attack Atk;
        Action() { }
        Action(string name, string desc)
        {
            Name = name;
            Description = desc;
            PlayerAttack = false;
        }
        Action(string name, string desc, bool plrAtk)
        {
            if (plrAtk == false)
            {
                Name = name;
                Description = desc;
                PlayerAttack = plrAtk;
            }
            else { throw new ArgumentException("Incorrect constructor / parameter use, must include an Attack object for an attack that is a Player Attack."); }
        }
        Action(string name, string desc, bool plrAtk, Attack atk)
        {
            if (plrAtk == true)
            {
                Name = name;
                Description = desc;
                PlayerAttack = plrAtk;
                Atk = atk;
            }
            else { throw new ArgumentException("Incorrect constructor / parameter use, cannot have an Attack object for an attack that is not a Player Attack."); }
        }
    }

    internal class Creatures
    {
        // Required by the combat tracker.
        public string Name { get; set; }
        public int ArmorClass { get; set; }
        public Dice HP;
        public int InitiativeBonus { get; set; }

        // Additional mechanics that all creatures use.
        public AbilityScores Scores = new AbilityScores();
        public string Alignment { get; set; }
        public List<TraitFeature> TraitsFeatsList = new List<TraitFeature>();
        public List<string> Languages = new List<string>();
        public List<Spell> KnownSpells = new List<Spell>();
    }

    internal class PlayerCharacter : Creatures
    {
        public string Class { get; set; }
        public int Level { get; set; }
        public string Background { get; set; }
        public string PlayerName { get; set; }
        public string Race { get; set; }
        public int Xp { get; set; }
        public int Speed { get; set; }

        public int[] DeathSaves = { 0, 0 };
    }

    internal class Monster : Creatures
    {
        // Required by the combat tracker

    }
}
