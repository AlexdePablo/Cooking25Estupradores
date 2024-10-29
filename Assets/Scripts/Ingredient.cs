using System.Collections.Generic;
using System;
using UnityEngine;

namespace Logic
{
    public class Ingredient : MonoBehaviour
    {
        [SerializeField] protected Ingredientes mIngrediente;
        public Ingredientes eIngrediente => mIngrediente;
        private int mTimeCooked = 0;
        public int timeCooked => mTimeCooked;

        public void Cocinate()
        {
            mTimeCooked++;
            print("Cooking " + mIngrediente.ToString());
        }
    }

    [Serializable]
    public struct Receta
    {
        public List<IngredientRecetaSO> ingredientes;
        public float tiempoEjecucion;
        public GameObject ingredienteResultante;
    }
    [Serializable]
    public struct RecetaFinal
    {
        public List<IngredientRecetaSO> ingredientes;
        public GameObject ingredienteResultante;
    }

    [Serializable]
    public struct IngredienteCantidad
    {
        public Ingredient ingrediente;
        public int cantidad;

        public IngredienteCantidad(Ingredient _i, int _c)
        {
            ingrediente = _i;
            cantidad = _c;
        }
    }
    public enum Ingredientes { CHOCOLEIT, BATER, HEROIN, SHUGAR, ECS, SAL, MARIA, CHOCOLEIT_TEMPLADO, BROWNIE_CRUDO, BROWNIE, HUEBOS_BAT }
   
}