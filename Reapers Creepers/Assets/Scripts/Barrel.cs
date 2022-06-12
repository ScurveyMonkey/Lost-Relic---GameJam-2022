using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    //public
    public GameObject projectilePrefab;
    public GameObject player;
    public Transform reticle;
    public bool active;

    //private
    [SerializeField] private Transform firePoint;
    private Vector2 lookDirection;
    private int ammo = 1;
    private float lookAngle;
    private float distance;



    private void Start()
    {
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
                GameObject firedBullet = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
                firedBullet.GetComponent<Rigidbody2D>().velocity = firePoint.right * 10f;
                distance = Vector2.Distance(firedBullet.transform.position, player.transform.position);
                active = true;
                Debug.Log("Distance of bullet to player: " + distance);
                --ammo;
            }


        }
        if (lookDirection.x < 0)
        {
            lookAngle = Mathf.Atan2(-lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
            firePoint.rotation = Quaternion.Euler(0f, 0f, -lookAngle);

            if (Input.GetMouseButtonDown(0) && player.GetComponent<PlayerMovement>()._facingRight != true && ammo > 0 && !active)
            {
                GameObject firedBullet = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
                firedBullet.GetComponent<Rigidbody2D>().velocity = firePoint.right * 10f;
                active = true;
                --ammo;
            }

        }
        if (ammo < 1)
        {
            if (Input.GetMouseButtonDown(1))
            {
                Debug.Log("Ammo added");
                active = false;
                ++ammo;
            }
        }
    }

}
