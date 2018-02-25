using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static string CurrrentLocationInfo() 
        {
            string messageBoxText =
            "You are located in Kaupang in Sikringssal. \n" +
            "Here you will begin your journey. \n" +
            "Take the time to look around, this place is the center for merchants and craftsmen. \n" +
            "You will need good weapond and skills to survive the battles ahead. \n" +
            " \n" +
            "\tChoose from the menu options to proceed.\n";

            return messageBoxText;
        }

        #region Initialize Mission Text

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
                "Enter which one you identfy with below.";

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


        public static string DisplayPlayerStartingCapital(Player gamePlayer)
        {
            string messageBoxText =
                $"Ok, {gamePlayer.Name} from {gamePlayer.HomeVillage}, starting the game your capital is at: {gamePlayer.Capital} coins. \n" +
                " \n" +
                "You are currently unarmed, the price of a weapon is 25 coins. \n" +
                "Do you wish to purchase a weapon? \n" +
                " \n" +
                "Please respond yes or no below: ";

            return messageBoxText;
        }

        public static string DisplayPlayerPurchaseWeapon(Player gamePlayer)
        {
            string messageBoxText =
                "The weapons available for purchase are listed below.\n" +
                " \n";

            string weaponList = null;

            foreach(Player.Weapon weapon in Enum.GetValues(typeof(Player.Weapon)))
            {
                if (weapon != Player.Weapon.None)
                {
                    weaponList += $"\t{weapon} \n";
                }
            }
            messageBoxText += weaponList;

            if (gamePlayer.IsArmed)
            {
                messageBoxText += " \n The weapons currently in your inventory are: ";

                string inventroyList = null;

                foreach (Player.Weapon weapon in gamePlayer.WeaponType)
                {
                    inventroyList += $"\t{weapon}, ";
                }
                messageBoxText += inventroyList;
            }
                messageBoxText += " \n" + 
                " \n" +
                "Please type the name of the weapon you would like to purchase below.";

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
                $"\tCapital: {gamePlayer.Capital} coins\n" +
                $"\tWeapons: ";

            string inventoryList = null;

            if (gamePlayer.IsArmed)
            {
                foreach (Player.Weapon weapon in gamePlayer.WeaponType)
                {
                    inventoryList += $"{weapon}, ";
                }
            }
            else
            {
                inventoryList += "You are currently unarmed.";
            }
                

                messageBoxText += inventoryList += "\n \n Press any key to begin your mission.";

            return messageBoxText;
        }

        #endregion

        #endregion

        #region EDIT PLAYER INFO

        public static string EditGetPlayerGender(Player gamePlayer)
        {
            string messageBoxText =
                $"Alright {gamePlayer.Name}, your current gender info is {gamePlayer.Viking}. \n" +
                "Are you a Karl or a Shieldmaiden? \n" +
                " \n" +
                "Enter which one you identfy with below.";

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

        #region MAIN MENU ACTION SCREENS

        public static string PlayerInfo(Player gamePlayer)
        {
            string messageBoxText =
                $"\tViking Name: {gamePlayer.Name}\n" +
                $"\tGender: {gamePlayer.Viking}\n" +
                $"\tViking Years: {gamePlayer.Age}\n" +
                $"\tHome Village: {gamePlayer.HomeVillage}\n" +
                $"\tCapital: {gamePlayer.Capital} coins\n" +
                $"\tWeapon: ";

            string inventoryList = null;

            if (gamePlayer.IsArmed)
            {
                foreach (Player.Weapon weapon in gamePlayer.WeaponType)
                {
                    inventoryList += $"{weapon.ToString()}, ";
                }
            }
            else
            {
                inventoryList += "You are currently unarmed.";
            }


            messageBoxText += inventoryList += "\n\tViking greeting: " + gamePlayer.Greeting();

            return messageBoxText;
        }


        #endregion
    }
}
