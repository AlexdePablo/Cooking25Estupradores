using Logic;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlatoBuenoScript : MonoBehaviour
{
    [SerializeField] private GameObject mBrownieCrudo;
    [SerializeField] private GameObject mBrownieMierda;
    [SerializeField] private GameObject mBrownieMaking;
    private GameObject mBrownieMakingRefe;

    [SerializeField] private List<Toggle> mToggles;

    [SerializeField] protected RecetaFinal mRecetaFinal;

    public Action onFalloCocina;

    private int mIngredienteActual;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mIngredienteActual = 0;
        DesactivaToggles();
    }

    private void DesactivaToggles()
    {
        foreach (Toggle tog in mToggles)
        {
            tog.isOn = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Ingredient>(out Ingredient ingrediente))
        {
            if (ingrediente.eIngrediente == mRecetaFinal.ingredientes[mIngredienteActual].eIngredient)
            {
                mToggles[mIngredienteActual].isOn = true;
                if (mIngredienteActual == 0)
                {
                    print("empezamos");
                    mBrownieMakingRefe = Instantiate(mBrownieMaking);
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
                    Destroy(mBrownieMakingRefe);
                    GameObject brownie = Instantiate(mBrownieCrudo);
                    brownie.transform.position = transform.position;
                    DesactivaToggles();
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
                DesactivaToggles();
                mIngredienteActual = 0;
                print("Cagaste");
                if (TryGetComponent<Pooleable>(out Pooleable pooleable))
                    pooleable.ReturnToPool();
                else
                    Destroy(other.gameObject);
                Destroy(mBrownieMakingRefe);
                GameObject mielda = Instantiate(mBrownieMierda);
                mielda.transform.position = transform.position;
            }
        }
    }
}
