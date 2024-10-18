using Logic;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class PlatoBuenoScript : MonoBehaviour
{
    [SerializeField] private List<Ingredient> mIngredient;
    [SerializeField] private GameObject mBrownieCrudo;
    [SerializeField] private GameObject mBrownieMierda;
    [SerializeField] private GameObject mBrownieMaking;

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
            if (ingrediente.eIngrediente == mIngredient[mIngredienteActual].eIngrediente)
            {
                if (mIngredienteActual == 0)
                {
                    print("empezamos");
                    GameObject brownieMaking = Instantiate(mBrownieMaking);
                    brownieMaking.GetComponent<BrownieMakingScript>().PasarPlato(gameObject);
                    brownieMaking.transform.position = transform.position;
                    Destroy(other.gameObject);
                    mIngredienteActual++;
                }
                if (mIngredienteActual == mIngredient.Count - 1)
                {
                    print("Sacabo");
                    Destroy(other.gameObject);
                    mIngredienteActual = 0;
                    onFalloCocina?.Invoke();
                }
                else
                {
                    print("Crece");
                    Destroy(other.gameObject);
                    mIngredienteActual++;
                }
            }
            else
            {
                mIngredienteActual = 0;
                print("Cagaste");
                Destroy(other.gameObject);
                onFalloCocina?.Invoke();
            }
        }
    }
}
