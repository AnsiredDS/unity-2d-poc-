using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    [SerializeField] Animator anim;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0) == true) {
            anim.Play("ButterKnifeAttack");
        } 
    }
}
