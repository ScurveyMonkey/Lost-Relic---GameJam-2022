using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    private float speed = 5.0f;
    Rigidbody2D bullet;
    // Start is called before the first frame update
    void Start()
    {
        bullet = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
