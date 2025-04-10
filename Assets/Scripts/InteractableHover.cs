using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class InteractableHover : MonoBehaviour
{
    [SerializeField] GameObject hoverObject;
    [SerializeField] MeshRenderer hoverRenderer;
    [SerializeField] Color hoverColor = Color.white;
    [SerializeField] InputActionReference zoomInput;
    [SerializeField] InputActionReference lookInput;
    [SerializeField] float distance = 40f;

    Transform player;
    XRSimpleInteractable interactable;
    Vector3 zoomTarget;
    Vector3 playerTargetPos;
    bool hasTarget;
    bool hasSelection;
    GameObject tempParent;
    DeviceBasedContinuousTurnProvider turnProvider;
       
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        turnProvider = player.GetComponentInChildren<DeviceBasedContinuousTurnProvider>();

        zoomInput.action.Enable();
        lookInput.action.Enable();

        hoverRenderer.material.SetColor("_BaseColor", hoverColor);
        hoverRenderer.material.SetColor("_EmissionColor", hoverColor);

        interactable = GetComponent<XRSimpleInteractable>();
        interactable.hoverEntered.AddListener(OnHoverStart);
        interactable.hoverExited.AddListener(OnHoverEnd);
        interactable.selectEntered.AddListener(OnSelected);
        interactable.selectExited.AddListener(OnDeselected);

        hoverObject.SetActive(false);
    }

    private void Update()
    {
        if(hasSelection)
        {
            Vector2 lookValue = lookInput.action.ReadValue<Vector2>();

            //tempParent.transform.rotation = Quaternion.Euler(0, lookValue.x, 0);
            //tempParent.transform.Rotate(new Vector3(0, -lookValue.x, 0));
            tempParent.transform.Rotate(Vector3.up * -lookValue.x);
        }    
    }

    private void OnEnable()
    {
        zoomInput.action.performed += ZoomToPlanet;        
    }

    private void OnDisable()
    {
        zoomInput.action.performed -= ZoomToPlanet;
    }

    void OnHoverStart(HoverEnterEventArgs a)
    {
        hoverObject.SetActive(true);

        hasTarget = true;
        playerTargetPos = SetPlayerTargetPosition();
    }

    void OnHoverEnd(HoverExitEventArgs a)
    {
        hoverObject.SetActive(false);
        hasTarget = false;
    }

    Vector3 SetPlayerTargetPosition()
    {
        zoomTarget = (player.position - transform.position).normalized;
        print("Zoom distance: " + zoomTarget.magnitude);
        return transform.position + zoomTarget * distance;
    }

    void ZoomToPlanet(InputAction.CallbackContext ctx)
    {
        if(hasTarget)
        {
            player.position = playerTargetPos;

            print("Distance from planet: " + Vector3.Distance(transform.position, player.position));

            player.LookAt(transform.position);
        }
    }

    private void OnSelected(SelectEnterEventArgs a)
    {
        tempParent = Instantiate(new GameObject("TempParent"), a.interactableObject.transform.position, a.interactableObject.transform.rotation);
        player.parent = tempParent.transform;
        hasSelection = true;
        turnProvider.enabled = false;
    }

    private void OnDeselected(SelectExitEventArgs a)
    {
        player.parent = null;
        Destroy(tempParent);
        hasSelection = false;
        turnProvider.enabled = true;
    }
}
