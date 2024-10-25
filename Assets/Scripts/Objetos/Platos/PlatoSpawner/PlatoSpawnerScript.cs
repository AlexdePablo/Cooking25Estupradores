using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlatoSpawnerScript : MonoBehaviour
{
    [SerializeField] private int mIngredientsToSpawn;
    private Pool mPool;

    private void Awake()
    {
        mPool = GetComponent<Pool>();
        mPool.onItemReturned += SpawnItem;
    }

    private void SpawnItem()
    {
        GameObject ingredient = mPool.GetElement();
        ingredient.transform.localPosition = new Vector3(Random.Range(-1f, 1f), 3, Random.Range(-1f, 1f));//transform.position;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for(int i = 0; i < mIngredientsToSpawn; i++)
        {
            GameObject ingredient = mPool.GetElement();
            ingredient.transform.localPosition = new Vector3(Random.Range(-1f, 1f), 3, Random.Range(-1f, 1f));//transform.position;
        }
    }
}
