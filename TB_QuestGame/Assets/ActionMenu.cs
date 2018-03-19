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
                    { '2', PlayerAction.PlayerEdit },
                    { '3', PlayerAction.ListDestinations },
                    { '4', PlayerAction.LookAround },
                    { '5', PlayerAction.Travel },
                    { '6', PlayerAction.LocationsVisited },
                    { '7', PlayerAction.ListGameObjects },
                    { '0', PlayerAction.Exit }
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
