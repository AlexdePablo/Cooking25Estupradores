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

    [Header("Transform de los platos")]
    [SerializeField] private Transform mPlatoHeroin;
    [SerializeField] private Transform mPlatoChocoleit;
    [SerializeField] private Transform mPlatoShugar;
    [SerializeField] private Transform mPlatoEcs;
    [SerializeField] private Transform mPlatoBater;
    [SerializeField] private Transform mPlatoSalt;

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
            switch(ingrediente.GetComponent<IngredientImaginario>().IngredienteEnum)
            {
                case Logic.Ingredientes.CHOCOLEIT:
                    ingrediente.transform.position = mPlatoChocoleit.position;
                    break;
                case Logic.Ingredientes.HEROIN:
                    ingrediente.transform.position = mPlatoHeroin.position;
                    break;
                case Logic.Ingredientes.BATER:
                    ingrediente.transform.position = mPlatoBater.position;
                    break;
                case Logic.Ingredientes.ECS:
                    ingrediente.transform.position = mPlatoEcs.position;
                    break;
                case Logic.Ingredientes.SAL:
                    ingrediente.transform.position = mPlatoSalt.position;
                    break;
                case Logic.Ingredientes.SHUGAR:
                    ingrediente.transform.position = mPlatoShugar.position;
                    break;
                default:
                    print("AAAAAA");
                    break;
            }
            
            mObjetosInvisibles.Add(ingrediente);
        }

        GetAlimentsVisible();   
    }

    private void GetAlimentsVisible()
    {
        for (int i = 0; i < mObjetosInvisibles.Count; i++)
        {
            mObjetosInvisibles[i].GetComponent<IngredientImaginario>().MakeVisible(); 
        }
    }

    private void DespawnInvisibles()
    {
        for (int i = 0; i < mObjetosInvisibles.Count; i++)
        {
            mObjetosInvisibles[i].GetComponent<IngredientImaginario>().MakeInvisible();
        }
    }
}
