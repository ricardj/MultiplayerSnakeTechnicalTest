using System;
using UnityEngine;
using UnityEngine.Events;

public class ApplePickableController : IPickable
{

    public UnityEvent OnConsumed;

    public void Consume()
    {
        OnConsumed.Invoke();
        Destroy(gameObject);
    }
}
