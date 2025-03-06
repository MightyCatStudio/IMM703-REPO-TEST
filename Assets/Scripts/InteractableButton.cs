using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class InteractableButton : MonoBehaviour
{
    Animation anim;
    AudioSource audioSource;
    XRSimpleInteractable interactable;

    [SerializeField] UnityEvent onPressed;

    private void Start()
    {
        anim = GetComponent<Animation>();
        audioSource = GetComponent<AudioSource>();

        //Assign interactable variable, and add method to eventhandler
        interactable = GetComponent<XRSimpleInteractable>();
        interactable.hoverEntered.AddListener(OnPokeStarted);
    }

    void OnPokeStarted(HoverEnterEventArgs args)
    {
        //Play audio/animation on button press
        anim.Play();
        audioSource.Play();

        //Invoke our own custom event
        onPressed?.Invoke();
    }
}
