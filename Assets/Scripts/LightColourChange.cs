using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightColourChange : MonoBehaviour
{
    Light sceneLight;

    void Start()
    {
        sceneLight = GetComponent<Light>();
    }

    public void RandomiseLightColour()
    {
        //Generate a new random colour using a random value
        //within a range (0 to 1). This is passed to the Red,
        //Green and Blue channels. Alpha defaults to 1 so the 
        //colour is opaque.
        Color randomColour = new Color(
            Random.Range(0f, 1f), //Red
            Random.Range(0f, 1f), //Green
            Random.Range(0f, 1f), //Blue
            1);                   //Alpha

        sceneLight.color = randomColour;
    }
}
