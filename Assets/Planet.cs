using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField] float distanceThreshold = 100f;
    [SerializeField] Transform player;
    [SerializeField] InformationCard card;
    [SerializeField] Transform cardPivot;
    [SerializeField] Transform cardTilt;

    // Update is called once per frame
    void Update()
    {
        if (GetDistance() < distanceThreshold)
        {
            if(!card.IsOpen)
            {
                card.Animate(true);
            }
        }
        else
        {
            if(card.IsOpen)
            {
                card.Animate(false);
            }
        }
    }

    private void LateUpdate()
    {
        cardPivot.LookAt(player);
        cardTilt.LookAt(player);

    }

    float GetDistance()
    {
        return (player.position - transform.position).magnitude; 
    }
}
