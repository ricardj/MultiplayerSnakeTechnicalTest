using Mirror;
using System.Collections;
using UnityEngine;

public class MoveSnakeOnInput : NetworkBehaviour
{

    [Header("References")]
    [SerializeField] InputManager _inputManager;
    [SerializeField] SnakeNetworkManager _networkManager;
    [SerializeField] NetworkPlayersManager _networkPlayersManager;


    [Header("Debug values")]
    [SerializeField] SnakeController _snakeController;

    [Client]
    public IEnumerator Start()
    {
        yield return new WaitUntil(() => _networkManager.GetClientSnakeController() != null);
            _snakeController = _networkManager.GetClientSnakeController();
            _inputManager.OnGoUp.AddListener(() => _snakeController.GoUp());
            _inputManager.OnGoDown.AddListener(() => _snakeController.GoDown());
            _inputManager.OnGoLeft.AddListener(() => _snakeController.GoLeft());
            _inputManager.OnGoRight.AddListener(() => _snakeController.GoRight());
      

    }
}
