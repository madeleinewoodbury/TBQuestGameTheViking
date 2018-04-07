using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// the character class the player uses in the game
    /// </summary>
    public class Player : Character
    {
        #region ENUMERABLES

        public enum VikingType
        {
            None,
            Karl,
            Shieldmaiden
        }

        #endregion

        #region FIELDS

        private VikingType _viking;
        private string _homeVillage;
        private int _capital;
        private bool _isArmed;
        private int _health;
        private int _lives;
        private int _experiencePoints;
        private List<int> _locationsVisited;
        private List<GameObject> _inventory;

        #endregion

        #region PROPERTIES

        public VikingType Viking
        {
            get { return _viking; }
            set { _viking = value; }
        }

        public string HomeVillage
        {
            get { return _homeVillage; }
            set { _homeVillage = value; }
        }

        public int Capital
        {
            get { return _capital; }
            set { _capital = value; }
        }

        public bool IsArmed
        {
            get { return _isArmed; }
            set { _isArmed = value; }
        }

        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }

        public int Lives
        {
            get { return _lives; }
            set { _lives = value; }
        }

        public int ExperiencePoints
        {
            get { return _experiencePoints; }
            set { _experiencePoints = value; }
        }

        public List<int> LocationsVisted
        {
            get { return _locationsVisited; }
            set { _locationsVisited = value; }
        }

        public List<GameObject> Inventory
        {
            get { return _inventory; }
            set { _inventory = value; }
        }


        #endregion

        #region CONSTRUCTORS

        public Player()
        {
            _locationsVisited = new List<int>();
            _inventory = new List<GameObject>();
        }

        public Player(string name, CharacterType race, int locationId) : base(name, race, locationId)
        {
            _locationsVisited = new List<int>();
            _inventory = new List<GameObject>();
        }

        #endregion

        #region METHODS

        public bool HasVisited(int _locationId)
        {
            if (LocationsVisted.Contains(_locationId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string Greeting()
        {
            return $"Hello! I am {base.Name} of {_homeVillage}.";
        }

        #endregion
    }
}
