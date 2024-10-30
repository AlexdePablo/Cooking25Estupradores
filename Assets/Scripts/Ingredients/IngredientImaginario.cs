using Logic;
using System;
using System.Collections;
using UnityEngine;

public class IngredientImaginario : MonoBehaviour
{
    private Material mMaterial;
    [SerializeField] private Ingredientes mIngredienteEnum;
    public Ingredientes IngredienteEnum => mIngredienteEnum;

    private void Awake()
    {
        mMaterial = GetComponent<MeshRenderer>().material;
        mMaterial.SetFloat("_Threshold", 1);
        gameObject.SetActive(true);
    }

    public void MakeVisible()
    {
        gameObject.SetActive(true);
        GetComponent<Collider>().enabled = true;
        StartCoroutine(Vanecer());
    }

    private IEnumerator Vanecer()
    {
        while (mMaterial.GetFloat("_Threshold") > 0)
        {
            mMaterial.SetFloat("_Threshold", mMaterial.GetFloat("_Threshold") - Time.deltaTime);
            yield return new WaitForFixedUpdate();
        }

    }

    public void MakeInvisible()
    {
        StartCoroutine(Desvanecer());
    }
    private IEnumerator Desvanecer()
    {
        while (mMaterial.GetFloat("_Threshold") < 1)
        {
            mMaterial.SetFloat("_Threshold", mMaterial.GetFloat("_Threshold") + Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }

        GetComponent<Collider>().enabled = false;
        gameObject.SetActive(false);
    }
}
