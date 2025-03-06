using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class InteractableColourChange : MonoBehaviour
{
    [SerializeField] private Material hoverMaterial;
    [SerializeField] private Transform lAttach, rAttach;

    private Material defaultMaterial;
    private MeshRenderer meshRenderer;
    private XRGrabInteractable xrGrabbable;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        xrGrabbable = GetComponent<XRGrabInteractable>();
        defaultMaterial = meshRenderer.material;

        xrGrabbable.hoverEntered.AddListener(OnHoverBegin);
        xrGrabbable.hoverExited.AddListener(OnHoverFinish);
        xrGrabbable.selectEntered.AddListener(OnSelectBegin);
    }

    public void OnHoverBegin(HoverEnterEventArgs args)
    {
        meshRenderer.material = hoverMaterial;
    }

    public void OnHoverFinish(HoverExitEventArgs args)
    {
        meshRenderer.material = defaultMaterial;
    }

    public void OnSelectBegin(SelectEnterEventArgs args)
    {
        meshRenderer.material = defaultMaterial;

        XRController controller = (args.interactorObject as XRBaseInteractor).GetComponentInParent<XRController>();

        if(controller.controllerNode == UnityEngine.XR.XRNode.RightHand)
        {
            xrGrabbable.attachTransform = rAttach;
        }
        else
        {
            xrGrabbable.attachTransform = lAttach;
        }
    }
}
