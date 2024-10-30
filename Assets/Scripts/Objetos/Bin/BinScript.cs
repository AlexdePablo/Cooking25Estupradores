using UnityEngine;

public class BinScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Pooleable pool))
            pool.ReturnToPool();
    }
}
