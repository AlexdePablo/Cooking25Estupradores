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
        /*m_Interact = GetComponent<XRSimpleInteractable>();
        if(m_Interact) m_Interact.selectEntered.AddListener(CambiaColor);*/

        m_Grab = GetComponent<XRGrabInteractable>();
        if (m_Grab) m_Grab.selectEntered.AddListener(CambiaTamanio);
        if (m_Grab) m_Grab.selectExited.AddListener(CambiaTamanioExit);
    }

    private void CambiaTamanioExit(SelectExitEventArgs arg0)
    {
        /*print("ExitCreciendo2");
        transform.localScale = new Vector3(2, 2, 2);*/
    }

    private void CambiaTamanio(SelectEnterEventArgs arg0)
    {
        print("Creciendo2");
        transform.localScale *= 1.01f;
    }
    private void OnDestroy()
    {
        //m_Interact.selectEntered.RemoveListener(CambiaColor);
        m_Grab.selectEntered.RemoveListener(CambiaTamanio);
    }
    private void OnCollisionEnter(Collision collision)
    {
        print("COL");
        Debug.Log(GetComponent<Rigidbody>().linearVelocity.magnitude);
        if (GetComponent<Rigidbody>().linearVelocity.magnitude > 0.5)
            Destroy(gameObject);
        if (collision.gameObject.GetComponent<Rigidbody>() != null)
            if (collision.gameObject.GetComponent<Rigidbody>()?.linearVelocity.magnitude > 0.5 )
                Destroy(gameObject);
    }
}
