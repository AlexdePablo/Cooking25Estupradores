using System;
using UnityEngine;

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
        ingredient.transform.position = transform.position;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        print("Start Spawner");
        for(int i = 0; i < mIngredientsToSpawn; i++)
        {
            GameObject ingredient = mPool.GetElement();
            ingredient.transform.position = transform.position;
        }
    }
}
