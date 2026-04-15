using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace HexInfiniteFuel
{
    [BepInPlugin(ModGuid, ModName, ModVersion)]
    public class Plugin : BaseUnityPlugin
    {
        public const string ModGuid = "com.hex.hexinfinitefuel";
        public const string ModName = "HexInfiniteFuel";
        public const string ModVersion = "1.0.0";

        internal static Plugin Instance;
        internal static Harmony HarmonyInstance;
        public static ManualLogSource logger = BepInEx.Logging.Logger.CreateLogSource(ModName);

        public void Awake()
        {
            Instance = this;
            HarmonyInstance = new Harmony(ModGuid);
            HarmonyInstance.PatchAll();
            logger.LogInfo($"{ModName} v{ModVersion} is loaded!");
        }

        public void OnDestroy()
        {
            Instance = null;
            HarmonyInstance.UnpatchSelf();

            logger.LogInfo($"{ModName} v{ModVersion} is unloaded!");
        }
    }

    [HarmonyPatch(typeof(Fireplace), "Awake")]
    public static class Patch_Fireplace_InfiniteFuel
    {
        private static void Postfix(Fireplace __instance)
        {
            if (__instance == null)
            {
                return;
            }

            __instance.m_infiniteFuel = true;
            Plugin.logger.LogInfo($"[Patch_Fireplace_InfiniteFuel] Fireplace infinite fuel enabled.");
        }
    }
}
