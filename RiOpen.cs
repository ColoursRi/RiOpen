using BepInEx;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiOpen
{
    [BepInPlugin("com.ri.potioncraft.riopen", "RiOpen", "1.0.0.0")]
    public class RiPatcher : BaseUnityPlugin
    {
        void Awake()
        {
            UnityEngine.Debug.Log("[RiOpen] launching!");
            Patcher();
        }

        void Patcher()
        {
            try
            {
                var harmony = new Harmony("com.ri.potioncraft.riopen");
                harmony.PatchAll();
            }
            catch (Exception e)
            {
                UnityEngine.Debug.Log(e);
            }
        }
    }
}
