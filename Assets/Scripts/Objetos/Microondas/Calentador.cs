using Logic;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calentador : FusionadorDeIngredientes
{
    private Light mLight;
    [SerializeField] private PuertaMicroondasScript mPuerta;

    protected override void Start()
    {
        base.Start();
        mPuerta.OnDoorClosed += CerrarPuerta;
        mLight = GetComponent<Light>();
    }

    private void CerrarPuerta(bool _puertaCerrada)
    {
        mLight.gameObject.SetActive(_puertaCerrada);
        mTrabajando = _puertaCerrada;
        if (!_puertaCerrada)
        {
            mIngredientesDentro.Clear();
            mIngredienteDentroPorSeparado.Clear();
            mRecetaActual = -1;
            if (mCoroutineCooking != null)
                StopCoroutine(mCoroutineCooking);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Ingredient ingrediente))
        {
            if (EstaElIngrediente(ingrediente.eIngrediente))
            {
                AumentarCantidadDeDentro(ingrediente);
                mIngredienteDentroPorSeparado.Add(other.gameObject);
            }
            else
            {
                mIngredientesDentro.Add(new IngredienteCantidad(ingrediente, 1));
                mIngredienteDentroPorSeparado.Add(other.gameObject);
            }

            mRecetaActual = EncontrarReceta();

            if (mRecetaActual != -1)
                Cocinar();
        }
    }

    

   
}
