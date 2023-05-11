﻿using Mirror;
using UnityEngine;

namespace COTL_Multiplayer.Manager;

/*
	Documentation: https://mirror-networking.gitbook.io/docs/components/network-manager
	API Reference: https://mirror-networking.com/docs/api/Mirror.NetworkManager.html
*/

// Custom NetworkManager that simply assigns the correct racket positions when
// spawning players. The built in RoundRobin spawn method wouldn't work after
// someone reconnects (both players would be on the same side).
[AddComponentMenu("")]
public class NetworkManagerCOTL : NetworkManager
{
    public Transform leftRacketSpawn;
    public Transform rightRacketSpawn;
    private GameObject ball;

    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        // add player at correct spawn position
        var start = numPlayers == 0 ? leftRacketSpawn : rightRacketSpawn;
        var player = Instantiate(playerPrefab, start.position, start.rotation);
        NetworkServer.AddPlayerForConnection(conn, player);

        // spawn ball if two players
        if (numPlayers == 2)
        {
            ball = Instantiate(spawnPrefabs.Find(prefab => prefab.name == "Ball"));
            NetworkServer.Spawn(ball);
        }
    }

    public override void OnServerDisconnect(NetworkConnectionToClient conn)
    {
        // destroy ball
        if (ball != null)
            NetworkServer.Destroy(ball);

        // call base functionality (actually destroys the player)
        base.OnServerDisconnect(conn);
    }
}