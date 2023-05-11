﻿using COTL_Multiplayer.Manager;
using kcp2k;
using Mirror;
using UnityEngine;

namespace COTL_Multiplayer.Helper;

public static class NetworkManagerHelper
{
    public static GameObject CreateNetworkManager()
    {
        var networkManager = new GameObject("NetworkManager");
        
        var managerScript = networkManager.AddComponent<NetworkManagerCOTL>();
        var managerHud = networkManager.AddComponent<NetworkManagerHUD>();
        var kcpTransport = networkManager.AddComponent<KcpTransport>();

        managerScript.transport = kcpTransport;

        return networkManager;
    }
}