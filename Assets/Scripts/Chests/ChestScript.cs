using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : MonoBehaviour
{
    public GameObject item;
    public bool opened;
    public int quantity, maxQuantity;
    
    void Start()
    {
        opened = false;
    }

    void Update()
    {
        if(opened == true && quantity < maxQuantity) {
            StartCoroutine(DropItem());
            quantity++;
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
         /* if (other == GameObject.FindGameObjectWithTag("Player")) {
                if (Input.GetKeyDown(KeyCode.E)){
                    opened = true;
                    Debug.Log("The chest was opened!!");
                }
        }
        */

    }

    IEnumerator DropItem() {
        yield return new WaitForSeconds(2);
        Instantiate(item, new Vector3(transform.position.x, transform.position.y +2f, transform.position.z), Quaternion.identity); 
    }
}
