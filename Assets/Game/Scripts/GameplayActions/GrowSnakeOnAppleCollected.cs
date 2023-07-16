using Mirror;
using UnityEngine;

public class GrowSnakeOnAppleCollected : NetworkBehaviour
{
    [SerializeField] ApplesManager _appleManager;

    [Server]
    public void Start()
    {
        _appleManager.OnApplePicked.AddListener(context =>
        {
            if (context.pickable is ApplePickableController && context.picker is SnakeController)
            {
                ApplePickableController applePickable = (ApplePickableController)context.pickable;
                SnakeController snakeController = (SnakeController)context.picker;
                applePickable.Consume();
                snakeController.Grow();
                
            }
        });
    }
}
