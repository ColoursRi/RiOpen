using HarmonyLib;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiOpen
{
      /*      
       * NpcManager.SpawnNpcQueue
       * Intent: Prevent customers from entering if the shop is not open
       */
        [HarmonyPatch(typeof(NpcManager), "SpawnNpcQueue")]
        internal class NpcManager_SpawnNpcQueue_Patcher
        {

            static bool Prefix()
            {
                if (!ShopOpenState.getOpen())
                {
                    return false;
                }

                return true;
            }
        }
    

       /*      
       * NpcManager.CallNextNpc
       * Intent: Prevent customers from entering if the shop is not open
       */
        [HarmonyPatch(typeof(NpcManager), "CallNextNpc")]
        internal class NpcManager_CallNextNpc_Patcher
        {

        static bool Prefix()
        {
            ShopOpenState.setOpen(true);
            return true;
        }
    }

}
