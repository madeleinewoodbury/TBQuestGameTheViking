using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    public abstract class NPC : Character
    {
        #region Fields
        public abstract int Id { get; set; }
        public abstract string Description { get; set; }
        private int _xp;

        #endregion

        #region Properties
        public int XP
        {
            get { return _xp; }
            set { _xp = value; }
        }

        #endregion

        #region Constructors

        #endregion

        #region Methods

        #endregion


    }
}
