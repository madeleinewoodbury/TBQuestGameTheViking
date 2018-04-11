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
            None,
            QuestIntro,
            MainMenu,
            LookAround,
            ListGameObjectsMenu,
            InventoryMenu,
            PickUp,
            AdminMenu,
            TradeMenu,
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
                    { '3', PlayerAction.Inventory },
                    { '4', PlayerAction.Travel },    
                    { '5', PlayerAction.AdminMenu },
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
                    { '4', PlayerAction.Trade },
                    { '5', PlayerAction.EnterPlace },
                    { '0', PlayerAction.ReturnToMainMenu }

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
                {'0', PlayerAction.ReturnToMainMenu }
            }
        };

        public static Menu ListGameObjectsMenu = new Menu()
        {
            MenuName = "ListGameObjects",
            MenuTitle = "List Game Objects",
            MenuChoices = new Dictionary<char, PlayerAction>()
            {
                {'1', PlayerAction.ListWeapons },
                {'2', PlayerAction.ListTreasures},
                {'3', PlayerAction.ListItems },
                {'4', PlayerAction.ListPlaces },
                {'0', PlayerAction.ReturnToMainMenu }
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
                {'0', PlayerAction.GoBack }
            }
        };

        public static Menu TradeMenu = new Menu()
        {
            MenuName = "TradeMenu",
            MenuTitle = "Trade Menu",
            MenuChoices = new Dictionary<char, PlayerAction>()
            {
                { '1', PlayerAction.Buy },
                { '2', PlayerAction.Sell },
                { '0', PlayerAction.GoBack }
            }
        };

        public static Menu InventoryMenu = new Menu()
        {
            MenuName = "InventoryMenu",
            MenuTitle = "Inventory Menu",
            MenuChoices = new Dictionary<char, PlayerAction>()
            {
                { '1', PlayerAction.LookAt },
                { '0', PlayerAction.ReturnToMainMenu }
            }
        };

        public static Menu PickUpMenu = new Menu()
        {
            MenuName = "PickUpMenu",
            MenuTitle = "Pick Up Menu",
            MenuChoices = new Dictionary<char, PlayerAction>()
            {
                { '1', PlayerAction.LookAt },
                { '2', PlayerAction.AddToInventory},
                { '3', PlayerAction.Consume},
                { '4', PlayerAction.PutDownItem},
                { '0', PlayerAction.GoBack }
            }
        };


    }
}
