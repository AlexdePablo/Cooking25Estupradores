using System;
using System.Collections.Generic;
using UnityEngine;

namespace Logic
{
    public class Pot : MonoBehaviour
    {
        [SerializeField]
        private List<IngredienQuantity> m_Recepet;
        private int mPosList = 0;
        private bool OnPutIngredient(Ingredientes Ing)
        {
            if (m_Recepet[mPosList].ingredient == Ing)
            {
                mPosList++;
                if (mPosList == m_Recepet.Count)
                {
                    return true; // Recepet Completed
                }
                return true; // Correct Ingredient
            }
            mPosList = 0;
            return false; // InCorrect Ingredint
        }
        private void OnTriggerEnter(Collider other)
        {
            
        }
    }
    [Serializable]
    public struct IngredienQuantity
    {
        public int quantity;
        public Ingredientes ingredient;
    }
}

