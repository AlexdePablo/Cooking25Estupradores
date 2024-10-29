using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ImaginariumScript : MonoBehaviour
{
    [SerializeField] private DrunkCameraScript mDrunkCamera;
    [SerializeField] private List<GameObject> mImaginariosPrefab;
    [SerializeField] private int mNumeroIngredientesSpawn;
    private List<GameObject> mObjetosInvisibles = new();



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mDrunkCamera.onMarihuanedBehavioured += MarihuanaBehaviour;
    }

    private void MarihuanaBehaviour(bool _marihuaned)
    {
        if (_marihuaned)
        {
            SpawnInvisibles();
        }
        else
        {
            DespawnInvisibles();
        }
    }

    private void SpawnInvisibles()
    {
        if(mObjetosInvisibles.Count == 0)
        {
            CreateInvisibleAliments();
        }
        else
        {
            GetAlimentsVisible();
        }
    }
    private void CreateInvisibleAliments()
    {
        for(int i = 0; i < mNumeroIngredientesSpawn; i++)
        {
            GameObject ingrediente = Instantiate(mImaginariosPrefab[Random.Range(0, mImaginariosPrefab.Count)], transform);
            transform.position = new Vector3(Random.Range(0, 4f), 4, Random.Range(0, 4f));
            mObjetosInvisibles.Add(ingrediente);
        }

        GetAlimentsVisible();   
    }

    private void GetAlimentsVisible()
    {
                
    }

    private void DespawnInvisibles()
    {
        
    }
}
