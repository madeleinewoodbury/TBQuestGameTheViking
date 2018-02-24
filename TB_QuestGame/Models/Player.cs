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
        private Weapon _weaponType;

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

        public Weapon WeaponType
        {
            get { return _weaponType; }
            set { _weaponType = value; }
        }


        #endregion

        #region CONSTRUCTORS

        public Player()
        {

        }

        public Player(string name, CharacterType race, string homeVillage, bool isFriendly) : base(name, race, isFriendly)
        {

        }

        #endregion
        
        #region METHODS
        

        #endregion
    }
}
