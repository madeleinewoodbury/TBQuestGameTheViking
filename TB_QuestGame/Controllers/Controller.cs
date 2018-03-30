﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            UpdateGameStatus();

            //
            // game loop
            //
            while (_playingGame)
            { 

                //
                // get the next action from the player
                //
                if(ActionMenu.currentMenu == ActionMenu.CurrentMenu.MainMenu)
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
                    case PlayerAction.LookAround:
                        _gameConsoleView.DisplayLookAround();
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
                    case PlayerAction.LocationsVisited:
                        _gameConsoleView.DisplayLocationsVisited();
                        break;
                    case PlayerAction.LookAt:
                        LookAtAction();
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
                    case PlayerAction.PurchaseWeapon:
                        _gamePlayer = _gameConsoleView.DisplayPurchaseWeapon(_gamePlayer);
                        _gameConsoleView.DisplayGamePlayScreen("Edit Player Info", Text.PlayerInfo(_gamePlayer), ActionMenu.EditPlayer, "");
                        break;
                    case PlayerAction.GoBack:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.AdminMenu;
                        _gameConsoleView.DisplayGamePlayScreen("Edit Player Info", Text.PlayerInfo(_gamePlayer), ActionMenu.EditPlayer, "");
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
            _gamePlayer.WeaponType = player.WeaponType;
            _gamePlayer.IsArmed = player.IsArmed;

            _gamePlayer.ExperiencePoints = 0;
            _gamePlayer.Health = 100;
            _gamePlayer.Lives = 3;

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
        }

        #endregion
    }
}
