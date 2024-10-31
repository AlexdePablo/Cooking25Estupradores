using Logic;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class Calentador : FusionadorDeIngredientes
{
    private Light mLight;
    [SerializeField] private PuertaMicroondasScript mPuerta;
    private AudioSource mAudioSource;

    [SerializeField] private AudioClip mMicrowaveEnds;
    [SerializeField] private AudioClip mMicrowaveWorks;

    protected override void Start()
    {
        base.Start();
        mPuerta.OnDoorClosed += CerrarPuerta;
        mLight = GetComponent<Light>();
        mAudioSource = transform.parent.GetComponent<AudioSource>();
        onCocinadoEnd += Finish;
    }

    private void Finish()
    {
        print("Termine");
        CerrarPuerta(false);
        mAudioSource.clip = mMicrowaveEnds;
        mAudioSource.Play();
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

            mAudioSource.Stop();
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
            {
                mAudioSource.clip = mMicrowaveWorks;
                mAudioSource.Play();
                Cocinar();
            }
        }
    }
}
