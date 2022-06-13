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
                Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
                active = true;
                --ammo;
            }
            if(active == true && projectilePrefab.transform.position.x > 10)
            {
                Destroy(projectilePrefab);
            }


        }
        if (lookDirection.x < 0)
        {
            lookAngle = Mathf.Atan2(-lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
            firePoint.rotation = Quaternion.Euler(0f, 0f, -lookAngle);

            if (Input.GetMouseButtonDown(0) && player.GetComponent<PlayerMovement>()._facingRight != true && ammo > 0 && !active)
            {
                Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
                active = true;
                --ammo;
            }

        }
        if (ammo < 1)
        {
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                Debug.Log("Ammo added");
                active = false;
                ++ammo;
            }
        }
    }

}
