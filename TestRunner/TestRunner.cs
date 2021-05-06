using System;
using BepInEx;
using HarmonyLib;
using UnityEngine;

namespace TestRunner
{
    [BepInPlugin(ID, title, version)]
    public class ValheimModTemplate : BaseUnityPlugin
    {
        public const string ID = "mixone.valheim.testrunner";
        public const string version = "0.0.0.0";     
        public const string title = "Test Runner";     

        public Harmony harmony;
        
        public static BepInEx.Logging.ManualLogSource harmonyLog;

        public void Awake()
        {
            harmony = new Harmony(ID);
            harmony.PatchAll();
            harmonyLog = Logger;

            harmonyLog.LogDebug($"{title} loaded.");
        }
    }

    #region Utils

    #endregion

    #region Transpilers

    #endregion

    #region Patches 

    #region Ladder

    [HarmonyPatch(typeof(Ladder), nameof(Ladder.Interact))]
    public static class Ladder_Interact_Patch
    {
        public static Vector3 targetPos;
        public static Quaternion targetRot;
        public static Vector3 targetFor;

        public static bool Prefix(ref Ladder __instance, ref bool __result, ref Humanoid character, ref bool hold)
        {
            if (hold)
            {
                __result = false;
                return false;
            }
            if (!__instance.InUseDistance(character))
            {
                __result = false;
                return false;
            }
            targetPos = character.transform.position;
            targetRot = character.transform.rotation;
            targetFor = character.GetLookDir();
            character.transform.position = __instance.m_targetPos.position;
            character.transform.rotation = __instance.m_targetPos.rotation;
            character.SetLookDir(__instance.m_targetPos.forward);
            __instance.m_targetPos.position = targetPos;
            __instance.m_targetPos.rotation = targetRot;
            __instance.m_targetPos.forward = targetFor;
            __result = false;
            return false;
        }
    }

    #endregion

    #endregion
}
