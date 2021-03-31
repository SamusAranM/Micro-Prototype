using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesSpawner : MonoBehaviour
{
    ObjectPooler objectPooler;
    public float respawnTime = 3.0f;
    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnWave());
        objectPooler = ObjectPooler.Instance;
    }

    
    IEnumerator SpawnWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            objectPooler.SpawnFromPool("Cactus", transform.position);
            objectPooler.SpawnFromPool("Bird", transform.position);
        }
        
    }
}
