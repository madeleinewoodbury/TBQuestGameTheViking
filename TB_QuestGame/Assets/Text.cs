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

        public static string CurrrentLocationInfo() // change
        {
            string messageBoxText =
            "You are now in the Norlon Corporation research facility located in " +
            "the city of Heraklion on the north coast of Crete. You have passed through " +
            "heavy security and descended an unknown number of levels to the top secret " +
            "research lab for the Aion Project.\n" +
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
                "Do you wish to purchase a weapon?" +
                " \n" +
                "Please respond yes or no below: ";

            return messageBoxText;
        }

        public static string DisplayPlayerPurchaseWeapon(Player gamePlayer)
        {
            string messageBoxText =
                "The weapons available for purchase are listed below.\n";

            string weaponList = null;

            foreach(Player.Weapon weapon in Enum.GetValues(typeof(Player.Weapon)))
            {
                if (weapon != Player.Weapon.None)
                {
                    weaponList += $"\t{weapon} \n";
                }
            }

            messageBoxText += weaponList + " \n" +
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
                $"\tViking Years: {gamePlayer.Age}\n" +
                $"\tGender: {gamePlayer.Viking}\n" +
                $"\tHome Village: {gamePlayer.HomeVillage}\n" +
                $"\tWeapon: {gamePlayer.WeaponType}\n" +
                $"\tCapital: {gamePlayer.Capital} coins\n" +
                " \n";

                if (gamePlayer.WeaponType == Player.Weapon.None)
                {
                messageBoxText += "WARNING: You are currently unarmed! \n";
                }

                messageBoxText += "Press any key to begin your mission.";

            return messageBoxText;
        }

        #endregion

        #endregion

        #region MAIN MENU ACTION SCREENS

        public static string PlayerInfo(Player gamePlayer)
        {
            string messageBoxText =
                $"\tViking Name: {gamePlayer.Name}\n" +
                $"\tViking Years: {gamePlayer.Age}\n" +
                $"\tGender: {gamePlayer.Viking}\n" +
                $"\tHome Village: {gamePlayer.HomeVillage}\n" +
                $"\tWeapon: {gamePlayer.WeaponType}\n" +
                $"\tCapital: {gamePlayer.Capital} coins\n" +
                " \n" +
                "\tViking greeting: " + gamePlayer.Greeting() + 
                "\n";

            if (gamePlayer.WeaponType == Player.Weapon.None)
            {
                messageBoxText += "WARNING: You are currently unarmed!";
            }

            return messageBoxText;
        }

        public static string DisplayCurrentPlayerInfo(Player gamePlayer)
        {
            string messageBoxText =
                "Your current information is: \n" +
                $"\t1. Viking Name: {gamePlayer.Name}\n" +
                $"\t2. Viking Years: {gamePlayer.Age}\n" +
                $"\t3. Gender: {gamePlayer.Viking}\n" +
                $"\t4. Home Village: {gamePlayer.HomeVillage}\n" +
                $"\t5. Weapon: {gamePlayer.WeaponType}\n" +
                $"\t6. Capital: {gamePlayer.Capital} coins\n" +
                " \n" +
                "Please type the number for which information you would like to change.";

            return messageBoxText;
        }

        public static string DisplayEditPlayerInfoComplete(Player gamePlayer)
        {
            string messageBoxText =
                $"{gamePlayer.Name}, you have completed editing your information. \n" +
                " \n" +
                "Press any key to continue";

            return messageBoxText;

        }

        #endregion
    }
}
