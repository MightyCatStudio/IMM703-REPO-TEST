using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class HandAnimation : MonoBehaviour
{
    InputDevice controller;
    Animator animator;
    float thumbValue;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(!controller.isValid)
        {
            InitialiseController();
        }
        else
        {
            UpdateAnimation();
        }
    }

    void InitialiseController()
    {
        XRNode node = GetComponentInParent<XRController>().controllerNode;
        controller = InputDevices.GetDeviceAtXRNode(node);
    }

    void UpdateAnimation()
    {
        if (controller.TryGetFeatureValue(CommonUsages.grip, out float finger))
        {
            animator.SetFloat("FingerBend", finger);
        }

        if (controller.TryGetFeatureValue(CommonUsages.trigger, out float index))
        {
            animator.SetFloat("IndexBend", index);
        }

        if(controller.TryGetFeatureValue(CommonUsages.primaryTouch, out bool thumb))
        {
            if(thumb)
            {
                animator.SetFloat("ThumbBend", 1);
            }
            else
            {
                animator.SetFloat("ThumbBend", 0);
            }
        }
        
    }
}
