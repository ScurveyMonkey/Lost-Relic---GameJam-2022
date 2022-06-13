using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 10.0f;
    public Rigidbody2D rb;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "Bullet";
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.right * speed;

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Teleport");
            StartCoroutine(TeleportPlayer());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            rb.velocity = transform.right * 0;
        }
    }

    IEnumerator TeleportPlayer()
    {
        //Debug.Log("Teleport");
        yield return new WaitForSeconds(0.01f);
        player.transform.position = gameObject.transform.position;
        Destroy(gameObject);

    }
}
