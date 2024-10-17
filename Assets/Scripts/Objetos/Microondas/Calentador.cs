using Logic;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calentador : MonoBehaviour
{
    private Light mLight;
    [SerializeField] private PuertaMicroondasScript mPuerta;
    [SerializeField] private List<Receta> mRecetas;
    [SerializeField] private List<Ingredient> mIngredientesDentro;
    public int mRecetaActual;
    private bool mCalentando;
    private Coroutine mCoroutineCooking;

    [Serializable]
    public struct Receta
    {
        public List<Ingredient> ingredientes;
        public float tiempoCoccion;
        public GameObject ingredienteResultante;
    }

    void Start()
    {
        mPuerta.OnDoorClosed += CerrarPuerta;
        mLight = GetComponent<Light>();
        mRecetaActual = -1;
    }

    private void CerrarPuerta(bool _puertaCerrada)
    {
        mLight.gameObject.SetActive(_puertaCerrada);
        mCalentando = _puertaCerrada;
        if (!_puertaCerrada)
        {
            mIngredientesDentro.Clear();
            mRecetaActual = -1;
            if (mCoroutineCooking != null)
                StopCoroutine(mCoroutineCooking);
        }
    }

    private int EncontrarReceta()
    {
        for (int i = 0; i < mRecetas.Count; i++)
        {
            var numeroIngredientesReceta = mRecetas[i].ingredientes.Count;
            var ingredientesCorrectos = 0;
            for(int j = 0; j < numeroIngredientesReceta; j++)
            {
                if (EstaElIngrediente(mRecetas[i].ingredientes[j]))
                {
                    ingredientesCorrectos++;
                }
            }
            if(ingredientesCorrectos == numeroIngredientesReceta)
            {
                return i;
            }
        }
        return -1;
    }

    private bool EstaElIngrediente(Ingredient ingrediente)
    {
        for (int i = 0; i < mIngredientesDentro.Count; i ++)
        {
            if (mIngredientesDentro[i] == ingrediente)
            {
                return true;
            }
        }

        return false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Ingredient ingrediente))
        {
            mIngredientesDentro.Add(ingrediente);
            mRecetaActual = EncontrarReceta();
            if (mRecetaActual != -1)
                Cocinar();
        }
    }

    private void Cocinar()
    {
        mCoroutineCooking = StartCoroutine(CookRoutine());
    }

    private IEnumerator CookRoutine()
    {
        while (mCalentando)
        {
            var numeroIngredientes = mRecetas[mRecetaActual].ingredientes.Count;
            var ingredientesCocinados = 0;
            for (int i = 0; i < numeroIngredientes; i++)
            {
                if (mRecetas[mRecetaActual].ingredientes[i].timeCooked < mRecetas[mRecetaActual].tiempoCoccion)
                    mRecetas[mRecetaActual].ingredientes[i].Cocinate();
                else
                    ingredientesCocinados++;
            }

            yield return new WaitForSeconds(1);
            
            if (ingredientesCocinados == numeroIngredientes)
            {
                RecetaAcabada();
                mCalentando = false;
            }
        }
    }

    private void RecetaAcabada()
    {
        /*while(mIngredientesDentro.Count > 0)
        {
            Destroy(mIngredientesDentro[0].gameObject);
        }*/

        GameObject cooked = Instantiate(mRecetas[mRecetaActual].ingredienteResultante);
        cooked.transform.position = transform.position;
    }
}
