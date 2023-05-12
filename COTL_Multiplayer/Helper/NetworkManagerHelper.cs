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

        networkManager.SetActive(true);
        return networkManager;
    }
}