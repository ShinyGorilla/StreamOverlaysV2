using System;
using System.Reflection;
using HarmonyLib;

namespace StreamOverlaysV2
{
    public class HarmonyPatches
    {
        public static bool IsPatched { get; private set; }

        internal static void ApplyHarmonyPatches()
        {
            if (!HarmonyPatches.IsPatched)
            {
                if (HarmonyPatches.instance == null)
                {
                    HarmonyPatches.instance = new Harmony("ShinyGorilla.StreamOverlaysV2");
                }
                HarmonyPatches.instance.PatchAll(Assembly.GetExecutingAssembly());
                HarmonyPatches.IsPatched = true;
            }
        }

        internal static void RemoveHarmonyPatches()
        {
            if (HarmonyPatches.instance != null && HarmonyPatches.IsPatched)
            {
                HarmonyPatches.instance.UnpatchSelf();
                HarmonyPatches.IsPatched = false;
            }
        }

        private static Harmony instance;
    }
}
