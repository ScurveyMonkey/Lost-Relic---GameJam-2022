using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    public GameObject projectilePrefab;
    PlayerMovement playerController;
    public GameObject player;
    public Transform reticle;
    private Vector2 lookDirection;
    public int ammo = 1;
    float lookAngle;
    public bool active;
    [SerializeField] private Transform firePoint;


    private void Start()
    {
        playerController = player.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        reticle.position = new Vector2(transform.position.x + lookDirection.x, transform.position.y + lookDirection.y);

        if (lookDirection.x > 0)
        {
            lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
            firePoint.rotation = Quaternion.Euler(0f, 0f, lookAngle);
            if (Input.GetMouseButtonDown(0) && player.GetComponent<PlayerMovement>()._facingRight == true && ammo > 0 && !active)
            {
                Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
                projectilePrefab.GetComponent<Rigidbody2D>().velocity = firePoint.right * 10f;
                active = true;
                --ammo;
                if (Input.GetMouseButtonDown(1))
                {
                    Debug.Log("Right button");
                }
            }
        }
        if (lookDirection.x < 0)
        {
            lookAngle = Mathf.Atan2(-lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
            firePoint.rotation = Quaternion.Euler(0f, 0f, -lookAngle);
            if (Input.GetMouseButtonDown(0) && player.GetComponent<PlayerMovement>()._facingRight != true && ammo > 0 && !active)
            {
                Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
                projectilePrefab.GetComponent<Rigidbody2D>().velocity = firePoint.right * 10f;
                active = true;
                --ammo;
            }
        }
        if (ammo < 1)
        {
            active = false;
            ++ammo;
        }
    }

}
