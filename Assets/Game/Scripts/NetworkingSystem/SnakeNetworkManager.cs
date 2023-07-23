using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SnakeNetworkManager : NetworkManager
{
    public static new SnakeNetworkManager singleton { get; private set; }
    [SerializeField] NetworkPlayersManager networkPlayersManager;


    [Header("UnityEvents")]
    public SnakeControllerEvent OnSnakePrefabAdded;



    public override void Awake()
    {
        base.Awake();
        singleton = this;
    }


    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        GameObject player = Instantiate(playerPrefab);
        NetworkServer.AddPlayerForConnection(conn, player);
        networkPlayersManager.AddNetworkPlayerToList(player);
    }

    

    public override void OnServerDisconnect(NetworkConnectionToClient conn)
    {
        base.OnServerDisconnect(conn);
        conn.DestroyOwnedObjects();
    }

    public override void OnClientConnect()
    {
        base.OnClientConnect();
    }
  

    public SnakeController GetClientSnakeController()
    {
        return networkPlayersManager.GetPlayerSnakeController();
    }
}
