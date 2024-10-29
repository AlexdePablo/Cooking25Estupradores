using Logic;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FusionadorDeIngredientes : MonoBehaviour
{
    [SerializeField] protected List<Receta> mRecetas;
    [SerializeField] protected List<IngredienteCantidad> mIngredientesDentro;
    public int mRecetaActual;
    protected bool mTrabajando;
    protected Coroutine mCoroutineCooking;

    protected virtual void Start()
    {
        mRecetaActual = -1;
    }

    protected int EncontrarReceta()
    {
        for (int i = 0; i < mRecetas.Count; i++)
        {
            var numeroIngredientesReceta = mRecetas[i].ingredientes.Count;
            var ingredientesCorrectos = 0;
            for (int j = 0; j < numeroIngredientesReceta; j++)
            {
                if (EstaElIngrediente(mRecetas[i].ingredientes[j].eIngredient))
                {
                    if (EstaLaCantidadIngrediente(mRecetas[i].ingredientes[j].eIngredient, mRecetas[i].ingredientes[j].cantidad))
                        ingredientesCorrectos++;
                }
            }
            if (ingredientesCorrectos == numeroIngredientesReceta)
            {
                return i;
            }
        }
        return -1;
    }

    private bool EstaLaCantidadIngrediente(Ingredientes ingrediente, int cantidad)
    {
        for (int i = 0; i < mIngredientesDentro.Count; i++)
        {
            if (mIngredientesDentro[i].ingrediente.eIngrediente == ingrediente)
            {
                if (mIngredientesDentro[i].cantidad == cantidad)
                    return true;
            }
        }
        return false;
    }

    protected bool EstaElIngrediente(Ingredientes ingrediente)
    {
        for (int i = 0; i < mIngredientesDentro.Count; i++)
        {
            if (mIngredientesDentro[i].ingrediente.eIngrediente == ingrediente)
            {
                return true;
            }
        }
        return false;
    }
    protected void Cocinar()
    {
        mCoroutineCooking = StartCoroutine(CookRoutine());
    }

    protected IEnumerator CookRoutine()
    {
        while (mTrabajando)
        {
            var numeroIngredientes = mRecetas[mRecetaActual].ingredientes.Count;
            var ingredientesCocinados = 0;
            for (int i = 0; i < numeroIngredientes; i++)
            {
                if (mIngredientesDentro[i].ingrediente.timeCooked < mRecetas[mRecetaActual].tiempoEjecucion)
                    mIngredientesDentro[i].ingrediente.Cocinate();
                else
                    ingredientesCocinados++;
            }

            yield return new WaitForSeconds(1);

            if (ingredientesCocinados == numeroIngredientes)
            {
                RecetaAcabada();
                mTrabajando = false;
            }
        }
    }
    protected void RecetaAcabada()
    {
        for (int i = mIngredientesDentro.Count - 1; i >= 0; i--)
        {
            if (mIngredientesDentro[i].ingrediente.gameObject.TryGetComponent<Pooleable>(out Pooleable pooleable))
                pooleable.ReturnToPool();
            else
                Destroy(mIngredientesDentro[i].ingrediente.gameObject);
        }

        GameObject cooked = Instantiate(mRecetas[mRecetaActual].ingredienteResultante);
        cooked.transform.position = transform.position;
    }

    protected void AumentarCantidadDeDentro(Ingredient ingredient)
    {
        for (int i = 0; i < mIngredientesDentro.Count; i++)
        {
            if (ingredient.eIngrediente == mIngredientesDentro[i].ingrediente.eIngrediente)
            {
                IngredienteCantidad temp = mIngredientesDentro[i];
                temp.cantidad++;
                mIngredientesDentro[i] = temp;
            }
        }
    }
}
