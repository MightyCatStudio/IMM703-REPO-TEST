using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RadioUIButton : MonoBehaviour
{
    [Header("Object References")]
    [SerializeField] Image icon;
    [SerializeField] TMP_Text buttonText;
    [SerializeField] TMP_Text infoText;


    [Header("Resource References")]
    [SerializeField] Sprite iconSprite;
    [SerializeField] string functionName;
    [SerializeField] string functionInfo;

    void Start()
    {
        icon.sprite=iconSprite;
        buttonText.text=functionName;

        infoText.text = string.IsNullOrWhiteSpace(functionInfo) ? "" : functionInfo;
    }



}
