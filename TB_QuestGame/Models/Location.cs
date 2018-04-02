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
        private string _region;
        private List<int> _acessableLocations;
        private int _experiencePoints;


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

        public string Region
        {
            get { return _region; }
            set { _region = value; }
        }

        public List<int> AccessableLocations
        {
            get { return _acessableLocations; }
            set { _acessableLocations = value; }
        }

        public int ExperiencePoints
        {
            get { return _experiencePoints; }
            set { _experiencePoints = value; }
        }

        #endregion

        #region Constructors

        #endregion

        #region Methods

        #endregion
    }
}
