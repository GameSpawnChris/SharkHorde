using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    public int playerHealth;
    //public int playerDamage;

    public float speed;
    public BoxCollider2D playArea;

    public GameObject spear;
    public Transform spearSpawn;
    public Slider healthBar;

    public int shieldCap;

    SpriteRenderer sr;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        healthBar.value = playerHealth;

        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(moveH, moveV);
        rb.velocity = move * speed;

        //Keeps the player in the PlayArea
        float clampX = Mathf.Clamp(rb.position.x, playArea.bounds.min.x, playArea.bounds.max.x);
        float clampY = Mathf.Clamp(rb.position.y, playArea.bounds.min.y, playArea.bounds.max.y);
        rb.position = new Vector2(clampX, clampY);

        if (Input.GetButtonDown("Jump"))
        {
            Shoot();
        }

    }

    void Shoot()
    {
        Instantiate(spear, spearSpawn.position, spearSpawn.rotation);
    }

    public void LoseLife()
    {
        if (shieldCap <= 0)
        {
            playerHealth -= 1;
            sr.color = Color.white;
            if (playerHealth < 0)
            {
                Debug.Log("Dead");
                Destroy(gameObject);
            }
        }
        shieldCap--;
    }

    public void PickUpHealth()
    {
        Debug.Log("Health Gain");
        playerHealth += 5;
    }

    public void PickUpShield()
    {
        Debug.Log("Shield Gain");
        shieldCap = 2;
        sr.color = Color.green;
    }

}

