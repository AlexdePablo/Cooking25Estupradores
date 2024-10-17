using UnityEngine;

namespace Logic
{
    [CreateAssetMenu(fileName = "Ingrediente", menuName = "Scriptables/Ingrediente")]
    public class IngredientRecetaSO : ScriptableObject
    {
        public Ingredientes eIngredient;
        public int cantidad;
    }
}

