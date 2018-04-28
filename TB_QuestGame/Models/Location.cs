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
        #region Enumerables

        public enum RegionName
        {
            Norwegia,
            Shetland,
            England
        }

        #endregion
        #region Fields

        private string _locationName;
        private int _locationId;
        private string _description;
        private bool _accessable;
        private RegionName _region;
        private List<int> _acessableLocations;
        private int _experiencePoints;
        private List<int> _tradeObjects;
        private int _capitalNeeded;
        private int _levelNeeded;
        private Dictionary<RegionName, int> _regionDistance;

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

        public RegionName Region
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

        public List<int> TradeObjects
        {
            get { return _tradeObjects; }
            set { _tradeObjects = value; }
        }

        public int CapitalNeeded
        {
            get { return _capitalNeeded; }
            set { _capitalNeeded = value; }
        }

        public int LevelNeeded
        {
            get { return _levelNeeded; }
            set { _levelNeeded = value; }
        }

        public Dictionary<RegionName, int> RegionDistance
        {
            get { return _regionDistance; }
            set { _regionDistance = value; }
        }

        #endregion

        #region Constructors

        #endregion

        #region Methods

        #endregion
    }
}
