using HarmonyLib;
using InventoryWindow;
using LocalizationSystem;
using ObjectBased.Bedroom;
using ObjectBased.UIElements;
using ObjectBased.UIElements.ConfirmationWindow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RiOpen
{
    /* 
     * OpenCalendarButton.OnButtonReleasedPointerInside
     * Intent: Trigger the openning of the shop, allowing in customers
     */
    [HarmonyPatch(typeof(OpenCalendarButton), "OnButtonReleasedPointerInside")]
    internal class OpenCalendarButton_OnButtonReleasedPointerInside_Patcher
    {

        static bool Prefix()
        {
            if (Managers.Room.currentRoom == RoomManager.RoomIndex.Meeting) 
            {
                ShopOpenState.setOpen(true);
            }

            return false;
        }
    }
}
