using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ApplesManager : NetworkedSingleton<ApplesManager>
{
    [Header("Configuration")]
    [SerializeField] int _maxExclusive = 10;
    [SerializeField] int _maxApples = 3;

    [Header("References")]
    public ApplePickableController applePickableController;

    [Header("Events")]
    public PickContextEvent OnApplePicked;

    [Header("Debug")]
    [SerializeField] List<ApplePickableController> Pickables;


    [Server]
    public void Start()
    {
        
        StartCoroutine(SpawnSequence());
    }

    private IEnumerator SpawnSequence()
    {

        while (true)
        {
            ApplePickableController newApple = Instantiate(applePickableController);
            NetworkServer.Spawn(newApple.gameObject);
            newApple.transform.position = GetRandomPosition();
            Pickables.Add(newApple);
            newApple.OnPickablePickedEvent.AddListener(OnApplePicked.Invoke);
            newApple.OnConsumed.AddListener(() => Pickables.Remove(newApple));


            yield return new WaitUntil(() => Pickables.Count < _maxApples);

            yield return null;

        }

    }

    private Vector3 GetRandomPosition()
    {
        return new Vector3(Random.Range(-_maxExclusive, _maxExclusive),0, Random.Range(-_maxExclusive, _maxExclusive));
    }
}
