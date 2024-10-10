using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class TestObjetoInteract : MonoBehaviour
{
    [SerializeField] private XRSimpleInteractable m_Interact;
    [SerializeField] private XRGrabInteractable m_Grab;

    private void Awake()
    {
        m_Interact = GetComponent<XRSimpleInteractable>();
        if(m_Interact) m_Interact.selectEntered.AddListener(CambiaColor);

        m_Grab = GetComponent<XRGrabInteractable>();
        if (m_Grab) m_Grab.selectEntered.AddListener(CambiaTamanio);
    }

    private void CambiaTamanio(SelectEnterEventArgs arg0)
    {
        print("Creciendo2");
        GetComponent<MeshRenderer>()?.material.SetColor("_Color", Color.red);
        transform.localScale *= 1.98f;
    }

    private void CambiaColor(SelectEnterEventArgs _)
    {
        print("Creciendo1");
        GetComponent<MeshRenderer>()?.material.SetColor("_Color", Color.red);
        transform.localScale *= 1.98f;
    }

    private void OnDestroy()
    {
        m_Interact.selectEntered.RemoveListener(CambiaColor);
        m_Grab.selectEntered.RemoveListener(CambiaTamanio);
    }

    private void Update()
    {
       
    }
    private void FixedUpdate()
    {
        if (m_Grab.isSelected)
        {
          
            
        }

        /*if (m_Grab.isHovered)
        {
            print("menguando");
            transform.GetChild(0).localScale *= 0.98f;
        }*/
    }
}
