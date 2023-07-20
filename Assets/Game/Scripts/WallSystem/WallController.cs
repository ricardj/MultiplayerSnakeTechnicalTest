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
        Debug.LogError("So far sogood");
        IWallInteractable wallInteractable = other.attachedRigidbody.gameObject.GetComponent<IWallInteractable>();
        if (wallInteractable != null)
        {

            OnWallInteractableCollisioned.Invoke(new WallInteractionContext()
            {
                wallController = this,
                wallInteractable = wallInteractable,
            });
        }
    }
}
