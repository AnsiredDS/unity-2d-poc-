using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    Transform tr;
    PlayerChest p;
    [SerializeField] bool spin; 
    void Start()
    {
       tr = GetComponent<Transform>();
       p = GameObject.Find("Player").GetComponent<PlayerChest>();
    }

    // Update is called once per frame
    void Update()
    {
        if (spin == true) {
            tr.Rotate(0f, 5f, 0f); 
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player" && gameObject.tag == "Coin") {
            CollectCoin();
        }

        if(other.tag == "Player" && gameObject.tag == "Key") {
            CollectKey();
        }
    }

     /* private void OnCollisionStay2D(Collision2D other) {
        if(other.gameObject.name == "Player") {
            CollectCoin();
        }
            
    } */

    void CollectCoin() { 
        p.coinAmount++;
        Destroy(gameObject);

    }

    void CollectKey() {
        p.keyAmount++;
        Destroy(gameObject);
    }
}
