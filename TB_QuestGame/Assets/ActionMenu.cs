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
            NpcMenu,
            LookAround,
            ItemMenu,
            ListGameObjectsMenu,
            InventoryMenu,
            AdminMenu,
            ShopMenu,
            EditPlayerMenu,
            BattleMenu, 
            TradeMenu
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
                    { '6', PlayerAction.GameInfo },
                    { '0', PlayerAction.Exit }
                }
        };

        public static Menu LookAround = new Menu()
        {
            MenuName = "LookAround",
            MenuTitle = "Look Around Menu",
            MenuChoices = new Dictionary<char, PlayerAction>()
                {
                    { '1', PlayerAction.ItemMenu},
                    { '2', PlayerAction.NpcMenu},
                    { '3', PlayerAction.Shop },
                    { '4', PlayerAction.EnterPlace },
                    { '0', PlayerAction.ReturnToMainMenu }

                }
        };

        public static Menu NpcMenu = new Menu()
        {
            MenuName = "NpcMenu",
            MenuTitle = "NPC Menu",
            MenuChoices = new Dictionary<char, PlayerAction>()
            {
                { '1', PlayerAction.TalkTo},
                { '2', PlayerAction.Trade },
                { '0', PlayerAction.GoBack}
            }
        };

        public static Menu TradeMenu = new Menu()
        {
            MenuName = "TradeMenu",
            MenuTitle = "Trade Menu",
            MenuChoices = new Dictionary<char, PlayerAction>()
            {
                { '1', PlayerAction.TradeInventoryItem},
                { '2', PlayerAction.Buy },
                { '0', PlayerAction.GoBack}
            }
        };

        public static Menu BattleMenu = new Menu()
        {
            MenuName = "BattleMenu",
            MenuTitle = "Battle Menu",
            MenuChoices = new Dictionary<char, PlayerAction>()
            {
                { '1', PlayerAction.Fight},
                { '2', PlayerAction.RunAway}
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
                {'5', PlayerAction.ListNonPlayerCharacters},
                {'0', PlayerAction.ReturnToMainMenu}
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
                {'0', PlayerAction.GoBack }
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
                {'0', PlayerAction.GoBack }
            }
        };

        public static Menu ItemMenu = new Menu()
        {
            MenuName = "Item Menu",
            MenuTitle = "Item Menu",
            MenuChoices = new Dictionary<char, PlayerAction>()
            {
                { '1', PlayerAction.LookAt },
                { '2', PlayerAction.PickUpItem },
                { '3', PlayerAction.Consume},
                { '0', PlayerAction.GoBack }
            }
        };

        public static Menu ShopMenu = new Menu()
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
                { '2', PlayerAction.Consume},
                { '3', PlayerAction.PutDownItem},
                { '4', PlayerAction.ChooseWeapon },
                { '5', PlayerAction.ChooseShield },
                { '0', PlayerAction.ReturnToMainMenu }
            }
        };

    }
}
