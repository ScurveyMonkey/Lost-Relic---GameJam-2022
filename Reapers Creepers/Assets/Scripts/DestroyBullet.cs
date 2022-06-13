using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    private float xBound = 10.0f;
    private float yBound = 10.0f;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x > xBound && transform.position.y > yBound)
        {
            Destroy(gameObject);
        }
        if (transform.position.x < -xBound && transform.position.y > yBound)
        {
            Destroy(gameObject);
        }
    }

}
