using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    [Header("Configuration")]
    [SerializeField] KeyCode[] upKeys;
    [SerializeField] KeyCode[] downKeys;
    [SerializeField] KeyCode[] leftKeys;
    [SerializeField] KeyCode[] rightKeys;
    


    [Header("Unity events")]
    public UnityEvent OnGoUp;
    public UnityEvent OnGoDown;
    public UnityEvent OnGoLeft;
    public UnityEvent OnGoRight;

    // Update is called once per frame
    void Update()
    {
        CheckInput(upKeys, OnGoUp.Invoke);
        CheckInput(downKeys, OnGoDown.Invoke);
        CheckInput(leftKeys, OnGoLeft.Invoke);

        CheckInput(rightKeys, OnGoRight.Invoke);
    }

    private void CheckInput(KeyCode[] targetKeys, Action targetCallback)
    {
        for (int i = 0; i < targetKeys.Length; i++)
        {
            if (Input.GetKeyDown(targetKeys[i]))
            {
                Debug.LogError("Keys pressed");
                targetCallback.Invoke();
            }
        }
    }
}
