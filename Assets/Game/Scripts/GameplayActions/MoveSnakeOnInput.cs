using Mirror;
using System.Collections;
using UnityEngine;

public class MoveSnakeOnInput : NetworkBehaviour
{

    [Header("References")]
    [SerializeField] InputManager _inputManager;
    [SerializeField] SnakeNetworkManager _networkManager;


    [Header("Debug values")]
    [SerializeField] SnakeController _snakeController;

    [Client]
    public void Start()
    {
        _networkManager.OnSnakePlayerCreated.AddListener(() =>
        {
            _snakeController = _networkManager.GetClientSnakeController();
            _inputManager.OnGoUp.AddListener(() => _snakeController.GoUp());
            _inputManager.OnGoDown.AddListener(() => _snakeController.GoDown());
            _inputManager.OnGoLeft.AddListener(() => _snakeController.GoLeft());
            _inputManager.OnGoRight.AddListener(() => _snakeController.GoRight());
        });

    }
}
