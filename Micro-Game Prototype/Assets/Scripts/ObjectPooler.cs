using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    #region Singleton

    public static ObjectPooler Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary; // to have multiple pools

    // Start is called before the first frame update
    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools) 
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++) // fill out entire pool by instantiating objects as we define in size
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj); // adds this to the end of the queue
            }

            poolDictionary.Add(pool.tag, objectPool); // add pool to dictionary
        }
    }

    public GameObject SpawnFromPool (string tag, Vector3 position) // taking inactive objects and spawning them into active world
    {
        if (!poolDictionary.ContainsKey(tag)) // fail safe
        {
            Debug.Log("Pool with tag " + tag + " doesn't exist.");
            return null;
        }

        GameObject objectToSpawn = poolDictionary[tag].Dequeue(); // pull out the first element in the queue 

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;

        IPooledObjects pooledObj = objectToSpawn.GetComponent<IPooledObjects>();

        if (pooledObj != null)
        {
            pooledObj.OnObjectSpawn();
        }

        poolDictionary[tag].Enqueue(objectToSpawn); // add it back to queue

        return objectToSpawn;
    }
}
