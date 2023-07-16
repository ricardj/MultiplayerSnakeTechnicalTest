using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
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