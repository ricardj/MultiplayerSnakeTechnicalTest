using Mirror;
using UnityEngine;
using UnityEngine.Events;

public class NetworkPlayersManager : NetworkBehaviour
{

    
    public SyncList<SnakeController> _playerSnakeControllers = new SyncList<SnakeController>();
    [Header("Events")]
    public UnityEvent OnSnakePlayerCreated;
    public void AddNetworkPlayerToList(GameObject player)
    {
        _playerSnakeControllers.Add(player.GetComponent<SnakeController>());
        OnSnakePlayerCreated.Invoke();
    }

    public SnakeController GetPlayerSnakeController()
    {
        return _playerSnakeControllers.Find(prefab => prefab != null && prefab.isClient);
    }
}