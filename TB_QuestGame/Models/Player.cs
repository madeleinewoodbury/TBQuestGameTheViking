﻿using System;
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

        public enum Weapon
        {
            None,
            Sword,
            Axe,
            Shield,
            Bow, 
            Knife
        }

        #endregion

        #region FIELDS

        private VikingType _viking;
        private string _homeVillage;
        private int _capital;
        private List<Weapon> _weaponType;
        private bool _isArmed;
        private int _health;
        private int _lives;
        private int _experiencePoints;
        private List<int> _locationsVisited;

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

        public List<Weapon> WeaponType
        {
            get { return _weaponType; }
            set { _weaponType = value; }
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


        #endregion

        #region CONSTRUCTORS

        public Player()
        {
            _locationsVisited = new List<int>();
        }

        public Player(string name, CharacterType race, int locationId) : base(name, race, locationId)
        {
            _locationsVisited = new List<int>();
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
