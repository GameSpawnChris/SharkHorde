using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTouch : MonoBehaviour
{
    public string tagToDestroy;
    public GameObject spearShot;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(tagToDestroy))
        {
            if (tagToDestroy == "Enemy")
            {
                Destroy(spearShot);
                other.GetComponent<SharkEnemy>().LoseSharkLife();
            }
            else if (tagToDestroy == "Player")
            {
                Debug.Log("Life lost");
                other.GetComponent<PlayerController>().LoseLife();
            }
            else if (tagToDestroy == "Boss")
            {
                Destroy(spearShot);
                Debug.Log("Boss Life lost");
                other.GetComponent<BossController>().BossLoseLife(); 
            }
        }
    }
}
