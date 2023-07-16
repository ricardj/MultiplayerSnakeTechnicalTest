using Mirror;
using UnityEngine;

public class NetworkedSingleton<T> : NetworkBehaviour where T : NetworkedSingleton<T>
{
    public static T get;

    public void Awake()
    {
        if (get == null)
        {
            get = (T)this;
        }
        else if (get != this)
        {
            Destroy(this.gameObject);
        }
    }

}