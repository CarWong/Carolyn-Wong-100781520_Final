using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckPooler : MonoBehaviour
{
    public static DuckPooler instance;

    public List<DuckPool> pools;

    Queue<GameObject> objectPool;

    public Dictionary<string, Queue<GameObject>> poolDictionary;


    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (DuckPool pool in pools)
        {
            objectPool = new Queue<GameObject>();
            
            for(int i = 0; i< pool.size; i++)
            {
                GameObject duckobj = Instantiate(pool.prefab);
                duckobj.SetActive(false);
                objectPool.Enqueue(duckobj);
            }
            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 position)
    {
        GameObject duckspawn = poolDictionary[tag].Dequeue();

        duckspawn.SetActive(true);
        duckspawn.transform.position = position;

        poolDictionary[tag].Enqueue(duckspawn);

        return duckspawn;
    }
}
