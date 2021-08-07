using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLerp : MonoBehaviour
{
    public Transform pointA, pointB, actualPoint;

    [SerializeField] 
    [Range(0f, 1f)]
    float lerpPercentage;

    [SerializeField]
    [Range(0f, 10f)]
    float Speed;

    //lerp = startPoint, endPoint, lerpPercentage

    void Start()
    {
        
    }

    void Update()
    {   

        transform.position = Vector2.Lerp(pointA.position, pointB.position, lerpPercentage);
    
        
        /* lerpPercentage += Input.GetAxis("Horizontal") * Time.deltaTime;
        
        
        if(lerpPercentage < 0) {
            lerpPercentage = 0;
        }
        
        else if (lerpPercentage > 1) {
            lerpPercentage = 1;
        }
        */
        /*
        if(transform.position  == pointA.transform.position || actualPoint == pointA) {
            actualPoint = pointA;
            lerpPercentage += 1 * Time.deltaTime * Speed; 
        }

        if (transform.position == pointB.transform.position || actualPoint == pointB) {
            actualPoint = pointB;
            lerpPercentage -= 1 *  Time.deltaTime * Speed; 
        }
        */
    }
}