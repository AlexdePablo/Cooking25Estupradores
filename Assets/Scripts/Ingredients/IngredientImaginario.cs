using UnityEngine;

public class IngredientImaginario : MonoBehaviour
{
    private Material mMaterial;
    private bool mDesvaneciendo;

    private void Awake()
    {
        mMaterial = GetComponent<MeshRenderer>().material;
        MakeInvisible();   
    }

    private void Update()
    {
        if(mDesvaneciendo)
        {
            if(mMaterial.GetFloat("_Threshold") > 0)
            {
                mMaterial.SetFloat("_Threshold", mMaterial.GetFloat("_Threshold") - Time.deltaTime);
            }
            else
            {
                MakeVisible();
            }
        }
        else
        {
            if (mMaterial.GetFloat("_Threshold") < 1)
            {
                mMaterial.SetFloat("_Threshold", mMaterial.GetFloat("_Threshold") + Time.deltaTime);
            }
            else
            {
                MakeInvisible();
            }
        }
    }

    public void MakeVisible()
    {
        mDesvaneciendo = false;
    }

    public void MakeInvisible()
    {
        mDesvaneciendo = true;
    }
}
