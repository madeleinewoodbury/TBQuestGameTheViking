using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace TB_QuestGame
{
    /// <summary>
    /// class to store static and to generate dynamic text for the message and input boxes
    /// </summary>
    public static class Text
    {
        public static List<string> HeaderText = new List<string>() { "The Viking" };
        public static List<string> FooterText = new List<string>() { "Woodbury Productions" };

        #region INTITIAL GAME SETUP

        /// <summary>
        /// Welcome screen and game intro
        /// </summary>
        /// <returns></returns>
        public static string QuestIntro()
        {
            string messageBoxText =
            "Welcome to Fylkirfold, the world of kings. \n" +
            "Here, only the toughest and bravest Vikings will thrive. \n" +
            "Your quest is to climb the ranks to become the King of the Vikings. \n" +
            "But be warned, the road to the top is hard, and you will have to encouter battles,\n" +
            "both at home and overseas.\n" +
            " \n" +
            "If you don't think you have what it takes, then this is not the place for you. \n" +
            " \n" +
            "Your quest begins now. \n" +
            " \n" +
            "\tYour first task will be to channel your inner viking and setup your character." +
            " \n" +
            "\tPress any key to begin.\n";

            return messageBoxText;
        }

        /// <summary>
        /// Setup intro screen
        /// </summary>
        /// <returns></returns>
        public static string SetupIntro()
        {
            string messageBoxText =
                "Before you start your journey, we need some infromation from you to get your viking ready for battle.\n" +
                " \n" +
                "You will be prompted for the required information. Please enter the information below.\n" +
                " \n" +
                "\tPress any key to begin.";

            return messageBoxText;
        }

        /// <summary>
        /// Set-up the player's name
        /// </summary>
        /// <returns></returns>
        public static string SetuoGetPlayerName()
        {
            string messageBoxText =
                "Enter your viking name.\n" +
                " \n" +
                "Please use the name you wish to be referred during your quest.";

            return messageBoxText;
        }

        /// <summary>
        /// Set-up the player's gender: Karl or Shieldmaiden
        /// </summary>
        /// <param name="gamePlayer"></param>
        /// <returns></returns>
        public static string SetupGetPlayerGender(Player gamePlayer)
        {
            string messageBoxText =
                $"Very good then, we will call you {gamePlayer.Name} from here on out. \n" +
                "We know you are a true viking, but we need to know your gender. \n" +
                " \n" +
                "Are you a Karl or a Shieldmaiden? \n" +
                " \n" +
                "Enter which one you identfy with: \n" +
                " \n" +
                "\t1. Karl\n" +
                "\t2. Shieldmaiden";

            return messageBoxText;
        }

        /// <summary>
        /// Set-up the player's age
        /// </summary>
        /// <param name="gamePlayer"></param>
        /// <returns></returns>
        public static string SetupGetPlayerAge(Player gamePlayer)
        {
            string messageBoxText =
                $"Alright, {gamePlayer.Viking} {gamePlayer.Name}, now we need to know your viking years. \n" +
                " \n" +
                "Enter your age below.\n" +
                " \n" +
                "Please use the standard Earth year as your reference.";

            return messageBoxText;
        }

        /// <summary>
        /// Set-up the player's home village
        /// </summary>
        /// <param name="gamePlayer"></param>
        /// <returns></returns>
        public static string SetupGetPlayerHomeVillage(Player gamePlayer)
        {
            string messageBoxText =
                $"{gamePlayer.Name}, we need to know what village you are from." +
                " \n" +
                "Enter the name of your home village below.";

            return messageBoxText;
        }

        /// <summary>
        /// Set-up complete: Displays player infor
        /// </summary>
        /// <param name="gamePlayer"></param>
        /// <returns></returns>
        public static string SetupEchoPlayerInfo(Player gamePlayer)
        {
            string messageBoxText =
                $"Very good then {gamePlayer.Name}.\n" +
                " \n" +
                "It appears we have all the necessary info to begin your journey. You will find it" +
                " listed below.\n" +
                " \n" +
                $"\tViking Name: {gamePlayer.Name}\n" +
                $"\tGender: {gamePlayer.Viking}\n" +
                $"\tViking Years: {gamePlayer.Age}\n" +
                $"\tHome Village: {gamePlayer.HomeVillage}\n" +
                $"\tStarting capital: {gamePlayer.Capital} coins\n" +
                "\tWeapon: You are currently unarmed\n" +
                "\t Shield: You are currently unshielded.\n" +
                "\n" +
                "NOTE: You are staring the game without any weapons, you need to either visit a shop to purchase weapons or trade with another game character. \n" +
                "\n \n Press any key to begin your mission.";

            return messageBoxText;
        }

        #endregion

        #region MAIN MENU

        /// <summary>
        /// Display current location. Screen shows when player enters Looking Around
        /// </summary>
        /// <param name="currentLocation"></param>
        /// <returns></returns>
        public static string CurrrentLocationInfo(Location currentLocation)
        {
            string messageBoxText =
            $"You are located in {currentLocation.LocationName}\n" +
            "Here is what you will find here:";

            return messageBoxText;
        }

        /// <summary>
        /// Displays player info
        /// </summary>
        /// <param name="gamePlayer"></param>
        /// <returns></returns>
        public static string PlayerInfo(Player gamePlayer)
        {
            string messageBoxText =
                $"\tViking Name: {gamePlayer.Name}\n" +
                $"\tGender: {gamePlayer.Viking}\n" +
                $"\tViking Years: {gamePlayer.Age}\n" +
                $"\tHome Village: {gamePlayer.HomeVillage}\n" +
                $"\tCapital: {gamePlayer.Capital} coins\n";

            string weaponInfo;

            if (gamePlayer.IsArmed)
            {
                weaponInfo = $"\tPrimary Weapon: {gamePlayer.PrimaryWeapon.Name}\n";
            }
            else
            {
                weaponInfo = "\tPrimary Weapon: You are currently unarmed\n";
            }

            messageBoxText += weaponInfo;

            string shieldInfo;

            if (gamePlayer.IsShielded)
            {
                shieldInfo = $"\tPrimary Shield: {gamePlayer.PrimaryShield.Name}";
            }
            else
            {
                shieldInfo = "\tPrimary Shield: You don't have a shield.";
            }

            messageBoxText += shieldInfo;

            return messageBoxText;
        }

        /// <summary>
        /// Displays current location with description
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public static string LookAround(Location location)
        {
            string messageTextBox =
                $"Current location: {location.LocationName}\n" +
                " \n" + location.Description;

            return messageTextBox;
        }

        /// <summary>
        /// Display travel options
        /// </summary>
        /// <param name="gamePlayer"></param>
        /// <param name="locations"></param>
        /// <returns></returns>
        public static string Travel(Player gamePlayer, List<Location> locations)
        {
            string messageTextBox =
                $"{gamePlayer.Name}, where would you like to travel to. \n" +
                " \n" +
                "Enter the ID of your next location. \n" +
                " \n" +

                 //
                 // display table header
                 //
                 "ID".PadRight(10) + "Name".PadRight(20) + "Region".PadRight(15) + "Level Needed".PadRight(10) + "\n" +
                 "---".PadRight(10) + "-----------------".PadRight(20) +"---------".PadRight(15) + "------------".PadRight(10) + "\n";

            //
            // display all locations besides the current
            //
            string locationList = null;
            foreach (Location location in locations)
            {
                // checks if the location's accesaable locations includes current location ID
                if (location.AccessableLocations.Contains(gamePlayer.LocationId))
                {
                    if (location.LocationId != gamePlayer.LocationId)
                    {
                        locationList +=
                        $"{location.LocationId}".PadRight(10) +
                        $"{location.LocationName}".PadRight(20) +
                        $"{location.Region}".PadRight(15) +
                        $"level {location.LevelNeeded}".PadRight(10) +
                        Environment.NewLine;

                    }
                }

            }

            messageTextBox += locationList;

            return messageTextBox;

        }

        /// <summary>
        /// Display list of game objects to choose from
        /// </summary>
        /// <param name="gameObjects"></param>
        /// <returns></returns>
        public static string GameObjectsChooseList(IEnumerable<GameObject> gameObjects)
        {
            //
            // display table name and column headers
            //
            string messageBoxText =
                "Game Objects\n" +
                " \n" +

                //
                // display table header
                //
                "ID".PadRight(10) +
                "Name".PadRight(40) + 
                "Value".PadRight(10) + "\n" +
                "---".PadRight(10) +
                "----------------------".PadRight(40) + 
                "------".PadRight(10) + "\n";

            //
            // display all traveler objects in rows
            //
            string gameObjectRows = null;
            foreach (GameObject gameObject in gameObjects)
            {
                gameObjectRows +=
                    $"{gameObject.Id}".PadRight(10) +
                    $"{gameObject.Name}".PadRight(40) +
                    $"{gameObject.Value}".PadRight(10) +
                    Environment.NewLine;
            }

            messageBoxText += gameObjectRows;

            return messageBoxText;
        }

        /// <summary>
        /// Display current inventory information
        /// </summary>
        /// <param name="inventory"></param>
        /// <returns></returns>
        public static string CurrentInventory(Player player)
        {
            string messageBoxText = "\n" +
                "Inventory max weight capacity: 50 kg \n" +
                $"Current weight: {player.InventoryWeight} kg\n" +
                "\n ";


            //
            // display table header
            //
            messageBoxText += "\n" +
                "ID".PadRight(10) +
                "Name".PadRight(35) +
                "Value".PadRight(10) +
                "Weight".PadRight(10) +
                "\n" +
                "---".PadRight(10) +
                "-----------------------------".PadRight(35) +
                "------".PadRight(10) +
                "------".PadRight(10) +
                "\n";

            //
            // display all traveler objects in rows
            //
            string inventoryObjectRows = null;
            foreach (GameObject inventoryObject in player.Inventory)
            {
                inventoryObjectRows +=
                $"{inventoryObject.Id}".PadRight(10) +
                $"{inventoryObject.Name}".PadRight(35) +
                $"{inventoryObject.Value}".PadRight(10) +
                $"{inventoryObject.Weight} kg".PadRight(10) +
                Environment.NewLine;

            }

            messageBoxText += inventoryObjectRows;

            return messageBoxText;
        }

        /// <summary>
        /// Display closing screen
        /// </summary>
        /// <param name="gamePlayer"></param>
        /// <returns></returns>
        public static string DisplayClosingScreenText(Player gamePlayer)
        {
            string messageBox = 
                $"Thank you for playing The Viking {gamePlayer.Name}. \n" +
                "We at Woodbury Productions hope that you have enjoyed the game. \n" +
                "We wish you all the best in your future quests. \n" +
                " \n" +
                "\tPress any key to exit the game.";

            return messageBox;
        }


        #endregion

        #region LOOK AROUND MENU

        /// <summary>
        /// Display list of NPCs to choose from
        /// </summary>
        /// <param name="npcs"></param>
        /// <returns></returns>
        public static string NpcsChooseList(IEnumerable<NPC> npcs)
        {
            string messageBoxText =
                "NPCs\n" +
                " \n" +

                "ID".PadRight(10) +
                "Name".PadRight(30) + "\n" +
                "---".PadRight(10) +
                "------------------------".PadRight(30) + "\n";

            string npcObjectRows = null;
            foreach (NPC npcObject in npcs)
            {
                npcObjectRows +=
                    $"{npcObject.Id}".PadRight(10) +
                    $"{npcObject.Name}".PadRight(30) +
                    Environment.NewLine;
            }

            messageBoxText += npcObjectRows;


            return messageBoxText;
        }

        /// <summary>
        /// Display look at object information
        /// </summary>
        /// <param name="gameObject"></param>
        /// <returns></returns>
        public static string LookAt(GameObject gameObject)
        {
            string messageBoxText = "";

            messageBoxText =
                $"{gameObject.Name}\n" +
                " \n" +
                gameObject.Description + " \n" +
                " \n";

            if (gameObject is Item)
            {
                Item item = gameObject as Item;

                messageBoxText += $"The {item.Name} has a value of {item.Value} and ";

            }
            else if (gameObject is Treasure)
            {
                Treasure treasure = gameObject as Treasure;

                messageBoxText += $"The {treasure.Name} has a value of {treasure.Value} and ";

            }
            else if (gameObject is Weapon)
            {
                Weapon weapon = gameObject as Weapon;

                messageBoxText += $"The {weapon.Name} has a value of {weapon.Value} and ";

            }

            return messageBoxText;
        }

        /// <summary>
        /// Display trade screen when the player enters the shop
        /// </summary>
        /// <param name="inventory"></param>
        /// <param name="currentLocation"></param>
        /// <returns></returns>
        public static string DisplayTradeScreenText(IEnumerable<GameObject> inventory, Location currentLocation)
        {
            string messageBoxText = "";

            //
            // display table header
            //
            messageBoxText =
                $"Here in {currentLocation.LocationName}, you can trade in your valuables for coins or you can purchase items from the shop. \n" +
                "The question is...do you wish to buy or sell? \n" +
                " \n" +
                "Here is your current Inventory: \n" +
                " \n" +
                "ID".PadRight(10) +
                "Name".PadRight(40) +
                "Value".PadRight(10) +
                "\n" +
                "---".PadRight(10) +
                "-----------------------------".PadRight(40) +
                "---".PadRight(10) +
                "\n";

            //
            // display all traveler objects in rows
            //
            string inventoryObjectRows = null;
            foreach (GameObject inventoryObject in inventory)
            {
                inventoryObjectRows +=
                $"{inventoryObject.Id}".PadRight(10) +
                $"{inventoryObject.Name}".PadRight(40) +
                $"{inventoryObject.Value}".PadRight(10) +
                Environment.NewLine;

            }

            messageBoxText += inventoryObjectRows;
            return messageBoxText;
        }
       
        /// <summary>
        /// List objects that the player can purchase
        /// </summary>
        /// <param name="tradeObjects"></param>
        /// <returns></returns>
        public static string ListTradeObjects(IEnumerable<GameObject> tradeObjects)
        {
            //
            // display table name and column headers
            //
            string messageBoxText =
                "Available Items for Purchases\n" +
                " \n" +

                //
                // display table header
                //
                "ID".PadRight(10) +
                "Name".PadRight(40) +
                "Value".PadRight(10) + "\n" +
                "---".PadRight(10) +
                "----------------------".PadRight(40) +
                "---".PadRight(10) + "\n";

            //
            // display all traveler objects in rows
            //
            string gameObjectRows = null;
            foreach (GameObject tradeObject in tradeObjects)
            {
                gameObjectRows +=
                    $"{tradeObject.Id}".PadRight(10) +
                    $"{tradeObject.Name}".PadRight(40) +
                    $"{tradeObject.Value}".PadRight(10) +
                    Environment.NewLine;
            }

            messageBoxText += gameObjectRows;

            return messageBoxText;
        }

        /// <summary>
        /// Display items in inventory that the player can sell
        /// </summary>
        /// <param name="inventory"></param>
        /// <returns></returns>
        public static string DisplayObjectsForSale(IEnumerable<GameObject> inventory)
        {
            string messageBoxText = "";

            //
            // display table header
            //
            messageBoxText =
                "Your current Inventory and their trade value: \n" +
                " \n" +
                "ID".PadRight(10) +
                "Name".PadRight(40) +
                "Value".PadRight(10) +
                "\n" +
                "---".PadRight(10) +
                "-----------------------------".PadRight(40) +
                "---".PadRight(10) +
                "\n";

            //
            // display all traveler objects in rows
            //
            string inventoryObjectRows = null;
            foreach (GameObject inventoryObject in inventory)
            {
                inventoryObjectRows +=
                $"{inventoryObject.Id}".PadRight(10) +
                $"{inventoryObject.Name}".PadRight(40) +
                $"{inventoryObject.Value}".PadRight(10) +
                Environment.NewLine;

            }

            messageBoxText += inventoryObjectRows;
            return messageBoxText;
        }

        /// <summary>
        /// Display list of places that can be entered to choose from
        /// </summary>
        /// <param name="gameObjects"></param>
        /// <returns></returns>
        public static string GamePlaceChooseList(IEnumerable<GameObject> gameObjects)
        {
            //
            // display table name and column headers
            //
            string messageBoxText =
                "Choose from the list below\n" +
                " \n" +

                //
                // display table header
                //
                "ID".PadRight(10) +
                "Name".PadRight(40) + 
                "Entry Points".PadRight(10) + "\n" +
                "---".PadRight(10) +
                "---------------------------".PadRight(40) + 
                "-------------".PadRight(10) + "\n";

            //
            // display all game objects in rows
            //
            string gameObjectRows = null;
            List<Place> placeObjects = new List<Place>();
            foreach (GameObject gameObject in gameObjects)
            {
                if (gameObject is Place)
                {
                    placeObjects.Add(gameObject as Place);
                }
                
            }

            foreach (Place place in placeObjects)
            {
                gameObjectRows +=
                $"{place.Id}".PadRight(10) +
                $"{place.Name}".PadRight(40) +
                $"{place.EntryPoints}".PadRight(10) +
                Environment.NewLine;
            }

            messageBoxText += gameObjectRows;

            return messageBoxText;
        }

        /// <summary>
        /// Display place enetered screen
        /// </summary>
        /// <param name="placeEntered"></param>
        /// <returns></returns>
        public static string DisplayEnterPlaceText(Place placeEntered)
        {
            string messageBoxText = placeEntered.EntryMessage;

            if (placeEntered.CanEeat)
            {
                messageBoxText += $"You have gained {placeEntered.Health} health points here. \n";
            }
            if (placeEntered.CanTrain)
            {
                messageBoxText += $"You have gained {placeEntered.ExperiencePoints} experience points here. \n";
            }
            if (placeEntered.CanRest)
            {
                messageBoxText += $"Your energy level is back up. You are fully rested. \n";
            }

            return messageBoxText;
        }

        /// <summary>
        /// Display info about an opponent NPC
        /// </summary>
        /// <param name="weapons"></param>
        /// <param name="npc"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static string DisplayOpponentInfo(IEnumerable<Weapon> weapons, NPC npc, string message)
        {
            string messageBoxText = $"{npc.Name} is not a friend of yours and is prepared to fight you. \n" + Environment.NewLine;

            if (npc is Enemy)
            {
                Enemy opponent = npc as Enemy;


                if (message != null)
                {
                    messageBoxText += $"\n{npc.Name}: " + '"' + message + '"' + "\n";
                }

                string weapon = "None";
                string shield = "None";
                foreach (var item in weapons)
                {
                    if (item.Id == opponent.PrimaryWeapon)
                    {
                        weapon = item.Name;
                    }
                    else if(item.Id == opponent.PrimaryShield)
                    {
                        shield = item.Name;
                    }
                }

                string opponentInfo = $"Viking Rank: {opponent.VikingRank.ToString()}\n" +
                    $"Weapon: {weapon}\n" +
                    $"Shield: {shield}\n";


                messageBoxText += opponentInfo;
            }

            return messageBoxText;
                
        }

        /// <summary>
        /// Display list of NPCs to choose from
        /// </summary>
        /// <param name="npc"></param>
        /// <param name="tradeObjects"></param>
        /// <returns></returns>
        public static string DisplayChooseNpcItem(NPC npc, IEnumerable<GameObject> tradeObjects)
        {
            string messageBoxText = $"Here are the items {npc.Name} are willing to trade you: \n" +
                "\n" +

            //
            // display table header
            //
            "ID".PadRight(10) +
            "Name".PadRight(40) +
            "Value".PadRight(10) + "\n" +
            "---".PadRight(10) +
            "----------------------".PadRight(40) +
            "---".PadRight(10) + "\n";

            //
            // display all traveler objects in rows
            //
            string gameObjectRows = null;
            foreach (GameObject tradeObject in tradeObjects)
            {
                gameObjectRows +=
                    $"{tradeObject.Id}".PadRight(10) +
                    $"{tradeObject.Name}".PadRight(40) +
                    $"{tradeObject.Value}".PadRight(10) +
                    Environment.NewLine;
            }

            messageBoxText += gameObjectRows;

            return messageBoxText;
        }

        #endregion

        #region ADMIN MENU

        #region EDIT PLAYER 

        /// <summary>
        /// Edit Player Info Screen
        /// </summary>
        /// <param name="gamePlayer"></param>
        /// <returns></returns>
        public static string EditPlayerInfo(Player gamePlayer)
        {
            string messageBoxText =
                "Here is the your viking info that you may changer: \n" +
                "\n" +
                $"\tViking Name: {gamePlayer.Name}\n" +
                $"\tGender: {gamePlayer.Viking}\n" +
                $"\tViking Years: {gamePlayer.Age}\n" +
                $"\tHome Village: {gamePlayer.HomeVillage}\n" +
                $"\n\n\t{gamePlayer.Name}, choose which information you want to edit from the menu on the left.";

            return messageBoxText;
        }

        /// <summary>
        /// Edit player's gender screen
        /// </summary>
        /// <param name="gamePlayer"></param>
        /// <returns></returns>
        public static string EditGetPlayerGender(Player gamePlayer)
        {
            string messageBoxText =
                $"Alright {gamePlayer.Name}, your current gender info is {gamePlayer.Viking}. \n" +
                " \n" +
                "Enter which one you identfy with: \n" +
                " \n" +
                "\t1. Karl\n" +
                "\t2. Shieldmaiden"; ;

            return messageBoxText;
        }

        #endregion

        /// <summary>
        /// Display list of locations the player has visted
        /// </summary>
        /// <param name="locations"></param>
        /// <returns></returns>
        public static string VisitedLocations(IEnumerable<Location> locations)
        {
            string messageBoxText =
                "Locations Visited\n" +
                " \n" +

                //
                // display table header
                //
                "ID".PadRight(10) + "Name".PadRight(30) + "\n" +
                "---".PadRight(10) + "----------------------".PadRight(30) + "\n";

            //
            // display locations visited
            //
            string locationsList = null;
            foreach (Location location in locations)
            {
                locationsList +=
                    $"{location.LocationId}".PadRight(10) +
                    $"{location.LocationName}".PadRight(30) +
                    Environment.NewLine;
            }

            messageBoxText += locationsList;

            return messageBoxText;

        }

        /// <summary>
        /// Display list of all locations in game
        /// </summary>
        /// <param name="locations"></param>
        /// <returns></returns>
        public static string ListLocations(IEnumerable<Location> locations)
        {
            string messageBoxText =
                "Locations \n" +
                " \n" +

                //
                // display table header
                //
                "ID".PadRight(10) + "NAME".PadRight(30) + "\n" +
                "---".PadRight(10) + "-----------------------".PadRight(30) + "\n";

            //
            // display all locations
            //
            string locationsList = null;
            foreach (Location location in locations)
            {
                locationsList +=
                    $"{location.LocationId}".PadRight(10) +
                    $"{location.LocationName}".PadRight(30) +
                    Environment.NewLine;
            }

            messageBoxText += locationsList;

            return messageBoxText;
        }

        /// <summary>
        /// Display list of all weapons in the game
        /// </summary>
        /// <param name="gameObjects"></param>
        /// <returns></returns>
        public static string ListWeapons(IEnumerable<GameObject> gameObjects)
        {
            //
            // display table name and column headers
            //
            string messageBoxText =
                "Weapons\n" +
                " \n" +

                //
                // display table header
                //
                "ID".PadRight(10) +
                "Name".PadRight(40) +
                "Location Id".PadRight(10) + "\n" +
                "---".PadRight(10) +
                "----------------------".PadRight(40) +
                "----------------------".PadRight(10) + "\n";

            List<Weapon> weaponObjects = new List<Weapon>();
            foreach (GameObject gameObject in gameObjects)
            {
                if (gameObject is Weapon)
                {
                    weaponObjects.Add(gameObject as Weapon);
                }

            }

            //
            // display all traveler objects in rows
            //
            string gameObjectRows = null;
            foreach (Weapon weapon in weaponObjects)
            {
                gameObjectRows +=
                    $"{weapon.Id}".PadRight(10) +
                    $"{weapon.Name}".PadRight(40) +
                    $"{weapon.LocationId}".PadRight(10) +
                    Environment.NewLine;
            }

            messageBoxText += gameObjectRows;

            return messageBoxText;
        }

        /// <summary>
        /// Display list of all treasures in the game
        /// </summary>
        /// <param name="gameObjects"></param>
        /// <returns></returns>
        public static string ListTreasures(IEnumerable<GameObject> gameObjects)
        {
            //
            // display table name and column headers
            //
            string messageBoxText =
                "Game Treasures\n" +
                " \n" +

                //
                // display table header
                //
                "ID".PadRight(10) +
                "Name".PadRight(40) +
                "Location Id".PadRight(10) + "\n" +
                "---".PadRight(10) +
                "----------------------".PadRight(40) +
                "----------------------".PadRight(10) + "\n";

            List<Treasure> treasureObjects = new List<Treasure>();
            foreach (GameObject gameObject in gameObjects)
            {
                if (gameObject is Treasure)
                {
                    treasureObjects.Add(gameObject as Treasure);
                }

            }

            //
            // display all traveler objects in rows
            //
            string gameObjectRows = null;
            foreach (Treasure treasure in treasureObjects)
            {
                gameObjectRows +=
                    $"{treasure.Id}".PadRight(10) +
                    $"{treasure.Name}".PadRight(40) +
                    $"{treasure.LocationId}".PadRight(10) +
                    Environment.NewLine;
            }

            messageBoxText += gameObjectRows;

            return messageBoxText;
        }

        /// <summary>
        /// Display list of all items in the game
        /// </summary>
        /// <param name="gameObjects"></param>
        /// <returns></returns>
        public static string ListItems(IEnumerable<GameObject> gameObjects)
        {
            //
            // display table name and column headers
            //
            string messageBoxText =
                "Game Items\n" +
                " \n" +

                //
                // display table header
                //
                "ID".PadRight(10) +
                "Name".PadRight(40) +
                "Location Id".PadRight(10) + "\n" +
                "---".PadRight(10) +
                "----------------------".PadRight(40) +
                "----------------------".PadRight(10) + "\n";

            List<Item> itemObjects = new List<Item>();
            foreach (GameObject gameObject in gameObjects)
            {
                if (gameObject is Item)
                {
                    itemObjects.Add(gameObject as Item);
                }

            }

            //
            // display all traveler objects in rows
            //
            string gameObjectRows = null;
            foreach (Item item in itemObjects)
            {
                gameObjectRows +=
                    $"{item.Id}".PadRight(10) +
                    $"{item.Name}".PadRight(40) +
                    $"{item.LocationId}".PadRight(10) +
                    Environment.NewLine;
            }

            messageBoxText += gameObjectRows;

            return messageBoxText;
        }

        /// <summary>
        /// Display list og all the place objects in the game
        /// </summary>
        /// <param name="gameObjects"></param>
        /// <returns></returns>
        public static string ListPlaces(IEnumerable<GameObject> gameObjects)
        {
            //
            // display table name and column headers
            //
            string messageBoxText =
                "Game Places\n" +
                " \n" +

                //
                // display table header
                //
                "ID".PadRight(10) +
                "Name".PadRight(40) +
                "Location Id".PadRight(10) + "\n" +
                "---".PadRight(10) +
                "----------------------".PadRight(40) +
                "----------------------".PadRight(10) + "\n";

            List<Place> placeObjects = new List<Place>();
            foreach (GameObject gameObject in gameObjects)
            {
                if (gameObject is Place)
                {
                    placeObjects.Add(gameObject as Place);
                }

            }

            //
            // display all traveler objects in rows
            //
            string gameObjectRows = null;
            foreach (Place place in placeObjects)
            {
                gameObjectRows +=
                    $"{place.Id}".PadRight(10) +
                    $"{place.Name}".PadRight(40) +
                    $"{place.LocationId}".PadRight(10) +
                    Environment.NewLine;
            }

            messageBoxText += gameObjectRows;

            return messageBoxText;
        }

        /// <summary>
        /// Display list of all NPCs in the game
        /// </summary>
        /// <param name="npcObjects"></param>
        /// <returns></returns>
        public static string ListAllNpcObjects(IEnumerable<NPC> npcObjects)
        {
            string messageBoxText = "" +
                "NPC Objects\n" +
                " \n" +

                "ID".PadRight(10) +
                "Name".PadRight(30) +
                "Location Id".PadRight(10) + "\n" +
                "---".PadRight(10) +
                "------------------------".PadRight(30) +
                "------------------------".PadRight(10) + "\n";

            string npcObjectRows = null;
            foreach (NPC npcObject in npcObjects)
            {
                npcObjectRows +=
                    $"{npcObject.Id}".PadRight(10) +
                    $"{npcObject.Name}".PadRight(30) +
                    $"{npcObject.LocationId}".PadRight(10) +
                    Environment.NewLine;
            }

            messageBoxText += npcObjectRows;
            return messageBoxText;
        }

        #endregion

        #region OTHER 

        public static List<string> StatusBox(Player gamePlayer)
        {
            string energyWarning = "";
            string healthWarning = "";

            // WARNING to display if low
            if (gamePlayer.Energy < 20)
                energyWarning = "NEED REST!";
            if(gamePlayer.Health < 20)
                healthWarning = "LOW HEALTH!";

            if (gamePlayer.Viking == Player.VikingType.Shieldmaiden)
            {
                if (gamePlayer.VikingRank == Character.Rank.Freyr)
                {
                    gamePlayer.VikingRank = Character.Rank.Freya;
                }
                else if (gamePlayer.VikingRank == Character.Rank.King)
                {
                    gamePlayer.VikingRank = Character.Rank.Queen;
                }
            }

            List<string> statusBoxText = new List<string>();

            statusBoxText.Add($"Lives: {gamePlayer.Lives}\n");
            statusBoxText.Add($"Health: {gamePlayer.Health} {healthWarning}\n");
            statusBoxText.Add($"Energy: {gamePlayer.Energy} {energyWarning}\n");
            statusBoxText.Add($"Capital: {gamePlayer.Capital}\n");
            statusBoxText.Add($"Experience Points: {gamePlayer.ExperiencePoints}\n");
            statusBoxText.Add($"Level: {gamePlayer.CurrentLevel}");
            statusBoxText.Add($"Rank: {gamePlayer.VikingRank.ToString()}");


            return statusBoxText;
        }

        public static string NewLevelMessage(Player gamePlayer)
        {
            if (gamePlayer.Viking == Player.VikingType.Shieldmaiden)
            {
                if (gamePlayer.VikingRank == Character.Rank.Freyr)
                {
                    gamePlayer.VikingRank = Character.Rank.Freya;
                }
                else if (gamePlayer.VikingRank == Character.Rank.King)
                {
                    gamePlayer.VikingRank = Character.Rank.Queen;
                }
            }

            string messageBoxText = "Congratulations\n" +
                $"You have reached a level {gamePlayer.CurrentLevel}! \n" +
                $"Your new rank is {gamePlayer.VikingRank}. Way to go {gamePlayer.Name}!";

            return messageBoxText;
        }

        public static string GameInfo()
        {
            string infoText = "The object of the game is to climb the ranks and become the King or Queen of the Vikings\n" +
                "Explore, travel, and battle in order to increase your experience points and reach new levels.\n" +
                Environment.NewLine; 

            string rankInfo =
                "The Viking Ranks         Description\n" +
                "----------------------   ----------------------------------------------------------------------------------" +
                "\n" +
                "1. VIKING:               Fierce Fighter who has proved him or herself to be a viking.\n" +
                "2. MAURAUDER:            Strong Raiders, given to those who are actively taking part in raids.\n" +
                "3. BERSERKER/VALKYRIE:   Veteran, given to those who have shown an outstanding attitude or skill.\n" +
                "4. HUSKARL:              Veteran Warrior, has proven his/her loyalty and can be chosen to lead raids/wars. \n" +
                "5. RADNINGAR:            Strong Warrior, has proven his/her loyalty and strength during raids.\n" +
                "6. HERSIR:               Only Chosen by The High King/Queen or Jarl, Leading General. \n" +
                "7. SKALD:                In charge of the clan site.\n" +
                "8. FREYR/FREYA:          The lord or lady of the clan. \n" +
                "9. JARL:                 Full Independent Lordship/Head of Council. \n" +
                "10. KING/QUEEN:          The Founders/Stronghold of this clan. Highest Rank! \n";

            infoText += rankInfo;

            return infoText;
        }

        #endregion

    }

}
