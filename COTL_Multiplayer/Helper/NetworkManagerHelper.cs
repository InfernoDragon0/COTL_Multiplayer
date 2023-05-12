using COTL_Multiplayer.Manager;
using kcp2k;
using Mirror;
using Mirror.FizzySteam;
using UnityEngine;

namespace COTL_Multiplayer.Helper;

public static class NetworkManagerHelper
{
    public static GameObject CreateNetworkManager()
    {
        var networkManager = new GameObject("NetworkManager");
        networkManager.SetActive(false);

        var managerScript = networkManager.AddComponent<NetworkManagerCOTL>();
        var managerHud = networkManager.AddComponent<NetworkManagerHUD>();
        var steamworks = networkManager.AddComponent<FizzySteamworks>();


        managerScript.transport = steamworks;
        managerScript.offlineScene = "Main Menu"; //TODO find the main menu scene name
        managerScript.onlineScene = "Base Biome 1";

        networkManager.SetActive(true);
        return networkManager;
    }

    public static void RunAsHost()
    {
        Plugin.Instance?.NetworkManager.GetComponent<NetworkManagerCOTL>().StartHost();
    }

    public static void JoinServer(Uri uri)
    {
        Plugin.Instance?.NetworkManager.GetComponent<NetworkManagerCOTL>().StartClient(uri);
        Plugin.Instance?.Logger.LogInfo("Joining " + uri);
    }
}