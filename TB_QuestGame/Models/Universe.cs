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
        private List<NPC> _npcs;
        private Dictionary<int, Character.Rank> _ranks;
        private Dictionary<int, int> _levels;

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

        public List<NPC> NPCs
        {
            get { return _npcs; }
            set { _npcs = value; }
        }

        public Dictionary<int, Character.Rank> Rank
        {
            get { return _ranks; }
            set { _ranks = value; }
        }

        public Dictionary<int, int> Levels
        {
            get { return _levels; }
            set { _levels = value; }
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
            _npcs = UniverseObjects.NPCs;
            _ranks = new Dictionary<int, Character.Rank>()
            {
                { 1, Character.Rank.Viking },
                { 2, Character.Rank.Marauder },
                { 3, Character.Rank.Berserker},
                { 4, Character.Rank.Huskarl },
                { 5, Character.Rank.Radnigar },
                { 6, Character.Rank.Hersir },
                { 7, Character.Rank.Skald },
                { 8, Character.Rank.Freyr },
                { 9, Character.Rank.Jarl },
                { 10, Character.Rank.King }

            };

            _levels = new Dictionary<int, int>()
            {
                { 100, 1 },
                { 200, 2 },
                { 300, 3 },
                { 400, 4 },
                { 500, 5 },
                { 600, 6 },
                { 700, 7 },
                { 800, 8 },
                { 900, 9 },
                { 1000, 10 }
            };
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
        public bool IsAccessibleLocation(int locationId, Player gamePlayer)
        {
            Location location = GetLocationById(locationId);
            Location currentLocation = GetLocationById(gamePlayer.LocationId);

            if (currentLocation.AccessableLocations.Contains(locationId))
            {
                if (location.LevelNeeded > gamePlayer.CurrentLevel)
                {
                    return false;
                }
                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// Get the location by the location ID
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Returns bool for valid trade object
        /// </summary>
        /// <param name="tradeObjectId"></param>
        /// <param name="currentLocationId"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Determine if the object is a valid trade object by location
        /// </summary>
        /// <param name="tradeItemId"></param>
        /// <param name="locationId"></param>
        /// <returns></returns>
        public bool TestValidTradeItemByLocation(int tradeItemId, int locationId)
        {
            List<int> ids = new List<int>();
            Location currentLocation = GetLocationById(locationId);

            // checks each item in the list of trade objects in the current locatoion
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

        /// <summary>
        /// Return bool for valid place objects by location
        /// </summary>
        /// <param name="placeId"></param>
        /// <param name="currentLocationId"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Return bool for valid Npc by location
        /// </summary>
        /// <param name="npcId"></param>
        /// <param name="currentLocation"></param>
        /// <returns></returns>
        public bool IsValidNpcByLocationId(int npcId, int currentLocation)
        {
            List<int> npcIds = new List<int>();

            foreach (NPC npc in _npcs)
            {
                if (npc.LocationId == currentLocation)
                {
                    npcIds.Add(npc.Id);
                }
            }

            if (npcIds.Contains(npcId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Get the NPC object by their id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public NPC GetNpcById(int Id)
        {
            NPC npcToReturn = null;

            foreach (NPC npc in _npcs)
            {
                if (npc.Id == Id)
                {
                    npcToReturn = npc;
                }
            }

            if (npcToReturn == null)
            {
                string feedBackMessage = $"The NPC ID {Id} does not exist in the current universe.";
                throw new ArgumentException(feedBackMessage, Id.ToString());
            }

            return npcToReturn;
        }

        /// <summary>
        /// Get list of npcs by the location id
        /// </summary>
        /// <param name="locationId"></param>
        /// <returns></returns>
        public List<NPC> GetNpcByLocationId(int locationId)
        {
            List<NPC> npcs = new List<NPC>();

            foreach (NPC npc in _npcs)
            {
                if (npc.LocationId == locationId)
                {
                    npcs.Add(npc);
                }
            }

            return npcs;
        }

        /// <summary>
        /// Get the viking rank based on the current level
        /// </summary>
        /// <param name="currentLevel"></param>
        /// <returns></returns>
        public Character.Rank GetVikingRank(int currentLevel)
        {
            Character.Rank rank = Character.Rank.None;

            foreach (var item in _ranks)
            {
                if (item.Key == currentLevel)
                {
                    rank = item.Value;
                }
            }

            return rank;
        }

        /// <summary>
        /// Get level based on experience points
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public int GetLevel(Player player)
        {
            int level = player.CurrentLevel;

            // checks each item in the _levels dictionary
            foreach (var item in _levels)
            {
                if (item.Value == level)
                {
                    // if XP is higher than current level value's key, add new level
                    if (player.ExperiencePoints > item.Key)
                    {
                        level += 1;
                    }
                }
            }

            return level;
        }

        /// <summary>
        /// Get the battle points from the opponent
        /// </summary>
        /// <param name="opponentId"></param>
        /// <returns></returns>
        public int GetOpponentPoints(int opponentId)
        {
            int opponentPoints = 0;

            NPC npc = GetNpcById(opponentId);

            if (npc != null)
            {
                if (!npc.IsFriendly && npc is Enemy)
                {
                    Enemy opponent = npc as Enemy;
                    foreach (var rank in _ranks)
                    {
                        if (opponent.IsViking)
                        {
                            if (rank.Value == opponent.VikingRank)
                            {
                                opponentPoints += rank.Key * 100;
                            }
                        }
                        else
                        {
                            if (rank.Key == opponent.EnglishRank)
                            {
                                opponentPoints += opponent.EnglishRank * 100;
                            }
                        }

                    }
                    if (opponent.IsArmed)
                    {
                        GameObject weapon = GetGameObjectById(opponent.PrimaryWeapon);
                        GameObject shield = GetGameObjectById(opponent.PrimaryShield);
                        if (weapon != null && weapon is Weapon)
                        {
                            Weapon opponentWeapon = weapon as Weapon;
                            opponentPoints += opponentWeapon.DamagePoints;
                        }

                        if (shield != null && shield is Weapon)
                        {
                            Weapon opponentShield = shield as Weapon;
                            opponentPoints += opponentShield.DamagePoints;
                        }
                    }


                    opponentPoints += opponent.XP;
                }
            }

            return opponentPoints;
        }

        /// <summary>
        /// Get player battle points
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public int GetPlayerPoints(Player player)
        {
            int playerPoints = 0;

            foreach (var rank in _ranks)
            {
                if (rank.Value == player.VikingRank)
                {
                    playerPoints += rank.Key * 10;
                }
            }

            if (player.IsArmed)
            {
                Weapon weapon = player.PrimaryWeapon;
                Weapon shield = player.PrimaryShield;

                if (weapon != null)
                {
                    playerPoints += weapon.DamagePoints;
                }

                if (shield != null)
                {
                    playerPoints += shield.DamagePoints;
                }
            }

            playerPoints += player.ExperiencePoints;
            return playerPoints;
        }

            

                    
                
            

            
        

        #endregion
    }
}
