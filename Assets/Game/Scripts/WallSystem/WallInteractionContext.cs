using System;
using UnityEngine;

[Serializable]
public class WallInteractionContext
{
    public WallController wallController;
    public IWallInteractable wallInteractable;
    public Vector3 wallCollissionOffset;
}
