using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractiveText : MonoBehaviour
{
    private TMP_Text welcomeText;

    //A list is a collection type, that allows for multiple values
    //to be stored and enumerated
    List<string> text = new List<string>()
    {
        "Hello! Welcome to this VR experience!",
        "Try pushing the button to find out more!",
        "Sorry, the button doesn't do much!"
    };

    int currentText = 0;

    private void Start()
    {
        welcomeText = GetComponent<TMP_Text>();
        welcomeText.text = text[0];
    }

    public void ChangeText()
    {
        if(currentText + 1 == text.Count)
        {
            currentText = 0;
        }
        else
        {
            currentText++;
        }

        welcomeText.text = text[currentText];
    }
}
