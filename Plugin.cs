using BepInEx;
using BepInEx.Configuration;
using Photon.Pun;
using static WhoIsThatMonke.PublicVariablesGatherHere;

namespace WhoIsThatMonke
{
    // This is your mod's main class.
    [BepInIncompatibility("com.hansolo1000falcon.gorillatag.whatisthefps")]
    [BepInIncompatibility("com.hansolo1000falcon.gorillatag.whoischeating")]
    [BepInIncompatibility("com.hansolo1000falcon.gorillatag.whoisspeeding")]
    [BepInIncompatibility("org.iidk.gorillatag.iimenu")]
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        private ConfigEntry<bool> PlatformCheckerEnabled;
        private ConfigEntry<bool> VelocityCheckerEnabled;
        private ConfigEntry<bool> FPSCheckerEnabled;
        private ConfigEntry<bool> ColorCodeSpooferEnabled;

        void Start()
        {
            HarmonyPatches.ApplyHarmonyPatches();
            ExitGames.Client.Photon.Hashtable properties = new ExitGames.Client.Photon.Hashtable();
            properties.Add("cheese is gouda", PluginInfo.Name);
            PhotonNetwork.LocalPlayer.SetCustomProperties(properties);
        }

 	    void Awake()
  	    {
  	     
            PlatformCheckerEnabled = Config.Bind("Settings", "Platform Checker", true, "Enable or disable the platform checker.");
            VelocityCheckerEnabled = Config.Bind("Settings", "Velocity Checker", true, "Enable or disable the velocity checker.");
            FPSCheckerEnabled = Config.Bind("Settings", "FPS Checker", true, "Enable or disable the FPS checker.");
            ColorCodeSpooferEnabled = Config.Bind("Settings", "Color Code Spoofer", true, "Enable or disable the color code spoofer.");

            isPlatformEnabled = PlatformCheckerEnabled.Value;
            isVelocityEnabled = VelocityCheckerEnabled.Value;
            isFPSEnabled = FPSCheckerEnabled.Value;
            isColorCodeEnabled = ColorCodeSpooferEnabled.Value;
        }
    }
}
