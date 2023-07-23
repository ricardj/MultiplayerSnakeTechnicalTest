using Mirror;
using UnityEngine;

public class SnakeSegmentController : NetworkBehaviour
{
    private static int minMotionDistanceForTeleporting = 3;
    [SerializeField] NetworkTransformReliable networkTransform;

    public Vector3 Position
    {
        get => transform.position;
        set
        {
            float motionDistance = Vector3.Magnitude(transform.position - value);
            if (motionDistance > minMotionDistanceForTeleporting)
            {
                this.Teleport(value);
            }
            else
            {
                transform.position = value;
            }
        }
    }

    public void Teleport(Vector3 targetPosition)
    {
        networkTransform.CmdTeleport(targetPosition);
    }


}