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
        public int XP { get; set; }
        public bool IsArmed { get; set; }
        public bool CanTrade { get; set; }
        public List<int> TradeObjects { get; set; }

        #endregion

        #region Properties

        #endregion

        #region Constructors

        #endregion

        #region Methods

        #endregion


    }
}
