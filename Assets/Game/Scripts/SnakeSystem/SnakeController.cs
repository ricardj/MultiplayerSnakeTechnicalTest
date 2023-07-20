using Mirror;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SnakeController : NetworkBehaviour, IPicker, IWallInteractable
{
    [SerializeField] SyncList<SnakeSegmentController> _snakeSegments = new SyncList<SnakeSegmentController>();
    [SerializeField] SnakeSegmentController _snakeSegmentPrefab;
    [SerializeField] Collider _snakeCollider;
    [Header("Configuration")]
    [SerializeField] float _updatePeriod;

    [Header("Debug values")]
    [SerializeField] Vector3 direction;
    [SerializeField] float _updateCounter;

    public Transform Transform => transform;
    public Collider Collider => _snakeCollider;

    public void Update()
    {
        _updateCounter += Time.deltaTime;
        if (_updateCounter < _updatePeriod)
            return;
        _updateCounter = 0;

        this.transform.position = new Vector3(
           MathF.Round(this.transform.position.x) + direction.x,
           0,
           Mathf.Round(this.transform.position.z) + direction.z
           );


        if (_snakeSegments.Count > 0)
        {

            _snakeSegments[0].Position = transform.position;
            for (int i = _snakeSegments.Count - 1; i > 0; i--)
            {
                SnakeSegmentController currentSnakeSegment = _snakeSegments[i];
                SnakeSegmentController previousSnakeSegment = _snakeSegments[i - 1];
                currentSnakeSegment.Position = previousSnakeSegment.Position;
            }
        }


    }



    public void Grow()
    {
        SnakeSegmentController newController = Instantiate(_snakeSegmentPrefab);
        NetworkServer.Spawn(newController.gameObject);
        if (_snakeSegments.Count > 0)
        {
            newController.Position = _snakeSegments.Last().Position;

        }
        else
        {
            newController.Position = transform.position;
        }
        _snakeSegments.Add(newController);
    }


    public void GoDown()
    {
        direction = Vector3.back;
    }

    public void GoLeft()
    {
        direction = Vector3.left;
    }

    public void GoRight()
    {
        direction = Vector3.right;
    }

    public void GoUp()
    {
        direction = Vector3.forward;

        //Debug.LogError("Keys pressed");
    }
}
