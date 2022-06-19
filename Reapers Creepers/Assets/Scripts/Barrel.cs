using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    //public
    public GameObject projectilePrefab;
    public GameObject player;
    public Transform reticle;
    public bool scytheActive;
    public int ammo = 1;


    //private
    [SerializeField] private Transform firePoint;
    private Vector2 lookDirection;
    private AudioSource audioSource;
    private bool dead;
    private float lookAngle;



    private void Start()
    {
        player.GetComponent<PlayerMovement>()._facingRight = true;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        dead = player.GetComponent<PlayerMovement>()._dead;
        if (dead == false)
        {
            if (ammo > 0)
            {
                if (lookDirection.x > 0)
                {
                    if (player.GetComponent<PlayerMovement>()._facingRight == true)
                    {
                        if (Input.GetMouseButtonDown(0) && !scytheActive)
                        {
                            ScytheThrow();
                        }
                    }
                    else
                    {

                    }
                }
                else
                {
                    if (player.GetComponent<PlayerMovement>()._facingRight == false)
                    {
                        if (Input.GetMouseButtonDown(0) && !scytheActive)
                        {
                            ScytheThrow();   
                        }
                    }
                    else
                    {

                    }
                }
            }
        }


    }
    private void FixedUpdate()
    {
        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        firePoint.rotation = Quaternion.Euler(0f, 0f, lookAngle);
        reticle.position = new Vector2(transform.position.x + lookDirection.x, transform.position.y + lookDirection.y);
    }

    void ScytheThrow()
    {        
        Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        scytheActive = true;
        audioSource.Play();
        --ammo;
    }

}
