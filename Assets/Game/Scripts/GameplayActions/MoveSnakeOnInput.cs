using System.Collections;
using UnityEngine;

public class MoveSnakeOnInput : MonoBehaviour
{
    [SerializeField] SnakeController _snakeController;
    [SerializeField] InputManager _inputManager;


    public void Start()
    {
        _inputManager.OnGoUp.AddListener(() => _snakeController.GoUp());
        _inputManager.OnGoDown.AddListener(() => _snakeController.GoDown());
        _inputManager.OnGoLeft.AddListener(() => _snakeController.GoLeft());
        _inputManager.OnGoRight.AddListener(() => _snakeController.GoRight());

    }
}
