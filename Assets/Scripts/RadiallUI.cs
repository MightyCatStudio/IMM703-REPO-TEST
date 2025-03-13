using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialUI : MonoBehaviour
{
    [SerializeField] Transform offset;
    [SerializeField] RectTransform[] buttons;
    [SerializeField] float radialRadius = 150f;
    [SerializeField] float smooth = 0.5f;

    Vector3 smoothRef;
    
    // Start is called before the first frame update
    void Start()
    {
        PositionButtons();
    }

    // Update is called once per frame
    void PositionButtons()
    {
        float angleBetween = 360 / buttons.Length * Mathf.Deg2Rad;

        for (int i = 0; i < buttons.Length; i++)
        {
            Vector2 direction = new Vector2(Mathf.Sin(-angleBetween * i), Mathf.Cos(-angleBetween * i));

            buttons[i].anchoredPosition = direction * radialRadius;
        }
    }


    void OnValidate()
    {
        PositionButtons();

    }// Update is called once per frame
    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, offset.position, ref smoothRef, smooth);
        transform.LookAt(Camera.main.transform);
    }


    }

