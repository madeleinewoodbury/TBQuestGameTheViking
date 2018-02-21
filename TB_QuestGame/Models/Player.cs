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

        #endregion

        #region PROPERTIES

        public VikingType Viking
        {
            get { return _viking; }
            set { _viking = value; }
        }

        #endregion

        #region CONSTRUCTORS

        public Player()
        {

        }

        public Player(string name, CharacterType race) : base(name, race)
        {

        }

        #endregion
        
        #region METHODS
        

        #endregion
    }
}
