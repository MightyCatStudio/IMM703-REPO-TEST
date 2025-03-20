using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RadialUIF : MonoBehaviour
{
    [Header("Interactor References")]
    [SerializeField] GameObject leftUIInteractor;
    [SerializeField] GameObject rightUIInteractor;
    [SerializeField] GameObject leftGameInteractors;
    [SerializeField] GameObject rightGameInteractors;
    [SerializeField] GameObject leftRayInteractor;
    [SerializeField] GameObject rightRayInteractor;
    [SerializeField] GameObject leftDirectInteractor;
    [SerializeField] GameObject rightDirectInteractor;

    Vector3 menuScale;
    bool canAnimate = true;
    bool menuOpen = false;

    void Start()
    {
        menuScale = transform.localScale;
        transform.localScale = Vector3.zero;

        leftDirectInteractor.SetActive(true);
        rightDirectInteractor.SetActive(true);
        leftRayInteractor.SetActive(false);
        rightRayInteractor.SetActive(false);

        leftUIInteractor.SetActive(false);
        rightUIInteractor.SetActive(false
            );

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ToggleMenu()
    {
        if (canAnimate)
        {
            menuOpen = !menuOpen;

            leftGameInteractors.SetActive(!menuOpen);
            rightGameInteractors.SetActive(!menuOpen);

            leftUIInteractor.SetActive(menuOpen);
            rightUIInteractor.SetActive(menuOpen);

            StartCoroutine(AnimateMenu(menuOpen, 0.5f));


        }
    }
     public void ToggleLeftInteractor(TMP_Text infoText)
    {
        leftDirectInteractor.SetActive(!leftDirectInteractor.activeSelf);
        leftRayInteractor.SetActive(!leftRayInteractor.activeSelf);

        infoText.text = leftDirectInteractor.activeSelf ? "Direct Interactor" : "Ray Interactor";
    }

    public void ToggleRightInteractor(TMP_Text infoText)
    {
        rightDirectInteractor.SetActive(!rightDirectInteractor.activeSelf);
        rightRayInteractor.SetActive(!rightRayInteractor.activeSelf);

        infoText.text = rightDirectInteractor.activeSelf ? "Direct Interactor" : "Ray Interactor";

    }

    public void QuitGame()
    {
        Application.Quit();
    }
    IEnumerator AnimateMenu(bool opening, float length)
    {
        canAnimate = false;
        float alpha = 0;

        if (opening)
        {
            while (alpha < length)
            {
                transform.localScale = Vector3.Lerp(transform.localScale, menuScale, alpha / length);
                alpha += Time.deltaTime;
                yield return null;
            }
        }
        else
        {
            while (alpha < length)
            {
                transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, alpha / length);
                alpha += Time.deltaTime;
                yield return null;
            }
        }

        canAnimate = true;

    }
}


