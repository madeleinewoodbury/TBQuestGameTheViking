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
        }

        /// <summary>
        /// method to manage the application setup and game loop
        /// </summary>
        private void ManageGameLoop()
        {
            PlayerAction playerActionChoice = PlayerAction.None;

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
            _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.CurrrentLocationInfo(_currentLocaton), ActionMenu.MainMenu, "");

            //
            // update game stauts
            //
            _gamePlayer.GameTimer = new Timer(1000);
            _gamePlayer.GameTimer.Start();
            //UpdateGameStatus();

            //
            // game loop
            //
            while (_playingGame)
            {
                UpdateGameStatus();
                //
                // get the next action from the player
                //
                if (ActionMenu.currentMenu == ActionMenu.CurrentMenu.MainMenu)
                {
                    playerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.MainMenu);
                }
                else if (ActionMenu.currentMenu == ActionMenu.CurrentMenu.AdminMenu)
                {
                    playerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.AdminMenu);
                }
                else if (ActionMenu.currentMenu == ActionMenu.CurrentMenu.EditPlayerMenu)
                {
                    playerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.EditPlayer);
                }
                else if (ActionMenu.currentMenu == ActionMenu.CurrentMenu.LookAround)
                {
                    playerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.LookAround);
                }
                else if (ActionMenu.currentMenu == ActionMenu.CurrentMenu.TradeMenu)
                {
                    playerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.TradeMenu);
                }

                //
                // choose an action based on the user's menu choice
                //
                switch (playerActionChoice)
                {
                    //
                    // Main Menu Choices
                    //
                    case PlayerAction.None:
                        break;
                    case PlayerAction.PlayerInfo:
                        _gameConsoleView.DisplayPlayerInfo();
                        break;

                    case PlayerAction.Inventory:
                        if (ActionMenu.currentMenu == ActionMenu.CurrentMenu.MainMenu)
                        {
                            _gameConsoleView.DisplayInventory();
                        }
                        else if (ActionMenu.currentMenu == ActionMenu.CurrentMenu.LookAround)
                        {
                            _gameConsoleView.DisplayInventoryLookAroundMenu();
                        }

                        break;
                    case PlayerAction.Travel:
                        // get new locationId and update the curentLocation
                        _gamePlayer.LocationId = _gameConsoleView.DisplayGetLocation();
                        _currentLocaton = _gameUniverse.GetLocationById(_gamePlayer.LocationId);

                        //
                        // update the status of the game
                        //
                        UpdateGameStatus();

                        // set the game play screen to current location info
                        _gameConsoleView.DisplayGamePlayScreen("Current Location: ", Text.CurrrentLocationInfo(_currentLocaton), ActionMenu.MainMenu, "");
                        break;

                    case PlayerAction.AdminMenu:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.AdminMenu;
                        _gameConsoleView.DisplayGamePlayScreen("Admin Menu", "Select an operation from the menu.", ActionMenu.AdminMenu, "");
                        break;
                    case PlayerAction.Exit:
                        _gameConsoleView.DisplayClosingScreen(_gamePlayer);
                        _playingGame = false;
                        break;

                    //
                    // Look Around Menu choices
                    //
                    case PlayerAction.LookAround:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.LookAround;
                        _gameConsoleView.DisplayLookAround();
                        break;
                    case PlayerAction.LookAt:
                        LookAtAction();
                        break;
                    case PlayerAction.PickUpItem:
                        PickUpAction();
                        break;
                    case PlayerAction.PutDownItem:
                        PutDownAction();
                        break;
                    case PlayerAction.Trade:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.TradeMenu;
                        _gameConsoleView.DisplayTrade(_currentLocaton);
                        break;
                    case PlayerAction.EnterPlace:
                        EnterAction();
                        break;

                    //
                    // Admin Menu choices
                    //
                    case PlayerAction.PlayerEdit:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.EditPlayerMenu;
                        _gameConsoleView.DisplayGamePlayScreen("Edit Player Info", Text.PlayerInfo(_gamePlayer), ActionMenu.EditPlayer, "");
                        break;
                    case PlayerAction.ListDestinations:
                        _gameConsoleView.DisplayListOfLocations();
                        break;
                    case PlayerAction.ListGameObjects:
                        _gameConsoleView.DisplayListOfAllGameObjects();
                        break;
                    case PlayerAction.LocationsVisited:
                        _gameConsoleView.DisplayLocationsVisited();
                        break;
                    case PlayerAction.ReturnToMainMenu:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.MainMenu;
                        _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.CurrrentLocationInfo(_currentLocaton), ActionMenu.MainMenu, "");
                        break;

                    //
                    // Edit player info menu choices
                    //
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
                    case PlayerAction.GoBack:
                        if (ActionMenu.currentMenu == ActionMenu.CurrentMenu.EditPlayerMenu)
                        {
                            ActionMenu.currentMenu = ActionMenu.CurrentMenu.AdminMenu;
                            _gameConsoleView.DisplayGamePlayScreen("Admin Menu", "Select an operation from the menu.", ActionMenu.AdminMenu, "");
                        }
                        else if (ActionMenu.currentMenu == ActionMenu.CurrentMenu.TradeMenu)
                        {
                            ActionMenu.currentMenu = ActionMenu.CurrentMenu.LookAround;
                            _gameConsoleView.DisplayLookAround();
                        }

                        break;

                    //
                    // Trade Menu Choices
                    //
                    case PlayerAction.Buy:
                        BuyAction();
                        break;
                    case PlayerAction.Sell:
                        SellAction();
                        break;

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

            _gamePlayer.Name = player.Name;
            _gamePlayer.Age = player.Age;
            _gamePlayer.Viking = player.Viking;
            _gamePlayer.LocationId = 1;
            _gamePlayer.HomeVillage = player.HomeVillage;
            _gamePlayer.Capital = player.Capital;
            _gamePlayer.IsArmed = false;

            _gamePlayer.ExperiencePoints = 0;
            _gamePlayer.Health = 100;
            _gamePlayer.Lives = 3;
            _gamePlayer.Energy = 100;

            //
            // add initial items to inventory
            //
            _gamePlayer.Inventory.Add(_gameUniverse.GetGameObjectById(17) as GameObject);

        }

        private void UpdateGameStatus()
        {
            if (!_gamePlayer.HasVisited(_currentLocaton.LocationId))
            {
                // add new location to the list of visited locations
                _gamePlayer.LocationsVisted.Add(_currentLocaton.LocationId);

                // update experience points and health for visiting locations
                _gamePlayer.ExperiencePoints += _currentLocaton.ExperiencePoints;

            }

            _gamePlayer.GameTimer.Elapsed += GameTickTimer_Elapsed;
            if (_gamePlayer.Energy == 0)
            {
                _gamePlayer.Lives -= 1;
                _gamePlayer.Energy = 100;
            }
        }

        private void EnterAction()
        {
            //
            // display list of places in current location
            //
            int placeId = _gameConsoleView.DisplayGetPlaceToEnter();

            if (placeId != 0)
            {
                GameObject gameObject = _gameUniverse.GetGameObjectById(placeId);
                Place placeToEnter = gameObject as Place;

                // update game stats
                _gamePlayer.ExperiencePoints += placeToEnter.ExperiencePoints;
                _gamePlayer.Health += placeToEnter.Health;

                _gameConsoleView.DisplayConfirmPlaceEntered(placeToEnter);
            }
            else
            {
                _gameConsoleView.DisplayLookAround();
            }


        }

        /// <summary>
        /// process the Look At action
        /// </summary>
        private void LookAtAction()
        {
            //
            // display a list of game objects in space-time location and get a player choice
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
                _gameConsoleView.DisplayLookAround();
            }
        }


        private void SellAction()
        {
            int tradeObjectToSell = _gameConsoleView.DisplayGetTradeObjectToSell();

            if (tradeObjectToSell != 0)
            {
                //
                // get the game object from the universe
                //
                GameObject tradeObject = _gameUniverse.GetGameObjectById(tradeObjectToSell) as GameObject;

                //
                // update the capital and remover from inventory
                //
                _gamePlayer.Capital += tradeObject.Value;
                _gamePlayer.Inventory.Remove(tradeObject);

                _gameConsoleView.DisplayConfirmSale(tradeObject);
            }

            else
            {
                _gameConsoleView.DisplayTrade(_currentLocaton);
            }

        }

        private void BuyAction()
        {
            //
            // display a list of trade objects in location and get a player choice
            //
            int tradeObjectIdToBuy = _gameConsoleView.DisplayGetTradeItemToPurchase(_currentLocaton);

            //
            // add the traveler object to traveler's inventory
            //
            if (tradeObjectIdToBuy != 0)
            {
                //
                // get the game object from the universe
                //
                GameObject tradeObject = _gameUniverse.GetGameObjectById(tradeObjectIdToBuy) as GameObject;

                //
                // update the capital and add to inventory
                //
                _gamePlayer.Capital -= tradeObject.Value;
                _gamePlayer.Inventory.Add(tradeObject);
                tradeObject.LocationId = 0;

                _gameConsoleView.DisplayConfirmPurchase(tradeObject);
            }
            else
            {
                _gameConsoleView.DisplayTrade(_currentLocaton);
            }

        }

        private void PickUpAction()
        {
            //
            // display a list of game objects in location and get a player choice
            //
            int gameObjectToPickUpId = _gameConsoleView.DisplayGetGameObjectToPickUp();

            //
            // add the traveler object to traveler's inventory
            //
            if (gameObjectToPickUpId != 0)
            {
                //
                // get the game object from the universe
                //
                GameObject gameObject = _gameUniverse.GetGameObjectById(gameObjectToPickUpId) as GameObject;

                //
                // note: traveler object is added to list and space-time location is set to 0
                //
                _gamePlayer.Inventory.Add(gameObject);
                gameObject.LocationId = 0;

                //
                // display confirmation message
                //
                _gameConsoleView.DisplayConfirmGameObjectAddedToInventory(gameObject);
            }
            else
            {
                _gameConsoleView.DisplayLookAround();
            }
        }

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
                // remove the object from the inventory and set the location to the current value
                //
                _gamePlayer.Inventory.Remove(gameObject);
                gameObject.LocationId = _gamePlayer.LocationId;

                //
                // display confirmation message
                //
                _gameConsoleView.DisplayConfirmItemRemovedFromInventory(gameObject);
            }
            else
            {
                _gameConsoleView.DisplayLookAround();
            }

        }

        private void GameTickTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Timer timer = sender as Timer; //cast the sender as a timer
            TimeSpan gameTime = TimeSpan.FromSeconds(_gameTick);
            _gameTick++;
            if (_gameTick == 100)
            {
                _gamePlayer.Energy -= 10;
                _gameTick = 1;
            }

        }

        #endregion

    }
    
}
