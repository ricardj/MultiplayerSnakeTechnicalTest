using UnityEngine;

public class StartConnectionOnStartScreen : MonoBehaviour
{
    [SerializeField] StartScreenManager startScreenManager;
    [SerializeField] SnakeNetworkManager snakeNetworkManager;
    public void Start()
    {
        startScreenManager.OnHostButtonPressed.AddListener(() =>
        {
            snakeNetworkManager.StartHost();
            startScreenManager.HideScreen();
        });

        startScreenManager.OnClientButtonPressed.AddListener(() =>
        {
            snakeNetworkManager.StartClient();
            startScreenManager.HideScreen();
        });
    }

}
