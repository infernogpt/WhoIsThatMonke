using System;
using BepInEx;
using Photon.Pun;
using UnityEngine;
using Utilla;

namespace WhoIsThatMonke
{
    [BepInIncompatibility("com.hansolo1000falcon.gorillatag.whatisthefps")]
    [BepInIncompatibility("com.hansolo1000falcon.gorillatag.whoischeating")]
    [BepInIncompatibility("com.hansolo1000falcon.gorillatag.whoisspeeding")]
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        void Start()
        {
            HarmonyPatches.ApplyHarmonyPatches();
            ExitGames.Client.Photon.Hashtable properties = new ExitGames.Client.Photon.Hashtable();
            properties.Add("cheese is gouda", PluginInfo.Name);
            PhotonNetwork.LocalPlayer.SetCustomProperties(properties);
        }
    }
}
