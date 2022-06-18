using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    private float speed = 2.5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > - 2.0f)
        {
            transform.Translate(Vector2.up * -speed * Time.deltaTime);
        }
        if (transform.position.y < - 4.0f)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }

    }
}
