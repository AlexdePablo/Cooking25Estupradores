using System;
using UnityEngine;

public class PuertaMicroondasScript : MonoBehaviour
{
    public Action<bool> OnDoorClosed;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("puertaMicroondas"))
        {
            OnDoorClosed?.Invoke(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("puertaMicroondas"))
        {
            OnDoorClosed?.Invoke(false);
        }
    }
}
