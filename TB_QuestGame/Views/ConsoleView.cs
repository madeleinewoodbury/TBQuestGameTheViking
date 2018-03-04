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

            DisplayInputBoxPrompt(prompt);
            while (!validResponse)
            {
                if (int.TryParse(Console.ReadLine(), out integerChoice))
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
        /// get type of weapon from user
        /// </summary>
        /// <returns></returns>
        public Player.Weapon GetWeapon()
        {
            bool validInput = false;
            Player.Weapon weaponType = Player.Weapon.None;

            while (!validInput)
            {
                if (!Enum.TryParse<Player.Weapon>(Console.ReadLine(), out weaponType))
                {
                    ClearInputBox();
                    DisplayInputErrorMessage("You need to enter the name of a weapon. Please try again");
                    DisplayInputBoxPrompt("Enter weapon: ");
                }
                else
                {
                    validInput = true;
                }
            }


            return weaponType;
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

            // instantiate a new list of weapons
            player.WeaponType = new List<Player.Weapon>();

            //instantiate a new waeapon
            Player.Weapon weaponType;

            // isArmed is set to false to begin with
            player.IsArmed = false;

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
            DisplayInputBoxPrompt("Enter Shieldmaiden or Karl: ");
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
            // Player's capital. Prompt for purchase of weapon
            // Starting capital is 100 coins
            player.Capital = 100;
            DisplayGamePlayScreen("The Viking Setup - Capital", Text.DisplayPlayerStartingCapital(player), ActionMenu.QuestIntro, "");
            DisplayInputBoxPrompt("Enter yes or no: ");
            string userResponse = GetYesOrNo();

            if (userResponse == "YES")
            {
                DisplayGamePlayScreen("The Viking Setup - Purchase Weapon", Text.DisplayPlayerPurchaseWeapon(player), ActionMenu.QuestIntro, "");
                DisplayInputBoxPrompt("Enter weapon: ");
                weaponType =GetWeapon();

                if (weaponType != Player.Weapon.None)
                {
                    // subtract 25 coins from the player's capital
                    player.Capital -= 25;
                    player.IsArmed = true;
                    player.WeaponType.Add(weaponType);
                }
                else
                {
                    player.IsArmed = false;
                }
            }
            else
            {
                weaponType = Player.Weapon.None;
                player.IsArmed = false;
            }

            //
            // echo the player's info
            //
            DisplayGamePlayScreen("The Viking Setup - Complete", Text.SetupEchoPlayerInfo(player), ActionMenu.QuestIntro, "");
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
            DisplayGamePlayScreen("List: Locations", Text.ListLocations(_gameUniverse.Locations), ActionMenu.MainMenu, "");
        }

        /// <summary>
        /// Display look around method from the text class
        /// </summary>
        public void DisplayLookAround()
        {
            Location currentLocation = _gameUniverse.GetLocationById(_gamePlayer.LocationId);
            DisplayGamePlayScreen("Current Location", Text.LookAround(currentLocation), ActionMenu.MainMenu, "");
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
                    if (_gameUniverse.IsAccessibleLocation(locationId))
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

            DisplayGamePlayScreen("Edit Viking Info", Text.PlayerInfo(player), ActionMenu.EditPlayer, "");
            PlayerAction playerMenuEditChoice = GetActionMenuChoice(ActionMenu.EditPlayer);

            return playerMenuEditChoice;
        }

        /// <summary>
        /// Edit Player Name
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public Player DisplayEditName(Player player)
        {
            DisplayGamePlayScreen("Edit Viking Info - Name", Text.SetuoGetPlayerName(), ActionMenu.EditPlayer, "");
            string prompt = "Enter your name: ";
            player.Name = GetString(prompt);
            return player;
        }

        /// <summary>
        /// Edit Player Gender
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public Player DisplayEditGender(Player player)
        {
            DisplayGamePlayScreen("Edit Viking Info - Gender", Text.EditGetPlayerGender(player), ActionMenu.EditPlayer, "");
            DisplayInputBoxPrompt("Enter Shieldmaiden or Karl: ");
            player.Viking = GetVikingType();
            return player;
        }

        /// <summary>
        /// Edit Player Age
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public Player DisplayEditAge(Player player)
        {
            DisplayGamePlayScreen("The Viking Setup - Age", Text.SetupGetPlayerAge(player), ActionMenu.EditPlayer, "");
            int gamePlayerAge;

            GetInteger($"Enter your age {player.Name}: ", 0, 1000000, out gamePlayerAge);
            player.Age = gamePlayerAge;
            return player;
        }

        /// <summary>
        /// Edit Player Home Village
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public Player DisplayEditHomeVillage(Player player)
        {
            DisplayGamePlayScreen("The Viking Setup - Home Village", Text.SetupGetPlayerHomeVillage(player), ActionMenu.EditPlayer, "");
            string prompt = "Enter the name of the Village: ";
            player.HomeVillage = GetString(prompt);
            return player;
        }

        /// <summary>
        /// Purchase Weapon
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public Player DisplayPurchaseWeapon(Player player)
        {
            if (player.Capital < 25)
            {
                DisplayGamePlayScreen("Edit Viking Info - Weapons", Text.DisplayNotEnoughCapital(player), ActionMenu.EditPlayer, "");
                GetContinueKey();
            }
            else
            {
                DisplayGamePlayScreen("Edit Viking Info - Weapons", Text.DisplayPlayerPurchaseWeapon(player), ActionMenu.EditPlayer, "");
                DisplayInputBoxPrompt("Enter weapon: ");
                Player.Weapon weaponType = GetWeapon();

                if (weaponType != Player.Weapon.None)
                {
                    // subtract 25 coins from the player's capital
                    player.Capital -= 25;
                    player.WeaponType.Add(weaponType);
                    player.IsArmed = true;
                }
            }


            return player;
        }

        public void DisplayClosingScreen(Player player)
        {
            DisplayGamePlayScreen("Exiting Game", Text.DisplayClosingScreenText(player), ActionMenu.QuestIntro, "");
            GetContinueKey();
        }
        #endregion

        #endregion
    }
}
