using HarmonyLib;
using Npc.MonoBehaviourScripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiOpen
{
    /* 
     * DayManager.StartNewDay
     * Intent: Set the shop back to closed at the start of each day
     */
    [HarmonyPatch(typeof(DayManager), "StartNewDay")]
    internal class DayManager_StartNewDay_Patcher
    {

        static bool Prefix(DayManager __instance)
        {
            Console.WriteLine("!!!!!!!!");

            ShopOpenState.setOpen(false);

            return true;
        }
    }

    /* 
     * DayManager.StartNewDay
     * Intent: Set the shop back to closed when a new save is loaded
     */
    [HarmonyPatch(typeof(DayManager), "OnLoad")]
    internal class DayManager_OnLoad_Patcher
    {

        static bool Prefix()
        {

            NpcManager mng = Managers.Npc;

            var prop = mng.GetType().GetField("CurrentNpcMonoBehaviour", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            NpcMonoBehaviour npc = null;

            if (prop != null)
            {
                npc = (NpcMonoBehaviour)prop.GetValue(mng);
                return true;
            }

            if (npc != null)
            {

                ShopOpenState.setOpen(true);
                return true;
            }

            ShopOpenState.setOpen(false);
            return true;
        }
    }


    /* 
     * EnvironmentManager.StartNight
     * Intent: Decrease the player's popularity if they skipped the day
     */
    [HarmonyPatch(typeof(EnvironmentManager), "StartNight")]
    internal class EnvironmentManager_StartNight_Patch
    {

        static void Postfix() {

            if (!ShopOpenState.getOpen())
            {
                PlayerManager mng = Managers.Player;
                mng.AddPopularity(ShopOpenState.getPenalty());
            }

            return;
        }

    }

}
