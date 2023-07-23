using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

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
    }

    public override void OnClientConnect()
    {
        base.OnClientConnect();
    }

    public override void OnClientDisconnect()
    {
        base.OnClientDisconnect();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public SnakeController GetClientSnakeController()
    {
        return networkPlayersManager.GetPlayerSnakeController();
    }
}
