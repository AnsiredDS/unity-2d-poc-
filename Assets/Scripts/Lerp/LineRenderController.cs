using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class LineRenderController : MonoBehaviour
{
    [SerializeField]
    LineRenderer lr;
    [SerializeField]
    Transform pointA, pointB;


    void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }

    
    void Update()
    {
        lr.SetPosition(0, pointA.position);
        lr.SetPosition(1, pointB.position);
    }
}
