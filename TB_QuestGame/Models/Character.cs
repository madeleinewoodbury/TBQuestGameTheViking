using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// base class for the player and all game characters
    /// </summary>
    public class Character
    {
        #region ENUMERABLES

        public enum CharacterType
        {
            None,
            Royalty,
            Viking,
            Farmer,
            Englishman,
            Soldier
        }

        public enum Rank
        {
            None,
            Viking, //rank 1
            Marauder, //rank 2
            Berserker, //rank 3
            Huskarl, //rank 4
            Radnigar, //rank 5
            Hersir, // rank 6
            Skald, //rank 7
            Freyr, // rank 8 male
            Freya, // rank 8 female
            Jarl, // rank 9
            King, // rank 10 male
            Queen, //rank 10 female
        }

        #endregion

        #region FIELDS

        private string _name;
        private int _age;
        private CharacterType _gameCharacter;
        private int _locationId;
        private bool _isFriendly;
        private Rank _vikingRank;

        #endregion

        #region PROPERTIES

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public CharacterType GameCharacter
        {
            get { return _gameCharacter; }
            set { _gameCharacter = value; }
        }

        public int LocationId
        {
            get { return _locationId; }
            set { _locationId = value; }
        }

        public bool IsFriendly
        {
            get { return _isFriendly; }
            set { _isFriendly = value; }
        }

        public Rank VikingRank
        {
            get { return _vikingRank; }
            set { _vikingRank = value; }
        }

        #endregion

        #region CONSTRUCTORS

        public Character()
        {

        }

        public Character(string name, CharacterType race, int locationId)
        {
            _name = name;
            _gameCharacter = race;
            _locationId = locationId;
        }

        #endregion

        #region METHODS

        public virtual string Greeting()
        {
            return $"Hei, my name is {_name} and I am a {_gameCharacter}";   
        }



        #endregion
    }
}
