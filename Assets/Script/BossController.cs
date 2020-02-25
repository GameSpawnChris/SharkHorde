using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossController : MonoBehaviour
{
    public GameObject shot;
    public Transform shotSpawn;
    public float minShotDelay;
    public float maxShotDelay;

    public int bossHealth;
    public Slider bosshealthBar;

    public Vector2 direction;

    //public GameObject bossPrefab;
    //public float bossDelay;

    Rigidbody2D rb;
    BoxCollider2D playArea;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(BossSpawn());
        StartCoroutine(Shoot());

        rb = GetComponent<Rigidbody2D>();
        direction.y = Random.Range(-direction.y, direction.y);
        rb.velocity = direction;

        playArea = GameObject.Find("PlayArea").GetComponent<BoxCollider2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        bosshealthBar.value = bossHealth;

        if (rb.position.y > playArea.bounds.max.y && rb.velocity.y > 0)
        {
            direction.y = -Mathf.Abs(direction.y);
            rb.velocity = direction;
        }
        else if (rb.position.y < playArea.bounds.min.y && rb.velocity.y < 0)
        {
            direction.y = Mathf.Abs(direction.y);
            rb.velocity = direction;
        }
    }

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(maxShotDelay);
        while (true)
        {
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            yield return new WaitForSeconds(Random.Range(minShotDelay, maxShotDelay));
        }
    }

    public void BossLoseLife()
    {
            bossHealth -= 2;
            if (bossHealth < 0)
            {
                Debug.Log("Dead");
                Destroy(gameObject);
            }
    }

    /*IEnumerator BossSpawn()
    {
        yield return new WaitForSeconds(bossDelay);

        Vector2 spawnPosition = new Vector2(3, Random.Range(-1, -4));
        Instantiate(bossPrefab, spawnPosition, Quaternion.identity);

    } */

}