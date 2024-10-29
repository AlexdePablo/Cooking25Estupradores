using System;
using System.Collections;
using UnityEngine;

public class DrunkCameraScript : MonoBehaviour
{
    [Header("Rango de Rotacion")]
    public float RangoRotacionY;
    public float RangoRotacionZ;

    private float RotacionY;
    private float RotacionZ;

    [Header("Velocidades Y")]
    public float MinimoVelocidadRotacionY;
    public float MaximoVelocidadRotacionY;

    [Header("Velocidades Z")]
    public float MinimoVelocidadRotacionZ;
    public float MaximoVelocidadRotacionZ;

    private float VelocidadRotacionY;
    private float VelocidadRotacionZ;

    private bool rotatingLeft = true;
    private bool rotatingUp = true;

    private bool mDrunked;
    [SerializeField] private int mTimeDrunked;
    [SerializeField] private int mTimeMarihuaned;

    private Coroutine mCoroutineDrunked;
    private Coroutine mCoroutineMarihuaned;

    public Action<bool> onMarihuanedBehavioured; 

    private void Start()
    {
        mDrunked = false;
        CambiarVelocidadY();
        CambiarVelocidadZ();
    }

    void Update()
    {
        if (mDrunked)
        {
            UpdateY();
            UpdateZ();

            transform.parent.localRotation = Quaternion.Euler(0f, RotacionY, RotacionZ);
        }
    }

    private void UpdateZ()
    {
        if (rotatingUp)
        {
            RotacionZ += VelocidadRotacionZ * Time.deltaTime;

            if (RotacionZ >= RangoRotacionZ)
            {
                RotacionZ = RangoRotacionZ;
                rotatingUp = false;
                CambiarVelocidadZ();
            }
        }
        else
        {
            RotacionZ -= VelocidadRotacionZ * Time.deltaTime;

            if (RotacionZ <= -RangoRotacionZ)
            {
                RotacionZ = -RangoRotacionZ;
                rotatingUp = true;
                CambiarVelocidadZ();
            }
        }
    }

    private void UpdateY()
    {
        if (rotatingLeft)
        {
            RotacionY += VelocidadRotacionY * Time.deltaTime;

            if (RotacionY >= RangoRotacionY)
            {
                RotacionY = RangoRotacionY;
                rotatingLeft = false;
                CambiarVelocidadY();
            }
        }
        else
        {
            RotacionY -= VelocidadRotacionY * Time.deltaTime;

            if (RotacionY <= -RangoRotacionY)
            {
                RotacionY = -RangoRotacionY;
                rotatingLeft = true;
                CambiarVelocidadY();
            }
        }
    }

    private void CambiarVelocidadY()
    {
        VelocidadRotacionY = UnityEngine.Random.Range(MinimoVelocidadRotacionY, MaximoVelocidadRotacionY);
    }

    private void CambiarVelocidadZ()
    {
        VelocidadRotacionZ = UnityEngine.Random.Range(MinimoVelocidadRotacionZ, MaximoVelocidadRotacionZ);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Beer"))
        {
            mDrunked = true;
            if (mCoroutineDrunked == null)
                mCoroutineDrunked = StartCoroutine(GetDrunked());
            else
            {
                StopCoroutine(mCoroutineDrunked);
                mCoroutineDrunked = StartCoroutine(GetDrunked());
            }
            other.GetComponent<Pooleable>().ReturnToPool();
        }

        if (other.CompareTag("BrownieMarihuana"))
        {
            onMarihuanedBehavioured?.Invoke(true);
            if (mCoroutineMarihuaned == null)
                mCoroutineMarihuaned = StartCoroutine(GetMarihuaned());
            else
            {
                StopCoroutine(mCoroutineMarihuaned);
                mCoroutineMarihuaned = StartCoroutine(GetMarihuaned());
            }
        }
    }

    private IEnumerator GetMarihuaned()
    {
        yield return new WaitForSeconds(mTimeMarihuaned);
        onMarihuanedBehavioured?.Invoke(false);
    }

    private IEnumerator GetDrunked()
    {
        yield return new WaitForSeconds(mTimeDrunked);
        mDrunked = false;
        ResetCameraCameraRotation();
    }

    private void ResetCameraCameraRotation()
    {
        transform.localEulerAngles = Vector3.zero;
    }
}
