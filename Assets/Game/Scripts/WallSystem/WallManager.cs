using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallManager : MonoBehaviour
{
    [SerializeField] List<WallController> wallControllers;

    public void Start()
    {
        wallControllers.ForEach(wallController =>
        {
            wallController.OnWallInteractableCollisioned.AddListener(this.TeleportWallInteractable);
        });
    }

    private void TeleportWallInteractable(WallInteractionContext wallInteractionContext)
    {
        StartCoroutine(TeleportWallInteractableSequence(wallInteractionContext));

    }

    private IEnumerator TeleportWallInteractableSequence(WallInteractionContext wallInteractionContext)
    {
        IWallInteractable wallInteractable = wallInteractionContext.wallInteractable;
        WallController wallController = wallInteractionContext.wallController;
        WallController oppositieWallController = wallController.OppositeWall;
        Vector3 collisionOffsest = wallInteractionContext.wallCollissionOffset;

        wallInteractable.Transform.position = oppositieWallController.transform.position + collisionOffsest;

        wallInteractable.Collider.enabled = false;
        yield return new WaitForSeconds(0.3f);
        wallInteractable.Collider.enabled = true;
        yield return new WaitForSeconds(0.3f);

        //wallInteractable.Transform.position = oppositieWallController.transform.position;
    }
}
