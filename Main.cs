using System;
using BepInEx;
using Pathfinding.RVO.Sampled;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace StreamOverlaysV2
{
    [BepInPlugin("ShinyGorilla.StreamOverlaysV2", "StreamOverlaysV2", "1.0.1")]
    public class Main : BaseUnityPlugin
    {
        public static Font Agency = Font.CreateDynamicFontFromOSFont("Agency FB", 24);
        public static bool Enabled;
        private void OnEnable()
        {
            HarmonyPatches.ApplyHarmonyPatches();
            Enabled = true;
        }

        private void OnDisable()
        {
            HarmonyPatches.RemoveHarmonyPatches();
            Enabled = false;
        }

        private void OnGUI()
        {
            if (Enabled)
            {
                GUI.skin.toggle.fontSize = 7;
                GUI.skin.label.font = Agency;
                GUI.skin.toggle.font = Agency;
                GUI.skin.label.fontStyle = FontStyle.Normal;
                GUI.skin.toggle.fontStyle = FontStyle.Normal;
                GUI.color = new Color32(255, 255, 255, byte.MaxValue);

                if (PhotonNetwork.InRoom)
                {
                    GUILayout.BeginVertical(Array.Empty<GUILayoutOption>());

                    GUILayout.Label(string.Concat(new string[]
                    {
                    "Code:",
                    PhotonNetwork.CurrentRoom.Name,
                    "\n",
                    PhotonNetwork.CurrentRoom.PlayerCount.ToString(),
                    "/10 players"
                    }), Array.Empty<GUILayoutOption>());
                    GUILayout.EndHorizontal();
                }

                GUILayout.Space(5f);

                if (!PhotonNetwork.InRoom)
                {
                    GUILayout.Label("Not connected to room", Array.Empty<GUILayoutOption>());
                    return;
                }
            }
        }
    }
}
