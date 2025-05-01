using AssetBundleTools;
using HarmonyLib;
using UnityEngine;

[HarmonyPatch]
public class DesktopFinderPatch
{
    private static RealTimeClock rtc;

    private static LongTimePanel ltp;

    [HarmonyPatch(typeof(DesktopFinder), "Start")]
    class StartPatch
    {
        static void Postfix()
        {
            var topBar = GameObject.Find("ComputerCanvas/Desktop/BarraSupDesktop").transform;
            var rtcPrefab = BundleTool.GetPrefab("Assets/RealTimeDisplayPlugin/RealTimeClock.prefab");
            if (rtcPrefab == null)
            {
                return;
            }
            var rtcObj = UnityEngine.Object.Instantiate(rtcPrefab, topBar);
            rtcObj.name = "RealTimeClock";
            rtc = rtcObj.gameObject.AddComponent<RealTimeClock>();
            rtcObj.SetActive(true);

            var canvas = GameObject.Find("ComputerCanvas/Desktop").transform;
            var ltpPrefab = BundleTool.GetPrefab("Assets/RealTimeDisplayPlugin/LongTimePanel.prefab");
            if (ltpPrefab == null)
            {
                return;
            }
            var ltpObj = UnityEngine.Object.Instantiate(ltpPrefab, canvas);
            ltpObj.name = "LongTimePanel";
            ltp = ltpObj.gameObject.AddComponent<LongTimePanel>();
            ltpObj.SetActive(true);
        }
    }

    [HarmonyPatch(typeof(DesktopFinder), "SetColors")]
    class SetColorsPlugin
    {
        static void Postfix(ref UI_Theme theme)
        {
            rtc.SetTheme(theme);
            ltp.SetTheme(theme);
            ltp.OnHidePanel();
        }
    }
}