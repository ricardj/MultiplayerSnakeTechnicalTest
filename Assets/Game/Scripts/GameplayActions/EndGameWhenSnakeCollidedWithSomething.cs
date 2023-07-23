using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameWhenSnakeCollidedWithSomething : MonoBehaviour
{
    [SerializeField] SnakeNetworkManager snakeNetworkManager;
    [SerializeField] EndGameScreenManager endGameScreenManager;

    public IEnumerator Start()
    {
        yield return new WaitUntil(() => snakeNetworkManager.GetClientSnakeController());
        SnakeController snakeController = snakeNetworkManager.GetClientSnakeController();
        snakeController.OnSnakeCollisionedWithSegment.AddListener(snake =>
        {
            endGameScreenManager.ShowScreen();
            snakeNetworkManager.StopHost();
        });
    }
}
