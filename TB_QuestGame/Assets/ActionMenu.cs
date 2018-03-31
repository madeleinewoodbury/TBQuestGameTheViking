using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// static class to hold key/value pairs for menu options
    /// </summary>
    public static class ActionMenu
    {
        public enum CurrentMenu
        {
            QuestIntro,
            MainMenu,
            AdminMenu,
            EditPlayerMenu
        }

        public static CurrentMenu currentMenu = CurrentMenu.MainMenu;

        public static Menu QuestIntro = new Menu()
        {
            MenuName = "QuestIntro",
            MenuTitle = "",
            MenuChoices = new Dictionary<char, PlayerAction>()
                    {
                        { ' ', PlayerAction.None }
                    }
        };

        public static Menu MainMenu = new Menu()
        {
            MenuName = "MainMenu",
            MenuTitle = "Main Menu",
            MenuChoices = new Dictionary<char, PlayerAction>()
                {
                    { '1', PlayerAction.PlayerInfo },
                    { '2', PlayerAction.LookAround },
                    { '3', PlayerAction.LookAt },
                    { '4', PlayerAction.PickUpItem },
                    { '5', PlayerAction.PutDownItem },
                    { '6', PlayerAction.Inventory },
                    { '7', PlayerAction.Travel },
                    { '8', PlayerAction.LocationsVisited },
                    { '9', PlayerAction.AdminMenu },
                    { '0', PlayerAction.Exit }
                }
        };

        public static Menu AdminMenu = new Menu()
        {
            MenuName = "AdminMenu",
            MenuTitle = "Admin Menu",
            MenuChoices = new Dictionary<char, PlayerAction>()
            {
                {'1', PlayerAction.PlayerEdit },
                {'2', PlayerAction.ListDestinations },
                {'3', PlayerAction.ListGameObjects },
                {'4', PlayerAction.ReturnToMainMenu }
            }
        };

        public static Menu EditPlayer = new Menu()
        {
            MenuName = "Player Info",
            MenuTitle = "Player Info",
            MenuChoices = new Dictionary<char, PlayerAction>()
            {
                {'1', PlayerAction.ChangeName},
                {'2', PlayerAction.ChangeGender },
                {'3', PlayerAction.ChangeAge},
                {'4', PlayerAction.ChangeHomeVillage },
                {'5', PlayerAction.PurchaseWeapon},
                {'6', PlayerAction.GoBack }
            }
        };

    }
}
