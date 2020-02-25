using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public float startX;
    public float endX;
    public float speed; // units per second

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x -= speed * Time.deltaTime;
        if (pos.x < endX)
        {
            pos.x = startX;
        }
        transform.position = pos;
    }
}
