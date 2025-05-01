using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    [SerializeField] InputActionReference activateAction;

    public static Action OnActivate;

    // Start is called before the first frame update
    void Start()
    {
        activateAction.action.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        Activate();
    }

    void Activate()
    {
        if(activateAction.action.WasPerformedThisFrame())
        {
            OnActivate?.Invoke();
            print("Activating!");
        }
    }
}
