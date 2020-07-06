using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour {

    [System.Serializable]
    public class Pool
    {
        public string Tag;
        public GameObject Prefab;
        public int Size;
    }
    
    #region Singleton
    public static ObjectPooler Instance;
        
    private void Awake()
    {
        Instance = this;
        InitializePool();
    }
    #endregion
    public List<Pool> Pools;
    public Dictionary<string,Queue<GameObject>> PoolDictionary;
	
    private void InitializePool () {

        PoolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach(Pool pool in Pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            if (pool.Tag.StartsWith("pattern"))
            {
                pool.Size = 1;
            }

            for (int i = 0; i < pool.Size; i++)
            {
                GameObject obj = Instantiate(pool.Prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            PoolDictionary.Add(pool.Tag, objectPool);
        }
	}

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
     
        GameObject objectToSpawn = PoolDictionary[tag].Dequeue();

        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;
        objectToSpawn.SetActive(true);

        PoolDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }
}
