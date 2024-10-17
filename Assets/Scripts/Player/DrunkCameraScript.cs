using System;
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

    private void Start()
    {
        CambiarVelocidadY();
        CambiarVelocidadZ();
    }

    void Update()
    {
        UpdateY();
        UpdateZ();
        
        transform.localRotation = Quaternion.Euler(0f, RotacionY, RotacionZ);
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
}
