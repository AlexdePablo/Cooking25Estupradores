using UnityEngine;

public class Calentador : MonoBehaviour
{
    private Light mLight;
    [SerializeField] private PuertaMicroondasScript mPuerta;

    void Start()
    {
        mPuerta.OnDoorClosed += CerrarPuerta;
        mLight = GetComponent<Light>();
    }

    private void CerrarPuerta(bool _puertaCerrada)
    {
        mLight.gameObject.SetActive(_puertaCerrada);
    }
}
