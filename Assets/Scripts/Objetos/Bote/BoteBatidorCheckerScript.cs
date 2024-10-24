using Logic;
using UnityEngine;

public class BoteBatidorCheckerScript : MonoBehaviour
{
    [SerializeField] private GameObject mInteriorBol;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("batidor"))
        {
            mInteriorBol.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("batidor"))
        {
            mInteriorBol.SetActive(false);
        }
    }
}
