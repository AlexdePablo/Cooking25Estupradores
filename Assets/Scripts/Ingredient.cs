using UnityEngine;

namespace Logic
{
    public abstract class Ingredient : MonoBehaviour
    {
        internal Ingredientes m_Ingredient;
        public Ingredientes Ingrediente => m_Ingredient;
    }
    public enum Ingredientes { CHOCOLEIT, BATER, HEROIN, SHUGAR, ECS, SAL, MARIA }
   
}