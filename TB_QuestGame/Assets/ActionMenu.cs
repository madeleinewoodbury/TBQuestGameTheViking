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
            LookAround,
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
                    //{ '3', PlayerAction.LookAt },
                    //{ '4', PlayerAction.PickUpItem },
                    //{ '5', PlayerAction.PutDownItem },
                    { '6', PlayerAction.Inventory },
                    { '7', PlayerAction.Travel },    
                    { '8', PlayerAction.AdminMenu },
                    { '0', PlayerAction.Exit }
                }
        };

        public static Menu LookAround = new Menu()
        {
            MenuName = "LookAround",
            MenuTitle = "Look Around Menu",
            MenuChoices = new Dictionary<char, PlayerAction>()
                {
                    { '1', PlayerAction.LookAt },
                    { '2', PlayerAction.PickUpItem },
                    { '3', PlayerAction.PutDownItem },
                    { '4', PlayerAction.Inventory },
                    { '5', PlayerAction.ReturnToMainMenu }

                }
        };

        public static Menu AdminMenu = new Menu()
        {
            MenuName = "AdminMenu",
            MenuTitle = "Admin Menu",
            MenuChoices = new Dictionary<char, PlayerAction>()
            {
                {'1', PlayerAction.PlayerEdit },
                {'2', PlayerAction.LocationsVisited },
                {'3', PlayerAction.ListDestinations },
                {'4', PlayerAction.ListGameObjects },
                {'5', PlayerAction.ReturnToMainMenu }
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
