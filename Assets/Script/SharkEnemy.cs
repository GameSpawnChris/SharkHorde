using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class SharkEnemy : MonoBehaviour
{
    public float speed;

    public GameObject hydroBall;
    public Transform hydroSpawn;
    public float minShotDelay;
    public float maxShotDelay;

    public int sharkHealth;

    SpriteRenderer sr;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        StartCoroutine(Shoot());
    }


    void Update()
    {
        Vector2 move = new Vector2(-2, 0);
        rb.velocity = move * speed;
    }

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(maxShotDelay);
        while (true)
        {
            Instantiate(hydroBall, hydroSpawn.position, hydroSpawn.rotation);
            yield return new WaitForSeconds(Random.Range(minShotDelay, maxShotDelay));
        }
    }

    public void LoseSharkLife()
    {
        sharkHealth -= 2;
        if (sharkHealth < 0)
        {
            Debug.Log("SharkDead");
            Destroy(gameObject);
        }

    }
}
