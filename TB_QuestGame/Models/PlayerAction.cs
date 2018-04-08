using System;
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
        Buy,
        ChangeName,
        ChangeGender,
        ChangeAge,
        ChangeHomeVillage,
        GoBack,
        EnterPlace,
        Inventory,
        ListDestinations,
        ListItems,
        ListGameObjects,
        ListWeapons,
        ListPlaces,
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
