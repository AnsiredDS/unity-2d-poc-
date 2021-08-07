using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Displayer : MonoBehaviour
{
    int coinAmount, keyAmount;
    [SerializeField] Text text;
    [SerializeField] string textContent;
    void Start()
    {
        
    }

    void Update()
    {
        if(text.name == "Coin Text") {
           coinAmount = GameObject.Find("Player").GetComponent<PlayerChest>().coinAmount;
            text.text = textContent + coinAmount;
        } 
        
        if(text.name == "Key Text") {
            keyAmount = GameObject.Find("Player").GetComponent<PlayerChest>().keyAmount;
            text.text = textContent + keyAmount;
        }

             
    }
}
    