using UnityEngine;

namespace Logic
{
    public abstract class Ingredient : MonoBehaviour
    {
        internal Ingredientes m_Ingredient;
    }
    public enum Ingredientes { Chocolate, Butter, Heroine, Sugar, Eggs, Salt, Maria }
    // Ingredients
    public class Chocolate : Ingredient { public Chocolate() { m_Ingredient = Ingredientes.Chocolate; } }
    public class Butter : Ingredient { public Butter() { m_Ingredient = Ingredientes.Butter; } }
    public class Heroine : Ingredient { public Heroine() { m_Ingredient = Ingredientes.Heroine; } }
    public class Sugar : Ingredient { public Sugar() { m_Ingredient = Ingredientes.Sugar; } }
    public class Eggs : Ingredient { public Eggs() { m_Ingredient = Ingredientes.Eggs; } }
    public class Salt : Ingredient { public Salt() { m_Ingredient = Ingredientes.Salt; } }
    public class Maria : Ingredient { public Maria() { m_Ingredient = Ingredientes.Maria; } }
}