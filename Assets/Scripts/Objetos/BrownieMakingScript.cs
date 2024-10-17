using System;
using UnityEngine;

public class BrownieMakingScript : MonoBehaviour
{
    public void PasarPlato(GameObject _)
    {
        _.GetComponent<PlatoBuenoScript>().onFalloCocina += Sacabo;
    }

    private void Sacabo()
    {
        Destroy(this);
    }
}
