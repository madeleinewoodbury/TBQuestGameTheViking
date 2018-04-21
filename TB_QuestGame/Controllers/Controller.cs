using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace TB_QuestGame
{
    /// <summary>
    /// controller for the MVC pattern in the application
    /// </summary>
    public class Controller
    {
        #region FIELDS

        private ConsoleView _gameConsoleView;
        private Player _gamePlayer;
        private Universe _gameUniverse;
        private bool _playingGame;
        private Location _currentLocaton;
        private int _gameTick = 1;
        Timer timer = new Timer(1000);
        

        #endregion

        #region PROPERTIES


        #endregion

        #region CONSTRUCTORS

        public Controller()
        {
            //
            // setup all of the objects in the game
            //
            InitializeGame();

            //
            // begins running the application UI
            //
            ManageGameLoop();
        }

        #endregion

        #region METHODS

        /// <summary>
        /// initialize the major game objects
        /// </summary>
        private void InitializeGame()
        {
            _gamePlayer = new Player();
            _gameUniverse = new Universe();
            _gameConsoleView = new ConsoleView(_gamePlayer, _gameUniverse);
            _playingGame = true;

            Console.CursorVisible = false;

            timer.Elapsed += GameTickTimer_Elapsed;
        }

        /// <summary>
        /// method to manage the application setup and game loop
        /// </summary>
        private void ManageGameLoop()
        {
            PlayerAction playerActionChoice = PlayerAction.None;
            int objectId = 0;
            int npcId = 0;
            int npcObject = 0;

            //
            // display splash screen
            //
            _playingGame = _gameConsoleView.DisplaySpashScreen();

            //
            // player chooses to quit
            //
            if (!_playingGame)
            {
                Environment.Exit(1);
            }

            //
            // display introductory message
            //
            _gameConsoleView.DisplayGamePlayScreen("Quest Intro", Text.QuestIntro(), ActionMenu.QuestIntro, "");
            _gameConsoleView.GetContinueKey();

            //
            // initialize the mission traveler
            // 
            InitializeQuest();

            //
            // prepare game play screen
            //
            _currentLocaton = _gameUniverse.GetLocationById(_gamePlayer.LocationId);
            _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.LookAround(_currentLocaton), ActionMenu.MainMenu, "");

            //
            // update game stauts
            //
            //_gamePlayer.GameTimer = new Timer(1000);
            //_gamePlayer.GameTimer.Start();
            timer.Start();

            //
            // game loop
            //
            while (_playingGame)
            {
                UpdateGameStatus();
                //
                // get the next action from the player
                //
                playerActionChoice = GetNextPlayerAction();

                //
                // choose an action based on the user's menu choice
                //
                switch (playerActionChoice)
                {
                    case PlayerAction.None:
                        break;

                    #region Edit Options
                    case PlayerAction.ChangeName:
                        _gamePlayer.Name = _gameConsoleView.DisplayEditName(_gamePlayer);
                        _gameConsoleView.DisplayGamePlayScreen("Edit Player Info", Text.PlayerInfo(_gamePlayer), ActionMenu.EditPlayer, "");
                        break;
                    case PlayerAction.ChangeGender:
                        _gamePlayer.Viking = _gameConsoleView.DisplayEditGender(_gamePlayer);
                        _gameConsoleView.DisplayGamePlayScreen("Edit Player Info", Text.PlayerInfo(_gamePlayer), ActionMenu.EditPlayer, "");
                        break;
                    case PlayerAction.ChangeAge:
                        _gamePlayer.Age = _gameConsoleView.DisplayEditAge(_gamePlayer);
                        _gameConsoleView.DisplayGamePlayScreen("Edit Player Info", Text.PlayerInfo(_gamePlayer), ActionMenu.EditPlayer, "");
                        break;
                    case PlayerAction.ChangeHomeVillage:
                        _gamePlayer.HomeVillage = _gameConsoleView.DisplayEditHomeVillage(_gamePlayer);
                        _gameConsoleView.DisplayGamePlayScreen("Edit Player Info", Text.PlayerInfo(_gamePlayer), ActionMenu.EditPlayer, "");
                        break;
                    case PlayerAction.PlayerEdit:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.EditPlayerMenu;
                        _gameConsoleView.DisplayGamePlayScreen("Edit Player Info", Text.PlayerInfo(_gamePlayer), ActionMenu.EditPlayer, "");
                        break;
                    #endregion

                    #region List Options
                    case PlayerAction.ListWeapons:
                        _gameConsoleView.DisplayListWeapons();
                        break;
                    case PlayerAction.ListTreasures:
                        _gameConsoleView.DisplayListTreasures();
                        break;
                    case PlayerAction.ListItems:
                        _gameConsoleView.DisplayListItems();
                        break;
                    case PlayerAction.ListPlaces:
                        _gameConsoleView.DisplayListPlaces();
                        break;
                    case PlayerAction.ListDestinations:
                        _gameConsoleView.DisplayListOfLocations();
                        break;
                    case PlayerAction.ListGameObjects:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.ListGameObjectsMenu;
                        _gameConsoleView.DisplayListGameObjects();
                        break;
                    case PlayerAction.ListNonPlayerCharacters:
                        _gameConsoleView.DisplayListAllNpcObjects();
                        break;
                    case PlayerAction.LocationsVisited:
                        _gameConsoleView.DisplayLocationsVisited();
                        break;
                    #endregion

                    #region Object Options (LookAt, Trade/Sell, NPC)
                    case PlayerAction.NpcMenu:
                        _gameConsoleView.DisplayGamePlayScreen("NPC Menu", "Select an operation from the menu", ActionMenu.NpcMenu, "");
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.NpcMenu;
                        break;
                    case PlayerAction.Buy:
                        BuyAction();
                        break;
                    case PlayerAction.Consume:
                        if (ActionMenu.currentMenu == ActionMenu.CurrentMenu.ItemMenu)
                        {
                            ConsumeItem();
                        }
                        else
                        {
                            ConsumeInventoryItem();
                        }               
                        break;
                    case PlayerAction.ChooseWeapon:
                        ChooseWeaponAction();
                        break;
                    case PlayerAction.ChooseShield:
                        ChooseShieldAction();
                        break;
                    case PlayerAction.EnterPlace:
                        EnterAction();
                        break;
                    case PlayerAction.ItemMenu:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.ItemMenu;
                        _gameConsoleView.DisplayGamePlayScreen("Look Around", "Select an option from the Item Menu", ActionMenu.ItemMenu, "");
                        break;
                    case PlayerAction.LookAt:
                        if (ActionMenu.currentMenu == ActionMenu.CurrentMenu.InventoryMenu)
                        {
                            _gameConsoleView.DisplayInventory();
                            InventoryLookAtAction();
                        }
                        else
                        {
                            ActionMenu.currentMenu = ActionMenu.CurrentMenu.ItemMenu;
                            objectId = LookAtAction();
                        }
                        break;
                    case PlayerAction.PickUpItem:
                        PickUpAction();
                        break;
                    case PlayerAction.PutDownItem:
                        PutDownAction();
                        break;
                    case PlayerAction.Sell:
                        SellAction();
                        break;
                    case PlayerAction.Trade:
                        if (ActionMenu.currentMenu == ActionMenu.CurrentMenu.NpcMenu)
                        {
                            npcObject = TradeWithNpc();
                        }
                        else
                        {
                            ActionMenu.currentMenu = ActionMenu.CurrentMenu.TradeMenu;
                            _gameConsoleView.DisplayTrade(_currentLocaton);
                        }
                        break;
                    case PlayerAction.TalkTo:
                        npcId = TalkToAction();
                        break;
                    case PlayerAction.Fight:
                        BattleAction(npcId);
                        break;
                    case PlayerAction.RunAway:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.MainMenu;
                        _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.LookAround(_currentLocaton), ActionMenu.MainMenu, "");
                        break;
                    case PlayerAction.TradeInventoeyItem:
                        TradeInventoryItemAction(npcObject);
                        break;
                    #endregion

                    #region Main Menu Options
                    case PlayerAction.PlayerInfo:
                        _gameConsoleView.DisplayPlayerInfo();
                        break;
                    case PlayerAction.AdminMenu:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.AdminMenu;
                        _gameConsoleView.DisplayGamePlayScreen("Admin Menu", "Select an operation from the menu.", ActionMenu.AdminMenu, "");
                        break;
                    case PlayerAction.LookAround:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.LookAround;
                        _gameConsoleView.DisplayLookAround();
                        break;
                    case PlayerAction.Inventory:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.InventoryMenu;
                        _gameConsoleView.DisplayInventory();
                        break;
                    case PlayerAction.Travel:
                        // get new locationId and update the curentLocation
                        _gamePlayer.LocationId = _gameConsoleView.DisplayGetLocation();
                        _currentLocaton = _gameUniverse.GetLocationById(_gamePlayer.LocationId);

                        // set the game play screen to current location info
                        _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.LookAround(_currentLocaton), ActionMenu.MainMenu, "");
                        break;
                    #endregion

                    #region Exit/Go Back / ReturnToMainMenu
                    case PlayerAction.ReturnToMainMenu:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.MainMenu;
                        _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.LookAround(_currentLocaton), ActionMenu.MainMenu, "");
                        break;
                    case PlayerAction.GoBack:
                        if (ActionMenu.currentMenu == ActionMenu.CurrentMenu.EditPlayerMenu)
                        {
                            ActionMenu.currentMenu = ActionMenu.CurrentMenu.AdminMenu;
                            _gameConsoleView.DisplayGamePlayScreen("Admin Menu", "Select an operation from the menu.", ActionMenu.AdminMenu, "");
                        }
                        else if (ActionMenu.currentMenu == ActionMenu.CurrentMenu.TradeMenu)
                        {
                            ActionMenu.currentMenu = ActionMenu.CurrentMenu.LookAround;
                            _gameConsoleView.DisplayLookAround();
                        }
                        else if (ActionMenu.currentMenu == ActionMenu.CurrentMenu.ListGameObjectsMenu)
                        {
                            ActionMenu.currentMenu = ActionMenu.CurrentMenu.AdminMenu;
                            _gameConsoleView.DisplayGamePlayScreen("Admin Menu", "Select an operation from the menu.", ActionMenu.AdminMenu, "");
                        }
                        else if (ActionMenu.currentMenu == ActionMenu.CurrentMenu.ItemMenu)
                        {
                            ActionMenu.currentMenu = ActionMenu.CurrentMenu.LookAround;
                            _gameConsoleView.DisplayLookAround();
                        }
                        else if (ActionMenu.currentMenu == ActionMenu.CurrentMenu.NpcMenu)
                        {
                            ActionMenu.currentMenu = ActionMenu.CurrentMenu.LookAround;
                            _gameConsoleView.DisplayLookAround();
                        }
                        break;
                    case PlayerAction.Exit:
                        _gameConsoleView.DisplayClosingScreen(_gamePlayer);
                        _playingGame = false;
                        break;
                    #endregion

                    default:
                        break;
                }
            }

            //
            // close the application
            //
            Environment.Exit(1);
        }

        /// <summary>
        /// Initialize the player info
        /// </summary>
        private void InitializeQuest()
        {
            Player player = _gameConsoleView.GetInitialPlayerInfo();

            _gamePlayer.Name = player.Name;
            _gamePlayer.Age = player.Age;
            _gamePlayer.Viking = player.Viking;
            _gamePlayer.LocationId = 1;
            _gamePlayer.HomeVillage = player.HomeVillage;
            _gamePlayer.Capital = player.Capital;
            _gamePlayer.IsArmed = false;
            _gamePlayer.IsShielded = false;
            _gamePlayer.VikingRank = Character.Rank.Viking;
            _gamePlayer.PrimaryWeapon = null;

            _gamePlayer.ExperiencePoints = 0;
            _gamePlayer.Health = 100;
            _gamePlayer.Lives = 3;
            _gamePlayer.Energy = 100;
            _gamePlayer.CurrentLevel = 1;

            //
            // add initial items to inventory
            //
            _gamePlayer.Inventory.Add(_gameUniverse.GetGameObjectById(17) as GameObject);

        }

        private void UpdateGameStatus()
        {
            if (!_gamePlayer.HasVisited(_currentLocaton.LocationId))
            {
                // add new location to the list of visited locations
                _gamePlayer.LocationsVisted.Add(_currentLocaton.LocationId);

                // update experience points and health for visiting locations
                _gamePlayer.ExperiencePoints += _currentLocaton.ExperiencePoints;

            }

            if (_gamePlayer.PrimaryWeapon != null)
            {
                _gamePlayer.IsArmed = true;
            }

            if (_gamePlayer.PrimaryShield != null)
            {
                _gamePlayer.IsShielded = true;
            }
            if (_gamePlayer.Energy <= 0)
            {
                _gameConsoleView.DisplayGamePlayScreen("Warning", "Your energy levels are too low. You need rest!", ActionMenu.MainMenu, "");
                
            }

            if (_gamePlayer.Health <= 0)
            {
                _gamePlayer.Lives -= 1;
                _gamePlayer.Energy = 100;
            }

            int level = _gamePlayer.CurrentLevel;
            _gamePlayer.CurrentLevel = _gameUniverse.GetLevel(_gamePlayer.ExperiencePoints, _gamePlayer.CurrentLevel);
            _gamePlayer.VikingRank = _gameUniverse.GetVikingRank(_gamePlayer.CurrentLevel);

            if (level < _gamePlayer.CurrentLevel)
            {
                ActionMenu.currentMenu = ActionMenu.CurrentMenu.MainMenu;
                _gameConsoleView.DisplayNewLevelMessage();
            }

        }

        private PlayerAction GetNextPlayerAction()
        {
            PlayerAction playerActionChocie = PlayerAction.None;

            switch (ActionMenu.currentMenu)
            {
                case ActionMenu.CurrentMenu.MainMenu:
                    playerActionChocie = _gameConsoleView.GetActionMenuChoice(ActionMenu.MainMenu);
                    break;
                case ActionMenu.CurrentMenu.LookAround:
                    playerActionChocie = _gameConsoleView.GetActionMenuChoice(ActionMenu.LookAround);
                    break;
                case ActionMenu.CurrentMenu.ListGameObjectsMenu:
                    playerActionChocie = _gameConsoleView.GetActionMenuChoice(ActionMenu.ListGameObjectsMenu);
                    break;
                case ActionMenu.CurrentMenu.AdminMenu:
                    playerActionChocie = _gameConsoleView.GetActionMenuChoice(ActionMenu.AdminMenu);
                    break;
                case ActionMenu.CurrentMenu.TradeMenu:
                    playerActionChocie = _gameConsoleView.GetActionMenuChoice(ActionMenu.TradeMenu);
                    break;
                case ActionMenu.CurrentMenu.EditPlayerMenu:
                    playerActionChocie = _gameConsoleView.GetActionMenuChoice(ActionMenu.EditPlayer);
                    break;
                case ActionMenu.CurrentMenu.InventoryMenu:
                    playerActionChocie = _gameConsoleView.GetActionMenuChoice(ActionMenu.InventoryMenu);
                    break;
                case ActionMenu.CurrentMenu.ItemMenu:
                    playerActionChocie = _gameConsoleView.GetActionMenuChoice(ActionMenu.ItemMenu);
                    break;
                case ActionMenu.CurrentMenu.NpcMenu:
                    playerActionChocie = _gameConsoleView.GetActionMenuChoice(ActionMenu.NpcMenu);
                    break;
                case ActionMenu.CurrentMenu.BattleMenu:
                    playerActionChocie = _gameConsoleView.GetActionMenuChoice(ActionMenu.BattleMenu);
                    break;
                default:
                    break;
            }

            return playerActionChocie;
        }

        private void EnterAction()
        {
            //
            // display list of places in current location
            //
            int placeId = _gameConsoleView.DisplayGetPlaceToEnter();

            if (placeId != 0)
            {
                GameObject gameObject = _gameUniverse.GetGameObjectById(placeId);
                Place placeToEnter = gameObject as Place;

                // update game stats
                _gamePlayer.ExperiencePoints += placeToEnter.ExperiencePoints;
                _gamePlayer.Health += placeToEnter.Health;

                _gameConsoleView.DisplayConfirmPlaceEntered(placeToEnter);
            }
            else
            {
                _gameConsoleView.DisplayLookAround();
            }


        }

        private void InventoryLookAtAction()
        {
            int objectId = _gameConsoleView.DisplayGetInventoryObjectToLookAt();

            //
            // display game object info
            //
            if (objectId != 0)
            {
                //
                // get the game object from the universe
                //
                GameObject gameObject = _gameUniverse.GetGameObjectById(objectId);

                //
                // display information for the object chosen and provide the option to pick it up
                //
                _gameConsoleView.DisplayInventoryObjectInfo(gameObject);
            }
            
        }

        /// <summary>
        /// process the Look At action
        /// </summary>
        private int LookAtAction()
        {
            //
            // display a list of game objects in space-time location and get a player choice
            //
            int gameObjectToLookAtId = _gameConsoleView.DisplayGetGameObjectToLookAt();

            //
            // display game object info
            //
            if (gameObjectToLookAtId != 0)
            {
                //
                // get the game object from the universe
                //
                GameObject gameObject = _gameUniverse.GetGameObjectById(gameObjectToLookAtId);

                //
                // display information for the object chosen and provide the option to pick it up
                //
                _gameConsoleView.DisplayGameObjectInfo(gameObject);  
            }
            else
            {
                ActionMenu.currentMenu = ActionMenu.CurrentMenu.LookAround;
                _gameConsoleView.DisplayLookAround();
            }

            return gameObjectToLookAtId;
        }


        private void SellAction()
        {
            int tradeObjectToSell = _gameConsoleView.DisplayGetTradeObjectToSell();

            if (tradeObjectToSell != 0)
            {
                //
                // get the game object from the universe
                //
                GameObject tradeObject = _gameUniverse.GetGameObjectById(tradeObjectToSell) as GameObject;

                //
                // update the capital and remover from inventory
                //
                _gamePlayer.Capital += tradeObject.Value;
                _gamePlayer.Inventory.Remove(tradeObject);

                _gameConsoleView.DisplayConfirmSale(tradeObject);
            }

            else
            {
                _gameConsoleView.DisplayTrade(_currentLocaton);
            }

        }

        private void BuyAction()
        {
            //
            // display a list of trade objects in location and get a player choice
            //
            int tradeObjectIdToBuy = _gameConsoleView.DisplayGetTradeItemToPurchase(_currentLocaton);

            //
            // add the traveler object to traveler's inventory
            //
            if (tradeObjectIdToBuy != 0)
            {
                //
                // get the game object from the universe
                //
                GameObject tradeObject = _gameUniverse.GetGameObjectById(tradeObjectIdToBuy) as GameObject;

                //
                // update the capital and add to inventory
                //
                _gamePlayer.Capital -= tradeObject.Value;
                _gamePlayer.Inventory.Add(tradeObject);
                tradeObject.LocationId = 0;

                _gameConsoleView.DisplayConfirmPurchase(tradeObject);
            }
            else
            {
                _gameConsoleView.DisplayTrade(_currentLocaton);
            }

        }

        private void PickUpAction()
        {
            //
            // display a list of game objects in location and get a player choice
            //
            int gameObjectToPickUpId = _gameConsoleView.DisplayGetGameObjectToPickUp();

            //
            // add the traveler object to traveler's inventory
            //
            if (gameObjectToPickUpId != 0)
            {
                //
                // get the game object from the universe
                //
                GameObject gameObject = _gameUniverse.GetGameObjectById(gameObjectToPickUpId) as GameObject;

                //
                // note: traveler object is added to list and space-time location is set to 0
                //
                _gamePlayer.Inventory.Add(gameObject);
                gameObject.LocationId = 0;

                //
                // display confirmation message
                //
                _gameConsoleView.DisplayConfirmGameObjectAddedToInventory(gameObject);
            }
            else
            {
                ActionMenu.currentMenu = ActionMenu.CurrentMenu.LookAround; 
                _gameConsoleView.DisplayLookAround();
            }
        }

     

        private void PutDownAction()
        {
            //
            // display a list of game objects in inventory and get player's choice
            //
            int objectToPutDown = _gameConsoleView.DisplayGetGameObjectToPutDown();

            if (objectToPutDown != 0)
            {
                //
                // get the game object from the universe
                //
                GameObject gameObject = _gameUniverse.GetGameObjectById(objectToPutDown) as GameObject;

                //
                // remove the object from the inventory and set the location to the current value
                //
                _gamePlayer.Inventory.Remove(gameObject);
                gameObject.LocationId = _gamePlayer.LocationId;

                //
                // display confirmation message
                //
                _gameConsoleView.DisplayConfirmItemRemovedFromInventory(gameObject);
            }

        }

        private void ConsumeInventoryItem()
        {
            //
            // display a list of game objects in inventory and get player's choice
            //
            int objectToConsume = _gameConsoleView.DisplayGetInventoryItemToConsume();

            if (objectToConsume != 0)
            {
                //
                // get the game object from the universe
                //
                GameObject gameObject = _gameUniverse.GetGameObjectById(objectToConsume) as GameObject;

                if (gameObject is Item)
                {
                    Item item = gameObject as Item;
                    if (item.IsConsumable)
                    {
                        _gamePlayer.Inventory.Remove(item);
                        _gamePlayer.Health += item.Health;

                        _gameConsoleView.DisplayConsumeItem(item);
                    }
                    else
                    {
                        _gameConsoleView.DisplayGamePlayScreen("Current Inventory", $"{item.Name} cannot be consumed.", ActionMenu.InventoryMenu, "");
                    }
                }
                else
                {
                    _gameConsoleView.DisplayGamePlayScreen("Current Inventory", $"{gameObject.Name} cannot be consumed.", ActionMenu.InventoryMenu, "");
                }

            }
            else
            {
                _gameConsoleView.DisplayInventory();
            }
        }

        private void ConsumeItem()
        {
            //
            // display a list of game objects in inventory and get player's choice
            //
            int objectToConsume = _gameConsoleView.DisplayGetItemToConsume();

            if (objectToConsume != 0)
            {
                //
                // get the game object from the universe
                //
                GameObject gameObject = _gameUniverse.GetGameObjectById(objectToConsume) as GameObject;

                if (gameObject is Item)
                {
                    Item item = gameObject as Item;
                    if (item.IsConsumable)
                    {
                        item.LocationId = 0;
                        _gamePlayer.Health += item.Health;
                        _gameConsoleView.DisplayConsumeItem(item);
                    }
                }
            }
        }

        private void ChooseWeaponAction()
        {
            //
            // display a list of game objects in inventory and get player's choice
            //
            int weaponId = _gameConsoleView.DisplayGetWeapon();

            if (weaponId != 0)
            {
                //
                // get the game object from the universe
                //
                GameObject gameObject = _gameUniverse.GetGameObjectById(weaponId) as GameObject;

                if (gameObject is Weapon)
                {
                    Weapon weapon = gameObject as Weapon;
                    if (!weapon.Shield)
                    {
                        _gamePlayer.PrimaryWeapon = weapon;
                        _gameConsoleView.DisplayGamePlayScreen("Current Inventory", $"{weapon.Name} is now your primary weapon", ActionMenu.InventoryMenu, "");
                    }
                    else
                    {
                        _gameConsoleView.DisplayGamePlayScreen("Current Inventory", $"{weapon.Name} is a shield and can't be your primary weapon.", ActionMenu.InventoryMenu, "");
                    }
                }
                else
                {
                    _gameConsoleView.DisplayGamePlayScreen("Current Inventory", $"{gameObject.Name} is not a weapon.", ActionMenu.InventoryMenu, "");
                }

            }
            else
            {
                _gameConsoleView.DisplayInventory();
            }
        }

        private void ChooseShieldAction()
        {
            //
            // display a list of game objects in inventory and get player's choice
            //
            int shieldId = _gameConsoleView.DisplayGetWeapon();

            if (shieldId != 0)
            {
                //
                // get the game object from the universe
                //
                GameObject gameObject = _gameUniverse.GetGameObjectById(shieldId) as GameObject;

                if (gameObject is Weapon)
                {
                    Weapon shield = gameObject as Weapon;
                    if (shield.Shield)
                    {
                        _gamePlayer.PrimaryShield = shield;
                        _gameConsoleView.DisplayGamePlayScreen("Current Inventory", $"{shield.Name} is now your primary shield", ActionMenu.InventoryMenu, "");
                    }
                    else
                    {
                        _gameConsoleView.DisplayGamePlayScreen("Current Inventory", $"{shield.Name} is not a shield.", ActionMenu.InventoryMenu, "");
                    }
                }
                else
                {
                    _gameConsoleView.DisplayGamePlayScreen("Current Inventory", $"{gameObject.Name} is not a shield.", ActionMenu.InventoryMenu, "");
                }

            }
            else
            {
                _gameConsoleView.DisplayInventory();
            }
        }

        private int TalkToAction()
        {
            // get id of npc to talk to
            int npcId = _gameConsoleView.DisplayGetNpcToTalkTo();
            int opponentId = 0;

            // display npc message
            if (npcId != 0)
            {
                NPC npc = _gameUniverse.GetNpcById(npcId);
                if (npc.IsFriendly)
                {
                    _gameConsoleView.DisplayTalkTo(npc);
                    _gamePlayer.ExperiencePoints += npc.XP;
                }
                else
                {
                    ActionMenu.currentMenu = ActionMenu.CurrentMenu.BattleMenu;
                    _gameConsoleView.DisplayTalkToOpponent(npc);
                    opponentId = npcId;
                }

                
            }

            return opponentId;
        }

        private void BattleAction(int npcId)
        {
            NPC npc = _gameUniverse.GetNpcById(npcId);

            int opponentPoints = _gameUniverse.GetOpponentPoints(npcId);
            int playerPoints = _gameUniverse.GetPlayerPoints(_gamePlayer);

            if (playerPoints > opponentPoints)
            {
                if (_gamePlayer.IsArmed)
                {
                    _gamePlayer.ExperiencePoints += npc.XP;
                    ActionMenu.currentMenu = ActionMenu.CurrentMenu.LookAround;
                    _gameConsoleView.DisplayGamePlayScreen("Battle", $"Congratulations! You won the battle agains {npc.Name}.\n" +
                        $"Your points: {playerPoints}\n" +
                        $"{npc.Name}'s points: {opponentPoints}", ActionMenu.LookAround, "");
                }
                else if (!_gamePlayer.IsArmed && !npc.IsArmed)
                {
                    _gamePlayer.ExperiencePoints += npc.XP;
                    ActionMenu.currentMenu = ActionMenu.CurrentMenu.LookAround;
                    _gameConsoleView.DisplayGamePlayScreen("Battle", $"Congratulations! You won the battle agains {npc.Name}.\n" +
                        $"Your points: {playerPoints}\n" +
                        $"{npc.Name}'s points: {opponentPoints}", ActionMenu.LookAround, "");
                }
                else
                {
                    _gamePlayer.Lives -= 1;
                    ActionMenu.currentMenu = ActionMenu.CurrentMenu.MainMenu;
                    _gameConsoleView.DisplayGamePlayScreen("Battle", $"You lost the battle against {npc.Name}.\n" +
                        $"Your points: {playerPoints}\n" +
                        $"{npc.Name}'s points: {opponentPoints}", ActionMenu.MainMenu, "");
                }

            }
            else
            {
                _gamePlayer.Lives -= 1;
                ActionMenu.currentMenu = ActionMenu.CurrentMenu.MainMenu;
                _gameConsoleView.DisplayGamePlayScreen("Battle", $"You lost the battle against {npc.Name}.\n" +
                    $"Your points: {playerPoints}\n" +
                    $"{npc.Name}'s points: {opponentPoints}", ActionMenu.MainMenu, "");
            }
        }

        private int TradeWithNpc()
        {
            int npcId = _gameConsoleView.DisplayGetNpcToTradeWith();
            int npcTradeObject = 0;

            if (npcId != 0)
            {
                NPC npc = _gameUniverse.GetNpcById(npcId);
                if (npc.TradeObjects.Count > 0)
                {
                    npcTradeObject= _gameConsoleView.DisplayChooseNpcItemToTrade(npc);
                    GameObject tradeItem = _gameUniverse.GetGameObjectById(npcTradeObject);
                    _gameConsoleView.DisplayGamePlayScreen("Trade", $"Would you like to buy {tradeItem.Name} for {tradeItem.Value} coins \n" +
                        "or would you like to trade one of the items in your inventory for it?\n" +
                        "\nChoose from the menu options", ActionMenu.NpcMenu, "");
                }
            }

            return npcTradeObject;
        }

        private void TradeInventoryItemAction(int npcItemToTrade)
        {
            int inventoryItemToTade = _gameConsoleView.DisplayGetInventoryItemToTrade();

            if (inventoryItemToTade != 0)
            {
                GameObject inventoryObject = _gameUniverse.GetGameObjectById(inventoryItemToTade) as GameObject;

                if (npcItemToTrade != 0)
                {
                    GameObject npcObject = _gameUniverse.GetGameObjectById(npcItemToTrade) as GameObject;
                    if (inventoryObject != null && npcObject != null)
                    {
                        if (inventoryObject.Value >= npcObject.Value)
                        {
                            _gamePlayer.Inventory.Remove(inventoryObject);
                            _gamePlayer.Inventory.Add(npcObject);

                            _gameConsoleView.DisplayGamePlayScreen("Trade", $"You have traded {inventoryObject.Name} for {npcObject.Name} which has now\n" +
                                "been added to your ineventory.", ActionMenu.NpcMenu, "");
                        }
                        else
                        {
                            _gameConsoleView.DisplayGamePlayScreen("Trade", $"The value of {inventoryObject.Name} is not enouh to trade for the value of {npcObject.Name}.", ActionMenu.NpcMenu, "");
                        }
                    
                    }

                }
            }

        }

        private void GameTickTimer_Elapsed(object sender, ElapsedEventArgs e)
        { 
            _gameTick++;
            if (_gameTick % 60 == 0)
            { 

                if (_gamePlayer.Energy <= 0)
                {
                    _gamePlayer.Health -= 10;
                }
                else
                {
                    _gamePlayer.Energy -= 10;
                }

            }


        }

        #endregion

    }
    
}
