using Mirror;
using UnityEngine;

public class NetworkPlayersManager : NetworkBehaviour
{

    public SyncList<SnakeController> _playerSnakeControllers = new SyncList<SnakeController>();

    public void AddNetworkPlayerToList(GameObject player)
    {
        _playerSnakeControllers.Add(player.GetComponent<SnakeController>());
    }

    public SnakeController GetPlayerSnakeController()
    {
        return _playerSnakeControllers.Find(prefab => prefab.isOwned);
    }
}