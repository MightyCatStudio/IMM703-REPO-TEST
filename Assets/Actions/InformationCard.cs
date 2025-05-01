using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformationCard : MonoBehaviour
{
    [SerializeField] float scaleLength = 0.5f;    
    Vector3 initialScale;
    bool canAnimate = true;


    public bool IsOpen => transform.localScale == initialScale;

    private void OnEnable()
    {
        InputHandler.OnActivate += Animate;
    }

    private void OnDisable()
    {
        InputHandler.OnActivate -= Animate;
    }

    private void Start()
    {
        Application.targetFrameRate = 72;
        initialScale = transform.localScale;
        transform.localScale = Vector3.zero;
    }

    public void Animate(bool opening)
    {
        if (canAnimate)
        {
            StartCoroutine(AnimateCard(scaleLength, opening));
        }

    }

    void Animate()
    {
        if (canAnimate)
        {
            if (transform.localScale != initialScale)
            {
                StartCoroutine(AnimateCard(scaleLength, true));
            }
            else
            {
                StartCoroutine(AnimateCard(scaleLength, false));
            }
        }
    }

    IEnumerator AnimateCard(float length, bool opening)
    {
        canAnimate = false;

        float alpha = 0;

        Vector3 finalScale = opening ? initialScale : Vector3.zero;

        while(alpha < length)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, finalScale, alpha / length);
            alpha += Time.deltaTime;
            yield return null;
        }

        canAnimate = true;
    }
}
