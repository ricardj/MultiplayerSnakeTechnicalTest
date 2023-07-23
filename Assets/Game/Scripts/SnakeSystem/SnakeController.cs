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

    [Header("Unity Events")]
    public SnakeControllerEvent OnSnakeCollisionedWithSegment;



    public void Update()
    {
        _updateCounter += Time.deltaTime;
        if (_updateCounter < _updatePeriod)
            return;
        _updateCounter = 0;




        if (_snakeSegments.Count > 0)
        {

            for (int i = _snakeSegments.Count - 1; i > 0; i--)
            {
                SnakeSegmentController currentSnakeSegment = _snakeSegments[i];
                SnakeSegmentController previousSnakeSegment = _snakeSegments[i - 1];
                if (currentSnakeSegment != null)
                    currentSnakeSegment.Position = previousSnakeSegment.Position;

            }
            if (_snakeSegments[0] != null)
                _snakeSegments[0].Position = transform.position;
        }

        this.transform.position = new Vector3(
            MathF.Round(this.transform.position.x) + direction.x,
            0,
            Mathf.Round(this.transform.position.z) + direction.z
            );


    }



    public void Grow()
    {
        Vector3 targetPosition = _snakeSegments.Count > 0 ? _snakeSegments.Last().Position : transform.position;
        SnakeSegmentController newController = Instantiate(_snakeSegmentPrefab, targetPosition, Quaternion.identity);
        NetworkServer.Spawn(newController.gameObject, this.gameObject);
        //if (_snakeSegments.Count > 0)
        //{
        //    newController.Position = _snakeSegments.Last().Position;

        //}
        //else
        //{
        //    newController.Position = transform.position;
        //}
        _snakeSegments.Add(newController);
    }


    public void GoDown()
    {
        if (direction != Vector3.forward)
            direction = Vector3.back;
    }

    public void GoLeft()
    {
        if (direction != Vector3.right)
            direction = Vector3.left;
    }

    public void GoRight()
    {
        if (direction != Vector3.left)
            direction = Vector3.right;
    }

    public void GoUp()
    {
        if (direction != Vector3.back)
            direction = Vector3.forward;
    }




    public void OnTriggerEnter(Collider collision)
    {
        if (collision.attachedRigidbody != null)
        {
            SnakeSegmentController snakeSegmentController = collision.attachedRigidbody.GetComponent<SnakeSegmentController>();
            if (snakeSegmentController != null)
            {

                if (_snakeSegments.Count == 0)
                {
                    InvokeCollision();
                }
                else
                {
                    int firstSegmentsToExclude = 2;
                    for (int i = 0; i < firstSegmentsToExclude; i++)
                    {
                        if (_snakeSegments.Count > i && _snakeSegments[i] == snakeSegmentController)
                        {
                            return;
                        }
                    }
                    InvokeCollision();
                }

            }
        }
    }

    private void InvokeCollision()
    {
        OnSnakeCollisionedWithSegment.Invoke(this);
    }
}
