using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using BepInEx;
using HarmonyLib;
using UnityEngine;

namespace TestRunner
{
    [BepInPlugin(ID, title, version)]
    public class TestRunner : BaseUnityPlugin
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

    

    #endregion
}
