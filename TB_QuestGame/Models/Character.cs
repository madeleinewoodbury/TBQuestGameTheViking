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
            Viking,
            Farmer,
            Englishman,
            Soldier
        }

        #endregion

        #region FIELDS

        private string _name;
        private int _age;
        private CharacterType _gameCharacter;
        private bool _isFriendly;

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

        public bool IsFriendly
        {
            get { return _isFriendly; }
            set { _isFriendly = value; }
        }

        #endregion

        #region CONSTRUCTORS

        public Character()
        {

        }

        public Character(string name, CharacterType race, bool isFriendly)
        {
            _name = name;
            _gameCharacter = race;
            _isFriendly = isFriendly;
        }

        #endregion

        #region METHODS



        #endregion
    }
}
