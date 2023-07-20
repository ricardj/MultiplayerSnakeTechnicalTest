using UnityEngine;

public interface IWallInteractable
{
    public Transform Transform { get; }
    public Collider Collider { get; }
}

