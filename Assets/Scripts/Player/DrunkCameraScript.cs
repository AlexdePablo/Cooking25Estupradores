using System;
using UnityEngine;

public class DrunkCameraScript : MonoBehaviour
{
    [Header("Rango de Rotacion")]
    public float RangoRotacion;

    private float RotacionY;
    private float RotacionZ;

    [Header("Velocidades")]
    public float MinimoVelocidadRotacion;
    public float MaximoVelocidadRotacion;

    public float VelocidadRotacionY;
    public float VelocidadRotacionZ;

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

            if (RotacionZ >= RangoRotacion)
            {
                RotacionZ = RangoRotacion;
                rotatingUp = false;
                CambiarVelocidadZ();
            }
        }
        else
        {
            RotacionZ -= VelocidadRotacionZ * Time.deltaTime;

            if (RotacionZ <= -RangoRotacion)
            {
                RotacionZ = -RangoRotacion;
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

            if (RotacionY >= RangoRotacion)
            {
                RotacionY = RangoRotacion;
                rotatingLeft = false;
                CambiarVelocidadY();
            }
        }
        else
        {
            RotacionY -= VelocidadRotacionY * Time.deltaTime;

            if (RotacionY <= -RangoRotacion)
            {
                RotacionY = -RangoRotacion;
                rotatingLeft = true;
                CambiarVelocidadY();
            }
        }
    }

    private void CambiarVelocidadY()
    {
        VelocidadRotacionY = UnityEngine.Random.Range(MinimoVelocidadRotacion, MaximoVelocidadRotacion);
    }

    private void CambiarVelocidadZ()
    {
        VelocidadRotacionZ = UnityEngine.Random.Range(MinimoVelocidadRotacion, MaximoVelocidadRotacion);
    }
}
