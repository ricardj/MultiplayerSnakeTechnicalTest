using UnityEngine;

public interface IWallInteractable
{
    public Transform Transform { get; }
    public Collider Collider { get; }

    void Teleport(Vector3 vector3);
}

