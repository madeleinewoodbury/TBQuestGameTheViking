using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// class for the map of the game
    /// </summary>
    public class Location
    {
        #region Fields

        private string _locationName;
        private int _locationId;
        private string _description;
        private bool _accessable;

        #endregion

        #region Properties

        public string LocationName
        {
            get { return _locationName; }
            set { _locationName = value; }
        }

        public int LocationId
        {
            get { return _locationId; }
            set { _locationId = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public bool Accessable
        {
            get { return _accessable; }
            set { _accessable = value; }
        }

        #endregion

        #region Constructors

        #endregion

        #region Methods

        #endregion
    }
}
