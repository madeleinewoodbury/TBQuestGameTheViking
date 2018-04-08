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

        public static string QuestIntro()
        {
            string messageBoxText =
            "Welcome to Fylkirfold, the world of kings. \n" +
            "Here, only the toughest and bravest Vikings will thrive. \n" +
            "Your quest is to climb the ranks to become the King of the Vikings. \n" +
            "But be warned, the road to the top is hard, and you will have to encouter battles,\n" +
            "both at home and overseas.\n" +
            " \n" +
            "If you don't think you have what it takes, you can press the Esc key to exit the game at any point. \n" +
            " \n" +
            "Your quest begins now. \n" +
            " \n" +
            "\tYour first task will be to channel your inner viking and setup your character." +
            " \n" +
            "\tPress any key to begin.\n";

            return messageBoxText;
        }

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

        public static string SetuoGetPlayerName()
        {
            string messageBoxText =
                "Enter your viking name.\n" +
                " \n" +
                "Please use the name you wish to be referred during your quest.";

            return messageBoxText;
        }

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

        public static string SetupGetPlayerHomeVillage(Player gamePlayer)
        {
            string messageBoxText =
                $"{gamePlayer.Name}, we need to know what village you are from." +
                " \n" +
                "Enter the name of your home village below.";

            return messageBoxText;
        }

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
                "\tWeapon: You are currently unarmed" +
                "\n \n Press any key to begin your mission.";

            return messageBoxText;
        }

        #endregion

        #region EDIT PLAYER 

        public static string EditPlayerInfo(Player gamePlayer)
        {
            string messageBoxText =
                $"\tViking Name: {gamePlayer.Name}\n" +
                $"\tGender: {gamePlayer.Viking}\n" +
                $"\tViking Years: {gamePlayer.Age}\n" +
                $"\tHome Village: {gamePlayer.HomeVillage}\n" +
                $"\tCapital: {gamePlayer.Capital} coins\n" +
                $"\n\n\t{gamePlayer.Name}, choose which information you want to edit from the menu on the left.";

            return messageBoxText;
        }

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

        public static string DisplayNotEnoughCapital(Player player)
        {
            string messageBoxText =
                $"This is unfortunate, {player.Name}. It seems like you don't have enough capital \n" +
                "to purchase a new weapon. \n" +
                $"You need 25 coins to purchase a new weapon, you currently only have {player.Capital} coins. \n" +
                " \n" +
                "Press any key to continue:";

            return messageBoxText;
        }


        #endregion

        #region MAIN MENU

        public static string CurrrentLocationInfo(Location currentLocation)
        {
            string messageBoxText =
            $"You are located in {currentLocation.LocationName}. \n" +
            " \n" +
            "\tChoose from the menu options to proceed.\n";

            return messageBoxText;
        }

        public static string PlayerInfo(Player gamePlayer)
        {
            string messageBoxText =
                $"\tViking Name: {gamePlayer.Name}\n" +
                $"\tGender: {gamePlayer.Viking}\n" +
                $"\tViking Years: {gamePlayer.Age}\n" +
                $"\tHome Village: {gamePlayer.HomeVillage}\n" +
                $"\tCapital: {gamePlayer.Capital} coins\n" +
                "\tViking greeting: " + gamePlayer.Greeting();

            return messageBoxText;
        }

        public static string LookAround(Location location)
        {
            string messageTextBox =
                $"Current location: {location.LocationName}\n" +
                " \n" + location.Description;
            // TODO display contents

            return messageTextBox;
        }

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
                 "ID".PadRight(10) + "Name".PadRight(30) + "\n" +
                 "---".PadRight(10) + "--------------------".PadRight(30) + "\n";

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
                        $"{location.LocationName}".PadRight(30) +
                        Environment.NewLine;

                    }
                }

            }

            messageTextBox += locationList;

            return messageTextBox;

        }

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

        public static string GameObjectsChooseList(IEnumerable<GameObject> gameObjects)
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

                if (item.CanInventory)
                {
                    messageBoxText += "may be added to your inventory.";
                }
                else
                {
                    messageBoxText += "may not be added to your inventory.";
                }
            }
            else if (gameObject is Treasure)
            {
                Treasure treasure = gameObject as Treasure;

                messageBoxText += $"The {treasure.Name} has a value of {treasure.Value} and ";

                if (treasure.CanInventory)
                {
                    messageBoxText += "may be added to your inventory.";
                }
                else
                {
                    messageBoxText += "may not be added to your inventory.";
                }
            }
            else if (gameObject is Weapon)
            {
                Weapon weapon = gameObject as Weapon;

                messageBoxText += $"The {weapon.Name} has a value of {weapon.Value} and ";

                if (weapon.CanInventory)
                {
                    messageBoxText += "may be added to your inventory.";
                }
                else
                {
                    messageBoxText += "may not be added to your inventory.";
                }
            }
            else
            {
                messageBoxText += $"The {gameObject.Name} may not be added to your inventory.";
            }


            return messageBoxText;
        }

        public static string CurrentInventory(IEnumerable<GameObject> inventory)
        {
            string messageBoxText = "";

            //
            // display table header
            //
            messageBoxText =
                "ID".PadRight(10) +
                "Name".PadRight(40) +
                "\n" +
                "---".PadRight(10) +
                "-----------------------------".PadRight(40) +
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
                Environment.NewLine;

            }

            messageBoxText += inventoryObjectRows;

            return messageBoxText;
        }


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

        public static string DisplayTradeScreenText(IEnumerable<GameObject> inventory, Location currentLocation)
        {
            string messageBoxText = "";

            //
            // display table header
            //
            messageBoxText =
                $"Here in {currentLocation.LocationName}, you can trade in your valuables for money or you can purchase items. \n" +
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
            // display all traveler objects in rows
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
                $"{place.EnytryPoints}".PadRight(10) +
                Environment.NewLine;
            }

            messageBoxText += gameObjectRows;

            return messageBoxText;
        }

        public static string DisplayEnterPlaceText(Place placeEntered)
        {
            string messageBoxText = placeEntered.EntryMessage;

            if (placeEntered.CanEeat)
            {
                messageBoxText += $"You have gained {placeEntered.Health} health points here. \n";
            }
            if (placeEntered.CanTrain)
            {
                messageBoxText += $"You have gaines {placeEntered.ExperiencePoints} experience points here. \n";
            }

            return messageBoxText;
        }

        #endregion

        #region ADMIN MENU

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

        #endregion

        #region OTHER 

        public static List<string> StatusBox(Player gamePlayer)
        {
            List<string> statusBoxText = new List<string>();

            statusBoxText.Add($"Lives: {gamePlayer.Lives}\n");
            statusBoxText.Add($"Health: {gamePlayer.Health}\n");
            statusBoxText.Add($"Capital: {gamePlayer.Capital}\n");
            statusBoxText.Add($"Experience Point: {gamePlayer.ExperiencePoints}\n");

            return statusBoxText;
        }

        #endregion

    }

}
