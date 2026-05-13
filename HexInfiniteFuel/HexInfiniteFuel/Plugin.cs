using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using System;
using UnityEngine;

namespace HexInfiniteFuel
{
    [BepInPlugin(PluginGuid, PluginName, PluginVersion)]
    public class Plugin : BaseUnityPlugin
    {
        private const string PluginGuid = "hex.infinitefuel";
        private const string PluginName = "Infinite Fuel";
        private const string PluginVersion = "1.0.1";

        private ConfigEntry<bool> _pluginEnabled;

        internal static Plugin Instance { get; private set; }
        internal static Harmony HarmonyInstance { get; private set; }

        public static ConfigEntry<bool> EnableAdvancedDebugLogging { get; private set; }
        public static ManualLogSource logger = BepInEx.Logging.Logger.CreateLogSource(PluginName);

        public bool IsPluginEnabled => _pluginEnabled.Value;

        public void Awake()
        {
            Instance = this;

            _pluginEnabled = Config.Bind("General", $"Enable {PluginName}", true, $"Enable or disable {PluginName.ToLower()}.");
            EnableAdvancedDebugLogging = Config.Bind("Debug", "EnableAdvancedDebugLogging", false, "Enable or disable advanced debug logging.");

            _pluginEnabled.SettingChanged += OnPluginEnabledChanged;

            HarmonyInstance = new Harmony(PluginGuid);
            HarmonyInstance.PatchAll();

            logger.LogInfo($"{PluginName} v{PluginVersion} is loaded!");
        }

        public void OnDestroy()
        {
            if (_pluginEnabled != null)
            {
                _pluginEnabled.SettingChanged -= OnPluginEnabledChanged;
            }

            HarmonyInstance?.UnpatchSelf();
            HarmonyInstance = null;
            Instance = null;

            logger.LogInfo($"{PluginName} v{PluginVersion} is unloaded!");
        }

        private void OnPluginEnabledChanged(object sender, EventArgs e)
        {
            ApplyInfiniteFuelToAllFireplaces();
        }

        private void ApplyInfiniteFuelToAllFireplaces()
        {
            var fireplaces = UnityEngine.Object.FindObjectsByType<Fireplace>(FindObjectsSortMode.None);

            foreach (var fireplace in fireplaces)
            {
                if (fireplace == null)
                {
                    continue;
                }

                fireplace.m_infiniteFuel = IsPluginEnabled;
            }

            if (Plugin.EnableAdvancedDebugLogging.Value)
            {
                logger.LogInfo($"Applied Infinite Fuel = {IsPluginEnabled} to {fireplaces.Length} fireplaces.");
            }
        }
    }

    [HarmonyPatch(typeof(Fireplace), nameof(Fireplace.Awake))]
    public static class PatchFireplace
    {
        private static void Postfix(Fireplace __instance)
        {
            if (__instance == null || Plugin.Instance == null)
            {
                return;
            }

            __instance.m_infiniteFuel = Plugin.Instance.IsPluginEnabled;

            if (Plugin.EnableAdvancedDebugLogging.Value)
            {
                Plugin.logger.LogInfo($"[PatchFireplace] Set m_infiniteFuel to {__instance.m_infiniteFuel}");
            }
        }
    }
}