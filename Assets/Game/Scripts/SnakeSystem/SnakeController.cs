using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    [SerializeField] List<SnakeSegmentController> _snakeSegments;
    [SerializeField] SnakeSegmentController _snakeSegmentPrefab;

    [Header("Configuration")]
    [SerializeField] float _updatePeriod;    

    [Header("Debug values")]
    [SerializeField] Vector3 direction;
    [SerializeField] float _updateCounter;

    


    public void Update()
    {
        _updateCounter += Time.deltaTime;        
        if (_updateCounter < _updatePeriod)
            return;
        _updateCounter = 0;


        _snakeSegments[0].Position = transform.position;
        for (int i = _snakeSegments.Count -1; i > 0; i--)
        {
            SnakeSegmentController currentSnakeSegment = _snakeSegments[i];
            SnakeSegmentController previousSnakeSegment = _snakeSegments[i - 1];
            currentSnakeSegment.Position = previousSnakeSegment.Position;
        }

        this.transform.position = new Vector3(
            MathF.Round(this.transform.position.x) + direction.x,
            0,
            Mathf.Round(this.transform.position.z) + direction.z
            );
    }



    public void Grow()
    {
        SnakeSegmentController newController = Instantiate(_snakeSegmentPrefab);
        newController.Position = _snakeSegments.Last().Position;
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
    }
}
