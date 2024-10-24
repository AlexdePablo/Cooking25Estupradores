using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pool : MonoBehaviour
{
    public GameObject PoolableObject;
    private List<GameObject> m_Pool;
    public int Capacitat = 10;
    public Action onItemReturned;

    private void Awake()
    {
        m_Pool = new List<GameObject>();
        if (PoolableObject.GetComponent<Pooleable>() == null)
        {
            Debug.LogError("Pool: " + gameObject + " poolable object does not have a Pooleable component.");
            return;
        }

        for (int i = 0; i < Capacitat; i++)
        {
            GameObject element = Instantiate(PoolableObject, gameObject.transform);
            element.GetComponent<Pooleable>().SetPool(this);
            m_Pool.Add(element);
            element.SetActive(false);
        }
    }
    public bool ReturnElement(GameObject element)
    {
        if (m_Pool.Contains(element))
        {
            element.SetActive(false);
            onItemReturned?.Invoke();
            return true;
        }
        return false;
    }

    public GameObject GetElement()
    {
        foreach (GameObject objeto in m_Pool)
            if (!objeto.activeInHierarchy)
            {
                objeto.SetActive(true);
                return objeto;
            }
        return null;
    }

    public void ReturnAllElements()
    {
        foreach (GameObject objeto in m_Pool)
            objeto.SetActive(false);
    }
}

