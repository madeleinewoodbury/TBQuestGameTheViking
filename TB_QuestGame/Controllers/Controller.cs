using System;
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
            _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.CurrrentLocationInfo(), ActionMenu.MainMenu, "");

            //
            // game loop
            //
            while (_playingGame)
            {
                playerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.MainMenu);

                //
                // choose an action based on the user's menu choice
                //
                switch (playerActionChoice)
                {
                    case PlayerAction.None:
                        break;
                    case PlayerAction.PlayerInfo:
                        _gameConsoleView.DisplayPlayerInfo();
                        break;
                    case PlayerAction.PlayerEdit:
                        EditPlayerInfo();
                        break;
                    case PlayerAction.ListDestinations:
                        _gameConsoleView.DisplayListOfLocations();
                        break;
                    case PlayerAction.Exit:
                        _gameConsoleView.DisplayClosingScreen(_gamePlayer);
                        _playingGame = false;
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

            _gamePlayer.Health = 100;
            _gamePlayer.Lives = 3;

        }

        public void EditPlayerInfo()
        {
            PlayerAction playerActionEditChoice = _gameConsoleView.DisplayEditPlayerInfo(_gamePlayer);
                switch (playerActionEditChoice)
                {
                    case PlayerAction.ChangeName:
                        EditName();
                        EditPlayerInfo();
                        break;
                    case PlayerAction.ChangeGender:
                        EditGender();
                        EditPlayerInfo();
                        break;
                    case PlayerAction.ChangeAge:
                        EditAge();
                        EditPlayerInfo();
                        break;
                    case PlayerAction.ChangeHomeVillage:
                        EditHomeVillage();
                        EditPlayerInfo();
                        break;
                    case PlayerAction.PurchaseWeapon:
                        PurchaseWeapon();
                        EditPlayerInfo();
                        break;
                    case PlayerAction.GoBack:
                        _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.CurrrentLocationInfo(), ActionMenu.MainMenu, "");
                        break;
                    default:
                        break;
                }

        }

        public void EditName()
        {
            _gamePlayer = _gameConsoleView.DisplayEditName(_gamePlayer);

        }

        public void EditGender()
        {
            _gamePlayer = _gameConsoleView.DisplayEditGender(_gamePlayer);
        }

        public void EditAge()
        {
            _gamePlayer = _gameConsoleView.DisplayEditAge(_gamePlayer);
        }

        public void EditHomeVillage()
        {
            _gamePlayer = _gameConsoleView.DisplayEditHomeVillage(_gamePlayer);
        }

        public void PurchaseWeapon()
        {
            _gamePlayer = _gameConsoleView.DisplayPurchaseWeapon(_gamePlayer);
        }
        #endregion
    }
}
