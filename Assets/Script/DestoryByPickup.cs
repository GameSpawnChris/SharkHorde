using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryByPickup : MonoBehaviour
{

    public string tagToPickUp;
    public string pickupTag;
    public GameObject Potion;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (tagToPickUp == "Player" && pickupTag == "Health")
        {
          other.GetComponent<PlayerController>().PickUpHealth();
          Destroy(Potion);
        } 
        else
        {
          other.GetComponent<PlayerController>().PickUpShield();
          Destroy(Potion);
        }

        
    }
}
