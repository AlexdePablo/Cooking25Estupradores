using UnityEngine;

namespace Logic
{
    public abstract class Ingredient : MonoBehaviour
    {
        protected Ingredientes m_Ingredient;
        public Ingredientes Ingrediente => m_Ingredient;
        protected int mTimeCooked = 0;
        public int timeCooked => mTimeCooked;

        public void Cocinate()
        {
            mTimeCooked++;
            print("Cocinando " + m_Ingredient.ToString());
        }
    }
    public enum Ingredientes { CHOCOLEIT, BATER, HEROIN, SHUGAR, ECS, SAL, MARIA, CHOCOLEIT_TEMPLADO }
   
}