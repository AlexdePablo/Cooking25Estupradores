using Logic;
using System.Collections.Generic;
using UnityEngine;

public class BoteEcs : FusionadorDeIngredientes
{
    private void OnTriggerEnter(Collider other)
    {

        if (other.TryGetComponent(out Ingredient ingrediente))
        {
            if (EstaElIngrediente(ingrediente.eIngrediente))
            {
                AumentarCantidadDeDentro(ingrediente);
            }
            else
            {
                mIngredientesDentro.Add(new IngredienteCantidad(ingrediente, 1));
            }

            mRecetaActual = EncontrarReceta();

        }
        if (mRecetaActual != -1)
        {
            mTrabajando = true;
            Cocinar();
        }
    }

    private void OnDisable()
    {
        mIngredientesDentro.Clear();
        if (mCoroutineCooking != null)
        {
            mTrabajando = false;
            StopCoroutine(mCoroutineCooking);
        }
    }
}
