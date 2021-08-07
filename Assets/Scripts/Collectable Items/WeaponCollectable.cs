using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCollectable : MonoBehaviour
{
    [SerializeField] GameObject weaponID;
    Transform weaponHolder;
    void Start()
    {
        weaponHolder = GameObject.Find("Weapon Holder").GetComponent<Transform>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            Instantiate(weaponID, weaponHolder.position, Quaternion.identity, weaponHolder.transform);
            Destroy(gameObject);
        }    
    }
}
