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
            PlayerInitialization,
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

            _viewStatus = ViewStatus.PlayerInitialization;

            InitializeDisplay();
        }

        #endregion

        #region METHODS

        #region LAYOUT AND SCREEN SETTINGS

        public bool DisplayGameOverScreen()
        {
            bool playing = false;
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
            Console.Write("Press any key to exit.");
            keyPressed = Console.ReadKey();

            return playing;
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
        /// display continue message
        /// </summary>
        /// <param name="prompt"></param>
        public void DisplayContinueMessage(string prompt)
        {
            Console.SetCursorPosition(ConsoleLayout.InputBoxPositionLeft + 4, ConsoleLayout.InputBoxPositionTop + 1);
            Console.ForegroundColor = ConsoleTheme.InputBoxForegroundColor;
            Console.Write(prompt);
            Console.CursorVisible = false;
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

        #endregion

        #region GET ACTIONS

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

            while (userResponse == "")
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
            int maxAttempts = 3;
            int attempt = 0;
            bool maxAttemptsExceed = false;

            //
            // validate on range if either minimumValue and maximumValue are not 0
            //
            bool validateRange = (minimumValue != 0 || maximumValue != 0);

            DisplayInputBoxPrompt(prompt);
            while (!validResponse)
            {
                attempt++;
                if (attempt > maxAttempts)
                {
                    maxAttemptsExceed = true;
                    validResponse = true;
                    ClearInputBox();
                }
                else if (int.TryParse(Console.ReadLine(), out integerChoice))
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

            return maxAttemptsExceed;
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
                string userResponse = UppercaseFirst(Console.ReadLine());
                if (!Enum.TryParse<Player.VikingType>(userResponse, out vikingType))
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
        /// changes string to lowercase with first letter uppercase
        /// adapted from: https://www.dotnetperls.com/uppercase-first-letter
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        static string UppercaseFirst(string s)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            // Return char and concatenation substring.
            return char.ToUpper(s[0]) + s.Substring(1).ToLower();
        }

        #endregion

        #region PLAYER SETUP

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

            bool maxAttemptsExceeded = GetInteger($"Enter your age {player.Name}: ", 0, 1000000, out gamePlayerAge);
            if (maxAttemptsExceeded)
            {
                ClearInputBox();
                DisplayInputErrorMessage("You have exceed your attempts. Your age will be set to 0. Press any key to contine.");
                Console.CursorVisible = false;
                Console.ReadLine();
            }
            player.Age = gamePlayerAge;

            //
            // get palyer's home village
            //
            DisplayGamePlayScreen("The Viking Setup - Home Village", Text.SetupGetPlayerHomeVillage(player), ActionMenu.QuestIntro, "");
            prompt = "Enter the name of the Village: ";
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

        #endregion

        #region MAIN MENU ACTIONS

        #region PLAYER INFO

        /// <summary>
        /// Display player info
        /// </summary>
        public void DisplayPlayerInfo()
        {
            DisplayGamePlayScreen("Viking Information", Text.PlayerInfo(_gamePlayer), ActionMenu.MainMenu, "");
        }

        #endregion

        #region LOOK AROUND ACTIONS

        /// <summary>
        /// Display look around method from the text class
        /// </summary>
        public void DisplayLookAround()
        {
            // get current location
            Location currentLocation = _gameUniverse.GetLocationById(_gamePlayer.LocationId);

            // get list of game objects and list of npcs in location
            List<GameObject> gameObjectsInLocation = _gameUniverse.GetGameObjectsByLocationId(_gamePlayer.LocationId);
            List<NPC> npcObjectsInLocation = _gameUniverse.GetNpcByLocationId(_gamePlayer.LocationId);

            string messageBoxText = Text.CurrrentLocationInfo(currentLocation) + Environment.NewLine + Environment.NewLine;
            messageBoxText += Text.GameObjectsChooseList(gameObjectsInLocation) + Environment.NewLine;
            messageBoxText += Text.NpcsChooseList(npcObjectsInLocation);

            DisplayGamePlayScreen("Look Around", messageBoxText, ActionMenu.LookAround, "");
        }

        #region ITEM ACTIONS

        public void DisplayConfirmWeaponPickedUp(Weapon weapon, string weaponType)
        {
            DisplayGamePlayScreen("Pick Up Item", $"The {weapon.Name} has been added to your inventory and is now your primary {weaponType}.", ActionMenu.ItemMenu, "");
        }

        public void DisplayPickUpObjectTooHeavy(GameObject item)
        {
            DisplayGamePlayScreen("Pick Up Item", $"Your inventory is full, it can't hold the weight of {item.Name}.", ActionMenu.ItemMenu, "");
        }

        /// <summary>
        /// display the information required for the player to choose an object to look at
        /// </summary>
        /// <returns></returns>
        public int DisplayGetGameObjectToLookAt()
        {
            int gameObjectId = 0;
            bool validGamerObjectId = false;
            int attempt = 0;

            //
            // get a list of game objects in the current space-time location
            //
            List<GameObject> gameObjectsInLocation = _gameUniverse.GetGameObjectsByLocationId(_gamePlayer.LocationId);



            if (gameObjectsInLocation.Count >= 0)
            {
                DisplayGamePlayScreen("Look At", Text.GameObjectsChooseList(gameObjectsInLocation), ActionMenu.ItemMenu, "");

                while (!validGamerObjectId)
                {
                    attempt++;

                    if (attempt > 3)
                    {
                        gameObjectId = 0;
                        validGamerObjectId = true;
                        DisplayMaxAttemptsExceeded();
                    }
                    else
                    {
                        //
                        // get an integer from the player
                        //
                        GetInteger($"Enter the Id number of the object you wish to check out: ", 0, 0, out gameObjectId);
                    }

                    if (gameObjectId != 0)
                    {
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
            }
            else
            {
                DisplayGamePlayScreen("Look At", "It appears there is not much here. \nPress any key to continue.", ActionMenu.LookAround, "");
                Console.CursorVisible = false;
                Console.ReadKey();
            }

            return gameObjectId;
        }

        public int DisplayGetGameObjectToPickUp()
        {
            int gameObjectId = 0;
            bool validGameObjectId = false;
            int attempt = 0;

            //
            // get a list of objects in the current location
            //
            List<GameObject> gameObjectsInLocation = _gameUniverse.GetGameObjectsByLocationId(_gamePlayer.LocationId);

            if (gameObjectsInLocation.Count > 0)
            {
                DisplayGamePlayScreen("Pick Up Item", Text.GameObjectsChooseList(gameObjectsInLocation), ActionMenu.ItemMenu, "");

                while (!validGameObjectId)
                {
                    attempt++;
                    if (attempt > 3)
                    {
                        validGameObjectId = true;
                        gameObjectId = 0;
                        DisplayMaxAttemptsExceeded();
                    }
                    else
                    {
                        //
                        // get an integer from the player
                        //
                        GetInteger($"Enter the Id number of the object you wish to add to your inventory: ", 0, 0, out gameObjectId);
                    }

                    if (gameObjectId != 0)
                    {
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
            }
            else
            {
                DisplayGamePlayScreen("Pick Up Item", "It appears there are no game objects here. \nPress any key to continue.", ActionMenu.LookAround, "");
                Console.CursorVisible = false;
                Console.ReadKey();
            }

            return gameObjectId;

        }

        public void DisplayGameObjectInfo(GameObject gameObject)
        {
            DisplayGamePlayScreen("Look at", Text.LookAt(gameObject), ActionMenu.ItemMenu, "");

        }

        public void DisplayConfirmGameObjectAddedToInventory(GameObject objectAdded)
        {
            DisplayGamePlayScreen("Pick Up Item", $"The {objectAdded.Name} has been added to your inventory", ActionMenu.ItemMenu, "");
        }

        public int DisplayGetItemToConsume()
        {
            int gameObjectId = 0;
            bool validObjectId = false;
            int attempt = 0;

            //
            // get a list of objects in the current location
            //
            List<GameObject> gameObjectsInLocation = _gameUniverse.GetGameObjectsByLocationId(_gamePlayer.LocationId);

            if (gameObjectsInLocation.Count > 0)
            {
                List<Item> consumableItems = new List<Item>();

                foreach (GameObject gameObject in gameObjectsInLocation)
                {
                    if (gameObject is Item)
                    {
                        Item item = gameObject as Item;
                        if (item.IsConsumable)
                        {
                            consumableItems.Add(item);
                        }
                    }
                }
                if (consumableItems.Count > 0)
                {
                    DisplayGamePlayScreen("Consume Item", Text.GameObjectsChooseList(consumableItems), ActionMenu.ItemMenu, "");

                    while (!validObjectId)
                    {
                        attempt++;
                        if (attempt > 3)
                        {
                            validObjectId = true;
                            gameObjectId = 0;
                            DisplayMaxAttemptsExceeded();
                        }
                        else
                        {
                            //
                            // get an integer from the player
                            //
                            GetInteger($"Enter the Id number of the object you wish to consume: ", 0, 0, out gameObjectId);
                        }

                        if (gameObjectId != 0)
                        {
                            //
                            // validate integer as valid game object id in current location
                            if (_gameUniverse.IsValidGameObjectByLocationId(gameObjectId, _gamePlayer.LocationId))
                            {
                                Item gameObject = _gameUniverse.GetGameObjectById(gameObjectId) as Item;
                                if (gameObject.IsConsumable)
                                {
                                    validObjectId = true;
                                }
                                else
                                {
                                    ClearInputBox();
                                    DisplayInputErrorMessage($"It appears you may not consume {gameObject.Name}. Please try again.");
                                }
                            }
                            else
                            {
                                ClearInputBox();
                                DisplayInputErrorMessage("It appears you entered an invalid game object id. Please try again.");
                            }
                        }


                    }
                }
                else
                {
                    DisplayGamePlayScreen("Consume Item", "It appears there are no items here that you can consume.", ActionMenu.ItemMenu, "");
                }

            }
            else
            {
                DisplayGamePlayScreen("Consume Item", "It appears there are no game objects here.", ActionMenu.ItemMenu, "");
            }


            return gameObjectId;
        }

        #endregion

        #region NPC ACTIONS

        public void DisplayTradeWillExceedInventoryMaxWeight(GameObject npcObject)
        {
            DisplayGamePlayScreen("Trade", $"Adding the weight of {npcObject.Weight} will be more than your inventory can handle.", ActionMenu.TradeMenu, "");
        }

        public void DisplayInventroyObjectValueNotEnough(GameObject inventoryObject, GameObject npcObject)
        {
            DisplayGamePlayScreen("Trade", $"The value of {inventoryObject.Name} is not enoug to trade for the value of {npcObject.Name}.", ActionMenu.TradeMenu, "");
        }

        public void DisplayConfirmTradeWithNPC(GameObject inventoryObject, GameObject npcObject)
        {
            DisplayGamePlayScreen("Trade", $"You have traded {inventoryObject.Name} for {npcObject.Name} which has now\n" +
                                        "been added to your inventory.", ActionMenu.NpcMenu, "");
        }

        public void DisplayWeaponTraded(Weapon weapon, string weaponType, GameObject npcObject)
        {
            DisplayGamePlayScreen("Trade", $"The {weapon.Name} has been traded for {npcObject.Name}.\n" +
                                $"This was your primary {weaponType}, you are currently don't have a primary {weaponType}.", ActionMenu.NpcMenu, "");
        }

        public void DisplayGetNPCObjectToTrade(GameObject tradeItem)
        {
            DisplayGamePlayScreen("Trade", $"Would you like to buy {tradeItem.Name} for {tradeItem.Value} coins \n" +
                        "or would you like to trade one of the items in your inventory for it?\n" +
                        "\nChoose from the menu options", ActionMenu.TradeMenu, "");
        }

        public void DisplayBattleDefeat(NPC npc, int playerPoints, int opponentPoints)
        {
            DisplayGamePlayScreen("Battle", $"You lost the battle against {npc.Name}.\n" +
                        $"Your points: {playerPoints}\n" +
                        $"{npc.Name}'s points: {opponentPoints}", ActionMenu.MainMenu, "");
        }

        public void DisplayBattleVictory(NPC npc, int playerPoints, int opponentPoints)
        {
            DisplayGamePlayScreen("Battle", $"Congratulations! You won the battle against {npc.Name}.\n" +
                        $"Your points: {playerPoints}\n" +
                        $"{npc.Name}'s points: {opponentPoints}", ActionMenu.LookAround, "");
        }

        public void DisplayNotEnoughCapitalToBuyNPCObject(GameObject npcObject)
        {
            DisplayGamePlayScreen("Trade", $"You don't have enough capital to buy {npcObject.Name}, it will cost you {npcObject.Value} coins, but you\n" +
                            $"only have {_gamePlayer.Capital} coins.", ActionMenu.TradeMenu, "");
        }

        public void DisplayNPCObjectTooHeavyForInevntory(GameObject npcObject)
        {
            DisplayGamePlayScreen("Trade", $"The weight of {npcObject.Name} is too much for your inventory to handle.", ActionMenu.TradeMenu, "");
        }

        public void DisplayBuyObjectFromNPC(GameObject npcObject)
        {
            DisplayGamePlayScreen("Trade", $"You have bought {npcObject.Name} for {npcObject.Value} coins and it has\n" +
                                "been added to your inventory.", ActionMenu.NpcMenu, "");
        }

        public void DisplayListAllNpcObjects()
        {
            DisplayGamePlayScreen("List: Game Characters", Text.ListAllNpcObjects(_gameUniverse.NPCs), ActionMenu.AdminMenu, "");
        }

        public int DisplayGetNpcToTalkTo()
        {
            int npcId = 0;
            bool validNpcId = false;
            int attempt = 0;

            List<NPC> npcsInLocation = _gameUniverse.GetNpcByLocationId(_gamePlayer.LocationId);

            if (npcsInLocation.Count > 0)
            {
                DisplayGamePlayScreen("Choose Character to Speak With", Text.NpcsChooseList(npcsInLocation), ActionMenu.NpcMenu, "");

                while (!validNpcId)
                {
                    attempt++;
                    if (attempt > 3)
                    {
                        npcId = 0;
                        validNpcId = true;
                        DisplayMaxAttemptsExceeded();
                    }
                    else
                    {
                        GetInteger($"Enter the id number of the character: ", 0, 0, out npcId);

                        if (_gameUniverse.IsValidNpcByLocationId(npcId, _gamePlayer.LocationId))
                        {
                            NPC npc = _gameUniverse.GetNpcById(npcId);
                            if (npc is ITalk || npc is Enemy)
                            {
                                validNpcId = true;
                            }
                            else
                            {
                                ClearInputBox();
                                DisplayInputErrorMessage("It appears this character has nothing to say. Please try agian.");
                            }
                        }
                        else
                        {
                            ClearInputBox();
                            DisplayInputErrorMessage("It appears you entered an invalid id. Please try agian.");
                        }
                    }


                }
            }
            else
            {
                DisplayGamePlayScreen("Choose Character to Speak With", "It appears there is noone here.", ActionMenu.NpcMenu, "");
            }

            return npcId;
        }

        public void DisplayTalkTo(NPC npc)
        {
            ITalk speakingNpc = npc as ITalk;

            string message = speakingNpc.Talk();

            if (message == "")
            {
                message = "It appears this character has nothing to say. Please try agian.";
            }

            DisplayGamePlayScreen("Speak to Character", $"{npc.Description}\n" +
                $"{npc.Name}: " + '"' + message + '"', ActionMenu.NpcMenu, "");

        }

        public void DisplayTalkToOpponent(NPC npc)
        {
            IBattle battlingNpc = npc as IBattle;

            string message = battlingNpc.Battle();
            List<Weapon> weapons = new List<Weapon>();
            foreach (var item in _gameUniverse.GameObjects)
            {
                if (item is Weapon)
                {
                    Weapon weapon = item as Weapon;
                    weapons.Add(weapon);
                }
            }
            DisplayGamePlayScreen("Speak to Character", Text.DisplayOpponentInfo(weapons, npc, message), ActionMenu.BattleMenu, "");
        }

        public int DisplayGetNpcToTradeWith()
        {
            int npcId = 0;
            bool validNpcId = false;
            int attempt = 0;

            List<NPC> npcsInLocation = _gameUniverse.GetNpcByLocationId(_gamePlayer.LocationId);

            if (npcsInLocation.Count > 0)
            {
                List<NPC> tradingNPCs = new List<NPC>();
                foreach (NPC npc in npcsInLocation)
                {
                    if (npc.CanTrade)
                    {
                        if (npc.TradeObjects.Count > 0)
                        {
                            tradingNPCs.Add(npc);
                        }

                    }
                }

                if (tradingNPCs.Count > 0)
                {
                    DisplayGamePlayScreen("Choose Person to trade with", Text.NpcsChooseList(tradingNPCs), ActionMenu.TradeMenu, "");

                    while (!validNpcId)
                    {
                        attempt++;
                        if (attempt > 3)
                        {
                            npcId = 0;
                            validNpcId = true;
                            DisplayMaxAttemptsExceeded();
                        }
                        else
                        {
                            GetInteger($"Enter the id number of the character: ", 0, 0, out npcId);

                            if (_gameUniverse.IsValidNpcByLocationId(npcId, _gamePlayer.LocationId))
                            {
                                validNpcId = true;
                            }
                            else
                            {
                                ClearInputBox();
                                DisplayInputErrorMessage("It appears you entered an invalid id. Please try agian.");
                            }
                        }


                    }
                }
                else
                {
                    DisplayGamePlayScreen("Choose Person to Trade With", "It appears there are nobody to trade with here.", ActionMenu.NpcMenu, "");
                }

            }
            else
            {
                DisplayGamePlayScreen("Choose Person to Trade With", "It appears nobody is here.", ActionMenu.NpcMenu, "");
            }

            return npcId;
        }

        public int DisplayChooseNpcItemToTrade(NPC npc)
        {
            int tradeObjectId = 0;
            int attempt = 0;
            bool validObjectId = false;
            List<GameObject> npcTradeObjects = new List<GameObject>();
            foreach (int item in npc.TradeObjects)
            {
                GameObject tradeObject = _gameUniverse.GetGameObjectById(item) as GameObject;
                if (tradeObject != null)
                {
                    npcTradeObjects.Add(tradeObject);
                }
            }

            if (npcTradeObjects.Count > 0)
            {
                DisplayGamePlayScreen("Trade", Text.DisplayChooseNpcItem(npc, npcTradeObjects), ActionMenu.TradeMenu, "");

                while (!validObjectId)
                {
                    attempt++;
                    if (attempt > 3)
                    {
                        tradeObjectId = 0;
                        validObjectId = true;
                        DisplayMaxAttemptsExceeded();
                    }
                    else
                    {
                        //
                        // get an integer from the player
                        //
                        GetInteger($"Enter the Id number of the object you wish to trade: ", 0, 0, out tradeObjectId);
                    }

                    if (tradeObjectId != 0)
                    {
                        //
                        // validate integer as valid game object id in current location
                        if (npc.TradeObjects.Contains(tradeObjectId))
                        {
                            validObjectId = true;

                        }
                        else
                        {
                            ClearInputBox();
                            DisplayInputErrorMessage("It appears you entered an invalid id. Please try again.");
                        }
                    }

                }
            }
            else
            {
                DisplayGamePlayScreen("Trade", $"It appears {npc.Name} doesn't have any items to trade.", ActionMenu.TradeMenu, "");
            }



            return tradeObjectId;
        }

        public int DisplayGetInventoryItemToTrade()
        {
            int gameObjectId = 0;
            bool validObjectId = false;
            int attempt = 0;

            if (_gamePlayer.Inventory.Count > 0)
            {
                DisplayGamePlayScreen("Trade", Text.GameObjectsChooseList(_gamePlayer.Inventory), ActionMenu.TradeMenu, "");


                while (!validObjectId)
                {
                    attempt++;
                    if (attempt > 3)
                    {
                        gameObjectId = 0;
                        validObjectId = true;
                        DisplayMaxAttemptsExceeded();
                    }
                    else
                    {
                        //
                        // get an integer from the player
                        //
                        GetInteger($"Enter the Id number of the object you wish to trade: ", 0, 0, out gameObjectId);
                    }

                    if (gameObjectId != 0)
                    {
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
            }
            else
            {
                DisplayGamePlayScreen("Trade", "You don't have any items to trade. Your inventory is empty.", ActionMenu.TradeMenu, "");
            }


            return gameObjectId;
        }

        #endregion

        #region SHOP MENU ACTIONS

        public void DisplayWeaponSold(Weapon weapon, string weaponType)
        {
            DisplayGamePlayScreen("Shop", $"The {weapon.Name} has been removed from your inventory.\n" +
                                $"This was your primary {weaponType}, you are currently don't have a primary {weaponType}.", ActionMenu.ShopMenu, "");
        }

        public void DisplayWeaponAddedToInventory(Weapon weapon, string weaponType)
        {
            DisplayGamePlayScreen("Shop", $"The {weapon.Name} has been added to your inventory and is now your primary {weaponType}.", ActionMenu.ShopMenu, "");
        }

        public void DisplayWeaponPickedUpToInventory(Weapon weapon, string weaponType)
        {
            DisplayGamePlayScreen("Pick Up Item", $"The {weapon.Name} has been added to your inventory and is now your primary {weaponType}.", ActionMenu.ItemMenu, "");
        }

        public void DisplayObjectTooHeavyForInventory(GameObject tradeObject)
        {
            DisplayGamePlayScreen("Shop", $"Your inventory is full, it can't hold the weight of {tradeObject.Name}.", ActionMenu.ShopMenu, "");
        }

        public void DisplayShop(Location currentLocation)
        {
            DisplayGamePlayScreen("Shop", Text.DisplayTradeScreenText(_gamePlayer.Inventory, currentLocation), ActionMenu.ShopMenu, "");
        }

        public void DisplayConfirmPurchase(GameObject objectAdded)
        {
            DisplayGamePlayScreen("Shop", $"The {objectAdded.Name} has been added to your inventory", ActionMenu.ShopMenu, "");
        }

        public int DisplayGetTradeObjectToSell()
        {
            int tradeObjectId = 0;
            bool validObjectId = false;
            int attempt = 0;

            if (_gamePlayer.Inventory.Count > 0)
            {
                DisplayGamePlayScreen("Sell", Text.DisplayObjectsForSale(_gamePlayer.Inventory), ActionMenu.ShopMenu, "");


                while (!validObjectId)
                {
                    attempt++;
                    if (attempt > 3)
                    {
                        validObjectId = true;
                        tradeObjectId = 0;
                        DisplayMaxAttemptsExceeded();
                    }
                    else
                    {
                        //
                        // get an integer from the player
                        //
                        GetInteger($"Enter the Id number of the object you wish to trade in for money: ", 0, 0, out tradeObjectId);
                    }

                    if (tradeObjectId != 0)
                    {
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
            }
            else
            {
                DisplayGamePlayScreen("Sell", "You don't have any items to sell. Your inventory is empty. \nPress any key to continue,", ActionMenu.ShopMenu, "");
                Console.CursorVisible = false;
                Console.ReadKey();
            }


            return tradeObjectId;

        }

        public void DisplayConfirmSale(GameObject objectAdded)
        {
            DisplayGamePlayScreen("Shop", $"The {objectAdded.Name} has been removed from your inventory.", ActionMenu.ShopMenu, "");
        }

        public int DisplayGetTradeItemToPurchase(Location currentLocation)
        {
            int tradeObjectId = 0;
            bool validObjectId = false;
            int attempt = 0;

            List<GameObject> tradeObjects = new List<GameObject>();
            foreach (int item in currentLocation.TradeObjects)
            {
                if (_gameUniverse.TestValidTradeItemByLocation(item, _gamePlayer.LocationId))
                {
                    GameObject tradeObject = _gameUniverse.GetGameObjectById(item) as GameObject;
                    tradeObjects.Add(tradeObject);
                }
            }

            DisplayGamePlayScreen("Buy", Text.ListTradeObjects(tradeObjects), ActionMenu.ShopMenu, "");

            while (!validObjectId)
            {
                attempt++;
                if (attempt > 3)
                {
                    tradeObjectId = 0;
                    validObjectId = true;
                    DisplayMaxAttemptsExceeded();
                }
                else
                {
                    //
                    // get an integer from the player
                    //
                    GetInteger($"Enter the Id number of the object you wish to purchase: ", 0, 0, out tradeObjectId);
                }

                if (tradeObjectId != 0)
                {
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

            }

            return tradeObjectId;

        }

        #endregion

        #region ENTER PLACE

        public void DisplayConfirmPlaceEntered(Place placeEntered)
        {
            DisplayGamePlayScreen($"Enter Place", Text.DisplayEnterPlaceText(placeEntered), ActionMenu.LookAround, "");
        }

        public int DisplayGetPlaceToEnter()
        {
            int placeId = 0;
            bool validPlaceId = false;
            int attempt = 0;

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
                    attempt++;
                    if (attempt > 3)
                    {
                        placeId = 0;
                        validPlaceId = true;
                        DisplayMaxAttemptsExceeded();
                    }
                    else
                    {
                        //
                        // get an integer from the player
                        //
                        GetInteger($"Enter the Id number of the place you wish to enter: ", 0, 0, out placeId);
                    }

                    if (placeId != 0)
                    {
                        //
                        // validate integer as a valid game object id and in current location
                        //
                        if (_gameUniverse.IsValidPlaceByLocation(placeId, _gamePlayer.LocationId))
                        {
                            Place placeChosen = _gameUniverse.GetGameObjectById(placeId) as Place;

                            if (_gamePlayer.ExperiencePoints >= placeChosen.EntryPoints)
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
            }
            else
            {
                DisplayGamePlayScreen("Enter Place", "It appears there are no places to enter here. \nPress any key to continue.", ActionMenu.LookAround, "");
                Console.CursorVisible = false;
                Console.ReadKey();
            }

            return placeId;
        }

        #endregion

        #endregion

        #region INVENTORY ACTIONS

        public void DisplayItemIsNotWeapon(GameObject gameObject)
        {
            DisplayGamePlayScreen("Current Inventory", $"{gameObject.Name} is not a weapon.", ActionMenu.InventoryMenu, "");
        }

        public void DisplaySetPrimaryWeapon(Weapon weapon, bool isWeapon)
        {
            if (isWeapon)
                DisplayGamePlayScreen("Current Inventory", $"{weapon.Name} is now your primary weapon", ActionMenu.InventoryMenu, "");
            else
                DisplayGamePlayScreen("Current Inventory", $"{weapon.Name} is a shield and can't be your primary weapon.", ActionMenu.InventoryMenu, "");

        }

        public void DisplayItemIsNotShield(GameObject gameObject)
        {
            DisplayGamePlayScreen("Current Inventory", $"{gameObject.Name} is not a shield.", ActionMenu.InventoryMenu, "");
        }

        public void DisplaySetPrimaryShield(Weapon shield, bool isShield)
        {
            if (isShield)
                DisplayGamePlayScreen("Current Inventory", $"{shield.Name} is now your primary shield", ActionMenu.InventoryMenu, "");
            else
                DisplayGamePlayScreen("Current Inventory", $"{shield.Name} is not a shield and can't be your primary shield.", ActionMenu.InventoryMenu, "");

        }


        public void DisplayInventoryItemCannotBeConsumed(GameObject gameObject)
        {
            DisplayGamePlayScreen("Current Inventory", $"{gameObject.Name} cannot be consumed.", ActionMenu.InventoryMenu, "");
        }

        public void DisplayWeaponPutDown(Weapon weapon, string weaponType)
        {
            DisplayGamePlayScreen("Put Down Item", $"The {weapon.Name} has been removed from your inventory.\n" +
                                $"This was your primary {weaponType}, you are currently don't have a primary {weaponType}.", ActionMenu.InventoryMenu, "");
        }

        public int DisplayGetInventoryItemToConsume()
        {
            int gameObjectId = 0;
            bool validObjectId = false;
            int attempt = 0;

            if (_gamePlayer.Inventory.Count > 0)
            {
                DisplayGamePlayScreen("Current Inventory", Text.GameObjectsChooseList(_gamePlayer.Inventory), ActionMenu.InventoryMenu, "");

                while (!validObjectId)
                {
                    attempt++;
                    if (attempt > 3)
                    {
                        gameObjectId = 0;
                        validObjectId = true;
                        DisplayMaxAttemptsExceeded();
                    }
                    else
                    {
                        //
                        // get an integer from the player
                        //
                        GetInteger($"Enter the Id number of the item you wish to consume: ", 0, 0, out gameObjectId);
                    }

                    if (gameObjectId != 0)
                    {
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
            }
            else
            {
                DisplayGamePlayScreen("Current Inventory", "You don't have any items to consume. Your inventory is empty. \n Press any key to continue.", ActionMenu.InventoryMenu, "");
                Console.CursorVisible = false;
                Console.ReadKey();
            }

            return gameObjectId;
        }

        public int DisplayGetWeapon()
        {
            int gameObjectId = 0;
            bool validObjectId = false;
            int attempt = 0;

            if (_gamePlayer.Inventory.Count > 0)
            {
                DisplayGamePlayScreen("Current Inventory", Text.GameObjectsChooseList(_gamePlayer.Inventory), ActionMenu.InventoryMenu, "");

                while (!validObjectId)
                {
                    attempt++;
                    if (attempt > 3)
                    {
                        gameObjectId = 0;
                        validObjectId = true;
                        DisplayMaxAttemptsExceeded();
                    }
                    else
                    {
                        //
                        // get an integer from the player
                        //
                        GetInteger($"Enter the Id number for the weapon you want to be your primary: ", 0, 0, out gameObjectId);
                    }

                    if (gameObjectId != 0)
                    {
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
            }
            else
            {
                DisplayGamePlayScreen("Current Inventory", "You don't have any weapons. \n Press any key to continue.", ActionMenu.InventoryMenu, "");
                Console.CursorVisible = false;
                Console.ReadKey();
            }

            return gameObjectId;
        }

        public int DisplayGetGameObjectToPutDown()
        {
            int gameObjectId = 0;
            bool validObjectId = false;
            int attempt = 0;

            if (_gamePlayer.Inventory.Count > 0)
            {
                DisplayGamePlayScreen("Put Down Item", Text.GameObjectsChooseList(_gamePlayer.Inventory), ActionMenu.InventoryMenu, "");


                while (!validObjectId)
                {
                    attempt++;
                    if (attempt > 3)
                    {
                        gameObjectId = 0;
                        validObjectId = true;
                        DisplayMaxAttemptsExceeded();
                    }
                    else
                    {
                        //
                        // get an integer from the player
                        //
                        GetInteger($"Enter the Id number of the object you wish to put down: ", 0, 0, out gameObjectId);
                    }

                    if (gameObjectId != 0)
                    {
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
            }
            else
            {
                DisplayGamePlayScreen("Put Down Item", "You don't have any items to put down. Your inventory is empty.", ActionMenu.InventoryMenu, "");
            }


            return gameObjectId;

        }

        public void DisplayInventory()
        {
            if (_gamePlayer.Inventory.Count <= 0)
            {
                DisplayGamePlayScreen("Current Inventory", "You currently have no items in your inventory", ActionMenu.InventoryMenu, "");
            }
            else
            {
                DisplayGamePlayScreen("Current Inventory", Text.CurrentInventory(_gamePlayer), ActionMenu.InventoryMenu, "");
            }

        }

        public void DisplayInventoryObjectInfo(GameObject gameObject)
        {
            DisplayGamePlayScreen("Inventory", Text.LookAt(gameObject), ActionMenu.InventoryMenu, "");

        }

        public int DisplayGetInventoryObjectToLookAt()
        {
            int inventoryObjectId = 0;
            bool validInventoryObjectId = false;
            int attempt = 0;

            //
            // get a list of all objects in inventory
            //
            List<GameObject> gameObjectsInInventory = _gamePlayer.Inventory;

            if (gameObjectsInInventory.Count > 0)
            {
                while (!validInventoryObjectId)
                {
                    attempt++;

                    if (attempt > 3)
                    {
                        inventoryObjectId = 0;
                        validInventoryObjectId = true;
                        DisplayMaxAttemptsExceeded();
                    }
                    else
                    {
                        //
                        // get an integer from the player
                        //
                        GetInteger($"Enter the Id number of the object you wish to look at: ", 0, 0, out inventoryObjectId);
                    }

                    if (inventoryObjectId != 0)
                    {
                        GameObject inventoryObject = _gameUniverse.GetGameObjectById(inventoryObjectId) as GameObject;
                        //
                        // validate integer as a valid game object id and in current location
                        //
                        if (_gamePlayer.Inventory.Contains(inventoryObject))
                        {
                            validInventoryObjectId = true;
                        }
                        else
                        {
                            ClearInputBox();
                            DisplayInputErrorMessage("It appears you entered an invalid game object id. Please try again.");
                        }
                    }

                }
            }
            else
            {
                DisplayGamePlayScreen("Current Inventory", "There are no items in your inventory.", ActionMenu.InventoryMenu, "");
                Console.CursorVisible = false;
                Console.ReadKey();
            }

            return inventoryObjectId;
        }

        public void DisplayConsumeItem(Item consumedItem)
        {
            if (ActionMenu.currentMenu == ActionMenu.CurrentMenu.ItemMenu)
            {
                DisplayGamePlayScreen("Consume Item", $"You have consumed {consumedItem.Name}, and have gained {consumedItem.Health} health points.", ActionMenu.ItemMenu, "");
            }
            else
            {
                DisplayGamePlayScreen("Look at Object", $"You have consumed {consumedItem.Name}, and have gained {consumedItem.Health} health points.", ActionMenu.InventoryMenu, "");
            }

        }

        public void DisplayConfirmItemRemovedFromInventory(GameObject gameObject)
        {
            DisplayGamePlayScreen("Put Down Item", $"The {gameObject.Name} has been removed from your invnetory.", ActionMenu.InventoryMenu, "");
        }

        #endregion

        #region TRAVEL ACTIONS

        /// <summary>
        /// Get the next location ID from the player
        /// </summary>
        /// <returns></returns>
        public int DisplayGetLocation()
        {
            int locationId = 0;
            bool validLocationId = false;
            int attempt = 0;

            DisplayGamePlayScreen("Travel to a new location", Text.Travel(_gamePlayer, _gameUniverse.Locations), ActionMenu.MainMenu, "");

            while (!validLocationId)
            {
                attempt++;
                if (attempt > 3)
                {
                    validLocationId = true;
                    locationId = _gamePlayer.LocationId;
                    DisplayMaxAttemptsExceeded();
                }
                else
                {
                    //
                    // get integer from user
                    //
                    GetInteger("Enter the new location: ", 1, _gameUniverse.GetMaxLocationID(), out locationId);
                }

                //
                // validate the locationID and determine accesability
                //
                if (_gameUniverse.IsValidLocationId(locationId))
                {
                    if (_gameUniverse.IsAccessibleLocation(locationId, _gamePlayer))
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

        #endregion

        #region ADMIN ACTIONS

        #region EDIT ACTIONS

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

        #endregion

        #region LIST ACTIONS

        /// <summary>
        /// Display List of all locations
        /// </summary>
        public void DisplayListOfLocations()
        {
            DisplayGamePlayScreen("List: Locations", Text.ListLocations(_gameUniverse.Locations), ActionMenu.AdminMenu, "");
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
            foreach (int locationId in _gamePlayer.LocationsVisted)
            {
                locationsVisited.Add(_gameUniverse.GetLocationById(locationId));
            }

            DisplayGamePlayScreen("Locations you have visited", Text.VisitedLocations(locationsVisited), ActionMenu.AdminMenu, "");
        }

        /// <summary>
        /// display list of game objects in the universe
        /// </summary>
        public void DisplayListGameObjects()
        {
            DisplayGamePlayScreen("List Game Objects", "Choose from the menu options", ActionMenu.ListGameObjectsMenu, "");
        }

        public void DisplayListWeapons()
        {
            DisplayGamePlayScreen("List: Weapons", Text.ListWeapons(_gameUniverse.GameObjects), ActionMenu.ListGameObjectsMenu, "");
        }

        public void DisplayListTreasures()
        {
            DisplayGamePlayScreen("List: Treasures", Text.ListTreasures(_gameUniverse.GameObjects), ActionMenu.ListGameObjectsMenu, "");
        }

        public void DisplayListItems()
        {
            DisplayGamePlayScreen("List: Items", Text.ListItems(_gameUniverse.GameObjects), ActionMenu.ListGameObjectsMenu, "");
        }

        public void DisplayListPlaces()
        {
            DisplayGamePlayScreen("List: Places", Text.ListPlaces(_gameUniverse.GameObjects), ActionMenu.ListGameObjectsMenu, "");
        }

        #endregion

        #endregion

        #endregion

        #region OTHER ACTIONS


        public void DisplayClosingScreen(Player player)
        {
            DisplayGamePlayScreen("Exiting Game", Text.DisplayClosingScreenText(player), ActionMenu.QuestIntro, "");
            GetContinueKey();
        }

        public void DisplayMaxAttemptsExceeded()
        {
            DisplayInputErrorMessage("You have exceeded your maximum attempts. Press any key to continue.                                                                  ");
            Console.CursorVisible = false;
            Console.ReadKey();
        }

        public void DisplayNewLevelMessage()
        {
            DisplayInputBoxPrompt("New level reached! Press any key to continue.");
            Console.CursorVisible = false;
            Console.ReadKey();
            ClearInputBox();
            DisplayGamePlayScreen("New Level Reached", Text.NewLevelMessage(_gamePlayer), ActionMenu.MainMenu, "");
        }


        #endregion

        
        #endregion

    }
}
