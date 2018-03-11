using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    public class Universe
    {
        #region Fields

        private List<Location> _locations;

        #endregion

        #region Properties

        public List<Location> Locations
        {
            get { return _locations; }
            set { _locations = value; }
        }

        #endregion

        #region Constructors

        public Universe()
        {
            InitializeUniverse(); 
        }

        #endregion

        #region Methods

        /// <summary>
        /// initialize the universe with all of the locations
        /// </summary>
        private void InitializeUniverse()
        {
            _locations = UniverseObjects.Locations;
        }

        /// <summary>
        /// determines if the locationId is valid
        /// </summary>
        /// <param name="locationId"></param>
        /// <returns></returns>
        public bool IsValidLocationId(int locationId)
        {
            List<int> locationIds = new List<int>();

            //
            // create a list of location ids
            //
            foreach (Location id in _locations)
            {
                locationIds.Add(id.LocationId);
            }

            //
            // determine if the location id is valid and return the boolean value
            //
            if (locationIds.Contains(locationId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// return the next available ID for a lovation object
        /// </summary>
        /// <returns></returns>
        public int GetMaxLocationID()
        {
            int MaxId = 0;

            foreach (Location location in Locations)
            {
                if (location.LocationId > MaxId)
                {
                    MaxId = location.LocationId;
                }
            }

            return MaxId;
        }

        /// <summary>
        /// determines if locationId is accesible
        /// </summary>
        /// <param name="locationId"></param>
        /// <returns></returns>
        public bool IsAccessibleLocation(int locationId, int currentLocationId)
        {
            Location location = GetLocationById(locationId);
            Location currentLocation = GetLocationById(currentLocationId);

            if (currentLocation.AccessableLocations.Contains(locationId))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public Location GetLocationById(int Id)
        {
            Location requestedLocation = null;

            //
            // run through the space-time location list and grab the correct one
            //
            foreach (Location location in _locations)
            {
                if (location.LocationId == Id)
                {
                    requestedLocation = location;
                }
            }

            //
            // if the id is not found in the universe
            //

            if (requestedLocation == null)
            {
                string feedBackMessage = $"The Location Id {Id} does not exist in the current Universe.";
                throw new ArgumentException(Id.ToString(), feedBackMessage);
            }

            return requestedLocation;
        }
        #endregion
    }
}
