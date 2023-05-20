/**
 * @file DnDFifthEdition.cs
 * @author: Adair Torres
 * @brief: This file contains classes related to using the application with Dungeons & Dragons Fifth Edition.
 * @last modified: 10/28/2022
**/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Continental_Encounters
{
    internal class Roller
    {
        // Roller Format: <# of dice>D<# of sides> + <Bonus amount>, Ex: 2d12 + 5
        // The bonus amount depends on what the dice is being used for. Ex: Hit Dice use Constitution modifier, Attack Dice use Strength or Dexterity modifier.
        private uint _diceCount;
        private uint _diceSides;
        private int _bonus;

        /**
         * @pre Constructor is called with three parameters given.
         * @post Instantiates a new Roller object.
         * @param uint diceCount: the number of dice to be rolled; uint diceSides: the numbers of sides on the dice; int bonus: a flat bonus to be applied to the roll result.
         * @throw ArgumentException if diceCount or diceSides are not positive numbers.
         * @return none
        **/
        public Roller(uint diceCount, uint diceSides, int bonus)      // Constructor with Parameters
        {
            if (diceCount > 0 && diceSides > 0)
            {
                _diceCount = diceCount;
                _diceSides = diceSides;
                _bonus = bonus;
            }
            else { throw new ArgumentException("A dice object cannot be created with the given parameters."); }
        }
        /**
         * @pre Copy Constructor for making a deep copy of a Roller instance.
         * @post Instantiates a deep copy of a Roller object.
         * @param Roller orig: the Roller to be copied.
         * @throw none
         * @return none
        **/
        public Roller(Roller orig)      // Copy Constructor
        {
            _diceCount = orig._diceCount;
            _diceSides = orig._diceSides;
            _bonus = orig._bonus;
        }
        /**
         * @pre 
         * @post 
         * @param 
         * @throw 
         * @return 
        **/
        public void ChangeAll(uint newDice, uint newSides, int newBonus)
        {
            if (newDice > 0 && newSides > 0)
            {
                _diceCount = newDice;
                _diceSides = newSides;
                _bonus = newBonus;
            }
            else { throw new ArgumentException("A dice object cannot be created with the given parameters."); }
        }
        /**
         * @pre 
         * @post 
         * @param 
         * @throw 
         * @return 
        **/
        public void ChangeAmount(uint newDice)
        {
            if (newDice > 0) { _diceCount = newDice; }
            else { throw new ArgumentOutOfRangeException("The number of dice must be a positive integer."); }
        }
        /**
         * @pre 
         * @post 
         * @param 
         * @throw 
         * @return 
        **/
        public void ChangeSides(uint newSides)
        {
            if (newSides > 0) { _diceSides = newSides; }
            else { throw new ArgumentOutOfRangeException("The number of sides must be a positive integer."); }
        }
        /**
         * @pre 
         * @post 
         * @param 
         * @throw 
         * @return 
        **/
        public void ChangeBonus(int newBonus) { _bonus = newBonus; }
        /**
         * @pre 
         * @post 
         * @param 
         * @throw 
         * @return 
        **/
        public uint GetAmount() { return _diceCount; }
        /**
         * @pre 
         * @post 
         * @param 
         * @throw 
         * @return 
        **/
        public uint GetSides() { return _diceSides; }
        /**
         * @pre 
         * @post 
         * @param 
         * @throw 
         * @return 
        **/
        public int GetBonus() { return _bonus; }

        /**
         * @pre 
         * @post 
         * @param 
         * @throw 
         * @return 
        **/
        public int[] ShowRolls()        // Returns an array of format { Total, Flat Bonus, 1st Roll, ..., Last Roll }
        {
            var rnd = new Random();
            int[] rolls = { 0, _bonus };
            for (int i = 1; i <= _diceCount; i++)
            {
                int roll = rnd.Next(1, (int)_diceSides + 1);
                rolls.Append(roll);
            }
            rolls[0] = rolls.Sum();
            return rolls;
        }
        /**
         * @pre 
         * @post 
         * @param 
         * @throw 
         * @return 
        **/
        public int RollTotal()
        {
            var rnd = new Random();
            int total = 0;
            for (int i = 1; i<= _diceCount; i++) { total += rnd.Next(1, (int)_diceSides + 1); }
            return total + _bonus;
        }
        /**
         * @pre 
         * @post 
         * @param 
         * @throw 
         * @return 
        **/
        public int getMax()
        {
            return (int)_diceCount * (int)_diceSides + _bonus;
        }
    }

    internal class AbilityScores
    {
        // Indices: Strength = 0, Dexterity = 1, Constitution = 2, Intelligence = 3, Wisdom = 4, Charisma = 5
        private uint[] _rawScores = {10, 10, 10, 10, 10, 10};
        private int[] _modifiers = {0, 0, 0, 0, 0, 0, 0};
        /**
         * @pre 
         * @post 
         * @param 
         * @throw 
         * @return 
        **/
        private void _calculateMods()
        {
            for (int i = 0; i < _rawScores.Length; i++)
            {
                if (_rawScores[i] > 0) { _modifiers[i] = (int)Math.Floor(((float)_rawScores[i] - 10) / 2); }
                else { _modifiers[i] = 0; }
            }
        }
        /**
         * @pre 
         * @post 
         * @param 
         * @throw 
         * @return 
        **/
        public AbilityScores()
        {
            _rawScores = new uint[] { 0, 0, 0, 0, 0, 0 };
            _modifiers = new int[] { 0, 0, 0, 0, 0, 0 };
        }
        /**
         * @pre 
         * @post 
         * @param 
         * @throw 
         * @return 
        **/
        public AbilityScores(uint[] stats)
        {
            if (stats.Length == 6)
            {
                _rawScores = stats;
                _calculateMods();
            }
            else { throw new ArgumentException("Stats array parameter must be of size 6."); }
        }
        /**
         * @pre 
         * @post 
         * @param 
         * @throw 
         * @return 
        **/
        public uint[] getScores()
        {
            return _rawScores;
        }
        /**
         * @pre 
         * @post 
         * @param 
         * @throw 
         * @return 
        **/
        public int[] getModifiers()
        {
            return _modifiers;
        }
        /**
         * @pre 
         * @post 
         * @param 
         * @throw 
         * @return 
        **/
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
        /**
         * @pre 
         * @post 
         * @param 
         * @throw 
         * @return 
        **/
        public TraitFeature() { }
        /**
         * @pre 
         * @post 
         * @param 
         * @throw 
         * @return 
        **/
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
        public Roller Damage;
        public Roller SecondDmg;

        public Attack() { }
        public Attack(string name, string type, string rng, string targ, int hit, Roller dmg)
        {
            AttackName = name;
            AttackType = type;
            AttackRange = rng;
            Target = targ;
            toHit = hit;
            Damage = dmg;
        }
        public Attack(string name, string type, string rng, string targ, int hit, Roller dmg, Roller dmg2)
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
            Roller d20 = new Roller(1, 20, toHit);
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

    internal abstract class Creatures
    {
        // Required by the combat tracker.
        public string Name { get; set; }
        public int ArmorClass { get; set; }
        public Roller HitDice;
        public int curHP;
        public int maxHP;
        public int InitiativeBonus { get; set; }
        public abstract int[] getHP();

        // Additional mechanics that all creatures use.
        public AbilityScores Scores;
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

        public PlayerCharacter(string name, int ac, Roller hitDice, int initiative)
        {

        }
    
        public override int[] getHP()
        {
            int[] hp = { 0, 0 };
            return hp;
        }
    }

    internal class Monster : Creatures
    {
        // Required by the combat tracker
        public override int[] getHP()
        {
            throw new NotImplementedException();
        }

    }
}
