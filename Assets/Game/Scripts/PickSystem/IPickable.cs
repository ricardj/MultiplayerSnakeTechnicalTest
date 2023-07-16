using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IPickable : NetworkBehaviour
{

    public PickContextEvent OnPickablePickedEvent;

    public void OnTriggerEnter(Collider other)
    {

        IPicker picker = other.attachedRigidbody.GetComponent<IPicker>(); 
        if(picker != null)
        {
            OnPickablePickedEvent.Invoke(new PickContext()
            {
                picker = picker,
                pickable = this
            });
            //OnPickablePicked();
        }
    }

    //public abstract void OnPickablePicked();
}
