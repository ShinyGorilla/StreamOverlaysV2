using System;
using BepInEx;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace StreamOverlaysV2
{
    [BepInPlugin("ShinyGorilla.StreamOverlaysV2", "StreamOverlaysV2", "1.0.0")]
    public class Main : BaseUnityPlugin
    {
        private void OnEnable()
        {
            HarmonyPatches.ApplyHarmonyPatches();
        }

        private void OnDisable()
        {
            HarmonyPatches.RemoveHarmonyPatches();
        }

        private void OnGUI()
        {
            GUI.skin.toggle.fontSize = 7;
            GUI.skin.label.font = Main.agency;
            GUI.skin.toggle.font = Main.agency;
            GUI.skin.label.fontStyle = FontStyle.Italic;
            GUI.skin.toggle.fontStyle = FontStyle.Italic;
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

        public static Font agency = Font.CreateDynamicFontFromOSFont("Agency FB", 24);
    }
}
