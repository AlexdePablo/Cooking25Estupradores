using Logic;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class PlatoBuenoScript : MonoBehaviour
{
    [SerializeField] private GameObject mBrownieCrudo;
    private GameObject mBrownieCrudoRefe;
    [SerializeField] private GameObject mBrownieMierda;
    private GameObject mBrownieMierdaRefe;
    [SerializeField] private GameObject mBrownieMaking;
    private GameObject mBrownieMakingRefe;

    [SerializeField] protected RecetaFinal mRecetaFinal;

    public Action onFalloCocina;

    private int mIngredienteActual;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mIngredienteActual = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Ingredient>(out Ingredient ingrediente))
        {
            if (ingrediente.eIngrediente == mRecetaFinal.ingredientes[mIngredienteActual].eIngredient)
            {
                if (mIngredienteActual == 0)
                {
                    print("empezamos");
                    mBrownieMakingRefe = Instantiate(mBrownieMaking);
                    mBrownieMakingRefe.GetComponent<BrownieMakingScript>().PasarPlato(gameObject);
                    mBrownieMakingRefe.transform.position = transform.position;
                    if(TryGetComponent<Pooleable>(out Pooleable pooleable))
                        pooleable.ReturnToPool();
                    else
                        Destroy(other.gameObject);

                    mIngredienteActual++;
                }
                if (mIngredienteActual == mRecetaFinal.ingredientes.Count - 1)
                {
                    print("Sacabo");
                    if (TryGetComponent<Pooleable>(out Pooleable pooleable))
                        pooleable.ReturnToPool();
                    else
                        Destroy(other.gameObject);
                    mIngredienteActual = 0;
                    onFalloCocina?.Invoke();
                }
                else
                {
                    print("Crece");
                    if (TryGetComponent<Pooleable>(out Pooleable pooleable))
                        pooleable.ReturnToPool();
                    else
                        Destroy(other.gameObject);
                    mIngredienteActual++;
                }
            }
            else
            {
                mIngredienteActual = 0;
                print("Cagaste");
                if (TryGetComponent<Pooleable>(out Pooleable pooleable))
                    pooleable.ReturnToPool();
                else
                    Destroy(other.gameObject);
                onFalloCocina?.Invoke();
                GameObject mielda = Instantiate(mBrownieMierda);
                mielda.transform.position = transform.position;
            }
        }
    }
}
