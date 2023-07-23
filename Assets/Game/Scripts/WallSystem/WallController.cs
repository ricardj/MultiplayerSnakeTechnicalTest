using System;
using System.Collections;
using UnityEngine;

public class WallController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] WallController oppositeWall;

    [Header("Unity events")]
    public WallInteractionContextEvent OnWallInteractableCollisioned;

    public WallController OppositeWall { get => oppositeWall; set => oppositeWall = value; }

    public void OnTriggerEnter(Collider other)
    {

        IWallInteractable wallInteractable = other.attachedRigidbody.gameObject.GetComponent<IWallInteractable>();
        if (wallInteractable != null)
        {

            OnWallInteractableCollisioned.Invoke(new WallInteractionContext()
            {
                wallController = this,
                wallInteractable = wallInteractable,
                wallCollissionOffset = wallInteractable.Transform.position - this.transform.position
            });
        }
    }
}
