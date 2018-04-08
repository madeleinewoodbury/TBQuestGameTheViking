using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// view class
    /// </summary>
    public class ConsoleView
    {
        #region ViewStatus

        private enum ViewStatus
        {
            TravelerInitialization,
            PlayingGame
        }

        #endregion
        
        #region FIELDS

        //
        // declare game objects for the ConsoleView object to use
        //
        Player _gamePlayer;
        Universe _gameUniverse;

        ViewStatus _viewStatus;

        #endregion

        #region PROPERTIES

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// default constructor to create the console view objects
        /// </summary>
        public ConsoleView(Player gamePlayer, Universe gameUniverse)
        {
            _gamePlayer = gamePlayer;
            _gameUniverse = gameUniverse;

            _viewStatus = ViewStatus.TravelerInitialization;

            InitializeDisplay();
        }

        #endregion

        #region METHODS
        /// <summary>
        /// display all of the elements on the game play screen on the console
        /// </summary>
        /// <param name="messageBoxHeaderText">message box header title</param>
        /// <param name="messageBoxText">message box text</param>
        /// <param name="menu">menu to use</param>
        /// <param name="inputBoxPrompt">input box text</param>
        public void DisplayGamePlayScreen(string messageBoxHeaderText, string messageBoxText, Menu menu, string inputBoxPrompt)
        {
            //
            // reset screen to default window colors
            //
            Console.BackgroundColor = ConsoleTheme.WindowBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.WindowForegroundColor;
            Console.Clear();

            ConsoleWindowHelper.DisplayHeader(Text.HeaderText);
            ConsoleWindowHelper.DisplayFooter(Text.FooterText);

            DisplayMessageBox(messageBoxHeaderText, messageBoxText);
            DisplayMenuBox(menu);
            DisplayInputBox();
            DisplayStatusBox();
        }

        /// <summary>
        /// wait for any keystroke to continue
        /// </summary>
        public void GetContinueKey()
        {
            Console.ReadKey();
        }

        /// <summary>
        /// get a action menu choice from the user
        /// </summary>
        /// <returns>action menu choice</returns>
        public PlayerAction GetActionMenuChoice(Menu menu)
        {
            PlayerAction choosenAction = PlayerAction.None;
            Console.CursorVisible = false;

            //
            // create an array of valid keys from new dictionary
            //
            char[] validKeys = menu.MenuChoices.Keys.ToArray();

            //
            // validate key pressed in MenuChoices dictionary
            //
            char keyPressed;
            do
            {
                ConsoleKeyInfo keyPressedInfo = Console.ReadKey(true);
                keyPressed = keyPressedInfo.KeyChar;
            } while (!validKeys.Contains(keyPressed));

            choosenAction = menu.MenuChoices[keyPressed];
            Console.CursorVisible = true;

            return choosenAction;
        }

        /// <summary>
        /// get a string value from the user
        /// </summary>
        /// <returns>string value</returns>
        public string GetString(string prompt)
        {
            DisplayInputBoxPrompt(prompt);
            string userResponse = Console.ReadLine();

            while(userResponse == "")
            {
                ClearInputBox();
                DisplayInputErrorMessage("You must enter at least one character. Please try again.");
                DisplayInputBoxPrompt(prompt);
                userResponse = Console.ReadLine();
            }

            return userResponse;
        }

        /// <summary>
        /// get an integer value from the user
        /// </summary>
        /// <returns>integer value</returns>
        public bool GetInteger(string prompt, int minimumValue, int maximumValue, out int integerChoice)
        {
            bool validResponse = false;
            integerChoice = 0;

            //
            // validate on range if either minimumValue and maximumValue are not 0
            //
            bool validateRange = (minimumValue != 0 || maximumValue != 0);

            DisplayInputBoxPrompt(prompt);
            while (!validResponse)
            {
                if (int.TryParse(Console.ReadLine(), out integerChoice))
                {
                    if (validateRange)
                    {
                        if (integerChoice >= minimumValue && integerChoice <= maximumValue)
                        {
                            validResponse = true;
                        }
                        else
                        {
                            ClearInputBox();
                            DisplayInputErrorMessage($"You must enter an integer value between {minimumValue} and {maximumValue}. Please try again.");
                            DisplayInputBoxPrompt(prompt);
                        }
                    }
                    else
                    {
                        validResponse = true;
                    }

                }
                else
                {
                    ClearInputBox();
                    DisplayInputErrorMessage($"You must enter an integer value between {minimumValue} and {maximumValue}. Please try again.");
                    DisplayInputBoxPrompt(prompt);
                }
            }

            return true;
        }

        /// <summary>
        /// get yes or no from user
        /// </summary>
        /// <returns></returns>
        public string GetYesOrNo()
        {
            bool validResponse = false;
            string userResponse = "";

            while (!validResponse)
            {
                userResponse = Console.ReadLine().ToUpper();

                if (userResponse == "YES" || userResponse == "NO")
                {
                    validResponse = true;
                }
                else
                {
                    ClearInputBox();
                    DisplayInputErrorMessage("You must enter yes or no. Please try again.");
                    DisplayInputBoxPrompt("Enter yes or no: ");
                }
            }

            return userResponse;
        }

        /// <summary>
        /// get a character race value from the user
        /// </summary>
        /// <returns>character race value</returns>
        public Player.VikingType GetVikingType()
        {
            bool validInput = false;
            Player.VikingType vikingType = Player.VikingType.None;

            while (!validInput)
            {
                if (!Enum.TryParse<Player.VikingType>(Console.ReadLine(), out vikingType))
                {
                    ClearInputBox();
                    DisplayInputErrorMessage("You have entered an invalid response. Please try again.");
                    DisplayInputBoxPrompt("Enter Shieldmaiden or Karl: ");
                }
                else
                {
                    validInput = true;
                }
            }
            

            return vikingType;
        }

        /// <summary>
        /// display splash screen
        /// </summary>
        /// <returns>player chooses to play</returns>
        public bool DisplaySpashScreen()
        {
            bool playing = true;
            ConsoleKeyInfo keyPressed;

            Console.BackgroundColor = ConsoleTheme.SplashScreenBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.SplashScreenForegroundColor;
            Console.Clear();
            Console.CursorVisible = false;


            Console.SetCursorPosition(0, 10);
            string tabSpace = new String(' ', 35);
            Console.WriteLine(tabSpace + @"                        __          __ _   _   _   _   _      _   _______       ");
            Console.WriteLine(tabSpace + @"    _____ _             \ \        / /| | | | / / | | | \    | | |  _____|      ");
            Console.WriteLine(tabSpace + @"   |_   _| |             \ \      / / | | | |/ /  | | |  \   | | | |            ");
            Console.WriteLine(tabSpace + @"     | | | |__   ___      \ \    / /  | | |   /   | | |   \  | | | |  __        ");
            Console.WriteLine(tabSpace + @"     | | | '_ \ / _ \      \ \  / /   | | |   \   | | | |\ \ | | | | |_  \      ");
            Console.WriteLine(tabSpace + @"     | | | | | |  __/       \ \/ /    | | | |\ \  | | | | \ \| | | |___| |      ");
            Console.WriteLine(tabSpace + @"     |_| |_| |_|\___|        \__/     |_| |_| \_\ |_| |_|  \___| |_______|      ");
            Console.WriteLine(tabSpace + @"  ____________________________________________________________________________  ");
            Console.WriteLine(tabSpace + @" |                                                                            | ");
            Console.WriteLine(tabSpace + @" |                THE QUEST TO BECOME THE KING OF THE VIKINGS                 | ");
            Console.WriteLine(tabSpace + @" |____________________________________________________________________________| ");

            Console.SetCursorPosition(80, 25);
            Console.Write("Press any key to continue or Esc to exit.");
            keyPressed = Console.ReadKey();
            if (keyPressed.Key == ConsoleKey.Escape)
            {
                playing = false;
            }

            return playing;
        }

        /// <summary>
        /// initialize the console window settings
        /// </summary>
        private static void InitializeDisplay()
        {
            //
            // control the console window properties
            //
            ConsoleWindowControl.DisableResize();
            ConsoleWindowControl.DisableMaximize();
            ConsoleWindowControl.DisableMinimize();
            Console.Title = "The Viking";

            //
            // set the default console window values
            //
            ConsoleWindowHelper.InitializeConsoleWindow();

            Console.CursorVisible = false;
        }

        /// <summary>
        /// display the correct menu in the menu box of the game screen
        /// </summary>
        /// <param name="menu">menu for current game state</param>
        private void DisplayMenuBox(Menu menu)
        {
            Console.BackgroundColor = ConsoleTheme.MenuBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MenuBorderColor;

            //
            // display menu box border
            //
            ConsoleWindowHelper.DisplayBoxOutline(
                ConsoleLayout.MenuBoxPositionTop,
                ConsoleLayout.MenuBoxPositionLeft,
                ConsoleLayout.MenuBoxWidth,
                ConsoleLayout.MenuBoxHeight);

            //
            // display menu box header
            //
            Console.BackgroundColor = ConsoleTheme.MenuBorderColor;
            Console.ForegroundColor = ConsoleTheme.MenuForegroundColor;
            Console.SetCursorPosition(ConsoleLayout.MenuBoxPositionLeft + 2, ConsoleLayout.MenuBoxPositionTop + 1);
            Console.Write(ConsoleWindowHelper.Center(menu.MenuTitle, ConsoleLayout.MenuBoxWidth - 4));

            //
            // display menu choices
            //
            Console.BackgroundColor = ConsoleTheme.MenuBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MenuForegroundColor;
            int topRow = ConsoleLayout.MenuBoxPositionTop + 3;

            foreach (KeyValuePair<char, PlayerAction> menuChoice in menu.MenuChoices)
            {
                if (menuChoice.Value != PlayerAction.None)
                {
                    string formatedMenuChoice = ConsoleWindowHelper.ToLabelFormat(menuChoice.Value.ToString());
                    Console.SetCursorPosition(ConsoleLayout.MenuBoxPositionLeft + 3, topRow++);
                    Console.Write($"{menuChoice.Key}. {formatedMenuChoice}");
                }
            }
        }

        /// <summary>
        /// display the text in the message box of the game screen
        /// </summary>
        /// <param name="headerText"></param>
        /// <param name="messageText"></param>
        private void DisplayMessageBox(string headerText, string messageText)
        {
            //
            // display the outline for the message box
            //
            Console.BackgroundColor = ConsoleTheme.MessageBoxBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MessageBoxBorderColor;
            ConsoleWindowHelper.DisplayBoxOutline(
                ConsoleLayout.MessageBoxPositionTop,
                ConsoleLayout.MessageBoxPositionLeft,
                ConsoleLayout.MessageBoxWidth,
                ConsoleLayout.MessageBoxHeight);

            //
            // display message box header
            //
            Console.BackgroundColor = ConsoleTheme.MessageBoxBorderColor;
            Console.ForegroundColor = ConsoleTheme.MessageBoxForegroundColor;
            Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 2, ConsoleLayout.MessageBoxPositionTop + 1);
            Console.Write(ConsoleWindowHelper.Center(headerText, ConsoleLayout.MessageBoxWidth - 4));

            //
            // display the text for the message box
            //
            Console.BackgroundColor = ConsoleTheme.MessageBoxBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MessageBoxForegroundColor;
            List<string> messageTextLines = new List<string>();
            messageTextLines = ConsoleWindowHelper.MessageBoxWordWrap(messageText, ConsoleLayout.MessageBoxWidth - 4);

            int startingRow = ConsoleLayout.MessageBoxPositionTop + 3;
            int endingRow = startingRow + messageTextLines.Count();
            int row = startingRow;
            foreach (string messageTextLine in messageTextLines)
            {
                Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 2, row);
                Console.Write(messageTextLine);
                row++;
            }

        }

        /// <summary>
        /// draw the status box on the game screen
        /// </summary>
        public void DisplayStatusBox()
        {
            Console.BackgroundColor = ConsoleTheme.InputBoxBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.InputBoxBorderColor;

            //
            // display the outline for the status box
            //
            ConsoleWindowHelper.DisplayBoxOutline(
                ConsoleLayout.StatusBoxPositionTop,
                ConsoleLayout.StatusBoxPositionLeft,
                ConsoleLayout.StatusBoxWidth,
                ConsoleLayout.StatusBoxHeight);

            //
            // display the text for the status box if playing game
            //
            if (_viewStatus == ViewStatus.PlayingGame)
            {
                //
                // display status box header with title
                //
                Console.BackgroundColor = ConsoleTheme.StatusBoxBorderColor;
                Console.ForegroundColor = ConsoleTheme.StatusBoxForegroundColor;
                Console.SetCursorPosition(ConsoleLayout.StatusBoxPositionLeft + 2, ConsoleLayout.StatusBoxPositionTop + 1);
                Console.Write(ConsoleWindowHelper.Center("Game Stats", ConsoleLayout.StatusBoxWidth - 4));
                Console.BackgroundColor = ConsoleTheme.StatusBoxBackgroundColor;
                Console.ForegroundColor = ConsoleTheme.StatusBoxForegroundColor;

                //
                // display stats
                //
                int startingRow = ConsoleLayout.StatusBoxPositionTop + 3;
                int row = startingRow;
                foreach (string statusTextLine in Text.StatusBox(_gamePlayer))
                {
                    Console.SetCursorPosition(ConsoleLayout.StatusBoxPositionLeft + 3, row);
                    Console.Write(statusTextLine);
                    row++;
                }
            }
            else
            {
                //
                // display status box header without header
                //
                Console.BackgroundColor = ConsoleTheme.StatusBoxBorderColor;
                Console.ForegroundColor = ConsoleTheme.StatusBoxForegroundColor;
                Console.SetCursorPosition(ConsoleLayout.StatusBoxPositionLeft + 2, ConsoleLayout.StatusBoxPositionTop + 1);
                Console.Write(ConsoleWindowHelper.Center("", ConsoleLayout.StatusBoxWidth - 4));
                Console.BackgroundColor = ConsoleTheme.StatusBoxBackgroundColor;
                Console.ForegroundColor = ConsoleTheme.StatusBoxForegroundColor;
            }
        }

        /// <summary>
        /// draw the input box on the game screen
        /// </summary>
        public void DisplayInputBox()
        {
            Console.BackgroundColor = ConsoleTheme.InputBoxBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.InputBoxBorderColor;

            ConsoleWindowHelper.DisplayBoxOutline(
                ConsoleLayout.InputBoxPositionTop,
                ConsoleLayout.InputBoxPositionLeft,
                ConsoleLayout.InputBoxWidth,
                ConsoleLayout.InputBoxHeight);
        }

        /// <summary>
        /// display the prompt in the input box of the game screen
        /// </summary>
        /// <param name="prompt"></param>
        public void DisplayInputBoxPrompt(string prompt)
        {
            Console.SetCursorPosition(ConsoleLayout.InputBoxPositionLeft + 4, ConsoleLayout.InputBoxPositionTop + 1);
            Console.ForegroundColor = ConsoleTheme.InputBoxForegroundColor;
            Console.Write(prompt);
            Console.CursorVisible = true;
        }

        /// <summary>
        /// display the error message in the input box of the game screen
        /// </summary>
        /// <param name="errorMessage">error message text</param>
        public void DisplayInputErrorMessage(string errorMessage)
        {
            Console.SetCursorPosition(ConsoleLayout.InputBoxPositionLeft + 4, ConsoleLayout.InputBoxPositionTop + 2);
            Console.ForegroundColor = ConsoleTheme.InputBoxErrorMessageForegroundColor;
            Console.Write(errorMessage);
            Console.ForegroundColor = ConsoleTheme.InputBoxForegroundColor;
            Console.CursorVisible = true;
        }

        /// <summary>
        /// clear the input box
        /// </summary>
        private void ClearInputBox()
        {
            string backgroundColorString = new String(' ', ConsoleLayout.InputBoxWidth - 4);

            Console.ForegroundColor = ConsoleTheme.InputBoxBackgroundColor;
            for (int row = 1; row < ConsoleLayout.InputBoxHeight - 2; row++)
            {
                Console.SetCursorPosition(ConsoleLayout.InputBoxPositionLeft + 4, ConsoleLayout.InputBoxPositionTop + row);
                DisplayInputBoxPrompt(backgroundColorString);
            }
            Console.ForegroundColor = ConsoleTheme.InputBoxForegroundColor;
        }

        /// <summary>
        /// get the player's initial information at the beginning of the game
        /// </summary>
        /// <returns>player object with all properties updated</returns>
        public Player GetInitialPlayerInfo()
        {
            // instantiate a new player
            Player player = new Player();

            // isArmed is set to false to begin with
            player.IsArmed = false;

            // starting capital is set to 100
            player.Capital = 100;

            string prompt;

            //
            // intro
            //
            DisplayGamePlayScreen("The Viking Setup", Text.SetupIntro(), ActionMenu.QuestIntro, "");
            GetContinueKey();

            //
            // get player's name
            //
            DisplayGamePlayScreen("The Viking Setup - Name", Text.SetuoGetPlayerName(), ActionMenu.QuestIntro, "");
            prompt = "Enter your name: ";
            player.Name = GetString(prompt);

            //
            // get player's race
            //
            DisplayGamePlayScreen("The Viking Setup - Gender", Text.SetupGetPlayerGender(player), ActionMenu.QuestIntro, "");
            DisplayInputBoxPrompt("Enter your viking: ");
            player.Viking = GetVikingType();

            //
            // get player's age
            //
            DisplayGamePlayScreen("The Viking Setup - Age", Text.SetupGetPlayerAge(player), ActionMenu.QuestIntro, "");
            int gamePlayerAge;

            GetInteger($"Enter your age {player.Name}: ", 0, 1000000, out gamePlayerAge);
            player.Age = gamePlayerAge;

            //
            // get palyer's home village
            //
            DisplayGamePlayScreen("The Viking Setup - Home Village", Text.SetupGetPlayerHomeVillage(player), ActionMenu.QuestIntro, "");
            prompt ="Enter the name of the Village: ";
            player.HomeVillage = GetString(prompt);

            //
            // echo the player's info
            //
            DisplayGamePlayScreen("The Viking Setup - Complete", Text.SetupEchoPlayerInfo(player), ActionMenu.QuestIntro, "");
            Console.CursorVisible = false;
            GetContinueKey();

            //
            // change view status to playing game
            //
            _viewStatus = ViewStatus.PlayingGame;

            return player;
        }

        #region ----- display responses to menu action choices -----

        /// <summary>
        /// Display List of all locations
        /// </summary>
        public void DisplayListOfLocations()
        {
            DisplayGamePlayScreen("List: Locations", Text.ListLocations(_gameUniverse.Locations), ActionMenu.AdminMenu, "");
        }

        /// <summary>
        /// Display look around method from the text class
        /// </summary>
        public void DisplayLookAround()
        {
            Location currentLocation = _gameUniverse.GetLocationById(_gamePlayer.LocationId);
            DisplayGamePlayScreen("Current Location", Text.LookAround(currentLocation), ActionMenu.LookAround, "");
        }

        /// <summary>
        /// Get the next location ID from the player
        /// </summary>
        /// <returns></returns>
        public int DisplayGetLocation()
        {
            int locationId = 0;
            bool validLocationId = false;

            DisplayGamePlayScreen("Travel to a new location", Text.Travel(_gamePlayer, _gameUniverse.Locations), ActionMenu.MainMenu, "");

            while (!validLocationId)
            {
                //
                // get integer from user
                //
                GetInteger("Enter the new location: ", 1, _gameUniverse.GetMaxLocationID(), out locationId);

                //
                // validate the locationID and determine accesability
                //
                if (_gameUniverse.IsValidLocationId(locationId))
                {
                    if (_gameUniverse.IsAccessibleLocation(locationId, _gamePlayer.LocationId))
                    {
                        validLocationId = true;
                    }
                    else
                    {
                        ClearInputBox();
                        DisplayInputErrorMessage("You are attempting to travel to a location that is not accessible. Please try again.");
                    }
                }
                else
                {
                    DisplayInputErrorMessage("You entered an invalid locationId. Please try again.");
                }
            }

            return locationId;
        }

        /// <summary>
        /// 
        /// </summary>
        public void DisplayLocationsVisited()
        {
            //
            // generate a list of locations that the player has visited
            //
            List<Location> locationsVisited = new List<Location>();
            foreach (int  locationId in _gamePlayer.LocationsVisted)
            {
                locationsVisited.Add(_gameUniverse.GetLocationById(locationId));
            }

            DisplayGamePlayScreen("Locations you have visited", Text.VisitedLocations(locationsVisited), ActionMenu.AdminMenu, "");
        }

        /// <summary>
        /// Display player info
        /// </summary>
        public void DisplayPlayerInfo()
        {
            DisplayGamePlayScreen("Viking Information", Text.PlayerInfo(_gamePlayer), ActionMenu.MainMenu, "");
        }

        /// <summary>
        /// Display Edit Player Infor screen
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public PlayerAction DisplayEditPlayerInfo(Player player)
        {

            DisplayGamePlayScreen("Edit Viking Info", Text.EditPlayerInfo(player), ActionMenu.EditPlayer, "");
            PlayerAction playerMenuEditChoice = GetActionMenuChoice(ActionMenu.EditPlayer);

            return playerMenuEditChoice;
        }

        /// <summary>
        /// Edit Player Name
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public string DisplayEditName(Player player)
        {
            DisplayGamePlayScreen("Edit Viking Info - Name", Text.SetuoGetPlayerName(), ActionMenu.EditPlayer, "");
            string prompt = "Enter your name: ";
            string name = GetString(prompt);
            return name;
        }

        /// <summary>
        /// Edit Player Gender
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public Player.VikingType DisplayEditGender(Player player)
        {
            Player.VikingType viking = Player.VikingType.None;
            DisplayGamePlayScreen("Edit Viking Info - Gender", Text.EditGetPlayerGender(player), ActionMenu.EditPlayer, "");
            DisplayInputBoxPrompt("Enter your viking: ");
            viking = GetVikingType();
            return viking;
        }

        /// <summary>
        /// Edit Player Age
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public int DisplayEditAge(Player player)
        {
            DisplayGamePlayScreen("The Viking Setup - Age", Text.SetupGetPlayerAge(player), ActionMenu.EditPlayer, "");
            int gamePlayerAge;

            GetInteger($"Enter your age {player.Name}: ", 0, 1000000, out gamePlayerAge);
            return gamePlayerAge;
        }

        /// <summary>
        /// Edit Player Home Village
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public string DisplayEditHomeVillage(Player player)
        {
            DisplayGamePlayScreen("The Viking Setup - Home Village", Text.SetupGetPlayerHomeVillage(player), ActionMenu.EditPlayer, "");
            string prompt = "Enter the name of the Village: ";
            string homeVillage = GetString(prompt);
            return homeVillage;
        }

        /// <summary>
        /// display list of game objects in the universe
        /// </summary>
        public void DisplayListOfAllGameObjects()
        {
            DisplayGamePlayScreen("List: Game Objects", Text.ListAllGameObjects(_gameUniverse.GameObjects), ActionMenu.AdminMenu, "");
        }

        /// <summary>
        /// display the information required for the player to choose an object to look at
        /// </summary>
        /// <returns></returns>
        public int DisplayGetGameObjectToLookAt()
        {
            int gameObjectId = 0;
            bool validGamerObjectId = false;

            //
            // get a list of game objects in the current space-time location
            //
            List<GameObject> gameObjectsInLocation = _gameUniverse.GetGameObjectsByLocationId(_gamePlayer.LocationId);

            if (gameObjectsInLocation.Count > 0)
            {
                DisplayGamePlayScreen("Look at a Object", Text.GameObjectsChooseList(gameObjectsInLocation), ActionMenu.LookAround, "");

                while (!validGamerObjectId)
                {
                    //
                    // get an integer from the player
                    //
                    GetInteger($"Enter the Id number of the object you wish to look at: ", 0, 0, out gameObjectId);

                    //
                    // validate integer as a valid game object id and in current location
                    //
                    if (_gameUniverse.IsValidGameObjectByLocationId(gameObjectId, _gamePlayer.LocationId))
                    {
                        validGamerObjectId = true;
                    }
                    else
                    {
                        ClearInputBox();
                        DisplayInputErrorMessage("It appears you entered an invalid game object id. Please try again.");
                    }
                }
            }
            else
            {
                DisplayGamePlayScreen("Look at a Object", "It appears there are no game objects here.", ActionMenu.LookAround, "");
            }

            return gameObjectId;
        }

        public int DisplayGetGameObjectToPickUp()
        {
            int gameObjectId = 0;
            bool validGameObjectId = false;

            //
            // get a list of objects in the current location
            //
            List<GameObject> gameObjectsInLocation = _gameUniverse.GetGameObjectsByLocationId(_gamePlayer.LocationId);

            if (gameObjectsInLocation.Count > 0)
            {
                DisplayGamePlayScreen("Pick Up Object", Text.GameObjectsChooseList(gameObjectsInLocation), ActionMenu.LookAround, "");

                while (!validGameObjectId)
                {
                    //
                    // get an integer from the player
                    //
                    GetInteger($"Enter the Id number of the object you wish to add to your inventory: ", 0, 0, out gameObjectId);

                    //
                    // validate integer as valid game object id in current location
                    if (_gameUniverse.IsValidGameObjectByLocationId(gameObjectId, _gamePlayer.LocationId))
                    {
                        GameObject gameObject = _gameUniverse.GetGameObjectById(gameObjectId) as GameObject;
                        if (gameObject.CanInventory)
                        {
                            validGameObjectId = true;
                        }
                        else
                        {
                            ClearInputBox();
                            DisplayInputErrorMessage($"It appears you may not add {gameObject.Name} to your inventory.");
                        }
                    }
                    else
                    {
                        ClearInputBox();
                        DisplayInputErrorMessage("It appears you entered an invalid game object id. Please try again.");
                    }

                }
            }
            else
            {
                DisplayGamePlayScreen("Pick Up Object", "It appears there are no game objects here.", ActionMenu.LookAround, "");
            }

            return gameObjectId;

        }

        public void DisplayConfirmGameObjectAddedToInventory(GameObject objectAdded)
        {
            DisplayGamePlayScreen("Pick Up Object", $"The {objectAdded.Name} has been added to your inventory", ActionMenu.LookAround, "");
        }

        public int DisplayGetGameObjectToPutDown()
        {
            int gameObjectId = 0;
            bool validObjectId = false;

            if (_gamePlayer.Inventory.Count > 0)
            {
                DisplayGamePlayScreen("Put Down Item", Text.GameObjectsChooseList(_gamePlayer.Inventory), ActionMenu.LookAround, "");


                while (!validObjectId)
                {
                    //
                    // get an integer from the player
                    //
                    GetInteger($"Enter the Id number of the object you wish to put down: ", 0, 0, out gameObjectId);

                    //
                    // find object in inventory
                    //
                    GameObject gameObject = _gamePlayer.Inventory.FirstOrDefault(o => o.Id == gameObjectId);

                    //
                    // validate object in inventory
                    //
                    if (gameObject != null)
                    {
                        validObjectId = true;
                    }
                    else
                    {
                        ClearInputBox();
                        DisplayInputErrorMessage("It appears you entered the id of an object that is not in your inventory. Please try again.");
                    }
                }
            }
            else
            {
                DisplayGamePlayScreen("Put Down Item", "You don't have any items to put down. Your inventory is empty.", ActionMenu.LookAround, "");
            }


            return gameObjectId;

        }

        public void DisplayConfirmItemRemovedFromInventory(GameObject gameObject)
        {
            DisplayGamePlayScreen("Put Down Item", $"The {gameObject.Name} has been removed from your invnetory.", ActionMenu.LookAround, "");
        }

        public void DisplayGameObjectInfo(GameObject gameObject)
        {
            DisplayGamePlayScreen("Current Location", Text.LookAt(gameObject), ActionMenu.LookAround, "");

        }

        public void DisplayInventory()
        {
            DisplayGamePlayScreen("Current Inventory", Text.CurrentInventory(_gamePlayer.Inventory), ActionMenu.MainMenu, "");
        }

        public void DisplayInventoryLookAroundMenu()
        {
            DisplayGamePlayScreen("Current Inventory", Text.CurrentInventory(_gamePlayer.Inventory), ActionMenu.LookAround, "");
        }

        public void DisplayTrade(Location currentLocation)
        {
            DisplayGamePlayScreen("Trade", Text.DisplayTradeScreenText(_gamePlayer.Inventory, currentLocation), ActionMenu.TradeMenu, "");
        }

        public void DisplayConfirmPurchase(GameObject objectAdded)
        {
            DisplayGamePlayScreen("Trade", $"The {objectAdded.Name} has been added to your inventory", ActionMenu.TradeMenu, "");
        }

        public int DisplayGetTradeObjectToSell()
        {
            int tradeObjectId = 0;
            bool validObjectId = false;

            if (_gamePlayer.Inventory.Count > 0)
            {
                DisplayGamePlayScreen("Sell", Text.DisplayObjectsForSale(_gamePlayer.Inventory), ActionMenu.TradeMenu, "");


                while (!validObjectId)
                {
                    //
                    // get an integer from the player
                    //
                    GetInteger($"Enter the Id number of the object you wish to trade in for money: ", 0, 0, out tradeObjectId);

                    //
                    // find object in inventory
                    //
                    GameObject tradeObject = _gamePlayer.Inventory.FirstOrDefault(o => o.Id == tradeObjectId);

                    //
                    // validate object in inventory
                    //
                    if (tradeObject != null)
                    {
                        validObjectId = true;
                    }
                    else
                    {
                        ClearInputBox();
                        DisplayInputErrorMessage("It appears you entered the id of an object that is not in your inventory. Please try again.");
                    }
                }
            }
            else
            {
                DisplayGamePlayScreen("Sell", "You don't have any items to sell. Your inventory is empty.", ActionMenu.TradeMenu, "");
            }
            

            return tradeObjectId;
            
        }

        public void DisplayConfirmSale(GameObject objectAdded)
        {
            DisplayGamePlayScreen("Trade", $"The {objectAdded.Name} has been removed from your inevntory.", ActionMenu.TradeMenu, "");
        }

        public void DisplayClosingScreen(Player player)
        {
            DisplayGamePlayScreen("Exiting Game", Text.DisplayClosingScreenText(player), ActionMenu.QuestIntro, "");
            GetContinueKey();
        }

        public int DisplayGetTradeItemToPurchase(Location currentLocation)
        {
            int tradeObjectId = 0;
            bool validObjectId = false;

            List<GameObject> tradeObjects = new List<GameObject>();
            foreach (int item in currentLocation.TradeObjects)
            {
                if (_gameUniverse.TestValidTradeItemByLocation(item, _gamePlayer.LocationId))
                {
                    GameObject tradeObject = _gameUniverse.GetGameObjectById(item) as GameObject;
                    tradeObjects.Add(tradeObject);
                }
            }

            DisplayGamePlayScreen("Buy", Text.ListTradeObjects(tradeObjects), ActionMenu.TradeMenu, "");

            while (!validObjectId)
            {
                //
                // get an integer from the player
                //
                GetInteger($"Enter the Id number of the object you wish to purchase: ", 0, 0, out tradeObjectId);

                //
                // validate integer as valid game object id in current location
                if (_gameUniverse.IsValidTradeObjectId(tradeObjectId, _gamePlayer.LocationId))
                {
                    GameObject tradeObject = _gameUniverse.GetGameObjectById(tradeObjectId) as GameObject;

                    if (tradeObject.Value <= _gamePlayer.Capital)
                    {
                        validObjectId = true;
                    }
                    else
                    {
                        ClearInputBox();
                        DisplayInputErrorMessage($"It appears you don't have enough capital to purchase the {tradeObject.Name}. Please try again.");
                    }
                }
                else
                {
                    ClearInputBox();
                    DisplayInputErrorMessage("It appears you entered an invalid id. Please try again.");
                }
            }

            return tradeObjectId;

        }

        public void DisplayConfirmPlaceEntered(Place placeEntered)
        {
            DisplayGamePlayScreen($"Enter Place", Text.DisplayEnterPlaceText(placeEntered), ActionMenu.LookAround, "");
        }

        public int DisplayGetPlaceToEnter()
        {
            int placeId = 0;
            bool validPlaceId = false;

            //
            // get a list of place objects in current location
            //
            List<GameObject> gameObjectsInLocation = _gameUniverse.GetGameObjectsByLocationId(_gamePlayer.LocationId);
            List<Place> places = new List<Place>();

            foreach (GameObject gameObject in gameObjectsInLocation)
            {
                if (gameObject is Place)
                {
                    places.Add(gameObject as Place);
                }
            }

            if (places.Count > 0)
            {
                DisplayGamePlayScreen("Enter Place", Text.GamePlaceChooseList(places), ActionMenu.LookAround, "");

                while (!validPlaceId)
                {
                    //
                    // get an integer from the player
                    //
                    GetInteger($"Enter the Id number of the place you wish to enter: ", 0, 0, out placeId);

                    //
                    // validate integer as a valid game object id and in current location
                    //
                    if (_gameUniverse.IsValidPlaceByLocation(placeId, _gamePlayer.LocationId))
                    {
                        Place placeChosen = _gameUniverse.GetGameObjectById(placeId) as Place;
                        
                        if (_gamePlayer.ExperiencePoints >= placeChosen.EnytryPoints)
                        {
                            validPlaceId = true;
                        }
                        else
                        {
                            ClearInputBox();
                            DisplayInputErrorMessage($"You don't have enough experience points to enter {placeChosen.Name}. Please try again.");
                        }
                        
                    }
                    else
                    {
                        ClearInputBox();
                        DisplayInputErrorMessage("It appears you entered an invalid place id. Please try again.");
                    }
                }
            }
            else
            {
                DisplayGamePlayScreen("Enter Place", "It appears there are no places to enter here.", ActionMenu.LookAround, "");
            }

            return placeId;
        }

        #endregion

        #endregion
    }
}
