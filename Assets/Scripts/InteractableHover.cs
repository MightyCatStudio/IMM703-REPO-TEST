using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class InteractableHover : MonoBehaviour
{
    [SerializeField] GameObject hoverObject;
    [SerializeField] MeshRenderer hoverRenderer;
    [SerializeField] Color hoverColor = Color.white;

    XRSimpleInteractable interactable;    
       
    void Start()
    {
        hoverRenderer.material.SetColor("_BaseColor", hoverColor);
        hoverRenderer.material.SetColor("_EmissionColor", hoverColor);

        interactable = GetComponent<XRSimpleInteractable>();
        interactable.hoverEntered.AddListener(OnHoverStart);
        interactable.hoverExited.AddListener(OnHoverEnd);

        hoverObject.SetActive(false);
    }

    void OnHoverStart(HoverEnterEventArgs a)
    {
        hoverObject.SetActive(true);
    }

    void OnHoverEnd(HoverExitEventArgs a)
    {
        hoverObject.SetActive(false);
    }
}
