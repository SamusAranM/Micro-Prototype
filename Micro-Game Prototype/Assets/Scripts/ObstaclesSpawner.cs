using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesSpawner : MonoBehaviour
{
    ObjectPooler objectPooler;

    public float respawnTime = 3.0f;

    private void Start()
    {
        objectPooler = ObjectPooler.Instance;
        StartCoroutine(spawnWave());
    }

    //private void FixedUpdate() // a test on what he did 
    //{
       // objectPooler.SpawnFromPool("Cactus", transform.position);
    //}

    IEnumerator spawnWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            objectPooler.SpawnFromPool("Cactus", transform.position);
            objectPooler.SpawnFromPool("Bird", transform.position);
        }
    }
}
