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
        MissionSetup,
        LookAround,
        LookAt,
        PickUpItem,
        PickUpTreasure,
        PutDownItem,
        PutDownTreasure,
        Travel,
        PlayerInfo,
        PlayerEdit,
        PlayerInventory,
        PlayerTreasure,
        ListDestinations,
        ListItems,
        ListTreasures,
        ChangeName,
        ChangeGender,
        ChangeAge,

        Exit
    }
}
