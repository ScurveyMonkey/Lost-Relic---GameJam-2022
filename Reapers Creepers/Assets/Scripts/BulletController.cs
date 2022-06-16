using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 5.0f;
    public Rigidbody2D rb;
    private GameObject player;
    private GameObject barrel;
    public bool teleport;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "Bullet";
        player = GameObject.Find("Player");
        barrel = GameObject.Find("firePoint");

        barrel.GetComponent<Barrel>();
        player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(1) && player.GetComponent<PlayerMovement>()._dead == false)
        {
            StartCoroutine(TeleportPlayer());
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.right * speed;
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
        yield return new WaitForSeconds(0.10f);
        player.transform.position = gameObject.transform.position;
        barrel.GetComponent<Barrel>().ammo = 1;
        barrel.GetComponent<Barrel>().scytheActive = false;
        Destroy(gameObject);
    }
}
