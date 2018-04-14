﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// enum of all possible player actions
    /// </summary>
    public enum PlayerAction
    {
        None,
        AdminMenu,
        AddToInventory,
        Buy,
        ChangeName,
        ChangeGender,
        ChangeAge,
        ChangeHomeVillage,
        Consume,
        GoBack,
        EnterPlace,
        Inventory,
        ListDestinations,
        ListItems,
        ListGameObjects,
        ListWeapons,
        ListPlaces,
        ListNonPlayerCharacters,
        ListTreasures,
        LocationsVisited,
        LookAround,
        LookAt,
        MissionSetup,
        PickUpItem,
        PlayerEdit,
        PlayerInfo,
        PlayerInventory,
        PurchaseWeapon,
        PutDownItem,
        Sell,
        Trade,
        Travel,
        ReturnToMainMenu,
        Exit
    }
}
