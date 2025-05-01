using AssetBundleTools;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace RealTimeDisplayPlugin;

[BepInPlugin("com.machaceleste.realtimedisplayplugin", MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    internal static new ManualLogSource Logger;
        
    private void Awake()
    {
        Logger = base.Logger;
        Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");
        BundleTool.LoadBundle("asset.bundle");
        var harmony = new Harmony("com.machaceleste.realtimedisplayplugin");
        harmony.PatchAll();
    }
}