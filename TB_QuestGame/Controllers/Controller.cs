using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace TB_QuestGame
{
    /// <summary>
    /// controller for the MVC pattern in the application
    /// </summary>
    public class Controller
    {
        #region FIELDS

        private ConsoleView _gameConsoleView;
        private Player _gamePlayer;
        private Universe _gameUniverse;
        private bool _playingGame;
        private Location _currentLocaton;
        private int _gameTick = 1;
        Timer timer = new Timer(1000);  

        #endregion

        #region PROPERTIES


        #endregion

        #region CONSTRUCTORS

        public Controller()
        {
            //
            // setup all of the objects in the game
            //
            InitializeGame();

            //
            // begins running the application UI
            //
            ManageGameLoop();
        }

        #endregion

        #region METHODS

        /// <summary>
        /// initialize the major game objects
        /// </summary>
        private void InitializeGame()
        {
            _gamePlayer = new Player();
            _gameUniverse = new Universe();
            _gameConsoleView = new ConsoleView(_gamePlayer, _gameUniverse);
            _playingGame = true;

            Console.CursorVisible = false;

            //
            // handle timer for the player's energt levels
            //
            timer.Elapsed += GameTickTimer_Elapsed;
        }

        /// <summary>
        /// method to manage the application setup and game loop
        /// </summary>
        private void ManageGameLoop()
        {
            //
            // game loop variables
            //
            PlayerAction playerActionChoice = PlayerAction.None;
            int objectId = 0;
            int npcId = 0;
            Dictionary<int, int> npcToTradeWith = new Dictionary<int, int>();

            //
            // display splash screen
            //
            _playingGame = _gameConsoleView.DisplaySpashScreen();

            //
            // player chooses to quit
            //
            if (!_playingGame)
            {
                Environment.Exit(1);
            }

            //
            // display introductory message
            //
            _gameConsoleView.DisplayGamePlayScreen("Quest Intro", Text.QuestIntro(), ActionMenu.QuestIntro, "");
            _gameConsoleView.GetContinueKey();

            //
            // initialize the mission traveler
            // 
            InitializeQuest();

            //
            // prepare game play screen
            //
            _currentLocaton = _gameUniverse.GetLocationById(_gamePlayer.LocationId);
            _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.LookAround(_currentLocaton), ActionMenu.MainMenu, "");

            //
            // update game stauts
            //
            timer.Start();

            //
            // game loop
            //
            while (_playingGame)
            {
                UpdateGameStatus();
                //
                // get the next action from the player
                //
                playerActionChoice = GetNextPlayerAction();

                //
                // choose an action based on the user's menu choice
                //
                switch (playerActionChoice)
                {
                    case PlayerAction.None:
                        break;

                    #region Edit Options
                    case PlayerAction.ChangeName:
                        _gamePlayer.Name = _gameConsoleView.DisplayEditName(_gamePlayer);
                        _gameConsoleView.DisplayGamePlayScreen("Edit Player Info", Text.PlayerInfo(_gamePlayer), ActionMenu.EditPlayer, "");
                        break;

                    case PlayerAction.ChangeGender:
                        _gamePlayer.Viking = _gameConsoleView.DisplayEditGender(_gamePlayer);
                        _gameConsoleView.DisplayGamePlayScreen("Edit Player Info", Text.PlayerInfo(_gamePlayer), ActionMenu.EditPlayer, "");
                        break;

                    case PlayerAction.ChangeAge:
                        _gamePlayer.Age = _gameConsoleView.DisplayEditAge(_gamePlayer);
                        _gameConsoleView.DisplayGamePlayScreen("Edit Player Info", Text.PlayerInfo(_gamePlayer), ActionMenu.EditPlayer, "");
                        break;

                    case PlayerAction.ChangeHomeVillage:
                        _gamePlayer.HomeVillage = _gameConsoleView.DisplayEditHomeVillage(_gamePlayer);
                        _gameConsoleView.DisplayGamePlayScreen("Edit Player Info", Text.PlayerInfo(_gamePlayer), ActionMenu.EditPlayer, "");
                        break;

                    case PlayerAction.PlayerEdit:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.EditPlayerMenu;
                        _gameConsoleView.DisplayGamePlayScreen("Edit Player Info", Text.PlayerInfo(_gamePlayer), ActionMenu.EditPlayer, "");
                        break;
                    #endregion

                    #region List Options
                    case PlayerAction.ListWeapons:
                        _gameConsoleView.DisplayListWeapons();
                        break;

                    case PlayerAction.ListTreasures:
                        _gameConsoleView.DisplayListTreasures();
                        break;

                    case PlayerAction.ListItems:
                        _gameConsoleView.DisplayListItems();
                        break;

                    case PlayerAction.ListPlaces:
                        _gameConsoleView.DisplayListPlaces();
                        break;

                    case PlayerAction.ListDestinations:
                        _gameConsoleView.DisplayListOfLocations();
                        break;

                    case PlayerAction.ListGameObjects:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.ListGameObjectsMenu;
                        _gameConsoleView.DisplayListGameObjects();
                        break;

                    case PlayerAction.ListNonPlayerCharacters:
                        _gameConsoleView.DisplayListAllNpcObjects();
                        break;

                    case PlayerAction.LocationsVisited:
                        _gameConsoleView.DisplayLocationsVisited();
                        break;
                    #endregion

                    #region Object Options (LookAt, Trade/Sell, NPC)
                    case PlayerAction.NpcMenu:
                        _gameConsoleView.DisplayGamePlayScreen("NPC Menu", "Select an operation from the menu", ActionMenu.NpcMenu, "");
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.NpcMenu;
                        break;

                    case PlayerAction.Buy:
                        if (ActionMenu.currentMenu == ActionMenu.CurrentMenu.ShopMenu)
                            BuyAction();    
                        else
                            BuyNPCItem(npcToTradeWith);     
                        break;

                    case PlayerAction.Consume:
                        if (ActionMenu.currentMenu == ActionMenu.CurrentMenu.ItemMenu)
                            ConsumeItem();
                        else
                            ConsumeInventoryItem();              
                        break;

                    case PlayerAction.ChooseWeapon:
                        ChooseWeaponAction();
                        break;

                    case PlayerAction.ChooseShield:
                        ChooseShieldAction();
                        break;

                    case PlayerAction.EnterPlace:
                        EnterAction();
                        break;

                    case PlayerAction.ItemMenu:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.ItemMenu;
                        _gameConsoleView.DisplayGamePlayScreen("Look Around", "Select an option from the Item Menu", ActionMenu.ItemMenu, "");
                        break;

                    case PlayerAction.LookAt:
                        if (ActionMenu.currentMenu == ActionMenu.CurrentMenu.InventoryMenu)
                        {
                            _gameConsoleView.DisplayInventory();
                            InventoryLookAtAction();
                        }
                        else
                        {
                            ActionMenu.currentMenu = ActionMenu.CurrentMenu.ItemMenu;
                            objectId = LookAtAction();
                        }
                        break;

                    case PlayerAction.PickUpItem:
                        PickUpAction();
                        break;

                    case PlayerAction.PutDownItem:
                        PutDownAction();
                        break;

                    case PlayerAction.Sell:
                        SellAction();
                        break;

                    case PlayerAction.Trade:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.TradeMenu;
                        npcToTradeWith = TradeWithNpc();
                        break;

                    case PlayerAction.Shop:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.ShopMenu;
                        _gameConsoleView.DisplayShop(_currentLocaton);
                        break;

                    case PlayerAction.TalkTo:
                        npcId = TalkToAction();
                        break;

                    case PlayerAction.Fight:
                        BattleAction(npcId);
                        break;

                    case PlayerAction.RunAway:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.MainMenu;
                        _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.LookAround(_currentLocaton), ActionMenu.MainMenu, "");
                        break;

                    case PlayerAction.TradeInventoryItem:
                        TradeInventoryItemAction(npcToTradeWith);
                        break;
                    #endregion

                    #region Main Menu Options
                    case PlayerAction.PlayerInfo:
                        _gameConsoleView.DisplayPlayerInfo();
                        break;

                    case PlayerAction.AdminMenu:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.AdminMenu;
                        _gameConsoleView.DisplayGamePlayScreen("Admin Menu", "Select an operation from the menu.", ActionMenu.AdminMenu, "");
                        break;

                    case PlayerAction.LookAround:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.LookAround;
                        _gameConsoleView.DisplayLookAround();
                        break;

                    case PlayerAction.Inventory:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.InventoryMenu;
                        _gameConsoleView.DisplayInventory();
                        break;

                    case PlayerAction.Travel:
                        TravelAction();
                        break;
                    #endregion

                    #region Exit/Go Back / ReturnToMainMenu
                    case PlayerAction.ReturnToMainMenu:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.MainMenu;
                        _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.LookAround(_currentLocaton), ActionMenu.MainMenu, "");
                        break;

                    // go back: change menu based on current menu 
                    case PlayerAction.GoBack:
                        if (ActionMenu.currentMenu == ActionMenu.CurrentMenu.EditPlayerMenu)
                        {
                            ActionMenu.currentMenu = ActionMenu.CurrentMenu.AdminMenu;
                            _gameConsoleView.DisplayGamePlayScreen("Admin Menu", "Select an operation from the menu.", ActionMenu.AdminMenu, "");
                        }
                        else if (ActionMenu.currentMenu == ActionMenu.CurrentMenu.ShopMenu)
                        {
                            ActionMenu.currentMenu = ActionMenu.CurrentMenu.LookAround;
                            _gameConsoleView.DisplayLookAround();
                        }
                        else if (ActionMenu.currentMenu == ActionMenu.CurrentMenu.ListGameObjectsMenu)
                        {
                            ActionMenu.currentMenu = ActionMenu.CurrentMenu.AdminMenu;
                            _gameConsoleView.DisplayGamePlayScreen("Admin Menu", "Select an operation from the menu.", ActionMenu.AdminMenu, "");
                        }
                        else if (ActionMenu.currentMenu == ActionMenu.CurrentMenu.ItemMenu)
                        {
                            ActionMenu.currentMenu = ActionMenu.CurrentMenu.LookAround;
                            _gameConsoleView.DisplayLookAround();
                        }
                        else if (ActionMenu.currentMenu == ActionMenu.CurrentMenu.NpcMenu)
                        {
                            ActionMenu.currentMenu = ActionMenu.CurrentMenu.LookAround;
                            _gameConsoleView.DisplayLookAround();
                        }
                        else if (ActionMenu.currentMenu == ActionMenu.CurrentMenu.TradeMenu)
                        {
                            ActionMenu.currentMenu = ActionMenu.CurrentMenu.NpcMenu;
                            _gameConsoleView.DisplayGamePlayScreen("NPC Menu", "Select an operation from the menu", ActionMenu.NpcMenu, "");
                        }
                        break;

                    case PlayerAction.Exit:
                        _gameConsoleView.DisplayClosingScreen(_gamePlayer);
                        _playingGame = false;
                        break;
                    #endregion

                    default:
                        break;
                }
            }

            //
            // close the application
            //
            Environment.Exit(1);
        }

        /// <summary>
        /// Initialize the player info
        /// </summary>
        private void InitializeQuest()
        {
            Player player = _gameConsoleView.GetInitialPlayerInfo();

            //
            // player initial setup
            //
            _gamePlayer.Name = player.Name;
            _gamePlayer.Age = player.Age;
            _gamePlayer.Viking = player.Viking;
            _gamePlayer.LocationId = 1;
            _gamePlayer.HomeVillage = player.HomeVillage;
            _gamePlayer.Capital = player.Capital;
            _gamePlayer.IsArmed = false;
            _gamePlayer.IsShielded = false;
            _gamePlayer.VikingRank = Character.Rank.Viking;
            _gamePlayer.PrimaryWeapon = null;
            _gamePlayer.InventoryWeight = 0;

            //
            // game stats initial setup
            //
            _gamePlayer.ExperiencePoints = 0;
            _gamePlayer.Health = 100;
            _gamePlayer.Lives = 3;
            _gamePlayer.Energy = 100;
            _gamePlayer.CurrentLevel = 1;

        }

        private void UpdateGameStatus()
        {
            //
            // if player visits location for the first time add to visited locations list
            //
            if (!_gamePlayer.HasVisited(_currentLocaton.LocationId))
            {
                // add new location to the list of visited locations
                _gamePlayer.LocationsVisted.Add(_currentLocaton.LocationId);

                // update experience points and health for visiting locations
                _gamePlayer.ExperiencePoints += _currentLocaton.ExperiencePoints;

            }

            // update if the player is armed with a weapon
            if (_gamePlayer.PrimaryWeapon != null)
                _gamePlayer.IsArmed = true;
            
            // update if the player is armed with a shield
            if (_gamePlayer.PrimaryShield != null)
                _gamePlayer.IsShielded = true;
            
               
            // update health, 
            // subtract a life if health is down to 0
            if (_gamePlayer.Health <= 0)
            {
                _gamePlayer.Lives -= 1;
                _gamePlayer.Energy = 100;
            }

            // add life is health is more than 100
            if (_gamePlayer.Health > 100)
            {
                _gamePlayer.Lives += 1;
                _gamePlayer.Health = 100;
            }

            if (_gamePlayer.Lives == 0)
            {
                _gameConsoleView.DisplayContinueMessage("No more lives! Press any key to continue");
                Console.ReadKey();
                _playingGame = _gameConsoleView.DisplayGameOverScreen();
            }

            // update level
            // level icreases for every 100 experience points
            int level = _gamePlayer.CurrentLevel;
            if (_gamePlayer.ExperiencePoints > 100)
            {
                _gamePlayer.CurrentLevel = _gameUniverse.GetLevel(_gamePlayer);
                _gamePlayer.VikingRank = _gameUniverse.GetVikingRank(_gamePlayer.CurrentLevel);
            }
    
            // display message if a new level is reached
            if (level < _gamePlayer.CurrentLevel && _gamePlayer.ExperiencePoints >= 100)
            {   
                ActionMenu.currentMenu = ActionMenu.CurrentMenu.MainMenu;
                _gameConsoleView.DisplayNewLevelMessage();
            }

        }

        /// <summary>
        /// Method that returns the next playeraction coice depending on which menu is the current one
        /// </summary>
        /// <returns></returns>
        private PlayerAction GetNextPlayerAction()
        {
            PlayerAction playerActionChocie = PlayerAction.None;

            switch (ActionMenu.currentMenu)
            {
                case ActionMenu.CurrentMenu.MainMenu:
                    playerActionChocie = _gameConsoleView.GetActionMenuChoice(ActionMenu.MainMenu);
                    break;
                case ActionMenu.CurrentMenu.LookAround:
                    playerActionChocie = _gameConsoleView.GetActionMenuChoice(ActionMenu.LookAround);
                    break;
                case ActionMenu.CurrentMenu.ListGameObjectsMenu:
                    playerActionChocie = _gameConsoleView.GetActionMenuChoice(ActionMenu.ListGameObjectsMenu);
                    break;
                case ActionMenu.CurrentMenu.AdminMenu:
                    playerActionChocie = _gameConsoleView.GetActionMenuChoice(ActionMenu.AdminMenu);
                    break;
                case ActionMenu.CurrentMenu.ShopMenu:
                    playerActionChocie = _gameConsoleView.GetActionMenuChoice(ActionMenu.ShopMenu);
                    break;
                case ActionMenu.CurrentMenu.EditPlayerMenu:
                    playerActionChocie = _gameConsoleView.GetActionMenuChoice(ActionMenu.EditPlayer);
                    break;
                case ActionMenu.CurrentMenu.InventoryMenu:
                    playerActionChocie = _gameConsoleView.GetActionMenuChoice(ActionMenu.InventoryMenu);
                    break;
                case ActionMenu.CurrentMenu.ItemMenu:
                    playerActionChocie = _gameConsoleView.GetActionMenuChoice(ActionMenu.ItemMenu);
                    break;
                case ActionMenu.CurrentMenu.NpcMenu:
                    playerActionChocie = _gameConsoleView.GetActionMenuChoice(ActionMenu.NpcMenu);
                    break;
                case ActionMenu.CurrentMenu.BattleMenu:
                    playerActionChocie = _gameConsoleView.GetActionMenuChoice(ActionMenu.BattleMenu);
                    break;
                case ActionMenu.CurrentMenu.TradeMenu:
                    playerActionChocie = _gameConsoleView.GetActionMenuChoice(ActionMenu.TradeMenu);
                    break;
                default:
                    break;
            }

            return playerActionChocie;
        }

        /// <summary>
        /// Process travel action
        /// </summary>
        private void TravelAction()
        {
            // set the variable for the region traveled from
            Location.RegionName regionTraveledFrom = _currentLocaton.Region;

            // get new locationId and update the curentLocation
            _gamePlayer.LocationId = _gameConsoleView.DisplayGetLocation();
            _currentLocaton = _gameUniverse.GetLocationById(_gamePlayer.LocationId);

            // subtract the energy from the travel based on the distance traveled
            foreach (var region in _currentLocaton.RegionDistance)
            {
                if (region.Key == regionTraveledFrom)
                {
                    _gamePlayer.Energy -= region.Value;
                }
            }

            // set the game play screen to current location info
            _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.LookAround(_currentLocaton), ActionMenu.MainMenu, "");
        }

        /// <summary>
        /// Display list of places in current locations and prompt the user for the place id and
        /// display enter place action
        /// </summary>
        private void EnterAction()
        {
            //
            // display list of places in current location
            //
            int placeId = _gameConsoleView.DisplayGetPlaceToEnter();

            if (placeId != 0)
            {
                //
                // get the game object from the universe
                //
                GameObject gameObject = _gameUniverse.GetGameObjectById(placeId);
                Place placeToEnter = gameObject as Place;

                //
                // update game stats based on place entered
                //
                _gamePlayer.ExperiencePoints += placeToEnter.ExperiencePoints;
                _gamePlayer.Health += placeToEnter.Health;
                if (placeToEnter.CanRest)
                {
                    _gamePlayer.Energy = 100;
                }

                _gameConsoleView.DisplayConfirmPlaceEntered(placeToEnter);
            }
            else
            {
                _gameConsoleView.DisplayLookAround();
            }


        }

        /// <summary>
        /// Look at object in player's inventory
        /// </summary>
        private void InventoryLookAtAction()
        {
            //
            // get object id to look at
            //
            int objectId = _gameConsoleView.DisplayGetInventoryObjectToLookAt();

            //
            // display game object info
            //
            if (objectId != 0)
            {
                //
                // get the game object from the universe
                //
                GameObject gameObject = _gameUniverse.GetGameObjectById(objectId);

                //
                // display information for the object chosen 
                //
                _gameConsoleView.DisplayInventoryObjectInfo(gameObject);
            }
            
        }

        /// <summary>
        /// process the Look At object in location action
        /// </summary>
        private int LookAtAction()
        {
            //
            // display a list of game objects in current location and get a player choice
            //
            int gameObjectToLookAtId = _gameConsoleView.DisplayGetGameObjectToLookAt();

            //
            // display game object info
            //
            if (gameObjectToLookAtId != 0)
            {
                //
                // get the game object from the universe
                //
                GameObject gameObject = _gameUniverse.GetGameObjectById(gameObjectToLookAtId);

                //
                // display information for the object chosen
                //
                _gameConsoleView.DisplayGameObjectInfo(gameObject);  
            }
            else
            {
                ActionMenu.currentMenu = ActionMenu.CurrentMenu.LookAround;
                _gameConsoleView.DisplayLookAround();
            }

            return gameObjectToLookAtId;
        }

        /// <summary>
        /// process sell object action
        /// </summary>
        private void SellAction()
        {
            //
            // display a list of game objects in inventory
            //
            int tradeObjectToSell = _gameConsoleView.DisplayGetTradeObjectToSell();

            if (tradeObjectToSell != 0)
            {
                //
                // get the game object from the universe
                //
                GameObject tradeObject = _gameUniverse.GetGameObjectById(tradeObjectToSell) as GameObject;


                //
                // update the capital and remove object from inventory
                //
                _gamePlayer.Capital += tradeObject.Value;
                _gamePlayer.Inventory.Remove(tradeObject);
                _gamePlayer.InventoryWeight -= tradeObject.Weight;
                if (tradeObject is Weapon)
                {
                    Weapon weapon = tradeObject as Weapon;
                    string weaponType = "";
                    if (!weapon.Shield && _gamePlayer.PrimaryWeapon == weapon)
                    {
                        //
                        // primary weapon put down
                        //
                        _gamePlayer.IsArmed = false;
                        _gamePlayer.PrimaryWeapon = null;
                        weaponType = "weapon";
                        _gameConsoleView.DisplayWeaponSold(weapon, weaponType);
                    }
                    else if (_gamePlayer.PrimaryShield == weapon)
                    {
                        //
                        // primary shield put down
                        //
                        _gamePlayer.IsShielded = false;
                        _gamePlayer.PrimaryShield = null;
                        weaponType = "shield";
                        _gameConsoleView.DisplayWeaponSold(weapon, weaponType);
                    }
                    else
                    {
                        //
                        // confirm sale of object
                        //
                        _gameConsoleView.DisplayConfirmSale(tradeObject);
                    }

                }
                else
                {
                    //
                    // confirm sale of object
                    //
                    _gameConsoleView.DisplayConfirmSale(tradeObject);
                }
            }
            else
            {
                _gameConsoleView.DisplayShop(_currentLocaton);
            }

        }

        /// <summary>
        /// process buy action
        /// </summary>
        private void BuyAction()
        {
            //
            // display a list of trade objects in location and get a player choice
            //
            int tradeObjectIdToBuy = _gameConsoleView.DisplayGetTradeItemToPurchase(_currentLocaton);

            //
            // add the object to player's inventory
            //
            if (tradeObjectIdToBuy != 0)
            {
                //
                // get the game object from the universe
                //
                GameObject tradeObject = _gameUniverse.GetGameObjectById(tradeObjectIdToBuy) as GameObject;
                if (!_gamePlayer.MaxWeight(tradeObject.Weight))
                {
                    //
                    // update the capital and add to inventory
                    //
                    _gamePlayer.Capital -= tradeObject.Value;
                    _gamePlayer.Inventory.Add(tradeObject);
                    _gamePlayer.InventoryWeight += tradeObject.Weight;
                    tradeObject.LocationId = 0;

                    //
                    // if the player is unarmed and the object is a weapon, the game object will become primary shield or weapon
                    //
                    if (tradeObject is Weapon)
                    {
                        Weapon weapon = tradeObject as Weapon;
                        string weaponType = "";
                        if (!weapon.Shield && !_gamePlayer.IsArmed)
                        {
                            //
                            // add primary weapon
                            //
                            _gamePlayer.PrimaryWeapon = weapon;
                            _gamePlayer.IsArmed = true;
                            weaponType = "weapon";
                            _gameConsoleView.DisplayWeaponAddedToInventory(weapon, weaponType);
                        }
                        else if (weapon.Shield && !_gamePlayer.IsShielded)
                        {
                            //
                            // add primary shield
                            //
                            _gamePlayer.PrimaryShield = weapon;
                            _gamePlayer.IsShielded = true;
                            weaponType = "shield";
                            _gameConsoleView.DisplayWeaponAddedToInventory(weapon, weaponType);
                        }
                        else
                        {
                            //
                            // confirm object added to inventory
                            //
                            _gameConsoleView.DisplayConfirmPurchase(tradeObject);
                        }
                    }
                    else
                    {
                        //
                        // confirm object added to inventory
                        //
                        _gameConsoleView.DisplayConfirmPurchase(tradeObject);
                    }
                    
                }
                else
                {
                    //
                    // if the game object will exceed the capacity weight of the inventory the object can't be added
                    //
                    _gameConsoleView.DisplayObjectTooHeavyForInventory(tradeObject);
                }   
            }
            else
            {
                _gameConsoleView.DisplayShop(_currentLocaton);
            }

        }

        /// <summary>
        /// process pick up action
        /// </summary>
        private void PickUpAction()
        {
            //
            // display a list of game objects in location and get a player choice
            //
            int gameObjectToPickUpId = _gameConsoleView.DisplayGetGameObjectToPickUp();

            //
            // add the object to player's inventory
            //
            if (gameObjectToPickUpId != 0)
            {
                //
                // get the game object from the universe
                //
                GameObject gameObject = _gameUniverse.GetGameObjectById(gameObjectToPickUpId) as GameObject;

                if (!_gamePlayer.MaxWeight(gameObject.Weight))
                {
                    //
                    // object's location id is set to 0
                    //
                    _gamePlayer.Inventory.Add(gameObject);
                    _gamePlayer.InventoryWeight += gameObject.Weight;
                    gameObject.LocationId = 0;

                    //
                    // if the player is unarmed and the object is a weapon, the gameObject will become primary shield or weapon
                    //
                    if (gameObject is Weapon)
                    {
                        Weapon weapon = gameObject as Weapon;
                        string weaponType = "";
                        if (!weapon.Shield && !_gamePlayer.IsArmed)
                        {
                            //
                            // set primary weapon
                            //
                            _gamePlayer.PrimaryWeapon = weapon;
                            _gamePlayer.IsArmed = true;
                            weaponType = "weapon";
                            _gameConsoleView.DisplayWeaponAddedToInventory(weapon, weaponType);
                        }
                        else if (weapon.Shield && !_gamePlayer.IsShielded)
                        {
                            //
                            // set primary shield
                            //
                            _gamePlayer.PrimaryShield = weapon;
                            _gamePlayer.IsShielded = true;
                            weaponType = "shield";
                            _gameConsoleView.DisplayWeaponAddedToInventory(weapon, weaponType);
                        }
                    }
                    else
                    {
                        //
                        // display confirmation message
                        //
                        _gameConsoleView.DisplayConfirmGameObjectAddedToInventory(gameObject);
                    }
                }
                else
                {
                    //
                    // if object's weigh will exceed the inventory object the object can't be picked up
                    //
                    _gameConsoleView.DisplayPickUpObjectTooHeavy(gameObject);
                }

            }
            else
            {
                ActionMenu.currentMenu = ActionMenu.CurrentMenu.LookAround; 
                _gameConsoleView.DisplayLookAround();
            }
        }

        /// <summary>
        /// process put down action
        /// </summary>
        private void PutDownAction()
        {
            //
            // display a list of game objects in inventory and get player's choice
            //
            int objectToPutDown = _gameConsoleView.DisplayGetGameObjectToPutDown();

            if (objectToPutDown != 0)
            {
                //
                // get the game object from the universe
                //
                GameObject gameObject = _gameUniverse.GetGameObjectById(objectToPutDown) as GameObject;

                //
                // remove the object from the inventory and set the location to the current location
                //
                _gamePlayer.Inventory.Remove(gameObject);
                _gamePlayer.InventoryWeight -= gameObject.Weight;
                gameObject.LocationId = _gamePlayer.LocationId;

                //
                // if player puts down a primary weapon or shield, they will be unarmed or unshielded
                //
                if (gameObject is Weapon)
                {
                    Weapon weapon = gameObject as Weapon;
                    string weaponType = "";
                    if (!weapon.Shield && _gamePlayer.PrimaryWeapon == weapon)
                    {
                        //
                        // primary weapon put down
                        //
                        _gamePlayer.IsArmed = false;
                        _gamePlayer.PrimaryWeapon = null;
                        weaponType = "weapon";
                        _gameConsoleView.DisplayWeaponPutDown(weapon, weaponType);
                    }
                    else if (_gamePlayer.PrimaryShield == weapon)
                    {
                        //
                        // primary shield put down
                        //
                        _gamePlayer.IsShielded = false;
                        _gamePlayer.PrimaryShield = null;
                        weaponType = "shield";
                        _gameConsoleView.DisplayWeaponPutDown(weapon, weaponType);
                    }
                    else
                    {
                        //
                        // display confirmation message
                        //
                        _gameConsoleView.DisplayConfirmItemRemovedFromInventory(gameObject);
                    }

                }
                else
                {
                    //
                    // display confirmation message
                    //
                    _gameConsoleView.DisplayConfirmItemRemovedFromInventory(gameObject);
                }

            }

        }

        /// <summary>
        /// process consume inventory item action
        /// </summary>
        private void ConsumeInventoryItem()
        {
            //
            // display a list of game objects in inventory and get player's choice
            //
            int objectToConsume = _gameConsoleView.DisplayGetInventoryItemToConsume();

            if (objectToConsume != 0)
            {
                //
                // get the game object from the universe
                //
                GameObject gameObject = _gameUniverse.GetGameObjectById(objectToConsume) as GameObject;

                if (gameObject is Item)
                {
                    //
                    // determine if the item can be consumed
                    //
                    Item item = gameObject as Item;
                    if (item.IsConsumable)
                    {
                        //
                        // add item's values to the player's game stats
                        //
                        _gamePlayer.Inventory.Remove(item);
                        _gamePlayer.InventoryWeight -= gameObject.Weight;
                        _gamePlayer.Health += item.Health;

                        _gameConsoleView.DisplayConsumeItem(item);
                    }
                    else
                    {
                        _gameConsoleView.DisplayInventoryItemCannotBeConsumed(gameObject);
                    }
                }
                else
                {
                    _gameConsoleView.DisplayInventoryItemCannotBeConsumed(gameObject);
                }

            }
            else
            {
                _gameConsoleView.DisplayInventory();
            }
        }

        /// <summary>
        /// process consume item action in item menu
        /// </summary>
        private void ConsumeItem()
        {
            //
            // display a list of game objects in inventory and get player's choice
            //
            int objectToConsume = _gameConsoleView.DisplayGetItemToConsume();

            if (objectToConsume != 0)
            {
                //
                // get the game object from the universe
                //
                GameObject gameObject = _gameUniverse.GetGameObjectById(objectToConsume) as GameObject;

                if (gameObject is Item)
                {
                    //
                    // determine if item can be consumed
                    //
                    Item item = gameObject as Item;
                    if (item.IsConsumable)
                    {
                        item.LocationId = 0;
                        _gamePlayer.Health += item.Health;
                        _gameConsoleView.DisplayConsumeItem(item);
                    }
                }
            }
        }

        /// <summary>
        /// process choose primary weapon action
        /// </summary>
        private void ChooseWeaponAction()
        {
            //
            // display a list of game objects in inventory and get player's choice
            //
            int weaponId = _gameConsoleView.DisplayGetWeapon();

            if (weaponId != 0)
            {
                //
                // get the game object from the universe
                //
                GameObject gameObject = _gameUniverse.GetGameObjectById(weaponId) as GameObject;

                if (gameObject is Weapon)
                {
                    Weapon weapon = gameObject as Weapon;
                    bool isWeapon = false;
                    if (!weapon.Shield)
                    {
                        // set primary weapond
                        isWeapon = true;
                        _gamePlayer.PrimaryWeapon = weapon; 
                    }

                    _gameConsoleView.DisplaySetPrimaryWeapon(weapon, isWeapon);
                }
                else
                {
                    //
                    // display if item is not weapon
                    //
                    _gameConsoleView.DisplayItemIsNotWeapon(gameObject);
                }

            }
            else
            {
                _gameConsoleView.DisplayInventory();
            }
        }

        /// <summary>
        /// process choose primary shield action
        /// </summary>
        private void ChooseShieldAction()
        {
            //
            // display a list of game objects in inventory and get player's choice
            //
            int shieldId = _gameConsoleView.DisplayGetWeapon();

            if (shieldId != 0)
            {
                //
                // get the game object from the universe
                //
                GameObject gameObject = _gameUniverse.GetGameObjectById(shieldId) as GameObject;

                if (gameObject is Weapon)
                {
                    Weapon shield = gameObject as Weapon;
                    bool isShield = false;
                    if (shield.Shield)
                    {
                        _gamePlayer.PrimaryShield = shield;
                        isShield = true;
                    }
                    _gameConsoleView.DisplaySetPrimaryShield(shield, isShield);
                }
                else
                {
                    //
                    // display if not a shield
                    //
                    _gameConsoleView.DisplayGamePlayScreen("Current Inventory", $"{gameObject.Name} is not a shield.", ActionMenu.InventoryMenu, "");
                }

            }
            else
            {
                _gameConsoleView.DisplayInventory();
            }
        }

        /// <summary>
        /// process talk to action
        /// </summary>
        /// <returns></returns>
        private int TalkToAction()
        {
            // get id of npc to talk to
            int npcId = _gameConsoleView.DisplayGetNpcToTalkTo();
            int opponentId = 0;

            // display npc message
            if (npcId != 0)
            {
                NPC npc = _gameUniverse.GetNpcById(npcId);
                if (npc.IsFriendly)
                {
                    _gameConsoleView.DisplayTalkTo(npc);
                    if (!_gamePlayer.HasTalkedTo(npcId))
                    {
                        // add npc to list of npcs talked to
                        _gamePlayer.TalkedToNPCs.Add(npcId);
                        _gamePlayer.ExperiencePoints += npc.XP;
                        _gamePlayer.Health += npc.Health;
                    }

                }
                else
                {
                    //
                    // if npc is not friendly change to battle menu
                    //
                    ActionMenu.currentMenu = ActionMenu.CurrentMenu.BattleMenu;
                    _gameConsoleView.DisplayTalkToOpponent(npc);
                    opponentId = npcId;
                }


            }
            else
            {
                _gameConsoleView.DisplayGamePlayScreen("NPC Menu", "Select an operation from the menu", ActionMenu.NpcMenu, "");
                ActionMenu.currentMenu = ActionMenu.CurrentMenu.NpcMenu;
            }

            return opponentId;
        }

        /// <summary>
        /// process battle action
        /// </summary>
        /// <param name="npcId"></param>
        private void BattleAction(int npcId)
        {
            NPC npc = _gameUniverse.GetNpcById(npcId);

            //
            // get the player and the opponents points to determine battle outcome
            //
            int opponentPoints = _gameUniverse.GetOpponentPoints(npcId);
            int playerPoints = _gameUniverse.GetPlayerPoints(_gamePlayer);
            bool victory = false;

            //
            // determine battle outcome: player wins if more points than opponent
            //
            if (playerPoints > opponentPoints)
            {
                if (_gamePlayer.IsArmed)
                    victory = true;
                else if (!_gamePlayer.IsArmed && !npc.IsArmed)
                    victory = true;
                else
                    victory = false;
            }
            else
                victory = false;

            if (victory)
            {
                //
                // the player wins
                // update game stats: increase XP and decrease health
                //
                _gamePlayer.ExperiencePoints += npc.XP;
                _gamePlayer.Health -= 20;

                ActionMenu.currentMenu = ActionMenu.CurrentMenu.LookAround;
                _gameConsoleView.DisplayBattleVictory(npc, playerPoints, opponentPoints);
                npc.LocationId = 0;
            }
            else
            {
                //
                // player is defeated and looses a life
                //
                _gamePlayer.Lives -= 1;
                ActionMenu.currentMenu = ActionMenu.CurrentMenu.MainMenu;
                _gameConsoleView.DisplayBattleDefeat(npc, playerPoints, opponentPoints);
            }

        }

        /// <summary>
        /// process trade with NPC action
        /// </summary>
        /// <returns></returns>
        private Dictionary<int, int> TradeWithNpc()
        {
            //
            // dictionary of npc to return with npcid and npc object
            //
            Dictionary<int, int> npcToReturn = new Dictionary<int, int>();
            int npcId = _gameConsoleView.DisplayGetNpcToTradeWith();
            int npcTradeObject = 0;

            if (npcId != 0)
            {
                //
                // get npc from the universe
                //
                NPC npc = _gameUniverse.GetNpcById(npcId);

                //
                // if npc has objects to trade
                //
                if (npc.TradeObjects.Count > 0)
                {
                    //
                    // get npc object to trade from the user
                    //
                    npcTradeObject= _gameConsoleView.DisplayChooseNpcItemToTrade(npc);
                    GameObject tradeItem = _gameUniverse.GetGameObjectById(npcTradeObject);
                    if (tradeItem != null)
                    {
                        _gameConsoleView.DisplayGetNPCObjectToTrade(tradeItem);
                    }
                    else
                    {
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.NpcMenu;
                        _gameConsoleView.DisplayGamePlayScreen("NPC Menu", "Select an operation from the menu", ActionMenu.NpcMenu, "");
                    }
                    
                }
            }
            else
            {
                ActionMenu.currentMenu = ActionMenu.CurrentMenu.NpcMenu;
                _gameConsoleView.DisplayGamePlayScreen("NPC Menu", "Select an operation from the menu", ActionMenu.NpcMenu, "");
            }

            // add npc id and object id to dictionary
            npcToReturn.Add(npcId, npcTradeObject);

            return npcToReturn;
        }

        /// <summary>
        /// process trade inevntory item action
        /// </summary>
        /// <param name="npcToTradeWith"></param>
        private void TradeInventoryItemAction(Dictionary<int, int> npcToTradeWith)
        {
            //
            // dictionary contains npc id to trade with and object id to trade for
            //
            foreach (var item in npcToTradeWith)
            {
                int npcId = item.Key;
                int npcItemToTrade = item.Value;

                //
                // get item from player's inventory to trade
                //
                int inventoryItemToTade = _gameConsoleView.DisplayGetInventoryItemToTrade();

                if (inventoryItemToTade != 0)
                {
                    //
                    // get player object from the universe
                    //
                    GameObject inventoryObject = _gameUniverse.GetGameObjectById(inventoryItemToTade) as GameObject;

                    if (npcItemToTrade != 0)
                    {
                        //
                        // get npc object and npc from the universe
                        //
                        GameObject npcObject = _gameUniverse.GetGameObjectById(npcItemToTrade) as GameObject;
                        NPC npc = _gameUniverse.GetNpcById(npcId) as NPC;
                        if (inventoryObject != null && npcObject != null)
                        {
                            //
                            // determine if the object will exceed the inventory's max weight if traded 
                            //
                            if (!_gamePlayer.MaxWeight(npcObject.Weight - inventoryObject.Weight))
                            {
                                //
                                // detrmine that the inventory value is enough
                                //
                                if (inventoryObject.Value >= npcObject.Value)
                                {
                                    //
                                    // remover inventory object and add npc object to inventory
                                    //
                                    _gamePlayer.Inventory.Remove(inventoryObject);
                                    _gamePlayer.InventoryWeight -= inventoryObject.Weight;
                                    _gamePlayer.Inventory.Add(npcObject);
                                    _gamePlayer.InventoryWeight += npcObject.Weight;

                                    //
                                    // remover npc object from npc's trade objects and add player object
                                    //
                                    npc.TradeObjects.Remove(npcItemToTrade);
                                    npc.TradeObjects.Add(inventoryObject.Id);

                                    ActionMenu.currentMenu = ActionMenu.CurrentMenu.NpcMenu;
                                    _gameConsoleView.DisplayConfirmTradeWithNPC(inventoryObject, npcObject);
                                }
                                else
                                {
                                    //
                                    // display if player's inventory object's value is not enougg
                                    //
                                    _gameConsoleView.DisplayInventroyObjectValueNotEnough(inventoryObject, npcObject);
                                }
                            }
                            else
                            {
                                //
                                // display if weight will exceed inventory's max capacity
                                //
                                _gameConsoleView.DisplayTradeWillExceedInventoryMaxWeight(npcObject);
                            }


                        }

                    }
                    else
                    {
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.NpcMenu;
                        _gameConsoleView.DisplayGamePlayScreen("NPC Menu", "Select an operation from the menu", ActionMenu.NpcMenu, "");
                    }
                }
            }

        }

        /// <summary>
        /// process buy item from NPC action
        /// </summary>
        /// <param name="npcToTradeWith"></param>
        private void BuyNPCItem(Dictionary<int, int> npcToTradeWith)
        {
            //
            // dictinary npcToTradeWith contains NPC ID and the value is their item the player wishes to purchase
            //
            foreach (var item in npcToTradeWith)
            {
                int npcId = item.Key;
                int npcItemToBuy = item.Value;

                if (npcItemToBuy != 0)
                {
                    //
                    // get the npc object and the npc from the universe
                    //
                    GameObject npcObject = _gameUniverse.GetGameObjectById(npcItemToBuy) as GameObject;
                    NPC npc = _gameUniverse.GetNpcById(npcId) as NPC;

                    //
                    // determine if the player has enough capital to purchase NPC object
                    //
                    if (_gamePlayer.Capital >= npcObject.Value)
                    {
                        if (!_gamePlayer.MaxWeight(npcObject.Weight))
                        {
                            //
                            // update player game stats and add item to inventory
                            //
                            _gamePlayer.Capital -= npcObject.Value;
                            _gamePlayer.Inventory.Add(npcObject);
                            _gamePlayer.InventoryWeight += npcObject.Weight;

                            //
                            // remove object from the npc's list og objects to trade
                            //
                            npc.TradeObjects.Remove(npcItemToBuy);
                            

                            ActionMenu.currentMenu = ActionMenu.CurrentMenu.NpcMenu;
                            _gameConsoleView.DisplayBuyObjectFromNPC(npcObject);
                        }
                        else
                        {
                            //
                            // display if the game object will exceed the inventory max weight
                            //
                            _gameConsoleView.DisplayNPCObjectTooHeavyForInevntory(npcObject);
                        }
                    }
                    else
                    {
                        //
                        // display if the game player does not have enough coins to buy item
                        //
                        _gameConsoleView.DisplayNotEnoughCapitalToBuyNPCObject(npcObject);
                    }
                }
            }
           
   

        }

        /// <summary>
        /// game timer event handler. Player's energy levels decreases for every 30 tick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameTickTimer_Elapsed(object sender, ElapsedEventArgs e)
        { 
            _gameTick++;
            if (_gameTick % 30 == 0)
            { 

                if (_gamePlayer.Energy <= 0)
                {
                    _gamePlayer.Health -= 10;
                }
                else
                {
                    _gamePlayer.Energy -= 10;
                }

            }


        }

        #endregion

    }
    
}
