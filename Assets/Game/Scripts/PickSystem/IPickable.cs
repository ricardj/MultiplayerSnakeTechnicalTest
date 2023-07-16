using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IPickable : MonoBehaviour
{

    public PickContextEvent OnPickablePicked;

    public void OnTriggerEnter(Collider other)
    {
        IPicker picker = other.GetComponent<IPicker>(); 
        if(picker != null)
        {
            OnPickablePicked.Invoke(new PickContext()
            {
                picker = picker,
                pickable = this
            });
        }
    }
}
