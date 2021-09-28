using HarmonyLib;
using LocalizationSystem;
using ObjectBased.Bedroom;
using ObjectBased.UIElements;
using ObjectBased.UIElements.ConfirmationWindow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiOpen
{
    /*  
     * Bed.OnPrimaryCursorClick
     * Intent: Allow the player to sleep if the shop is closed but customers have not been dealt with.
     */
    [HarmonyPatch(typeof(Bed), "OnPrimaryCursorClick")]
    internal class Bed_OnPrimaryCursorClick_Patcher
    {

        static bool Prefix(NpcManager __instance)
        {
           
            if (!ShopOpenState.getOpen())
            {
                ConfirmationWindow.Show(DarkScreen.Layer.Lower, new Key("#bed_start_new_day", null), new Key("#bed_start_new_day_description", null), Managers.Game.settings.confirmationWindowPosition, new Action(Managers.Environment.StartNight), null);

                return false;
            }

            return true;
        }
    }
}
