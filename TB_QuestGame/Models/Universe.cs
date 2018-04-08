using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace TB_QuestGame
{
    public class Universe
    {
        #region Fields

        private List<Location> _locations;
        private List<GameObject> _gameObjects;

        #endregion

        #region Properties

        public List<Location> Locations
        {
            get { return _locations; }
            set { _locations = value; }
        }

        public List<GameObject> GameObjects
        {
            get { return _gameObjects; }
            set { _gameObjects = value; }
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
            _gameObjects = UniverseObjects.GameObjetcs;
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


        /// <summary>
        /// validate game object id number in current location
        /// </summary>
        /// <param name="gameObjectId"></param>
        /// <returns>is Id valid</returns>
        public bool IsValidGameObjectByLocationId(int gameObjectId, int currentLocationId)
        {
            List<int> gameObjectIds = new List<int>();

            //
            // create a list of game object ids in current space-time location
            //
            foreach (GameObject gameObject in _gameObjects)
            {
                if (gameObject.LocationId == currentLocationId)
                {
                    gameObjectIds.Add(gameObject.Id);
                }

            }

            //
            // determine if the game object id is a valid id and return the result
            //
            if (gameObjectIds.Contains(gameObjectId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// get a game object using an Id
        /// </summary>
        /// <param name="Id">game object Id</param>
        /// <returns>requested game object</returns>
        public GameObject GetGameObjectById(int Id)
        {
            GameObject gameObjectToReturn = null;

            //
            // run through the game object list and grab the correct one
            //
            foreach (GameObject gameObject in _gameObjects)
            {
                if (gameObject.Id == Id)
                {
                    gameObjectToReturn = gameObject;
                }
            }

            //
            // the specified ID was not found in the universe
            // throw and exception
            //
            if (gameObjectToReturn == null)
            {
                string feedbackMessage = $"The Game Object ID {Id} does not exist in the current Universe.";
                throw new ArgumentException(feedbackMessage, Id.ToString());
            }

            return gameObjectToReturn;
        }

        /// <summary>
        /// get list of game objetc by location ID
        /// </summary>
        /// <param name="locationId"></param>
        /// <returns></returns>
        public List<GameObject> GetGameObjectsByLocationId(int locationId)
        {
            List<GameObject> gameObjects = new List<GameObject>();

            //
            // run through the game object list and grab all that are in the current space-time location
            //
            foreach (GameObject gameObject in _gameObjects)
            {
                if (gameObject.LocationId == locationId)
                {
                    gameObjects.Add(gameObject);
                }
            }

            return gameObjects;
        }

        public bool IsValidTradeObjectId(int tradeObjectId, int currentLocationId)
        {
            List<int> tradeObjectIds = new List<int>();
            Location currentLocation = GetLocationById(currentLocationId);

            //
            // create a list of game object ids in current location
            //
            foreach (int item in currentLocation.TradeObjects)
            {
                tradeObjectIds.Add(item);
            }

            //
            // determine if the game object id is a valid id and return the result
            //
            if (tradeObjectIds.Contains(tradeObjectId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool TestValidTradeItemByLocation(int tradeItemId, int locationId)
        {
            List<int> ids = new List<int>();
            Location currentLocation = GetLocationById(locationId);

            foreach (int item in currentLocation.TradeObjects)
            {
                ids.Add(item);
            }

            if (ids.Contains(tradeItemId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsValidPlaceByLocation(int placeId, int currentLocationId)
        {
            List<int> placeIds = new List<int>();

            //
            // create a list of game object ids in current space-time location
            //
            foreach (GameObject gameObject in _gameObjects)
            {
                if (gameObject is Place)
                {
                    if (gameObject.LocationId == currentLocationId)
                    {
                        placeIds.Add(gameObject.Id);
                    }
                }


            }

            //
            // determine if the game object id is a valid id and return the result
            //
            if (placeIds.Contains(placeId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion
    }
}
