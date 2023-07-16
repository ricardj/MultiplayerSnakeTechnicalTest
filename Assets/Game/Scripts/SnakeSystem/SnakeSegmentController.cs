using Mirror;
using UnityEngine;

public class SnakeSegmentController : NetworkBehaviour
{
      public Vector3 Position { get => transform.position; set => transform.position = value; }

}