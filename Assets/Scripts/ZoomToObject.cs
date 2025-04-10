using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomToObject : MonoBehaviour
{
    [SerializeField] Transform greenObj;
    [SerializeField] Transform redObj;
    [SerializeField] float distance = 1;

    bool isMoving;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out RaycastHit hit, 100))
            {
                print(hit.collider.name);

                if(hit.collider.CompareTag("Green"))
                {
                    Vector3 direction = (redObj.position - greenObj.position);
                    direction.Normalize();
                    Vector3 targetPos = greenObj.position + direction * distance;

                    print("Distance: " + Vector3.Distance(greenObj.position, redObj.position));
                    redObj.position = targetPos;
                }
            }
        }
    }
}
