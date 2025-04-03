using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRDrawer : MonoBehaviour
{
    [SerializeField] Transform visual;
    [SerializeField] float minValue = 0;
    [SerializeField] float maxValue = 0.003f;


    Vector3 originalPosition;
    XRGrabInteractable interactable;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = visual.position;
        interactable = GetComponent<XRGrabInteractable>();
        interactable.selectExited.AddListener(OnReleaseDrawer);

    }

    
    // Update is called once per frame
    void Update()
    {
        visual.position = originalPosition + transform.forward * Vector3.Dot(transform.position - originalPosition, transform.forward);

        float difference = Vector3.Dot(transform.position - originalPosition, transform.forward);

        difference = Mathf.Clamp(difference, minValue, maxValue);

        visual.position = originalPosition + transform.forward * difference;

    }

    void OnReleaseDrawer(SelectExitEventArgs args)
    {
        transform.position = visual.position;
    }
}
